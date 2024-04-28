namespace Avalon.Infra;

public class StringCompare : Compare
{
    public override int Execute(object left, object right)
    {
        if (left == null | right == null)
        {
            return 0;
        }

        string leftString;
        string rightString;
        leftString = (string)left;
        rightString = (string)right;
        int a;
        a = string.CompareOrdinal(leftString, rightString);
        return a;
    }
}