namespace Avalon.Infra;

public class StringJoin : Any
{
    public override bool Init()
    {
        base.Init();

        return true;
    }


    public virtual String Result()
    {
        return null;
    }

    public virtual bool Clear()
    {
        return true;
    }

    public virtual bool Append(uint oc)
    {
        return true;
    }
}