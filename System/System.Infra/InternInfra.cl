class InternInfra : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        return true;
    }
    
    field prusate String ModuleFoldPath { get { return data; } set { data : value; } }
    field precate Intern InternIntern { get { return data; } set { data : value; } }
    field precate Extern Extern { get { return data; } set { data : value; } }

    maide prusate Int DataByteListGet(var Any data, var Int index, var Int count)
    {
        var Intern internIntern;
        internIntern : this.InternIntern;

        var Int oo;
        oo : 0;

        var Int i;
        i : 0;
        while (i < count)
        {
            var Int ob;
            ob : internIntern.DataGet(data, index + i);

            var Int shiftCount;
            shiftCount : i * 8;

            var Int o;
            o : bit <(ob, shiftCount);

            oo : bit |(oo, o);

            i : i + 1;
        }

        var Int a;
        a : oo;
        return a;
    }

    maide prusate Bool DataByteListSet(var Any data, var Int index, var Int count, var Int value)
    {
        var Intern internIntern;
        internIntern : this.InternIntern;

        var Int oo;
        oo : value;

        var Int i;
        i : 0;
        while (i < count)
        {
            var Int shiftCount;
            shiftCount : i * 8;

            var Int o;
            o : bit >(oo, shiftCount);

            internIntern.DataSet(data, index + i, o);

            i : i + 1;
        }
        return true;
    }

    maide prusate Int DataMidGet(var Any data, var Int index)
    {
        return this.DataByteListGet(data, index, 4);
    }

    maide prusate Bool DataMidSet(var Any data, var Int index, var Int value)
    {
        return this.DataByteListSet(data, index, 4, value);
    }

    maide prusate Int DataCharGet(var Any data, var Int index)
    {
        return this.DataMidGet(data, index);
    }

    maide prusate Bool DataCharSet(var Any data, var Int index, var Int value)
    {
        return this.DataMidSet(data, index, value);
    }

    maide prusate Int TextCodeCount(var Int innKind, var Int outKind, var Any data, var Int dataIndex, var Int dataCount)
    {
        var Int dataValue;
        dataValue : this.InternIntern.Memory(data);
        dataValue : dataValue + dataIndex;

        var Int k;
        k : this.Extern.TextCode_ExecuteCount(0, innKind, outKind, dataValue, dataCount);
        return k;
    }

    maide prusate Bool TextCodeResult(var Any result, var Int resultIndex, var Int innKind, var Int outKind, var Any data, var Int dataIndex, var Int dataCount)
    {
        var Int dataValue;
        dataValue : this.InternIntern.Memory(data);
        dataValue : dataValue + dataIndex;

        var Int resultValue;
        resultValue : this.InternIntern.Memory(result);
        resultValue : resultValue + resultIndex;

        this.Extern.TextCode_ExecuteResult(0, resultValue, innKind, outKind, dataValue, dataCount);
        return true;
    }
    
    maide prusate Bool CopyToByteArray(var Int source, var Any dest, var Int index, var Int count)
    {
        var Int dataValue;
        dataValue : this.InternIntern.Memory(dest);
        dataValue : dataValue + index;
        
        this.Extern.Environ_Copy(dataValue, source, count);
        return true;
    }
    
    maide prusate Bool CopyFromByteArray(var Int dest, var Any source, var Int index, var Int count)
    {
        var Int dataValue;
        dataValue : this.InternIntern.Memory(source);
        dataValue : dataValue + index;
        
        this.Extern.Environ_Copy(dest, dataValue, count);
        return true;
    }
    
    maide prusate Int StringCreate(var String k)
    {
        var Any value;
        value : this.InternIntern.StringValueGet(k);

        var Int count;
        count : this.InternIntern.StringCountGet(k);

        var Int ka;
        ka : count * 4;

        var Extern extern;
        extern : this.Extern;

        var Int kk;
        kk : extern.Environ_New(ka);

        this.CopyFromByteArray(kk, value, 0, ka);

        var Int a;
        a : extern.String_New();
        extern.String_Init(a);
        extern.String_ValueSet(a, kk);
        extern.String_CountSet(a, count);
        return a;
    }
    
    maide prusate Bool StringDelete(var Int k)
    {
        var Extern extern;
        extern : this.Extern;

        var Int value;
        value : extern.String_ValueGet(k);

        extern.String_Final(k);
        extern.String_Delete(k);

        extern.Environ_Delete(value);
        return true;
    }

    maide prusate String StringCreateIntern(var Int k)
    {
        var Any value;
        value : this.ByteArrayCreateString(k);

        var Int count;
        count : this.Extern.String_CountGet(k);

        var String a;
        a : this.InternIntern.StringNew();
        this.InternIntern.StringValueSet(a, value);
        this.InternIntern.StringCountSet(a, count);
        return a;
    }

    maide prusate Any ByteArrayCreateString(var Int k)
    {
        var Extern extern;
        extern : this.Extern;

        var Int value;
        var Int count;
        value : extern.String_ValueGet(k);
        count : extern.String_CountGet(k);

        var Int dataCount;
        dataCount : count * 4;

        var Any a;
        a : this.InternIntern.DataNew(dataCount);

        this.CopyToByteArray(value, a, 0, dataCount);
        return a;
    }

    maide prusate Int StateCreate(var Int varMaide, var Int arg)
    {
        var Extern extern;
        extern : this.Extern;
        var Int a;
        a : extern.State_New();
        extern.State_Init(a);
        extern.State_MaideSet(a, varMaide);
        extern.State_ArgSet(a, arg);
        return a;
    }
    
    maide prusate Bool StateDelete(var Int o)
    {
        var Extern extern;
        extern : this.Extern;
        extern.State_Final(o);
        extern.State_Delete(o);
        return true;        
    }
    
    maide prusate Int RangeCreate()
    {
        var Extern extern;
        extern : this.Extern;
        var Int a;
        a : extern.Range_New();
        extern.Range_Init(a);
        return a;
    }    

    maide prusate Bool RangeDelete(var Int a)
    {
        var Extern extern;
        extern : this.Extern;
        extern.Range_Final(a);
        extern.Range_Delete(a);
        return true;
    }
    
    maide prusate Bool RangeSet(var Int range, var Int index, var Int count)
    {
        var Extern extern;
        extern : this.Extern;
        extern.Range_IndexSet(range, index);
        extern.Range_CountSet(range, count);
        return true;
    }    

    maide prusate Int PosCreate()
    {
        var Extern extern;
        extern : this.Extern;
        var Int a;
        a : extern.Pos_New();
        extern.Pos_Init(a);
        return a;
    }

    maide prusate Bool PosDelete(var Int a)
    {
        var Extern extern;
        extern : this.Extern;
        extern.Pos_Final(a);
        extern.Pos_Delete(a);
        return true;
    }

    maide prusate Bool PosSet(var Int pos, var Int col, var Int row)
    {
        var Extern extern;
        extern : this.Extern;
        extern.Pos_ColSet(pos, col);
        extern.Pos_RowSet(pos, row);
        return true;
    }

    maide prusate Int SizeCreate()
    {
        var Extern extern;
        extern : this.Extern;
        var Int a;
        a : extern.Size_New();
        extern.Size_Init(a);
        return a;
    }

    maide prusate Bool SizeDelete(var Int a)
    {
        var Extern extern;
        extern : this.Extern;
        extern.Size_Final(a);
        extern.Size_Delete(a);
        return true;
    }

    maide prusate Bool SizeSet(var Int size, var Int width, var Int hegth)
    {
        var Extern extern;
        extern : this.Extern;
        extern.Size_WidthSet(size, width);
        extern.Size_HegthSet(size, hegth);
        return true;
    }

    maide prusate Int RectCreate()
    {
        var Int pos;
        pos : this.PosCreate();

        var Extern extern;
        extern : this.Extern;

        var Int size;
        size : extern.Size_New();
        extern.Size_Init(size);

        var Int rect;
        rect : extern.Rect_New();
        extern.Rect_Init(rect);
        extern.Rect_PosSet(rect, pos);
        extern.Rect_SizeSet(rect, size);
        return rect;
    }

    maide prusate Bool RectDelete(var Int rect)
    {
        var Extern extern;
        extern : this.Extern;

        var Int pos;
        var Int size;
        pos : extern.Rect_PosGet(rect);
        size : extern.Rect_SizeGet(rect);
        
        extern.Rect_Final(rect);
        extern.Rect_Delete(rect);

        extern.Size_Final(size);
        extern.Size_Delete(size);

        this.PosDelete(pos);
        return true;
    }

    maide prusate Bool RectSet(var Int rect, var Int col, var Int row, var Int width, var Int hegth)
    {
        var Extern extern;
        extern : this.Extern;

        var Int pos;
        pos : extern.Rect_PosGet(rect);

        this.PosSet(pos, col, row);

        var Int size;
        size : extern.Rect_SizeGet(rect);

        this.SizeSet(size, width, hegth);
        return true;
    }

    maide prusate Int Bool(var Bool k)
    {
        var Int a;
        a : 0;
        inf (k)
        {
            a : 1;
        }
        return a;
    }

    maide prusate Bool StreamRead(var Int stream, var Any dataValue, var Int data, var Int range)
    {
        var Int k;
        k : this.InternIntern.Memory(dataValue);

        var Extern extern;
        extern : this.Extern;

        extern.Data_ValueSet(data, k);

        extern.Stream_Read(stream, data, range);

        extern.Data_ValueSet(data, 0);
        return true;
    }
    
    maide prusate Bool StreamWrite(var Int stream, var Any dataValue, var Int data, var Int range)
    {
        var Int k;
        k : this.InternIntern.Memory(dataValue);

        var Extern extern;
        extern : this.Extern;

        extern.Data_ValueSet(data, k);

        extern.Stream_Write(stream, data, range);

        extern.Data_ValueSet(data, 0);
        return true;
    }

    maide prusate Int TypeIndexFromInternIndex(var Int value)
    {
        var Int k;
        k : value;

        var Int na;
        na : 0h01000000;

        var Int nb;
        nb : 0h80;

        inf (~(k < na))
        {
            k : k - na;
            k : k + nb;
        }
        return k;
    }
}