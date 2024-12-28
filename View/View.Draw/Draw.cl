class Draw : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternInfra : share InternInfra;
        this.MathInfra : share MathInfra;
        this.DrawInfra : share Infra;
        this.Math : share Math;

        this.Size : this.CreateSize();
        this.Area : this.CreateArea();
        this.Pos : this.CreatePos();
        this.FillPos : this.CreateFillPos();

        this.MathComp : this.CreateMathComp();

        this.PosA : this.CreatePosA();
        this.WorldForm : this.CreateWorldForm();

        this.TextCount : 1024;

        var Int ka;
        ka : this.TextCount;
        ka : ka * 4;
        this.InternTextData : extern.New(ka);
    }
}