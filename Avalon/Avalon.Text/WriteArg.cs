namespace Avalon.Text;

public class WriteArg : Any
{
    public override bool Init()
    {
        base.Init();
        this.Value = new Value();
        this.Value.Init();
        return true;
    }

    public virtual long Pos { get; set; }
    public virtual long Kind { get; set; }
    public virtual Value Value { get; set; }
    public virtual bool AlignLeft { get; set; }
    public virtual long FieldWidth { get; set; }
    public virtual long MaxWidth { get; set; }
    public virtual long Base { get; set; }
    public virtual long FillChar { get; set; }
    public virtual long ValueCount { get; set; }
    public virtual long Count { get; set; }
    public virtual CharForm Form { get; set; }
}