include(../exe_console.pri)

HEADERS += \
    Demo.h

SOURCES += \
    main.c

unix {

LIBS += -L$$PWD/../../Out/Infra-Linux-Release

}

win32 {

LIBS += -L$$PWD/../../Out/InfraDeploy

}

LIBS += -lInfra

INCLUDEPATH += $$PWD/..
