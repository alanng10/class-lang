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
    weightU = m->Weight;

    bool italicU;
    italicU = m->Italic;

    bool underlineU;
    underlineU = m->Underline;

    bool overlineU;
    overlineU = m->Overline;

    bool strikeoutU;
    strikeoutU = m->Strikeout;

    m->Intern = new QFont(nameString, sizeU, weightU, italicU);
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

CppField(Font, Name)
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
    Int a;
    a = CastInt(m->Intern);
    return a;
}