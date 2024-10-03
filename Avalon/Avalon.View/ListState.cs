namespace Avalon.View;

public class ListState : State
{
    public virtual List List { get; set; }

    public override bool Execute()
    {
        Change change;
        change = (Change)this.Arg;
        CompComp a;
        a = change.Comp;
        Comp item;
        item = (Comp)a;
        this.List.ItemChange(item);
        return true;
    }
}