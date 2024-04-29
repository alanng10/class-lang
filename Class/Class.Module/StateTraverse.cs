namespace Class.Module;

public class StateTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.VarStack = new Stack();
        this.VarStack.Init();

        this.System = this.Create.SystemClass;
        this.NullClass = this.Create.NullClass;
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual SystemClass System { get; set; }
    protected virtual ClassClass NullClass { get; set; }
    protected virtual ClassClass ThisClass { get; set; }
    protected virtual ClassClass ThisResultClass { get; set; }
    protected virtual Table StateVar { get; set; }
    protected virtual Stack VarStack { get; set; }

    public override bool ExecuteClass(NodeClass varClass)
    {
        if (varClass == null)
        {
            return true;
        }

        this.ThisClass = this.Info(varClass).Class;

        if (this.ThisClass == null)
        {
            return true;
        }

        base.ExecuteClass(varClass);
        return true;
    }

    public override bool ExecuteField(NodeField nodeField)
    {
        if (nodeField == null)
        {
            return true;
        }

        State nodeGet;
        nodeGet = nodeField.Get;
        State nodeSet;
        nodeSet = nodeField.Set;

        Field field;
        field = this.Info(nodeField).Field;
        if (field == null)
        {
            return true;
        }

        this.FieldGet(field, nodeGet);
        this.FieldSet(field, nodeSet);
        return true;
    }

    protected bool FieldGet(Field field, State nodeGet)
    {
        if (nodeGet == null)
        {
            return true;
        }

        this.ThisResultClass = field.Class;

        this.StateVar = field.Get;

        Var dataVar;
        dataVar = new Var();
        dataVar.Init();
        dataVar.Name = "data";
        dataVar.Class = field.Class;

        Table o;
        o = this.ClassInfra.TableCreateStringCompare();
        this.ListInfra.TableAdd(o, dataVar.Name, dataVar);

        this.VarStack.Push(o);

        this.ExecuteState(nodeGet);

        this.VarStack.Pop();

        this.StateVar = null;
        this.ThisResultClass = null;
        return true;
    }

    protected virtual bool FieldSet(Field field, State nodeSet)
    {
        if (nodeSet == null)
        {
            return true;
        }

        this.ThisResultClass = this.System.Bool;

        this.StateVar = field.Set;

        Var dataVar;
        dataVar = new Var();
        dataVar.Init();
        dataVar.Name = "data";
        dataVar.Class = field.Class;

        Var valueVar;
        valueVar = new Var();
        valueVar.Init();
        valueVar.Name = "value";
        valueVar.Class = field.Class;

        Table o;
        o = this.ClassInfra.TableCreateStringCompare();

        this.ListInfra.TableAdd(o, dataVar.Name, dataVar);
        this.ListInfra.TableAdd(o, valueVar.Name, valueVar);

        this.VarStack.Push(o);

        this.ExecuteState(nodeSet);

        this.VarStack.Pop();

        this.StateVar = null;
        this.ThisResultClass = null;
        return true;
    }

    public override bool ExecuteMaide(NodeMaide nodeMaide)
    {
        if (nodeMaide == null)
        {
            return true;
        }

        Param param;
        param = nodeMaide.Param;
        State call;
        call = nodeMaide.Call;

        Maide maide;
        maide = this.Info(nodeMaide).Maide;
        if (maide == null)
        {
            return true;
        }

        this.ThisResultClass = maide.Class;

        Table o;
        o = this.ClassInfra.TableCreateStringCompare();

        this.VarTableAdd(o, maide.Param);

        this.StateVar = o;

        this.VarStack.Push(maide.Param);

        this.ExecuteState(call);

        this.VarStack.Pop();

        this.StateVar = null;
        this.ThisResultClass = null;
        return true;
    }

    public override bool ExecuteVar(NodeVar nodeVar)
    {
        if (nodeVar == null)
        {
            return true;
        }

        VarName name;
        name = nodeVar.Name;
        ClassName nodeClass;
        nodeClass = nodeVar.Class;

        string varName;
        varName = name.Value;
        string className;
        className = nodeClass.Value;

        if (this.StateVar.Contain(varName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);
            return true;
        }

        ClassClass varClass;
        varClass = this.Class(className);
        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeVar);
            return true;
        }

        Var a;
        a = new Var();
        a.Init();
        a.Name = varName;
        a.Class = varClass;
        a.Any = nodeVar;

        Table oo;
        oo = (Table)this.VarStack.Top;

        this.ListInfra.TableAdd(oo, a.Name, a);
        this.ListInfra.TableAdd(this.StateVar, a.Name, a);

        this.Info(nodeVar).Var = a;
        return true;
    }

    public override bool ExecuteState(State state)
    {
        if (state == null)
        {
            return true;
        }

        Table h;
        h = this.ClassInfra.TableCreateStringCompare();

        this.VarStack.Push(h);

        base.ExecuteState(state);

        this.VarStack.Pop();
        return true;
    }

    public override bool ExecuteInfExecute(InfExecute infExecute)
    {
        if (infExecute == null)
        {
            return true;
        }

        Operate cond;
        cond = infExecute.Cond;
        State then;
        then = infExecute.Then;

        base.ExecuteInfExecute(infExecute);

        this.ExecuteCondBodyExecute(infExecute, cond);
        return true;
    }

    public override bool ExecuteWhileExecute(WhileExecute whileExecute)
    {
        if (whileExecute == null)
        {
            return true;
        }

        Operate cond;
        cond = whileExecute.Cond;
        State loop;
        loop = whileExecute.Loop;

        base.ExecuteWhileExecute(whileExecute);

        this.ExecuteCondBodyExecute(whileExecute, cond);
        return true;
    }

    public override bool ExecuteReturnExecute(ReturnExecute returnExecute)
    {
        if (returnExecute == null)
        {
            return true;
        }

        Operate result;
        result = returnExecute.Result;

        base.ExecuteReturnExecute(returnExecute);

        ClassClass resultClass;
        resultClass = null;
        if (!(result == null))
        {
            resultClass = this.Info(result).OperateClass;
        }

        if (resultClass == null)
        {
            this.Error(this.ErrorKind.ResultUndefined, returnExecute);
        }

        if (!(resultClass == null))
        {
            if (!this.CheckClass(resultClass, this.ThisResultClass))
            {
                this.Error(this.ErrorKind.ResultUnassignable, returnExecute);
            }
        }
        return true;
    }

    public override bool ExecuteAssignExecute(AssignExecute assignExecute)
    {
        if (assignExecute == null)
        {
            return true;
        }

        Target target;            
        target = assignExecute.Target;
        Operate value;
        value = assignExecute.Value;

        base.ExecuteAssignExecute(assignExecute);

        ClassClass targetClass;
        targetClass = null;
        if (!(target == null))
        {
            targetClass = this.Info(target).TargetClass;
        }

        ClassClass valueClass;
        valueClass = null;
        if (!(value == null))
        {
            valueClass = this.Info(value).OperateClass;
        }

        if (targetClass == null)
        {
            this.Error(this.ErrorKind.TargetUndefined, assignExecute);
        }

        if (valueClass == null)
        {
            this.Error(this.ErrorKind.ValueUndefined, assignExecute);
        }

        if (!(targetClass == null) & !(valueClass == null))
        {
            if (!this.CheckClass(valueClass, targetClass))
            {
                this.Error(this.ErrorKind.ValueUnassignable, assignExecute);
            }
        }
        return true;
    }

    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (varTarget == null)
        {
            return true;
        }

        VarName name;
        name = varTarget.Var;

        string varName;
        varName = name.Value;

        ClassClass varClass;
        varClass = this.ExecuteVarNameNode(varTarget, varName);

        this.Info(varTarget).TargetClass = varClass;
        return true;
    }

    public override bool ExecuteSetTarget(SetTarget setTarget)
    {
        if (setTarget == null)
        {
            return true;
        }

        Operate varThis;
        varThis = setTarget.This;
        FieldName nodeField;
        nodeField = setTarget.Field;

        base.ExecuteSetTarget(setTarget);

        Field field;
        field = this.ExecuteThisFieldNode(setTarget, varThis, nodeField);

        ClassClass fieldClass;
        fieldClass = null;
        if (!(field == null))
        {
            fieldClass = field.Class;
        }

        this.Info(setTarget).SetField = field;
        this.Info(setTarget).TargetClass = fieldClass;
        return true;
    }

    public override bool ExecuteGetOperate(GetOperate getOperate)
    {
        if (getOperate == null)
        {
            return true;
        }

        Operate varThis;
        varThis = getOperate.This;
        FieldName nodeField;
        nodeField = getOperate.Field;

        base.ExecuteGetOperate(getOperate);

        Field field;
        field = this.ExecuteThisFieldNode(getOperate, varThis, nodeField);

        ClassClass fieldClass;
        fieldClass = null;
        if (!(field == null))
        {
            fieldClass = field.Class;
        }

        this.Info(getOperate).GetField = field;
        this.Info(getOperate).OperateClass = fieldClass;
        return true;
    }

    public override bool ExecuteCallOperate(CallOperate callOperate)
    {
        if (callOperate == null)
        {
            return true;
        }

        Operate varThis;
        varThis = callOperate.This;
        MaideName nodeMaide;
        nodeMaide = callOperate.Maide;
        Argue argue;
        argue = callOperate.Argue;

        base.ExecuteCallOperate(callOperate);

        ClassClass thisClass;
        thisClass = null;
        if (!(varThis == null))
        {
            thisClass = this.Info(varThis).OperateClass;
        }

        string maideName;
        maideName = null;
        if (!(nodeMaide == null))
        {
            maideName = nodeMaide.Value;
        }

        if (thisClass == null)
        {
            this.Error(this.ErrorKind.ThisUndefined, callOperate);
        }

        Maide maide;
        maide = null;

        if (!(thisClass == null))
        {
            if (!(maideName == null))
            {
                maide = this.Method(thisClass, maideName);
            }
            if (maide == null)
            {
                this.Error(this.ErrorKind.MaideUndefined, callOperate);
            }
        }

        if (!(maide == null))
        {
            if (!this.ArgueMatch(maide, argue))
            {
                this.Error(this.ErrorKind.ArgueUnassignable, callOperate);
            }
        }

        ClassClass operateClass;
        operateClass = null;
        if (!(maide == null))
        {
            operateClass = maide.Class;
        }

        this.Info(callOperate).CallMaide = maide;
        this.Info(callOperate).OperateClass = operateClass;
        return true;
    }

    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            return true;
        }

        this.Info(thisOperate).OperateClass = this.ThisClass;
        return true;
    }


    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            return true;
        }

        this.Info(nullOperate).OperateClass = this.NullClass;
        return true;
    }


    public override bool ExecuteNewOperate(NewOperate newOperate)
    {
        if (newOperate == null)
        {
            return true;
        }

        ClassName nodeClass;
        nodeClass = newOperate.Class;

        string className;
        className = nodeClass.Value;

        ClassClass varClass;
        varClass = this.Class(className);

        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, newOperate);
        }

        this.Info(newOperate).OperateClass = varClass;
        return true;
    }

    public override bool ExecuteShareOperate(ShareOperate shareOperate)
    {
        if (shareOperate == null)
        {
            return true;
        }

        ClassName nodeClass;
        nodeClass = shareOperate.Class;

        string className;
        className = nodeClass.Value;

        ClassClass varClass;
        varClass = this.Class(className);

        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, shareOperate);
        }

        this.Info(shareOperate).OperateClass = varClass;
        return true;
    }

    public override bool ExecuteCastOperate(CastOperate castOperate)
    {
        if (castOperate == null)
        {
            return true;
        }

        ClassName nodeClass;
        nodeClass = castOperate.Class;
        Operate any;
        any = castOperate.Any;

        base.ExecuteCastOperate(castOperate);

        ClassClass anyClass;
        anyClass = null;
        if (!(any == null))
        {
            anyClass = this.Info(any).OperateClass;
        }

        if (anyClass == null)
        {
            this.Error(this.ErrorKind.AnyUndefined, castOperate);
        }

        string className;
        className = null;
        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }

        ClassClass varClass;
        varClass = null;
        if (!(className == null))
        {
            varClass = this.Class(className);
        }

        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, castOperate);
        }

        this.Info(castOperate).OperateClass = varClass;
        return true;
    }



    public override bool ExecuteVarOperate(VarOperate varOperate)
    {
        if (varOperate == null)
        {
            return true;
        }

        VarName name;
        name = varOperate.Var;

        string varName;
        varName = name.Value;

        ClassClass varClass;
        varClass = this.ExecuteVarNameNode(varOperate, varName);

        this.Info(varOperate).OperateClass = varClass;
        return true;
    }



    public override bool ExecuteValueOperate(ValueOperate valueOperate)
    {
        if (valueOperate == null)
        {
            return true;
        }





        Value value;


        value = valueOperate.Value;





        base.ExecuteValueOperate(valueOperate);





        ClassClass valueClass;


        valueClass = null;




        if (!(value == null))
        {
            if (value is BoolValue)
            {
                valueClass = this.System.Bool;
            }

            if (value is IntValue)
            {
                valueClass = this.System.Int;
            }

            if (value is StringValue)
            {
                valueClass = this.System.String;
            }
        }




        this.Info(valueOperate).OperateClass = valueClass;




        return true;
    }




    public override bool ExecuteBracketOperate(BracketOperate bracketOperate)
    {
        if (bracketOperate == null)
        {
            return true;
        }





        Operate operate;

        operate = bracketOperate.Operate;





        base.ExecuteBracketOperate(bracketOperate);





        ClassClass operateClass;

        operateClass = null;



        if (!(operate == null))
        {
            operateClass = this.Info(operate).OperateClass;
        }



            

        this.Info(bracketOperate).OperateClass = operateClass;




        return true;
    }







    public override bool ExecuteAndOperate(AndOperate andOperate)
    {
        if (andOperate == null)
        {
            return true;
        }





        Operate left;
            
        left = andOperate.Left;



        Operate right;
            
        right = andOperate.Right;





        base.ExecuteAndOperate(andOperate);





        this.ExecuteTwoOperandOperate(andOperate, left, right, this.System.Bool, this.System.Bool);





        return true;
    }
    




    public override bool ExecuteOrnOperate(OrnOperate ornOperate)
    {
        if (ornOperate == null)
        {
            return true;
        }





        Operate left;

        left = ornOperate.Left;



        Operate right;

        right = ornOperate.Right;





        base.ExecuteOrnOperate(ornOperate);





        this.ExecuteTwoOperandOperate(ornOperate, left, right, this.System.Bool, this.System.Bool);





        return true;
    }





    public override bool ExecuteNotOperate(NotOperate notOperate)
    {
        if (notOperate == null)
        {
            return true;
        }





        Operate value;

        value = notOperate.Value;





        base.ExecuteNotOperate(notOperate);





        ClassClass valueClass;

        valueClass = null;



        if (!(value == null))
        {
            valueClass = this.Info(value).OperateClass;
        }





        if (valueClass == null)
        {
            this.Error(this.ErrorKind.OperandUndefined, notOperate);
        }




        if (!(valueClass == null))
        {
            if (!this.CheckClass(valueClass, this.System.Bool))
            {
                this.Error(this.ErrorKind.OperandUnassignable, notOperate);
            }
        }


            

        this.Info(notOperate).OperateClass = this.System.Bool;




        return true;
    }






    public override bool ExecuteAddOperate(AddOperate addOperate)
    {
        if (addOperate == null)
        {
            return true;
        }





        Operate left;

        left = addOperate.Left;



        Operate right;

        right = addOperate.Right;





        base.ExecuteAddOperate(addOperate);





        this.ExecuteTwoOperandOperate(addOperate, left, right, this.System.Int, this.System.Int);





        return true;
    }






    public override bool ExecuteSubOperate(SubOperate subOperate)
    {
        if (subOperate == null)
        {
            return true;
        }





        Operate left;

        left = subOperate.Left;



        Operate right;

        right = subOperate.Right;





        base.ExecuteSubOperate(subOperate);





        this.ExecuteTwoOperandOperate(subOperate, left, right, this.System.Int, this.System.Int);





        return true;
    }





    public override bool ExecuteMulOperate(MulOperate mulOperate)
    {
        if (mulOperate == null)
        {
            return true;
        }





        Operate left;

        left = mulOperate.Left;



        Operate right;

        right = mulOperate.Right;





        base.ExecuteMulOperate(mulOperate);





        this.ExecuteTwoOperandOperate(mulOperate, left, right, this.System.Int, this.System.Int);





        return true;
    }





    public override bool ExecuteDivOperate(DivOperate divOperate)
    {
        if (divOperate == null)
        {
            return true;
        }





        Operate left;

        left = divOperate.Left;



        Operate right;

        right = divOperate.Right;





        base.ExecuteDivOperate(divOperate);





        this.ExecuteTwoOperandOperate(divOperate, left, right, this.System.Int, this.System.Int);





        return true;
    }






    public override bool ExecuteLessOperate(LessOperate lessOperate)
    {
        if (lessOperate == null)
        {
            return true;
        }





        Operate left;

        left = lessOperate.Left;



        Operate right;

        right = lessOperate.Right;





        base.ExecuteLessOperate(lessOperate);





        this.ExecuteTwoOperandOperate(lessOperate, left, right, this.System.Bool, this.System.Int);





        return true;
    }






    public override bool ExecuteEqualOperate(EqualOperate equalOperate)
    {
        if (equalOperate == null)
        {
            return true;
        }





        Operate left;

        left = equalOperate.Left;




        Operate right;

        right = equalOperate.Right;




        base.ExecuteEqualOperate(equalOperate);





        ClassClass leftClass;

        leftClass = null;



        if (!(left == null))
        {
            leftClass = this.Info(left).OperateClass;
        }




        ClassClass rightClass;

        rightClass = null;



        if (!(right == null))
        {
            rightClass = this.Info(right).OperateClass;
        }







        bool hasOperandUndefined;



        hasOperandUndefined = false;





        if (leftClass == null)
        {
            hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, equalOperate, hasOperandUndefined);
        }





        if (rightClass == null)
        {
            hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, equalOperate, hasOperandUndefined);
        }



        


        this.Info(equalOperate).OperateClass = this.System.Bool;




        return true;
    }








    protected virtual bool ExecuteTwoOperandOperate(Operate operate, Operate left, Operate right, ClassClass resultClass, ClassClass operandClass)
    {
        ClassClass leftClass;

        leftClass = null;




        if (!(left == null))
        {
            leftClass = this.Info(left).OperateClass;
        }





        ClassClass rightClass;

        rightClass = null;




        if (!(right == null))
        {
            rightClass = this.Info(right).OperateClass;
        }






        bool hasOperandUndefined;


        hasOperandUndefined = false;





        bool hasOperandUnassignable;


        hasOperandUnassignable = false;





        if (leftClass == null)
        {
            hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, operate, hasOperandUndefined);
        }




        if (!(leftClass == null))
        {
            if (!this.CheckClass(leftClass, operandClass))
            {
                hasOperandUnassignable = this.UniqueError(this.ErrorKind.OperandUnassignable, operate, hasOperandUnassignable);
            }
        }





        if (rightClass == null)
        {
            hasOperandUndefined = this.UniqueError(this.ErrorKind.OperandUndefined, operate, hasOperandUndefined);
        }




        if (!(rightClass == null))
        {
            if (!this.CheckClass(rightClass, operandClass))
            {
                hasOperandUnassignable = this.UniqueError(this.ErrorKind.OperandUnassignable, operate, hasOperandUnassignable);
            }
        }




        this.Info(operate).OperateClass = resultClass;




        return true;
    }





















    protected virtual bool ExecuteCondBodyExecute(Execute execute, Operate cond)
    {
        ClassClass condClass;
        condClass = null;

        if (!(cond == null))
        {
            condClass = this.Info(cond).OperateClass;
        }

        if (condClass == null)
        {
            this.Error(this.ErrorKind.CondUndefined, execute);
        }

        if (!(condClass == null))
        {
            if (!this.CheckClass(condClass, this.System.Bool))
            {
                this.Error(this.ErrorKind.CondUnassignable, execute);
            }
        }
        return true;
    }







    protected virtual ClassClass ExecuteVarNameNode(NodeNode node, string name)
    {
        Var varVar;
        varVar = this.VarStackVar(name);
        if (varVar == null)
        {
            this.Error(this.ErrorKind.VarUndefined, node);
        }

        ClassClass a;
        a = null;
        if (!(varVar == null))
        {
            a = varVar.Class;
        }

        this.Info(node).Var = varVar;

        return a;
    }

    protected virtual Field ExecuteThisFieldNode(NodeNode node, Operate varThis, FieldName nodeField)
    {
        ClassClass thisClass;
        thisClass = null;
        if (!(varThis == null))
        {
            thisClass = this.Info(varThis).OperateClass;
        }

        string fieldName;
        fieldName = null;
        if (!(nodeField == null))
        {
            fieldName = nodeField.Value;
        }

        if (thisClass == null)
        {
            this.Error(this.ErrorKind.ThisUndefined, node);
        }

        Field field;
        field = null;
        if (!(thisClass == null))
        {
            if (!(fieldName == null))
            {
                field = this.Field(thisClass, fieldName);
            }
            if (field == null)
            {
                this.Error(this.ErrorKind.FieldUndefined, node);
            }
        }
        return field;
    }

    protected virtual bool CheckClass(ClassClass varClass, ClassClass requiredClass)
    {
        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass thisClass;
        thisClass = varClass;

        bool b;
        b = false;
        while (!b & !(thisClass == null))
        {
            if (thisClass == this.NullClass)
            {
                b = true;
            }
            if (thisClass == requiredClass)
            {
                b = true;
            }

            ClassClass aa;
            aa = null;
            if (!(thisClass == anyClass))
            {
                aa = thisClass.Base;
            }
            thisClass = aa;
        }
        bool a;
        a = b;
        return a;
    }

    protected virtual Field Field(ClassClass varClass, string name)
    {
        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass thisClass;
        thisClass = varClass;

        Field d;
        d = null;

        bool b;
        b = false;
        while (!b & !(thisClass == null))
        {
            if (thisClass.Maide.Contain(name))
            {
                b = true;
            }
            
            if (!b)
            {
                Field a;
                a = (Field)thisClass.Field.Get(name);
                if (!(a == null))
                {
                    d = a;
                    b = true;
                }
            }

            if (!b)
            {
                ClassClass aa;
                aa = null;
                if (!(thisClass == anyClass))
                {
                    aa = thisClass.Base;
                }
                thisClass = aa;
            }
        }

        if (d == null)
        {
            return null;
        }

        if (!this.CheckCount(varClass, d.Parent, d.Count))
        {
            return null;
        }

        return d;
    }

    protected virtual Maide Method(ClassClass varClass, string name)
    {
        ClassClass anyClass;
        anyClass = this.System.Any;

        ClassClass thisClass;
        thisClass = varClass;

        Maide d;
        d = null;

        bool b;
        b = false;
        while (!b & !(thisClass == null))
        {
            if (thisClass.Field.Contain(name))
            {
                b = true;
            }

            if (!b)
            {
                Maide a;
                a = (Maide)thisClass.Maide.Get(name);
                if (!(a == null))
                {
                    d = a;
                    b = true;
                }
            }

            if (!b)
            {
                ClassClass aa;
                aa = null;
                if (!(thisClass == anyClass))
                {
                    aa = thisClass.Base;
                }
                thisClass = aa;
            }
        }

        if (d == null)
        {
            return null;
        }

        if (!this.CheckCount(varClass, d.Parent, d.Count))
        {
            return null;
        }

        return d;
    }

    protected virtual bool CheckCount(ClassClass triggerClass, ClassClass varClass, Count count)
    {
        if (count == this.Count.Prudate)
        {
            return true;
        }

        if (count == this.Count.Probate)
        {
            if (this.Module == varClass.Module)
            {
                return true;
            }
            return false;
        }

        if (count == this.Count.Precate)
        {
            if (this.ThisClass == triggerClass)
            {
                return true;
            }
            return false;
        }

        if (count == this.Count.Private)
        {
            if (triggerClass == varClass)
            {
                if (this.ThisClass == triggerClass)
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }



    protected virtual bool ArgueMatch(Maide maide, Argue argue)
    {
        int count;
        count = maide.Param.Count;

        bool countEqual;
        countEqual = (count == argue.Value.Count);
        if (!countEqual)
        {
            return false;
        }

        Iter varIter;
        varIter = maide.Param.IterCreate();
        maide.Param.IterSet(varIter);

        Iter argueIter;
        argueIter = argue.Value.IterCreate();
        argue.Value.IterSet(argueIter);

        int i;
        i = 0;
        while (i < count)
        {
            varIter.Next();
            argueIter.Next();

            Var varVar;
            varVar = (Var)varIter.Value;

            Operate operate;
            operate = (Operate)argueIter.Value;
            if (operate == null)
            {
                return false;
            }

            ClassClass varClass;
            varClass = varVar.Class;

            ClassClass operateClass;
            operateClass = this.Info(operate).OperateClass;
            if (operateClass == null)
            {
                return false;
            }

            if (!this.CheckClass(operateClass, varClass))
            {
                return false;
            }
            i = i + 1;
        }
        return true;
    }

    protected virtual bool VarTableAdd(Table varTable, Table other)
    {
        Iter iter;
        iter = other.IterCreate();
        other.IterSet(iter);
        while (iter.Next())
        {
            Var a;
            a = (Var)iter.Value;

            this.ListInfra.TableAdd(varTable, a.Name, a);
        }
        return true;
    }

    protected virtual Var VarStackVar(string name)
    {
        Iter iter;
        iter = this.VarStack.IterCreate();
        this.VarStack.IterSet(iter);

        while (iter.Next())
        {
            Table varTable;
            varTable = (Table)iter.Value;

            Var varVar;
            varVar = (Var)varTable.Get(name);
            if (!(varVar == null))
            {
                return varVar;
            }
        }
        return null;
    }
}