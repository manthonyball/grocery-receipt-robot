using System.Collections.Generic;
using System.Linq;
public static class JobList
{
    //if diveded by 10 has no remainder => major step; otherwise, optional items
    public static List<BaseWorkItem> GetJobList()
    {
        List<BaseWorkItem> todayJobList = new List<BaseWorkItem>() { };
        todayJobList.Add(new WebpageWorker.FillTheReceiptCode() { jobSequence = 10 });
        todayJobList.Add(new WebpageWorker.FillTheForm() { jobSequence = 20 });
        return todayJobList.OrderBy(seq => seq.jobSequence).ToList();
    }
}
