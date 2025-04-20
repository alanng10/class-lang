#pragma once

#include "Pronate.hpp"

#include <QString>
#include <QLibrary>

Int ExecuteMain(Int argc, Int argv);
Int ExecuteMainError(Int status, Int text);
Int ExecuteStatusWrite(Int value);
Int ExecuteArg(Int result, Int arg);
Int ExecuteModuleString(Int result, Int moduleRef);
Int ExecuteModuleVer(Int result, Int moduleRefVer);
Int ExecuteModuleNameString(Int result, Int moduleName);
Int ExecuteModuleVerString(Int result, Int moduleVer);
Int ExecuteHexDigitChar(Int value);
Int ExecuteValidModuleNameChar(Int n);
Int ExecuteStringQString(Int value);
