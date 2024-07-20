namespace Avalon.Event;

public class StateTable : Table
{
    public override bool Init()
    {
        RefCompare compare;
        compare = new RefCompare();
        compare.Init();
        this.Compare = compare;
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
        this.Remove(state);
        return true;
    }
}