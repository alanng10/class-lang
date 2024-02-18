namespace Z.Tool.NodeListSourceGen;







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



        Array classArray;

        classArray = read.ClassArray;





        NodeGen nodeGen;

        nodeGen = new NodeGen();

        nodeGen.Init();


        nodeGen.ClassArray = classArray;

        nodeGen.Execute();




        NewStateGen newStateGen;

        newStateGen = new NewStateGen();

        newStateGen.Init();


        newStateGen.ClassArray = classArray;

        newStateGen.Execute();





        NodeStateGen nodeStateGen;

        nodeStateGen = new NodeStateGen();

        nodeStateGen.Init();


        nodeStateGen.ClassArray = classArray;

        nodeStateGen.Execute();





        CreateOperateStateGen createOperateStateGen;

        createOperateStateGen = new CreateOperateStateGen();

        createOperateStateGen.Init();


        createOperateStateGen.ClassArray = classArray;

        createOperateStateGen.Execute();





        NodeKindListGen nodeKindListGen;

        nodeKindListGen = new NodeKindListGen();

        nodeKindListGen.Init();


        nodeKindListGen.ClassArray = classArray;

        nodeKindListGen.Execute();





        return 0;
    }
}