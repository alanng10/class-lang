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

CppField(Memory, Stream)

Int Memory_Open(Int o)
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





    Stream_KindSet(stream, kind);


    Stream_ValueSet(stream, uo);




    Stream_CanReadSet(stream, canRead);


    Stream_CanWriteSet(stream, canWrite);





    return true;
}

Int Memory_Close(Int o)
{
    Memory* m;

    m = CP(o);




    Int stream;

    stream = m->Stream;




    Int value;


    value = Stream_ValueGet(stream);




    QIODevice* oo;


    oo = (QIODevice*)value;




    QBuffer* buffer;


    buffer = (QBuffer*)oo;



    buffer->close();




    delete buffer;





    Stream_KindSet(stream, null);



    Stream_ValueSet(stream, null);





    return true;
}