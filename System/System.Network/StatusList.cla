class StatusList : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InitArray();
        this.Count : this.Array.Count;
        this.Index : 0;

        this.NoError : this.AddItem();
        this.ConnectionRefusedError : this.AddItem();
        this.RemoteHostClosedError : this.AddItem();
        this.HostNotFoundError : this.AddItem();
        this.SocketAccessError : this.AddItem();
        this.SocketResourceError : this.AddItem();
        this.SocketTimeoutError : this.AddItem();
        this.DatagramTooLargeError : this.AddItem();
        this.NetworkError : this.AddItem();
        this.AddressInUseError : this.AddItem();
        this.SocketAddressNotAvailableError : this.AddItem();
        this.UnsupportedSocketOperationError : this.AddItem();
        this.UnfinishedSocketOperationError : this.AddItem();
        this.ProxyAuthenticationRequiredError : this.AddItem();
        this.SslHandshakeFailedError : this.AddItem();
        this.ProxyConnectionRefusedError : this.AddItem();
        this.ProxyConnectionClosedError : this.AddItem();
        this.ProxyConnectionTimeoutError : this.AddItem();
        this.ProxyNotFoundError : this.AddItem();
        this.ProxyProtocolError : this.AddItem();
        this.OperationError : this.AddItem();
        this.SslInternalError : this.AddItem();
        this.SslInvalidUserDataError : this.AddItem();
        this.TemporaryError : this.AddItem();
        return true;
    }

    field prusate Status NoError { get { return data; } set { data : value; } }
    field prusate Status ConnectionRefusedError { get { return data; } set { data : value; } }
    field prusate Status RemoteHostClosedError { get { return data; } set { data : value; } }
    field prusate Status HostNotFoundError { get { return data; } set { data : value; } }
    field prusate Status SocketAccessError { get { return data; } set { data : value; } }
    field prusate Status SocketResourceError { get { return data; } set { data : value; } }
    field prusate Status SocketTimeoutError { get { return data; } set { data : value; } }
    field prusate Status DatagramTooLargeError { get { return data; } set { data : value; } }
    field prusate Status NetworkError { get { return data; } set { data : value; } }
    field prusate Status AddressInUseError { get { return data; } set { data : value; } }
    field prusate Status SocketAddressNotAvailableError { get { return data; } set { data : value; } }
    field prusate Status UnsupportedSocketOperationError { get { return data; } set { data : value; } }
    field prusate Status UnfinishedSocketOperationError { get { return data; } set { data : value; } }
    field prusate Status ProxyAuthenticationRequiredError { get { return data; } set { data : value; } }
    field prusate Status SslHandshakeFailedError { get { return data; } set { data : value; } }
    field prusate Status ProxyConnectionRefusedError { get { return data; } set { data : value; } }
    field prusate Status ProxyConnectionClosedError { get { return data; } set { data : value; } }
    field prusate Status ProxyConnectionTimeoutError { get { return data; } set { data : value; } }
    field prusate Status ProxyNotFoundError { get { return data; } set { data : value; } }
    field prusate Status ProxyProtocolError { get { return data; } set { data : value; } }
    field prusate Status OperationError { get { return data; } set { data : value; } }
    field prusate Status SslInternalError { get { return data; } set { data : value; } }
    field prusate Status SslInvalidUserDataError { get { return data; } set { data : value; } }
    field prusate Status TemporaryError { get { return data; } set { data : value; } }

    maide precate Status AddItem()
    {
        var Status item;
        item : new Status;
        item.Init();
        item.Index : this.Index;
        this.Array.Set(item.Index, item);
        this.Index : this.Index + 1;
        return item;
    }

    maide precate Bool InitArray()
    {
        this.Array : new Array;
        this.Array.Count : this.ArrayCount;
        this.Array.Init();
        return true;
    }

    field precate Array Array { get { return data; } set { data : value; } }

    field precate Int ArrayCount { get { return 24; } set { } }

    field prusate Int Count { get { return data; } set { data : value; } }
    
    field precate Int Index { get { return data; } set { data : value; } }

    maide prusate Status Get(var Int index)
    {
        return cast Status(this.Array.Get(index));
    }
}