include(../exe_console.pri)

TARGET = class

HEADERS += \
    Execute.hpp \
    Prusate.h

SOURCES += \
    Execute.cpp

LIBS += -L$$PWD/../../../../../Out/Class/

LIBS += -lInfra \
    -lInfraIntern

INCLUDEPATH += $$PWD/..
