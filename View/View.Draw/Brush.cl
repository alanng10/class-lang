class Brush : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;

        var BrushInfra infra;
        infra : share BrushInfra;

        var Int kindK;
        kindK : this.Kind.Intern;
    }
}