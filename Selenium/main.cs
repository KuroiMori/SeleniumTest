namespace Selenium
{
	public class main
	{
		public void Setup()
		{
			var driver = new OpenQA.Selenium.Chrome.ChromeDriver(@"\webdrivers");
			driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");


		}
	}
}