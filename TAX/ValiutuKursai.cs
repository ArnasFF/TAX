using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPage;
using TestAutomationProject.TaxPages;


namespace TAX
{
    public class ValiutuKursaiTests : Method
    {

        driverController controller;


        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/valiutu_kursai";
        }

        [Test]

        public void CheckIfDateTableExists()
        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ClickButtonByXpath(controller.driver, "//input[@id='rate_date']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='datepicker dropdown-menu']");
            //Patikrina ar galima atgaline data ziureti valiutu kursus spaudziant rodykle i kaire
            ClickButtonByXpath(controller.driver, "//th[@class='prev']//i[@class='icon-arrow-left'][1]");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='datepicker-days']");

        }

        [Test]

        public void CheckIfCurrencyExchangeTableExists()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            CheckIfElementIsPresentByXpath(controller.driver, "//input[@id='currency_text']");
            //Tikrina ar "filterina" valiuta i teksto laukeli ivedus "USD"
            SendKeysByXpath(controller.driver, "//input[@id='currency_text']", "USD");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='currencies_list']//*[contains(text(),'JAV')]");

        }

        [Test]

        public void CheckIfSpecificCurrencyExist()
            {

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrina ar valiutu lenteleje yra Norvegijos krona ir jai priskirti elementai
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'NOK')]");
            CheckIfElementIsPresentByXpath(controller.driver, "//img[@src='/images/flags/no.png']");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'Norvegijos')]");


        }


        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }
    }
}


