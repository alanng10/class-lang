#pragma once

#include "Probate.h"

typedef struct
{
}
TextEncode;

typedef Int (*TextEncode_CountMaide)(Int o, Int data);
typedef Int (*TextEncode_ResultMaide)(Int o, Int result, Int data);

Int TextEncode_ExecuteCount32To8(Int o, Int data);
Int TextEncode_ExecuteCount32To16(Int o, Int data);
Int TextEncode_ExecuteCount16To8(Int o, Int data);
Int TextEncode_ExecuteCount16To32(Int o, Int data);
Int TextEncode_ExecuteCount8To16(Int o, Int data);
Int TextEncode_ExecuteCount8To32(Int o, Int data);

Int TextEncode_ExecuteResult32To8(Int o, Int result, Int data);
Int TextEncode_ExecuteResult32To16(Int o, Int result, Int data);
Int TextEncode_ExecuteResult16To8(Int o, Int result, Int data);
Int TextEncode_ExecuteResult16To32(Int o, Int result, Int data);
Int TextEncode_ExecuteResult8To16(Int o, Int result, Int data);
Int TextEncode_ExecuteResult8To32(Int o, Int result, Int data);

#define Read8 \
{\
        b = false;\
\
        Byte ooa;\
        ooa = p[i];\
\
        Int aaa;\
        aaa = ooa;\
\
        Char oc;\
        oc = 0;\
\
        if ((aaa >> 7) == 0)\
        {\
            Int akaa;\
            akaa = aaa;\
\
            oc = akaa;\
\
            i = i + 1;\
\
            b = true;\
        }\
\
        if ((aaa >> 5) == 0x6)\
        {\
            Int akb;\
            akb = i + 2;\
\
            if (!(count < akb))\
            {\
                Byte akboa;\
                Byte akbob;\
                akboa = p[i + 1];\
                akbob = ooa;\
\
                Int akba;\
                Int akbb;\
                Int akbc;\
                akba = akboa & 0xf;\
                akbb = ((akboa >> 4) & 0x3) | ((akbob & 0x3) << 2);\
                akbc = (akbob >> 2) & 0x7;\
\
                Int kkb;\
                kkb = 0;\
                kkb = kkb | (akba << (4 * 0));\
                kkb = kkb | (akbb << (4 * 1));\
                kkb = kkb | (akbc << (4 * 2));\
\
                oc = kkb;\
\
                i = akb;\
\
                b = true;\
            }\
        }\
\
        if ((aaa >> 4) == 0xe)\
        {\
            Int akc;\
            akc = i + 3;\
\
            if (!(count < akc))\
            {\
                Byte akcoa;\
                Byte akcob;\
                Byte akcoc;\
                akcoa = p[i + 2];\
                akcob = p[i + 1];\
                akcoc = ooa;\
\
                Int akca;\
                Int akcb;\
                Int akcc;\
                Int akcd;\
                akca = akcoa & 0xf;\
                akcb = ((akcoa >> 4) & 0x3) | ((akcob & 0x3) << 2);
                akcc = (akcob >> 2) & 0xf;
                akcd = akcoc & 0xf;

                Int kkc;
                kkc = 0;
                kkc = kkc | (akca << (4 * 0));
                kkc = kkc | (akcb << (4 * 1));
                kkc = kkc | (akcc << (4 * 2));
                kkc = kkc | (akcd << (4 * 3));

                oc = kkc;

                i = akc;

                b = true;
            }
        }

        if ((aaa >> 3) == 0x1e)
        {
            Int akd;
            akd = i + 4;

            if (!(count < akd))
            {
                Byte akdoa;
                Byte akdob;
                Byte akdoc;
                Byte akdod;
                akdoa = p[i + 3];
                akdob = p[i + 2];
                akdoc = p[i + 1];
                akdod = ooa;

                Int akda;
                Int akdb;
                Int akdc;
                Int akdd;
                Int akde;
                Int akdf;
                akda = akdoa & 0xf;
                akdb = ((akdoa >> 4) & 0x3) | ((akdob & 0x3) << 2);
                akdc = (akdob >> 2) & 0xf;
                akdd = akdoc & 0xf;
                akde = ((akdoc >> 4) & 0x3) | ((akdod & 0x3) << 2);
                akdf = (akdod >> 2) & 0x1;

                Int kkd;
                kkd = 0;
                kkd = kkd | (akda << (4 * 0));
                kkd = kkd | (akdb << (4 * 1));
                kkd = kkd | (akdc << (4 * 2));
                kkd = kkd | (akdd << (4 * 3));
                kkd = kkd | (akde << (4 * 4));
                kkd = kkd | (akdf << (4 * 5));

                oc = kkd;

                i = akd;

                b = true;
            }
        }
}\


#define Write8 \
{\
        Int ka;\
        Int kb;\
        Int kc;\
        Int kd;\
        Int ke;\
        Int kf;\
\
        ka = (oc >> (4 * 0)) & 0xf;\
        kb = (oc >> (4 * 1)) & 0xf;\
        kc = (oc >> (4 * 2)) & 0xf;\
        kd = (oc >> (4 * 3)) & 0xf;\
        ke = (oc >> (4 * 4)) & 0xf;\
        kf = (oc >> (4 * 5)) & 0x1;\
\
        if (oc < 0x80)\
        {\
            Int kaa;\
            kaa = 0;\
            kaa = kaa | ka;\
            kaa = kaa | (kb << 4);\
            kaa = kaa & 0x7f;\
\
            Byte oaa;\
            oaa = kaa;\
\
            dest[k + 0] = oaa;\
\
            k = k + 1;\
        }\
\
        if (!(oc < 0x80) & oc < 0x800)\
        {\
            Int kba;\
            kba = 0;\
            kba = kba | ka;\
            kba = kba | ((kb & 0x3) << 4);\
            kba = kba | 0x80;\
\
            Int kbb;\
            kbb = 0;\
            kbb = kbb | (kb >> 2);\
            kbb = kbb | ((kc & 0x7) << 2);\
            kbb = kbb | 0xc0;\
\
            Byte oba;\
            Byte obb;\
\
            oba = kba;\
            obb = kbb;\
\
            dest[k + 0] = obb;\
            dest[k + 1] = oba;\
\
            k = k + 2;\
        }\
\
        if (!(oc < 0x800) & oc < 0x10000)\
        {\
            Int kca;\
            kca = 0;\
            kca = kca | ka;\
            kca = kca | ((kb & 0x3) << 4);\
            kca = kca | 0x80;\
\
            Int kcb;\
            kcb = 0;\
            kcb = kcb | (kb >> 2);\
            kcb = kcb | (kc << 2);\
            kcb = kcb | 0x80;\
\
            Int kcc;\
            kcc = 0;\
            kcc = kcc | kd;\
            kcc = kcc | 0xe0;\
\
            Byte oca;\
            Byte ocb;\
            Byte occ;\
\
            oca = kca;\
            ocb = kcb;\
            occ = kcc;\
\
            dest[k + 0] = occ;\
            dest[k + 1] = ocb;\
            dest[k + 2] = oca;\
\
            k = k + 3;\
        }\
\
        if (!(oc < 0x10000) & oc < 0x110000)\
        {\
            Int kda;\
            kda = 0;\
            kda = kda | ka;\
            kda = kda | ((kb & 0x3) << 4);\
            kda = kda | 0x80;\
\
            Int kdb;\
            kdb = 0;\
            kdb = kdb | (kb >> 2);\
            kdb = kdb | (kc << 2);\
            kdb = kdb | 0x80;\
\
            Int kdc;\
            kdc = 0;\
            kdc = kdc | kd;\
            kdc = kdc | ((ke & 0x3) << 4);\
            kdc = kdc | 0x80;\
\
            Int kdd;\
            kdd = 0;\
            kdd = kdd | (ke >> 2);\
            kdd = kdd | (kf << 2);\
            kdd = kdd | 0xf0;\
\
            Byte oda;\
            Byte odb;\
            Byte odc;\
            Byte odd;\
\
            oda = kda;\
            odb = kdb;\
            odc = kdc;\
            odd = kdd;\
\
            dest[k + 0] = odd;\
            dest[k + 1] = odc;\
            dest[k + 2] = odb;\
            dest[k + 3] = oda;\
\
            k = k + 4;\
        }\
}\


#define Write16 \
{\
        if (oc < 0x10000)\
        {\
            Int16 oaa;\
            oaa = oc;\
\
            dest[k + 0] = oaa;\
\
            k = k + 1;\
        }\
\
        if (!(oc < 0x10000))\
        {\
            Int koa;\
            koa = oc;\
            koa = koa - 0x10000;\
\
            Int kba;\
            kba = koa & 0x3ff;\
            kba = kba + 0xdc00;\
\
            Int kbb;\
            kbb = (koa >> 10) & 0x3ff;\
            kbb = kbb + 0xd800;\
\
            Int16 oba;\
            Int16 obb;\
\
            oba = kba;\
            obb = kbb;\
\
            dest[k + 0] = obb;\
            dest[k + 1] = oba;\
\
            k = k + 2;\
        }\
}\


#define Write32 \
{\
        dest[k + 0] = oc;\
\
        k = k + 1;\
}\

