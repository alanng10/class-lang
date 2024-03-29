namespace Class.Token;



public class Create : InfraCreate
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

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

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual CountCreateOperate CountCreateOperate { get; set; }
    protected virtual SetCreateOperate SetCreateOperate { get; set; }
    protected virtual CreateOperate CreateOperate { get; set; }
    protected virtual Array CodeArray { get; set; }
    protected virtual Array CodeCountArray { get; set; }
    protected virtual Text SourceText { get; set; }

    public virtual Code Code { get; set; }
    public virtual SourceItem SourceItem { get; set; }
    public virtual TextRange Range { get; set; }
    public virtual int TokenIndex { get; set; }
    public virtual int CommentIndex { get; set; }
    public virtual int CodeTokenIndex { get; set; }
    public virtual int CodeCommentIndex { get; set; }

    public override bool Execute()
    {
        this.Result = new Result();
        this.Result.Init();

        this.CodeArray = this.CodeArrayCreate();

        this.Result.Code = this.CodeArray;
        this.Result.Error = this.ListInfra.ArrayCreate(0);

        this.CodeCountArray = this.CodeCountArrayCreate();

        this.CreateOperate = this.CountCreateOperate;

        this.TokenIndex = 0;
        this.CommentIndex = 0;

        this.ExecuteStage();

        int tokenCount;
        int commentCount;
        tokenCount = this.TokenIndex;
        commentCount = this.CommentIndex;

        Array tokenArray;
        tokenArray = this.ListInfra.ArrayCreate(tokenCount);

        Array commentArray;
        commentArray = this.ListInfra.ArrayCreate(commentCount);

        this.SetTokenArray(tokenArray);
        this.SetCommentArray(commentArray);

        this.CreateOperate = this.SetCreateOperate;

        this.TokenIndex = 0;
        this.CommentIndex = 0;
        
        this.ExecuteStage();

        return true;
    }


    protected virtual bool ExecuteStage()
    {
        int count;
        count = this.CodeArray.Count;

        int i;
        i = 0;
        while (i < count)
        {
            Code code;
            code = (Code)this.CodeArray.Get(i);

            this.SourceItem = (SourceItem)this.Source.Item.Get(i);

            this.CodeTokenIndex = 0;
            this.CodeCommentIndex = 0;

            this.ExecuteCode(code);

            CodeCount codeCount;
            codeCount = (CodeCount)this.CodeCountArray.Get(i);
            codeCount.Token = this.CodeTokenIndex;
            codeCount.Comment = this.CodeCommentIndex;

            i = i + 1;
        }

        return true;
    }


    protected virtual bool ExecuteCode(Code code)
    {
        this.Code = code;


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

            Data data;
            data = line.Data;


            int colCount;


            colCount = line.Count;



            col = 0;



            while (col < colCount)
            {
                bool isValid;


                isValid = false;



                char c;

                c = this.TextInfra.CharGet(data, col);



                if (c == '#')
                {
                    this.EndToken(col);



                    this.Range.Row = row;


                    this.Range.Col.Index = col;


                    this.Range.Col.Count = this.ClassInfra.Count(col, colCount);



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

                    this.Range.Col.Index = col;




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
                        oc = this.TextInfra.CharGet(data, cc);



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
                    


                    
                    this.Range.Col.Count = this.ClassInfra.Count(this.Range.Col.Index, cc);

                    


                    this.AddToken();


                    col = cc;


                    this.Reset();




                    isValid = true;
                }

                    

                if (this.TextInfra.IsUpperLetter(c) | this.TextInfra.IsLowerLetter(c) | this.TextInfra.IsDigit(c) | c == '_')
                {
                    if (this.NullRange())
                    {
                        this.Range.Row = row;


                        this.Range.Col.Index = col;
                    }



                    col = col + 1;



                    isValid = true;
                }



                if (!isValid)
                {
                    this.EndToken(col);



                    this.Range.Row = row;


                    this.Range.Col.Index = col;


                    this.Range.Col.Count = 1;
                    
                    

                    this.AddToken();



                    col = col + 1;



                    this.Reset();
                }
            }




            this.EndToken(col);



            this.Reset();




            row = row + 1;
        }
        




        return true;
    }

    protected virtual Array CodeArrayCreate()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Source.Item.Count);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Code code;
            code = new Code();
            code.Init();

            array.Set(i, code);

            i = i + 1;
        }

        return array;
    }

    protected virtual Array CodeCountArrayCreate()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.CodeArray.Count);

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            CodeCount code;
            code = new CodeCount();
            code.Init();

            array.Set(i, code);

            i = i + 1;
        }

        return array;
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
            count = this.ClassInfra.Count(this.Range.Col.Index, col);
            this.Range.Col.Count = count;
            this.AddToken();
        }
        return true;
    }






    protected virtual bool NullRange()
    {
        return this.Range.Row == -1;
    }





    protected virtual bool SetRangeNull(TextRange range)
    {
        range.Row = -1;


        return true;
    }




    protected virtual bool Reset()
    {
        this.SetRangeNull(this.Range);
        



        return true;
    }
}