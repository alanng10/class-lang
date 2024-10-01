namespace Avalon.Comp;

public class FieldState : State
{
    public virtual Field Field { get; set; }

    public override bool Execute()
    {
        Mod change;
        change = (Mod)this.Arg;
        this.Field.Comp.Change(this.Field, change);
        return true;
    }
}