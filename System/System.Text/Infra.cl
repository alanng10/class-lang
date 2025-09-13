class Infra : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.FormInfra : share FormInfra;
        this.StringComp : share StringComp;
        this.TextCode : share Code;

        this.NewLine : "\n";
        this.PathCombine : "/";
        this.Zero : "";

        this.PosAddSign : "+";
        this.PosSubSign : "-";

        this.BoolFalseString : "false";
        this.BoolTrueString : "true";
        
        this.AlphaNiteForm : new AlphaNiteForm;
        this.AlphaNiteForm.Init();
        this.AlphaSiteForm : new AlphaSiteForm;
        this.AlphaSiteForm.Init();
        return true;
    }

    field prusate String BoolFalseString { get { return data; } set { data : value; } }
    field prusate String BoolTrueString { get { return data; } set { data : value; } }
    field prusate String NewLine { get { return data; } set { data : value; } }
    field prusate String PathCombine { get { return data; } set { data : value; } }
    field prusate String Zero { get { return data; } set { data : value; } }
    field prusate String PosAddSign { get { return data; } set { data : value; } }
    field prusate String PosSubSign { get { return data; } set { data : value; } }
    field prusate Form AlphaNiteForm { get { return data; } set { data : value; } }
    field prusate Form AlphaSiteForm { get { return data; } set { data : value; } }
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field private FormInfra FormInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate Code TextCode { get { return data; } set { data : value; } }

    maide prusate Int Char(var String k)
    {
        return this.FormInfra.Char(k);
    }

    maide prusate Bool Digit(var Int o)
    {
        return this.FormInfra.Digit(o);
    }

    maide prusate Bool HexAlpha(var Int o, var Bool upperCase)
    {
        return this.FormInfra.HexAlpha(o, upperCase);
    }

    maide prusate Bool Alpha(var Int o, var Bool upperCase)
    {
        return this.FormInfra.Alpha(o, upperCase);
    }

    maide prusate Bool Range(var Int first, var Int last, var Int o)
    {
        return this.FormInfra.Range(first, last, o);
    }

    maide prusate Int DataCharGet(var Data data, var Int index)
    {
        var Int n;
        n : index;
        n : n * 4;
        return this.InfraInfra.DataCharGet(data, n);
    }

    maide prusate Bool DataCharSet(var Data data, var Int index, var Int value)
    {
        var Int n;
        n : index;
        n : n * 4;
        return this.InfraInfra.DataCharSet(data, n, value);
    }

    maide prusate Text TextCreate(var Int count)
    {
        inf (count = null)
        {
            return null;
        }
        
        var Int oa;
        oa : count;
        oa : oa * 4;

        var Text a;
        a : new Text;
        a.Init();
        a.Data : new Data;
        a.Data.Count : oa;
        a.Data.Init();
        a.Range : new Range;
        a.Range.Init();
        a.Range.Index : 0;
        a.Range.Count : count;
        return a;
    }

    maide prusate StringData StringDataCreateString(var String value)
    {
        var StringData a;
        a : new StringData;
        a.Init();
        a.ValueString : value;
        return a;
    }

    maide prusate Text TextCreateStringData(var String value, var Range range)
    {
        var StringComp stringComp;
        stringComp : this.StringComp;

        var Int totalCount;
        totalCount : stringComp.Count(value);

        var Int index;
        var Int count;
        var Bool b;
        b : (range = null);
        inf (b)
        {
            index : 0;
            count : totalCount;
        }
        inf (~b)
        {
            index : range.Index;
            count : range.Count;
            inf (~this.InfraInfra.ValidRange(totalCount, index, count))
            {
                return null;
            }
        }

        var StringData data;
        data : this.StringDataCreateString(value);

        var Range rangeK;
        rangeK : new Range;
        rangeK.Init();
        rangeK.Index : index;
        rangeK.Count : count;

        var Text a;
        a : new Text;
        a.Init();
        a.Data : data;
        a.Range : rangeK;
        return a;
    }

    maide prusate Bool ValidRange(var Text text)
    {
        var Data data;
        data : text.Data;

        var Range range;
        range : text.Range;

        var Int dataCount;
        dataCount : data.Count;
        var Int totalCount;
        totalCount : dataCount / 4;
        
        inf (~this.InfraInfra.ValidRange(totalCount, range.Index, range.Count))
        {
            return false;
        }
        return true;
    }

    maide prusate Int DigitValue(var Int oc, var Int varBase)
    {
        var Int oa;
        oa : 0;
        var Bool b;
        b : (varBase < 10);
        inf (b)
        {
            oa : varBase;
        }
        inf (~b)
        {
            oa : 10;
        }
        var Int oaa;
        oaa : 0;
        inf (~b)
        {
            oaa : varBase - 10;
        }
        var Int oca;
        oca : this.Char("a");

        inf (this.Digit(oc))
        {
            var Int ooa;
            ooa : oc - this.Char("0");
            inf (~(ooa < oa))
            {
                return null;
            }

            return ooa;
        }

        inf (~this.Alpha(oc, false))
        {
            return null;
        }

        var Int oob;
        oob : oc - oca;
        inf (~(oob < oaa))
        {
            return null;
        }

        var Int a;
        a : oob + 10;
        return a;
    }

    maide prusate Int DigitChar(var Int digit, var Int letterStart)
    {
        var Int n;
        n : 0;
        var Bool b;
        b : (digit < 10);
        inf (b)
        {
            n : this.Char("0") + digit;
        }
        inf (~b)
        {
            var Int m;
            m : digit - 10;
            n : letterStart + m;
        }
        
        n : bit &(n, 0hffffffff);

        var Int a;
        a : n;
        return a;
    }

    maide prusate String StringCreate(var Text text)
    {
        return this.StringComp.CreateData(text.Data, text.Range);
    }

    maide prusate Bool AddString(var StringAdd stringAdd, var String value)
    {
        var StringComp stringComp;
        stringComp : this.StringComp;

        var Int count;
        count : stringComp.Count(value);
        var Int i;
        i : 0;
        while (i < count)
        {
            var Int n;
            n : stringComp.Char(value, i);

            stringAdd.Execute(n);

            i : i + 1;
        }
        return true;
    }

    maide prusate Bool Same(var Text lite, var Text rite, var InfraLess less)
    {
        var Int o;
        o : less.Execute(lite, rite);
        return (o = 0);
    }

    maide prusate Bool Start(var Text text, var Text other, var InfraLess less)
    {
        var Range range;
        range : text.Range;

        var Int count;
        count : range.Count;
        var Int otherCount;
        otherCount : other.Range.Count;
        
        inf (count < otherCount)
        {
            return false;
        }

        range.Count : otherCount;

        var Bool a;
        a : this.Same(text, other, less);

        range.Count : count;

        return a;
    }

    maide prusate Bool End(var Text text, var Text other, var InfraLess less)
    {
        var Range range;
        range : text.Range;

        var Int count;
        count : range.Count;
        var Int otherCount;
        otherCount : other.Range.Count;

        inf (count < otherCount)
        {
            return false;
        }

        var Int index;
        index : range.Index;
        
        var Int end;
        end : index + count;

        range.Index : end - otherCount;
        range.Count : otherCount;

        var Bool a;
        a : this.Same(text, other, less);

        range.Index : index;
        range.Count : count;

        return a;
    }

    maide prusate Int Index(var Text text, var Text other, var InfraLess less)
    {
        inf (~this.ValidRange(text))
        {
            return null;
        }
        inf (~this.ValidRange(other))
        {
            return null;
        }

        var Range textRange;
        textRange : text.Range;

        var Int textIndex;
        var Int textCount;
        textIndex : textRange.Index;
        textCount : textRange.Count;

        var Int otherCount;
        otherCount : other.Range.Count;

        inf (textCount < otherCount)
        {
            return null;
        }

        var Int k;
        
        var Int count;
        count : textCount - otherCount + 1;
        var Int i;
        i : 0;
        while (k = null & i < count)
        {
            textRange.Index : textIndex + i;
            textRange.Count : otherCount;

            var Bool b;
            b : this.Same(text, other, less);
            inf (b)
            {
                k : i;
            }
            i : i + 1;
        }

        textRange.Index : textIndex;
        textRange.Count : textCount;

        return k;
    }

    maide prusate Int LastIndex(var Text text, var Text other, var InfraLess less)
    {
        inf (~this.ValidRange(text))
        {
            return null;
        }
        inf (~this.ValidRange(other))
        {
            return null;
        }

        var Range textRange;
        textRange : text.Range;

        var Int textIndex;
        var Int textCount;
        textIndex : textRange.Index;
        textCount : textRange.Count;

        var Int otherCount;
        otherCount : other.Range.Count;

        inf (textCount < otherCount)
        {
            return null;
        }

        var Int k;

        var Int count;
        count : textCount - otherCount + 1;
        var Int i;
        i : 0;
        while (k = null & i < count)
        {
            var Int index;
            index : (count - 1) - i;

            textRange.Index : textIndex + index;
            textRange.Count : otherCount;

            var Bool b;
            b : this.Same(text, other, less);
            inf (b)
            {
                k : index;
            }
            i : i + 1;
        }

        textRange.Index : textIndex;
        textRange.Count : textCount;

        return k;
    }

    maide prusate Array Limit(var Text text, var Text limit, var InfraLess less)
    {
        var InfraInfra infraInfra;
        infraInfra : this.InfraInfra;

        var Data data;
        data : text.Data;

        var Range textRange;
        textRange : text.Range;

        var Int limitCount;
        limitCount : limit.Range.Count;

        var Int kka;
        kka : textRange.Index;

        var Int kkb;
        kkb : textRange.Count;

        var Int count;
        count : 0;

        var Int oo;
        oo : this.Index(text, limit, less);
        while (~(oo = null))
        {
            count : count + 1;

            var Int kaa;
            kaa : oo + limitCount;

            textRange.Index : textRange.Index + kaa;
            textRange.Count : textRange.Count - kaa;

            oo : this.Index(text, limit, less);
        }

        var Array array;
        array : new Array;
        array.Count : count + 1;
        array.Init();

        var Range rangeA;
        rangeA : new Range;
        rangeA.Init();

        textRange.Index : kka;
        textRange.Count : kkb;

        var Text kk;

        var Int i;
        i : 0;
        while (i < count)
        {
            oo : this.Index(text, limit, less);

            rangeA.Index : textRange.Index;
            rangeA.Count : oo;

            kk : this.TextCreateDataRange(data, rangeA);

            array.Set(i, kk);

            var Int kab;
            kab : oo + limitCount;

            textRange.Index : textRange.Index + kab;
            textRange.Count : textRange.Count - kab;

            i : i + 1;
        }

        var Int ka;
        ka : kka + kkb - textRange.Index;

        rangeA.Index : textRange.Index;
        rangeA.Count : ka;

        textRange.Index : kka;
        textRange.Count : kkb;

        kk : this.TextCreateDataRange(data, rangeA);

        array.Set(count, kk);

        return array;
    }
    
    maide prusate Text Join(var Array array, var Text join)
    {
        var Int k;
        k : 0;
        
        var Range joinRange;
        joinRange : join.Range;
        
        var Int joinCount;
        joinCount : joinRange.Count;
        
        var Int count;
        count : array.Count;
        var Int i;
        i : 0;
        while (i < count)
        {
            inf (0 < i)
            {
                k : k + joinCount;
            }
            
            var Text kk;
            kk : cast Text(array.Get(i));
            
            k : k + kk.Range.Count;
            
            i : i + 1;
        }
        
        var Text text;
        text : this.TextCreate(k);
        
        var Data dest;
        dest : text.Data;
        
        var Data joinData;
        joinData : join.Data;
        
        var Int joinIndex;
        joinIndex : joinRange.Index;
        
        k : 0;
        i : 0;
        while (i < count)
        {
            inf (0 < i)
            {
                this.Copy(dest, k, joinData, joinIndex, joinCount);
                
                k : k + joinCount;
            }
            
            var Text ka;
            ka : cast Text(array.Get(i));
            
            var Data kaData;
            kaData : ka.Data;
            
            var Range kaRange;
            kaRange : ka.Range;
            
            var Int kaCount;
            kaCount : kaRange.Count;
            
            this.Copy(dest, k, kaData, kaRange.Index, kaCount);
            
            k : k + kaCount;
            
            i : i + 1;
        }
        
        return text;
    }
    
    maide prusate Text Place(var Text text, var Text limit, var Text join, var InfraLess less)
    {
        var Array array;
        array : this.Limit(text, limit, less);
        
        var Text k;
        k : this.Join(array, join);
        
        var Text a;
        a : k;
        return a;
    }
    
    maide prusate Bool Form(var Text dest, var Text source, var Form form)
    {
        var Int count;
        count : dest.Range.Count;
        
        inf (~(count = source.Range.Count))
        {
            return false;
        }
        
        var Data sourceData;
        var Data destData;
        sourceData : source.Data;
        destData : dest.Data;
        
        var Int sourceIndex;
        var Int destIndex;
        sourceIndex : source.Range.Index;
        destIndex : dest.Range.Index;
        
        var Int i;
        i : 0;
        while (i < count)
        {
            var Int n;
            n : this.DataCharGet(sourceData, sourceIndex + i);
            
            n : form.Execute(n);
            
            this.DataCharSet(destData, destIndex + i, n);
            
            i : i + 1;
        }
        
        return true;
    }
    
    maide prusate StringLess StringLessCreate()
    {
        var IntLess charLess;
        charLess : new IntLess;
        charLess.Init();

        var Form form;
        form : new Form;
        form.Init();

        var StringLess a;
        a : new StringLess;
        a.CharLess : charLess;
        a.LiteForm : form;
        a.RiteForm : form;
        a.Init();
        return a;
    }
    
    maide prusate Bool Copy(var Data dest, var Int destIndex, var Data source, var Int sourceIndex, var Int count)
    {
        var Int ka;
        ka : 4;
        
        return this.InfraInfra.DataCopy(dest, destIndex * ka, source, sourceIndex * ka, count * ka);
    }

    maide prusate Data Code(var CodeKind innKind, var CodeKind outKind, var Data data, var Range range)
    {
        var Code code;
        code : this.TextCode;

        inf (~code.ValidKind(innKind, outKind))
        {
            return null;
        }

        var Int resultCount;
        resultCount : code.ExecuteCount(innKind, outKind, data, range);

        var Data result;
        result : new Data;
        result.Count : resultCount;
        result.Init();

        code.ExecuteResult(result, 0, innKind, outKind, data, range);

        return result;
    }

    maide private Text TextCreateDataRange(var Data data, var Range range)
    {
        var Range aa;
        aa : new Range;
        aa.Init();
        aa.Index : range.Index;
        aa.Count : range.Count;
        
        var Text a;
        a : new Text;
        a.Init();
        a.Data : data;
        a.Range : aa;
        return a;
    }
}