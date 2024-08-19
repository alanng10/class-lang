#include "Frame.hpp"

CppClassNew(Frame)

Int Frame_Init(Int o)
{
    Frame* m;
    m = CP(o);

    Int size;
    size = Size_New();
    Size_Init(size);
    m->Size = size;

    FrameIntern* a;
    a = new FrameIntern;
    a->Frame = o;
    a->Init();
    a->setWindowState(Qt::WindowFullScreen);
    a->setCursor(Qt::BlankCursor);
    m->Intern = a;

    QScreen* screen;
    screen = m->Intern->screen();

    QSize ua;
    ua = screen->size();

    int w;
    int h;
    w = ua.width();
    h = ua.height();

    Int wed;
    Int het;
    wed = w;
    het = h;
    Size_WedSet(m->Size, wed);
    Size_HetSet(m->Size, het);
    return true;
}

Int Frame_Final(Int o)
{
    Frame* m;
    m = CP(o);

    delete m->Intern;

    Size_Final(m->Size);
    Size_Delete(m->Size);
    return true;
}

CppFieldGet(Frame, Size)

FieldDefaultSet(Frame, Size)

CppField(Frame, Title)

Int Frame_TitleThisSet(Int o)
{
    Frame* m;
    m = CP(o);

    QString titleU;
    Int ua;
    ua = CastInt(&titleU);

    String_QStringSet(ua, m->Title);

    m->Intern->setWindowTitle(titleU);
    return true;
}

Int Frame_VisibleGet(Int o)
{
    Frame* m;
    m = CP(o);

    bool bu;
    bu = m->Intern->isVisible();

    Bool bo;
    bo = bu;
    return bo;
}

Int Frame_VisibleSet(Int o, Int value)
{
    Frame* m;
    m = CP(o);

    bool b;
    b = !(value == 0);
    m->Intern->setVisible(b);
    return true;
}

CppField(Frame, DrawState)
CppField(Frame, TypeState)

Int Frame_VideoOut(Int o)
{
    Frame* m;
    m = CP(o);

    QPaintDevice* u;
    u = m->Intern;

    Int a;
    a = CastInt(u);
    return a;
}

Int Frame_Update(Int o, Int rect)
{
    Frame* m;
    m = CP(o);

    Int pos;
    pos = Rect_PosGet(rect);
    Int col;
    Int row;
    col = Pos_ColGet(pos);
    row = Pos_RowGet(pos);
    Int size;
    size = Rect_SizeGet(rect);
    Int wed;
    Int het;
    wed = Size_WedGet(size);
    het = Size_HetGet(size);

    int c;
    int r;
    int w;
    int h;
    c = col;
    r = row;
    w = wed;
    h = het;
    m->Intern->update(c, r, w, h);
    return true;
}

Int Frame_Close(Int o)
{
    Frame* m;
    m = CP(o);
    m->Intern->close();
    return true;
}