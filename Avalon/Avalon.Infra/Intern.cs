namespace Avalon.Infra;

public class Intern : Any
{
    public static Intern This { get; } = ShareCreate();

    private static Intern ShareCreate()
    {
        Intern share;
        share = new Intern();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    [SystemThreadStatic]
    public static object ThisThread = null;

    public virtual String StringNew()
    {
        String a;
        a = new String();
        a.Init();
        return a;
    }

    public virtual object StringValueGet(String k)
    {
        return k.Value;
    }

    public virtual bool StringValueSet(String k, object value)
    {
        k.Value = value;
        return true;
    }

    public virtual long StringCountGet(String k)
    {
        return k.Count;
    }

    public virtual bool StringCountSet(String k, long value)
    {
        k.Count = value;
        return true;
    }

    public virtual object DataNew(long count)
    {
        return new byte[count];
    }

    public virtual long DataGet(object data, long index)
    {
        byte[] k;
        k = data as byte[];

        return k[index];
    }

    public virtual bool DataSet(object data, long index, long value)
    {
        byte[] k;
        k = data as byte[];

        byte ob;
        ob = (byte)value;

        k[index] = ob;

        return true;
    }

    public virtual object ArrayNew(long count)
    {
        return new object[count];
    }

    public virtual object ArrayGet(object array, long index)
    {
        object[] k;
        k = array as object[];

        return k[index];
    }

    public virtual bool ArraySet(object array, long index, object value)
    {
        object[] k;
        k = array as object[];

        k[index] = value;

        return true;
    }

    public virtual ulong MaidePointer(SystemDelegate d)
    {
        SystemIntPtr u;
        u = Marshal.GetFunctionPointerForDelegate(d);
        ulong a;
        a = (ulong)u;
        return a;
    }

    public virtual ulong TextCodeCount(ulong innKind, ulong outKind, ulong data, ulong dataIndex, ulong dataCount)
    {
        ulong dataValue;
        dataValue = data + dataIndex;

        ulong a;
        a = Extern.TextCode_ExecuteCount(0, innKind, outKind, dataValue, dataCount);
        return a;
    }

    public virtual bool TextCodeResult(ulong result, ulong resultIndex, ulong innKind, ulong outKind, ulong data, ulong dataIndex, ulong dataCount)
    {
        ulong resultValue;
        resultValue = result + resultIndex;

        ulong dataValue;
        dataValue = data + dataIndex;

        Extern.TextCode_ExecuteResult(0, resultValue, innKind, outKind, dataValue, dataCount);
        return true;
    }

    public virtual ulong TextCodeCountArray(ulong innKind, ulong outKind, object data, ulong dataIndex, ulong dataCount)
    {
        ulong a;
        a = 0;

        byte[] k;
        k = data as byte[];

        unsafe
        {
            fixed (byte* p = k)
            {
                ulong dataU;
                dataU = (ulong)p;

                a = this.TextCodeCount(innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return a;
    }

    public virtual ulong TextCodeCountString(ulong innKind, ulong outKind, string data, ulong dataIndex, ulong dataCount)
    {
        ulong a;
        a = 0;

        unsafe
        {
            fixed (char* p = data)
            {
                ulong dataU;
                dataU = (ulong)p;

                a = this.TextCodeCount(innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return a;
    }

    public virtual bool TextCodeResultArray(ulong result, ulong resultIndex, ulong innKind, ulong outKind, object data, ulong dataIndex, ulong dataCount)
    {
        byte[] k;
        k = data as byte[];

        unsafe
        {
            fixed (byte* p = k)
            {
                ulong dataU;
                dataU = (ulong)p;

                this.TextCodeResult(result, resultIndex, innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return true;
    }

    public virtual bool TextCodeResultString(ulong result, ulong resultIndex, ulong innKind, ulong outKind, string data, ulong dataIndex, ulong dataCount)
    {
        unsafe
        {
            fixed (char* p = data)
            {
                ulong dataU;
                dataU = (ulong)p;

                this.TextCodeResult(result, resultIndex, innKind, outKind, dataU, dataIndex, dataCount);
            }
        }
        return true;
    }

    public virtual bool TextCodeResultArrayArray(object result, ulong resultIndex, ulong innKind, ulong outKind, object data, ulong dataIndex, ulong dataCount)
    {
        byte[] k;
        k = result as byte[];

        unsafe
        {
            fixed (byte* p = k)
            {
                ulong resultU;
                resultU = (ulong)p;

                this.TextCodeResultArray(resultU, resultIndex, innKind, outKind, data, dataIndex, dataCount);
            }
        }
        return true;
    }

    public virtual bool TextCodeResultStringArray(byte[] result, ulong resultIndex, ulong innKind, ulong outKind, string data, ulong dataIndex, ulong dataCount)
    {
        unsafe
        {
            fixed (byte* p = result)
            {
                ulong resultU;
                resultU = (ulong)p;

                this.TextCodeResultString(resultU, resultIndex, innKind, outKind, data, dataIndex, dataCount);
            }
        }
        return true;
    }

    public virtual bool StreamRead(ulong stream, object dataValue, ulong data, ulong range)
    {
        byte[] k;
        k = dataValue as byte[];

        unsafe
        {
            fixed (byte* p = k)
            {
                ulong u;
                u = (ulong)p;

                ulong ka;
                ka = u;

                Extern.Data_ValueSet(data, ka);

                Extern.Stream_Read(stream, data, range);

                Extern.Data_ValueSet(data, 0);
            }
        }
        return true;
    }

    public virtual bool StreamWrite(ulong stream, object dataValue, ulong data, ulong range)
    {
        byte[] k;
        k = dataValue as byte[];

        unsafe
        {
            fixed (byte* p = k)
            {
                ulong u;
                u = (ulong)p;

                ulong ka;
                ka = u;

                Extern.Data_ValueSet(data, ka);

                Extern.Stream_Write(stream, data, range);

                Extern.Data_ValueSet(data, 0);
            }
        }
        return true;
    }

    public virtual bool CopyToByteArray(ulong source, object dest, ulong index, ulong count)
    {
        byte[] k;
        k = dest as byte[];

        unsafe
        {
            fixed (byte* uu = k)
            {
                byte* destP;
                destP = uu + index;

                ulong destU;
                destU = (ulong)destP;

                Extern.Environ_Copy(destU, source, count);
            }
        }
        return true;
    }

    public virtual bool CopyFromByteArray(ulong dest, object source, ulong index, ulong count)
    {
        byte[] k;
        k = source as byte[];

        unsafe
        {
            fixed (byte* uu = k)
            {
                byte* sourceP;
                sourceP = uu + index;

                ulong sourceU;
                sourceU = (ulong)sourceP;

                Extern.Environ_Copy(dest, sourceU, count);
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