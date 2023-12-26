using System.Collections.Generic;
using System.Linq;
public static class JobList {
    //if diveded by 10 has no remainder => major step; otherwise, optional items
    public static List<BaseWorkItem> GetJobList(ConfigDTO aTestSetting, ProductDTO productSetting) {

        List<BaseWorkItem> todayJobList = new List<BaseWorkItem>() { };
        if (aTestSetting.productCode == ProductEnum.Product.CI) {
            todayJobList.Add(new VendorSelenium.FillTheQuote() { jobSequence = 10 });
            todayJobList.Add(new VendorSelenium.EnrollOnline() { jobSequence = 30 });
            todayJobList.Add(new VendorSelenium.FillMQ() { jobSequence = 40 });
            todayJobList.Add(new VendorSelenium.FillTC() { jobSequence = 50 });
            todayJobList.Add(new VendorSelenium.FillPrivacy() { jobSequence = 60 });
            todayJobList.Add(new VendorSelenium.ScrollToCaptra() { jobSequence = 70 });
        }
        else {
            todayJobList.Add(new trialOnSelenium.FillTheQuote() { jobSequence = 10 });
            todayJobList.Add(new trialOnSelenium.ReviewMember() { jobSequence = 40 });
            todayJobList.Add(new trialOnSelenium.FillPersonalDetail(GetFillPersonDetail(productSetting.isMultiMemberSupported)) { jobSequence = 50 });
            todayJobList.Add(new trialOnSelenium.FillPersonalMqDetails(GetFillPersonMQ(productSetting.isMultiMemberSupported)) { jobSequence = 60 });
            todayJobList.Add(new trialOnSelenium.FillTCs() { jobSequence = 80 });
            todayJobList.Add(new trialOnSelenium.ScrollToCaptra(productSetting.isMultiMemberSupported ? Utility.CAPTRA_MULTI : Utility.CAPTRA_Single) { jobSequence = 90 });

            if (aTestSetting.isBroker)
                todayJobList.Add(new trialOnSelenium.FillBrokerInfo() { jobSequence = 20 });
            if (aTestSetting.productCode == ProductEnum.Product.vtop)
                todayJobList.Add(new trialOnSelenium.FillFullfillmentForm() { jobSequence = 30 });
            if (IsNeedMq(aTestSetting))
                todayJobList.Add(new trialOnSelenium.FillMQs(productSetting.isMultiMemberSupported ? Utility.SUW_ID_MULTI : Utility.SUW_ID_Single) { jobSequence = 70 });
        }

        return todayJobList.OrderBy(seq => seq.jobSequence).ToList();
    }
    private static bool IsNeedMq(ConfigDTO aTestSetting) => (aTestSetting.productCode != ProductEnum.Product.vtop
            || (aTestSetting.productCode == ProductEnum.Product.vtop && aTestSetting.numberOfInsured > 0)// vtop, other persons also need to fill MQs
            || (aTestSetting.productCode == ProductEnum.Product.vtop && aTestSetting.optionalBenefitItems.Any(b => b == OptionalBenefitEnum.OptionalBenefit.CLI)));// vtop if clinical selected, needs to fill MQ even for first person

    private static JobDispensor GetFillPersonDetail(bool isMulti) => isMulti ? new JobDispensor(new trialOnSelenium.FillMultiplePersonal()) : new JobDispensor(new trialOnSelenium.FillSinglePersonal());
    private static JobDispensor GetFillPersonMQ(bool isMulti) => isMulti ? new JobDispensor(new trialOnSelenium.FillMultiplePersonMQ()) : new JobDispensor(new trialOnSelenium.FillSinglePersonMQs());

}
