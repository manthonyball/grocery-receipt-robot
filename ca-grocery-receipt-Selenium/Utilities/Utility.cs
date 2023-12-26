using System;
using System.Collections.Generic;
using System.IO;


public static class Utility {
    public static string SUW_ID_MULTI = "Model.Persons";
    public static string SUW_ID_Single = "Questions";
    public static string CAPTRA_MULTI = "4";
    public static string CAPTRA_Single = "31";
    public static string GetMonthEngName(int i) {
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        return new DateTime(DateTime.Now.Year, i, 1).ToString("MMMM", ci);
    }
    public static void LogInfo(string i) => File.AppendAllText(@"C:\TFS\WriteLines.txt", i + "," + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt") + Environment.NewLine);

    public static string GetURL(ConfigDTO setting, ProductDTO productSetting)
        => $"{GetServer(setting.environment)}/{setting.language}/medical-insurance/{productSetting.productName}/insurance-quote/{(setting.isBroker ? "?broker=BOCL" : "")}";

    private static string GetServer(char env) {
        switch (char.ToLowerInvariant(env)) {
            case 'l':
                return "https://localhost:44"; 
            case 'd':
                return "https://dev.ba.com.hk";
            case 's':
                return "https://sit.ba.com.hk";
            case 'u':
                return "https://uatcms.ba.com.hk";
            case 'p':
                return "https://www.ba.com.hk";
            default:
                break;
        }
        return string.Empty;
    }

    public static ProductDTO GetProduct(ProductEnum.Product product) {
        switch (product) {
            case ProductEnum.Product.Hero:
                return new ProductDTO() { productName = ProductEnum.Product.Hero.ToString(), isMultiMemberSupported = true, isFullfillmentFormNeeded = false, maxInsuredPersons = 5 };
            case ProductEnum.Product.vtop:
                return new ProductDTO() { productName = ProductEnum.Product.vtop.ToString(), isMultiMemberSupported = true, isFullfillmentFormNeeded = true, maxInsuredPersons = 6 };
            case ProductEnum.Product.myflexi:
                return new ProductDTO() { productName = ProductEnum.Product.myflexi.ToString(), isMultiMemberSupported = true, isFullfillmentFormNeeded = false, maxInsuredPersons = 6 };
            case ProductEnum.Product.mybasic:
                return new ProductDTO() { productName = ProductEnum.Product.mybasic.ToString(), isMultiMemberSupported = true, isFullfillmentFormNeeded = false, maxInsuredPersons = 9 };
            case ProductEnum.Product.carepro:
                return new ProductDTO() { productName = ProductEnum.Product.carepro.ToString(), isMultiMemberSupported = false, isFullfillmentFormNeeded = false, maxInsuredPersons = 0 };
            case ProductEnum.Product.CI:
                return new ProductDTO() { productName = "critical-illness", isMultiMemberSupported = false, isFullfillmentFormNeeded = false, maxInsuredPersons = 0 };
            default:
                throw new Exception("no product setup found");
        }
    }
    public static List<OptionalBenefitEnum.OptionalBenefit> GetProductSupportedBenefit(ProductEnum.Product product) {
        List<OptionalBenefitEnum.OptionalBenefit> returnList = new List<OptionalBenefitEnum.OptionalBenefit>();
        switch (product) {
            case ProductEnum.Product.Hero:
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.CLI);
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.DEN);
                break;
            case ProductEnum.Product.vtop:
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.CLI);
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.SMM);
                break;
            case ProductEnum.Product.myflexi:
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.DENA);
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.DENB);
                break;
            case ProductEnum.Product.mybasic:
                break;
            case ProductEnum.Product.carepro:
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.DENA);
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.DENB);
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.HC);
                returnList.Add(OptionalBenefitEnum.OptionalBenefit.FCHS);
                break;
        }
        return returnList;
    }
    public static string GetWeekInfoInEng(DateTime date) {
        switch (GetOne2FiveFromDate(date)) {
            case 1:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-One";
            case 2:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Two";
            case 3:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Three";
            case 4:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Four";
            case 5:
                return date.ToString("MMMM") + "-" + date.DayOfWeek + "-Five";
            default:
                return "master";
        }
    }
    private static int GetOne2FiveFromDate(DateTime date) {
        date = date.Date;
        DateTime firstMonthDay = new DateTime(date.Year, date.Month, 1);
        DateTime firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
        if (firstMonthMonday > date) {
            firstMonthDay = firstMonthDay.AddMonths(-1);
            firstMonthMonday = firstMonthDay.AddDays((DayOfWeek.Monday + 7 - firstMonthDay.DayOfWeek) % 7);
        }
        return (date - firstMonthMonday).Days / 7 + 1;
    }
}