namespace Class.Library;



public class AddWriteOperate : WriteOperate
{
    public override bool Init()
    {
        base.Init();


        this.Span = new TextSpan();

        this.Span.Init();


        this.Span.Range = new Range();

        this.Span.Range.Init();
        
        
        
        return true;
    }
    
    
    
    protected virtual TextSpan Span { get; set; }
    
    
    
    public override bool ExecuteChar(char oc)
    {
        int index;

        index = this.Create.Index;


        
        this.Create.Array[index] = oc;
        
        
        
        index = index + 1;
        

        this.Create.Index = index;
        
        
        
        return true;
    }
    
    
    
    
    public override bool ExecuteIntValueHex(long a)
    {
        int index;

        index = this.Create.Index;



        this.Span.Data = this.Create.Array;


        
        int count;

        count = this.Create.TextStat.IntHexDigitCount;
        
        
        
        int end;

        end = index + count;


        
        this.Span.Range.Start = index;
        
        
        this.Span.Range.End = end;
        

        

        this.Create.TextInfra.GetIntHexText(this.Span, a);
        
        
        
        
        index = index + count;
        
        

        this.Create.Index = index;
        
        
        
        return true;
    }
}