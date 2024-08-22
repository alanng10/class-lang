namespace Z.Tool.Class.NodeList;

public class Gen : Any
{
    public virtual int Execute()
    {
        Read read;
        read = new Read();
        read.Init();
        int oo;
        oo = read.Execute();
        if (!(oo == 0))
        {
            return oo;
        }

        Table classTable;
        classTable = read.ClassTable;

        NodeGen nodeGen;
        nodeGen = new NodeGen();
        nodeGen.Init();
        nodeGen.ClassTable = classTable;
        nodeGen.Execute();

        NewStateGen newStateGen;
        newStateGen = new NewStateGen();
        newStateGen.Init();
        newStateGen.ClassTable = classTable;
        newStateGen.Execute();

        NodeStateGen nodeStateGen;
        nodeStateGen = new NodeStateGen();
        nodeStateGen.Init();
        nodeStateGen.ClassTable = classTable;
        nodeStateGen.Execute();

        CreateOperateStateGen createOperateStateGen;
        createOperateStateGen = new CreateOperateStateGen();
        createOperateStateGen.Init();
        createOperateStateGen.ClassTable = classTable;
        createOperateStateGen.Execute();

        NodeKindListGen nodeKindListGen;
        nodeKindListGen = new NodeKindListGen();
        nodeKindListGen.Init();
        nodeKindListGen.ClassTable = classTable;
        nodeKindListGen.Execute();

        TraverseGen traverseGen;
        traverseGen = new TraverseGen();
        traverseGen.Init();
        traverseGen.ClassTable = classTable;
        traverseGen.Execute();

        TraverseClassPathGen traverseClassPathGen;
        traverseClassPathGen = new TraverseClassPathGen();
        traverseClassPathGen.Init();
        traverseClassPathGen.ClassTable = classTable;
        traverseClassPathGen.Execute();
        return 0;
    }
}