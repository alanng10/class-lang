namespace Avalon.Event;

public class StateTable : Table
{
    public override bool Init()
    {
        RefLess less;
        less = new RefLess();
        less.Init();
        this.Less = less;
        base.Init();
        return true;
    }

    public virtual bool AddState(State state)
    {
        Entry entry;
        entry = new Entry();
        entry.Init();
        entry.Index = state;
        entry.Value = state;
        this.Add(entry);
        return true;
    }

    public virtual bool RemoveState(State state)
    {
        this.Rem(state);
        return true;
    }
}