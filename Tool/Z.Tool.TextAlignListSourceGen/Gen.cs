namespace Z.Tool.TextAlignListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Avalon.Draw";


        this.ClassName = "TextAlignList";


        this.BaseClassName = "Any";


        this.ItemClassName = "TextAlign";


        this.ArrayClassName = "Array";




        this.Export = true;




        this.InitMethodFileName = "InitMethodTextAlign.txt";


        this.AddMethodFileName = "AddMethodTextAlign.txt";



        this.OutputFilePath = "../../Avalon.Draw/TextAlignList.cs";





        return true;
    }





    protected override bool ExecuteItemList()
    {
        StringCompare compare;

        compare = new StringCompare();

        compare.Init();




        this.ItemTable = new Table();

        this.ItemTable.Compare = compare;

        this.ItemTable.Init();



        Array horzAlign;

        horzAlign = new Array();

        horzAlign.Count = 3;

        horzAlign.Init();


        this.AlignArray = horzAlign;

        this.Index = 0;


        this.AddAlign("Left", "Left");

        this.AddAlign("Right", "Right");

        this.AddAlign("Center", "HCenter");



        Array vertAlign;

        vertAlign = new Array();

        vertAlign.Count = 3;

        vertAlign.Init();


        this.AlignArray = vertAlign;

        this.Index = 0;


        this.AddAlign("Up", "Top");

        this.AddAlign("Down", "Bottom");

        this.AddAlign("Center", "VCenter");




        int countA;

        countA = horzAlign.Count;


        int ia;

        ia = 0;


        while (ia < countA)
        {
            Entry aa;

            aa = (Entry)horzAlign.Get(ia);



            int countB;

            countB = vertAlign.Count;


            int ib;

            ib = 0;


            while (ib < countB)
            {
                Entry ab;

                ab = (Entry)vertAlign.Get(ib);



                string index;

                index = aa.Name + ab.Name;



                Value value;

                value = new Value();

                value.Init();

                value.HorzAlign = aa.Intern;

                value.VertAlign = ab.Intern;





                TableEntry entry;

                entry = new TableEntry();

                entry.Init();

                entry.Index = index;

                entry.Value = value;




                this.ItemTable.Add(entry);




                ib = ib + 1;
            }


            ia = ia + 1;
        }




        return true;
    }




    protected virtual Entry CreateEntry(string name, string intern)
    {
        Entry a;

        a = new Entry();

        a.Init();

        a.Name = name;

        a.Intern = intern;


        return a;
    }




    protected virtual Array AlignArray { get; set; }



    protected virtual int Index { get; set; }




    protected virtual bool AddAlign(string name, string intern)
    {
        Entry entry;

        entry = this.CreateEntry(name, intern);



        this.AlignArray.Set(this.Index, entry);



        this.Index = this.Index + 1;



        return true;
    }






    protected override bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        Value a;

        a = (Value)value;




        sb.Append("AddItem")
            .Append("(")
            .Append("Extern.Stat_TextAlign" + a.HorzAlign).Append("(").Append("stat").Append(")").Append(",").Append(" ")
            .Append("Extern.Stat_TextAlign" + a.VertAlign).Append("(").Append("stat").Append(")")
            .Append(")");





        return true;
    }
}