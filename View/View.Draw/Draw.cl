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
        extern : this.Extern;

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

        this.InternFillPos : this.InternInfra.PosCreate();

        this.Intern : extern.Draw_New();
        extern.Draw_Init(this.Intern);
        extern.Draw_SizeSet(this.Intern, this.InternSize);
        extern.Draw_AreaSet(this.Intern, this.InternArea);
        extern.Draw_FillPosSet(this.Intern, this.InternFillPos);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Draw_Final(this.Intern);
        extern.Draw_Delete(this.Intern);

        this.InternInfra.PosDelete(this.InternFillPos);

        this.InternInfra.RectDelete(this.InternArea);

        this.InternInfra.SizeDelete(this.InternSize);

        this.InternInfra.PosDelete(this.InternPosB);
        this.InternInfra.PosDelete(this.InternPosA);
        this.InternInfra.RectDelete(this.InternRectB);
        this.InternInfra.RectDelete(this.InternRectA);
        this.InternInfra.RangeDelete(this.InternRangeA);

        extern.String_Final(this.InternText);
        extern.String_Delete(this.InternText);

        extern.Delete(this.InternTextData);

        this.FinalWorldForm(this.WorldForm);
        return true;
    }

    maide precate Size CreateSize()
    {
        var Size a;
        a : new Size;
        a.Init();
        return a;
    }

    maide precate Rect CreateArea()
    {
        var Rect a;
        a : new Rect;
        a.Init();
        a.Pos : new Pos;
        a.Pos.Init();
        a.Size : new Size;
        a.Size.Init();
        return a;
    }

    maide precate Pos CreatePos()
    {
        var Pos a;
        a : new Pos;
        a.Init();
        return a;
    }

    maide precate Pos CreateFillPos()
    {
        var Pos a;
        a : new Pos;
        a.Init();
        return a;
    }

    maide precate MathComp CreateMathComp()
    {
        var MathComp a;
        a : new MathComp;
        a.Init();
        return a;
    }

    maide precate Pos CreatePosA()
    {
        var Pos a;
        a : new Pos;
        a.Init();
        return a;
    }

    maide precate Form CreateWorldForm()
    {
        var Form a;
        a : new Form;
        a.Init();
        return a;
    }

    maide precate Bool FinalWorldForm(var Form a)
    {
        a.Final();
        return true;
    }

    field prusate Any Out { get { return data; } set { data : value; } }
    field prusate Size Size { get { return data; } set { data : value; } }
    field prusate Rect Area { get { return data; } set { data : value; } }
    field prusate Pos Pos { get { return data; } set { data : value; } }
    field prusate Pos FillPos { get { return data; } set { data : value; } }

    field prusate Brush Fill
    {
        get
        {
            return data;
        }
        set
        {
            data : value;

            var Int k;
            k : 0;
            inf (~(data = null))
            {
                k : data.Intern;
            }
            this.Extern.Draw_FillSet(this.Intern, k);
        }
    }
}