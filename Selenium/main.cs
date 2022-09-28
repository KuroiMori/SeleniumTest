//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
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

		}

		public void QuitDrivers()
		{
			driver.Quit();
		}

		[Test]
		public void EdgeSession()
		{
			driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

			var title = driver.Title;
			Assert.AreEqual("ToolsQA", title);

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

			var firstName = FindById("firstName");
			firstName.SendKeys("Leon");

			var lastName = FindById("lastName");
			lastName.SendKeys("Wichern");

			var userEmail = FindById("userEmail");
			userEmail.SendKeys("leon.wichern@hotmail.com");

			var gender = FindById("gender-radio-3");
			gender.SendKeys(Keys.Space);

			var mobileNumber = FindById("userNumber");
			mobileNumber.SendKeys("1754861234");

			var dateOfBirthMonth = FindById("react-datepicker__month-select");
			dateOfBirthMonth.SendKeys("March");

			var dateOfBirthYear = FindById("react-datepicker__year-select");
			dateOfBirthYear.SendKeys("2022");

			var dateOfBirthDay = FindById("react-datepicker__week-select");
			dateOfBirthDay.SendKeys("28");

			var subjectInput = FindById("subjectInput");
			subjectInput.SendKeys("Computer Science");
		}
	}
}