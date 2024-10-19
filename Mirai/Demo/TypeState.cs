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
        d = this.Demo.Frame.Type.Index;

        Button a;
        a = aa.Button;

        if (a == d.AlphaB & o)
        {
            this.Demo.Frame.Close();
        }

        bool b;
        b = false;
    
        if (a == d.AlphaI & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Row;
            k = k - 10;
            this.Demo.ViewA.Pos.Row = k;
            b = true;
        }
        if (a == d.AlphaK & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Row;
            k = k + 10;
            this.Demo.ViewA.Pos.Row = k;
            b = true;
        }
        if (a == d.AlphaJ & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Col;
            k = k - 10;
            this.Demo.ViewA.Pos.Col = k;
            b = true;
        }
        if (a == d.AlphaL & o)
        {
            long k;
            k = this.Demo.ViewA.Pos.Col;
            k = k + 10;
            this.Demo.ViewA.Pos.Col = k;
            b = true;
        }

        if (a == d.AlphaU & o)
        {
            bool bo;
            bo = this.Demo.ViewA.Visible;
            bo = !bo;
            this.Demo.ViewA.Visible = bo;
            b = true;
        }

        if (a == d.AlphaF & o)
        {
            long k;
            k = this.Demo.ViewA.RotateValue;
            k = k + 1;
            this.Demo.ViewA.RotateValue = k;
            b = true;
        }

        bool ba;
        ba = false;
        if (a == d.AlphaW & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Row;
            k = k - 10;
            this.Demo.ViewC.Pos.Row = k;
            ba = true;
        }
        if (a == d.AlphaS & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Row;
            k = k + 10;
            this.Demo.ViewC.Pos.Row = k;
            ba = true;
        }
        if (a == d.AlphaA & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Col;
            k = k - 10;
            this.Demo.ViewC.Pos.Col = k;


            ba = true;
        }
        if (a == d.AlphaD & o)
        {
            long k;
            k = this.Demo.ViewC.Pos.Col;
            k = k + 10;
            this.Demo.ViewC.Pos.Col = k;
            ba = true;
        }

        if (a == d.AlphaH & o)
        {
            bool baa;
            baa = this.Demo.Play.AudioOut.Muted;
            baa = !baa;
            this.Demo.Play.AudioOut.Muted = baa;
        }

        long scaleFactor;
        scaleFactor = 1 << 20;

        if (a == d.AlphaC & o)
        {
            long k;
            k = this.Demo.Play.AudioOut.Volume;
            long ao;
            ao = this.Demo.MathValue(scaleFactor / 16, -20);

            k = this.Demo.Math.Add(k, ao);

            this.Demo.Play.AudioOut.Volume = k;
        }

        if (a == d.AlphaV & o)
        {
            long k;
            k = this.Demo.Play.AudioOut.Volume;
            long ao;
            ao = this.Demo.MathValue(scaleFactor / 16, -20);

            k = this.Demo.Math.Sub(k, ao);

            this.Demo.Play.AudioOut.Volume = k;
        }

        if (a == d.AlphaE & o)
        {
            this.Demo.Play.Execute();
        }

        if (a == d.AlphaR & o)
        {
            this.Demo.Play.Pause();
        }

        if (a == d.AlphaG & o)
        {
            long kaaa;
            //global::System.Console.Write("Demo Play Pos Get Before\n");
            kaaa = this.Demo.Play.Pos;
            //global::System.Console.Write("Demo Play Pos Get After, value: " + kaaa + "\n");

            long kkaa;
            kkaa = kaaa + 10 * 1000;
            //global::System.Console.Write("Demo Play New Pos, value: " + kkaa + "\n");

            long time;
            //global::System.Console.Write("Demo Play Time Get Before\n");
            time = this.Demo.Play.Time;
            //global::System.Console.Write("Demo Play Time Get After, value: " + time + "\n");
            if (!(time < kkaa))
            {
                //global::System.Console.Write("Demo Play Pos Set Before\n");
                this.Demo.Play.Pos = kkaa;
                //global::System.Console.Write("Demo Play Pos Set After\n");
            }
        }

        if (a == d.AlphaN & o)
        {
            String frameTitle;
            frameTitle = this.S("Mirai Demo " + this.TitleIndex.ToString("x4"));

            this.Demo.Frame.Title = frameTitle;
            this.Demo.Frame.TitleSet();

            this.TitleIndex = this.TitleIndex + 1;
        }

        if (b)
        {
            this.ViewInfra.AssignDrawRectValue(this.Demo.UpdateRect, this.Demo.ViewA.Area);

            this.Demo.Frame.EventDraw(this.Demo.UpdateRect);
        }

        if (ba)
        {
            this.ViewInfra.AssignDrawRectValue(this.Demo.UpdateRect, this.Demo.ViewC.Area);

            this.Demo.Frame.EventDraw(this.Demo.UpdateRect);
        }
        return true;
    }

    protected virtual String S(string o)
    {
        return this.Demo.S(o);
    }
}