namespace Z.Tool.ReferBinaryGen;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }

    protected virtual Assembly Assembly { get; set; }
    protected virtual Array DotNetTypeArray { get; set; }

    public virtual int Execute()
    {
        this.Assembly = typeof(Any).Assembly;
        this.ExecuteAssembly();

        return 0;
    }

    protected virtual bool ExecuteAssembly()
    {
        this.DotNetTypeArray = this.DotNetTypeList(this.Assembly);

        int count;
        count = this.DotNetTypeArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            DotNetType a;
            a = (DotNetType)this.DotNetTypeArray.Get(i);

            SystemType type;
            type = a.Type;

            SystemType baseType;
            baseType = type.BaseType;

            global::System.Console.Write("Export Class: " + type.Name + ", Base: " + baseType.Name + "(" + baseType.Assembly.GetName().Name + ")" + "\n");

            int countA;
            int iA;
            
            countA = a.Property.Count;
            iA = 0;
            while (iA < countA)
            {
                PropertyInfo property;
                property = (PropertyInfo)a.Property.Get(iA);
                global::System.Console.Write("Property: " + property.Name + ", Count: " + this.CountString(property.GetMethod) + ", ResultType: " + property.PropertyType.Name + "\n");
                iA = iA + 1;
            }

            countA = a.Method.Count;
            iA = 0;
            while (iA < countA)
            {
                MethodInfo method;
                method = (MethodInfo)a.Method.Get(iA);
                global::System.Console.Write("Method: " + method.Name + ", Count: " + this.CountString(method) + ", ResultType: " + method.ReturnType.Name + "\n");
                iA = iA + 1;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual Table ImportTable()
    {
        Table table;
        table = new Table();
        table.Compare = new StringCompare();
        table.Compare.Init();
        table.Init();

        Array array;
        array = this.DotNetTypeArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            DotNetType a;
            a = (DotNetType)array.Get(i);
            
            SystemType type;
            type = a.Type;

            SystemType baseType;
            baseType = type.BaseType;

            this.AddTypeToImportTable(table, baseType);

            int countA;
            int iA;

            countA = a.Property.Count;
            iA = 0;
            while (iA < countA)
            {
                PropertyInfo property;
                property = (PropertyInfo)a.Property.Get(iA);
                this.AddTypeToImportTable(table, property.PropertyType);
                iA = iA + 1;
            }

            countA = a.Method.Count;
            iA = 0;
            while (iA < countA)
            {
                MethodInfo method;
                method = (MethodInfo)a.Method.Get(iA);
                this.AddTypeToImportTable(table, method.ReturnType);
                iA = iA + 1;
            }

            i = i + 1;
        }
        return table;
    }

    protected virtual bool AddTypeToImportTable(Table table, SystemType type)
    {
        if (type.Assembly == this.Assembly)
        {
            return true;
        }
        
        string assemblyName;
        assemblyName = type.Assembly.GetName().Name;
        if (!table.Contain(assemblyName))
        {
            Table typeTable;
            typeTable = new Table();
            typeTable.Compare = new StringCompare();
            typeTable.Compare.Init();
            typeTable.Init();

            ListEntry oa;
            oa = new ListEntry();
            oa.Init();
            oa.Index = assemblyName;
            oa.Value = typeTable;
            table.Add(oa);
        }
        Table oo;
        oo = (Table)table.Get(assemblyName);

        string name;
        name = type.Name;

        if (oo.Contain(name))
        {
            return true;
        }
        
        ListEntry ob;
        ob = new ListEntry();
        ob.Init();
        ob.Index = name;
        ob.Value = type;
        oo.Add(ob);
        return true;
    }

    protected virtual Array DotNetTypeList(Assembly o)
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
            DotNetType a;
            a = new DotNetType();
            a.Init();

            SystemType type;
            type = typeArray[i];

            SystemType baseType;
            baseType = type.BaseType;

            a.Type = type;

            PropertyInfo[] propertyArrayA;
            propertyArrayA = type.GetProperties(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

            MethodInfo[] methodArrayA;
            methodArrayA = type.GetMethods(BindingFlag.Instance | BindingFlag.Public | BindingFlag.NonPublic | BindingFlag.DeclaredOnly | BindingFlag.ExactBinding);

            int countA;
            int iA;
            ListList propertyList;
            propertyList = new ListList();
            propertyList.Init();

            countA = propertyArrayA.Length;
            iA = 0;
            while (iA < countA)
            {
                PropertyInfo property;
                property = propertyArrayA[iA];

                if (!property.IsSpecialName & property.CanRead & property.CanWrite)
                {
                    if (this.IsInAbstract(property.GetMethod))
                    {
                        propertyList.Add(property);
                    }
                }

                iA = iA + 1;
            }

            Array propertyArray;
            propertyArray = this.ListInfra.ArrayCreateList(propertyList);

            ListList methodList;
            methodList = new ListList();
            methodList.Init();

            countA = methodArrayA.Length;
            iA = 0;
            while (iA < countA)
            {
                MethodInfo method;
                method = methodArrayA[iA];

                if (!method.IsSpecialName & this.IsInAbstract(method))
                {
                    methodList.Add(method);
                }

                iA = iA + 1;
            }

            Array methodArray;
            methodArray = this.ListInfra.ArrayCreateList(methodList);

            a.Property = propertyArray;
            a.Method = methodArray;

            list.Add(a);

            i = i + 1;
        }

        Array array;
        array = this.ListInfra.ArrayCreateList(list);
        return array;
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

    protected virtual bool IsInAbstract(MethodInfo method)
    {
        return method.IsPublic | method.IsFamily;
    }
}