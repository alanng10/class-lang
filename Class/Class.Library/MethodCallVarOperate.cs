namespace Class.Library;




public class MethodCallVarOperate : VarOperate
{
    public override bool ExecuteGet(int varIndex)
    {
        int methodParamVarCount;

        methodParamVarCount = this.GetMethodParamCount();
        
        
        
        bool b;

        b = (varIndex < methodParamVarCount);

        if (b)
        {
            int index;

            index = varIndex;


            this.Create.ExecuteOperateVarParamVar(index);
        }


        if (!b)
        {
            int index;

            index = varIndex - methodParamVarCount;


            this.Create.ExecuteOperateVarLocalVar(index);
        }
        
        
        
        return true;
    }
    
    
    
    
    
    public override bool ExecuteSet(int varIndex)
    {
        int methodParamVarCount;

        methodParamVarCount = this.GetMethodParamCount();
        
        
        
        bool b;

        b = (varIndex < methodParamVarCount);

        if (b)
        {
            int index;

            index = varIndex;


            this.Create.ExecuteOperateAssignVarParamVar(index);
        }


        if (!b)
        {
            int index;

            index = varIndex - methodParamVarCount;


            this.Create.ExecuteOperateAssignVarLocalVar(index);
        }
        
        
        
        return true;
    }

    


    protected virtual int GetMethodParamCount()
    {
        return this.Create.StateParamVarCount - 1;
    }
}