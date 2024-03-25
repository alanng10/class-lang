namespace Z.Tool.ReferBinaryGen;

public class Gen : Any
{
    public virtual int Execute()
    {
        this.ExecuteAssembly(typeof(Any).Assembly);

        return 0;
    }

    protected virtual bool ExecuteAssembly(Assembly o)
    {
        ListList list;
        list = new ListList();
        list.Init();

        SystemType[] typeArray;
        typeArray = o.GetExportedTypes();

        int count;
        count = typeArray.Length;
        int i;
        i = 0;
        while (i < count)
        {
            SystemType type;
            type = typeArray[i];

            SystemType baseType;
            baseType = type.BaseType;
            if (!(baseType == null))
            {
                if (!(baseType.Assembly == o))
                {
                    list.Add(baseType);
                }
            }

            global::System.Console.Write("Export Class: " + type.Name + "\n");

            i = i + 1;
        }
        
        return true;
    }
}