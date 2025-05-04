#include "Main.h"

int main(int argc, const char** argv)
{
    Int ka;
    Int kb;
    ka = argc;
    kb = CastInt(argv);

    int k;
    k = Execute(ka, kb);
    return k;
}