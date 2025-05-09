class Add : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share TextInfra;
        this.StringComp : share StringComp;

        this.Format : this.CreateFormat();
        this.FormatArg : this.CreateFormatArg();
        this.IntParse : this.CreateIntParse();
        this.StringAdd : this.CreateStringAdd();
        this.TForm : this.CreateTextForm();
        this.ILess : this.CreateIntLess();
        this.TLess : this.CreateTextLess();
        this.SLess : this.CreateStringLess();

        this.TextA : this.CreateText();
        this.TextB : this.CreateText();
        this.TextC : this.CreateText();
        this.TextD : this.CreateText();
        this.TextE : this.CreateText();
        this.TextF : this.CreateText();

        this.StringDataA : this.CreateStringData();
        this.StringDataB : this.CreateStringData();
        this.StringDataC : this.CreateStringData();
        this.StringDataD : this.CreateStringData();
        this.StringDataE : this.CreateStringData();
        this.StringDataF : this.CreateStringData();

        this.TRangeA : this.CreateRange();

        this.SSpace : " ";
        this.SIndent : this.CreateIndent();
        return true;
    }

    maide precate Format CreateFormat()
    {
        var Format a;
        a : new Format;
        a.Init();
        return a;
    }

    maide precate FormatArg CreateFormatArg()
    {
        var FormatArg a;
        a : new FormatArg;
        a.Init();
        return a;
    }

    maide precate IntParse CreateIntParse()
    {
        var IntParse a;
        a : new IntParse;
        a.Init();
        return a;
    }

    maide precate StringAdd CreateStringAdd()
    {
        var StringAdd a;
        a : new StringAdd;
        a.Init();
        return a;
    }

    maide precate TextForm CreateTextForm()
    {
        var TextForm a;
        a : new TextForm;
        a.Init();
        return a;
    }

    maide precate IntLess CreateIntLess()
    {
        var IntLess a;
        a : new IntLess;
        a.Init();
        return a;
    }

    maide precate TextLess CreateTextLess()
    {
        var TextLess a;
        a : new TextLess;
        a.LiteForm : this.TForm;
        a.RiteForm : this.TForm;
        a.CharLess : this.ILess;
        a.Init();
        return a;
    }

    maide precate StringLess CreateStringLess()
    {
        var StringLess a;
        a : new StringLess;
        a.LiteForm : this.TForm;
        a.RiteForm : this.TForm;
        a.CharLess : this.ILess;
        a.Init();
        return a;
    }

    maide precate Text CreateText()
    {
        var Text a;
        a : new Text;
        a.Init();
        a.Range : new Range;
        a.Range.Init();
        return a;
    }

    maide precate StringData CreateStringData()
    {
        var StringData a;
        a : new StringData;
        a.Init();
        return a;
    }

    maide precate Range CreateRange()
    {
        var Range a;
        a : new Range;
        a.Init();
        return a;
    }

    maide precate String CreateIndent()
    {
        return this.StringComp.CreateChar(this.Char(this.SSpace), 4);
    }

    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate Format Format { get { return data; } set { data : value; } }
    field precate FormatArg FormatArg { get { return data; } set { data : value; } }
    field precate IntParse IntParse { get { return data; } set { data : value; } }
    field precate StringAdd StringAdd { get { return data; } set { data : value; } }
    field precate TextForm TForm { get { return data; } set { data : value; } }
    field precate TextLess TLess { get { return data; } set { data : value; } }
    field precate StringLess SLess { get { return data; } set { data : value; } }
    field precate IntLess ILess { get { return data; } set { data : value; } }
    field precate Text TextA { get { return data; } set { data : value; } }
    field precate Text TextB { get { return data; } set { data : value; } }
    field precate Text TextC { get { return data; } set { data : value; } }
    field precate Text TextD { get { return data; } set { data : value; } }
    field precate Text TextE { get { return data; } set { data : value; } }
    field precate Text TextF { get { return data; } set { data : value; } }
    field precate StringData StringDataA { get { return data; } set { data : value; } }
    field precate StringData StringDataB { get { return data; } set { data : value; } }
    field precate StringData StringDataC { get { return data; } set { data : value; } }
    field precate StringData StringDataD { get { return data; } set { data : value; } }
    field precate StringData StringDataE { get { return data; } set { data : value; } }
    field precate StringData StringDataF { get { return data; } set { data : value; } }
    field precate Range TRangeA { get { return data; } set { data : value; } }
    field precate String SIndent { get { return data; } set { data : value; } }
    field precate String SSpace { get { return data; } set { data : value; } }

    maide prusate Text TA(var String k)
    {
        return this.TextString(k, this.TextA, this.StringDataA);
    }

    maide prusate Text TB(var String k)
    {
        return this.TextString(k, this.TextB, this.StringDataB);
    }

    maide prusate Text TC(var String k)
    {
        return this.TextString(k, this.TextC, this.StringDataC);
    }

    maide prusate Text TD(var String k)
    {
        return this.TextString(k, this.TextD, this.StringDataD);
    }

    maide prusate Text TE(var String k)
    {
        return this.TextString(k, this.TextE, this.StringDataE);
    }

    maide prusate Text TF(var String k)
    {
        return this.TextString(k, this.TextF, this.StringDataF);
    }

    maide prusate Text TextString(var String k, var Text text, var StringData data)
    {
        data.ValueString : k;

        text.Data : data;
        text.Range.Index : 0;
        text.Range.Count : this.StringCount(k);
        return text;
    }

    maide prusate Bool ClearText(var Text text)
    {
        text.Data : null;
        return true;
    }

    maide prusate Bool ClearStringData(var StringData stringData)
    {
        stringData.ValueString : null;
        return true;
    }

    maide prusate Bool ClearData()
    {
        this.ClearText(this.TextA);
        this.ClearText(this.TextB);
        this.ClearText(this.TextC);
        this.ClearText(this.TextD);
        this.ClearText(this.TextE);
        this.ClearText(this.TextF);

        this.ClearStringData(this.StringDataA);
        this.ClearStringData(this.StringDataB);
        this.ClearStringData(this.StringDataC);
        this.ClearStringData(this.StringDataD);
        this.ClearStringData(this.StringDataE);
        this.ClearStringData(this.StringDataF);
        return true;
    }

    maide prusate Bool BoolText(var Text text)
    {
        var Bool k;
        k : false;

        inf (this.TextSame(text, this.TE(this.TextInfra.BoolTrueString)))
        {
            k : true;
        }
        return k;
    }

    maide prusate Int IntText(var Text text, var Int varBase)
    {
        return this.IntParse.Execute(text, varBase, null);
    }

    maide prusate Text TextCreate(var String value)
    {
        return this.TextInfra.TextCreateStringData(value, null);
    }

    maide prusate Int TextIndex(var Text text, var Text other)
    {
        return this.TextInfra.Index(text, other, this.TLess);
    }

    maide prusate Int TextLastIndex(var Text text, var Text other)
    {
        return this.TextInfra.LastIndex(text, other, this.TLess);
    }

    maide prusate Bool TextStart(var Text text, var Text other)
    {
        return this.TextInfra.Start(text, other, this.TLess);
    }

    maide prusate Bool TextEnd(var Text text, var Text other)
    {
        return this.TextInfra.End(text, other, this.TLess);
    }

    maide prusate Int TextLess(var Text lite, var Text rite)
    {
        return this.TLess.Execute(lite, rite);
    }

    maide prusate Bool TextSame(var Text text, var Text other)
    {
        return this.TextInfra.Same(text, other, this.TLess);
    }

    maide prusate Text TextForm(var Text text, var TextForm form)
    {
        var Int count;
        count : text.Range.Count;

        var Text a;
        a : this.TextInfra.TextCreate(count);

        this.TextInfra.Form(a, text, form);

        return a;
    }

    maide prusate Text TextAlphaNite(var Text text)
    {
        return this.TextForm(text, this.TextInfra.AlphaNiteForm);
    }

    maide prusate Text TextAlphaSite(var Text text)
    {
        return this.TextForm(text, this.TextInfra.AlphaSiteForm);
    }

    maide prusate Array TextLimit(var Text text, var Text limit)
    {
        return this.TextInfra.Limit(text, limit, this.TLess);
    }

    maide prusate Text TextPlace(var Text text, var Text limit, var Text join)
    {
        return this.TextInfra.Place(text, limit, join, this.TLess);
    }

    maide prusate Array TextLine(var Text text)
    {
        var Array a;
        a : this.TextLimit(text, this.TE(this.TextInfra.NewLine));
        return a;
    }

    maide prusate Text TextTrimStart(var Text text)
    {
        var Text space;
        space : this.TE(this.SSpace);

        var Int start;
        var Int count;
        start : text.Range.Index;
        count : text.Range.Count;

        var Int k;
        k : 0;

        text.Range.Count : 1;

        var Bool b;
        b : false;

        var Int i;
        i : 0;
        while (~b & i < count)
        {
            text.Range.Index : start + i;

            inf (~this.TextSame(text, space))
            {
                k : i;
                b : true;
            }

            i : i + 1;
        }

        inf (~b)
        {
            k : count;
        }

        text.Range.Index : start + k;
        text.Range.Count : count - k;

        return text;
    }

    maide prusate Text TextTrimEnd(var Text text)
    {
        var Text space;
        space : this.TE(this.SSpace);

        var Int start;
        var Int count;
        start : text.Range.Index;
        count : text.Range.Count;

        var Int k;
        k : count;

        text.Range.Count : 1;

        var Bool b;
        b : false;

        var Int i;
        i : 0;
        while (~b & i < count)
        {
            var Int index;
            index : (count - 1) - i;

            text.Range.Index : start + index;

            inf (~this.TextSame(text, space))
            {
                k : index + 1;
                b : true;
            }

            i : i + 1;
        }

        inf (~b)
        {
            k : 0;
        }

        text.Range.Index : start;
        text.Range.Count : k;

        return text;
    }

    maide prusate String StringCreate(var Text text)
    {
        return this.TextInfra.StringCreate(text);
    }

    maide prusate String StringCreateRange(var String value, var Int index, var Int count)
    {
        this.TRangeA.Index : index;
        this.TRangeA.Count : count;

        return this.StringComp.CreateString(value, this.TRangeA);
    }

    maide prusate String StringCreateIndex(var String value, var Int index)
    {
        var Int count;
        count : this.StringCount(value) - index;

        return this.StringCreateRange(value, index, count);
    }

    maide prusate String StringCreateTextRange(var Text value, var Int index, var Int count)
    {
        var Int ka;
        var Int kb;
        ka : value.Range.Index;
        kb : value.Range.Count;

        value.Range.Index : index;
        value.Range.Count : count;

        var String a;
        a : this.StringCreate(value);

        value.Range.Index : ka;
        value.Range.Count : kb;

        return a;
    }

    maide prusate String StringCreateTextIndex(var Text value, var Int index)
    {
        var Int ka;
        var Int kb;
        ka : value.Range.Index;
        kb : value.Range.Count;

        value.Range.Index : index;
        value.Range.Count : (ka + kb) - index;

        var String a;
        a : this.StringCreate(value);

        value.Range.Index : ka;
        value.Range.Count : kb;

        return a;
    }

    maide prusate Int StringCount(var String value)
    {
        return this.StringComp.Count(value);
    }

    maide prusate Int StringChar(var String value, var Int index)
    {
        return this.StringComp.Char(value, index);
    }

    maide prusate Int StringLess(var String lite, var String rite)
    {
        return this.SLess.Execute(lite, rite);
    }

    maide prusate String StringBool(var Bool value)
    {
        var String a;

        inf (value)
        {
            a : this.TextInfra.BoolTrueString;
        }
        inf (~value)
        {
            a : this.TextInfra.BoolFalseString;
        }
        return a;
    }

    maide prusate String StringBoolFormat(var Bool value, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        var FormatArg arg;
        arg : this.FormatArg;

        arg.Kind : 0;
        arg.Value : value;
        arg.Base : 0;
        arg.AlignLeft : alignLeft;
        arg.FieldWidth : fieldWidth;
        arg.MaxWidth : maxWidth;
        arg.FillChar : fillChar;
        arg.Form : null;

        return this.StringFormat();
    }

    maide prusate String StringInt(var Int value)
    {
        return this.StringIntFormat(value, 10, false, 0, null, 0);
    }

    maide prusate String StringIntHex(var Int value)
    {
        return this.StringIntFormat(value, 16, false, 15, 15, this.Char("0"));
    }

    maide prusate String StringIntFormat(var Int value, var Int varBase, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        var FormatArg arg;
        arg : this.FormatArg;

        arg.Kind : 1;
        arg.Value : value;
        arg.Base : varBase;
        arg.AlignLeft : alignLeft;
        arg.FieldWidth : fieldWidth;
        arg.MaxWidth : maxWidth;
        arg.FillChar : fillChar;
        arg.Form : null;

        return this.StringFormat();
    }

    maide prusate String StringTextFormat(var Text value, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        var FormatArg arg;
        arg : this.FormatArg;

        arg.Kind : 2;
        arg.Value : value;
        arg.Base : 0;
        arg.AlignLeft : alignLeft;
        arg.FieldWidth : fieldWidth;
        arg.MaxWidth : maxWidth;
        arg.FillChar : fillChar;
        arg.Form : null;

        return this.StringFormat();
    }

    maide prusate String StringFormat()
    {
        var Bool b;

        b : this.Format.ExecuteArgCount(this.FormatArg);

        inf (~b)
        {
            return null;
        }

        var Text k;
        k : this.TextInfra.TextCreate(this.FormatArg.Count);

        b : this.Format.ExecuteArgResult(this.FormatArg, k);

        inf (~b)
        {
            return null;
        }

        var String a;
        a : this.StringCreate(k);

        return a;
    }

    maide prusate Int Char(var String value)
    {
        return this.TextInfra.Char(value);
    }

    maide prusate Add AddClear()
    {
        this.StringAdd.Clear();
        return this;
    }

    maide prusate String AddResult()
    {
        return this.StringAdd.Result();
    }

    maide prusate Add Add(var String value)
    {
        this.TextInfra.AddString(this.StringAdd, value);
        return this;
    }

    maide prusate Add AddChar(var Int value)
    {
        this.StringAdd.Execute(value);
        return this;
    }

    maide prusate Add AddLine()
    {
        return this.Add(this.TextInfra.NewLine);
    }

    maide prusate Add AddIndent(var Int count)
    {
        var Int i;
        i : 0;
        while (i < count)
        {
            this.Add(this.SIndent);
            i : i + 1;
        }
        return this;
    }

    maide prusate Add AddBool(var Bool value)
    {
        return this.Add(this.StringBool(value));
    }

    maide prusate Add AddBoolFormat(var Bool value, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        return this.Add(this.StringBoolFormat(value, alignLeft, fieldWidth, maxWidth, fillChar));
    }

    maide prusate Add AddInt(var Int value)
    {
        return this.Add(this.StringInt(value));
    }

    maide prusate Add AddIntHex(var Int value)
    {
        return this.Add(this.StringIntHex(value));
    }

    maide prusate Add AddIntFormat(var Int value, var Int varBase, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        return this.Add(this.StringIntFormat(value, varBase, alignLeft, fieldWidth, maxWidth, fillChar));
    }

    maide prusate Add AddText(var Text value)
    {
        return this.Add(this.StringCreate(value));
    }

    maide prusate Add AddTextFormat(var Text value, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        return this.Add(this.StringTextFormat(value, alignLeft, fieldWidth, maxWidth, fillChar));
    }
}