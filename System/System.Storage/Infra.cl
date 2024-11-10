class Infra : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.TextInfra : share TextInfra;
        this.StringComp : share StringComp;
        this.TextCodeKindList : share TextCodeKindList;
        this.StorageStatusList : share StatusList;

        this.TextSlash : this.TextInfra.TextCreateStringData("/", null);
        this.TextDot : this.TextInfra.TextCreateStringData(".", null);
        this.TextColon : this.TextInfra.TextCreateStringData(":", null);
        return true;
    }

    field prusate TextText TextSlash { get { return data; } set { data : value; } }
    field prusate TextText TextDot { get { return data; } set { data : value; } }
    field prusate TextText TextColon { get { return data; } set { data : value; } }
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate TextCodeKindList TextCodeKindList { get { return data; } set { data : value; } }
    field precate StatusList StorageStatusList { get { return data; } set { data : value; } }

    maide prusate Bool ValidMode(var Mode mode)
    {
        inf (~(mode.Read | mode.Write))
        {
            return false;
        }
        inf (mode.New & mode.Exist)
        {
            return false;
        }
        return true;
    }

    maide prusate Data DataRead(var String filePath)
    {
        var Storage storage;
        storage : new Storage;
        storage.Init();

        var Mode mode;
        mode : new Mode;
        mode.Init();
        mode.Read : true;

        storage.Path : filePath;
        storage.Mode : mode;
        storage.Open();

        var Data a;
        inf (storage.Status = this.StorageStatusList.NoError)
        {
            var StreamStream stream;
            stream : storage.Stream;

            var Int count;
            count : stream.Count;
            var Data data;
            data : new Data;
            data.Count : count;
            data.Init();
            var Range range;
            range : new Range;
            range.Init();
            range.Index : 0;
            range.Count : count;

            stream.Read(data, range);
            inf (storage.Status = this.StorageStatusList.NoError)
            {
                a : data;
            }
        }
        storage.Close();
        storage.Final();
        return a;
    }

    maide prusate Bool DataWrite(var String filePath, var Data data)
    {
        var Storage storage;
        storage : new Storage;
        storage.Init();

        var Mode mode;
        mode : new Mode;
        mode.Init();
        mode.Write : true;

        storage.Path : filePath;
        storage.Mode : mode;
        storage.Open();

        var Bool a;
        a : false;
        inf (storage.Status = this.StorageStatusList.NoError)
        {
            var StreamStream stream;
            stream : storage.Stream;

            var Range range;
            range : new Range;
            range.Init();
            range.Index : 0;
            range.Count : data.Count;

            stream.Write(data, range);
            inf (storage.Status = this.StorageStatusList.NoError)
            {
                a : true;
            }
        }
        storage.Close();
        storage.Final();
        return a;
    }

    maide prusate String TextRead(var String filePath)
    {
        var TextCodeKindList kindList;
        kindList : this.TextCodeKindList;

        var Data data;
        data : this.DataRead(filePath);
        inf (data = null)
        {
            return null;
        }
        
        var TextCodeKind innKind;
        var TextCodeKind outKind;
        innKind : kindList.Utf8;
        outKind : kindList.Utf32;

        var Range dataRange;
        dataRange : new Range;
        dataRange.Init();
        dataRange.Index : 0;
        dataRange.Count : data.Count;

        var Data result;
        result : this.TextInfra.Code(innKind, outKind, data, dataRange); 

        var String k;
        k : this.StringComp.CreateData(result, null);

        var String a;
        a : k;
        return a;
    }

    maide prusate Bool TextWrite(var String filePath, var String text)
    {
        var TextCodeKindList kindList;
        kindList : this.TextCodeKindList;

        var TextCodeKind innKind;
        var TextCodeKind outKind;
        innKind : kindList.Utf32;
        outKind : kindList.Utf8;

        var Data data;
        data : this.TextInfra.StringDataCreateString(text);

        var Range dataRange;
        dataRange : new Range;
        dataRange.Init();
        dataRange.Index : 0;
        dataRange.Count : data.Count;

        var Data result;
        result : this.TextInfra.Code(innKind, outKind, data, dataRange);

        var Bool a;
        a : this.DataWrite(filePath, result);
        return a;
    }

    maide prusate Bool CountSet(var String filePath, var Int value)
    {
        var Storage storage;
        storage : new Storage;
        storage.Init();

        var Mode mode;
        mode : new Mode;
        mode.Init();
        mode.Read : true;
        mode.Write : true;
        mode.Exist : true;

        storage.Path : filePath;
        storage.Mode : mode;
        storage.Open();

        var Bool a;
        a : false;
        inf (storage.Status = this.StorageStatusList.NoError)
        {
            storage.CountSet(value);
            inf (storage.Status = this.StorageStatusList.NoError)
            {
                a : true;
            }
        }
        storage.Close();
        storage.Final();
        return a;
    }

    maide prusate Int EntryPathNameCombine(var TextText entryPath, var Less less)
    {
        var Int a;
        a : this.TextInfra.LastIndex(entryPath, this.TextSlash, less);
        return a;
    }

    maide prusate Int EntryNameExtensionDot(var TextText entryName, var Less less)
    {
        var Int a;
        a : this.TextInfra.LastIndex(entryName, this.TextDot, less);
        return a;
    }

    maide prusate Bool IsRelativePath(var TextText entryPath, var Less less)
    {
        var TextInfra textInfra;
        textInfra : this.TextInfra;

        var Int k;
        k : textInfra.Index(entryPath, this.TextSlash, less);
        inf (k = null)
        {
            return true;
        }

        inf (k = 0)
        {
            return false;
        }

        var Range range;
        range : entryPath.Range;

        var Int indexA;
        var Int countA;
        indexA : range.Index;
        countA : range.Count;

        var TextText colon;
        colon : this.TextColon;

        var Int colonCount;
        colonCount : colon.Range.Count;

        range.Index : indexA + k - colonCount;
        range.Count : colonCount;

        var Bool b;
        b : textInfra.Same(entryPath, colon, less);
        
        range.Index : indexA;
        range.Count : countA;

        var Bool a;
        a : ~b;
        return a;
    }
}