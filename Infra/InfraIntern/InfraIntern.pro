include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prudate.h \
    Intern.h \
    New.h \
    Class.h \
    Any.h

SOURCES += \
    Intern.c \
    New.c \
    Class.c \
    Any.c

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
