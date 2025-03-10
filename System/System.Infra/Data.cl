class Data : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.InfraInfra : share Infra;
        this.InitValue();
        return true;
    }

    field prusate Any Value { get { return data; } set { data : value; } }
    field prusate Int Count { get { return data; } set { data : value; } }
    field private Intern InternIntern { get { return data; } set { data : value; } }
    field precate Infra InfraInfra { get { return data; } set { data : value; } }

    maide precate Bool InitValue()
    {
        this.Value : this.InternIntern.DataNew(this.Count);
        return true;
    }

    maide prusate Int Get(var Int index)
    {
        inf (~this.Valid(index))
        {
            return null;
        }
        return this.InternIntern.DataGet(this.Value, index);
    }

    maide prusate Bool Set(var Int index, var Int value)
    {
        inf (~this.Valid(index))
        {
            return false;
        }

        this.InternIntern.DataSet(this.Value, index, value);
        return true;
    }

    maide prusate Bool Valid(var Int index)
    {
        return this.InfraInfra.ValidIndex(this.Count, index);
    }
}