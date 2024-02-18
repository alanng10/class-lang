namespace Z.Tool.PrudateSourceGen;




class FunctionOperate : Any
{
    public virtual PrudateGen Gen { get; set; }


    
    public virtual Class Class { get; set; }



    public virtual bool ExecuteName(StringBuilder sb)
    {
        return true;
    }


    public virtual bool ExecuteParam(StringBuilder sb)
    {
        return true;
    }
}