//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium
{
	public class TestApp
	{

		protected IWebDriver driver;

		public IWebElement FindById(string Id)
		{
			return driver.FindElement(By.Id(Id));
		}

		[SetUp]
		public void CreateDriver()
		
		{
			Console.WriteLine("Creating Driver");
			new DriverManager().SetUpDriver(new EdgeConfig());
			driver = new EdgeDriver();

			driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
		}

		[TearDown]
		public void QuitDrivers()
		{
			driver.Quit();
		}

		public void setup()
		{
			
		}

		[Test]
		public void firstNameTest()
		{
			setup();

			var firstName = FindById("firstName");
			firstName.SendKeys("Leon");
		}

		[Test]
		public void lastNameTest()
		{
			var lastName = FindById("lastName");
			lastName.SendKeys("Wichern");
		}

		[Test]
		public void emailTest()
		{
			var userEmail = FindById("userEmail");
			userEmail.SendKeys("leon.wichern@hotmail.com");
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
			mobileNumber.SendKeys("1754861234");
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
			subjectInput.SendKeys("Computer Science" + Keys.Enter);
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
			picture.SendKeys("C:\\Users\\leonw\\source\\repos\\KuroiMori\\SeleniumTest\\Selenium\\picture\\testPicture.jpg");
		}

		[Test]
		public void addressTextTest()
		{
			var address = FindById("currentAddress");
			address.SendKeys("Lutherstr. 33");
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
	}
}