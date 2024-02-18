namespace Class.Token;






public class SetCreateOperate : CreateOperate
{
    public virtual Create Create { get; set; }








    public override bool ExecuteToken()
    {
        int index;


        index = this.Create.TokenIndex;




        


        Token token;



        token = (Token)this.Create.Code.Token.Get(index);

        
        
        

        token.Range.Row = this.Create.Range.Row;




        InfraRange aa;


        aa = token.Range.Col; 
        



        InfraRange ab;
        

        ab = this.Create.Range.Col;



        aa.Start = ab.Start;
        
        
        aa.End = ab.End;







        index = index + 1;





        this.Create.TokenIndex = index;






        return true;
    }




    public override bool ExecuteComment()
    {
        int index;


        index = this.Create.CommentIndex;




        


        Comment comment;



        comment = (Comment)this.Create.Code.Comment.Get(index);

        
        
        

        comment.Range.Row = this.Create.Range.Row;




        InfraRange aa;


        aa = comment.Range.Col;
        



        InfraRange ab;
        
        
        ab = this.Create.Range.Col;



        aa.Start = ab.Start;


        aa.End = ab.End;






        index = index + 1;





        this.Create.CommentIndex = index;






        return true;
    }
}