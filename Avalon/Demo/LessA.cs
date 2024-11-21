namespace Demo;

class LessA : Less
{
    public override bool Init()
    {
        base.Init();
        this.IntLess = new LessInt();
        this.IntLess.Init();
        return true;
    }

    protected virtual LessInt IntLess { get; set; }

    public override long Execute(object lite, object rite)
    {
        Value liteValue;
        Value riteValue;
        liteValue = lite as Value;
        riteValue = rite as Value;

        long k;
        k = this.IntLess.Execute(liteValue.Int, riteValue.Int);

        return k;
    }
}