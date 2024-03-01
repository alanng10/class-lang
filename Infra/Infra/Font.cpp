#include "Font.hpp"

CppClassNew(Font)

Int Font_Init(Int o)
{
    Font* m;

    m = CP(o);





    QString familyString;



    Int ua;

    ua = CastInt(&familyString);



    String_QStringSet(ua, m->Family);





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

CppField(Font, Family)
CppField(Font, Size)
CppField(Font, Weight)
CppField(Font, Italic)
CppField(Font, Underline)
CppField(Font, Overline)
CppField(Font, Strikeout)

Int Font_Intern(Int o)
{
    Font* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}