namespace Avalon.Console;




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





        ProcessStartedMaide maideA;

        maideA = new ProcessStartedMaide(Process.InternStarted);



        this.ProcessStartedMaideAddress = new MaideAddress();


        this.ProcessStartedMaideAddress.Delegate = maideA;


        this.ProcessStartedMaideAddress.Init();





        ProcessFinishedMaide maideB;

        maideB = new ProcessFinishedMaide(Process.InternFinished);




        this.ProcessFinishedMaideAddress = new MaideAddress();


        this.ProcessFinishedMaideAddress.Delegate = maideB;


        this.ProcessFinishedMaideAddress.Init();





        return true;
    }





    public virtual MaideAddress ProcessStartedMaideAddress { get; set; }



    public virtual MaideAddress ProcessFinishedMaideAddress { get; set; }
}