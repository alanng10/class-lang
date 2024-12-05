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
    }
}