namespace Z.Tool.NodeListGen;

public class Gen : Any
{
    public virtual long Execute()
    {
        Read read;
        read = this.CreateRead();
        long oo;
        oo = read.Execute();
        if (!(oo == 0))
        {
            return oo;
        }

        Table classTable;
        classTable = read.ClassTable;

        NodeGen nodeGen;
        nodeGen = this.CreateNodeGen();
        nodeGen.ClassTable = classTable;
        nodeGen.Execute();

        NewStateGen newStateGen;
        newStateGen = this.CreateNewStateGen();
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

        TravelGen travelGen;
        travelGen = new TravelGen();
        travelGen.Init();
        travelGen.ClassTable = classTable;
        travelGen.Execute();

        TravelClassPathGen travelClassPathGen;
        travelClassPathGen = new TravelClassPathGen();
        travelClassPathGen.Init();
        travelClassPathGen.ClassTable = classTable;
        travelClassPathGen.Execute();
        return 0;
    }

    protected virtual Read CreateRead()
    {
        Read a;
        a = new Read();
        a.Init();
        return a;
    }
    
    protected virtual NodeGen CreateNodeGen()
    {
        NodeGen a;
        a = new NodeGen();
        a.Init();
        return a;
    }

    protected virtual NewStateGen CreateNewStateGen()
    {
        NewStateGen a;
        a = new NewStateGen();
        a.Init();
        return a;
    }
}