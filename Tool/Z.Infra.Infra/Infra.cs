namespace Z.Infra.Infra;




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



        this.NewLine = "\n";




        return true;
    }





    public virtual string NewLine { get; set; }






    public virtual bool AppendIndent(StringBuilder sb, int indent)
    {
        int count;

        count = indent;



        int i;

        i = 0;


        while (i < count)
        {
            sb.Append("    ");



            i = i + 1;
        }


        return true;
    }






    public virtual string ReadTextFile(string filePath)
    {
        string a;

        a = File.ReadAllText(filePath);


        return a;
    }





    public virtual bool WriteTextFile(string filePath, string text)
    {
        File.WriteAllText(filePath, text);


        return true;
    }





    public virtual Array SplitLineList(string text)
    {
        string[] a;


        a = text.Split('\n', StringSplitOption.None);





        Array array;

        array = new Array();

        array.Count = a.Length;

        array.Init();





        int count;

        count = array.Count;



        int i;

        i = 0;


        while (i < count)
        {
            string aa;


            aa = a[i];




            array.Set(i, aa);



            i = i + 1;
        }




        return array;
    }






    public virtual bool GetBool(string a)
    {
        bool b;


        b = false;



        if (!(a == "false"))
        {
            b = true;
        }



        return b;
    }





    public virtual string GetBoolString(bool a)
    {
        string u;


        u = "false";




        if (a)
        {
            u = "true";
        }




        return u;
    }
}