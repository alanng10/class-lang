namespace Saber.Module;

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

        String className;
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
        table = this.Create.ClassTable;

        if (table.Valid(className))
        {
            this.Error(this.ErrorKind.NameUnavailable, nodeClass);
            return true;
        }

        ClassClass a;
        a = new ClassClass();
        a.Init();
        a.Name = className;
        a.Base = null;
        a.Field = this.ClassInfra.TableCreateStringLess();
        a.Maide = this.ClassInfra.TableCreateStringLess();
        a.Module = this.Module;
        a.Index = this.Source.Index;
        a.FieldRange = this.CreateRange();
        a.MaideRange = this.CreateRange();
        a.Any = nodeClass;
        
        this.ListInfra.TableAdd(this.Module.Class, a.Name, a);
        this.ListInfra.TableAdd(table, a.Name, a);

        this.Info(nodeClass).Class = a;
        return true;
    }

    private Range CreateRange()
    {
        Range a;
        a = new Range();
        a.Init();
        return a;
    }
}