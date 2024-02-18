namespace Avalon.Audio;




public class Out : Any
{
    public override bool Init()
    {
        base.Init();



        this.Intern = Extern.AudioOut_New();


        Extern.AudioOut_Init(this.Intern);



        this.Ident = this.Intern;



        return true;
    }




    public virtual bool Final()
    {
        Extern.AudioOut_Final(this.Intern);


        Extern.AudioOut_Delete(this.Intern);



        return true;
    }





    public virtual ulong Ident { get; set; }




    internal virtual ulong Intern { get; set; }





    public virtual bool Muted
    {
        get
        {
            ulong u;

            u = Extern.AudioOut_GetMuted(this.Intern);



            bool a;

            a = !(u == 0);


            return a;
        }
        set
        {
            ulong u;

            u = (ulong)(value ? 1 : 0);



            Extern.AudioOut_SetMuted(this.Intern, u);
        }
    }





    public virtual long Volume
    {
        get
        {
            ulong u;

            u = Extern.AudioOut_GetVolume(this.Intern);



            long a;

            a = (long)u;


            return a;
        }
        set
        {
            ulong u;

            u = (ulong)value;



            Extern.AudioOut_SetVolume(this.Intern, u);
        }
    }
}