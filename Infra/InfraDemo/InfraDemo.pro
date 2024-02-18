include(../exe.pri)




HEADERS += \
    Demo.h


SOURCES += \
    main.c



win32 {

LIBS += -L$$PWD/../../Out/build-Infra-Windows-Release/release/

}


!win32 {

LIBS += -L$$PWD/../../Out/build-Infra-Linux-Release/

}


LIBS += -lInfra


INCLUDEPATH += $$PWD/..
