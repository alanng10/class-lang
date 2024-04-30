namespace Avalon.Text;

public class SIntFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        long value;
        value = arg.ValueInt;
        int varBase;
        varBase = arg.Base;
        int sign;
        sign = arg.Sign;

        long oa;
        oa = value;
        oa = oa << 4;
        oa = oa >> 4;

        bool b;
        b = (oa < 0);

        bool hasSign;
        hasSign = false;

        if (!b)
        {
            if (sign == 1)
            {
                hasSign = true;
            }
            if ((sign == 2) & (!(oa == 0)))
            {
                hasSign = true;
            }
        }
        if (b)
        {
            hasSign = true;
        }

        if (b)
        {
            oa = -oa;
        }

        long ua;
        ua = oa;

        int count;
        count = this.Format.IntDigitCount(ua, varBase);

        if (hasSign)
        {
            count = count + 1;
        }

        this.Result = count;
        return true;
    }
}