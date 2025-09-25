namespace Saber.Console;

public class ClassGenTravel : Travel
{
    public virtual ClassGen Gen { get; set; }

    public override bool ExecuteField(NodeField varField)
    {
        ClassGen gen;
        gen = this.Gen;

        State varGet;
        varGet = varField.Get;

        State varSet;
        varSet = varField.Set;

        Field field;
        field = this.Info(varField).Field;

        gen.ThisField = field;

        gen.CompStateKind = gen.StateKindGet;

        gen.ParamCount = 0;

        gen.LocalVarCount = field.Get.Count - 1;

        gen.CompStateStart(gen.Class, field, gen.StateKindGet);

        base.ExecuteState(varGet);

        gen.CompStateEnd();

        gen.Text(gen.NewLine);

        gen.CompStateKind = gen.StateKindSet;

        gen.ParamCount = 1;

        gen.LocalVarCount = field.Set.Count - 2;

        gen.CompStateStart(gen.Class, field, gen.StateKindSet);

        base.ExecuteState(varSet);

        gen.CompStateEnd();

        gen.Text(gen.NewLine);

        gen.ThisField = null;

        return true;
    }

    public override bool ExecuteMaide(NodeMaide varMaide)
    {
        ClassGen gen;
        gen = this.Gen;

        State call;
        call = varMaide.Call;

        Maide maide;
        maide = this.Info(varMaide).Maide;

        gen.CompStateKind = gen.StateKindCall;

        gen.ParamCount = maide.Param.Count;

        gen.LocalVarCount = maide.Call.Count - maide.Param.Count;

        gen.CompStateStart(gen.Class, maide, gen.StateKindCall);

        base.ExecuteState(call);

        gen.CompStateEnd();

        gen.Text(gen.NewLine);

        return true;
    }

    public override bool ExecuteState(State state)
    {
        ClassGen gen;
        gen = this.Gen;

        gen.IndentCount = gen.IndentCount + 1;

        base.ExecuteState(state);

        gen.IndentCount = gen.IndentCount - 1;

        return true;
    }

    public override bool ExecuteBitSignRiteOperate(BitSignRiteOperate bitSignRiteOperate)
    {
        base.ExecuteBitSignRiteOperate(bitSignRiteOperate);

        this.Gen.ExecuteOperateLimitAB(this.Gen.LimitBitRite);
        return true;
    }

    public override bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        Value value;
        value = valueOperate.Value;

        ClassGen gen;
        gen = this.Gen;

        String varA;
        varA = gen.VarA;

        gen.VarSetPre(varA);

        base.ExecuteValueOperate(valueOperate);

        gen.VarSetPost();

        gen.EvalValueSet(0, varA);

        gen.EvalIndexPosSet(1);

        return true;
    }

    public override bool ExecuteBoolValue(BoolValue boolValue)
    {
        this.Gen.BoolValueRef(boolValue.Value);
        return true;
    }

    public override bool ExecuteIntValue(IntValue intValue)
    {
        this.Gen.IntValueRef(intValue.Value);
        return true;
    }

    public override bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        this.Gen.IntValueRef(intSignValue.Value);
        return true;
    }

    public override bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        this.Gen.IntValueRef(intHexValue.Value);
        return true;
    }

    public override bool ExecuteIntHexSignValue(IntHexSignValue intHexSignValue)
    {
        this.Gen.IntValueRef(intHexSignValue.Value);
        return true;
    }

    public override bool ExecuteStringValue(StringValue stringValue)
    {
        long index;
        index = this.Gen.StringValueIndex;

        this.Gen.StringValueRef(index);

        index = index + 1;

        this.Gen.StringValueIndex = index;
        return true;
    }

    protected virtual ModuleInfo Info(NodeNode node)
    {
        return node.NodeAny as ModuleInfo;
    }
}