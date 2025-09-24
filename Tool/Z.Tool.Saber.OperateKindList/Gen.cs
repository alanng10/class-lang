namespace Z.Tool.Saber.OperateKindList;

public class Gen : Any
{
    public virtual long Execute()
    {
        ListGen listGen;
        listGen = new ListGen();
        listGen.Init();
        listGen.Execute();

        Table itemTable;
        itemTable = listGen.TableResult;

        StateGen stateGen;
        stateGen = new StateGen();
        stateGen.Init();
        stateGen.ItemTable = itemTable;
        stateGen.Execute();

        InitGen initGen;
        initGen = new InitGen();
        initGen.Init();
        initGen.ItemTable = itemTable;
        initGen.Execute();
        return 0;
    }
}