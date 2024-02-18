#include "Font.hpp"




CppClassNew(Font)








Int Font_Init(Int o)
{
    Font* m;

    m = CP(o);





    QString familyString;



    Int ua;

    ua = CastInt(&familyString);



    String_SetQString(ua, m->Family);





    int sizeU;

    sizeU = m->Size;




    int weightU;

    weightU = m->Weight;




    bool italicU;

    italicU = m->Italic;



    bool underlineU;

    underlineU = m->Underline;



    bool overlineU;

    overlineU = m->Overline;



    bool strikeoutU;

    strikeoutU = m->Strikeout;




    m->Intern = new QFont(familyString, sizeU, weightU, italicU);


    m->Intern->setStyleHint(QFont::AnyStyle, QFont::PreferAntialias);


    m->Intern->setUnderline(underlineU);


    m->Intern->setOverline(overlineU);


    m->Intern->setStrikeOut(strikeoutU);





    return true;
}






Int Font_Final(Int o)
{
    Font* m;

    m = CP(o);




    delete m->Intern;





    return true;
}










Int Font_GetFamily(Int o)
{
    Font* m;

    m = CP(o);



    return m->Family;
}





Int Font_SetFamily(Int o, Int value)
{
    Font* m;

    m = CP(o);



    m->Family = value;




    return true;
}







Int Font_GetSize(Int o)
{
    Font* m;

    m = CP(o);



    return m->Size;
}






Bool Font_SetSize(Int o, Int value)
{
    Font* m;

    m = CP(o);



    m->Size = value;



    return true;
}






Int Font_GetWeight(Int o)
{
    Font* m;

    m = CP(o);



    return m->Weight;
}





Bool Font_SetWeight(Int o, Int value)
{
    Font* m;

    m = CP(o);



    m->Weight = value;



    return true;
}







Int Font_GetItalic(Int o)
{
    Font* m;

    m = CP(o);



    return m->Italic;
}





Bool Font_SetItalic(Int o, Int value)
{
    Font* m;

    m = CP(o);



    m->Italic = value;



    return true;
}






Int Font_GetUnderline(Int o)
{
    Font* m;

    m = CP(o);



    return m->Underline;
}






Bool Font_SetUnderline(Int o, Int value)
{
    Font* m;

    m = CP(o);



    m->Underline = value;


    return true;
}







Int Font_GetOverline(Int o)
{
    Font* m;

    m = CP(o);



    return m->Overline;
}





Bool Font_SetOverline(Int o, Int value)
{
    Font* m;

    m = CP(o);



    m->Overline = value;


    return true;
}






Int Font_GetStrikeout(Int o)
{
    Font* m;

    m = CP(o);



    return m->Strikeout;
}





Bool Font_SetStrikeout(Int o, Int value)
{
    Font* m;

    m = CP(o);



    m->Strikeout = value;


    return true;
}





Int Font_GetIntern(Int o)
{
    Font* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}
