namespace Class.Node;

public class WhileExecute : Execute
{
    public virtual Operate Cond { get; set; }
    public virtual State Loop { get; set; }
}