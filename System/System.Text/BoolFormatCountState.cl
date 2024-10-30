class BoolFormatCountState : FormatCountState
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share Infra;
        this.StringComp : share StringComp;
        return true;
    }

    field precate Infra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    
    maide prusate Bool Execute()
    {
        var Infra textInfra;
        textInfra : this.TextInfra;

        var StringComp stringComp;
        stringComp : this.StringComp;
        
        var FormatArg arg;
        arg : cast FormatArg(this.Arg);

        var Bool b;
        b : cast Bool(arg.Value);
        var Int k;
        k : 0;
        inf (~b)
        {
            k : stringComp.Count(textInfra.BoolFalseString);
        }
        inf (b)
        {
            k : stringComp.Count(textInfra.BoolTrueString);
        }
        
        this.Result : k;
        return true;
    }
}