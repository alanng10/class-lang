namespace Z.Tool.ClassNameRegexStringGen;






public class Gen : Any
{
    public virtual int Execute()
    {
        string keywordA;

        keywordA = this.ReadRegexTextFile("Keyword.txt");



        string wordClassKeywordA;

        wordClassKeywordA = this.ReadRegexTextFile("WordClassKeyword.txt");



        string nameA;

        nameA = this.ReadRegexTextFile("Name.txt");



        string classNameA;

        classNameA = this.ReadRegexTextFile("ClassName.txt");




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





    private string GetFilePath(string fileName)
    {
        return "../../../ClassVSCode/" + fileName;
    }




    private string ReadRegexTextFile(string fileName)
    {
        string filePath;

        filePath = this.GetFilePath(fileName);


        return this.ReadTextFile(filePath);
    }






    protected virtual string ReadTextFile(string filePath)
    {
        string a;

        a = File.ReadAllText(filePath);


        return a;
    }





    protected virtual bool WriteTextFile(string filePath, string text)
    {
        File.WriteAllText(filePath, text);


        return true;
    }
}