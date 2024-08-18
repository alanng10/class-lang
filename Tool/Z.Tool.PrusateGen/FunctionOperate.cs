namespace Z.Tool.PrusateGen;




class FunctionOperate : ToolGen
{
    public virtual PrusateGen Gen { get; set; }


    
    public virtual Class Class { get; set; }



    public virtual bool ExecuteName()
    {
        return true;
    }


    public virtual bool ExecuteParam(StringBuilder sb)
    {
        return true;
    }
}