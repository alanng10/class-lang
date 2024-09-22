include(../module.pri)

DEFINES += Infra_Module

HEADERS += \
    AString.hpp \
    Array.h \
    AudioOut.hpp \
    Brush.hpp \
    Console.hpp \
    Data.h \
    Draw.hpp \
    Entry.h \
    Face.hpp \
    Form.hpp \
    Format.h \
    FormatArg.h \
    Frame.hpp \
    FrameIntern.hpp \
    Image.hpp \
    ImageRead.hpp \
    ImageWrite.hpp \
    Maide.h \
    Main.hpp \
    Math.hpp \
    Memory.hpp \
    Network.hpp \
    NetworkHandle.hpp \
    NetworkHost.hpp \
    NetworkHostIntern.hpp \
    NetworkPort.hpp \
    Phore.hpp \
    Play.hpp \
    PointData.hpp \
    Polate.hpp \
    PolateLinear.hpp \
    PolateRadial.hpp \
    PolateStop.hpp \
    Pos.h \
    Post.hpp \
    PostIntern.hpp \
    Pronate.h \
    Pronate.hpp \
    Program.hpp \
    ProgramIntern.hpp \
    Prusate.h \
    Rand.hpp \
    Range.h \
    Rect.h \
    Share.hpp \
    Size.h \
    Stat.hpp \
    State.h \
    Storage.hpp \
    StorageComp.hpp \
    Stream.hpp \
    TextCode.h \
    Thread.hpp \
    ThreadIntern.hpp \
    Time.hpp \
    TimeEvent.hpp \
    TimeEventIntern.hpp \
    VideoFrame.hpp \
    VideoOut.hpp \
    VideoOutIntern.hpp

SOURCES += \
    AString.cpp \
    Array.c \
    AudioOut.cpp \
    Brush.cpp \
    Console.cpp \
    Data.c \
    Draw.cpp \
    Entry.c \
    Face.cpp \
    Form.cpp \
    Format.c \
    FormatArg.c \
    Frame.cpp \
    FrameIntern.cpp \
    Polate.cpp \
    PolateLinear.cpp \
    PolateRadial.cpp \
    PolateStop.cpp \
    Image.cpp \
    ImageRead.cpp \
    ImageWrite.cpp \
    Maide.c \
    Main.cpp \
    Math.cpp \
    Math_Part.cpp \
    Memory.cpp \
    Network.cpp \
    NetworkHandle.cpp \
    NetworkHost.cpp \
    NetworkHostIntern.cpp \
    NetworkPort.cpp \
    Phore.cpp \
    Play.cpp \
    PointData.cpp \
    Pos.c \
    Post.cpp \
    PostIntern.cpp \
    Program.cpp \
    ProgramIntern.cpp \
    Rand.cpp \
    Range.c \
    Rect.c \
    Share.cpp \
    Size.c \
    Stat.cpp \
    Stat_PointData.cpp \
    Stat_TextAlign.cpp \
    Stat_TextCodeKind.cpp \
    Stat_ThreadCase.cpp \
    Stat_StreamKind.cpp \
    Stat_StorageMode.cpp \
    Stat_StorageStatus.cpp \
    Stat_NetworkCase.cpp \
    Stat_NetworkPortKind.cpp \
    Stat_NetworkStatus.cpp \
    Stat_BrushCap.cpp \
    Stat_BrushJoin.cpp \
    Stat_BrushKind.cpp \
    Stat_BrushLine.cpp \
    Stat_PolateKind.cpp \
    Stat_PolateSpread.cpp \
    Stat_Comp.cpp \
    Stat_ImageBinary.cpp \
    State.c \
    Storage.cpp \
    StorageComp.cpp \
    Stream.cpp \
    TextCode.c \
    Thread.cpp \
    ThreadIntern.cpp \
    Time.cpp \
    TimeEvent.cpp \
    TimeEventIntern.cpp \
    VideoFrame.cpp \
    VideoOut.cpp \
    VideoOutIntern.cpp



win32 {

HEADERS += \
    Thread_Windows.h \
    Console_Windows.h

SOURCES += \
    Thread_Windows.c \
    Console_Windows.c

}
