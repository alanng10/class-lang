include(../exe_console.pri)

HEADERS += \
    Demo.h

SOURCES += \
    main.c

LIBS += -L$$PWD/../../Out/InfraDeploy/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
