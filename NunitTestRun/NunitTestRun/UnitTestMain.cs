using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework.Internal;
using NLog;

namespace NunitTestRun
{
    public class Tests
    {
        IWebDriver webDriver;
        ScreenManagment screen;
        Entry entry;
        Products products;

        [SetUp]
        public void Setup()
        {
            LogWriter.LogLine("Begining of test");
            webDriver = new ChromeDriver();
            LogWriter.LogLine("add chrome driver");
            screen = new ScreenManagment(webDriver);
            LogWriter.LogLine("add screen manager object");  // screen manager object 
            entry = new Entry(webDriver);
            LogWriter.LogLine("add user entry object");      // user entry object (login)
            products = new Products(webDriver);
            LogWriter.LogLine("add product object");     // product object
            string web = "https://www.ikea.com/il/he/";
            LogWriter.LogLine(web + " the tested site");
            webDriver.Navigate().GoToUrl(web);
            LogWriter.LogLine("go to ural");
            Console.WriteLine("site is on");
            screen.windowMax();
            LogWriter.LogLine("maximazing screen by screen manager");
            Thread.Sleep(3000);
            LogWriter.LogLine("waiting 3 sec");
            entry.aproveCookies();
            LogWriter.LogLine("clicking on aproveCookies\nSetup Complete seccesfuly.");
            LogWriter.WriteLinesToFile();
        }

        // test case 1 new user
        [Test]
        public void FTSighnIn()
        {
            LogWriter.LogLine("Functunality Testing (TSighnIn) test is begining");
            LogWriter.LogLine("test ment for unrejisterd user");
            if (entry.registration("גיורא", "שמואיד", "shigri@gmail.com", "Q1w2e3r4t5"))
            {
                LogWriter.LogLine("user is unrejistered, continue test");
                products.productSearch();
                LogWriter.LogLine("search path");  //pruduct search path    
                if (products.searchProduct("TRULSTORP"))                   // products.searchProduct();  //"TRULSTORP"
                {
                    LogWriter.LogLine("will search for TRULSTORP product");
                    products.whiteColorCoice();
                    if (products.isProductavailable())
                        LogWriter.LogLine("Itam is available at given branch /n test 1 complited seccesfuly");

                    else
                        LogWriter.LogLine("item is not available at given branch");
                }
                else
                {
                    LogWriter.LogLine("item not found");
                }
            }
            else
                LogWriter.LogLine("not a new user, test aborted");
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            entry.HomePage();
            Thread.Sleep(1000);
             LogWriter.LogLine("waiting 1 sec");
            screen.quit();
            LogWriter.LogLine("FTSSignIn complete.");
            LogWriter.WriteLinesToFile();
        }

    // test case 2 - not a new user will try to rejister, system wont alow, user will sighn in
    [Test]
    public void FTUserAlreadyRejisterd()
    {
        LogWriter.LogLine("Functunality Testing (FTUser Already Rejisterd) test is begining");
        LogWriter.LogLine("test ment for rejistered user");
        Thread.Sleep(1000);
        LogWriter.LogLine("waiting 1 sec");
        if (entry.registration("בן", "סלע", "ben.sella@gmail.com", "Q1w2e3r4t5") == false)
        {
            LogWriter.LogLine("not a new user, sighning in");
            Console.WriteLine("not a new user, sighning in");
            entry.logIn("ben.sella@gmail.com", "Q1w2e3r4t5");
            LogWriter.LogLine("login with valid user parameters");
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            entry.HomePage();
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            screen.quit();
            LogWriter.LogLine("FTUserAlreadyRejisterd test 2 complete seccesfuly.");
            LogWriter.WriteLinesToFile();
        }
        else
        {
            Console.WriteLine("wrong data or a new user, test Failed");
            LogWriter.LogLine("wrong data or a new user, test Failed");
            LogWriter.WriteLinesToFile();
        }
    }

    //test case 3 - not a new user will try to rejister, system wont alow, user will press not to rejister phone
    [Test]
    public void FTestUserAlreadyRejisterdDeletingPhone()
    {
        LogWriter.LogLine("Functunality Testing (FTest User Already Rejisterd Deleting Phone) test is begining");
        LogWriter.LogLine("test ment for rejistered user");
        Thread.Sleep(1000);
        LogWriter.LogLine("waiting 1 sec");
        if (entry.registration("בן", "סלע", "ben.sella@gmail.com", "Q1w2e3r4t5") == false)
        {
            LogWriter.LogLine("not a new user, sighning in");
            Console.WriteLine("not a new user, sighning in");
            entry.logIn("ben.sella@gmail.com", "Q1w2e3r4t5");
            LogWriter.LogLine("rejistering with valid data");
            entry.personalAreaRemovePhone();
            LogWriter.LogLine("canceling adding phone option");
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            entry.HomePage();
            LogWriter.LogLine("homepage");
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            screen.quit();
            LogWriter.LogLine("Test 3 complited seccesuly/n exit site");
            LogWriter.WriteLinesToFile();

        }
        else
        {
            Console.WriteLine("wrong data or a new user, test Failed");
            LogWriter.LogLine("wrong data or a new user, test Failed");
            LogWriter.WriteLinesToFile();
        }
    }
    //test case 4 - log in and search item
    [Test]
    public void userRejisterdLogInSearchItem()
    {
        LogWriter.LogLine("Functunality Testing (user Rejisterd LogIn Search Item) test is begining/nchcking if user is not rejisterd");
        if (entry.registration("בן", "סלע", "ben.sella@gmail.com", "Q1w2e3r4t5") == false)
        {
            LogWriter.LogLine("user is rejisterd, loging in");
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            entry.logIn("ben.sella@gmail.com", "Q1w2e3r4t5");
            LogWriter.LogLine("rejistering with valid data");
            products.productSearch();                                //pruduct search path    
            LogWriter.LogLine("item TRULSTORP search");
            if (products.searchProduct("TRULSTORP"))                // products.searchProduct();  //"TRULSTORP"
            {
                products.whiteColorCoice();
                if (products.isProductavailable())
                {
                    Console.WriteLine("Itam is available at given branch");
                    LogWriter.LogLine("Itam is available at given branch/n Test 3 complited seccesuly");

                }
                else
                {
                    Console.WriteLine("item is not available at given branch");
                    LogWriter.LogLine("item is not available at given branch");

                }
            }
            else Console.WriteLine("item not found"); //  logger.Error("Item not found", ex);
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            entry.HomePage();
            LogWriter.LogLine("homepage");
            Thread.Sleep(1000);
            LogWriter.LogLine("waiting 1 sec");
            screen.quit();
            LogWriter.LogLine("exit site");
            LogWriter.WriteLinesToFile();

        }
        else
        {
            Console.WriteLine("not a rejisterd user, test aborted");
            LogWriter.LogLine("test Failed");
            LogWriter.WriteLinesToFile();
        }


    }

}

}