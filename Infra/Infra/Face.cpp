#include "Face.hpp"

CppClassNew(Face)

Int Face_Init(Int o)
{
    Face* m;
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

Int Face_Final(Int o)
{
    Face* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Face, Family)
CppField(Face, Size)
CppField(Face, Weight)
CppField(Face, Italic)
CppField(Face, Underline)
CppField(Face, Overline)
CppField(Face, Strikeout)

Int Face_Intern(Int o)
{
    Face* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}