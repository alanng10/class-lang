namespace Class.Infra;

public class PrintableChar : Any
{
    public override bool Init()
    {
        base.Init();

        this.AsciiData = new Data();
        this.AsciiData.Count = 0x80;
        this.AsciiData.Init();

        this.SetRange('!', '~');
        return true;
    }

    protected virtual Data AsciiData { get; set; }

    public virtual bool Get(int index)
    {        
        int a;
        a = this.AsciiData.Get(index);

        if (a == -1)
        {
            return false;
        }

        return !(a == 0);
    }

    protected virtual bool SetRange(int first, int last)
    {
        Data data;
        data = this.AsciiData;

        int count;
        count = last - first + 1;
        int i;
        i = 0;
        while (i < count)
        {
            int n;
            n = first + i;

            data.Set(n, 1);

            i = i + 1;
        }

        return true;
    }
}