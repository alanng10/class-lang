class IntFormatResultState : FormatResultState
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
        count: arg.Count;
        var Int value;
        value : cast Int(arg.Value);
        
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
        
        var Int varBase;
        varBase : arg.Base;
        var Int fillChar;
        fillChar : arg.FillChar;
        
        var Int fillStart;
        var Int valueStart;
        var Int valueIndex;
        
        var Int valueWriteCount;
        valueWriteCount : valueCount - clampCount;
        
        inf (alignLeft)
        {
            fillStart : valueWriteCount;
            valueStart : 0;
            valueIndex : 0;
        }
        
        inf (~alignLeft)
        {
            fillStart : 0;
            valueStart : fillCount;
            valueIndex : clampCount;
        }
        
        format.ResultInt(result, arg.Form, value, varBase, valueCount, valueWriteCount, valueStart, valueIndex);
        
        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}