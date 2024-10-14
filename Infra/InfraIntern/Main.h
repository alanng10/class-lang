#pragma once

#include "Pronate.h"

Bool Intern_ModuleInit(Int entryModuleInit);

Int Intern_ModuleInit_ModuleCount(Int module);

Int Intern_ModuleInit_ModuleSet(Int module);

Bool Intern_ClassSharePhoreInit();

Bool Intern_ClassSharePhoreInitModule(Module* module);

Bool Intern_NewInit();
