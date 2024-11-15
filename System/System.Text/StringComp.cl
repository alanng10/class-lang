class StringComp : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.InternInfra : share InternInfra;
        this.InfraInfra : share InfraInfra;
        return true;
    }
    
    field private Intern InternIntern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    
    maide prusate String CreateChar(var Int char, var Int count)
    {
        var InternInfra internInfra;
        internInfra : this.InternInfra;

        inf (char = null | count = null)
        {
            return null;
        }

        var Int ko;
        ko : 4;

        var Int dataCount;
        dataCount : count * ko;

        var Any value;
        value : this.InternIntern.DataNew(dataCount);

        var Int i;
        i : 0;
        while (i < count)
        {
            var Int index;
            index : i * ko;
            
            internInfra.DataCharSet(value, index, char);

            i : i + 1;
        }

        var String a;
        a : this.InternIntern.StringNew();
        this.InternIntern.StringValueSet(a, value);
        this.InternIntern.StringCountSet(a, count);
        return a;
    }
    
    maide prusate String CreateData(var Data data, var Range range)
    {
        inf (data = null)
        {
            return null;
        }
        
        return this.CreateDataValue(data.Value, data.Count, range);
    }
    
    maide prusate String CreateString(var String string, var Range range)
    {
        inf (string = null)
        {
            return null;
        }
        
        var Any k;
        k : this.InternIntern.StringValueGet(string);

        var Int count;
        count : this.Count(string);
        count : count * 4;

        return this.CreateDataValue(k, count, range);
    }
    
    maide private String CreateDataValue(var Any data, var Int dataCount, var Range range)
    {
        var Intern internIntern;
        internIntern : this.InternIntern;
        var InternInfra internInfra;
        internInfra : this.InternInfra;

        var Int kka;
        kka : 4;

        var Int totalCount;
        totalCount : dataCount / kka;

        var Int index;
        var Int count;

        var Bool b;
        b : range = null;

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

        var Int valueCount;
        valueCount : count * kka;

        var Any value;
        value : internIntern.DataNew(valueCount);

        var Int i;
        i : 0;
        while (i < count)
        {
            var Int ka;
            var Int kb;
            ka : (index + i) * kka;
            kb : i * kka;
            
            var Int n;
            n : internInfra.DataCharGet(data, ka);
            
            internInfra.DataCharSet(value, kb, n);
            
            i : i + 1;
        }


        var String a;
        a : internIntern.StringNew();
        internIntern.StringValueSet(a, value);
        internIntern.StringCountSet(a, count);
        return a;
    }
    
    maide prusate Int Count(var String string)
    {
        inf (string = null)
        {
            return null;
        }
        
        return this.InternIntern.StringCountGet(string);
    }
    
    maide prusate Int Char(var String string, var Int index)
    {
        var Int count;
        count : this.Count(string);

        inf (~this.InfraInfra.ValidIndex(count, index))
        {
            return null;
        }

        var Any k;
        k : this.InternIntern.StringValueGet(string);

        var Int ka;
        ka : index * 4;

        var Int a;
        a : this.InternInfra.DataCharGet(k, ka);
        return a;
    }
}