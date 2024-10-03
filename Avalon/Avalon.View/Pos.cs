namespace Avalon.View;

public class Pos : Comp
{
    public override bool Init()
    {
        base.Init();
        this.LeftField = this.CreateLeftField();
        this.UpField = this.CreateUpField();
        return true;
    }

    protected virtual Field CreateLeftField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateUpField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public override bool Mod(Field field, Mod mod)
    {
        if (this.LeftField == field)
        {
            this.ModLeft(mod);
        }
        if (this.UpField == field)
        {
            this.ModUp(mod);
        }
        return true;
    }

    public virtual Field LeftField { get; set; }

    public virtual long Left
    {
        get
        {
            return this.LeftField.GetInt();
        }

        set
        {
            this.LeftField.SetInt(value);
        }
    }

    protected virtual bool ModLeft(Mod mod)
    {
        this.Event(this.LeftField);
        return true;
    }

    public virtual Field UpField { get; set; }

    public virtual long Up
    {
        get
        {
            return this.UpField.GetInt();
        }

        set
        {
            this.UpField.SetInt(value);
        }
    }

    protected virtual bool ModUp(Mod mod)
    {
        this.Event(this.UpField);
        return true;
    }
}