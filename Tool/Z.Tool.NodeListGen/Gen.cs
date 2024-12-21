namespace Z.Tool.NodeListGen;

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

        CreateSetStateGen createSetStateGen;
        createSetStateGen = new CreateSetStateGen();
        createSetStateGen.Init();
        createSetStateGen.ClassTable = classTable;
        createSetStateGen.Execute();

        NodeKindListGen nodeKindListGen;
        nodeKindListGen = new NodeKindListGen();
        nodeKindListGen.Init();
        nodeKindListGen.ClassTable = classTable;
        nodeKindListGen.Execute();

        TravelGen traverseGen;
        traverseGen = new TravelGen();
        traverseGen.Init();
        traverseGen.ClassTable = classTable;
        traverseGen.Execute();

        TravelClassPathGen traverseClassPathGen;
        traverseClassPathGen = new TravelClassPathGen();
        traverseClassPathGen.Init();
        traverseClassPathGen.ClassTable = classTable;
        traverseClassPathGen.Execute();
        return 0;
    }
}