namespace Demo;

class TypeState : State
{
    public override bool Init()
    {
        base.Init();
        this.ViewInfra = ViewInfra.This;
        return true;
    }

    public Demo Demo { get; set; }
    public ViewInfra ViewInfra { get; set; }
    public int TitleIndex { get; set; }

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

        bool b;
        b = false;
    
        if (a == d.LetterI & o)
        {
            int k;
            k = this.Demo.ViewA.Pos.Up;
            k = k - 10;
            this.Demo.ViewA.Pos.Up = k;
            b = true;
        }
        if (a == d.LetterK & o)
        {
            int k;
            k = this.Demo.ViewA.Pos.Up;
            k = k + 10;
            this.Demo.ViewA.Pos.Up = k;
            b = true;
        }
        if (a == d.LetterJ & o)
        {
            int k;
            k = this.Demo.ViewA.Pos.Left;
            k = k - 10;
            this.Demo.ViewA.Pos.Left = k;
            b = true;
        }
        if (a == d.LetterL & o)
        {
            int k;
            k = this.Demo.ViewA.Pos.Left;
            k = k + 10;
            this.Demo.ViewA.Pos.Left = k;
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
            int k;
            k = this.Demo.ViewA.RotateValue;
            k = k + 1;
            this.Demo.ViewA.RotateValue = k;
            b = true;
        }

        bool ba;
        ba = false;
        if (a == d.LetterW & o)
        {
            int k;
            k = this.Demo.ViewC.Pos.Up;
            k = k - 10;
            this.Demo.ViewC.Pos.Up = k;
            ba = true;
        }
        if (a == d.LetterS & o)
        {
            int k;
            k = this.Demo.ViewC.Pos.Up;
            k = k + 10;
            this.Demo.ViewC.Pos.Up = k;
            ba = true;
        }
        if (a == d.LetterA & o)
        {
            int k;
            k = this.Demo.ViewC.Pos.Left;
            k = k - 10;
            this.Demo.ViewC.Pos.Left = k;


            ba = true;
        }
        if (a == d.LetterD & o)
        {
            int k;
            k = this.Demo.ViewC.Pos.Left;
            k = k + 10;
            this.Demo.ViewC.Pos.Left = k;
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
            ao = scaleFactor / 16;
            k = k + ao;
            this.Demo.Play.AudioOut.Volume = k;
        }

        if (a == d.LetterV & o)
        {
            long k;
            k = this.Demo.Play.AudioOut.Volume;
            long ao;
            ao = scaleFactor / 16;
            k = k - ao;
            if (k < 0)
            {
                k = 0;
            }
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
            string frameTitle;
            frameTitle = "Avalon Demo " + this.TitleIndex.ToString("x4");

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
}