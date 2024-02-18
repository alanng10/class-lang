namespace Class.Library;




public class FieldGetVarOperate : VarOperate
{
    public override bool ExecuteGet(int varIndex)
    {
        bool b;

        b = (varIndex == 0);



        if (b)
        {
            this.Create.ExecuteOperateVarThisFieldData();
        }
        
        


        if (!b)
        {
            int index;

            index = this.GetLocalVarIndex(varIndex);


            this.Create.ExecuteOperateVarLocalVar(index);
        }
        
        
        
        return true;
    }
    
    
    
    
    
    public override bool ExecuteSet(int varIndex)
    {
        bool b;

        b = (varIndex == 0);
        


        if (b)
        {
            this.Create.ExecuteOperateAssignVarThisFieldData();
        }
        
        


        if (!b)
        {
            int index;

            index = this.GetLocalVarIndex(varIndex);


            this.Create.ExecuteOperateAssignVarLocalVar(index);
        }
        
        
        
        return true;
    }




    protected virtual int GetLocalVarIndex(int varIndex)
    {
        return varIndex - 1;
    }
}