include(../exe_console.pri)

HEADERS += \
    Execute.hpp

SOURCES += \
    Execute.cpp

LIBS += -L$$PWD/../../Out/InfraDeploy/

LIBS += -lInfra \
    -lInfraIntern

INCLUDEPATH += $$PWD/..
