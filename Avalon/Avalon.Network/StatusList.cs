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

    public virtual Status NoError { get; set; }
    public virtual Status UnknownSocketError { get; set; }
    public virtual Status ConnectionRefusedError { get; set; }
    public virtual Status RemoteHostClosedError { get; set; }
    public virtual Status HostNotFoundError { get; set; }
    public virtual Status SocketAccessError { get; set; }
    public virtual Status SocketResourceError { get; set; }
    public virtual Status SocketTimeoutError { get; set; }
    public virtual Status DatagramTooLargeError { get; set; }
    public virtual Status NetworkError { get; set; }
    public virtual Status AddressInUseError { get; set; }
    public virtual Status SocketAddressNotAvailableError { get; set; }
    public virtual Status UnsupportedSocketOperationError { get; set; }
    public virtual Status UnfinishedSocketOperationError { get; set; }
    public virtual Status ProxyAuthenticationRequiredError { get; set; }
    public virtual Status SslHandshakeFailedError { get; set; }
    public virtual Status ProxyConnectionRefusedError { get; set; }
    public virtual Status ProxyConnectionClosedError { get; set; }
    public virtual Status ProxyConnectionTimeoutError { get; set; }
    public virtual Status ProxyNotFoundError { get; set; }
    public virtual Status ProxyProtocolError { get; set; }
    public virtual Status OperationError { get; set; }
    public virtual Status SslInternalError { get; set; }
    public virtual Status SslInvalidUserDataError { get; set; }
    public virtual Status TemporaryError { get; set; }

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

    protected virtual Array Array { get; set; }

    protected virtual int ArrayCount
    { 
        get
        {
            return 25;
        } 
        set
        {
        }
    }

    public virtual int Count { get; set; }

    public virtual Status Get(int index)
    {
        return (Status)this.Array.Get(index);
    }
    
    protected virtual int Index { get; set; }
}