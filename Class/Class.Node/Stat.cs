namespace Class.Node;





public class Stat : Any
{
    public static Stat This { get; } = CreateShare();




    private static Stat CreateShare()
    {
        Stat share;


        share = new Stat();



        Any a;


        a = share;


        a.Init();



        return share;
    }






    public override bool Init()
    {
        base.Init();




        this.InfraStat = InfraStat.This;
        



        this.IntSignValueNegativeMax = this.InfraStat.IntCapValue / 2;



        this.IntSignValuePositiveMax = this.IntSignValueNegativeMax - 1;


        

        return true;
    }




    protected virtual InfraStat InfraStat { get; set; }




    public virtual long IntSignValuePositiveMax { get; set; }



    public virtual long IntSignValueNegativeMax { get; set; }
}