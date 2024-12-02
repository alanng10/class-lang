class PolateStop : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.DrawInfra : share Infra;

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.PolateStop_New();
        extern.PolateStop_CountSet(this.Intern, this.Count);
        extern.PolateStop_Init(this.Intern);
        return true;        
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.PolateStop_Final(this.Intern);
        extern.PolateStop_Delete(this.Intern);
        return true;
    }

    field prusate Int Count { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field precate Infra DrawInfra { get { return data; } set { data : value; } }
    field pronate Int Intern { get { return data; } set { data : value; } }

    maide prusate Bool PointGet(var Int index, var PolateStopPoint result)
    {
        result.Pos : this.Extern.PolateStop_PointGetPos(this.Intern, index);
        
        var Int colorK;
        colorK : this.Extern.PolateStop_PointGetColor(this.Intern, index);
        
        this.DrawInfra.ColorSet(result.Color, colorK);
        return true;
    }

    maide prusate Bool PointSet(var Int index, var PolateStopPoint point)
    {
        var Int colorK;
        colorK : this.DrawInfra.InternColor(point.Color);
        
        this.Extern.PolateStop_PointSet(this.Intern, index, point.Pos, colorK);
        return true;
    }
}