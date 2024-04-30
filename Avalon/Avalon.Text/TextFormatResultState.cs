namespace Avalon.Text;

public class TextFormatResultState : FormatResultState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;
        Text result;
        result = this.ArgResult;
        Format format;
        format = this.Format;

        int valueCount;
        valueCount = arg.ValueCount;
        int count;
        count = arg.Count;
        Text value;
        value = arg.ValueText;

        bool alignLeft;
        alignLeft = arg.AlignLeft;

        int fillCount;
        fillCount = 0;
        int clampCount;
        clampCount = 0;

        if (valueCount < count)
        {
            fillCount = count - valueCount;
        }

        if (count < valueCount)
        {
            clampCount = valueCount - count;
        }

        int varCase;
        varCase = arg.Case;
        char fillChar;
        fillChar = arg.FillChar;

        int fillStart;
        fillStart = 0;
        int valueStart;
        valueStart = 0;
        int valueIndex;
        valueIndex = 0;

        int valueWriteCount;
        valueWriteCount = valueCount - clampCount;

        if (alignLeft)
        {
            fillStart = valueWriteCount;
            valueStart = 0;
            valueIndex = 0;
        }

        if (!alignLeft)
        {
            fillStart = 0;
            valueStart = fillCount;
            valueIndex = clampCount;
        }

        format.ResultString(result, value, varCase, valueWriteCount, valueStart, valueIndex);

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}