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

        this.ClassTable = read.ClassTable;

        NodeGen nodeGen;
        nodeGen = this.CreateNodeGen();
        nodeGen.ClassTable = this.ClassTable;
        nodeGen.Execute();

        NewStateGen newStateGen;
        newStateGen = this.CreateNewStateGen();
        newStateGen.ClassTable = this.ClassTable;
        newStateGen.Execute();

        NodeStateGen nodeStateGen;
        nodeStateGen = this.CreateNodeStateGen();
        nodeStateGen.ClassTable = this.ClassTable;
        nodeStateGen.Execute();

        CreateSetStateGen createSetStateGen;
        createSetStateGen = this.CreateCreateSetStateGen();
        createSetStateGen.ClassTable = this.ClassTable;
        createSetStateGen.Execute();

        this.ExecuteNodeKindList();

        TravelGen travelGen;
        travelGen = this.CreateTravelGen();
        travelGen.ClassTable = this.ClassTable;
        travelGen.Execute();

        TravelClassPathGen travelClassPathGen;
        travelClassPathGen = this.CreateTravelClassPathGen();
        travelClassPathGen.ClassTable = this.ClassTable;
        travelClassPathGen.Execute();
        return 0;
    }

    protected virtual Table ClassTable { get; set; }

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

    protected virtual NodeStateGen CreateNodeStateGen()
    {
        NodeStateGen a;
        a = new NodeStateGen();
        a.Init();
        return a;
    }

    protected virtual CreateSetStateGen CreateCreateSetStateGen()
    {
        CreateSetStateGen a;
        a = new CreateSetStateGen();
        a.Init();
        return a;
    }

    protected virtual NodeKindListGen CreateNodeKindListGen()
    {
        NodeKindListGen a;
        a = new NodeKindListGen();
        a.Init();
        return a;
    }

    protected virtual TravelGen CreateTravelGen()
    {
        TravelGen a;
        a = new TravelGen();
        a.Init();
        return a;
    }

    protected virtual TravelClassPathGen CreateTravelClassPathGen()
    {
        TravelClassPathGen a;
        a = new TravelClassPathGen();
        a.Init();
        return a;
    }

    protected virtual bool ExecuteNodeKindList()
    {
        NodeKindListGen nodeKindListGen;
        nodeKindListGen = this.CreateNodeKindListGen();
        nodeKindListGen.ClassTable = this.ClassTable;
        nodeKindListGen.Execute();
        return true;
    }
}