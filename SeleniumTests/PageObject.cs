using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumTests
{
    class PageObject
    {
        [Obsolete]
        public PageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='Title']")]
        public IWebElement txtTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Author']")]
        public IWebElement txtAuthor { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Publisher']")]
        public IWebElement txtPublisher { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Date']")]
        public IWebElement txtReleaseDate { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Pages']")]
        public IWebElement txtPages { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='SubmitBook']")]
        public IWebElement btnSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='Review']")]
        public IWebElement txtBookTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='Rating']")]
        public IWebElement txtBookRating { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='SubmitReview']")]
        public IWebElement btnReviewSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='openTitle']")]
        public IWebElement btnOpen { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='cardContainerOpened']//*[@class='redButtonOpened ng-binding']")]
        public IWebElement btnClose { get; set; }
    }
}
