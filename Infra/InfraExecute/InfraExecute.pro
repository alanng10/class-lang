include(../exe_console.pri)

TARGET = class

HEADERS += \
    Execute.hpp

SOURCES += \
    Execute.cpp

LIBS += -L$$PWD/../../../../../Out/Class/

LIBS += -lInfra \
    -lInfraIntern

INCLUDEPATH += $$PWD/..
