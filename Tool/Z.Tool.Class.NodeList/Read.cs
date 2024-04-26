namespace Z.Tool.Class.NodeList;





class Read : Any
{
    public override bool Init()
    {
        base.Init();



        this.ListInfra = ListInfra.This;




        return true;
    }




    public virtual int Execute()
    {
        bool b;

        b = this.SetClassArray();


        if (!b)
        {
            return 1;
        }


        return 0;
    }





    public virtual Array ClassArray { get; set; }





    protected virtual ListInfra ListInfra { get; set; }




    protected virtual List ClassList { get; set; }


    protected virtual Class Class { get; set; }






    protected virtual List FieldList { get; set; }









    protected virtual bool SetClassArray()
    {
        ToolInfra infra;

        infra = ToolInfra.This;



        string ka;

        ka = infra.StorageTextRead("NodeList.txt");



        Array lineArray;
        
        lineArray = infra.SplitLineList(ka);




        this.ClassList = new List();

        this.ClassList.Init();




        int count;

        count = lineArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            string line;


            line = (string)lineArray.Get(i);



            bool b;

            b = this.SetClassArrayOneLine(line);


            if (!b)
            {
                return false;
            }




            i = i + 1;
        }



        this.EndCurrentClass();




        this.ClassArray = this.ListInfra.ArrayCreateList(this.ClassList);




        this.ClassList = null;




        return true;
    }





    protected virtual bool SetClassArrayOneLine(string line)
    {
        if (line.Length == 0)
        {
            return true;
        }


        string oo;

        oo = "    ";


        bool b;

        b = line.StartsWith(oo);


        if (!b)
        {
            this.EndCurrentClass();





            Class varClass;

            varClass = this.GetClass(line);


            if (varClass == null)
            {
                return false;
            }



            this.Class = varClass;



            this.ClassList.Add(this.Class);



            this.FieldList = new List();

            this.FieldList.Init();
        }


        if (b)
        {
            string compLine;

            compLine = line.Substring(oo.Length);



            Field ob;

            ob = this.GetField(compLine);


            if (ob == null)
            {
                return false;
            }



            List list;

            list = this.FieldList;



            list.Add(ob);
        }



        return true;
    }




    protected virtual bool EndCurrentClass()
    {
        if (this.Class == null)
        {
            return true;
        }



        this.Class.Field = this.ListInfra.ArrayCreateList(this.FieldList);



        this.Class = null;


        this.FieldList = null;


        return true;
    }






    protected virtual Class GetClass(string a)
    {
        string uo;

        uo = " : ";



        int uu;

        uu = a.IndexOf(uo);


        if (uu < 0)
        {
            return null;
        }



        string className;

        className = a.Substring(0, uu);



        string baseClassName;

        baseClassName = a.Substring(uu + uo.Length);





        Class varClass;

        varClass = new Class();

        varClass.Init();

        varClass.Name = className;

        varClass.Base = baseClassName;



        return varClass;
    }





    protected virtual Field GetField(string a)
    {
        int uu;

        uu = a.IndexOf(' ');


        if (uu < 0)
        {
            return null;
        }



        string className;

        className = a.Substring(0, uu);



        string fieldName;

        fieldName = a.Substring(uu + 1);



        Field o;

        o = new Field();

        o.Init();

        o.Class = className;

        o.Name = fieldName;


        return o;
    }
}