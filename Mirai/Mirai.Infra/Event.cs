namespace Avalon.Event;

public class Event : Any
{
    public override bool Init()
    {
        base.Init();
        StateTable state;
        state = new StateTable();
        state.Init();
        this.State = state;
        this.StateIter = this.State.IterCreate();
        return true;
    }
    
    public virtual StateTable State { get; set; }
    protected virtual Iter StateIter { get; set; }

    public virtual bool Execute(object arg)
    {
        Iter iter;
        iter = this.StateIter;
        this.State.IterSet(iter);
        while (iter.Next())
        {
            State state;
            state = (State)iter.Value;
            state.Arg = arg;
            state.Execute();
            state.Arg = null;
        }
        return true;
    }
}