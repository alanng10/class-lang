namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        this.ExecuteOperate(addOperate.Left);
        
        this.ExecuteOperate(addOperate.Right);

        gen.GetEvalValue(1, gen.VarArgA);
        gen.GetEvalValue(0, gen.VarArgB);

        


        return true;
    }


    protected virtual bool TextIndent()
    {
        return this.Gen.TextIndent();
    }

    protected virtual bool Text(string text)
    {
        return this.Gen.Text(text);
    }
}