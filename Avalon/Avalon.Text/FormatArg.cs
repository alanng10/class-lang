namespace Avalon.Text;

public class FormatArg : Any
{
    public virtual int Pos { get { return __D_Pos; } set { __D_Pos = value; } }
    protected int __D_Pos;
    public virtual int Kind { get { return __D_Kind; } set { __D_Kind = value; } }
    protected int __D_Kind;
    public virtual bool ValueBool { get { return __D_ValueBool; } set { __D_ValueBool = value; } }
    protected bool __D_ValueBool;
    public virtual long ValueInt { get { return __D_ValueInt; } set { __D_ValueInt = value; } }
    protected long __D_ValueInt;
    public virtual Text ValueText { get { return __D_ValueText; } set { __D_ValueText = value; } }
    protected Text __D_ValueText;
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