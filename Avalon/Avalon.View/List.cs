namespace Avalon.View;

public class List : Comp
{
    public override bool Init()
    {
        base.Init();
        RefCompare compare;
        compare = new RefCompare();
        compare.Init();
        this.ItemTable = new Table();
        this.ItemTable.Compare = compare;
        this.ItemTable.Init();
        
        this.ItemIter = this.ItemTable.IterCreate();

        this.EventState = new ListState();
        this.EventState.Init();
        this.EventState.List = this;
        
        this.ListChangeArg = (ListChange)this.ChangeArg;
        return true;
    }

    protected virtual Table ItemTable { get; set; }
    protected virtual Iter ItemIter { get; set; }
    protected virtual ListState EventState { get; set; }
    protected virtual ListChange ListChangeArg { get; set; }

    protected override Change CreateChangeArg()
    {
        Change a;
        a = new ListChange();
        a.Init();
        return a;
    }

    public virtual int Count
    {
        get
        {
            return this.ItemTable.Count;
        }
        set
        {
        }
    }

    public virtual bool ItemChange(Comp item)
    {
        this.ListChangeArg.Item = item;

        this.EventList();

        this.ListChangeArg.Item = null;
        return true;
    }

    public virtual bool Add(Comp item)
    {
        if (item == null)
        {
            return true;
        }

        Entry entry;
        entry = new Entry();
        entry.Init();
        entry.Index = item;
        entry.Value = item;

        this.ItemTable.Add(entry);

        item.ChangeEvent.State.AddState(this.EventState);

        this.EventList();
        return true;
    }

    public virtual bool Clear()
    {
        Iter iter;
        iter = this.ItemIter;
        this.ItemTable.IterSet(iter);
        while (iter.Next())
        {
            Comp item;
            item = (Comp)iter.Value;
            item.ChangeEvent.State.RemoveState(this.EventState);
        }

        this.ItemTable.Clear();

        this.EventList();
        return true;
    }

    public virtual bool Insert(Comp index, Comp item)
    {
        if (!this.Valid(index))
        {
            return true;
        }

        if (item == null)
        {
            return true;
        }

        Entry entry;
        entry = new Entry();
        entry.Init();
        entry.Index = item;
        entry.Value = item;

        this.ItemTable.Insert(index, entry);

        item.ChangeEvent.State.AddState(this.EventState);

        this.EventList();
        return true;
    }

    public virtual bool Remove(Comp comp)
    {
        Comp item;
        item = this.Get(comp);
        if (item == null)
        {
            return true;
        }

        this.ItemTable.Remove(item);

        item.ChangeEvent.State.RemoveState(this.EventState);

        this.EventList();
        return true;
    }

    public virtual Iter IterCreate()
    {
        ListIter iter;
        iter = new ListIter();
        iter.Init();
        iter.Iter = this.ItemTable.IterCreate();
        Iter a;
        a = iter;
        return a;
    }

    public virtual bool IterSet(Iter iter)
    {
        ListIter a;
        a = (ListIter)iter;
        this.ItemTable.IterSet(a.Iter);
        return true;
    }

    protected virtual bool EventList()
    {
        this.Event(null);
        return true;
    }

    public virtual bool Valid(Comp index)
    {
        return !(this.Get(index) == null);
    }

    public virtual Comp Get(Comp index)
    {
        return (Comp)this.ItemTable.Get(index);
    }
}