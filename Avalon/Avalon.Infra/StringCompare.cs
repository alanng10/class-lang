namespace Avalon.Infra;

public class StringCompare : Compare
{
    public virtual CompareMid CharCompare { get; set; }
    public virtual CharForm CharForm { get; set; }

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

        CompareMid charCompare;
        charCompare = this.CharCompare;

        CharForm charForm;
        charForm = this.CharForm;

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

            oca = (char)charForm.Execute(oca);
            ocb = (char)charForm.Execute(ocb);

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