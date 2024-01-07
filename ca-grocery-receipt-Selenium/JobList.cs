using System.Collections.Generic;
using System.Linq;
public static class JobList
{
    //if diveded by 10 has no remainder => major step; otherwise, optional items
    public static List<BaseWorkItem> GetJobList()
    {
        // return an empty list if no need to run 
        // return Enumerable.Empty<BaseWorkItem>();
         
        List<BaseWorkItem> todayJobList =
        [
            new WebpageWorker.FillTheReceiptCode() { jobSequence = 10 },
            new WebpageWorker.FillTheForm() { jobSequence = 20 },
            new WebpageWorker.RamdomSection() { jobSequence = 30 },
            new WebpageWorker.FillTheContactInformation() { jobSequence = 40 },
            new WebpageWorker.SubmitTheForm() { jobSequence = 50 },
        ];
        return todayJobList.OrderBy(seq => seq.jobSequence).ToList();
    }
}
