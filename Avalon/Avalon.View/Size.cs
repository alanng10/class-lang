namespace Avalon.View;

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

    public override bool Change(Field varField, Change change)
    {
        if (this.WedField == varField)
        {
            this.ChangeWed(change);
        }
        if (this.HetField == varField)
        {
            this.ChangeHet(change);
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

    protected virtual bool ChangeWed(Change change)
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

    protected virtual bool ChangeHet(Change change)
    {
        this.Event(this.HetField);
        return true;
    }
}