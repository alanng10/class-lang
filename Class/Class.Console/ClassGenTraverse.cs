namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarArgA;
        argB = gen.VarArgB;

        string ka;
        ka = gen.RefKindClearMask;

        this.ExecuteOperate(addOperate.Left);
        
        this.ExecuteOperate(addOperate.Right);

        gen.GetEvalValue(2, argA);
        gen.GetEvalValue(1, argB);

        gen.ClearVarMask(argA, ka);
        gen.ClearVarMask(argB, ka);

        gen.Add(argA, argA, argB);

        gen.ClearVarMask(argA, ka);

        gen.SetVarMask(argA, gen.RefKindIntMask);

        gen.SetEvalValue(2, argA);

        gen.SetEvalIndexPos(-1);
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