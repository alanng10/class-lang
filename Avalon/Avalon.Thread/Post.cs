namespace Avalon.Thread;






public class Post : Any
{
    public override bool Init()
    {
        base.Init();





        this.InternIntern = InternIntern.This;


        this.InternInfra = InternInfra.This;


        this.ThreadInfra = Infra.This;





        this.InternHandle = new Handle();

        this.InternHandle.Any = this;

        this.InternHandle.Init();




        MaideAddress oa;

        oa = this.ThreadInfra.PostExecuteMaideAddress;



        ulong arg;


        arg = this.InternHandle.ULong();





        this.InternExecuteState = this.InternInfra.StateCreate(oa, arg);





        this.Intern = Extern.Post_New();


        Extern.Post_Init(this.Intern);



        Extern.Post_SetExecuteState(this.Intern, this.InternExecuteState);




        return true;
    }





    public virtual bool Final()
    {
        Extern.Post_Final(this.Intern);


        Extern.Post_Delete(this.Intern);



        this.InternInfra.StateDelete(this.InternExecuteState);



        this.InternHandle.Final();




        return true;
    }





    public virtual State State { get; set; }





    private InternIntern InternIntern { get; set; }


    private InternInfra InternInfra { get; set; }


    private Infra ThreadInfra { get; set; }





    private ulong Intern { get; set; }


    private ulong InternExecuteState { get; set; }


    private Handle InternHandle { get; set; }






    internal static ulong InternExecute(ulong post, ulong arg)
    {
        InternIntern internIntern;

        internIntern = InternIntern.This;




        object ao;

        ao = internIntern.HandleTarget(arg);




        Post a;

        a = (Post)ao;



        a.State.Execute();




        return 1;
    }






    public virtual bool Execute()
    {
        Extern.Post_Execute(this.Intern);




        return true;
    }
}