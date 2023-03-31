using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2070_Assignment3
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;
        public IDictionary<string, object> vars { get; private set; }
        private IJavaScriptExecutor js;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }
        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void test1TestValidDataWithNoAccidentsAndAge25Exp3()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Potter");
            driver.FindElement(By.Id("address")).SendKeys("425, Wilson Avenue");
            driver.FindElement(By.Id("city")).SendKeys("waterloo");
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NL']")).Click();
            }
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("0");
            driver.FindElement(By.Id("btnSubmit")).Click();
            {
                string value = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
                Assert.That(value, Is.EqualTo("$2500"));
            }
        }
        [Test]
        public void test2ValidDataWithAge25Exp3Accident4()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Ayush");
            driver.FindElement(By.Id("lastName")).SendKeys("Vekariya");
            driver.FindElement(By.Id("address")).SendKeys("12-147, Fairway RD N");
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).SendKeys("Kitchener");
            driver.FindElement(By.Id("postalCode")).Click();
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).Click();
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).Click();
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("4");
            driver.FindElement(By.Id("btnSubmit")).Click();
            {
                string value = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
                Assert.That(value, Is.EqualTo("No Insurance for you!!  Too many accidents - go take a course!"));
            }
        }
        [Test]
        public void test3ValidDataWithAge35Exp10Accidents2()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(1296, 736);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Ayush");
            driver.FindElement(By.Id("lastName")).SendKeys("Vekariya");
            driver.FindElement(By.Id("address")).SendKeys("12-147, Fairway RD N");
            driver.FindElement(By.Id("city")).SendKeys("waterloo");
            driver.FindElement(By.Id("postalCode")).SendKeys("n2c 2r8");
            driver.FindElement(By.Id("phone")).Click();
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("ayushshailesbhaivekariya@gmail.com");
            driver.FindElement(By.Id("age")).Click();
            driver.FindElement(By.Id("age")).SendKeys("35");
            driver.FindElement(By.Id("experience")).SendKeys("10");
            driver.FindElement(By.Id("accidents")).SendKeys("2");
            driver.FindElement(By.Id("btnSubmit")).Click();
            {
                string value = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
                Assert.That(value, Is.EqualTo("$1350"));
            }
        }
        [Test]
        public void test4InvalidPhoneNumberWithValidDataAge27Exp3Accidents0()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(660, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Ayush");
            driver.FindElement(By.Id("lastName")).SendKeys("Vekariya");
            driver.FindElement(By.Id("address")).SendKeys("12-147, Fairway RD N");
            driver.FindElement(By.Id("city")).SendKeys("Aerocity, Delhi");
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NL']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'PE']")).Click();
            }
            driver.FindElement(By.Id("postalCode")).Click();
            driver.FindElement(By.Id("postalCode")).SendKeys("n2c 2r8");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-56742");
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).Click();
            driver.FindElement(By.Id("age")).SendKeys("27");
            driver.FindElement(By.Id("experience")).SendKeys("10");
            driver.FindElement(By.Id("experience")).Click();
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("0");
            driver.FindElement(By.Id("btnSubmit")).Click();
            driver.FindElement(By.CssSelector(".col-md-4:nth-child(1)")).Click();
            Assert.That(driver.FindElement(By.Id("phone-error")).Text, Is.EqualTo("Phone Number must follow the patterns 111-111-1111 or (111)111-1111"));
        }
        [Test]
        public void test5InvalidEmailAddressWithValidDataAge28Exp3Accidents0()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Smith");
            driver.FindElement(By.Id("address")).SendKeys("425, Wilson Avenue");
            driver.FindElement(By.Id("city")).SendKeys("kitchener");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushveka.com");
            driver.FindElement(By.Id("age")).Click();
            driver.FindElement(By.Id("age")).SendKeys("28");
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("0");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("email-error")).Text, Is.EqualTo("Must be a valid email address"));
        }
        [Test]
        public void test6InvalidPostalCodeWithValidDataAge35Exp17Accidents1()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Vekariya");
            driver.FindElement(By.Id("lastName")).SendKeys("Vekariya");
            driver.FindElement(By.Id("lastName")).SendKeys(Keys.Down);
            driver.FindElement(By.Id("lastName")).SendKeys(Keys.Tab);
            driver.FindElement(By.Id("address")).SendKeys("425, Wilson Avenue");
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).SendKeys("waterloo");
            driver.FindElement(By.Id("postalCode")).Click();
            driver.FindElement(By.Id("postalCode")).SendKeys("123432");
            driver.FindElement(By.Id("phone")).Click();
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("35");
            driver.FindElement(By.Id("experience")).SendKeys("17");
            driver.FindElement(By.Id("accidents")).SendKeys("1");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("postalCode-error")).Text, Is.EqualTo("Postal Code must follow the pattern A1A 1A1"));
        }
        [Test]
        public void test7AgeOmittedWithValidDataExp5Accidents0()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Ayush");
            driver.FindElement(By.Id("lastName")).SendKeys("Vekariya");
            driver.FindElement(By.Id("address")).SendKeys("425, Wilson Avenue");
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).SendKeys("Kitchener");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushshailesbhaivekariya@gmail.com");
            driver.FindElement(By.Id("experience")).SendKeys("5");
            driver.FindElement(By.Id("accidents")).SendKeys("0");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("age-error")).Text, Is.EqualTo("Age (>=16) is required"));
        }
        [Test]
        public void test8NumAtFaultAccidentsOmittedWithValidDataAge37Exp8()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("John");
            driver.FindElement(By.Id("lastName")).SendKeys("Waltor");
            driver.FindElement(By.Id("address")).SendKeys("1220 Stark Tower");
            driver.FindElement(By.Id("city")).SendKeys("waterloo");
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NL']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'PE']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NS']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NB']")).Click();
            }
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("37");
            driver.FindElement(By.Id("experience")).SendKeys("8");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("accidents-error")).Text, Is.EqualTo("Number of accidents is required"));
        }
        [Test]
        public void test10DiffOfAgeAndExpIsLessThan16()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Joanthan");
            driver.FindElement(By.Id("lastName")).SendKeys("Wick");
            driver.FindElement(By.Id("address")).SendKeys("1220 Stark Tower");
            driver.FindElement(By.Id("city")).SendKeys("kitchener");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushshailesbhaivekariya@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("15");
            driver.FindElement(By.Id("accidents")).SendKeys("0");
            driver.FindElement(By.Id("btnSubmit")).Click();
            {
                string value = driver.FindElement(By.Id("finalQuote")).GetAttribute("value");
                Assert.That(value, Is.EqualTo("No Insurance for you!! Driver Age / Experience Not Correct"));
            }
        }
        [Test]
        public void test9YearsDrivingExperienceOmittedWithValidDataAge45Accidents0()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Winston");
            driver.FindElement(By.Id("lastName")).SendKeys("Belarus");
            driver.FindElement(By.Id("address")).Click();
            driver.FindElement(By.Id("address")).Click();
            driver.FindElement(By.Id("address")).SendKeys("Continental");
            driver.FindElement(By.Id("city")).Click();
            driver.FindElement(By.Id("city")).SendKeys("New York");
            driver.FindElement(By.Id("postalCode")).Click();
            driver.FindElement(By.Id("postalCode")).SendKeys("N2Y 5W6");
            driver.FindElement(By.Id("phone")).Click();
            driver.FindElement(By.Id("phone")).SendKeys("123-987-1289");
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).SendKeys("WinstonB@yahoo.com");
            driver.FindElement(By.Id("age")).Click();
            driver.FindElement(By.Id("age")).SendKeys("45");
            driver.FindElement(By.Id("accidents")).Click();
            driver.FindElement(By.Id("accidents")).SendKeys("0");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("experience-error")).Text, Is.EqualTo("Years of experience is required"));
        }
        [Test]
        public void test11AddressOmittedWithAge25Exp5Accident2()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Ayush");
            driver.FindElement(By.Id("lastName")).Click();
            driver.FindElement(By.Id("lastName")).SendKeys("Wick");
            driver.FindElement(By.Id("city")).SendKeys("waterloo");
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NL']")).Click();
            }
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).Click();
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("avekariya3800@conestogac.on.ca");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("5");
            driver.FindElement(By.Id("accidents")).SendKeys("2");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("address-error")).Text, Is.EqualTo("Address is required"));
        }
        [Test]
        public void test12FirstAndLastNameOmittedWithAge25Exp5Accident1()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("address")).Click();
            driver.FindElement(By.Id("address")).SendKeys("1220 Stark Tower");
            driver.FindElement(By.Id("city")).SendKeys("waterloo");
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("25");
            driver.FindElement(By.Id("experience")).SendKeys("5");
            driver.FindElement(By.Id("accidents")).SendKeys("1");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("firstName-error")).Text, Is.EqualTo("First Name is required"));
            Assert.That(driver.FindElement(By.Id("lastName-error")).Text, Is.EqualTo("Last Name is required"));
        }
        [Test]
        public void test13InvalidAgeWithAge12Exp3Accident0()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Ayush");
            driver.FindElement(By.Id("lastName")).SendKeys("Potter");
            driver.FindElement(By.Id("address")).SendKeys("425, Wilson Avenue");
            driver.FindElement(By.Id("city")).SendKeys("Aerocity, Delhi");
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NL']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'PE']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NS']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NB']")).Click();
            }
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("12");
            driver.FindElement(By.Id("experience")).SendKeys("3");
            driver.FindElement(By.Id("accidents")).SendKeys("0");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("age-error")).Text, Is.EqualTo("Please enter a value greater than or equal to 16."));
        }
        [Test]
        public void test14PhoneNumberOmittedWithAge34Exp6Accident1()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Joanthan");
            driver.FindElement(By.Id("lastName")).SendKeys("Smith");
            driver.FindElement(By.Id("address")).SendKeys("425, Wilson Avenue");
            driver.FindElement(By.Id("city")).SendKeys("waterloo");
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NL']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'PE']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NS']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'NB']")).Click();
            }
            {
                var dropdown = driver.FindElement(By.Id("province"));
                dropdown.FindElement(By.XPath("//option[. = 'QC']")).Click();
            }
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("email")).SendKeys("avekariya3800@conestogac.on.ca");
            driver.FindElement(By.Id("age")).SendKeys("34");
            driver.FindElement(By.Id("experience")).SendKeys("6");
            driver.FindElement(By.Id("accidents")).SendKeys("1");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("phone-error")).Text, Is.EqualTo("Phone Number is required"));
        }
        [Test]
        public void test15CityOmittedWithAge26Exp5Accident1()
        {
            driver.Navigate().GoToUrl("http://localhost/prog2070a03/prog2070a03/getQuote.html");
            driver.Manage().Window.Size = new System.Drawing.Size(652, 720);
            driver.FindElement(By.Id("firstName")).Click();
            driver.FindElement(By.Id("firstName")).SendKeys("Ayush");
            driver.FindElement(By.Id("lastName")).SendKeys("Vekariya");
            driver.FindElement(By.Id("address")).SendKeys("425, Wilson Avenue");
            driver.FindElement(By.Id("postalCode")).Click();
            driver.FindElement(By.Id("postalCode")).SendKeys("N2A 2N4");
            driver.FindElement(By.Id("phone")).SendKeys("234-234-5674");
            driver.FindElement(By.Id("email")).SendKeys("ayushvekariya629@gmail.com");
            driver.FindElement(By.Id("age")).SendKeys("26");
            driver.FindElement(By.Id("experience")).SendKeys("5");
            driver.FindElement(By.Id("accidents")).SendKeys("1");
            driver.FindElement(By.Id("btnSubmit")).Click();
            Assert.That(driver.FindElement(By.Id("city-error")).Text, Is.EqualTo("City is required"));
        }
    }

}
