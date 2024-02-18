namespace Avalon.Intern;






public class Intern : object
{
    public static Intern This { get; } = ShareCreate();




    private static Intern ShareCreate()
    {
        Intern share;

        share = new Intern();


        share.Init();


        return share;
    }





    public virtual bool Init()
    {
        return true;
    }








    [SystemThreadStatic]
    public static object ThisThread = null;







    public virtual ulong MaidePointer(SystemDelegate d)
    {
        SystemIntPtr u;

        u = Marshal.GetFunctionPointerForDelegate(d);



        ulong a;

        a = (ulong)u;



        return a;
    }






    public virtual bool CopyText(ulong dest, char[] source, ulong index, ulong count)
    {
        unsafe
        {
            fixed (char* p = source)
            {
                char* pa;

                pa = p + index;



                ulong u;

                u = (ulong)pa;



                ulong oa;

                oa = count * 2;



                Extern.Copy(dest, u, oa);
            }
        }



        return true;
    }







    public virtual bool CopyString(ulong dest, string source, ulong index, ulong count)
    {
        unsafe
        {
            fixed (char* p = source)
            {
                char* pa;

                pa = p + index;



                ulong u;

                u = (ulong)pa;



                ulong oa;

                oa = count * 2;



                Extern.Copy(dest, u, oa);
            }
        }



        return true;
    }






    public virtual bool StreamRead(ulong stream, byte[] dataArray, ulong data, ulong range)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                ulong u;

                u = (ulong)p;



                ulong dataValue;

                dataValue = u;



                Extern.Data_SetValue(data, dataValue);



                Extern.Stream_Read(stream, data, range);



                Extern.Data_SetValue(data, 0);
            }
        }



        return true;
    }





    public virtual bool StreamWrite(ulong stream, byte[] dataArray, ulong data, ulong range)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                ulong u;

                u = (ulong)p;



                ulong dataValue;

                dataValue = u;



                Extern.Data_SetValue(data, dataValue);



                Extern.Stream_Write(stream, data, range);



                Extern.Data_SetValue(data, 0);
            }
        }



        return true;
    }





    public virtual int DataReadInt(byte[] dataArray, long index)
    {
        int o;

        o = 0;



        unsafe
        {
            fixed (byte* p = dataArray)
            {
                byte* pa;

                pa = p + index;



                int* po;

                po = (int*)pa;



                o = *po;
            }
        }



        return o;
    }






    public virtual ulong DataReadULong(byte[] dataArray, long index)
    {
        ulong o;

        o = 0;



        unsafe
        {
            fixed (byte* p = dataArray)
            {
                byte* pa;

                pa = p + index;



                ulong* po;

                po = (ulong*)pa;



                o = *po;
            }
        }



        return o;
    }






    public virtual bool DataWriteInt(byte[] dataArray, long index, int value)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                byte* pa;

                pa = p + index;



                int* po;

                po = (int*)pa;



                *po = value;
            }
        }



        return true;
    }






    public virtual bool DataWriteULong(byte[] dataArray, long index, ulong value)
    {
        unsafe
        {
            fixed (byte* p = dataArray)
            {
                byte* pa;

                pa = p + index;



                ulong* po;

                po = (ulong*)pa;



                *po = value;
            }
        }



        return true;
    }






    public virtual string StringCreate(ulong data, int count)
    {
        string a;


        unsafe
        {
            char* p;

            p = (char*)data;



            a = new string(p, 0, count);
        }


        return a;
    }





    public virtual int TextEncodeGetString(ulong intern, char[] result, int resultIndex, ulong data, byte[] dataValue, long dataIndex)
    {
        ulong k;


        unsafe
        {
            fixed (char* p = result)
            {
                fixed (byte* pa = dataValue)
                {
                    char* pu;

                    pu = p + resultIndex;



                    byte* pau;

                    pau = pa + dataIndex;



                    ulong ou;

                    ou = (ulong)pu;


                    ulong oau;

                    oau = (ulong)pau;




                    Extern.Data_SetValue(data, oau);




                    k = Extern.TextEncode_GetString(intern, ou, data);
                }
            }
        }



        int a;

        a = (int)k;


        return a;
    }






    public virtual long TextEncodeGetData(ulong intern, byte[] result, long resultIndex, ulong fromText, char[] fromTextData, int fromTextIndex)
    {
        ulong k;


        unsafe
        {
            fixed (byte* p = result)
            {
                fixed (char* pa = fromTextData)
                {
                    byte* pu;

                    pu = p + resultIndex;



                    char* pau;

                    pau = pa + fromTextIndex;



                    ulong ou;

                    ou = (ulong)pu;


                    ulong oau;

                    oau = (ulong)pau;




                    Extern.String_SetData(fromText, oau);




                    k = Extern.TextEncode_GetData(intern, ou, fromText);
                }
            }
        }



        long a;

        a = (long)k;


        return a;
    }






    public virtual bool ReturnStringResult(ulong returnA, char[] array, ulong index, ulong count, ulong text)
    {
        unsafe
        {
            fixed (char* p = array)
            {
                char* pa;

                pa = p + index;



                ulong ua;

                ua = (ulong)pa;





                Extern.String_SetCount(text, count);


                Extern.String_SetData(text, ua);



                Extern.Return_StringResult(returnA, text);
            }
        }


        return true;
    }





    public virtual bool FormatArgString(ulong format, string a, ulong fieldWidth, ulong fillChar, ulong text)
    {
        unsafe
        {
            fixed (char* p = a)
            {
                ulong u;

                u = (ulong)p;



                Extern.String_SetData(text, u);


                Extern.Format_ArgString(format, text, fieldWidth, fillChar);
            }
        }



        return true;
    }





    public virtual bool MathGetCompose(ulong math, MathCompose compose, long value)
    {
        ulong u;

        u = (ulong)value;


        unsafe
        {
            ulong oa;

            ulong ob;

            oa = 0;

            ob = 0;


            ulong* pa;

            ulong* pb;


            pa = &oa;

            pb = &ob;



            ulong ua;

            ulong ub;


            ua = (ulong)pa;

            ub = (ulong)pb;


            Extern.Math_GetCompose(math, u, ua, ub);




            compose.Significand = oa;


            compose.Exponent = ob;
        }


        return true;
    }





    public virtual bool DrawGradientStopGetPoint(ulong intern, ulong index, DrawGradientStopPoint result)
    {
        unsafe
        {
            ulong pos;

            ulong color;


            ulong* posU;

            ulong* colorU;


            posU = &pos;

            colorU = &color;



            ulong ua;

            ulong ub;


            ua = (ulong)posU;

            ub = (ulong)colorU;



            Extern.GradientStop_GetPoint(intern, index, ua, ub);



            result.Pos = pos;

            result.Color = color;
        }



        return true;
    }






    public virtual bool CopyImageData(ulong dest, int destRowByteCount, int destLeft, int destUp, ulong source, int sourceRowByteCount, int sourceLeft, int sourceUp, int width, int height)
    {
        unsafe
        {
            byte* destU;

            byte* sourceU;


            destU = (byte*)dest;

            sourceU = (byte*)source;



            byte* p;

            byte* pa;


            uint* d;

            uint* da;



            int count;

            int countA;

            int i;

            int j;


            count = height;

            countA = width;


            i = 0;

            while (i < count)
            {
                j = 0;

                while (j < countA)
                {
                    p = sourceU + (sourceUp + i) * sourceRowByteCount + (sourceLeft + j) * 4;


                    pa = destU + (destUp + i) * destRowByteCount + (destLeft + j) * 4;



                    d = (uint*)p;


                    da = (uint*)pa;


                    *da = *d;



                    j = j + 1;
                }


                i = i + 1;
            }
        }



        return true;
    }





    public virtual object HandleTarget(ulong o)
    {
        SystemIntPtr u;

        u = (SystemIntPtr)o;




        SystemGCHandle uu;

        uu = SystemGCHandle.FromIntPtr(u);





        object a;

        a = uu.Target;


        return a;
    }
}