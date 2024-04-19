namespace Z.Tool.NodeListSourceGen;






public class NodeStateGen : Any
{
    public override bool Init()
    {
        base.Init();




        this.ToolInfra = ToolInfra.This;




        return true;
    }




    protected virtual ToolInfra ToolInfra { get; set; }




    public virtual Array ClassArray { get; set; }





    public virtual int Execute()
    {
        this.NodeStateSourceFileName = "NodeStateSource.txt";



        this.OutputFoldPath = "../../Class/Class.Node";





        string kk;

        kk = this.ToolInfra.ReadTextFile(this.NodeStateSourceFileName);




        int count;

        count = this.ClassArray.Count;


        int i;

        i = 0;


        while (i < count)
        {
            Class varClass;

            varClass = (Class)this.ClassArray.Get(i);


            
            string kind;

            kind = varClass.Name;



            string k;

            k = kk.Replace("#NodeKind#", kind);



            string path;

            path = this.GetOutputFilePath(kind);




            this.ToolInfra.WriteTextFile(path, k);



            i = i + 1;
        }





        return 0;
    }





    private string OutputFoldPath { get; set; }



    private string NodeStateSourceFileName { get; set; }




    private string GetOutputFilePath(string kind)
    {
        string fileName;

        fileName = "Z_NodeState_" + kind + ".cs";



        string filePath;

        filePath = this.OutputFoldPath + "/" + fileName;



        return filePath;
    }
}