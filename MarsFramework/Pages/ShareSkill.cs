using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")]
        private IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement Tags { get; set; }

        ////Select the Service type Hourly basis
        //[FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        //private IWebElement ServiceTypeHourly { get; set; }

        ////Select the Service type One-off
        //[FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        //private IWebElement ServiceTypeOneoff { get; set; }

        //Select the Service Type
        [FindsBy(How = How.Name, Using = "serviceType")]
        private IList<IWebElement> serviceOptions { get; set; }

        //Select the Location Type
        //[FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        //private IWebElement LocationTypeOption { get; set; }

        [FindsBy(How = How.Name, Using = "locationType")]
        private IList<IWebElement> LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input")]
        private IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input")]
        private IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement Save { get; set; }

        //Click on Cancel button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[2]")]
        private IWebElement Cancel { get; set; }

        internal void EnterShareSkill()
        {
            ShareSkillButton.Click();

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            Global.GlobalDefinitions.wait(2);

            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));

            Tags.SendKeys(Keys.Enter);

            var serviceOption = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");

            if (serviceOption == "Hourly basis service")
            {
                serviceOptions[0].Click();
            }
            else
            {
                serviceOptions[1].Click();
            }


           var locationTypeValue=GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");

            if(locationTypeValue == "On-site")
            {
                LocationTypeOption[0].Click();
            }
            else
            {
                LocationTypeOption[1].Click();
            }

            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));

            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            Days.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Selectday"));

            StartTime.Click();

            StartTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));

            EndTimeDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            SkillTradeOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade"));

            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));



            ActiveOption.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Active"));

            Save.Click();



        }

        internal void EditShareSkill()
        {

        }
    }
}
