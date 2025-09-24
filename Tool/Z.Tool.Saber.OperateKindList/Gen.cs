namespace Z.Tool.Saber.OperateKindList;

public class Gen : Any
{
    public virtual long Execute()
    {
        ListGen gen;
        gen = new ListGen();
        gen.Init();
        long k;
        k = gen.Execute();
        return 0;
    }
}