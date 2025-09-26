namespace Saber.Console;

public class ClassStringGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.StringComp = StringComp.This;
        return true;
    }

    public virtual Data State { get; set; }
    public virtual Array Result { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual long Index { get; set; }
    protected virtual Data CountData { get; set; }

    public virtual bool Execute()
    {
        this.Index = 0;

        long count;
        count = this.ExecuteCount();

        this.Index = sizeof(long);

        this.CountData = new Data();
        this.CountData.Count = count * sizeof(long);
        this.CountData.Init();

        long totalTextCount;
        totalTextCount = 0;

        long i;
        i = 0;

        while (i < count)
        {
            long ka;
            ka = this.ExecuteCount();

            this.Index = this.Index + sizeof(long);

            this.Index = this.Index + ka * sizeof(int);

            this.InfraInfra.DataIntSet(this.CountData, i * sizeof(long), ka);

            totalTextCount = totalTextCount + ka;

            i = i + 1;
        }

        Data textData;
        textData = new Data();
        textData.Count = totalTextCount * sizeof(int);
        textData.Init();

        this.Index = sizeof(long);

        long textIndex;
        textIndex = 0;

        i = 0;

        while (i < count)
        {
            long countA;
            countA = this.InfraInfra.DataIntGet(this.CountData, i * sizeof(long));

            this.Index = this.Index + sizeof(long);

            long iA;
            iA = 0;
            while (iA < countA)
            {
                long kk;
                kk = this.ExecuteMid();

                this.Index = this.Index + sizeof(int);

                this.TextInfra.DataCharSet(textData, textIndex, kk);

                textIndex = textIndex + 1;

                iA = iA + 1;
            }

            i = i + 1;
        }

        this.Result = this.ListInfra.ArrayCreate(count);

        InfraRange range;
        range = new InfraRange();
        range.Init();

        textIndex = 0;

        i = 0;

        while (i < count)
        {
            long countB;
            countB = this.InfraInfra.DataIntGet(this.CountData, i * sizeof(long));

            range.Index = textIndex;
            range.Count = countB;

            String k;
            k = this.StringComp.CreateData(textData, range);

            this.Result.SetAt(i, k);

            textIndex = textIndex + countB;

            i = i + 1;
        }
        return true;
    }

    protected virtual long ExecuteCount()
    {
        return this.ExecuteInt();
    }

    protected virtual long ExecuteMid()
    {
        return this.InfraInfra.DataMidGet(this.State, this.Index);
    }

    protected virtual long ExecuteInt()
    {
        return this.InfraInfra.DataIntGet(this.State, this.Index);
    }
}