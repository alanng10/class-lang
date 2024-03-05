namespace Class.Test;




public class Test : Any
{
    public override bool Init()
    {
        base.Init();


        this.InfraInfra = InfraInfra.This;



        this.LangName = this.LanguageName();




        this.UnitIndex = 0;




        this.PassCount = 0;






        this.TestFold = "Test";






        this.Spaces = new string(' ', 4);


        

        
        this.Class = this.CreateClass();






        string newCurrentDirectory = this.CurrentDirectory();



        Directory.SetCurrentDirectory(newCurrentDirectory);





        this.OriginalCurrentDirectory = Directory.GetCurrentDirectory();








        StringCompare compare;


        compare = new StringCompare();


        compare.Init();





        this.FoldSetMap = new Table();



        this.FoldSetMap.Compare = compare;



        this.FoldSetMap.Init();





        this.AddSets();




        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }





    protected virtual string CurrentDirectory()
    {
        return "../../../../Class.Test";
    }





    protected virtual bool AddSets()
    {
        TaskKindList kindList;


        kindList = TaskKindList.This;




        this.AddSet("Token", kindList.Token, false, false, false);



        this.AddSet("Node", kindList.Node, true, false, false);
        




        return true;
    }






    protected bool AddSet(string name, TaskKind kind, bool addKindAfterTaskArg, bool addPathAfterTaskArg, bool sourceFold)
    {
        Set set;




        set = new Set();





        set.Name = name;





        set.Kind = kind;






        set.AddKindAfterTaskArg = addKindAfterTaskArg;





        set.AddPathAfterTaskArg = addPathAfterTaskArg;





        set.SourceFold = sourceFold;






        TableEntry pair;


        pair = new TableEntry();


        pair.Init();


        pair.Index = set.Name;


        pair.Value = set;




        this.FoldSetMap.Add(pair);



        return true;
    }




    private string LangName { get; set; }






    private string TestFold { get; set; }


    private List UnitList { get; set; }




    private Table FoldSetMap { get; set; }


    private Set Set { get; set; }


    private Unit TestUnit { get; set; }


    private int PassCount { get; set; }


    private ClassClass Class { get; set; }


    private string UnitFold { get; set; }


    private Exception Error { get; set; }


    private StringWriter Writer { get; set; }




    private string OriginalCurrentDirectory { get; set; }





    private string Spaces { get; set; }






    private int UnitIndex { get; set; }






    private bool UnitPass { get; set; }





    


    public int Execute()
    {
        this.ExecuteSets();



        return 0;
    }

    



    private bool ExecuteSets()
    {
        Iter iter;

        iter = this.FoldSetMap.IterCreate();


        this.FoldSetMap.IterSet(iter);



        while (iter.Next())
        {
            this.Set = (Set)iter.Value;




            this.AddFoldSetUnits();



            this.ExecuteFoldSet();



            this.Set = null;
        }



        return true;
    }



    private bool AddFoldSetUnits()
    {
        this.UnitList = new List();



        this.UnitList.Init();






        string set;

        set = this.Set.Name;

        
        

        string setFold;
            
        setFold = this.TestFold + this.InfraInfra.PathCombine + set;





        Array kindList;

        kindList = this.GetFoldList(setFold);



        Iter kindIter;

        kindIter = kindList.IterCreate();


        kindList.IterSet(kindIter);

    

        while (kindIter.Next())
        {
            string kind;

            kind = (string)kindIter.Value;




            string kindFold;


            kindFold = setFold + this.InfraInfra.PathCombine + kind;




            Array unitList;
            
            unitList = this.GetFoldList(kindFold);





            Iter unitIter;

            unitIter = unitList.IterCreate();


            unitList.IterSet(unitIter);




            while (unitIter.Next())
            {
                string unit;


                unit = (string)unitIter.Value;




                string unitFold;
                

                unitFold = kindFold + this.InfraInfra.PathCombine + unit;




                string expectFile;
                
                
                expectFile = unitFold + this.InfraInfra.PathCombine + "Expect";


                


                string expect;
                
                
                
                expect = File.ReadAllText(expectFile);






                string path;



                path = null;



                if (this.Set.AddPathAfterTaskArg)
                {
                    string pathFile;


                    pathFile = unitFold + this.InfraInfra.PathCombine + "Path";




                    path = File.ReadAllText(pathFile);
                }
                




                Unit testUnit;


                testUnit = new Unit();


                testUnit.Set = this.Set;


                testUnit.Kind = kind;


                testUnit.Name = unit;


                testUnit.Expect = expect;



                testUnit.Path = path;




                this.UnitList.Add(testUnit);
            }
        }




        return true;
    }




    private bool ExecuteFoldSet()
    {
        this.WriteHeader(this.Set.Name);





        this.PassCount = 0;



        this.UnitIndex = 0;




        Iter iter;

        iter = this.UnitList.IterCreate();
        

        this.UnitList.IterSet(iter);



        while (iter.Next())
        {
            this.TestUnit = (Unit)iter.Value;



            this.ExecuteTestUnit();



            this.WriteFoldResult();



            this.TestUnit = null;



            this.UnitIndex = this.UnitIndex + 1;
        }




        this.WriteTotalResult();




        return true;
    }








    private bool ExecuteTestUnit()
    {
        this.UnitFold = this.TestFold + "/" + this.TestUnit.Set.Name + "/" + this.TestUnit.Kind + "/" + this.TestUnit.Name;



        this.Writer = new StringWriter();





        Directory.SetCurrentDirectory(this.UnitFold);







        Task task;



        task = this.CreateTask();



        this.Class.Task = task;
    


        this.Class.Execute();




        Directory.SetCurrentDirectory(this.OriginalCurrentDirectory);





        string actual;
        

        actual = this.Writer.ToString();




        string actualFile;
        

        actualFile = this.UnitFold + "/" + "Actual";




        File.WriteAllText(actualFile, actual);



        this.TestUnit.Actual = actual;





        bool pass;

        pass = (this.TestUnit.Actual == this.TestUnit.Expect);




        this.UnitPass = pass;




        return true;
    }





    protected virtual string LanguageName()
    {
        return "Class";
    }






    private bool WriteFoldResult()
    {
        this.WriteResult(this.UnitPass, this.TestUnit.Set.Name, this.TestUnit.Kind, this.TestUnit.Name);



        return true;
    }






    private bool WriteResult(bool pass, string set, string kind, string unit)
    {
        string a;



        a = null;




        bool b;


        b = pass;



        if (b)
        {
            a = "Pass";


            this.PassCount = this.PassCount + 1;
        }
        


        if (!b)
        {
            a = "Fail";
        }






        string u;

        u = string.Format("{0,-8}", set);




        string k;

        k = string.Format("{0,-24}", kind);




        string j;


        j = unit;





        int number;


        number = (this.UnitIndex + 1);




        string p;


        p = number.ToString("D3");





        string s;



        s = p + this.Spaces + a + this.Spaces + u + this.Spaces + k + " " + j;




        Console.WriteLine(s);




        return true;
    }






    private bool WriteTotalResult()
    {
        string t;



        int unitCount;



        unitCount = this.UnitIndex;
        



        if (this.PassCount == unitCount)
        {
            t = "All";
        }
        else
        {
            t = this.PassCount.ToString();
        }



        Console.WriteLine(t + " " + "Pass");




        return true;
    }





    private bool WriteHeader(string setName)
    {
        string s;


        s = this.LangName.ToUpper();




        string k;


        k = setName.ToUpper();




        Console.WriteLine("==============================" + " " + s + " " + k + " " + "TEST" + " " + "===============================");



        return true;
    }







    private string SourceFold { get; set; }








    private Task CreateTask()
    {
        Task task;


        task = new Task();


        task.Init();




        TaskKind kind;


        kind = this.TestUnit.Set.Kind;





        task.Kind = kind;



        

        bool ba;


        ba = this.Set.AddKindAfterTaskArg;



        if (ba)
        {
            task.Node = this.TestUnit.Kind;
        }



        if (!ba)
        {
            if (!(task.Kind == TaskKindList.This.Token))
            {
                task.Node = "Class";
            }
        }





        if (this.Set.AddPathAfterTaskArg)
        {
            task.Check = this.TestUnit.Path;
        }




        task.Print = true;





        string source;



        source = this.SourceFold;




        bool setSourceFold;



        setSourceFold = this.Set.SourceFold;




        if (setSourceFold)
        {
            source = "Source";
        }




        if (!setSourceFold)
        {
            source = "Code";
        }



        task.Source = source;





        task.Out = this.Writer;


        



        Task ret;
        

        ret = task;
        
        
        return ret;
    }







    protected virtual ClassClass CreateClass()
    {
        ClassClass t;



        t = new ClassClass();



        t.Init();





        ClassClass ret;


        ret = t;


        return ret;
    }







    private Array GetFoldList(string foldPath)
    {
        string[] u;
            
            
        u = Directory.GetDirectories(foldPath);




        int count;

        count = u.Length;


        int i;

        i = 0;


        while (i < count)
        {
            string path;

            path = u[i];



            string name;

            name = Path.GetFileName(path);



            u[i] = name;



            i = i + 1;
        }





        StringComparer comparer;


        comparer = new StringComparer();


        comparer.Init();




        SystemArray.Sort<string>(u, comparer);





        Array array;

        array = new Array();

        array.Count = u.Length;

        array.Init();




        count = array.Count;



        i = 0;



        while (i < count)
        {
            string k;

            k = u[i];


            array.Set(i, k);


            i = i + 1;
        }




        return array;
    }
}