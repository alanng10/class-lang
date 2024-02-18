namespace Class.Library;



public class WriteOperate : Any
{
    public virtual Create Create { get; set;  }
    
    
    
    public virtual bool ExecuteChar(char oc)
    {
        return true;
    }



    public virtual bool ExecuteIntValueHex(long a)
    {
        return true;
    }
}