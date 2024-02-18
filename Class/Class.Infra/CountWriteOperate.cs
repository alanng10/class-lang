namespace Class.Infra;





class CountWriteOperate : WriteOperate
{
    public virtual StringInfra Infra { get; set; }



    public override bool ExecuteChar(char oc)
    {
        int index;


        index = this.Infra.Index;



        index = index + 1;



        this.Infra.Index = index;



        return true;
    }
}