class BoolFormatResultState : FormatResultState
{
    maide prusate Bool Execute()
    {
        var FormatResultArg kke;
        kke : cast FormatResultArg(this.Arg);
        var FormatArg arg;
        arg : kke.Arg;
        var Text result;
        result : kke.Result;
        var Format format;
        format : this.Format;
        
        var Int valueCount;
        valueCount : arg.ValueCount;
        var Int count;
        count : arg.Count;
        var Bool value;
        value : cast Bool(arg.Value);
        var Bool alignLeft;
        alignLeft : arg.AlignLeft;
        
        var Int fillCount;
        fillCount : 0;
        var Int clampCount;
        clampCount : 0;
        
        inf (valueCount < count)
        {
            fillCount : count - valueCount;
        }
        
        inf (count < valueCount)
        {
            clampCount : valueCount - count;
        }
        
        var Int fillChar;
        fillChar : arg.FillChar;
    }
}