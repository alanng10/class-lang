#pragma once





#include <QProcessEnvironment>



#include "ProcessIntern.hpp"



#include "Probate.hpp"





struct Process
{
    Int Program;


    Int Argue;


    Int WorkFold;


    Int Environment;




    Int StartedState;


    Int FinishedState;



    ProcessIntern* Intern;
};





#define CP(a) ((Process*)(a))





Int Process_InternSetArgue(Int result, Int argue);



Int Process_InternSetEnvironment(Int result, Int environment);


