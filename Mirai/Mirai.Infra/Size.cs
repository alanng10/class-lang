namespace Mirai.Infra;

public class Size : Comp
{
    public override bool Init()
    {
        base.Init();
        this.WidthField = this.CreateWidthField();
        this.HeightField = this.CreateHeightField();
        return true;
    }

    protected virtual Field CreateWidthField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateHeightField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public override bool Mod(Field field, Mod mod)
    {
        if (this.WidthField == field)
        {
            this.ModWidth(mod);
        }
        if (this.HeightField == field)
        {
            this.ModHeight(mod);
        }
        return true;
    }

    public virtual Field WidthField { get; set; }

    public virtual long Wed
    {
        get
        {
            return this.WidthField.GetInt();
        }

        set
        {
            this.WidthField.SetInt(value);
        }
    }

    protected virtual bool ModWidth(Mod mod)
    {
        this.Event(this.WidthField);
        return true;
    }

    public virtual Field HeightField { get; set; }

    public virtual long Het
    {
        get
        {
            return this.HeightField.GetInt();
        }

        set
        {
            this.HeightField.SetInt(value);
        }
    }

    protected virtual bool ModHeight(Mod mod)
    {
        this.Event(this.HeightField);
        return true;
    }
}