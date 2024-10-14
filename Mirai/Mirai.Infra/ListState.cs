namespace Mirai.Infra;

public class ListState : State
{
    public virtual List List { get; set; }

    public override bool Execute()
    {
        Mod mod;
        mod = (Mod)this.Arg;
        Comp item;
        item = mod.Comp;
        this.List.ItemChange(item);
        return true;
    }
}