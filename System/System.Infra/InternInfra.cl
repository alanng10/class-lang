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
            o : bit<(ob, shiftCount);

            oo : bit|(oo, o);

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
            o : bit>(oo, shiftCount);

            internIntern.DataSet(data, index + i, o);

            i = i + 1;
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
        
        this.Extern.Copy(dataValue, source, count);
        return true;
    }
    
    maide prusate Bool CopyFromByteArray(var Int dest, var Any source, var Int index, var Int count)
    {
        var Int dataValue;
        dataValue : this.InternIntern.Memory(source);
        dataValue : dataValue + index;
        
        this.Extern.Copy(dest, dataValue, count);
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
        
        var Int kk;
        kk : this.Extern.New(ka);
        
        this.CopyFromByteArray(kk, value, 0, ka);
        
        var Extern extern;
        extern : this.Extern;
        
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

        extern.Delete(value);
        return true;
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

        this.InternIntern.CopyToByteArray(value, a, 0, dataCount);
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
}