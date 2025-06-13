class Code : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternInfra : share InternInfra;
        this.InfraInfra : share InfraInfra;
        return true;
    }

    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }

    maide prusate Int ExecuteCount(var CodeKind innKind, var CodeKind outKind, var Data data, var Range dataRange)
    {
        inf (~this.ValidKind(innKind, outKind))
        {
            return null;
        }

        var Int dataIndex;
        var Int dataCount;
        dataIndex : dataRange.Index;
        dataCount : dataRange.Count;

        inf (~this.InfraInfra.ValidRange(data.Count, dataIndex, dataCount))
        {
            return null;
        }

        var Int k;        
        k : this.InternInfra.TextCodeCount(innKind.Intern, outKind.Intern, data.Value, dataIndex, dataCount);

        var Int a;
        a : k;
        return a;
    }

    maide prusate Bool ExecuteResult(var Data result, var Int resultIndex, var CodeKind innKind, var CodeKind outKind, var Data data, var Range dataRange)
    {
        var InfraInfra infraInfra;
        infraInfra : this.InfraInfra;

        inf (~this.ValidKind(innKind, outKind))
        {
            return false;
        }

        inf (~infraInfra.ValidRange(result.Count, resultIndex, 0))
        {
            return false;
        }

        var Int dataIndex;
        var Int dataCount;
        dataIndex : dataRange.Index;
        dataCount : dataRange.Count;

        inf (~infraInfra.ValidRange(data.Count, dataIndex, dataCount))
        {
            return false;
        }

        this.InternInfra.TextCodeResult(result.Value, resultIndex, innKind.Intern, outKind.Intern, data.Value, dataIndex, dataCount);

        return true;
    }

    maide prusate Bool ValidKind(var CodeKind innKind, var CodeKind outKind)
    {
        inf (innKind = outKind)
        {
            return false;
        }
        return true;
    }
}