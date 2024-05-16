namespace Class.Port;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = ClassInfra.This;

        this.Text = new Text();
        this.Text.Init();
        this.Text.Range = new Range();
        this.Text.Range.Init();

        this.StringData = new StringData();
        this.StringData.Init();

        this.Colon = ":";
        return true;
    }

    public virtual string Source { get; set; }
    public virtual Port Port { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Array LineList { get; set; }
    protected virtual Text Text { get; set; }
    protected virtual StringData StringData { get; set; }
    protected virtual string Colon { get; set; }

    public virtual bool Execute()
    {
        this.LineList = this.ClassInfra.TextCreate(this.Source);
        return true;
    }

    protected virtual bool ExecuteModuleRef(Text text)
    {
        this.TextGet(this.Colon);
        return true;
    }

    protected virtual bool TextGet(string o)
    {
        this.StringData.Value = o;
        this.Text.Data = this.StringData;
        this.Text.Range.Index = 0;
        this.Text.Range.Count = o.Length;
        return true;
    }
}