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
    Environ.h \
    Font.hpp \
    FontStore.hpp \
    Form.hpp \
    Format.h \
    FormatArg.h \
    Frame.hpp \
    FrameIntern.hpp \
    Image.hpp \
    ImageRead.hpp \
    ImageWrite.hpp \
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
    Pronate.h \
    Pronate.hpp \
    Program.hpp \
    Prusate.h \
    Rand.hpp \
    Range.h \
    Rect.h \
    Screen.hpp \
    Share.hpp \
    Size.h \
    Slash.hpp \
    Stat.hpp \
    State.h \
    Storage.hpp \
    StorageComp.hpp \
    StorageEntry.h \
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
    Environ.c \
    Font.cpp \
    FontStore.cpp \
    Form.cpp \
    Format.c \
    FormatArg.c \
    Frame.cpp \
    FrameIntern.cpp \
    Image.cpp \
    ImageRead.cpp \
    ImageWrite.cpp \
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
    Polate.cpp \
    PolateLinear.cpp \
    PolateRadial.cpp \
    PolateStop.cpp \
    Pos.c \
    Program.cpp \
    Rand.cpp \
    Range.c \
    Rect.c \
    Screen.cpp \
    Share.cpp \
    Size.c \
    Slash.cpp \
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
    Stat_BrushKind.cpp \
    Stat_SlashCape.cpp \
    Stat_SlashJoin.cpp \
    Stat_SlashLine.cpp \
    Stat_PolateKind.cpp \
    Stat_PolateSpread.cpp \
    Stat_Comp.cpp \
    Stat_ImageFormat.cpp \
    State.c \
    Storage.cpp \
    StorageComp.cpp \
    StorageEntry.c \
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

unix {

HEADERS += \
    Main_Linux.h \
    Environ_Linux.h \
    Thread_Linux.h \
    Console_Linux.h

SOURCES += \
    Main_Linux.c \
    Environ_Linux.c \
    Thread_Linux.c \
    Console_Linux.c

}

win32 {

HEADERS += \
    Main_Windows.h \
    Environ_Windows.h \
    Thread_Windows.h \
    Console_Windows.h

SOURCES += \
    Main_Windows.c \
    Environ_Windows.c \
    Thread_Windows.c \
    Console_Windows.c

}
