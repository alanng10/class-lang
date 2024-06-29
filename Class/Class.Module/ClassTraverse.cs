namespace Class.Module;

public class ClassTraverse : Traverse
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }

    public override bool ExecuteClass(NodeClass nodeClass)
    {
        if (nodeClass == null)
        {
            return true;
        }
        
        ClassName name;
        name = nodeClass.Name;

        string className;
        className = null;
        if (!(name == null))
        {
            className = name.Value;
        }
        
        if (className == null)
        {
            return true;
        }

        Table table;
        table = this.Create.Module.Class;

        if (table.Contain(className))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeClass);
            return true;
        }

        ClassClass a;
        a = new ClassClass();
        a.Init();
        a.Name = className;
        a.Base = null;
        a.Field = this.ClassInfra.TableCreateStringCompare();
        a.Maide = this.ClassInfra.TableCreateStringCompare();
        a.Module = this.Module;
        a.Index = this.Source.Index;
        a.Any = nodeClass;
        
        this.ListInfra.TableAdd(table, a.Name, a);

        this.Info(nodeClass).Class = a;
        return true;
    }
}