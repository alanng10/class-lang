#include "Font.hpp"

CppClassNew(Font)

Int Font_Init(Int o)
{
    Font* m;
    m = CP(o);

    QString nameString;
    Int ua;
    ua = CastInt(&nameString);

    String_QStringSet(ua, m->Name);

    int sizeU;
    sizeU = m->Size;

    int weightU;
    weightU = m->Strong;

    bool italicU;
    italicU = m->Tenden;

    bool underlineU;
    underlineU = m->Staline;

    bool strikeoutU;
    strikeoutU = m->Midline;

    bool overlineU;
    overlineU = m->Endline;

    m->Intern = new QFont(nameString, sizeU, weightU, italicU);
    m->Intern->setStyleHint(QFont::AnyStyle, QFont::PreferAntialias);
    m->Intern->setUnderline(underlineU);
    m->Intern->setStrikeOut(strikeoutU);
    m->Intern->setOverline(overlineU);
    return true;
}

Int Font_Final(Int o)
{
    Font* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Font, Name)
CppField(Font, Size)
CppField(Font, Strong)
CppField(Font, Tenden)
CppField(Font, Staline)
CppField(Font, Midline)
CppField(Font, Endline)

Int Font_Intern(Int o)
{
    Font* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}