class IntFormatCountState : FormatCountState
{
    maide prusate Bool Execute()
    {
        var FormatArg arg;
        arg : cast FormatArg(this.Arg);
        
        var Int value;
        value : cast Int(arg.Value);
        
        var Int count;
        count : this.Format.IntDigitCount(value, arg.Base);
        
        this.Result : count;
        return true;
    }
}