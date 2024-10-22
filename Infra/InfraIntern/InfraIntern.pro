include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prusate.h \
    Prusate_Intern.h \
    Pronate.h \
    Call.h \
    Extern.h \
    Intern.h \
    Main.h \
    New.h \
    Thread.h \
    Value.h

SOURCES += \
    Call.c \
    Event.c \
    Extern.c \
    Intern.c \
    Main.c \
    New.c \
    Thread.c \
    Value.c

LIBS += -L$$PWD/../../Out/InfraDeploy/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
