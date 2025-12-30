using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ClosedXML.Excel;
using System.IO;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using WebDriverManager;
using Keys = OpenQA.Selenium.Keys;

namespace GoogleMapsVeriÇekme
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnExport.Enabled = false;

            businessBindingList = new BindingList<BusinessInfo>();
            allBusinesses = new List<BusinessInfo>();

            dgvBusinesses.AutoGenerateColumns = true;
            dgvBusinesses.DataSource = businessBindingList;

            cmbFilterField.Items.AddRange(new[] { "İsim", "Adres", "Telefon", "Web Sitesi" });
            cmbFilterField.SelectedIndex = 0;

            clbColumns.Items.AddRange(new string[]
            {
        "İsim", "Açık Adres", "Puanlama",
        "Değerlendirme", "Telefon", "Web Sitesi", "Link"
            });
            for (int i = 0; i < clbColumns.Items.Count; i++)
                clbColumns.SetItemChecked(i, true);
        }

        private BindingList<BusinessInfo> businessBindingList;
        private List<BusinessInfo> allBusinesses;

        private CancellationTokenSource _cts;
        private int _currentCount = 0;

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string keywords = txtKeywords.Text.Trim();

            if (string.IsNullOrEmpty(keywords))
            {
                MessageBox.Show("Lütfen aramak istediğiniz anahtar kelimeleri girin.");
                return;
            }

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            btnExport.Enabled = false;

            businessBindingList.Clear();
            allBusinesses.Clear();
            _currentCount = 0;
            lblCount.Text = "Toplam kayıt: 0";
            lblStatus.Text = "Durum: Çalışıyor...";

            bool showBrowser = chkShowBrowser.Checked;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            try
            {
                var progress = new Progress<BusinessInfo>(b =>
                {
                    businessBindingList.Add(b);
                    _currentCount++;
                    lblCount.Text = $"Toplam kayıt: {_currentCount}";
                });

                var result = await Task.Run(
                    () => ScrapeGoogleMaps(keywords, progress, showBrowser, token),
                    token);

                allBusinesses = result;

                if (token.IsCancellationRequested)
                {
                    lblStatus.Text = "Durum: Kullanıcı tarafından durduruldu";
                    MessageBox.Show("İşlem durduruldu.");
                }
                else
                {
                    lblStatus.Text = "Durum: Tamamlandı";
                    MessageBox.Show($"Toplam {allBusinesses.Count} kayıt alındı.");
                }

                btnExport.Enabled = allBusinesses.Any();
            }
            catch (OperationCanceledException)
            {
                lblStatus.Text = "Durum: Kullanıcı tarafından durduruldu";
                MessageBox.Show("İşlem durduruldu.");
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Durum: Hata";
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
            finally
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
        }

        private List<BusinessInfo> ScrapeGoogleMaps(
    string keywords,
    IProgress<BusinessInfo> progress,
    bool showBrowser,
    CancellationToken token)
        {
            List<BusinessInfo> businessList = new List<BusinessInfo>();
            HashSet<string> collectedBusinessUrls = new HashSet<string>();

            new DriverManager().SetUpDriver(new ChromeConfig());

            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--lang=en");

            // Kullanıcı pencereyi görmek istemiyorsa headless çalış
            if (!showBrowser)
            {
                options.AddArgument("--headless=new");
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

            // Orijinaldeki gibi istersen UA kullan
            options.AddArgument("user-agent=<your-agent-string>");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                driver.Navigate().GoToUrl("https://www.google.com/maps?hl=en");
                WaitForPageFullLoad(driver);

                var searchBox = driver.FindElement(By.Id("searchboxinput"));
                searchBox.SendKeys(keywords);
                searchBox.SendKeys(Keys.Enter);

                Thread.Sleep(7000); // geç yüklenme durumunda arttırılabilir

                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

                bool moreResultsAvailable = true;

                while (moreResultsAvailable && !token.IsCancellationRequested)
                {
                    // her seferinde feed div'ini tekrar bul
                    var scrollArea = driver.FindElement(By.XPath("//div[@role='feed']"));

                    int previousHeight = Convert.ToInt32(
                        jsExecutor.ExecuteScript("return arguments[0].scrollHeight", scrollArea));

                    jsExecutor.ExecuteScript(
                        "arguments[0].scrollTop = arguments[0].scrollHeight;", scrollArea);

                    Thread.Sleep(5000);

                    // yeniden bul (render değişmiş olabilir)
                    scrollArea = driver.FindElement(By.XPath("//div[@role='feed']"));

                    int newHeight = Convert.ToInt32(
                        jsExecutor.ExecuteScript("return arguments[0].scrollHeight", scrollArea));

                    if (newHeight == previousHeight)
                        moreResultsAvailable = false;

                    var results = driver.FindElements(By.CssSelector(".Nv2PK"));
                    foreach (var result in results)
                    {
                        if (token.IsCancellationRequested)
                            break;

                        try
                        {
                            string url = result.FindElement(By.CssSelector("a")).GetAttribute("href");
                            if (collectedBusinessUrls.Contains(url))
                                continue;

                            string name = "İsim bulunamadı.";
                            string address = "Adres Bulunamadı";
                            string website = "Website bulunamadı.";
                            string phone = "Telefon bilgisi bulunamadı.";
                            string rating = "Puanlama bulunamadı";
                            string review = "Değerlendirme bulunamadı";

                            result.Click();
                            Thread.Sleep(3000);

                            // İsim bilgisi
                            try
                            {
                                name = driver
                                    .FindElement(By.XPath("(//div[@role='main' and @aria-label]//h1)[last()]"))
                                    .Text;
                            }
                            catch (NoSuchElementException) { }

                            // Açık adres bilgisi
                            try
                            {
                                address = driver
                                    .FindElement(By.XPath("//button[contains(@aria-label,'Address:')]//div[@class='AeaXub']"))
                                    .Text;
                            }
                            catch (NoSuchElementException) { }

                            // Web site bilgisi
                            try
                            {
                                website = driver
                                    .FindElement(By.XPath("//a[contains(@aria-label, 'Website')]"))
                                    .GetAttribute("href");
                            }
                            catch (NoSuchElementException) { }

                            // Telefon bilgisi
                            try
                            {
                                phone = driver
                                    .FindElement(By.XPath("//button[starts-with(@aria-label, 'Phone:')]"))
                                    .Text;
                            }
                            catch (NoSuchElementException) { }

                            // Yıldız bilgisi
                            try
                            {
                                rating = driver
                                    .FindElement(By.XPath("//span[contains(@aria-label, 'star')][preceding-sibling::span[1]]"))
                                    .GetAttribute("aria-label");
                            }
                            catch (NoSuchElementException) { }

                            // Değerlendirme bilgisi
                            try
                            {
                                review = driver
                                    .FindElement(By.XPath("//span[contains(@aria-label, 'review') and starts-with(text(), '(')]"))
                                    .Text;
                            }
                            catch (NoSuchElementException) { }

                            var business = new BusinessInfo
                            {
                                Name = name,
                                Address = address,
                                Link = url,
                                Website = website,
                                Phone = phone,
                                Rating = rating,
                                Review = review,
                            };

                            businessList.Add(business);
                            collectedBusinessUrls.Add(url);

                            // UI'ya anlık bas
                            progress?.Report(business);
                        }
                        catch
                        {
                            // loglamak istersen buraya yazarsın
                        }
                    }
                }
            }

            return businessList;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!allBusinesses.Any())
            {
                MessageBox.Show("Dışa aktarılacak kayıt yok.");
                return;
            }

            string searchText = txtKeywords.Text.Trim();

            foreach (char c in Path.GetInvalidFileNameChars())
                searchText = searchText.Replace(c.ToString(), "");

            string safeSearchText = searchText.Replace(" ", "_");
            if (safeSearchText.Length > 50)
                safeSearchText = safeSearchText.Substring(0, 50);

            string fileName = $"Businesses_{safeSearchText}_{DateTime.Now:yyyy-MM-dd}.xlsx";

            string excelPath = SaveToExcel(allBusinesses, fileName);

            MessageBox.Show($"Excel dosyası oluşturuldu:\n{excelPath}");
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            string term = txtFilter.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(term))
            {
                // Filtre boşsa tümünü göster
                businessBindingList.Clear();
                foreach (var b in allBusinesses)
                    businessBindingList.Add(b);
                return;
            }

            string field = cmbFilterField.SelectedItem.ToString();

            IEnumerable<BusinessInfo> filtered = allBusinesses;

            switch (field)
            {
                case "İsim":
                    filtered = allBusinesses.Where(b => (b.Name ?? "").ToLower().Contains(term));
                    break;

                case "Adres":
                    filtered = allBusinesses.Where(b => (b.Address ?? "").ToLower().Contains(term));
                    break;

                case "Telefon":
                    filtered = allBusinesses.Where(b => (b.Phone ?? "").ToLower().Contains(term));
                    break;

                case "Web Sitesi":
                    filtered = allBusinesses.Where(b => (b.Website ?? "").ToLower().Contains(term));
                    break;
            }

            businessBindingList.Clear();
            foreach (var b in filtered)
                businessBindingList.Add(b);
        }

        private void clbColumns_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                string columnName = clbColumns.Items[e.Index].ToString();

                string propName = null;

                switch (columnName)
                {
                    case "İsim":
                        propName = "Name";
                        break;

                    case "Açık Adres":
                        propName = "Address";
                        break;

                    case "Puanlama":
                        propName = "Rating";
                        break;

                    case "Değerlendirme":
                        propName = "Review";
                        break;

                    case "Telefon":
                        propName = "Phone";
                        break;

                    case "Web Sitesi":
                        propName = "Website";
                        break;

                    case "Link":
                        propName = "Link";
                        break;

                    default:
                        propName = null;
                        break;
                }

                if (propName == null) return;

                var col = dgvBusinesses.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.DataPropertyName == propName);

                if (col != null)
                    col.Visible = clbColumns.GetItemChecked(e.Index);
            }));
        }

        private void WaitForPageFullLoad(IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(30))
                .Until(d => js.ExecuteScript("return document.readyState").Equals("complete"));
        }

        private string SaveToExcel(List<BusinessInfo> businesses, string fileName)
        {
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                fileName);

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Businesses");

                var headers = new string[]
                {
            "İsim", "Açık Adres", "Puanlama",
            "Değerlendirme", "Telefon", "Web Sitesi", "Link"
                };

                for (int col = 0; col < headers.Length; col++)
                {
                    var cell = worksheet.Cell(1, col + 1);
                    cell.Value = headers[col];
                    cell.Style.Font.Bold = true;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                }

                for (int i = 0; i < businesses.Count; i++)
                {
                    var row = i + 2;
                    worksheet.Cell(row, 1).Value = businesses[i].Name;
                    worksheet.Cell(row, 2).Value = businesses[i].Address;
                    worksheet.Cell(row, 3).Value = businesses[i].Rating;
                    worksheet.Cell(row, 4).Value = businesses[i].Review;
                    worksheet.Cell(row, 5).Value = businesses[i].Phone;
                    worksheet.Cell(row, 6).Value = businesses[i].Website;
                    worksheet.Cell(row, 7).Value = businesses[i].Link;

                    if (i % 2 == 1)
                    {
                        worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.LightCyan;
                    }
                }

                worksheet.Columns().AdjustToContents();
                worksheet.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.RangeUsed().Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                workbook.SaveAs(filePath);
            }

            return filePath;
        }

        private class BusinessInfo
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Link { get; set; }
            public string Website { get; set; }
            public string Phone { get; set; }
            public string Rating { get; set; }
            public string Review { get; set; }
        }

        private bool isWhite = true;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Dark Mode Özellikleri
            if (isWhite)
            {
                this.BackColor = Color.White;
                materialLabel1.ForeColor = Color.Black;
                materialLabel2.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.FromArgb(54, 54, 54);
                materialLabel2.ForeColor = Color.White;
            }
            isWhite = !isWhite;
        }
    }
}