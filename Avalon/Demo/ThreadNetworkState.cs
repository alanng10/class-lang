namespace Demo;

public class ThreadNetworkState : State
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        return true;
    }

    public TextInfra TextInfra { get; set; }
    public NetworkA Network { get; set; }

    public override bool Execute()
    {
        String hostName;
        hostName = this.S("localhost");
        long hostPort;
        hostPort = 50920;

        NetworkNetwork network;
        network = new NetworkNetwork();
        network.Init();

        network.HostName = hostName;
        network.HostPort = hostPort;

        bool b;
        b = network.Open();

        if (!b)
        {
            Console.This.Out.Write(this.S("Network Open Error\n"));
            return true;
        }


        

        network.Final();

        string k;
        k = null;
        bool b;
        b = (o == 0);
        if (b)
        {
            k = "Success";
        }
        if (!b)
        {
            k = "Fail";
        }

        Console.This.Out.Write(this.S("Network " + k + ", code: " + o + "\n"));
        return true;
    }

    private String S(string o)
    {
        return this.TextInfra.S(o);
    }
}