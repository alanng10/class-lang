namespace Z.Tool.InternGen;

class Gen : Any
{
    public virtual int Execute()
    {
        Read read;
        read = new Read();
        read.Init();
        int o;
        o = read.Execute();

        if (!(o == 0))
        {
            return o;
        }

        Table table;
        table = read.MaideTable;

        read.MaideTable = null;

        StateGen stateGen;
        stateGen = new StateGen();
        stateGen.Init();

        stateGen.MaideTable = table;

        stateGen.Execute();

        return 0;
    }
}