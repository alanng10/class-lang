namespace Class.Binary;




public class CountWriteOperate : WriteOperate
{
    public override bool ExecuteByte(byte ob)
    {
        int index;

        index = this.Write.Index;

        
        index = index + 1;
        

        this.Write.Index = index;
        
        
        
        return true;
    }
}