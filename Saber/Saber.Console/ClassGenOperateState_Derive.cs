namespace Saber.Console;

public class EndClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateEnd();
        return true;
    }
}

public class RetClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateRet();
        return true;
    }
}

public class ReferClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateRefer();
        return true;
    }
}

public class InfStartClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateInfStart();
        return true;
    }
}

public class InfEndClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateInfEnd();
        return true;
    }
}

public class WhileStartClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateWhileStart();
        return true;
    }
}

public class WhileClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateWhile();
        return true;
    }
}

public class WhileEndClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateWhileEnd();
        return true;
    }
}

public class AreClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateAre();
        return true;
    }
}

public class VarMarkClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateVarMark();
        return true;
    }
}

public class SetMarkClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateSetMark();
        return true;
    }
}

public class GetClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateGet();
        return true;
    }
}

public class CallClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateCall();
        return true;
    }
}

public class VarClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateVar();
        return true;
    }
}

public class BoolValueClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBoolValue();
        return true;
    }
}

public class IntValueClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateIntValue();
        return true;
    }
}

public class StringValueClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateStringValue();
        return true;
    }
}

public class ThisClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateThis();
        return true;
    }
}

public class BaseClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBase();
        return true;
    }
}

public class NullClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateNull();
        return true;
    }
}

public class NewClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateNew();
        return true;
    }
}

public class ShareClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateShare();
        return true;
    }
}

public class CastClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateCast();
        return true;
    }
}

public class SameClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateSame();
        return true;
    }
}

public class AndClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateAnd();
        return true;
    }
}

public class OrnClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateOrn();
        return true;
    }
}

public class NotClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateNot();
        return true;
    }
}

public class LessClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateLess();
        return true;
    }
}

public class AddClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateAdd();
        return true;
    }
}

public class SubClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateSub();
        return true;
    }
}

public class MulClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateMul();
        return true;
    }
}

public class DivClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateDiv();
        return true;
    }
}

public class SignLessClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateSignLess();
        return true;
    }
}

public class SignMulClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateSignMul();
        return true;
    }
}

public class SignDivClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateSignDiv();
        return true;
    }
}

public class BitAndClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBitAnd();
        return true;
    }
}

public class BitOrnClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBitOrn();
        return true;
    }
}

public class BitNotClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBitNot();
        return true;
    }
}

public class BitLiteClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBitLite();
        return true;
    }
}

public class BitRiteClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBitRite();
        return true;
    }
}

public class BitSignRiteClassGenOperateState : ClassGenOperateState
{
    public override bool Execute()
    {
        this.Gen.ExecuteOperateBitSignRite();
        return true;
    }
}

