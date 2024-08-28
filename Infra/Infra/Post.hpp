#pragma once

#include <QEvent>
#include <QCoreApplication>

#include "PostIntern.hpp"

#include "Pronate.hpp"

struct Post
{
    Int ExecuteState;
    PostIntern* Intern;
};

#define CP(a) ((Post*)(a))
