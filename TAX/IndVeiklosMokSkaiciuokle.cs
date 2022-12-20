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
    public class IndVeiklosSkaiciuokleTests : Method
    {
        driverController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/skaiciuokles/individualios_veiklos_mokesciu_skaiciuokle";
        }

        [Test]

        public void CheckifIncomeTableCounts()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrina ar suvedus pajamas gaunamas teisingas grynasis pelnas
            CheckIfElementIsPresentByXpath(controller.driver, "//input[@id='pajamos']");
            ClickButtonByXpath(controller.driver, "//input[@id='pajamos']");
            SendKeysByXpath(controller.driver, "//input[@id='pajamos']", "1000");
            CheckIfElementIsPresentByXpath(controller.driver, "//td[@id='grynasis_pelnas_div'][contains(text(),'783')]");
        }

        [Test]

        public void CheckIfInvestmentCostTableCounts()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrina ar teisingai skaiciuojamas grynasis pelnas atminusavus patirtas sanaudas
            CheckIfElementIsPresentByXpath(controller.driver, "//input[@id='sanaudos']");
            ClickButtonByXpath(controller.driver, "//input[@id='sanaudos']");
            SendKeysByXpath(controller.driver, "//input[@id='pajamos']", "1000");
            SendKeysByXpath(controller.driver, "//input[@id='sanaudos']", "100"); 
            CheckIfElementIsPresentByXpath(controller.driver, "//td[@id='grynasis_pelnas_div'][contains(text(),'704,95')]");


        }

        [Test]

        public void CheckifOptionsButtonsCanBeClicked()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrina ar Sanaudu skaiciavimo skiltyje spaudzia "Faktiskai patirtos" mygtuka
            ClickButtonByXpath(controller.driver, "//input[@id='kaip_skaiciuojamos_sanaudos_1']");
            //Tikrina ar spaudzia "30% nuo pajamu" mygtuka
            ClickButtonByXpath(controller.driver, "//input[@id='kaip_skaiciuojamos_sanaudos_2']");
            //Tikrina ar spaudzia "Kaupiu pensijai papildomai"
            ClickButtonByXpath(controller.driver, "//input[@id='papildomas_pensijos_kaupimas']");
            //Tikrina ar atsiranda procentalus pensijos kaupimas
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='papildomas_pensijos_kaupimas_procentai_div']");

        }



        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }
    }
}







