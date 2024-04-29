namespace Avalon.Network;

public class StatusList : Any
{
    public static StatusList This { get; } = ShareCreate();

    private static StatusList ShareCreate()
    {
        StatusList share;
        share = new StatusList();
        Any a;
        a = share;
        a.Init();
        return share;
    }

    public override bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count = this.Array.Count;
        this.Index = 0;

        this.NoError = this.AddItem();
        this.UnknownSocketError = this.AddItem();
        this.ConnectionRefusedError = this.AddItem();
        this.RemoteHostClosedError = this.AddItem();
        this.HostNotFoundError = this.AddItem();
        this.SocketAccessError = this.AddItem();
        this.SocketResourceError = this.AddItem();
        this.SocketTimeoutError = this.AddItem();
        this.DatagramTooLargeError = this.AddItem();
        this.NetworkError = this.AddItem();
        this.AddressInUseError = this.AddItem();
        this.SocketAddressNotAvailableError = this.AddItem();
        this.UnsupportedSocketOperationError = this.AddItem();
        this.UnfinishedSocketOperationError = this.AddItem();
        this.ProxyAuthenticationRequiredError = this.AddItem();
        this.SslHandshakeFailedError = this.AddItem();
        this.ProxyConnectionRefusedError = this.AddItem();
        this.ProxyConnectionClosedError = this.AddItem();
        this.ProxyConnectionTimeoutError = this.AddItem();
        this.ProxyNotFoundError = this.AddItem();
        this.ProxyProtocolError = this.AddItem();
        this.OperationError = this.AddItem();
        this.SslInternalError = this.AddItem();
        this.SslInvalidUserDataError = this.AddItem();
        this.TemporaryError = this.AddItem();
        return true;
    }

    public virtual Status NoError { get { return __D_NoError; } set { __D_NoError = value; } }
    protected Status __D_NoError;
    public virtual Status UnknownSocketError { get { return __D_UnknownSocketError; } set { __D_UnknownSocketError = value; } }
    protected Status __D_UnknownSocketError;
    public virtual Status ConnectionRefusedError { get { return __D_ConnectionRefusedError; } set { __D_ConnectionRefusedError = value; } }
    protected Status __D_ConnectionRefusedError;
    public virtual Status RemoteHostClosedError { get { return __D_RemoteHostClosedError; } set { __D_RemoteHostClosedError = value; } }
    protected Status __D_RemoteHostClosedError;
    public virtual Status HostNotFoundError { get { return __D_HostNotFoundError; } set { __D_HostNotFoundError = value; } }
    protected Status __D_HostNotFoundError;
    public virtual Status SocketAccessError { get { return __D_SocketAccessError; } set { __D_SocketAccessError = value; } }
    protected Status __D_SocketAccessError;
    public virtual Status SocketResourceError { get { return __D_SocketResourceError; } set { __D_SocketResourceError = value; } }
    protected Status __D_SocketResourceError;
    public virtual Status SocketTimeoutError { get { return __D_SocketTimeoutError; } set { __D_SocketTimeoutError = value; } }
    protected Status __D_SocketTimeoutError;
    public virtual Status DatagramTooLargeError { get { return __D_DatagramTooLargeError; } set { __D_DatagramTooLargeError = value; } }
    protected Status __D_DatagramTooLargeError;
    public virtual Status NetworkError { get { return __D_NetworkError; } set { __D_NetworkError = value; } }
    protected Status __D_NetworkError;
    public virtual Status AddressInUseError { get { return __D_AddressInUseError; } set { __D_AddressInUseError = value; } }
    protected Status __D_AddressInUseError;
    public virtual Status SocketAddressNotAvailableError { get { return __D_SocketAddressNotAvailableError; } set { __D_SocketAddressNotAvailableError = value; } }
    protected Status __D_SocketAddressNotAvailableError;
    public virtual Status UnsupportedSocketOperationError { get { return __D_UnsupportedSocketOperationError; } set { __D_UnsupportedSocketOperationError = value; } }
    protected Status __D_UnsupportedSocketOperationError;
    public virtual Status UnfinishedSocketOperationError { get { return __D_UnfinishedSocketOperationError; } set { __D_UnfinishedSocketOperationError = value; } }
    protected Status __D_UnfinishedSocketOperationError;
    public virtual Status ProxyAuthenticationRequiredError { get { return __D_ProxyAuthenticationRequiredError; } set { __D_ProxyAuthenticationRequiredError = value; } }
    protected Status __D_ProxyAuthenticationRequiredError;
    public virtual Status SslHandshakeFailedError { get { return __D_SslHandshakeFailedError; } set { __D_SslHandshakeFailedError = value; } }
    protected Status __D_SslHandshakeFailedError;
    public virtual Status ProxyConnectionRefusedError { get { return __D_ProxyConnectionRefusedError; } set { __D_ProxyConnectionRefusedError = value; } }
    protected Status __D_ProxyConnectionRefusedError;
    public virtual Status ProxyConnectionClosedError { get { return __D_ProxyConnectionClosedError; } set { __D_ProxyConnectionClosedError = value; } }
    protected Status __D_ProxyConnectionClosedError;
    public virtual Status ProxyConnectionTimeoutError { get { return __D_ProxyConnectionTimeoutError; } set { __D_ProxyConnectionTimeoutError = value; } }
    protected Status __D_ProxyConnectionTimeoutError;
    public virtual Status ProxyNotFoundError { get { return __D_ProxyNotFoundError; } set { __D_ProxyNotFoundError = value; } }
    protected Status __D_ProxyNotFoundError;
    public virtual Status ProxyProtocolError { get { return __D_ProxyProtocolError; } set { __D_ProxyProtocolError = value; } }
    protected Status __D_ProxyProtocolError;
    public virtual Status OperationError { get { return __D_OperationError; } set { __D_OperationError = value; } }
    protected Status __D_OperationError;
    public virtual Status SslInternalError { get { return __D_SslInternalError; } set { __D_SslInternalError = value; } }
    protected Status __D_SslInternalError;
    public virtual Status SslInvalidUserDataError { get { return __D_SslInvalidUserDataError; } set { __D_SslInvalidUserDataError = value; } }
    protected Status __D_SslInvalidUserDataError;
    public virtual Status TemporaryError { get { return __D_TemporaryError; } set { __D_TemporaryError = value; } }
    protected Status __D_TemporaryError;

    protected virtual Status AddItem()
    {
        Status item;
        item = new Status();
        item.Init();
        item.Index = this.Index;
        this.Array.Set(item.Index, item);
        this.Index = this.Index + 1;
        return item;
    }

    protected virtual bool InitArray()
    {
        this.Array = new Array();
        this.Array.Count = this.ArrayCount;
        this.Array.Init();
        return true;
    }

    protected virtual Array Array { get { return __D_Array; } set { __D_Array = value; } }
    protected Array __D_Array;

    protected virtual int ArrayCount { get { return 25; } set { } }
    protected int __D_ArrayCount;

    public virtual int Count { get { return __D_Count; } set { __D_Count = value; } }
    protected int __D_Count;
    
    protected virtual int Index { get { return __D_Index; } set { __D_Index = value; } }
    protected int __D_Index;

    public virtual Status Get(int index)
    {
        return (Status)this.Array.Get(index);
    }
}