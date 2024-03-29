include(../exe_console.pri)

HEADERS += \
    Demo.h

SOURCES += \
    main.c

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
