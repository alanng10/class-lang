#include "Memory.hpp"






CppClassNew(Memory)







Int Memory_Init(Int o)
{
    return true;
}




Int Memory_Final(Int o)
{
    return true;
}






Int Memory_GetStream(Int o)
{
    Memory* m;

    m = CP(o);


    return m->Stream;
}




Bool Memory_SetStream(Int o, Int value)
{
    Memory* m;

    m = CP(o);


    m->Stream = value;


    return true;
}






Bool Memory_Open(Int o)
{
    Memory* m;

    m = CP(o);





    Int stream;

    stream = m->Stream;





    QIODeviceBase::OpenModeFlag modeU;

    modeU = QIODeviceBase::ReadWrite;





    QBuffer* buffer;


    buffer = new QBuffer();





    buffer->open(modeU);






    QIODevice* oo;

    oo = buffer;




    Int uo;

    uo = CastInt(oo);






    Int aaa;


    aaa = Infra_Share();



    Int stat;

    stat = Share_Stat(aaa);




    Int kind;

    kind = Stat_StreamKindMemory(stat);




    Bool canRead;

    canRead = true;



    Bool canWrite;

    canWrite = true;





    Stream_SetKind(stream, kind);


    Stream_SetValue(stream, uo);




    Stream_SetCanRead(stream, canRead);


    Stream_SetCanWrite(stream, canWrite);





    return true;
}









Bool Memory_Close(Int o)
{
    Memory* m;

    m = CP(o);




    Int stream;

    stream = m->Stream;




    Int value;


    value = Stream_GetValue(stream);




    QIODevice* oo;


    oo = (QIODevice*)value;




    QBuffer* buffer;


    buffer = (QBuffer*)oo;



    buffer->close();




    delete buffer;





    Stream_SetKind(stream, null);



    Stream_SetValue(stream, null);





    return true;
}




