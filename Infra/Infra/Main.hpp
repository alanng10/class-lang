#pragma once



#include <signal.h>


#include <QApplication>



#include "Probate.hpp"




struct Main
{
    Int Share;



    Int MainThread;



    Int TerminateState;



    char* Argv[2];



    Bool IsCSharp;




    QApplication* Intern;
};





void Main_SignalHandle(int signo);