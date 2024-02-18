include(../exe.pri)




HEADERS += \
    Demo.h


SOURCES += \
    main.c



win32 {

LIBS += -L$$PWD/../../Out/build-Infra-Desktop_Qt_6_6_1_MinGW_64_bit-Release/release/

}


!win32 {

LIBS += -L$$PWD/../../Out/build-Infra-Desktop_Qt_6_6_1_GCC_64bit-Release/

}


LIBS += -lInfra


INCLUDEPATH += $$PWD/..
