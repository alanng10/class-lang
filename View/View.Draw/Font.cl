class Font : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        this.InternName : this.InternInfra.StringCreate(this.Name);

        var Int italicK;
        italicK : this.InternInfra.Bool(this.Italic);
        var Int underlineK;
        underlineK : this.InternInfra.Bool(this.Underline);
        var Int overlineK;
        overlineK : this.InternInfra.Bool(this.Overline);
        var Int strikeoutK;
        strikeoutK : this.InternInfra.Bool(this.Strikeout);

        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Font_New();
        extern.Font_NameSet(this.Intern, this.InternName);
        extern.Font_SizeSet(this.Intern, this.Size);
        extern.Font_WeightSet(this.Intern, this.Weight);
        extern.Font_ItalicSet(this.Intern, italicK);
        extern.Font_UnderlineSet(this.Intern, underlineK);
        extern.Font_OverlineSet(this.Intern, overlineK);
        extern.Font_StrikeoutSet(this.Intern, strikeoutK);
        extern.Font_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Font_Final(this.Intern);
        extern.Font_Delete(this.Intern);

        this.InternInfra.StringDelete(this.InternName);
        return true;
    }
}