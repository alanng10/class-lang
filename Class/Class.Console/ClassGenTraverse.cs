namespace Class.Console;

public class ClassGenTraverse : Traverse
{
    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        this.ExecuteOperate(andOperate.Left);

        this.ExecuteOperate(andOperate.Right);

        this.ExecuteOperateDelimit(this.Gen.DelimitAnd);
        return true;
    }

    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        this.ExecuteOperate(ornOperate.Left);

        this.ExecuteOperate(ornOperate.Right);

        this.ExecuteOperateDelimit(this.Gen.DelimitOrn);
        return true;
    }

    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        this.ExecuteOperate(addOperate.Left);
        
        this.ExecuteOperate(addOperate.Right);

        this.ExecuteOperateDelimit(this.Gen.DelimitAdd);
        return true;
    }

    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        this.ExecuteOperate(subOperate.Left);

        this.ExecuteOperate(subOperate.Right);

        this.ExecuteOperateDelimit(this.Gen.DelimitSub);
        return true;
    }

    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        this.ExecuteOperate(mulOperate.Left);

        this.ExecuteOperate(mulOperate.Right);

        this.ExecuteOperateDelimit(this.Gen.DelimitMul);
        return true;
    }

    protected virtual bool ExecuteOperateDelimit(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarArgA;
        argB = gen.VarArgB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.GetEvalValue(2, argA);
        gen.GetEvalValue(1, argB);

        gen.ClearVarMask(argA, ka);
        gen.ClearVarMask(argB, ka);

        gen.OperateDelimit(argA, argA, argB, delimit);

        gen.ClearVarMask(argA, ka);

        gen.SetVarMask(argA, gen.RefKindIntMask);

        gen.SetEvalValue(2, argA);

        gen.SetEvalIndexPos(-1);

        return true;
    }

    protected virtual bool ExecuteOperateDelimitBool(string delimit)
    {
        ClassGen gen;
        gen = this.Gen;

        string argA;
        string argB;
        argA = gen.VarArgA;
        argB = gen.VarArgB;

        string ka;
        ka = gen.RefKindClearMask;

        gen.GetEvalValue(2, argA);
        gen.GetEvalValue(1, argB);

        gen.ClearVarMask(argA, ka);
        gen.ClearVarMask(argB, ka);

        gen.OperateDelimit(argA, argA, argB, delimit);

        gen.SetVarMask(argA, gen.RefKindBoolMask);

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