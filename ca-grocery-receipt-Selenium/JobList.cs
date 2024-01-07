using System;
using System.Collections.Generic;
using System.Linq;
public static class JobList
{
    /**********
     * How to add a new job :
     * deJobSetUp.Item1: job name ; 
     * deJobSetUp.Item2: if true, run the job, otherwise, not run ; 
     * deJobSetUp.Item3: order of the job ;
     * if diveded by 10 has no remainder => major step; otherwise, optional items
     ***********/

    private static List<(string, bool, int)> deJobSetUp = new List<(string, bool, int)>()
     {
            ("FillTheReceiptCode", true, 10),
            ("FillTheForm", true, 20), 
     };

    private static BaseWorkItem GetAJob(string jobName) => jobName 
        switch {
           "FillTheReceiptCode" => new WebpageWorker.FillTheReceiptCode(),
           "FillTheForm" => new WebpageWorker.FillTheForm(),
           _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(jobName)),
        };

    public static IEnumerable<BaseWorkItem> GetJobList()
    {
        // return an empty list if no need to run 
        // return Enumerable.Empty<BaseWorkItem>();
         
        foreach (var aJob in deJobSetUp.OrderBy(i=>i.Item3))
        {
            if (aJob.Item2)
                yield return GetAJob(aJob.Item1);
        }
    }
}
