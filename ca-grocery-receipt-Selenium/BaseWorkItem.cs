using OpenQA.Selenium;
using System;
using System.Collections.Generic;

public abstract class BaseWorkItem : IWorkItems
{
    protected int _jobSequence;
    public int jobSequence { get { return _jobSequence; } set { _jobSequence = value; } }
    
    public BaseWorkItem()
    {
        //  Utility.LogInfo(this.GetType().Name);
    }
    public abstract void ExecuteItems(ConfigDTO setting, ProjectDTO projectData);
    private void ClickItemsByXPath(ConfigDTO setting, string itemIdentifier, bool isDelay)
    {
        AutomatedDrivers.GetInstanceDriver().FindElement(By.XPath(itemIdentifier)).Click();
        if (isDelay)
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(setting._timeout_second));
    }

    public virtual void ClickItems<T>(ConfigDTO setting, T[,] itemList, bool isByXpath, bool isDelay = false)  //multi-dimension array
    {
        for (int i = 0; i < itemList.GetLength(0); i++) 
                if (isByXpath) ClickItemsByXPath(setting, @"//label[@for='" + itemList[i,0] + "']", isDelay); 
    }
    public virtual void ClickItems<T>(ConfigDTO setting, T itemList, bool isByXpath, bool isDelay = false) where T : IEnumerable<string>  // 1 dimension array
    {
        foreach (var i in itemList)
            if (isByXpath) ClickItemsByXPath(setting, @"//label[@for='" + i + "']", isDelay);
    }
}
