namespace Z.Tool.MathGen;

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

        Table maide;
        maide = read.MaideTable;

        read.MaideTable = null;



        return 0;
    }
}