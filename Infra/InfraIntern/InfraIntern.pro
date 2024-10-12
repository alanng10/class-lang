include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prusate.h \
    Prusate_Part.h \
    Pronate.h \
    Call.h \
    Init.h \
    Intern.h \
    New.h \
    Thread.h

SOURCES += \
    Call.c \
    Event.c \
    Init.c \
    Intern.c \
    New.c \
    Thread.c

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
