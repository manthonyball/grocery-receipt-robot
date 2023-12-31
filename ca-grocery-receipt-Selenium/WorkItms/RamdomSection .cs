/****
* Template created by Anthony LAM , 2023
* Class generated in 2023 
****/
using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebpageWorker
{
    internal class RamdomSection : BaseWorkItem
    {
        public override void ExecuteItems(ConfigDTO setting, ProjectDTO projectData)
        {
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));
            //  Ramdom section  
            var trialCt = 0;
            while (trialCt < 2)
            {
                AutomatedDrivers.GetInstancePageWait().IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                // IgnoreExceptionTypes(typeof(NotFoundException));
                var title = AutomatedDrivers.GetInstancePageWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                                          .ElementIsVisible(By.XPath("//div[@id='promptArea']//label[1]"))).Text;

                if (title.Contains("agree with the following statements about this store?"))
                {
                    // agree with the following statements about this store?
                    string[,] itemsArray = { 
                        { "option_827361_373330", "Agree - This store is at least as good as any other I would consider" },
                        { "option_827351_373328", "4 agree - Generally speaking, this store meets my needs" }, // option_827351_373328 // option_827381_373334
                        { "option_827381_373334","4 agree - I would forgive this store if they made a mistake"},
                        { "option_827384_373335","disagree - I feel attached to this store"},
                        { "option_827374_373333","disagree - This store makes me feel inspired/excited"},
                        { "option_827370_373332","neutral - I am proud to say that I am a customer of this store"},
                        { "option_827356_373329","4 agree - This store is reliable"},
                        { "option_827366_373331","4 agree - I trust this store"},
                        { "option_1021081_443609","disagree - Inspires me to eat and live well"},
                     }; // 9 items

                    ClickItems(setting, itemsArray, isByXpath: true);
                     
                    Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));
                }
                else if (title.Contains("someone in particular"))
                {
                    // someone in particular ?

                    AutomatedDrivers.GetInstancePageWait().IgnoreExceptionTypes(typeof(StaleElementReferenceException)); 
                    AutomatedDrivers.GetInstancePageWait().Until(SeleniumExtras.WaitHelpers.ExpectedConditions
                                             .ElementIsVisible(By.XPath("//label[@for='option_1063389_462180']"))).Click(); //no    
                    Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));
                }
                else { new Exception("title is not expected!!!"); return; }
                AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
                trialCt++;
            }
        }
    }
}
