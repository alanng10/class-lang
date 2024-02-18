namespace Class.Binary;



public class AddWriteOperate : WriteOperate
{
    public override bool ExecuteByte(byte ob)
    {
        int index;

        index = this.Write.Index;


        
        this.Write.Data.Value[index] = ob;
        
        
        
        index = index + 1;
        

        this.Write.Index = index;
        
        
        
        return true;
    }
}