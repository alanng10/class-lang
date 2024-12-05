class PointList : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.InfraInfra : share InfraInfra;

        this.InternPos : this.InternInfra.PosCreate();

        var Extern extern;
        extern : this.Extern;

        var Int varShare;
        varShare : extern.Infra_Share();

        var Int stat;
        stat : extern.Share_Stat(varShare);

        var Int ka;
        ka : extern.Stat_PointDataCount(stat);

        var Int dataCount;
        dataCount : this.Count * ka;

        var Int dataValue;
        dataValue : extern.New(dataCount);

        this.InternDataValue : dataValue;

        this.Intern : extern.Data_New();
        extern.Data_Init(this.Intern);
        extern.Data_ValueSet(this.Intern, dataValue);
        extern.Data_CountSet(this.Intern, dataCount);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Data_Final(this.Intern);
        extern.Data_Delete(this.Intern);

        extern.Delete(this.InternDataValue);

        this.InternInfra.PosDelete(this.InternPos);
        return true;
    }

    field prusate Int Count { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }
    field private Int InternDataValue { get { return data; } set { data : value; } }
    field private Int InternPos { get { return data; } set { data : value; } }

    maide prusate Bool Get(var Int index, var Pos result)
    {
        inf (~this.InfraInfra.ValueIndex(this.Count, index))
        {
            return false;
        }

        var Int k;
        k : this.Memory(index);

        var Extern extern;
        extern : this.Extern;

        extern.PointData_PointGet(k, this.InternPos);

        var Int col;
        var Int row;
        col : extern.Pos_ColGet(this.InternPos);
        row : extern.Pos_RowGet(this.InternPos);

        result.Col : col;
        result.Row : row;
        return true;
    }

    maide prusate Bool Set(var Int index, var Pos value)
    {
        inf (~this.InfraInfra.ValueIndex(this.Count, index))
        {
            return false;
        }

        this.InternInfra.PosSet(this.InternPos, value.Col, value.Row);

        var Int k;
        k : this.Memory(index);

        this.Extern.PointData_PointSet(k, this.InternPos);
        return true;
    }

    maide prusate Int Memory(var Int index)
    {
        var Extern extern;
        extern : this.Extern;

        var Int varShare;
        varShare : extern.Infra_Share();

        var Int stat;
        stat : extern.Share_Stat(varShare);

        var Int ka;
        ka : extern.Stat_PointDataCount(stat);
        
        var Int k;
        k : index * ka;
        k : this.InternDataValue + k;

        return k;
    }
}