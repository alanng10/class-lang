namespace Avalon.Infra;

public class StringCompare : Compare
{
    public virtual IntCompare CharCompare { get; set; }

    public override int Execute(object left, object right)
    {
        string leftString;
        string rightString;
        leftString = (string)left;
        rightString = (string)right;

        int leftCount;
        leftCount = leftString.Length;

        int rightCount;
        rightCount = rightString.Length;

        IntCompare charCompare;
        charCompare = this.CharCompare;

        int count;
        count = leftCount;
        if (rightCount < count)
        {
            count = rightCount;
        }

        int i;
        i = 0;
        while (i < count)
        {
            char oca;
            char ocb;
            oca = leftString[i];
            ocb = rightString[i];

            int oo;
            oo = charCompare.Execute(oca, ocb);
            if (!(oo == 0))
            {
                return oo;
            }

            i = i + 1;
        }

        return leftCount - rightCount;
    }
}