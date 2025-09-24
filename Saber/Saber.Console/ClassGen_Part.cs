namespace Saber.Console;

partial class ClassGen
{
    public virtual bool InitOperateKindState()
    {
        this.OperateKindList.End.Any = this.InitOperateState(new EndClassGenOperateState());
        this.OperateKindList.Ret.Any = this.InitOperateState(new RetClassGenOperateState());
        this.OperateKindList.Refer.Any = this.InitOperateState(new ReferClassGenOperateState());
        this.OperateKindList.Are.Any = this.InitOperateState(new AreClassGenOperateState());
        this.OperateKindList.InfStart.Any = this.InitOperateState(new InfStartClassGenOperateState());
        this.OperateKindList.InfEnd.Any = this.InitOperateState(new InfEndClassGenOperateState());
        this.OperateKindList.WhileStart.Any = this.InitOperateState(new WhileStartClassGenOperateState());
        this.OperateKindList.While.Any = this.InitOperateState(new WhileClassGenOperateState());
        this.OperateKindList.WhileEnd.Any = this.InitOperateState(new WhileEndClassGenOperateState());
        this.OperateKindList.ItemGet.Any = this.InitOperateState(new GetClassGenOperateState());
        this.OperateKindList.SetMark.Any = this.InitOperateState(new SetMarkClassGenOperateState());
        this.OperateKindList.Call.Any = this.InitOperateState(new CallClassGenOperateState());
        this.OperateKindList.Var.Any = this.InitOperateState(new VarClassGenOperateState());
        this.OperateKindList.VarMark.Any = this.InitOperateState(new VarMarkClassGenOperateState());
        this.OperateKindList.New.Any = this.InitOperateState(new NewClassGenOperateState());
        this.OperateKindList.Share.Any = this.InitOperateState(new ShareClassGenOperateState());
        this.OperateKindList.Cast.Any = this.InitOperateState(new CastClassGenOperateState());
        this.OperateKindList.ItemThis.Any = this.InitOperateState(new ThisClassGenOperateState());
        this.OperateKindList.Base.Any = this.InitOperateState(new BaseClassGenOperateState());
        this.OperateKindList.Null.Any = this.InitOperateState(new NullClassGenOperateState());
        this.OperateKindList.Same.Any = this.InitOperateState(new SameClassGenOperateState());
        this.OperateKindList.Less.Any = this.InitOperateState(new LessClassGenOperateState());
        this.OperateKindList.And.Any = this.InitOperateState(new AndClassGenOperateState());
        this.OperateKindList.Orn.Any = this.InitOperateState(new OrnClassGenOperateState());
        this.OperateKindList.Not.Any = this.InitOperateState(new NotClassGenOperateState());
        this.OperateKindList.Add.Any = this.InitOperateState(new AddClassGenOperateState());
        this.OperateKindList.Sub.Any = this.InitOperateState(new SubClassGenOperateState());
        this.OperateKindList.Mul.Any = this.InitOperateState(new MulClassGenOperateState());
        this.OperateKindList.Div.Any = this.InitOperateState(new DivClassGenOperateState());
        this.OperateKindList.SignLess.Any = this.InitOperateState(new SignLessClassGenOperateState());
        this.OperateKindList.SignMul.Any = this.InitOperateState(new SignMulClassGenOperateState());
        this.OperateKindList.SignDiv.Any = this.InitOperateState(new SignDivClassGenOperateState());
        this.OperateKindList.BitAnd.Any = this.InitOperateState(new BitAndClassGenOperateState());
        this.OperateKindList.BitOrn.Any = this.InitOperateState(new BitOrnClassGenOperateState());
        this.OperateKindList.BitNot.Any = this.InitOperateState(new BitNotClassGenOperateState());
        this.OperateKindList.BitLite.Any = this.InitOperateState(new BitLiteClassGenOperateState());
        this.OperateKindList.BitRite.Any = this.InitOperateState(new BitRiteClassGenOperateState());
        this.OperateKindList.BitSignRite.Any = this.InitOperateState(new BitSignRiteClassGenOperateState());
        this.OperateKindList.BoolValue.Any = this.InitOperateState(new BoolValueClassGenOperateState());
        this.OperateKindList.IntValue.Any = this.InitOperateState(new IntValueClassGenOperateState());
        this.OperateKindList.StringValue.Any = this.InitOperateState(new StringValueClassGenOperateState());

        return true;
    }
}