namespace Avalon.Thread;




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





        ThreadExecuteMaide maideA;

        maideA = new ThreadExecuteMaide(Thread.InternExecute);



        this.ThreadExecuteMaideAddress = new MaideAddress();


        this.ThreadExecuteMaideAddress.Delegate = maideA;


        this.ThreadExecuteMaideAddress.Init();





        PostExecuteMaide maideB;

        maideB = new PostExecuteMaide(Post.InternExecute);



        this.PostExecuteMaideAddress = new MaideAddress();


        this.PostExecuteMaideAddress.Delegate = maideB;


        this.PostExecuteMaideAddress.Init();

        




        return true;
    }





    public virtual MaideAddress ThreadExecuteMaideAddress { get; set; }



    public virtual MaideAddress PostExecuteMaideAddress { get; set; }
}