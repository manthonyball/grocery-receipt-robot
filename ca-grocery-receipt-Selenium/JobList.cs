using System;
using System.Collections.Generic;
using System.Linq;
using JobSetUp = (string jobName, bool isExecute, int jobOrder);
public static class JobList
{
    /**********
     * How to add a new job :
     * deJobSetUp.jobName: job name ; 
     * deJobSetUp.isExecute: if true, run the job, otherwise, not run ; 
     * deJobSetUp.jobOrder: order of the job ;
     * if diveded by 10 has no remainder => major step; otherwise, optional items
     ***********/

    private static List<JobSetUp> deJobSetUp = new List<JobSetUp>()
     {
        ("FillTheReceiptCode", true, 10),
        ("FillTheForm", true, 20) 
     };
    private static BaseWorkItem GetAJob(string jobName) => jobName
        switch
    {
        "FillTheReceiptCode" => new WebpageWorker.FillTheReceiptCode(),
        "FillTheForm" => new WebpageWorker.FillTheForm(),
        _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(jobName)),
    };

    public static IEnumerable<BaseWorkItem> GetJobList()
    {
        // return an empty list if no need to run 
        // return Enumerable.Empty<BaseWorkItem>(); or yield break
        if (deJobSetUp.Count == 0)
            yield break;

        foreach (var aJob in deJobSetUp.OrderBy(i => i.jobOrder))
        {
            if (aJob.isExecute)
                yield return GetAJob(aJob.jobName);
        }
    }
}
