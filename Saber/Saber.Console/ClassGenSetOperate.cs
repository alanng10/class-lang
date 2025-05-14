namespace Saber.Console;

public class ClassGenSetOperate : ClassGenOperate
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;

        this.Write = new Write();
        this.Write.Init();

        WriteArg e;
        e = new WriteArg();
        e.Init();
        e.Kind = 1;
        e.AlignLeft = false;
        e.FillChar = '0';
        this.WriteArgInt = e;

        this.Text = new Text();
        this.Text.Init();
        this.Text.Range = new InfraRange();
        this.Text.Range.Init();
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Write Write { get; set; }
    protected virtual WriteArg WriteArgInt { get; set; }
    protected virtual Text Text { get; set; }

    public override bool ExecuteChar(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;

        long index;
        index = arg.Index;

        this.TextInfra.DataCharSet(arg.Data, index, o);

        index = index + 1;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteTextInt(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;

        Write write;
        write = this.Write;

        WriteArg e;
        e = this.WriteArgInt;

        Text kk;
        kk = this.Text;

        e.Base = 10;
        e.FieldWidth = 0;
        e.MaxWidth = -1;
        e.Value.Int = o;

        write.ExecuteArgCount(e);

        long count;
        count = e.Count;

        kk.Data = arg.Data;
        kk.Range.Index = index;
        kk.Range.Count = count;

        write.ExecuteArgResult(e, kk);

        e.Count = 0;
        e.ValueCount = 0;
        e.Value.Int = 0;

        kk.Data = null;
        kk.Range.Index = 0;
        kk.Range.Count = 0;

        index = index + count;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteTextIntHex(long o)
    {
        GenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;

        Write write;
        write = this.Write;

        WriteArg e;
        e = this.WriteArgInt;

        Text kk;
        kk = this.Text;

        e.Base = 16;
        e.FieldWidth = 15;
        e.MaxWidth = 15;
        e.Value.Int = o;

        write.ExecuteArgCount(e);

        kk.Data = arg.Data;
        kk.Range.Index = index;
        kk.Range.Count = e.Count;

        write.ExecuteArgResult(e, kk);

        e.Count = 0;
        e.ValueCount = 0;
        e.Value.Int = 0;
        
        kk.Data = null;
        kk.Range.Index = 0;
        kk.Range.Count = 0;

        index = index + 15;
        arg.Index = index;
        return true;
    }
}