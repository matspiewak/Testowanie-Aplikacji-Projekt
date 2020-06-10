using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    class Program
    {
        static void Main(string[] args){ }
        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new ChromeDriver();
            PropertiesCollection.driver.Navigate().GoToUrl("localhost:8080");
            Console.WriteLine("Otwarto stronę");
        }
        [Test]
        public void AddBookReview()
        {
            PageObject pageObject = new PageObject();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            pageObject.btnOpen.Click();
            pageObject.txtBookTitle.SendKeys("Lalka");
            pageObject.txtBookRating.SendKeys("3");
            pageObject.btnReviewSubmit.Click();
            pageObject.btnClose.Click();
            Console.WriteLine("Otwarto szczegóły");
        }
        [Test]
        public void AddBookTitle()
        {
            PageObject pageObject = new PageObject();
            pageObject.txtTitle.SendKeys("Przedwiośnie");
            pageObject.txtAuthor.SendKeys("Stefan Żeromski");
            pageObject.txtPublisher.SendKeys("GREG");
            pageObject.txtReleaseDate.SendKeys("2002-01-01");
            pageObject.txtPages.SendKeys("232");
            pageObject.btnSubmit.Click();

            Console.WriteLine("Dodano pozycję");
        }
        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();

            Console.WriteLine("Zamknięto przegląarke");
        }
    }
}
