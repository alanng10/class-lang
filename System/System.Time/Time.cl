class Time : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;

        var Extern extern;
        extern : this.Extern;
        
        this.Intern : extern.Time_New();
        extern.Time_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;
        
        extern.Time_Final(this.Intern);
        extern.Time_Delete(this.Intern);
        return true;
    }

    field private Extern Extern { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }

    field prusate Int Yea
    {
        get
        {
            var Int a;
            a : this.Extern.Time_YeaGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Mon
    {
        get
        {
            var Int a;
            a : this.Extern.Time_MonGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Day
    {
        get
        {
            var Int a;
            a : this.Extern.Time_DayGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Our
    {
        get
        {
            var Int a;
            a : this.Extern.Time_OurGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Min
    {
        get
        {
            var Int a;
            a : this.Extern.Time_MinGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Sec
    {
        get
        {
            var Int a;
            a : this.Extern.Time_SecGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Tick
    {
        get
        {
            var Int a;
            a : this.Extern.Time_TickGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int Pos
    {
        get
        {
            var Int a;
            a : this.Extern.Time_PosGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int YeaDay
    {
        get
        {
            var Int a;
            a : this.Extern.Time_YeaDayGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int WeekDay
    {
        get
        {
            var Int a;
            a : this.Extern.Time_WeekDayGet(this.Intern);
            return a;
        }
        set
        {
        }
    }
    
    field prusate Int YeaDayCount
    {
        get
        {
            var Int a;
            a : this.Extern.Time_YeaDayCountGet(this.Intern);
            return a;
        }
        set
        {
        }
    }
    
    field prusate Int MonDayCount
    {
        get
        {
            var Int a;
            a : this.Extern.Time_MonDayCountGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field prusate Int TotalTick
    {
        get
        {
            var Int a;
            a : this.Extern.Time_TotalTickGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    maide prusate Bool This()
    {
        var Int k;
        k : this.Extern.Time_This(this.Intern);
        
        var Bool a;
        a : ~(k = 0);
        return true;
    }

    maide prusate Bool ToPos(var Int pos)
    {
        this.Extern.Time_ToPos(this.Intern, pos);
        return true;
    }

    maide prusate Bool AddYea(var Int value)
    {
        var Int k;
        k : this.Extern.Time_AddYea(this.Intern, value);
        
        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool AddMon(var Int value)
    {
        var Int k;
        k : this.Extern.Time_AddMon(this.Intern, value);
        
        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool AddDay(var Int value)
    {
        var Int k;
        k : this.Extern.Time_AddDay(this.Intern, value);
        
        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool AddTick(var Int value)
    {
        var Int k;
        k : this.Extern.Time_AddTick(this.Intern, value);
        
        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool LeapYea(var Int yea)
    {
        var Int k;
        k : this.Extern.Time_LeapYea(yea);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool ValidDate(var Int yea, var Int mon, var Int day)
    {
        var Int k;
        k : this.Extern.Time_ValidDate(yea, mon, day);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool ValidTime(var Int our, var Int min, var Int sec, var Int tick)
    {
        var Int k;
        k : this.Extern.Time_ValidTime(our, min, sec, tick);

        var Bool a;
        a : ~(k = 0);
        return a;
    }

    maide prusate Bool Set(var Int yea, var Int mon, var Int day, var Int our, var Int min, var Int sec, var Int tick, var Int pos)
    {
        var Int k;
        k : this.Extern.Time_Set(this.Intern, yea, mon, day, our, min, sec, tick, pos);

        var Bool a;
        a : ~(k = 0);
        return a;
    }
}