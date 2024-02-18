QT += widgets multimedia network



TEMPLATE = lib

CONFIG += c11 c++17





QMAKE_CFLAGS += -fno-strict-aliasing

QMAKE_CXXFLAGS += -fno-strict-aliasing


QMAKE_CFLAGS_WARN_ON -= -Wextra -W

QMAKE_CXXFLAGS_WARN_ON -= -Wextra -W


QMAKE_CFLAGS_WARN_ON += -Wno-bitwise-instead-of-logical

QMAKE_CXXFLAGS_WARN_ON += -Wno-bitwise-instead-of-logical