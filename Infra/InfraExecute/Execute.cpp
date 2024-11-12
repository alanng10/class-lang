#include "Execute.hpp"

int main()
{
    Main_Init();

    Int eval;

    eval = Intern_Init();

    Int a;
    a = Intern_Execute(eval);

    Intern_Final(eval);

    Main_Final();

    return a;
}