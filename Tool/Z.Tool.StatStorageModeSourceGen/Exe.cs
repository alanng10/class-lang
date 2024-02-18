namespace Z.Tool.StatStorageModeSourceGen;




class Exe : Any
{
    static int Main()
    {
        Gen gen;

        gen = new Gen();

        gen.Init();



        int o;

        o = gen.Execute();


        return o;
    }
}