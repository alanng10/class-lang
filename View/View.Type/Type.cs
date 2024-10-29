namespace View.Type;

public class Type : Any
{
    public override bool Init()
    {
        base.Init();
        this.Index = IndexList.This;

        this.InitFieldList();
        return true;
    }

    public virtual IndexList Index { get; set; }
    protected virtual Data FieldData { get; set; }

    protected virtual bool InitFieldList()
    {
        this.FieldData = new Data();
        this.FieldData.Count = this.Index.Count;
        this.FieldData.Init();
        return true;
    }

    public virtual bool Get(long index)
    {
        long k;
        k = this.FieldData.Get(index);

        bool a;
        a = !(k == 0);

        return a;
    }

    public virtual bool Set(long index, bool value)
    {
        Index k;
        k = this.Index.Get(index);

        if (k == null)
        {
            return true;
        }

        bool ka;
        ka = this.Get(index);

        if (ka == value)
        {
            return true;
        }

        long ke;
        ke = 0;
        if (value)
        {
            ke = 1;
        }

        this.FieldData.Set(index, ke);

        this.Event(k, value);
        return true;
    }

    public virtual bool Event(Index index, bool field)
    {
        return false;
    }
}