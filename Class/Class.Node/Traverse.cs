namespace Class.Node;

public class Traverse : Any
{
    public override bool Init()
    {
        Array array;
        array = new Array();
        array.Count = 0;
        array.Init();

        this.Iter = array.IterCreate();
        return true;
    }

    protected virtual Iter Iter { get; set; }

    public virtual bool ExecuteClass(Class varClass)
    {
        if (varClass == null)
        {
            return true;
        }
        this.ExecuteNode(varClass);

        this.ExecuteClassName(varClass.Name);
        this.ExecuteClassName(varClass.Base);
        this.ExecutePart(varClass.Member);
        return true;
    }

    public virtual bool ExecutePart(Part part)
    {
        if (part == null)
        {
            return true;
        }
        this.ExecuteNode(part);

        Iter iter;
        iter = this.Iter;
        part.Value.IterSet(iter);
        while (iter.Next())
        {
            Comp comp;
            comp = (Comp)iter.Value;
            this.ExecuteComp(comp);
        }
        return true;
    }

    public virtual bool ExecuteComp(Comp comp)
    {
        if (comp == null)
        {
            return true;
        }

        if (comp is Field)
        {
            this.ExecuteField((Field)comp);
        }
        if (comp is Maide)
        {
            this.ExecuteMaide((Maide)comp);
        }
        return true;
    }

    public virtual bool ExecuteField(Field field)
    {
        if (field == null)
        {
            return true;
        }
        this.ExecuteNode(field);

        this.ExecuteClassName(field.Class);
        this.ExecuteFieldName(field.Name);
        this.ExecuteCount(field.Count);
        this.ExecuteState(field.Get);
        this.ExecuteState(field.Set);
        return true;
    }

    public virtual bool ExecuteMaide(Maide maide)
    {
        if (maide == null)
        {
            return true;
        }
        this.ExecuteNode(maide);

        this.ExecuteClassName(maide.Class);
        this.ExecuteMaideName(maide.Name);
        this.ExecuteCount(maide.Count);
        this.ExecuteParam(maide.Param);
        this.ExecuteState(maide.Call);
        return true;
    }

    public virtual bool ExecuteVar(Var varVar)
    {
        if (varVar == null)
        {
            return true;
        }
        this.ExecuteNode(varVar);

        this.ExecuteClassName(varVar.Class);
        this.ExecuteVarName(varVar.Name);
        return true;
    }

    public virtual bool ExecuteParam(Param param)
    {
        if (param == null)
        {
            return true;
        }
        this.ExecuteNode(param);

        Iter iter;
        iter = this.Iter;
        param.Value.IterSet(iter);
        while (iter.Next())
        {
            Var varVar;
            varVar = (Var)iter.Value;
            this.ExecuteVar(varVar);
        }
        return true;
    }

    public virtual bool ExecuteArgue(Argue argue)
    {
        if (argue == null)
        {
            return true;
        }
        this.ExecuteNode(argue);

        Iter iter;
        iter = this.Iter;
        argue.Value.IterSet(iter);
        while (iter.Next())
        {
            Operate operate;
            operate = (Operate)iter.Value;
            this.ExecuteOperate(operate);
        }
        return true;
    }

    public virtual bool ExecuteTarget(Target target)
    {
        if (target == null)
        {
            return true;
        }

        if (target is VarTarget)
        {
            this.ExecuteVarTarget((VarTarget)target);
        }
        if (target is SetTarget)
        {
            this.ExecuteSetTarget((SetTarget)target);
        }
        return true;
    }

    public virtual bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (varTarget == null)
        {
            return true;
        }
        this.ExecuteNode(varTarget);

        this.ExecuteVarName(varTarget.Var);
        return true;
    }

    public virtual bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (setTarget == null)
        {
            return true;
        }
        this.ExecuteNode(setTarget);

        this.ExecuteOperate(setTarget.This);
        this.ExecuteFieldName(setTarget.Field);
        return true;
    }

    public virtual bool ExecuteValue(Value value)
    {
        if (value == null)
        {
            return true;
        }

        if (value is BoolValue)
        {
            this.ExecuteBoolValue((BoolValue)value);
        }
        if (value is IntValue)
        {
            this.ExecuteIntValue((IntValue)value);
        }
        if (value is IntHexValue)
        {
            this.ExecuteIntHexValue((IntHexValue)value);
        }
        if (value is IntSignValue)
        {
            this.ExecuteIntSignValue((IntSignValue)value);
        }
        if (value is IntSignHexValue)
        {
            this.ExecuteIntSignHexValue((IntSignHexValue)value);
        }
        if (value is StringValue)
        {
            this.ExecuteStringValue((StringValue)value);
        }
        return true;
    }

    public virtual bool ExecuteBoolValue(BoolValue boolValue)
    {
        if (boolValue == null)
        {
            return true;
        }
        this.ExecuteNode(boolValue);
        return true;
    }

    public virtual bool ExecuteIntValue(IntValue intValue)
    {
        if (intValue == null)
        {
            return true;
        }
        this.ExecuteNode(intValue);
        return true;
    }

    public virtual bool ExecuteIntHexValue(IntHexValue intHexValue)
    {
        if (intHexValue == null)
        {
            return true;
        }
        this.ExecuteNode(intHexValue);
        return true;
    }

    public virtual bool ExecuteIntSignValue(IntSignValue intSignValue)
    {
        if (intSignValue == null)
        {
            return true;
        }
        this.ExecuteNode(intSignValue);
        return true;
    }

    public virtual bool ExecuteIntSignHexValue(IntSignHexValue intSignHexValue)
    {
        if (intSignHexValue == null)
        {
            return true;
        }
        this.ExecuteNode(intSignHexValue);
        return true;
    }

    public virtual bool ExecuteStringValue(StringValue stringValue)
    {
        if (stringValue == null)
        {
            return true;
        }
        this.ExecuteNode(stringValue);
        return true;
    }

    public virtual bool ExecuteCount(Count count)
    {
        if (count == null)
        {
            return true;
        }

        if (count is PrudateCount)
        {
            this.ExecutePrudateCount((PrudateCount)count);
        }
        if (count is ProbateCount)
        {
            this.ExecuteProbateCount((ProbateCount)count);
        }
        if (count is PrecateCount)
        {
            this.ExecutePrecateCount((PrecateCount)count);
        }
        if (count is PrivateCount)
        {
            this.ExecutePrivateCount((PrivateCount)count);
        }
        return true;
    }

    public virtual bool ExecutePrudateCount(PrudateCount prudateCount)
    {
        if (prudateCount == null)
        {
            return true;
        }
        this.ExecuteNode(prudateCount);
        return true;
    }

    public virtual bool ExecuteProbateCount(ProbateCount probateCount)
    {
        if (probateCount == null)
        {
            return true;
        }
        this.ExecuteNode(probateCount);
        return true;
    }

    public virtual bool ExecutePrecateCount(PrecateCount precateCount)
    {
        if (precateCount == null)
        {
            return true;
        }
        this.ExecuteNode(precateCount);
        return true;
    }

    public virtual bool ExecutePrivateCount(PrivateCount privateCount)
    {
        if (privateCount == null)
        {
            return true;
        }
        this.ExecuteNode(privateCount);
        return true;
    }







    public virtual bool ExecuteClassName(ClassName className)
    {
        if (className == null)
        {
            return true;
        }



        this.ExecuteNode(className);



        return true;
    }






    public virtual bool ExecuteFieldName(FieldName fieldName)
    {
        if (fieldName == null)
        {
            return true;
        }




        this.ExecuteNode(fieldName);




        return true;
    }






    public virtual bool ExecuteMaideName(MaideName maideName)
    {
        if (maideName == null)
        {
            return true;
        }




        this.ExecuteNode(maideName);




        return true;
    }






    public virtual bool ExecuteVarName(VarName varName)
    {
        if (varName == null)
        {
            return true;
        }




        this.ExecuteNode(varName);




        return true;
    }






    public virtual bool ExecuteState(State state)
    {
        if (state == null)
        {
            return true;
        }





        this.ExecuteNode(state);






        Iter iter;

        iter = this.Iter;


        state.Value.IterSet(iter);



        while (iter.Next())
        {
            Execute execute;


            execute = (Execute)iter.Value;



            this.ExecuteExecute(execute);
        }




        return true;
    }






    public virtual bool ExecuteExecute(Execute execute)
    {
        if (execute == null)
        {
            return true;
        }




        if (execute is ReturnExecute)
        {
            this.ExecuteReturnExecute((ReturnExecute)execute);
        }



        if (execute is InfExecute)
        {
            this.ExecuteInfExecute((InfExecute)execute);
        }



        if (execute is WhileExecute)
        {
            this.ExecuteWhileExecute((WhileExecute)execute);
        }




        if (execute is DeclareExecute)
        {
            this.ExecuteDeclareExecute((DeclareExecute)execute);
        }




        if (execute is AssignExecute)
        {
            this.ExecuteAssignExecute((AssignExecute)execute);
        }




        if (execute is OperateExecute)
        {
            this.ExecuteOperateExecute((OperateExecute)execute);
        }



        return true;
    }







    public virtual bool ExecuteInfExecute(InfExecute infExecute)
    {
        if (infExecute == null)
        {
            return true;
        }





        this.ExecuteNode(infExecute);





        this.ExecuteOperate(infExecute.Cond);





        this.ExecuteState(infExecute.Then);





        return true;
    }






    public virtual bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        if (whileExecute == null)
        {
            return true;
        }





        this.ExecuteNode(whileExecute);





        this.ExecuteOperate(whileExecute.Cond);





        this.ExecuteState(whileExecute.Loop);





        return true;
    }







    public virtual bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        if (returnExecute == null)
        {
            return true;
        }





        this.ExecuteNode(returnExecute);





        this.ExecuteOperate(returnExecute.Result);





        return true;
    }







    public virtual bool ExecuteDeclareExecute(DeclareExecute declareExecute)
    {
        if (declareExecute == null)
        {
            return true;
        }




        this.ExecuteNode(declareExecute);




        this.ExecuteVar(declareExecute.Var);




        return true;
    }






    public virtual bool ExecuteAssignExecute(AssignExecute assignExecute)
    {
        if (assignExecute == null)
        {
            return true;
        }





        this.ExecuteNode(assignExecute);





        this.ExecuteTarget(assignExecute.Target);




        this.ExecuteOperate(assignExecute.Value);




        return true;
    }







    public virtual bool ExecuteOperateExecute(OperateExecute operateExecute)
    {
        if (operateExecute == null)
        {
            return true;
        }




        this.ExecuteNode(operateExecute);




        this.ExecuteOperate(operateExecute.Operate);




        return true;
    }






    public virtual bool ExecuteOperate(Operate operate)
    {
        if (operate == null)
        {
            return true;
        }





        if (operate is GetOperate)
        {
            this.ExecuteGetOperate((GetOperate)operate);
        }



        if (operate is CallOperate)
        {
            this.ExecuteCallOperate((CallOperate)operate);
        }



        if (operate is VarOperate)
        {
            this.ExecuteVarOperate((VarOperate)operate);
        }



        if (operate is ValueOperate)
        {
            this.ExecuteValueOperate((ValueOperate)operate);
        }



        if (operate is ThisOperate)
        {
            this.ExecuteThisOperate((ThisOperate)operate);
        }



        if (operate is BaseOperate)
        {
            this.ExecuteBaseOperate((BaseOperate)operate);
        }



        if (operate is NullOperate)
        {
            this.ExecuteNullOperate((NullOperate)operate);
        }



        if (operate is NewOperate)
        {
            this.ExecuteNewOperate((NewOperate)operate);
        }



        if (operate is ShareOperate)
        {
            this.ExecuteShareOperate((ShareOperate)operate);
        }



        if (operate is CastOperate)
        {
            this.ExecuteCastOperate((CastOperate)operate);
        }



        if (operate is BracketOperate)
        {
            this.ExecuteBracketOperate((BracketOperate)operate);
        }



        if (operate is AndOperate)
        {
            this.ExecuteAndOperate((AndOperate)operate);
        }



        if (operate is OrnOperate)
        {
            this.ExecuteOrnOperate((OrnOperate)operate);
        }



        if (operate is NotOperate)
        {
            this.ExecuteNotOperate((NotOperate)operate);
        }



        if (operate is AddOperate)
        {
            this.ExecuteAddOperate((AddOperate)operate);
        }



        if (operate is SubOperate)
        {
            this.ExecuteSubOperate((SubOperate)operate);
        }



        if (operate is MulOperate)
        {
            this.ExecuteMulOperate((MulOperate)operate);
        }



        if (operate is DivOperate)
        {
            this.ExecuteDivOperate((DivOperate)operate);
        }



        if (operate is LessOperate)
        {
            this.ExecuteLessOperate((LessOperate)operate);
        }



        if (operate is BitAndOperate)
        {
            
        }



        if (operate is BitOrnOperate)
        {

        }



        if (operate is BitNotOperate)
        {

        }



        if (operate is BitLeftOperate)
        {

        }



        if (operate is BitRightOperate)
        {

        }



        if (operate is EqualOperate)
        {
            this.ExecuteEqualOperate((EqualOperate)operate);
        }
        



        return true;
    }






    public virtual bool ExecuteGetOperate(GetOperate getOperate)
    {
        if (getOperate == null)
        {
            return true;
        }





        this.ExecuteNode(getOperate);





        this.ExecuteOperate(getOperate.This);





        this.ExecuteFieldName(getOperate.Field);





        return true;
    }






    public virtual bool ExecuteCallOperate(CallOperate callOperate)
    {
        if (callOperate == null)
        {
            return true;
        }





        this.ExecuteNode(callOperate);





        this.ExecuteOperate(callOperate.This);




        this.ExecuteMaideName(callOperate.Maide);




        this.ExecuteArgue(callOperate.Argue);





        return true;
    }







    public virtual bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            return true;
        }




        this.ExecuteNode(thisOperate);




        return true;
    }





    public virtual bool ExecuteBaseOperate(BaseOperate baseOperate)
    {
        if (baseOperate == null)
        {
            return true;
        }




        this.ExecuteNode(baseOperate);




        return true;
    }






    public virtual bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            return true;
        }





        this.ExecuteNode(nullOperate);





        return true;
    }







    public virtual bool ExecuteVarOperate(VarOperate varOperate)
    {
        if (varOperate == null)
        {
            return true;
        }





        this.ExecuteNode(varOperate);





        this.ExecuteVarName(varOperate.Var);





        return true;
    }







    public virtual bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        if (valueOperate == null)
        {
            return true;
        }





        this.ExecuteNode(valueOperate);





        this.ExecuteValue(valueOperate.Value);





        return true;
    }





    public virtual bool ExecuteNewOperate(NewOperate newOperate)
    {
        if (newOperate == null)
        {
            return true;
        }




        this.ExecuteNode(newOperate);

        


        this.ExecuteClassName(newOperate.Class);



        return true;
    }





    public virtual bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        if (shareOperate == null)
        {
            return true;
        }




        this.ExecuteNode(shareOperate);

            


        this.ExecuteClassName(shareOperate.Class);



        return true;
    }






    public virtual bool ExecuteCastOperate(CastOperate castOperate)
    {
        if (castOperate == null)
        {
            return true;
        }





        this.ExecuteNode(castOperate);





        this.ExecuteClassName(castOperate.Class);




        this.ExecuteOperate(castOperate.Any);





        return true;
    }






    public virtual bool ExecuteBracketOperate(BracketOperate bracketOperate)
    {
        if (bracketOperate == null)
        {
            return true;
        }




        this.ExecuteNode(bracketOperate);

            


        this.ExecuteOperate(bracketOperate.Operate);



        return true;
    }






    public virtual bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        if (equalOperate == null)
        {
            return true;
        }





        this.ExecuteNode(equalOperate);





        this.ExecuteOperate(equalOperate.Left);





        this.ExecuteOperate(equalOperate.Right);





        return true;
    }






    public virtual bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            return true;
        }




        this.ExecuteNode(andOperate);





        this.ExecuteOperate(andOperate.Left);




        this.ExecuteOperate(andOperate.Right);




        return true;
    }





    public virtual bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            return true;
        }




        this.ExecuteNode(ornOperate);




        this.ExecuteOperate(ornOperate.Left);




        this.ExecuteOperate(ornOperate.Right);




        return true;
    }





    public virtual bool ExecuteNotOperate(NotOperate notOperate)
    {
        if (notOperate == null)
        {
            return true;
        }




        this.ExecuteNode(notOperate);




        this.ExecuteOperate(notOperate.Value);




        return true;
    }





    public virtual bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            return true;
        }




        this.ExecuteNode(addOperate);




        this.ExecuteOperate(addOperate.Left);




        this.ExecuteOperate(addOperate.Right);




        return true;
    }






    public virtual bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            return true;
        }




        this.ExecuteNode(subOperate);




        this.ExecuteOperate(subOperate.Left);




        this.ExecuteOperate(subOperate.Right);




        return true;
    }






    public virtual bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            return true;
        }





        this.ExecuteNode(mulOperate);




        this.ExecuteOperate(mulOperate.Left);




        this.ExecuteOperate(mulOperate.Right);




        return true;
    }






    public virtual bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            return true;
        }





        this.ExecuteNode(divOperate);





        this.ExecuteOperate(divOperate.Left);





        this.ExecuteOperate(divOperate.Right);




        return true;
    }







    public virtual bool ExecuteLessOperate(LessOperate lessOperate)
    {
        if (lessOperate == null)
        {
            return true;
        }




        this.ExecuteNode(lessOperate);




        this.ExecuteOperate(lessOperate.Left);




        this.ExecuteOperate(lessOperate.Right);





        return true;
    }







    public virtual bool ExecuteSignMulOperate(SignMulOperate signMulOperate)
    {
        if (signMulOperate == null)
        {
            return true;
        }



        this.ExecuteNode(signMulOperate);



        this.ExecuteOperate(signMulOperate.Left);


        this.ExecuteOperate(signMulOperate.Right);




        return true;
    }






    public virtual bool ExecuteSignDivOperate(SignDivOperate signDivOperate)
    {
        if (signDivOperate == null)
        {
            return true;
        }



        this.ExecuteNode(signDivOperate);



        this.ExecuteOperate(signDivOperate.Left);


        this.ExecuteOperate(signDivOperate.Right);




        return true;
    }






    public virtual bool ExecuteSignLessOperate(SignLessOperate signLessOperate)
    {
        if (signLessOperate == null)
        {
            return true;
        }



        this.ExecuteNode(signLessOperate);



        this.ExecuteOperate(signLessOperate.Left);


        this.ExecuteOperate(signLessOperate.Right);




        return true;
    }







    public virtual bool ExecuteBitAndOperate(BitAndOperate bitAndOperate)
    {
        if (bitAndOperate == null)
        {
            return true;
        }




        this.ExecuteNode(bitAndOperate);





        this.ExecuteOperate(bitAndOperate.Left);




        this.ExecuteOperate(bitAndOperate.Right);




        return true;
    }





    public virtual bool ExecuteBitOrnOperate(BitOrnOperate bitOrnOperate)
    {
        if (bitOrnOperate == null)
        {
            return true;
        }




        this.ExecuteNode(bitOrnOperate);




        this.ExecuteOperate(bitOrnOperate.Left);




        this.ExecuteOperate(bitOrnOperate.Right);




        return true;
    }





    public virtual bool ExecuteBitNotOperate(BitNotOperate bitNotOperate)
    {
        if (bitNotOperate == null)
        {
            return true;
        }




        this.ExecuteNode(bitNotOperate);




        this.ExecuteOperate(bitNotOperate.Value);




        return true;
    }





    public virtual bool ExecuteBitLeftOperate(BitLeftOperate bitLeftOperate)
    {
        if (bitLeftOperate == null)
        {
            return true;
        }




        this.ExecuteNode(bitLeftOperate);




        this.ExecuteOperate(bitLeftOperate.Value);




        this.ExecuteOperate(bitLeftOperate.Count);




        return true;
    }





    public virtual bool ExecuteBitRightOperate(BitRightOperate bitRightOperate)
    {
        if (bitRightOperate == null)
        {
            return true;
        }




        this.ExecuteNode(bitRightOperate);




        this.ExecuteOperate(bitRightOperate.Value);




        this.ExecuteOperate(bitRightOperate.Count);




        return true;
    }









    protected virtual bool ExecuteNode(Node node)
    {
        return true;
    }
}