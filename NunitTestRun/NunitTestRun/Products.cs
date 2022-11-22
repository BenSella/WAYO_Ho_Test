using OpenQA.Selenium;

namespace NunitTestRun
{
    internal class Products
    {
        public Products(IWebDriver driver)
        {
            this.webDriver = driver;
        }
        private IWebDriver webDriver;
        By productsMenue = By.XPath("//a [text()='מוצרים']");
        By houseFurnitureS = By.XPath("//a [text()='ריהוט לבית']");
        By tables = By.XPath("//a [text()='שולחנות']");
        By coffeTable = By.XPath("//span[text()='שולחנות קפה וצד']");
        By coffeTableSearch = By.XPath("//span[@class = 'pip-header-section__title--small notranslate']");
        By whiteColor = By.XPath("//img[@alt='TRULSTORP שולחן קפה, לבן, ‎115x70 ס\"מ‏']");
        By ikeaOnStock = By.XPath("//button [text()='לבירור מלאי לרכישה בחנויות איקאה']");
        By natanyaBranch = By.XPath("//input[@id='store_206']");
        By chooseStorButton = By.XPath("//span[text()='בחר חנות זו']");
        By isProductAvailable = By.XPath("//span [text()=' - מוצר במלאי']");
        public void productSearch()
        {
            webDriver.Navigate().Refresh();
            Thread.Sleep(2000);
            webDriver.FindElement(productsMenue).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(houseFurnitureS).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(tables).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(coffeTable).Click();
        }

        public Boolean searchProduct(String str)
        {
            ScreenManagment screenManagment = new ScreenManagment(webDriver);
            Thread.Sleep(1500);
            List<IWebElement> list = webDriver.FindElements(coffeTableSearch).ToList();
            foreach (var item in list)
            {
                if (item.Text.Equals(str))
                {
                    screenManagment.scrollToObject("//span[@class = 'pip-header-section__title--small notranslate']");
                    item.Click();
                    return true;
                }

            }
            return false;
        }
        public void whiteColorCoice()
        {
            Thread.Sleep(1000);
            webDriver.FindElement(whiteColor).Click();
        }
        public Boolean isProductavailable()
        {
            webDriver.Navigate().Refresh();
            Thread.Sleep(3000);   //some times it take the site a long time to refresh, there for the wait
            webDriver.FindElement(ikeaOnStock).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(natanyaBranch).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(chooseStorButton).Click();
            Thread.Sleep(1000);
            var massageTxt = webDriver.FindElement(isProductAvailable).Text;
            return (massageTxt.Equals("חנות - מוצר במלאי"));

        }
    }
}
