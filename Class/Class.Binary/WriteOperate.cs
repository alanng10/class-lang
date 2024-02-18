namespace Class.Binary;



public class WriteOperate : Any
{
    public virtual Write Write { get; set;  }
    
    
    public virtual bool ExecuteByte(byte ob)
    {
        return true;
    }
}