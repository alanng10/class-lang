#pragma once

#include "Pronate.hpp"

#include <QString>
#include <QLibrary>

Int ExecuteArg(Int result, Int arg);
Int ExecuteModuleString(Int result, Int moduleRef);
Int ExecuteModuleVer(Int result, Int moduleVer);
Int ExecuteModuleNameString(Int result, Int moduleName);
Int ExecuteModuleVerString(Int result, Int moduleVer);
Int ExecuteHexDigitChar(Int value);
Int ExecuteValidModuleNameChar(Int n);
