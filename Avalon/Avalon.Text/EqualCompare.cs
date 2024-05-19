namespace Avalon.Text;

public class EqualCompare : Compare
{
    public override int Execute(object left, object right)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        Text leftText;
        Text rightText;
        leftText = (Text)left;
        rightText = (Text)right;

        if (!textInfra.CheckRange(leftText))
        {
            return 0;
        }
        if (!textInfra.CheckRange(rightText))
        {
            return 0;
        }

        Data leftData;
        Data rightData;
        leftData = leftText.Data;
        rightData = rightText.Data;

        Range leftRange;
        Range rightRange;
        leftRange = leftText.Range;
        rightRange = rightText.Range;

        int leftIndex;
        int leftCount;
        leftIndex = leftRange.Index;
        leftCount = leftRange.Count;

        int rightIndex;
        int rightCount;
        rightIndex = rightRange.Index;
        rightCount = rightRange.Count;

        int da;
        da = leftCount - rightCount;
        if (!(da == 0))
        {
            return da;
        }

        IntCompare charCompare;
        charCompare = this.CharCompare;

        int count;
        count = leftCount;

        int i;
        i = 0;
        while (i < count)
        {
            char oca;
            char ocb;
            oca = textInfra.DataCharGet(leftData, leftIndex + i);
            ocb = textInfra.DataCharGet(rightData, rightIndex + i);

            int oo;
            oo = charCompare.Execute(oca, ocb);
            if (!(oo == 0))
            {
                return oo;
            }

            i = i + 1;
        }

        return 0;
    }
}