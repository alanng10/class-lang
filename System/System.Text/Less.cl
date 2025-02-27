class Less : InfraLess
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share Infra;
        return true;
    }

    field prusate IntLess CharLess { get { return data; } set { data : value; } }
    field prusate Form LiteForm { get { return data; } set { data : value; } }
    field prusate Form RiteForm { get { return data; } set { data : value; } }
    field precate Infra TextInfra { get { return data; } set { data : value; } }

    maide prusate Int Execute(var Any lite, var Any rite)
    {
        var Infra textInfra;
        textInfra : this.TextInfra;

        var Text liteText;
        var Text riteText;
        liteText : cast Text(lite);
        riteText : cast Text(rite);

        inf (~textInfra.ValidRange(liteText))
        {
            return null;
        }
        inf (~textInfra.ValidRange(riteText))
        {
            return null;
        }

        var Data liteData;
        var Data riteData;
        liteData : liteText.Data;
        riteData : riteText.Data;

        var Range liteRange;
        var Range riteRange;
        liteRange : liteText.Range;
        riteRange : riteText.Range;

        var Int liteIndex;
        var Int liteCount;
        liteIndex : liteRange.Index;
        liteCount : liteRange.Count;

        var Int riteIndex;
        var Int riteCount;
        riteIndex : riteRange.Index;
        riteCount : riteRange.Count;
        
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
            na : textInfra.DataCharGet(liteData, liteIndex + i);
            nb : textInfra.DataCharGet(riteData, riteIndex + i);

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