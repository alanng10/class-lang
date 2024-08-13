namespace Avalon.Infra;

public class StringCompare : Compare
{
    public override bool Init()
    {
        base.Init();
        this.StringComp = StringComp.This;
        return true;
    }

    public virtual CompareInt CharCompare { get; set; }
    public virtual CharForm LeftCharForm { get; set; }
    public virtual CharForm RightCharForm { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public override int Execute(object left, object right)
    {
        StringComp stringComp;
        stringComp = this.StringComp;

        String leftString;
        String rightString;
        leftString = (String)left;
        rightString = (String)right;

        long leftCount;
        long rightCount;
        leftCount = stringComp.Count(leftString);
        rightCount = stringComp.Count(rightString);

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
            oca = (uint)stringComp.Char(leftString, i);
            ocb = (uint)stringComp.Char(rightString, i);

            oca = (uint)leftCharForm.Execute(oca);
            ocb = (uint)rightCharForm.Execute(ocb);

            int oo;
            oo = charCompare.Execute(oca, ocb);
            if (!(oo == 0))
            {
                return oo;
            }

            i = i + 1;
        }

        long k;
        k = leftCount - rightCount;
        
        int a;
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