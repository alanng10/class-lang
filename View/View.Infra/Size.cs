namespace Mirai.Infra;

public class Size : Comp
{
    public override bool Init()
    {
        base.Init();
        this.WedField = this.CreateWedField();
        this.HetField = this.CreateHetField();
        return true;
    }

    protected virtual Field CreateWedField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateHetField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    public override bool Mod(Field field, Mod mod)
    {
        if (this.WedField == field)
        {
            this.ModWed(mod);
        }
        if (this.HetField == field)
        {
            this.ModHet(mod);
        }
        return true;
    }

    public virtual Field WedField { get; set; }

    public virtual long Wed
    {
        get
        {
            return this.WedField.GetInt();
        }

        set
        {
            this.WedField.SetInt(value);
        }
    }

    protected virtual bool ModWed(Mod mod)
    {
        this.Event(this.WedField);
        return true;
    }

    public virtual Field HetField { get; set; }

    public virtual long Het
    {
        get
        {
            return this.HetField.GetInt();
        }

        set
        {
            this.HetField.SetInt(value);
        }
    }

    protected virtual bool ModHet(Mod mod)
    {
        this.Event(this.HetField);
        return true;
    }
}