namespace Class.Library;




public class FieldSetVarOperate : VarOperate
{
    public override bool ExecuteGet(int varIndex)
    {
        bool ba;

        ba = (varIndex == 0);


        bool bb;

        bb = (varIndex == 1);



        if (ba)
        {
            this.Create.ExecuteOperateVarThisFieldData();
        }
        
        
        if (bb)
        {
            int index;

            index = 0;


            this.Create.ExecuteOperateVarParamVar(index);
        }


        if (!(ba | bb))
        {
            int index;

            index = this.GetLocalVarIndex(varIndex);


            this.Create.ExecuteOperateVarLocalVar(index);
        }
        
        
        
        return true;
    }
    
    
    
    
    
    public override bool ExecuteSet(int varIndex)
    {
        bool ba;

        ba = (varIndex == 0);


        bool bb;

        bb = (varIndex == 1);



        if (ba)
        {
            this.Create.ExecuteOperateAssignVarThisFieldData();
        }
        
        
        if (bb)
        {
            int index;

            index = 0;


            this.Create.ExecuteOperateAssignVarParamVar(index);
        }


        if (!(ba | bb))
        {
            int index;

            index = this.GetLocalVarIndex(varIndex);


            this.Create.ExecuteOperateAssignVarLocalVar(index);
        }
        
        
        
        return true;
    }




    protected virtual int GetLocalVarIndex(int varIndex)
    {
        return varIndex - 2;
    }
}