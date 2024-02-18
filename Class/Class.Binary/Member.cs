namespace Class.Binary;




public class Member : Any
{
    public virtual int FieldStart { get; set; }
    
    
    public virtual int MethodStart { get; set; }
    
    
    
    public virtual Array Field { get; set; }
    
    
    public virtual Array Method { get; set; }
}