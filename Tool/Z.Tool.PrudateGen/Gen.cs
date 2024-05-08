namespace Z.Tool.PrudateGen;





class Gen : Any
{
    protected virtual ReadResult ReadResult { get; set; }




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




        this.ReadResult = read.Result;




        ReadList readList;

        readList = new ReadList();

        readList.Init();



        readList.ReadResult = this.ReadResult;


        readList.Execute();
        




        this.ExecutePrudateGen(new PrudateGen());



        this.ExecutePrudateGen(new ExternGen());



        return 0;
    }




    protected virtual bool ExecutePrudateGen(PrudateGen gen)
    {
        gen.Init();



        gen.ReadResult = this.ReadResult;



        gen.Execute();



        return true;
    }
}