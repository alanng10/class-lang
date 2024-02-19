include(../exe.pri)




HEADERS += \
    Demo.h


SOURCES += \
    main.c



win32 {

LIBS += -L$$PWD/../Infra-Windows-Release/release/

}


!win32 {

LIBS += -L$$PWD/../Infra-Linux-Release/

}


LIBS += -lInfra


INCLUDEPATH += $$PWD/..
