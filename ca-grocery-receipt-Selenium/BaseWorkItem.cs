
public abstract class BaseWorkItem : IWorkItems {
    protected int _jobSequence;
    public int jobSequence
    {
        get
        {
            return _jobSequence;
        }

        set
        {
            _jobSequence = value;
        }
    }
    public BaseWorkItem() {
        //  Utility.LogInfo(this.GetType().Name);
    }
    public abstract void ExecuteItems(ConfigDTO setting, ProductDTO productSetting);
}
