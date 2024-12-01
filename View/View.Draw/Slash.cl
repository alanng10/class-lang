class Slash : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        
        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Slash_New();
        extern.Slash_BrushSet(this.Intern, this.Brush.Intern);
        extern.Slash_LineSet(this.Intern, this.Line.Intern);
        extern.Slash_SizeSet(this.Intern, this.Size);
        extern.Slash_CapSet(this.Intern, this.Cap.Intern);
        extern.Slash_JoinSet(this.Intern, this.Join.Intern);
        extern.Slash_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Slash_Final(this.Intern);
        extern.Slash_Delete(this.Intern);
        return true;
    }

    field prusate Brush Brush { get { return data; } set { data : value; } }
    field prusate SlashLine Line { get { return data; } set { data : value; } }
    field prusate Int Size { get { return data; } set { data : value; } }
    field prusate SlashCap Cap { get { return data; } set { data : value; } }
    field prusate SlashJoin Join { get { return data; } set { data : value; } }    
    field private Extern Extern { get { return data; } set { data : value; } }    
    field pronate Int Intern { get { return data; } set { data : value; } }
}