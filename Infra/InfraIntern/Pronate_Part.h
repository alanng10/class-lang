#pragma once

#include "Prusate.h"

Int Intern_Intern_RefLess(Eval* eval, Int frame);
Int Intern_Intern_StringNew(Eval* eval, Int frame);
Int Intern_Intern_StringValueGet(Eval* eval, Int frame);
Int Intern_Intern_StringValueSet(Eval* eval, Int frame);
Int Intern_Intern_StringCountGet(Eval* eval, Int frame);
Int Intern_Intern_StringCountSet(Eval* eval, Int frame);
Int Intern_Intern_DataNew(Eval* eval, Int frame);
Int Intern_Intern_DataGet(Eval* eval, Int frame);
Int Intern_Intern_DataSet(Eval* eval, Int frame);
Int Intern_Intern_ArrayNew(Eval* eval, Int frame);
Int Intern_Intern_ArrayGet(Eval* eval, Int frame);
Int Intern_Intern_ArraySet(Eval* eval, Int frame);
