class StringData : Data
{
    maide prusate Bool Init()
    {
        base.Init();
        this.StringInternIntern : share Intern;
        this.StringComp : share StringComp;
        return true;
    }

    maide precate Bool InitValue()
    {
        return true;
    }
    
    field prusate String ValueString
    {
        get
        {
            return data;
        }
        set
        {
            data : value;

            var Any ka;
            var Int count;
            count : 0;

            inf (~(data = null))
            {
                ka : this.StringInternIntern.StringValueGet(data);

                count : this.StringComp.Count(data);
                count : count * 4;
            }

            this.Value : ka;
            this.Count : count;
        }
    }

    field private Intern StringInternIntern { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }

    maide prusate Bool Set(var Int index, var Int value)
    {
        return false;
    }
}