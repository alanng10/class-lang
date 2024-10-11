include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prusate.h \
    Pronate.h \
    Pronate_Part.h \
    Intern.h \
    New.h

SOURCES += \
    Event.c \
    Intern.c \
    New.c

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
