namespace Avalon.Text;

public class Compare : InfraCompare
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = Infra.This;
        return true;
    }

    public virtual CharCompare CharCompare { get; set; }
    protected virtual Infra TextInfra { get; set; }

    public override int Execute(object left, object right)
    {
        if (left == null | right == null)
        {
            return 0;
        }

        Infra textInfra;
        textInfra = this.TextInfra;

        Text leftText;
        Text rightText;
        leftText = (Text)left;
        rightText = (Text)right;

        Range leftRange;
        Range rightRange;
        leftRange = leftText.Range;
        rightRange = rightText.Range;

        int leftCount;
        int rightCount;
        leftCount = leftRange.Count;
        rightCount = rightRange.Count;

        int o;
        o = leftCount.CompareTo(rightCount);
        if (!(o == 0))
        {
            return o;
        }

        Data leftData;
        Data rightData;
        leftData = leftText.Data;
        rightData = rightText.Data;

        int leftIndex;
        int rightIndex;
        leftIndex = leftRange.Index;
        rightIndex = rightRange.Index;

        CharCompare charCompare;
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