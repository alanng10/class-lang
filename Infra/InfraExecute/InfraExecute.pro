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

LIBS += -L$$PWD/../../../../../Out/Class/

LIBS += -lInfra \
    -lInfraIntern

INCLUDEPATH += $$PWD/..
