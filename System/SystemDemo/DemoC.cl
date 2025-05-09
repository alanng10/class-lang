class DemoC : DemoB
{
    field precate Int Aa { get { base.Aa; share Console.Out.Write("DemoC Field Get\n"); } set { base.Aa : null; share Console.Out.Write("DemoC Field Set\n"); } }
    field precate String Ake { get { return data; } set { base.Ake : value; } }
    field private Int Aaa { get { return data; } set { } }

    maide prusate Bool Execute()
    {
        base.Execute();

        this.Console.Out.Write("DemoC Execute\n");

        this.ExecuteA();

        this.Aa;
        this.Aa : null;

        var Bool baaa;
        baaa : (this.Aaa = null);
        this.Console.Out.Write(this.AddClear().Add("Demo Field Data Default ").Add(this.StatusString(baaa)).AddLine().AddResult());

        var String kaaa;
        kaaa : "Ke ad";

        this.Ake : kaaa;

        var String kkk;
        kkk : this.Ake;

        var Bool baab;
        baab : kkk = kaaa;

        this.Console.Out.Write(this.AddClear().Add("Demo Base Field Data ").Add(this.StatusString(baab)).AddLine().AddResult());

        return true;
    }
}