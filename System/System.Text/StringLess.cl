class StringLess : InfraLess
{
    maide prusate Bool Init()
    {
        this.StringComp : share StringComp;
        return true;
    }
    
    field prusate IntLess CharLess { get { return data; } set { data : value; } }
    field prusate Form LiteForm { get { return data; } set { data : value; } }
    field prusate Form RiteForm { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }

    maide prusate Int Execute(var Any lite, var Any rite)
    {
        var StringComp stringComp;
        stringComp : this.StringComp;
        
        var String liteString;
        var String riteString;
        liteString : cast String(lite);
        riteString : cast String(rite);

        var Int liteCount;
        var Int riteCount;
        liteCount : stringComp.Count(liteString);
        riteCount : stringComp.Count(riteString);

        var IntLess charLess;
        charLess : this.CharLess;

        var Form liteForm;
        var Form riteForm;
        liteForm : this.LiteForm;
        riteForm : this.RiteForm;

        var Int count;
        count : liteCount;
        inf (riteCount < count)
        {
            count : riteCount;
        }

        var Int i;
        i : 0;
        while (i < count)
        {
            var Int na;
            var Int nb;
            na : stringComp.Char(liteString, i);
            nb : stringComp.Char(riteString, i);

            na : liteForm.Execute(na);
            nb : riteForm.Execute(nb);

            var Int oo;
            oo : charLess.Execute(na, nb);
            inf (~(oo = 0))
            {
                return oo;
            }

            i : i + 1;
        }

        return liteCount - riteCount;
    }
}