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

        Class ka;
        ka = this.Class(className);
        if (!(ka == null))
        {
            this.Error(this.ErrorKind.NameUnavail, nodeClass);
            return true;
        }

        Class k;
        k = new Class();
        k.Init();
        k.Name = className;
        k.Base = null;
        k.Field = this.ClassInfra.TableCreateStringLess();
        k.Maide = this.ClassInfra.TableCreateStringLess();
        k.Module = this.Create.Module;
        k.Index = this.Create.SourceIndex;
        k.Any = nodeClass;

        this.ListInfra.TableAdd(this.Create.Module.Class, k.Name, k);

        this.Info(nodeClass).Class = k;
        return true;
    }
}