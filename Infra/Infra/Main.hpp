#pragma once

#include <signal.h>

#include <QApplication>
#include <QSysInfo>
#include <QScreen>

#include "Pronate.hpp"

struct Main
{
    Int Share;
    Int MainThread;
    Int Arg;
    Int ArgC;
    Int ArgV;
    Int Compute;
    int Argc;
    char* Argv[2];
    Int TerminateState;
    Int IsCSharp;
    Int ThreadStorage;
    QApplication* Intern;
};

Int Main_InitArg();
Int Main_FinalArg();

void Main_SignalHandle(int signo);
