using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;

namespace ShreeTranslink
{
    [TestClass]
    public class TranslinkTest
    {
        private IWebDriver _webdriver;
        
        [TestInitialize()]
 
        public void LaunchDriverInitialize()  
        {           
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"D:\\Projects\\TranslinkBus\\geckodriver-v0.29.1-win32", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            _webdriver = new FirefoxDriver(service);
        }

        [TestMethod]
        public void VerifyHomePage()
        {    // 1 Lauch any browser and goto https://new.translink.ca/   
            _webdriver.Navigate().GoToUrl("https://www.translink.ca");        
            _webdriver.Manage().Window.Maximize();

            // 2 Click on "Find My Next tab widget
            var button = _webdriver.FindElement(By.XPath("//button[contains(text(), 'Next Bus')]"));
            button.Click();

            // 2. a. Enter 99
            var BusSearch = _webdriver.FindElement(By.Id("NextBusSearchTerm"));
            BusSearch.SendKeys("99");
            
            // 2. b. Click on "Find My next bus" button
            var PlanmyTrip = _webdriver.FindElement(By.XPath("//button[contains(text(), 'Find my next bus')]"));
            PlanmyTrip.Click();

            // 3 Click on "Add Fav" Icon
            var AddDelFavorite = _webdriver.FindElement(By.ClassName("AddDelFav"));
            AddDelFavorite.Click();

            // 4 Enter "Translink auto Homework" in the Edit Name
            var FavoriteName = _webdriver.FindElement(By.Name("newFavourite"));   
            FavoriteName.SendKeys("Translink Auto Homework");

            // 5 Click on "Add to Favorites" button
            var AddtoFavorite = _webdriver.FindElement(By.XPath("//button[contains(text(), 'Add to Favourites')]"));
            AddtoFavorite.Submit();

            // 6 Click on "My Favs" icon
            _webdriver.Navigate().GoToUrl("https:www.translink.ca/next-bus/favourites/");
            //      var myFavorite = _webdriver.FindElement(By.XPath("//button[contains(text(), 'My Favs')]"));
            //      myFavorite.Click();

            // 7 Validate "Translink Auto Homework" link is present
            // 8 Click on "Translink Auto Homework" link
            var myLink = _webdriver.FindElement(By.PartialLinkText("Homework"));
            myLink.Click();
            if (myLink.Displayed)
                {
                myLink.Click();               
                }

            // 9 Validate "99 Commercial-Broadway / UBC (B-Line)" Displayed on page
            // _webdriver.Navigate().GoToUrl("https://www.translink.ca/next-bus/results/#/text/route/99/");
            var myBroadway = _webdriver.FindElement(By.PartialLinkText("Broadway"));
             
            // 10 Click on To "Comm'l-Bdway Stn / Boundary B-Line                     
            var LineB = _webdriver.FindElement(By.PartialLinkText("Boundary"));           
            LineB.Click();

            // 11 Click on "UBC Exchange Bay 7"
            var Bay7 = _webdriver.FindElement(By.PartialLinkText("UBC Exchange Bay 7"));
            Bay7.Click();  
        
           // 12 Validate "Stop # 6193" is Displaying
           Boolean blnStopNumber = _webdriver.FindElement(By.PartialLinkText("61935")).Displayed;
        }       
    }
}
