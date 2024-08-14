namespace Avalon.Text;

public class Compare : InfraCompare
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = Infra.This;
        return true;
    }

    public virtual CompareInt CharCompare { get; set; }
    public virtual CharForm LeftCharForm { get; set; }
    public virtual CharForm RightCharForm { get; set; }
    protected virtual Infra TextInfra { get; set; }

    public override long Execute(object left, object right)
    {
        Infra textInfra;
        textInfra = this.TextInfra;

        Text leftText;
        Text rightText;
        leftText = (Text)left;
        rightText = (Text)right;

        if (!textInfra.ValidRange(leftText))
        {
            return 0;
        }
        if (!textInfra.ValidRange(rightText))
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

        long leftIndex;
        long leftCount;
        leftIndex = leftRange.Index;
        leftCount = leftRange.Count;

        long rightIndex;
        long rightCount;
        rightIndex = rightRange.Index;
        rightCount = rightRange.Count;

        CompareInt charCompare;
        charCompare = this.CharCompare;

        CharForm leftCharForm;
        CharForm rightCharForm;
        leftCharForm = this.LeftCharForm;
        rightCharForm = this.RightCharForm;

        long count;
        count = leftCount;
        if (rightCount < count)
        {
            count = rightCount;
        }

        long i;
        i = 0;
        while (i < count)
        {
            uint oca;
            uint ocb;
            oca = textInfra.DataCharGet(leftData, leftIndex + i);
            ocb = textInfra.DataCharGet(rightData, rightIndex + i);

            oca = (uint)leftCharForm.Execute(oca);
            ocb = (uint)rightCharForm.Execute(ocb);

            long oo;
            oo = charCompare.Execute(oca, ocb);
            if (!(oo == 0))
            {
                return oo;
            }

            i = i + 1;
        }

        long k;
        k = leftCount - rightCount;
        
        long a;
        a = 0;
        if (k < 0)
        {
            a = -1;
        }

        if (0 < k)
        {
            a = 1;
        }
        return a;
    }
}