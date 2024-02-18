namespace Class.Token;






public class CountCreateOperate : CreateOperate
{
    public virtual Create Create { get; set; }




    public override bool ExecuteToken()
    {
        int index;


        index = this.Create.TokenIndex;




        index = index + 1;




        this.Create.TokenIndex = index;




        return true;
    }







    public override bool ExecuteComment()
    {
        int index;


        index = this.Create.CommentIndex;




        index = index + 1;




        this.Create.CommentIndex = index;




        return true;
    }
}