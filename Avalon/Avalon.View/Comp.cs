namespace Avalon.View;





public class Comp : CompComp
{
    public override bool Init()
    {
        base.Init();




        this.ViewInfra = Infra.This;




        return true;
    }






    protected virtual Infra ViewInfra { get; set; }
}