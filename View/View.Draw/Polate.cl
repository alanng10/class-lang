class Polate : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.KindList : share PolateKindList;
        
        var Int valueK;
        valueK : 0;
        inf (this.Kind = this.KindList.Linear)
        {
            valueK : this.Linear.Intern;
        }
        inf (this.Kind = this.KindList.Radial)
        {
            valueK : this.Radial.Intern;
        }

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Polate_New();
        extern.Polate_KindSet(this.Intern, this.Kind.Intern);
        extern.Polate_ValueSet(this.Intern, valueK);
        extern.Polate_StopSet(this.Intern, this.Stop.Intern);
        extern.Polate_SpreadSet(this.Intern, this.Spread.Intern);
        extern.Polate_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Polate_Final(this.Intern);
        extern.Polate_Delete(this.Intern);
        return true;
    }

    field prusate PolateKind Kind { get { return data; } set { data : value; } }
    field prusate PolateLinear Linear { get { return data; } set { data : value; } }
    field prusate PolateRadial Radial { get { return data; } set { data : value; } }
    field prusate PolateStop Stop { get { return data; } set { data : value; } }
    field prusate PolateSpread Spread { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field precate PolateKindList KindList { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }
}