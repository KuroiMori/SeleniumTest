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
		public void ChromeSession()
		{
			driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");

			var title = driver.Title;
			Assert.AreEqual("ToolsQA", title);

			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

			var firstName = driver.FindElement(By.Id("firstName"));
			firstName.SendKeys("Leon");

			var lastName = driver.FindElement(By.Id("lastName"));
			lastName.SendKeys("Wichern");

			var userEmail = driver.FindElement(By.Id("userEmail"));
			userEmail.SendKeys("leon.wichern@hotmail.com");


			
		}
	}
}