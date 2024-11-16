class TextFormatCountState : FormatCountState
{
    maide prusate Bool Execute()
    {
        var FormatArg arg;
        arg : cast FormatArg(this.Arg);
        
        var Text text;
        text : cast Text(arg.Value);
        
        var Int a;
        a : text.Range.Count;
        
        this.Result : a;
        return true;
    }
}