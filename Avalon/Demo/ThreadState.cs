namespace Demo;

class ThreadState : State
{
    public override bool Init()
    {
        base.Init();
        this.MathInfra = MathInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.Math = MathMath.This;
        this.MathComp = new MathComp();
        this.MathComp.Init();
        return true;
    }

    public Demo Demo { get; set; }
    public ThreadPhore Phore { get; set; }
    protected virtual MathInfra MathInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }

    public override bool Execute()
    {
        Console console;
        console = Console.This;

        console.Out.Write(this.S("Thread Execute State\n"));

        bool b;
        b = false;

        long a;
        a = 98572403;

        if (!b)
        {
            String ka;
            ka = this.StorageInfra.TextRead(this.S("DemoData/ThreadRead.txt"));

            String kb;
            kb = this.S("H n\n拉 a\nJ I 阿 着 的了@ 34 #F # S c");

            if (!this.Demo.TextSame(this.Demo.TA(ka), this.Demo.TB(kb)))
            {
                a = 10;
                b = true;
            }
        }

        string writeFilePath;
        writeFilePath = "DemoData/ThreadWrite.txt";

        String kkka;
        kkka = this.S(writeFilePath);

        String kc;
        kc = this.S("阿 了 水 GR 8 &\nEu #@ ?\n卡");

        if (!b)
        {
            File.Delete(writeFilePath);


            bool ba;
            ba = this.StorageInfra.TextWrite(kkka, kc);
            
            if (!ba)
            {
                a = 20;
                b = true;
            }
        }

        if (!b)
        {
            String kd;
            kd = this.StorageInfra.TextRead(kkka);

            if (!this.Demo.TextSame(this.Demo.TA(kc), this.Demo.TB(kd)))
            {
                a = 30;
                b = true;
            }
        }

        this.Phore.Close();

        Value aa;
        aa = new Value();
        aa.Init();
        aa.Int = a;

        this.Result = aa;
        return true;
    }

    public virtual ThreadState Add(String a)
    {
        this.Demo.Add(a);
        return this;
    }

    public virtual ThreadState AddS(string o)
    {
        this.Demo.AddS(o);
        return this;
    }

    public virtual ThreadState AddClear()
    {
        this.Demo.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.Demo.AddResult();
    }

    protected virtual String S(string o)
    {
        return this.Demo.S(o);
    }
}