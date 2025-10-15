include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prusate.h \
    Prusate_Extern.h \
    Prusate_Intern.h \
    Pronate.h \
    Call.h \
    Cast.h \
    Extern.h \
    Intern.h \
    Main.h \
    Memory.h \
    Share.h \
    State.h \
    Thread.h \
    Value.h

SOURCES += \
    Call.c \
    Cast.c \
    Extern.c \
    Intern.c \
    Main.c \
    Memory.c \
    Share.c \
    State.c \
    Thread.c \
    Value.c

unix {

LIBS += -L$$PWD/../../Out/Infra-Linux-Release

}

win32 {

LIBS += -L$$PWD/../../Out/InfraDeploy

}

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
