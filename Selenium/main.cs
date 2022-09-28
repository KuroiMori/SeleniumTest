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

			var dateOfBirthPicker = FindById("dateOfBirthInput");
			dateOfBirthPicker.SendKeys("28 Mar 2003");
			dateOfBirthPicker.SendKeys(Keys.Enter);

			for (var i = 0; i < 4; i++)
			{
				dateOfBirthPicker.SendKeys(Keys.Backspace);
			}

			dateOfBirthPicker.SendKeys("03");

			var subjectInput = FindById("subjectsInput");
			subjectInput.SendKeys("Computer Science");
			subjectInput.SendKeys(Keys.Enter);

			var hobbies2 = FindById("hobbies-checkbox-2");
			hobbies2.SendKeys(Keys.Space);

			var hobbies3 = FindById("hobbies-checkbox-3");
			hobbies3.SendKeys(Keys.Space);

			var picture = FindById("uploadPicture");
			picture.SendKeys("C:\\Users\\leonw\\source\\repos\\KuroiMori\\SeleniumTest\\Selenium\\picture\\testPicture.jpg");
		}
	}
}