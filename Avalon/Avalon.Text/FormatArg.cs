namespace Avalon.Text;

public class FormatArg : Any
{
    public virtual long Pos { get; set; }
    public virtual long Kind { get; set; }
    public virtual Value Value { get; set; }
    public virtual bool AlignLeft { get; set; }
    public virtual long FieldWidth { get; set; }
    public virtual long MaxWidth { get; set; }
    public virtual long Base { get; set; }
    public virtual long Case { get; set; }
    public virtual long Sign { get; set; }
    public virtual uint FillChar { get; set; }
    public virtual bool HasCount { get; set; }
    public virtual long ValueCount { get; set; }
    public virtual long Count { get; set; }
}