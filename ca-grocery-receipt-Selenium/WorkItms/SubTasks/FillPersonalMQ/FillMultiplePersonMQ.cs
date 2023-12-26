using OpenQA.Selenium;
using System.Linq;
//strategy pattern
namespace trialOnSelenium {
    class FillMultiplePersonMQ : ISubTask
    // class FillPersonalDetail : IWorkItems
    {
        public void ExecuteTheTask(ConfigDTO setting) {
            //public void ExecuteItems( ConfigDTO setting, ProductDTO productSetting) {
            if (setting.productCode != ProductEnum.Product.vtop
                    || (setting.productCode == ProductEnum.Product.vtop
                        && setting.optionalBenefitItems.Any(b => b == OptionalBenefitEnum.OptionalBenefit.CLI))
                ) {
                // if Vtop & s/he selects CLI; first person needs MQ question; otherwise, no need
                AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("Height-0")).SendKeys("177");
                AutomatedDrivers.GetInstanceDriver().FindElement(By.Name("WeightKg-0")).SendKeys("77");
            }
            if (setting.numberOfInsured > 0) {
                for (int i = 1; i <= setting.numberOfInsured; i++) {
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='cm-" + i.ToString() + "']")).SendKeys("177");
                    AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//*[@id='kg-" + i.ToString() + "']")).SendKeys("77");
                }
            }
        }

    }
}
