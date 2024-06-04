namespace Z.Tool.Infra.StatNetworkStatus;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "NetworkStatus";



        this.ScopeName = "QAbstractSocket";



        this.ValueOffset = " + 1";




        this.ItemListFileName = "ToolData/ItemListNetworkStatus.txt";




        int o;
        
        o = base.Execute();


        return o;
    }






    protected override string GetItemShareVar(string shareVar, Iter iter, int index)
    {
        if (index == 0)
        {
            string k;

            k = base.GetItemShareVar(shareVar, iter, index);



            string ua;

            ua = "::";


            string ub;

            ub = " ";



            int oa;

            oa = k.IndexOf(ua);

            
            if (oa < 0)
            {
                return "";
            }



            int oc;

            oc = oa + ua.Length;



            int ob;

            ob = k.IndexOf(ub, oc);



            if (ob < 0)
            {
                return "";
            }



            string ooa;

            ooa = k.Substring(0, oc);


            string oob;

            oob = k.Substring(ob);



            string ooc;

            ooc = "UnknownSocketError";




            string oo;

            oo = ooa + ooc + oob;



            return oo;
        }




        return base.GetItemShareVar(shareVar, iter, index);
    }
}