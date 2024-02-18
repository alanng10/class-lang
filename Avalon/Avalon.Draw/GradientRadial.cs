namespace Avalon.Draw;





public class GradientRadial : Any
{
    public override bool Init()
    {
        base.Init();




        this.InternIntern = InternIntern.This;


        this.InternInfra = InternInfra.This;




        Pos pos;

        pos = this.CenterPos;


        this.InternCenterPos = this.InternInfra.PosCreate(pos.Left, pos.Up);


        pos = this.FocusPos;


        this.InternFocusPos = this.InternInfra.PosCreate(pos.Left, pos.Up);




        ulong centerRadiusU;

        centerRadiusU = (ulong)(this.CenterRadius);


        ulong focusRadiusU;

        focusRadiusU = (ulong)(this.FocusRadius);





        this.Intern = Extern.GradientRadial_New();


        Extern.GradientRadial_SetCenterPos(this.Intern, this.InternCenterPos);


        Extern.GradientRadial_SetCenterRadius(this.Intern, centerRadiusU);


        Extern.GradientRadial_SetFocusPos(this.Intern, this.InternFocusPos);


        Extern.GradientRadial_SetFocusRadius(this.Intern, focusRadiusU);


        Extern.GradientRadial_Init(this.Intern);




        return true;
    }





    public virtual bool Final()
    {
        Extern.GradientRadial_Final(this.Intern);


        Extern.GradientRadial_Delete(this.Intern);



        this.InternInfra.PosDelete(this.InternFocusPos);


        this.InternInfra.PosDelete(this.InternCenterPos);




        return true;
    }

    



    public virtual Pos CenterPos { get; set; }


    public virtual int CenterRadius { get; set; }



    public virtual Pos FocusPos { get; set; }


    public virtual int FocusRadius { get; set; }





    private InternIntern InternIntern { get; set; }


    private InternInfra InternInfra { get; set; }



    internal virtual ulong Intern { get; set; }


    private ulong InternFocusPos { get; set; }


    private ulong InternCenterPos { get; set; }
}