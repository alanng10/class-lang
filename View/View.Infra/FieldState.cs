namespace Mirai.Infra;

public class FieldState : State
{
    public virtual Field Field { get; set; }

    public override bool Execute()
    {
        Mod mod;
        mod = (Mod)this.Arg;
        this.Field.Comp.Mod(this.Field, mod);
        return true;
    }
}