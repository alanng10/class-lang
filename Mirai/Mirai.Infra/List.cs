namespace Mirai.Infra;

public class List : Comp
{
    public override bool Init()
    {
        base.Init();
        RefLess less;
        less = new RefLess();
        less.Init();
        this.ItemTable = new Table();
        this.ItemTable.Less = less;
        this.ItemTable.Init();

        this.ItemIter = this.ItemTable.IterCreate();

        this.EventState = new ListState();
        this.EventState.Init();
        this.EventState.List = this;

        this.ListTriggerArg = (ListMod)this.ModArg;
        return true;
    }

    protected virtual Table ItemTable { get; set; }
    protected virtual Iter ItemIter { get; set; }
    protected virtual ListState EventState { get; set; }
    protected virtual ListMod ListTriggerArg { get; set; }

    protected override Mod CreateModArg()
    {
        Mod a;
        a = new ListMod();
        a.Init();
        return a;
    }

    public virtual long Count
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
        this.ListTriggerArg.Item = item;

        this.TriggerList();

        this.ListTriggerArg.Item = null;
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

        item.ModEvent.State.AddState(this.EventState);

        this.TriggerList();
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
            item.ModEvent.State.RemoveState(this.EventState);
        }

        this.ItemTable.Clear();

        this.TriggerList();
        return true;
    }

    public virtual bool Ins(Comp index, Comp item)
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

        this.ItemTable.Ins(index, entry);

        item.ModEvent.State.AddState(this.EventState);

        this.TriggerList();
        return true;
    }

    public virtual bool Rem(Comp comp)
    {
        Comp item;
        item = this.Get(comp);
        if (item == null)
        {
            return true;
        }

        this.ItemTable.Rem(item);

        item.ModEvent.State.RemoveState(this.EventState);

        this.TriggerList();
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

    protected virtual bool TriggerList()
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