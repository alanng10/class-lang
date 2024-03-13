namespace Class.Token;



public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();





        this.InfraInfra = InfraInfra.This;




        TextInfra textInfra;

        textInfra = TextInfra.This;



        this.TextInfra = textInfra;





        this.IntNull = -1;





        this.CountCreateOperate = new CountCreateOperate();


        this.CountCreateOperate.Create = this;


        this.CountCreateOperate.Init();






        this.SetCreateOperate = new SetCreateOperate();


        this.SetCreateOperate.Create = this;


        this.SetCreateOperate.Init();






        this.Range = new TextRange();


        this.Range.Init();


        this.Range.Col = new InfraRange();


        this.Range.Col.Init();






        return true;
    }






    public virtual Source Source { get; set; }






    public virtual Result Result { get; set; }







    public virtual InfraInfra InfraInfra { get; set; }




    protected virtual TextInfra TextInfra { get; set; }






    protected virtual CountCreateOperate CountCreateOperate { get; set; }




    protected virtual SetCreateOperate SetCreateOperate { get; set; }






    protected virtual Array CodeArray { get; set; }




    protected virtual List ErrorList { get; set; }




    protected virtual Text SourceText { get; set; }





    public virtual Code Code { get; set; }




    public virtual SourceItem SourceItem { get; set; }




    protected virtual CreateOperate CreateOperate { get; set; }





    public virtual TextRange Range { get; set; }







    public virtual int TokenIndex { get; set; }



    public virtual int CommentIndex { get; set; }




    

    protected virtual int IntNull { get; set; }







    public override bool Execute()
    {
        this.Result = new Result();



        this.Result.Init();





        Array codeArray;
        


        codeArray = new Array();



        codeArray.Count = this.Source.Item.Count;



        codeArray.Init();




        this.CodeArray = codeArray;





        
        
        Array a;
        
        a = new Array();

        a.Count = 0;

        a.Init();




        this.Result.Code = this.CodeArray;



        this.Result.Error = a;






        this.ExecuteCodeArray();




        return true;
    }







    protected virtual bool ExecuteCodeArray()
    {
        int count;


        count = this.CodeArray.Count;



        int i;


        i = 0;


        while (i < count)
        {
            Code code;


            code = new Code();



            code.Init();




            this.CodeArray.Set(i, code);



            this.Code = code;




            this.SourceItem = (SourceItem)this.Source.Item.Get(i);
            

        





            this.CreateOperate = this.CountCreateOperate;



            this.TokenIndex = 0;


            this.CommentIndex = 0;




            this.ExecuteCode();
            





            Array tokenArray;


            tokenArray = new Array();


            tokenArray.Count = this.TokenIndex;


            tokenArray.Init();





            Array commentArray;


            commentArray = new Array();


            commentArray.Count = this.CommentIndex;


            commentArray.Init();





            this.SetTokenArray(tokenArray);



            this.SetCommentArray(commentArray);





            this.Code.Token = tokenArray;


            this.Code.Comment = commentArray;






            this.CreateOperate = this.SetCreateOperate;




            this.TokenIndex = 0;


            this.CommentIndex = 0;





            this.ExecuteCode();






            i = i + 1;
        }



        return true;
    }





    protected virtual bool ExecuteCode()
    {
        this.SourceText = this.SourceItem.Text;




        this.SetRangeNull(this.Range);





        int row;

        row = 0;


        int col;

        col = 0;




        int count;

        count = this.SourceText.Count;




        while (row < count)
        {
            Line line;

            line = this.SourceText.GetLine(row);




            int colCount;


            colCount = line.Count;



            col = 0;



            while (col < colCount)
            {
                bool isValid;


                isValid = false;



                char c;

                c = line.Value[col];



                if (c == '#')
                {
                    this.EndToken(col);



                    this.Range.Row = row;


                    this.Range.Col.Index = col;


                    this.Range.Col.Count = this.InfraInfra.Count(col, colCount);



                    this.AddComment();



                    col = colCount;



                    this.Reset();




                    isValid = true;
                }



                if (c == ' ')
                {
                    this.EndToken(col);


                    col = col + 1;


                    this.Reset();



                    isValid = true;
                }



                if (c == '\"')
                {
                    this.EndToken(col);
                    


                    this.Range.Row = row;

                    this.Range.Col.Start = col;




                    int cc;

                    cc = col + 1;


                    

                    bool ba;


                    bool bb;



                    bool b;

                    b = false;



                    int uu;


                    
                    char oc;
                    

                    

                    while (!b & cc < colCount)
                    {
                        oc = line.Value[cc];



                        ba = (oc == '\"');



                        if (ba)
                        {
                            b = true;
                        }




                        
                        if (!b)
                        {
                            bb = (oc == '\\');



                            if (bb)
                            {
                                uu = cc + 1;



                                if (uu < colCount)
                                {
                                    cc = cc + 1;
                                }
                            }
                        }
                        


                        cc = cc + 1;
                    }
                    


                    
                    this.Range.Col.End = cc;

                    


                    this.AddToken();


                    col = this.Range.Col.End;


                    this.Reset();




                    isValid = true;
                }

                    

                if (this.TextInfra.IsUpperLetter(c) | this.TextInfra.IsLowerLetter(c) | this.TextInfra.IsDigit(c) | c == '_')
                {
                    if (this.NullRange())
                    {
                        this.Range.Row = row;


                        this.Range.Col.Start = col;
                    }



                    col = col + 1;



                    isValid = true;
                }



                if (!isValid)
                {
                    this.EndToken(col);



                    this.Range.Row = row;


                    this.Range.Col.Start = col;


                    this.Range.Col.End = this.Range.Col.Start + 1;
                    
                    

                    this.AddToken();



                    col = this.Range.Col.End;



                    this.Reset();
                }
            }




            this.EndToken(col);



            this.Reset();




            row = row + 1;
        }
        




        return true;
    }






    protected virtual bool SetTokenArray(Array array)
    {
        int count;

        count = array.Count;



        int i;

        i = 0;


        while (i < count)
        {
            Token token;

            token = new Token();

            token.Init();


            token.Range = new TextRange();

            token.Range.Init();


            token.Range.Col = new InfraRange();

            token.Range.Col.Init();



            array.Set(i, token);



            i = i + 1;
        }


        return true;
    }






    protected virtual bool SetCommentArray(Array array)
    {
        int count;

        count = array.Count;



        int i;

        i = 0;


        while (i < count)
        {
            Comment comment;

            comment = new Comment();

            comment.Init();


            comment.Range = new TextRange();

            comment.Range.Init();


            comment.Range.Col = new InfraRange();

            comment.Range.Col.Init();



            array.Set(i, comment);



            i = i + 1;
        }


        return true;
    }






    protected virtual bool AddToken()
    {
        this.CreateOperate.ExecuteToken();



        return true;
    }





    protected virtual bool AddComment()
    {
        this.CreateOperate.ExecuteComment();


        return true;
    }
    





    protected virtual bool EndToken(int col)
    {
        if (!this.NullRange())
        {
            int count;
            count = this.InfraInfra.Count(this.Range.Col.Index, col);
            this.Range.Col.Count = count;
            this.AddToken();
        }
        return true;
    }






    protected virtual bool NullRange()
    {
        return this.Range.Row == this.IntNull;
    }





    protected virtual bool SetRangeNull(TextRange range)
    {
        range.Row = this.IntNull;


        return true;
    }




    protected virtual bool Reset()
    {
        this.SetRangeNull(this.Range);
        



        return true;
    }
}