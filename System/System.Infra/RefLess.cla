class RefLess : Less
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        return true;
    }

    field private Intern InternIntern { get { return data; } set { data : value; } }

    maide prusate Int Execute(var Any lite, var Any rite)
    {
        return this.InternIntern.RefLess(lite, rite);
    }
}