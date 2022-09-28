//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium
{
	public class Test
	{
		/// <summary>
		/// Shortcut variable for the web driver.
		/// </summary>
		protected IWebDriver driver;

		/// <summary>
		/// Finds an IWebElement by it's ID in the HTML file.
		/// </summary>
		/// <param name="Id"> ID in the HTML file</param>
		/// <returns>IWebElement with specified ID</returns>
		public IWebElement FindById(string Id)
		{
			return driver.FindElement(By.Id(Id));
		}

		[SetUp]
		public void CreateDriver()
		{
			//new DriverManager().SetUpDriver(new EdgeConfig());
			//new EdgeDriver();
			new DriverManager().SetUpDriver(new ChromeConfig());
			driver = new ChromeDriver();

			driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
		}

		
		//[TearDown]
		public void QuitDrivers()
		{
			driver.Quit();
		}

		[Test]
		public void firstNameTest()
		{
			var firstName = FindById("firstName");
			firstName.SendKeys("Max");
		}

		[Test]
		public void lastNameTest()
		{
			var lastName = FindById("lastName");
			lastName.SendKeys("Mustermann");
		}

		[Test]
		public void emailTest()
		{
			var userEmail = FindById("userEmail");
			userEmail.SendKeys("Max.Mustermann@hotmail.com");
		}

		[Test]
		public void genderTest()
		{
			var gender = FindById("gender-radio-3");
			gender.SendKeys(Keys.Space);
		}

		[Test]
		public void phoneTest()
		{
			var mobileNumber = FindById("userNumber");
			mobileNumber.SendKeys("1234564212");
		}

		[Test]
		public void dateOfBirthTest()
		{
			var dateOfBirthPicker = FindById("dateOfBirthInput");
			dateOfBirthPicker.SendKeys("28 Mar 2003" + Keys.Enter);

			for (var i = 0; i< 4; i++)
			{
				dateOfBirthPicker.SendKeys(Keys.Backspace);
			}

			dateOfBirthPicker.SendKeys("03");
		}
		[Test]
		public void subjectTest()
		{
			var subjectInput = FindById("subjectsInput");
			subjectInput.SendKeys("Computer Science");
			subjectInput.SendKeys(Keys.Enter);
		}

		[Test]
		public void hobbiesTest()
		{
			var hobbies2 = FindById("hobbies-checkbox-2");
			hobbies2.SendKeys(Keys.Space);

			var hobbies3 = FindById("hobbies-checkbox-3");
			hobbies3.SendKeys(Keys.Space);
		}

		[Test]
		public void pictureTest()
		{
			var picture = FindById("uploadPicture");
			picture.SendKeys("C:\\Users\\MaxM\\source\\repos\\KuroiMori\\SeleniumTest\\Selenium\\picture\\testPicture.jpg");
		}

		[Test]
		public void addressTextTest()
		{
			var address = FindById("currentAddress");
			address.SendKeys("Musterstr.. 33");
		}

		[Test]
		public void stateAndCityTest()
		{
			var state = FindById("react-select-3-input");
			state.SendKeys("NCR");
			state.SendKeys(Keys.Enter);

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);

			var city = FindById("react-select-4-input");
			city.SendKeys("Delhi" + Keys.Enter);
		}

		[Test]
		public void completeFormTest()
		{
			var firstName = FindById("firstName");
			firstName.SendKeys("Max");

			var lastName = FindById("lastName");
			lastName.SendKeys("Mustermann");
		
			var userEmail = FindById("userEmail");
			userEmail.SendKeys("Max.Mustermann@hotmail.com");

			var gender = FindById("gender-radio-3");
			gender.SendKeys(Keys.Space);

			var mobileNumber = FindById("userNumber");
			mobileNumber.SendKeys("1234564212");

			var dateOfBirthPicker = FindById("dateOfBirthInput");
			dateOfBirthPicker.SendKeys("28 Mar 2003" + Keys.Enter);

			for (var i = 0; i < 4; i++)
			{
				dateOfBirthPicker.SendKeys(Keys.Backspace);
			}

			dateOfBirthPicker.SendKeys("03");

			var subjectInput = FindById("subjectsInput");
			subjectInput.SendKeys("Computer Science" );
			subjectInput.SendKeys(Keys.Enter);
		
			var hobbies2 = FindById("hobbies-checkbox-2");
			hobbies2.SendKeys(Keys.Space);

			var hobbies3 = FindById("hobbies-checkbox-3");
			hobbies3.SendKeys(Keys.Space);
		
			var picture = FindById("uploadPicture");
			picture.SendKeys("C:\\Users\\Maxw\\source\\repos\\KuroiMori\\SeleniumTest\\Selenium\\picture\\testPicture.jpg");
		
			var address = FindById("currentAddress");
			address.SendKeys("Musterstr. 33");
		
			var state = FindById("react-select-3-input");
			state.SendKeys("NCR");
			state.SendKeys(Keys.Enter);
			 
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);

			var city = FindById("react-select-4-input");
			city.SendKeys("Delhi" + Keys.Enter);

			FindById("submit").SendKeys(Keys.Space);
		}
	}
}