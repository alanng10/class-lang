class IntParse : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.TextInfra : share Infra;
        return true;
    }

    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate Infra TextInfra { get { return data; } set { data : value; } }

    maide prusate Int Execute(var Text text, var Int varBase, var Form form)
    {
        var Infra textInfra;
        textInfra : this.TextInfra;

        inf (varBase < 2 | 16 < varBase)
        {
            return null;
        }

        var Int m;
        m : 0;
        var Int h;
        h : 1;
        var Int hh;
        hh : 1;

        var Bool baa;
        baa : (form = null);
        var Data data;
        data : text.Data;
        var Range range;
        range : text.Range;
        var Int count;
        count : range.Count;
        var Int start;
        start : range.Index;
        var Int i;
        i : 0;
        while (i < count)
        {
            h : hh;

            var Int index;
            index : start + (count - 1) - i;

            var Int n;
            n : textInfra.DataCharGet(data, index);

            inf (~baa)
            {
                n : form.Execute(n);
            }

            var Int digitValue;
            digitValue : textInfra.DigitValue(n, varBase);
            inf (digitValue = null)
            {
                return null;
            }

            var Int oo;
            oo : h * digitValue;

            var Int mm;
            mm : m + oo;

            m : mm;

            hh : h * varBase;

            i : i + 1;
        }

        var Int a;
        a : m;
        return a;
    }
}