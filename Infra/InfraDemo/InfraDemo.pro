include(../exe.pri)


CONFIG += console


HEADERS += \
    Demo.h


SOURCES += \
    main.c



win32 {

LIBS += -L$$PWD/../../Out/Infra-Windows-Release/release/

}


!win32 {

LIBS += -L$$PWD/../../Out/Infra-Linux-Release/

}


LIBS += -lInfra


INCLUDEPATH += $$PWD/..
