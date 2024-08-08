#include "Stat.hpp"

Int Stat_Var_TextEncodeKindUtf8 = QStringConverter::Utf8 + 1;
Int Stat_Var_TextEncodeKindUtf16 = QStringConverter::Utf16 + 1;
Int Stat_Var_TextEncodeKindUtf32 = QStringConverter::Utf32 + 1;

Int Stat_TextEncodeKindUtf8(Int o)
{
    return Stat_Var_TextEncodeKindUtf8;
}
Int Stat_TextEncodeKindUtf16(Int o)
{
    return Stat_Var_TextEncodeKindUtf16;
}
Int Stat_TextEncodeKindUtf32(Int o)
{
    return Stat_Var_TextEncodeKindUtf32;
}
