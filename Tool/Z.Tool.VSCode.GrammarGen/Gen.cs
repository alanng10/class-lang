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
        string keyword;
        keyword = this.ToolInfra.StorageTextRead("ToolData/VSCode/Keyword.txt");

        string wordClassKeyword;
        wordClassKeyword = this.ToolInfra.StorageTextRead("ToolData/VSCode/WordClassKeyword.txt");

        string name;
        name = this.ToolInfra.StorageTextRead("ToolData/VSCode/Name.txt");

        string className;
        className = this.ToolInfra.StorageTextRead("ToolData/VSCode/ClassName.txt");


        string o;
        o = name;
        o = o.Replace("#Keyword#", keyword);

        string oa;
        oa = className;
        oa = oa.Replace("#WordClassKeyword#", wordClassKeyword);
        oa = oa.Replace("#Name#", o);
        oa = oa.Replace("\\", "\\\\");

        string classNameRegexString;
        classNameRegexString = oa;

        string ob;
        ob = keyword;
        ob = ob.Replace("\\", "\\\\");

        string keywordRegexString;
        keywordRegexString = ob;

        string grammar;
        grammar = this.ToolInfra.StorageTextRead("ToolData/VSCode/Grammar.txt");

        string k;
        k = grammar;
        k = k.Replace("#KeywordRegexString#", keywordRegexString);
        k = k.Replace("#ClassNameRegexString#", classNameRegexString);

        string outputFilePath;
        outputFilePath = "../../VSCode/class-lang-vscode-ext/syntaxes/class.tmLanguage.json";

        this.ToolInfra.StorageTextWrite(outputFilePath, k);
        return 0;
    }
}