namespace Class.Infra;





class AddWriteOperate : WriteOperate
{
    public virtual StringInfra Infra { get; set; }





    public override bool ExecuteChar(char oc)
    {
        int index;


        index = this.Infra.Index;




        this.Infra.Array[index] = oc;
        



        index = index + 1;




        this.Infra.Index = index;



        return true;
    }
}