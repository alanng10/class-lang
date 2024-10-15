#pragma once

#include <signal.h>

#include <QApplication>

#include "Pronate.hpp"

struct Main
{
    Int Share;
    Int MainThread;
    Int Arg;
    Int TerminateState;
    char* Argv[2];
    Int IsCSharp;
    QApplication* Intern;
};

Int Main_InitArg();
Int Main_FinalArg();

void Main_SignalHandle(int signo);
