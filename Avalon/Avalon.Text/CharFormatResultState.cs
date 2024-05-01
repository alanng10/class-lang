namespace Avalon.Text;

public class CharFormatResultState : FormatResultState
{
    public override bool Init()
    {
        base.Init();
        this.CharText = this.Format.TextInfra.TextCreate(1);
        return true;
    }

    protected virtual Text CharText { get { return __D_CharText; } set { __D_CharText = value; } }
    protected Text __D_CharText;

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
        long value;
        value = arg.ValueInt;
        char valueChar;
        valueChar = (char)value;

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

        Text valueText;
        valueText = this.CharText;
        format.TextInfra.DataCharSet(valueText.Data, 0, valueChar);

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

        format.ResultText(result, valueText, varCase, valueWriteCount, valueStart, valueIndex);

        format.ResultFill(result, fillStart, fillCount, fillChar);
        return true;
    }
}