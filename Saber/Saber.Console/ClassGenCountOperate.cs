namespace Saber.Console;

public class ClassGenCountOperate : ClassGenOperate
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
        e.Base = 10;
        e.AlignLeft = false;
        e.FieldWidth = 0;
        e.MaxWidth = -1;
        e.FillChar = '0';
        this.WriteArgInt = e;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual Write Write { get; set; }
    protected virtual WriteArg WriteArgInt { get; set; }

    public override bool ExecuteChar(long o)
    {
        ClassGenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;
        index = index + 1;
        arg.Index = index;
        return true;
    }

    public override bool ExecuteTextInt(long o)
    {
        ClassGenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;

        Write write;
        write = this.Write;

        WriteArg e;
        e = this.WriteArgInt;

        e.Value.Int = o;

        write.ExecuteArgCount(e);

        long count;
        count = e.Count;

        e.Count = 0;
        e.ValueCount = 0;
        e.Value.Int = 0;

        index = index + count;

        arg.Index = index;
        return true;
    }

    public override bool ExecuteTextIntHex(long o)
    {
        ClassGenArg arg;
        arg = this.Gen.Arg;
        long index;
        index = arg.Index;
        index = index + 15;
        arg.Index = index;
        return true;
    }
}