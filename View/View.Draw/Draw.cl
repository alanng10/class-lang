class Draw : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
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

        var Extern extern;
        extern : share Extern;

        var Int ka;
        ka : this.TextCount;
        ka : ka * 4;
        this.InternTextData : extern.New(ka);

        this.InternText : extern.String_New();
        extern.String_Init(this.InternText);
        extern.String_ValueSet(this.InternText, this.InternTextData);
        extern.String_CountSet(this.InternText, 0);

        this.InternRangeA : this.InternInfra.RangeCreate();
        this.InternRectA : this.InternInfra.RectCreate();
        this.InternRectB : this.InternInfra.RectCreate();
        this.InternPosA : this.InternInfra.PosCreate();
        this.InternPosB : this.InternInfra.PosCreate();

        this.InternSize : this.InternInfra.SizeCreate();

        this.InternArea : this.InternInfra.RectCreate();
    }
}