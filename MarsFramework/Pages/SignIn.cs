using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div[1]/div/a")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[1]/input")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[2]/input")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div/div[1]/div/div[4]/button")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        internal void LoginSteps()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2,"Url"));

            Global.GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.XPath("//*[@id='home']/div/div/div[1]/div/a"), 2);

            SignIntab.Click();

            Global.GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver,By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"), 2);

            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));

            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            LoginBtn.Click();
        }
    }
}