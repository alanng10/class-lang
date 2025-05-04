#include "Console_Windows.h"

Int Console_OS_Init()
{
    SetConsoleOutputCP(CP_UTF8);

    SetConsoleCP(CP_UTF8);
    return true;
}