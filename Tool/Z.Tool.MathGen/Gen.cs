namespace Z.Tool.MathGen;

class Gen : Any
{
    protected virtual Table Maide { get; set; }

    public virtual long Execute()
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

        this.Maide = read.MaideTable;

        read.MaideTable = null;

        bool b;

        b = this.ExecutePartGen(new InfraPartGen());
        if (!b)
        {
            return 600;
        }

        b = this.ExecutePartGen(new AvalonPartGen());
        if (!b)
        {
            return 601;
        }

        return 0;
    }

    protected virtual bool ExecutePartGen(PartGen partGen)
    {
        partGen.Init();

        partGen.Maide = this.Maide;

        bool b;
        b = partGen.Execute();

        return b;
    }
}