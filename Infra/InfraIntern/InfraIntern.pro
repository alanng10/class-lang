include(../module.pri)

DEFINES += InfraIntern_Module

HEADERS += \
    Prudate.h \
    Probate.h

SOURCES += \
    Intern.c

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
