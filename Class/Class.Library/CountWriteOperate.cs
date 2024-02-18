namespace Class.Library;




public class CountWriteOperate : WriteOperate
{
    public override bool ExecuteChar(char oc)
    {
        int index;

        index = this.Create.Index;

        
        index = index + 1;
        

        this.Create.Index = index;
        
        
        
        return true;
    }
    


    
    public override bool ExecuteIntValueHex(long a)
    {
        int index;

        index = this.Create.Index;

        
        
        index = index + this.Create.TextStat.IntHexDigitCount;
        
        

        this.Create.Index = index;
        
        
        
        return true;
    }
}