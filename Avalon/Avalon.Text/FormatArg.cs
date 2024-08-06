namespace Avalon.Text;

public class FormatArg : Any
{
    public virtual int Pos { get; set; }
    public virtual int Kind { get; set; }
    public virtual bool ValueBool { get; set; }
    public virtual long ValueInt { get; set; }
    public virtual Text ValueText { get; set; }
    public virtual bool AlignLeft { get; set; }
    public virtual int FieldWidth { get; set; }
    public virtual int MaxWidth { get; set; }
    public virtual int Base { get; set; }
    public virtual int Case { get; set; }
    public virtual int Sign { get; set; }
    public virtual char FillChar { get; set; }
    public virtual bool HasCount { get; set; }
    public virtual int ValueCount { get; set; }
    public virtual int Count { get; set; }
}