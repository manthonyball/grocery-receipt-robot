using OpenQA.Selenium;
using System;
using System.Threading;
namespace WebpageWorker
{
    class FillTheForm : BaseWorkItem
    {
        public override void ExecuteItems(ConfigDTO setting, ProjectDTO projectData)
        {
            // is age 18? 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("choice_no_851262")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // isShopInStore
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1076985_467488']")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // is Self-checkout
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046517_454564']")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // recommend to friend
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_826922_373170']")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // degree of satisfactory?
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_912737_394815']")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("commentArea_441261")).SendKeys("nice store");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            /**************************************************************
             * enter lucky draw  
             **************************************************************/
            // is enter lucky draw? 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1113484_483822']")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // is notified services provided? 
            //  string[,] itemsArray = {
            //             { "option_yes_376796", "NO - PC Express Pick-up (Click & Collect)"},
            //             { "option_yes_376800", "NO - Optical service (Theodore and Pringle)"},
            //             { "option_no_376801 ", "Yes - PC Optimum"},
            //             { "option_yes_376802", "NO - In-store pharmacy"},
            //             { "option_yes_478149", "NO - The Mobile Shop"},
            //             { "option_yes_478150", "NO - PC Financial Pavilion"}
            //           }; 
            // ClickItems(setting, itemsArray, clickMethod: ClickMethod.ClickByXPath, isDelay:true);

            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_yes_376796']")).Click(); //  NO - PC Express Pick-up (Click & Collect)
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_yes_376800']")).Click(); // NO - Optical service (Theodore and Pringle)
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_no_376801']")).Click(); // Yes - PC Optimum
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_yes_376802']")).Click(); // NO - In-store pharmacy
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_yes_478149']")).Click(); // NO - The Mobile Shop
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_yes_478150']")).Click(); // NO - PC Financial Pavilion
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // is enter lucky draw? 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='promptInput_373190']")).Click();// For a small top-up shop 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // is notified services provided? 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091133_473187']")).Click(); // No - President’s Choice products
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091137_473189']")).Click(); // NO - Life Brand® products
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091134_473188']")).Click(); // Yes - no name® products
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // how do you feel the store  
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827069_373212']")).Click(); // 4 agree - The store was clean and well maintained
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827015_373203']")).Click(); // 4 agree - The staff who served me were friendly
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827081_373214']")).Click(); // 4 agree - Staff were available when I needed help
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827009_373202']")).Click(); // 4 agree - I was acknowledged or greeted by staff
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827087_373215']")).Click(); // 4 agree - Prices were clearly marked
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827075_373213']")).Click(); // 4 agree - It was easy to find what I wanted
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827039_373207']")).Click(); // 4 agree - The check-out process was quick and easy
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_826991_373199']")).Click(); // 4 agree - I will continue to shop at this store
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827003_373201']")).Click(); // 4 agree - The experience in this store makes me want to shop here more often
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827045_373208']")).Click(); // 4 agree - I got good value for my money
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // you agree with the following statements
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827051_373209']")).Click(); // 4 agree - The products were fresh
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1033507_448550']")).Click(); // 4 agree - No Name products make me want to shop at this store
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827033_373206']")).Click(); // 4 agree - Regular items I was looking for were in stock 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827055_373210']")).Click(); // 2 disagree - Prices were lowest at this store  
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827021_373204']")).Click(); // 4 agree - Staff were knowledgeable  
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827027_373205']")).Click(); // 4 agree - Advertised items I was looking for were in stock
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // Which departments did you shop
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='promptInput_373239']")).Click();
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // provide additional? 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='promptInput_373280']")).Click();// no
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            /**************************************************************
            * recommend no name / OP 
            **************************************************************/
            // is notified services provided?  
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_993288_432336']")).Click(); // 8 - recommend noname
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091793_473622']")).Click(); // 4 agree - Is worth what it costs
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091803_473624']")).Click(); // 4 agree - Is a brand I trust
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091783_473620']")).Click(); // 4 agree - The packaging influences what I buy
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091814_473626']")).Click(); // 4 agree - Is priced competitively
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091798_473623']")).Click(); // 4 agree - Has quality products
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091788_473621']")).Click(); // 4 agree - Has a range of products that meet my needs
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1091819_473627']")).Click(); // 4 agree - Cares about the ingredients in my food
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // Are you a PC Optimum Member?
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_926525_401118']")).Click();// yes 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_827328_373325']")).Click();// 7 - recommend the PC Optimum program 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // is notified services provided? 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_926358_400929']")).Click(); // disagree 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("commentArea_400930")).SendKeys("points are hard to earn ; recommendation not good ");
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // satisfied are you with the following aspects of the PC program
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1260152_544472']")).Click(); // Moderately dissatisfied - The ability to earn points easily
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1260147_544471']")).Click(); // Moderately dissatisfied - The number of offers I receive weekly
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1260139_544469']")).Click(); // Moderately satisfied - The accuracy of the points awarded on my bill
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1260159_544473']")).Click(); // Moderately satisfied - The ability to redeem points easily
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1260129_544466']")).Click(); // Moderately dissatisfied - The value of my weekly offers
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1260142_544470']")).Click(); // Moderately dissatisfied - The relevancy of my weekly offers
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            // satisfied with my most recent self-checkout experience
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046603_454666']")).Click(); // Agree
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046660_454748']")).Click(); // Agree - The wait in line to checkout was reasonable
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046645_454745']")).Click(); // Agree - I was able to pack my groceries easily
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046630_454742']")).Click(); // Agree - The staff at the checkout were friendly
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046640_454744']")).Click(); // Agree - The self-checkout made my checkout experience quicker
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046650_454746']")).Click(); // Agree - The self-checkout technology was easy to use
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046635_454743']")).Click(); // Agree - My bill was error-free
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046663_454749']")).Click(); // Disagree - I was helped in an appropriate amount of time (if needed)
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

            //  use the self-checkout again for a future purchase?
            AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath("//label[@for='option_1046667_454792']")).Click(); // Agree 
            AutomatedDrivers.GetInstanceDriver().FindElement(By.Id("nextPageLink")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));

        }
    }
}