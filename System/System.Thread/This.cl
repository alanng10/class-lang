class This : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        return true;
    }
    
    field prusate Thread Thread
    {
        get
        {
            var Any k;
            k : this.InternIntern.ThisThread();
            var Thread a;
            a : cast Thread(k);
            return a;
        }
        set
        {
        }
    }

    field private Intern InternIntern { get { return data; } set { data : value; } }
}