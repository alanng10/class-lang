include(../exe_console.pri)

TARGET = class

HEADERS += \
    Execute.hpp \
    Main.h \
    Pronate.h \
    Pronate.hpp \
    Prusate.h

SOURCES += \
    Execute.cpp \
    Main.c

LIBS += -L$$PWD/../../Out/InfraDeploy/ \
    -L$$PWD/../../Out/InfraIntern-Windows-Release/release/

LIBS += -lInfra \
    -lInfraIntern

INCLUDEPATH += $$PWD/..
