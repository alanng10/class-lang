#pragma once

#include <QEvent>
#include <QCoreApplication>

#include "PostIntern.hpp"

#include "Probate.hpp"

struct Post
{
    Int ExecuteState;
    PostIntern* Intern;
};

#define CP(a) ((Post*)(a))
