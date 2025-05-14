namespace Saber.Module;

public class ClassTravel : Travel
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

        ClassClass ka;
        ka = this.Create.Class(className);
        if (!(ka == null))
        {
            this.Error(this.ErrorKind.NameUnavail, nodeClass);
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
        a.Index = this.Create.SourceIndex;
        a.Any = nodeClass;
        
        this.ListInfra.TableAdd(this.Module.Class, a.Name, a);

        this.Info(nodeClass).Class = a;
        return true;
    }
}