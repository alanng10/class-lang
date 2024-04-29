namespace Avalon.Math;

public class Compose : Any
{
    public virtual long Significand { get { return __D_Significand; } set { __D_Significand = value; } }
    protected long __D_Significand;
    public virtual long Exponent { get { return __D_Exponent; } set { __D_Exponent = value; } }
    protected long __D_Exponent;
}