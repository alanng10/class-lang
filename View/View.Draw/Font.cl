class Font : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        this.InternName : this.InternInfra.StringCreate(this.Name);

        var Int italicK;
        italicK : this.InternInfra.InternBool(this.Italic);
        var Int underlineK;
        underlineK : this.InternInfra.InternBool(this.Underline);
        var Int overlineK;
        overlineK : this.InternInfra.InternBool(this.Overline);
        var Int strikeoutK;
        strikeoutK : this.InternInfra.InternBool(this.Strikeout);

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
}