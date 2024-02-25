using OpenQA.Selenium;
using System;
using System.Threading;
using ValidateDTO;
namespace WebpageWorker
{
    class FillTheReceiptCode : BaseWorkItem
    {
        public override void ExecuteItems(ConfigDTO setting, ProjectDTO projectData)
        {
            var (part1, part2, part3, part4) = GetParts(projectData.receiptCode);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_0")).SendKeys(part1.GetCode());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_1")).SendKeys(part2.GetCode());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_2")).SendKeys(part3.GetCode());
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("promptInput_397048_3")).SendKeys(part4.GetCode());

            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));
        }
        /// <summary>
        /// this method will separate the code into 4 parts by ' ' 
        /// initialize Part1, Part2, Part3, Part4 respectively
        /// after initialize, it will call the validate method of each part to validate the code
        /// return the expected if the code is valid
        /// throw if the code is invalid
        /// </summary>
        /// <returns>(Part1, Part2, Part3, Part4)</returns>
        /// 
        private (Part1, Part2, Part3, Part4) GetParts(string code)
        {
            string[] parts = code.Split(' ');
            Part1 part1 = new Part1(parts[0]);
            Part2 part2 = new Part2(parts[1]);
            Part3 part3 = new Part3(parts[2]);
            Part4 part4 = new Part4(parts[3]);

            if (IsItValid(part1, part2, part3, part4))
                return (part1, part2, part3, part4);
            else
                throw new Exception("Invalid receipt code");
        }
        private bool IsItValid(Part1 part1, Part2 part2, Part3 part3, Part4 part4)
            => part1.Validate() && part2.Validate() && part3.Validate() && part4.Validate();
    }
}
