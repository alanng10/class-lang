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

            global::System.Console.Write("Export Class: " + type.Name + ", Base: " + baseType.Name + "(" + baseType.Assembly.GetName().Name + ")" + "\n");

            MethodInfo[] methodArray;
            methodArray = type.GetMethods(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

            int countA;
            countA = methodArray.Length;
            int iA;
            iA = 0;
            while (iA < countA)
            {
                MethodInfo method;
                method = methodArray[iA];

                if (!method.IsSpecialName)
                {
                    global::System.Console.Write("Method: " + method.Name + ", Count: " + this.CountString(method) + "\n");
                }

                iA = iA + 1;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual string CountString(MethodInfo method)
    {
        if (method.IsPublic)
        {
            return "Prudate";
        }
        if (method.IsAssembly)
        {
            return "Probate";
        }
        if (method.IsFamily)
        {
            return "Precate";
        }
        if (method.IsPrivate)
        {
            return "Private";
        }
        return null;
    }
}