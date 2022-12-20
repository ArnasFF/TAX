using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPage;
using TestAutomationProject.TaxPages;

namespace TAX
{
    public class Atlyginimai
    {
        public class AtlyginimasTests : Method
        {
            driverController controller;


            [SetUp]
            public void SetUp()
            {
                controller = new driverController();
                controller.driver.Manage().Window.Maximize();
                controller.driver.Url = "https://www.tax.lt/skaiciuokles/atlyginimo_ir_mokesciu_skaiciuokle";
            }

            [Test]
            public void CheckIfNumbersCanBeTyped()
            {


                ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
                SendKeysByXpath(controller.driver, "//input[@id='atlyginimas']", "500");
                CheckIfElementIsPresentByXpath(controller.driver, "//td[@id='ant_pop']");


            }

            [Test]
            public void CheckIfButtonsCanBeClicked()
            {


                ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
                ClickButtonByXpath(controller.driver, "//label[@class='radio'][1]");
                CheckIfElementIsPresentByXpath(controller.driver, "//span[@id='koks_atl_text']");
                ClickButtonByXpath(controller.driver, "//input[@id='koks_atl_2']");
                CheckIfElementIsPresentByXpath(controller.driver, "//span[@id='koks_atl_text']");
                ClickButtonByXpath(controller.driver, "//input[@id='paskaiciuoti_npd_2']");
                CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='npd_sum']");

            }
            [Test]
            public void CheckIfElementsExist()
            {
                ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
                //Tikrina ar yra lentele su "Atlyginimo ir mokesciu skaiciuokle" pavadinimu
                CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='box_subheader']");
                //Tikrina ar yra lentele su visos darbo vietos kaina
                CheckIfElementIsPresentByXpath(controller.driver, "//table[@id='calculator_table']");
                //Tikrina ar yra lentele atlyginimo duomenims suvesti
                CheckIfElementIsPresentByXpath(controller.driver, "//form[@id='tax_calculator_form']//div[@class='row']");
            }




            [TearDown]
            public void TearDown()
            {
                tear(controller.driver);
            }
        }
    }
    }
            
                
            
        

    





