namespace Avalon.Draw;





class BrushInfra : Any
{
    public static BrushInfra This { get; } = ShareCreate();




    private static BrushInfra ShareCreate()
    {
        BrushInfra share;

        share = new BrushInfra();



        Any a;

        a = share;

        a.Init();



        return share;
    }




    internal virtual ulong InternColor(Color color)
    {
        ulong k;

        k = 0;



        k = k | ((((ulong)color.Blue) & 0xff) << (0 * 8));


        k = k | ((((ulong)color.Green) & 0xff) << (1 * 8));


        k = k | ((((ulong)color.Red) & 0xff) << (2 * 8));


        k = k | ((((ulong)color.Alpha) & 0xff) << (3 * 8));



        return k;
    }
}