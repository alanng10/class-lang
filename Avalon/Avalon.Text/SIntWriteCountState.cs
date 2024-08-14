namespace Avalon.Text;

public class SIntWriteCountState : WriteCountState
{
    public override bool Execute()
    {
        WriteArg arg;
        arg = (WriteArg)this.Arg;

        long value;
        value = arg.Value.Int;
        long varBase;
        varBase = arg.Base;
        long sign;
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

        ulong ua;
        ua = (ulong)oa;

        long count;
        count = this.Format.IntDigitCount(ua, varBase);

        if (hasSign)
        {
            count = count + 1;
        }

        long a;
        a = count;

        Value aa;
        aa = (Value)this.Result;
        aa.Int = a;
        return true;
    }
}