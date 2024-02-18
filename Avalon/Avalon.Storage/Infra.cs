namespace Avalon.Storage;





public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();




    private static Infra ShareCreate()
    {
        Infra share;

        share = new Infra();



        Any a;

        a = share;

        a.Init();



        return share;
    }






    public override bool Init()
    {
        base.Init();



        this.InfraInfra = InfraInfra.This;



        this.TextInfra = TextInfra.This;




        TextEncodeKindList encodeKindList;

        encodeKindList = TextEncodeKindList.This;



        this.TextEncodeKindUtf8 = encodeKindList.Utf8;




        return true;
    }




    protected virtual InfraInfra InfraInfra { get; set; }



    protected virtual TextInfra TextInfra { get; set; }



    protected virtual TextEncodeKind TextEncodeKindUtf8 { get; set; }




    public virtual Data ReadData(string filePath)
    {
        Storage storage;

        storage = new Storage();

        storage.Init();


        Mode mode;

        mode = new Mode();

        mode.Init();

        mode.Read = true;



        storage.Path = filePath;

        storage.Mode = mode;


        storage.Open();



        Data o;

        o = null;


        if (storage.Status == 0)
        {
            StreamStream stream;

            stream = storage.Stream;



            long count;

            count = stream.Count;



            byte[] d;

            d = new byte[count];



            Data data;

            data = new Data();

            data.Init();


            data.Value = d;



            Range range;

            range = new Range();

            range.Init();

            range.Start = 0;

            range.End = count;




            stream.Read(data, range);



            if (stream.Status == 0)
            {
                o = data;
            }
        }


        storage.Close();


        storage.Final();



        return o;
    }






    public virtual bool WriteData(string filePath, Data data, Range range)
    {
        Storage storage;

        storage = new Storage();

        storage.Init();


        Mode mode;

        mode = new Mode();

        mode.Init();

        mode.Write = true;



        storage.Path = filePath;

        storage.Mode = mode;


        storage.Open();



        bool o;

        o = false;


        if (storage.Status == 0)
        {
            StreamStream stream;

            stream = storage.Stream;




            stream.Write(data, range);




            if (stream.Status == 0)
            {
                o = true;
            }
    }



        storage.Close();


        storage.Final();



        return o;
    }





    public virtual string ReadText(string filePath)
    {
        Data data;


        data = this.ReadData(filePath);



        if (data == null)
        {
            return null;
        }




        TextEncode encode;

        encode = new TextEncode();

        encode.Kind = this.TextEncodeKindUtf8;

        encode.Init();




        int ka;

        ka = encode.GetTextCountMax(data.Count);




        TextSpan span;
        
        span = this.TextInfra.SpanCreate(ka);




        Range range;

        range = new Range();

        range.Init();

        range.End = data.Count;




        int kb;

        kb = encode.GetText(span, data, range);




        encode.Final();




        int count;

        count = kb;




        string a;


        a = new string(span.Data, span.Range.Start, count);



        return a;
    }







    public virtual bool WriteText(string filePath, string text)
    {
        TextEncode encode;

        encode = new TextEncode();

        encode.Kind = this.TextEncodeKindUtf8;

        encode.Init();





        TextSpan span;

        span = this.TextInfra.SpanCreateString(text);


        

        int kk;

        kk = this.InfraInfra.Count(span.Range);




        long ka;

        ka = encode.GetDataCountMax(kk);





        Data data;

        data = new Data();

        data.Init();


        data.Value = new byte[ka];




        long kb;
        
        kb = encode.GetData(data, 0, span);




        encode.Final();




        long count;

        count = kb;
        



        Range range;

        range = new Range();

        range.Init();

        range.End = count;




        bool o;


        o = this.WriteData(filePath, data, range);



        return o;
    }
}