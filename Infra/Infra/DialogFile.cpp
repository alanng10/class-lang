#include "DialogFile.hpp"




CppClassNew(DialogFile)







Int DialogFile_Init(Int o)
{
    DialogFile* m;

    m = CP(o);



    m->Intern = new QFileDialog;



    return true;
}





Int DialogFile_Final(Int o)
{
    DialogFile* m;

    m = CP(o);



    delete m->Intern;



    return true;
}





Int DialogFile_GetSave(Int o)
{
    DialogFile* m;

    m = CP(o);


    return m->Save;
}




Int DialogFile_SetSave(Int o, Int value)
{
    DialogFile* m;

    m = CP(o);


    m->Save = value;



    QFileDialog::AcceptMode u;

    u = (QFileDialog::AcceptMode)(m->Save);



    m->Intern->setAcceptMode(u);




    return true;
}






Int DialogFile_GetFileMode(Int o)
{
    DialogFile* m;

    m = CP(o);


    return m->FileMode;
}




Int DialogFile_SetFileMode(Int o, Int value)
{
    DialogFile* m;

    m = CP(o);


    m->FileMode = value;


    return true;
}





Int DialogFile_GetFold(Int o)
{
    DialogFile* m;

    m = CP(o);


    return m->Fold;
}




Int DialogFile_SetFold(Int o, Int value)
{
    DialogFile* m;

    m = CP(o);


    m->Fold = value;


    return true;
}



