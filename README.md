# Unit ans Selenium Tests
Testing .net Core applications,AngularJs Front-End

## Table of contents

* [Techonogies](#Technologies)
* [Tested application](#Tested-application)
* [Tested Features NUnits](#Tested-Features-NUnits)
* [Tested Features Selenium](#Tested-Features-Selenium)
* [Setup](#Setup)
* [Code examples](#Code-examples)

## Technologies

* NUnit
* Selenium

## Tested application
.net Core Web Api Application as well as Main Page created with AngularJS, allowing allowing to show, post and edit books and book reviews.

## Tested Features NUnit

* User (POST)
* Books (CRUD)
* Book Reviews (CRUD)

## Tested Features with Selenium
* Posting new book
* Posting new book review


## Setup
To setup this project you need to download content of this repository and open it up in Visual Studio (Created with Visual Studio 2019, ver. 16.5.1<br>
Additionally in order to execute Selenium tests you have to start main project and also you need to start http server (http-server) on port 8080, by using command prompt in Front-End catalog.

## Code examples
* Test of Get action, with creating DbContext - NUnit
---
        DbContextOptions<BookReviewContext> options;
        public DbContextOptions<BookReviewContext> setUp()
        {
            options = new DbContextOptionsBuilder<BookReviewContext>()
                .UseInMemoryDatabase(databaseName: "BookReviews")
                .Options;

            using (var context = new BookReviewContext(options))
            {
                if(context.BookReviews.Count() == 0)
                {
                    context.BookReviews.Add(new BookReview { Id = 1, Rating = 4, Review = "Hey, that's pretty good", Title = "Lalka" });
                    context.SaveChanges();
                }
            }

            return options;
        }
        [Test]
        public void GetBookReviews_ReturnsAllBookReviewsList()
        {
            setUp();
            using(var context = new BookReviewContext(options))
            {
                var bookReviewsController = new BookReviewsController(context);
                var result = bookReviewsController.GetBookReviews().ToList();

                Assert.That(result.Count.Equals(context.BookReviews.ToList().Count));
            }
        }
---
* Finding page objects by theirs xpaths - Selenium
---
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
---
* Add new book review test - Selenium
---
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
---
## Author
Tests made by Mateusz Śpiewak
