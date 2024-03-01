#include "Post.hpp"




CppClassNew(Post)






Int Post_Init(Int o)
{
    Post* m;

    m = CP(o);




    m->Intern = new PostIntern();


    m->Intern->Post = o;


    m->Intern->Init();




    return true;
}





Int Post_Final(Int o)
{
    Post* m;

    m = CP(o);




    delete m->Intern;




    return true;
}

CppField(Post, ExecuteState)

Int Post_Execute(Int o)
{
    Post* m;

    m = CP(o);




    QEvent* u;

    u = new QEvent(QEvent::User);



    QCoreApplication::postEvent(m->Intern, u);




    return true;
}





Int Post_ExecuteHandle(Int o)
{
    Post* m;

    m = CP(o);



    Int state;

    state = m->ExecuteState;



    Int aa;

    aa = State_MaideGet(state);


    Int arg;

    arg = State_ArgGet(state);




    Post_Execute_Maide maide;

    maide = (Post_Execute_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}
