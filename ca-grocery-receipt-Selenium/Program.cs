using OpenQA.Selenium;
using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        //////// start test case setting
        List<OptionalBenefitEnum.OptionalBenefit> optionalBenefitCases = //new List<OptionalBenefitEnum.OptionalBenefit>() { };
              new List<OptionalBenefitEnum.OptionalBenefit>() {
                       OptionalBenefitEnum.OptionalBenefit.CLI
                       , OptionalBenefitEnum.OptionalBenefit.SMM
                       , OptionalBenefitEnum.OptionalBenefit.DEN
                       , OptionalBenefitEnum.OptionalBenefit.DENA
                       , OptionalBenefitEnum.OptionalBenefit.DENB
                       , OptionalBenefitEnum.OptionalBenefit.FCHS
                       , OptionalBenefitEnum.OptionalBenefit.HC
             };
        ConfigDTO setting = new ConfigDTO() {
            isBroker = false,
            productCode = ProductEnum.Product.CI,
            environment = 'P',
            gender = 'm',
            numberOfInsured = 0,
            receiveMail = "test@bubu.com",
            language = "en",
            optionalBenefitItems = optionalBenefitCases
        };
        //////// end test case setting

        /////start testing 
        ProductDTO productSetting = Utility.GetProduct(setting.productCode);

        //checking 
        Validator.CheckProduct(productSetting, setting.numberOfInsured);

        //start the job
        using (IWebDriver driver = AutomatedDrivers.GetInstanceDriver()) {
            driver.Navigate().GoToUrl(Utility.GetURL(setting, productSetting));
            foreach (IWorkItems aJob in JobList.GetJobList(setting, productSetting))
                aJob.ExecuteItems(setting, productSetting);

            Utility.LogInfo("--------------------------------------");
            Console.ReadKey();
        }
    }
}