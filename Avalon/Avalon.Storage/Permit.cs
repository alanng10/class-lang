namespace Avalon.Storage;

public class Permit : Any
{
    public virtual bool OwnerRead { get; set; }
    public virtual bool OwnerWrite { get; set; }
    public virtual bool GroupRead { get; set; }
    public virtual bool GroupWrite { get; set; }
    public virtual bool OtherRead { get; set; }
    public virtual bool OtherWrite { get; set; }
    public virtual long Other { get; set; }
}