namespace Z.Tool.ReferBinaryGen;

public class Module : Any
{
    public virtual string Name { get; set; }

    public virtual Assembly Assembly { get; set; }
    
    public virtual Table Class { get; set; }

    public virtual Table Import { get; set; }
}