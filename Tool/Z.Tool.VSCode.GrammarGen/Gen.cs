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


        string o;
        o = nameA;
        o = o.Replace("#Keyword#", keywordA);

        string oa;
        oa = classNameA;
        oa = oa.Replace("#WordClassKeyword#", wordClassKeywordA);
        oa = oa.Replace("#Name#", o);

        string k;
        k = oa.Replace("\\", "\\\\");



        string outputFilePath;

        outputFilePath = this.GetFilePath("ClassNameRegexString.txt");



        this.WriteTextFile(outputFilePath, k);





        return 0;
    }
}