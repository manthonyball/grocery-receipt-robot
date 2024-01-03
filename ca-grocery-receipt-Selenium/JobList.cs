using System.Collections.Generic;
using System.Linq;
public static class JobList
{
    //if diveded by 10 has no remainder => major step; otherwise, optional items
    public static List<BaseWorkItem> GetJobList()
    {
        List<BaseWorkItem> todayJobList =
        [
            new WebpageWorker.FillTheReceiptCode() { jobSequence = 10 },
            new WebpageWorker.FillTheForm() { jobSequence = 20 }
            //todo - can complete the workflow by adding more jobs here
        ];
        return todayJobList.OrderBy(seq => seq.jobSequence).ToList();
    }
}
