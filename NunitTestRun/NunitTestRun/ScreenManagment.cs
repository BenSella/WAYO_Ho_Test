using OpenQA.Selenium;

namespace NunitTestRun
{
    internal class ScreenManagment
    {
        public ScreenManagment(IWebDriver driver)
        {
            this.webDriver = driver;
        }
        private IWebDriver webDriver;
        public void windowMax()
        {
            webDriver.Manage().Window.Maximize();
        }
        public void windowMed(int wide, int length)
        {
            webDriver.Manage().Window.Size = new System.Drawing.Size(wide, length);
        }
        public void quit()
        {
            webDriver.Quit();
        }
        public void wait(int time)
        {
            // webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public void scrollToObject(String str)
        {
            // WebElement scr = (WebElement)webDriver.FindElement(By.XPath(str));
            IWebElement scr = webDriver.FindElement(By.XPath(str));
            IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scr);
            // js.ExecuteScript("window.scrollBy(0,-500);");
        }
        public void scrollToObjectAlinment(String str)
        {
            // WebElement scr = (WebElement)webDriver.FindElement(By.XPath(str));
            IWebElement scr = webDriver.FindElement(By.XPath(str));
            IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scr);
            js.ExecuteScript("window.scrollBy(0,-500);");
        }


    }
}
