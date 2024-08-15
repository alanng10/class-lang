namespace Demo;

class TypeState : State
{
    public override bool Init()
    {
        base.Init();
        this.ViewInfra = ViewInfra.This;
        this.Console = Console.This;
        return true;
    }

    public Demo Demo { get; set; }
    protected virtual ViewInfra ViewInfra { get; set; }
    protected virtual Console Console { get; set; }
    public long TitleIndex { get; set; }

    public override bool Execute()
    {
        ChangeArg aa;
        aa = (ChangeArg)this.Arg;
        bool o;
        o = aa.Field;

        ButtonList d;
        d = this.Demo.Frame.Type.Button;

        Button a;
        a = aa.Button;

        if (a == d.LetterB & o)
        {
            this.Demo.Frame.Close();
        }

        if (a == d.SignPercent & o)
        {
            this.Console.Out.Write(this.S("Type Button Sign Percent Pressed\n"));
        }

        bool b;
        b = false;
    
        if (a == d.LetterI & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Row;
            k = k - 10;
            this.Demo.ViewA.Pos.Row = k;
            b = true;
        }
        if (a == d.LetterK & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Row;
            k = k + 10;
            this.Demo.ViewA.Pos.Row = k;
            b = true;
        }
        if (a == d.LetterJ & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Col;
            k = k - 10;
            this.Demo.ViewA.Pos.Col = k;
            b = true;
        }
        if (a == d.LetterL & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Col;
            k = k + 10;
            this.Demo.ViewA.Pos.Col = k;
            b = true;
        }

        if (a == d.LetterU & o)
        {
            bool bo;
            bo = this.Demo.ViewA.Visible;
            bo = !bo;
            this.Demo.ViewA.Visible = bo;
            b = true;
        }

        if (a == d.LetterF & o)
        {
            long k;
            k = this.Demo.ViewA.RotateValue;
            k = k + 1;
            this.Demo.ViewA.RotateValue = k;
            b = true;
        }

        bool ba;
        ba = false;
        if (a == d.LetterW & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Row;
            k = k - 10;
            this.Demo.ViewC.Pos.Row = k;
            ba = true;
        }
        if (a == d.LetterS & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Row;
            k = k + 10;
            this.Demo.ViewC.Pos.Row = k;
            ba = true;
        }
        if (a == d.LetterA & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Col;
            k = k - 10;
            this.Demo.ViewC.Pos.Col = k;


            ba = true;
        }
        if (a == d.LetterD & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Col;
            k = k + 10;
            this.Demo.ViewC.Pos.Col = k;
            ba = true;
        }

        if (a == d.LetterH & o)
        {
            bool baa;
            baa = this.Demo.Play.AudioOut.Muted;
            baa = !baa;
            this.Demo.Play.AudioOut.Muted = baa;
        }

        long scaleFactor;
        scaleFactor = 1 << 20;

        if (a == d.LetterC & o)
        {
            long k;
            k = this.Demo.Play.AudioOut.Volume;
            long ao;
            ao = this.Demo.MathValue(scaleFactor / 16, -20);

            k = this.Demo.Math.Add(k, ao);

            this.Demo.Play.AudioOut.Volume = k;
        }

        if (a == d.LetterV & o)
        {
            long k;
            k = this.Demo.Play.AudioOut.Volume;
            long ao;
            ao = this.Demo.MathValue(scaleFactor / 16, -20);

            k = this.Demo.Math.Sub(k, ao);

            this.Demo.Play.AudioOut.Volume = k;
        }

        if (a == d.LetterE & o)
        {
            this.Demo.Play.Execute();
        }

        if (a == d.LetterR & o)
        {
            this.Demo.Play.Pause();
        }

        if (a == d.LetterN & o)
        {
            String frameTitle;
            frameTitle = this.S("Avalon Demo " + this.TitleIndex.ToString("x4"));

            this.Demo.Frame.Title = frameTitle;
            this.Demo.Frame.TitleSet();

            this.TitleIndex = this.TitleIndex + 1;
        }

        if (b)
        {
            this.ViewInfra.AssignDrawRectValue(this.Demo.UpdateRect, this.Demo.ViewA.Area);

            this.Demo.Frame.Update(this.Demo.UpdateRect);
        }

        if (ba)
        {
            this.ViewInfra.AssignDrawRectValue(this.Demo.UpdateRect, this.Demo.ViewC.Area);

            this.Demo.Frame.Update(this.Demo.UpdateRect);
        }
        return true;
    }

    protected virtual String S(string o)
    {
        return this.Demo.StringValue(o);
    }
}