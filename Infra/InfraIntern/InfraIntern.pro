include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prudate.h \
    Intern.h \
    New.h \
    Class.h

SOURCES += \
    Intern.c \
    New.c \
    Class.c

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
