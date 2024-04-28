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






    private bool FieldSet(Field field, State nodeSet)
    {
        if (nodeSet == null)
        {
            return true;
        }






        this.ThisResultClass = this.System.Bool;





        this.StateVar = field.Set;








        Table o;


        o = new Table();


        o.Compare = new StringCompare();


        o.Compare.Init();


        o.Init();





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





        this.VarMapAdd(o, dataVar);




        this.VarMapAdd(o, valueVar);








        this.VarStack.Push(o);




        this.ExecuteState(nodeSet);




        this.VarStack.Pop();






        this.StateVar = null;





        this.ThisResultClass = null;




        return true;
    }



        


    public override bool ExecuteMaide(NodeMaide nodeMethod)
    {
        if (nodeMethod == null)
        {
            return true;
        }





        Param varParams;


        varParams = nodeMethod.Param;





        State call;


        call = nodeMethod.Call;






        Maide method;


        method = this.Info(nodeMethod).Maide;




        if (method == null)
        {
            return true;
        }





        this.ThisResultClass = method.Class;





        this.StateVar = method.Call;







        Table o;


        o = new Table();


        o.Compare = new StringCompare();


        o.Compare.Init();


        o.Init();







        this.VarStack.Push(o);





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


        className = null;



        if (!(nodeClass == null))
        {
            className = nodeClass.Value;
        }






        if (this.StateVar.Contain(varName))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeVar);


            return true;
        }





        ClassClass varClass;


        varClass = null;




        if (!(className == null))
        {
            varClass = this.Class(className);
        }

        


        if (varClass == null)
        {
            this.Error(this.ErrorKind.ClassUndefined, nodeVar);


            return true;
        }





        Var varVar;


        varVar = new Var();


        varVar.Name = varName;


        varVar.Class = varClass;


        varVar.Any = nodeVar;






        this.VarMapAdd((Table)this.VarStack.Top, varVar);





        this.VarMapAdd(this.StateVar, varVar);
        




        this.Info(nodeVar).Var = varVar;




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








    public override bool ExecuteThisOperate(ThisOperate thisOperate)
    {
        if (thisOperate == null)
        {
            return true;
        }





        this.Info(thisOperate).OperateClass = this.ThisClass;




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
            if (! this.CheckClass(valueClass, targetClass))
            {
                this.Error(this.ErrorKind.ValueUnassignable, assignExecute);
            }
        }






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
            this.Error(this.ErrorKind.ClassUndefined, newOperate);
        }





        this.Info(newOperate).NewClass = varClass;



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
            this.Error(this.ErrorKind.ClassUndefined, shareOperate);
        }





        this.Info(shareOperate).ShareClass = varClass;



        this.Info(shareOperate).OperateClass = varClass;




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




        ClassClass fieldClass;


        fieldClass = this.ExecuteThisFieldNode(getOperate, varThis, nodeField);




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




        MaideName nodeMethod;

        nodeMethod = callOperate.Maide;




        Argue argue;

        argue = callOperate.Argue;





        base.ExecuteCallOperate(callOperate);





        ClassClass thisClass;


        thisClass = null;


            
        if (!(varThis == null))
        {
            thisClass = this.Info(varThis).OperateClass;
        }




        string methodName;


        methodName = null;



        if (!(nodeMethod == null))
        {
            methodName = nodeMethod.Value;
        }




        if (thisClass == null)
        {
            this.Error(this.ErrorKind.ThisUndefined, callOperate);
        }





        Maide method;


        method = null;




        if (!(thisClass == null))
        {
            if (!(methodName == null))
            {
                method = this.Method(thisClass, methodName);
            }



            if (method == null)
            {
                this.Error(this.ErrorKind.MaideUndefined, callOperate);
            }
        }






        if (!(method == null))
        {
            if (!this.ArguesMatch(method, argue))
            {
                this.Error(this.ErrorKind.ArgueUnassignable, callOperate);
            }
        }





        ClassClass operateClass;


        operateClass = null;




        if (!(method == null))
        {
            operateClass = method.Class;
        }




        this.Info(callOperate).CallMaide = method;



        this.Info(callOperate).OperateClass = operateClass;




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





        this.Info(castOperate).CastClass = varClass;



        this.Info(castOperate).OperateClass = varClass;




        return true;
    }





    public override bool ExecuteInfExecute(InfExecute condExecute)
    {
        if (condExecute == null)
        {
            return true;
        }




        Operate cond;
            
        cond = condExecute.Cond;



        State then;
        
        then = condExecute.Then;





        base.ExecuteInfExecute(condExecute);





        this.ExecuteCondBodyExecute(condExecute, cond);





        return true;
    }






    public override bool ExecuteWhileExecute(WhileExecute loopExecute)
    {
        if (loopExecute == null)
        {
            return true;
        }





        Operate cond;

        cond = loopExecute.Cond;



        State loop;

        loop = loopExecute.Loop;





        base.ExecuteWhileExecute(loopExecute);





        this.ExecuteCondBodyExecute(loopExecute, cond);





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






    public override bool ExecuteNullOperate(NullOperate nullOperate)
    {
        if (nullOperate == null)
        {
            return true;
        }

        


        this.Info(nullOperate).OperateClass = this.NullClass;




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




        ClassClass varClass;


        varClass = this.ExecuteVarNameNode(varOperate, name);




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





    public override bool ExecuteVarTarget(VarTarget varTarget)
    {
        if (varTarget == null)
        {
            return true;
        }




        VarName name;


        name = varTarget.Var;




        ClassClass varClass;


        varClass = this.ExecuteVarNameNode(varTarget, name);




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




        ClassClass fieldClass;


        fieldClass = this.ExecuteThisFieldNode(setTarget, varThis, nodeField);




        this.Info(setTarget).TargetClass = fieldClass;





        return true;
    }






    protected virtual ClassClass ExecuteVarNameNode(NodeNode node, VarName name)
    {
        string varName;


        varName = name.Value;




        Var varVar;


        varVar = this.VarStackVar(varName);




        if (varVar == null)
        {
            this.Error(this.ErrorKind.VarUndefined, node);
        }




        ClassClass varClass;

        varClass = null;


        if (!(varVar == null))
        {
            varClass = varVar.Class;
        }




        this.Info(node).Var = varVar;




        return varClass;
    }





    protected virtual ClassClass ExecuteThisFieldNode(NodeNode node, Operate varThis, FieldName nodeField)
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





        ClassClass fieldClass;


        fieldClass = null;




        if (!(field == null))
        {
            fieldClass = field.Class;
        }




        this.Info(node).GetField = field;





        return fieldClass;
    }






    protected virtual bool CheckClass(ClassClass varClass, ClassClass requiredClass)
    {
        ClassClass currentClass;



        currentClass = varClass;




        bool b;



        b = false;



        while (!b & !(currentClass == null))
        {


            if (currentClass == this.NullClass)
            {
                b = true;
            }



            if (currentClass == requiredClass)
            {
                b = true;
            }




            currentClass = currentClass.Base;
        }




        bool ret;


        ret = b;


        return ret;
    }





    private bool CheckAccces(ClassClass varClass, Count access)
    {
        if (this.ThisClass == varClass)
        {
            return true;
        }



        if (access == this.Count.Prudate)
        {
            return true;
        }



        if (access == this.Count.Probate)
        {
            bool b;

            b = false;

            if (b)
            {
                return true;
            }


            return false;
        }


 
        if (access == this.Count.Precate)
        {
            return true;
        }



        if (access == this.Count.Private)
        {
            return false;
        }



        return true;
    }






    protected virtual Field Field(ClassClass varClass, string name)
    {
        Field field;


        field = (Field)varClass.Field.Get(name);



        if (!(field == null))
        {
            if (!this.CheckAccces(varClass, field.Count))
            {
                return null;
            }


            return field;
        }




        ClassClass baseClass;


        baseClass = varClass.Base;



        if (!(baseClass == null))
        {
            field = this.Field(baseClass, name);



            if (!(field == null))
            {
                return field;
            }
        }



        return null;
    }





    protected virtual Maide Method(ClassClass varClass, string name)
    {
        Maide method;


        method = (Maide)varClass.Maide.Get(name);



        if (!(method == null))
        {
            if (!this.CheckAccces(varClass, method.Count))
            {
                return null;
            }


            return method;
        }




        ClassClass baseClass;


        baseClass = varClass.Base;



        if (!(baseClass == null))
        {
            method = this.Method(baseClass, name);



            if (!(method == null))
            {
                return method;
            }
        }



        return null;
    }





    protected virtual bool ArguesMatch(Maide method, Argue argue)
    {
        int count;



        count = method.Param.Count;





        bool countEqual;



        countEqual = (count == argue.Value.Count);




        if (!countEqual)
        {
            return false;
        }




        Iter varIter;

        varIter = method.Param.IterCreate();

        method.Param.IterSet(varIter);




        Iter argueItemIter;

        argueItemIter = argue.Value.IterCreate();

        argue.Value.IterSet(argueItemIter);



        int i;


        i = 0;


        while (i < count)
        {
            varIter.Next();



            argueItemIter.Next();




            Var varVar;


            varVar = (Var)varIter.Value;




            Operate operate;


            operate = (Operate)argueItemIter.Value;




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





    private bool VarMapAdd(Table map, Var varVar)
    {
        TableEntry pair;


        pair = new TableEntry();


        pair.Init();


        pair.Index = varVar.Name;


        pair.Value = varVar;




        map.Add(pair);



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