using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace NunitTestRun
{
    internal class Entry
    {
        public Entry(IWebDriver driver)
        {
            this.webDriver = driver;
        }
        private IWebDriver webDriver;
        ScreenManagment screenManagment;
        String checkUrl = "https://www.ikea.com/il/he/profile/dashboard/";
        
        By aprovingCookiesButton = By.XPath("//button [text()='אישור']");
        By myProfileIcon = By.XPath("//li[@id='hnf-header-profile']");  // my profile button 
        By createAcountButton = By.XPath("//span[text()='יצירת חשבון']"); // create acount icon
        By enterRegisterName = By.XPath("//input[@id='regular-signup-form-firstName']"); // registration enter name
        By enterRegisterFamily = By.XPath("//input[@id='regular-signup-form-lastName']"); // registration enter family name
        By enterRegisterMail = By.XPath("//input[@id='regular-signup-form-username']"); // registration eMail
        By enterRegisterPassword = By.XPath("//input[@id='regular-signup-form-password']"); // enter Password
        By privacyMassage = By.XPath("//span [text() = 'ודאי נודע לך על מדיניות הפרטיות.']");
        By homePage = By.XPath("//div [@class='hnf-header__logo']//a [@class ='hnf-link']");//return homepage
        By pressX = By.XPath("//div [@class='profile__toast-close-icon']"); //x button of massage הטופס
        By privacyAgreement = By.XPath("//div//input[@type='checkbox'][@name='acceptPrivacyPolicy']"); // privacy agreement putton
        By creatingAcountButton = By.XPath("//span[@class='profile__btn__inner profile__btn__inner--primary']");// create acount button
        By emainExistsMassage = By.XPath("//div[@class='profile__toast__body']//span[@class='profile__text-block profile__text-bold']");// email exists massage
        By addingCelolarNumber = By.XPath("//span//a[@rel='noopener noreferrer']");// adding celolar number
        By notAddingCellNumber = By.XPath("//a[@class='profile__link profile__link-underline profile__link-colour-grey-900 profile__missing-data-notification-dismiss-link profile__link']");//not inculde phone number
        By savingChanges = By.XPath("//button[@id='regular-dashboard-account-contact-form-submit']"); //save ProfileChanges
        By loginMail = By.XPath("//input [@id='login-form-username']");//login Mail
        By loginPassword = By.XPath("//input [@id='login-form-password']");// login password
        By entryWithUsername = By.XPath("//span[@class='profile__btn__inner profile__btn__inner--primary']");//entryge
        public Boolean registration(String name, String family, String mail, String pass)
        {
            
            screenManagment = new ScreenManagment(webDriver);
            Actions action = new Actions(webDriver);
            webDriver.FindElement(myProfileIcon).Click();
            Thread.Sleep(10000);
            webDriver.FindElement(createAcountButton).Click();
            Thread.Sleep(3000);
            webDriver.FindElement(enterRegisterName).SendKeys(name);
            Thread.Sleep(1000);
            webDriver.FindElement(enterRegisterFamily).SendKeys(family);
            Thread.Sleep(1000);
            webDriver.FindElement(enterRegisterMail).SendKeys(mail);
            Thread.Sleep(1000);
            webDriver.FindElement(enterRegisterPassword).SendKeys(pass);
            Thread.Sleep(1000);
            screenManagment.scrollToObjectAlinment("//div//input[@type='checkbox'][@name='acceptPrivacyPolicy']");
            webDriver.FindElement(privacyAgreement).Click();
            try
            {
                webDriver.FindElement(creatingAcountButton).Click();
                Thread.Sleep(2000);
                var qprivacyMassage = webDriver.FindElement(privacyMassage).Text;
                if (qprivacyMassage.Equals("ודאי נודע לך על מדיניות הפרטיות."))
                {

                   webDriver.FindElement(privacyAgreement).Click();// needed double click, the double click app didnt worked and this seemed the only way to activate the agreement button
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("registration button problem" + ex);
            }
            Thread.Sleep(1000);
            webDriver.FindElement(creatingAcountButton).Click();
            Thread.Sleep(10000);
            try
            {
                var massageTxt = webDriver.FindElement(emainExistsMassage).Text;
                if (massageTxt.Equals("הטופס לא הוגש"))
                {
                    Console.WriteLine("usier is already rejisterd, loging in");
                    //webDriver.FindElement(myProfileIcon).Click();
                    //entry();
                    Thread.Sleep(1000);
                    webDriver.FindElement(pressX).Click();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("user registration problem problem" + ex);
            }
         return true;
        }
        public void personalAreaRemovePhone()
        {
            Thread.Sleep(5000);
            try
            {
                webDriver.FindElement(notAddingCellNumber).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("cant find not addong cell number object" + ex);// logger.Error("error", ex);
            }

            Thread.Sleep(1000);
            try
            {
                webDriver.FindElement(savingChanges).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no save changes option" + ex);// logger.Error("error", ex);
            }

        }
        public void logIn(String mail,String pass)
        {
            webDriver.FindElement(myProfileIcon).Click();
            Thread.Sleep(1000);
            webDriver.FindElement(loginMail).SendKeys(mail);
            Thread.Sleep(1000);
            webDriver.FindElement(loginPassword).SendKeys(pass);
            Thread.Sleep(1000);
            webDriver.FindElement(entryWithUsername).Click();
        }
        public void aproveCookies()
        {
            webDriver.FindElement(aprovingCookiesButton).Click();
        }
        public void HomePage()
        {
            Thread.Sleep(1000);
            webDriver.Navigate().Refresh();
            screenManagment.scrollToObjectAlinment("//div [@class ='hnf-header__logo']");
            webDriver.FindElement(homePage).Click();
        }
        private string getURL()
        {
            Thread.Sleep(2000);
            String s = webDriver.Url.ToString();
            return s;

        }
        

    }
}
