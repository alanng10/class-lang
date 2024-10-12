include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prusate.h \
    Prusate_Part.h \
    Pronate.h \
    Intern.h \
    New.h \
    Thread.h

SOURCES += \
    Event.c \
    Intern.c \
    New.c \
    Thread.c

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
