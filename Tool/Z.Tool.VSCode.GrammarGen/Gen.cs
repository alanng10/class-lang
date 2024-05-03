namespace Z.Tool.VSCode.GrammarGen;

public class Gen : Any
{
    public override bool Init()
    {
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    protected virtual ToolInfra ToolInfra { get; set; }

    public virtual int Execute()
    {
        string keywordA;
        keywordA = this.ToolInfra.StorageTextRead("ToolData/VSCode/Keyword.txt");

        string wordClassKeywordA;
        wordClassKeywordA = this.ToolInfra.StorageTextRead("ToolData/VSCode/WordClassKeyword.txt");

        string nameA;
        nameA = this.ToolInfra.StorageTextRead("ToolData/VSCode/Name.txt");

        string classNameA;
        classNameA = this.ToolInfra.StorageTextRead("ToolData/VSCode/ClassName.txt");




        StringBuilder sa;

        sa = new StringBuilder();


        sa.Append(nameA);


        sa.Replace("#Keyword#", keywordA);



        string oo;

        oo = sa.ToString();




        StringBuilder sb;

        sb = new StringBuilder();


        sb.Append(classNameA);


        sb.Replace("#WordClassKeyword#", wordClassKeywordA);


        sb.Replace("#Name#", oo);




        string ka;

        ka = sb.ToString();



        string k;

        k = ka.Replace("\\", "\\\\");



        string outputFilePath;

        outputFilePath = this.GetFilePath("ClassNameRegexString.txt");



        this.WriteTextFile(outputFilePath, k);





        return 0;
    }
}