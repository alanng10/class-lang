namespace Avalon.Time;




class Infra : Any
{
    public static Infra This { get; } = ShareCreate();




    private static Infra ShareCreate()
    {
        Infra share;


        share = new Infra();



        Any a;


        a = share;


        a.Init();



        return share;
    }







    public override bool Init()
    {
        base.Init();





        IntervalElapseMaide maideA;

        maideA = new IntervalElapseMaide(Interval.InternElapse);



        this.IntervalElapseMaideAddress = new MaideAddress();


        this.IntervalElapseMaideAddress.Delegate = maideA;


        this.IntervalElapseMaideAddress.Init();




        return true;
    }





    public virtual MaideAddress IntervalElapseMaideAddress { get; set; }
}