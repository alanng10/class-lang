class InternInfra : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        return true;
    }
    
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
    
    maide prusate Bool StreamRead(var Int stream, var Any dataArray, var Int data, var Int range)
    {
        var Int dataValue;
        dataValue : this.InternIntern.Memory(dataArray);
    }
}