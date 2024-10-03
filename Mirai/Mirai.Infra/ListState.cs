namespace Mirai.Infra;

public class ListState : State
{
    public virtual List List { get; set; }

    public override bool Execute()
    {
        Mod mod;
        mod = (Mod)this.Arg;
        CompComp a;
        a = mod.Comp;
        Comp item;
        item = (Comp)a;
        this.List.ItemChange(item);
        return true;
    }
}