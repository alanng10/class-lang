namespace Z.Tool.Infra.StatNetworkPortKind;





class Gen : StatGen
{
    public override int Execute()
    {
        this.ClassName = "NetworkPortKind";



        this.ScopeName = "QHostAddress";



        this.ValueOffset = " + 2";




        this.ItemListFileName = "ToolData/ItemListNetworkPortKind.txt";




        int o;
        
        o = base.Execute();


        return o;
    }






    protected override string GetItemShareVar(string shareVar, Iter iter, int index)
    {
        if (index < 2)
        {
            string k;

            k = base.GetItemShareVar(shareVar, iter, index);



            string ua;

            ua = " = ";


            string ub;

            ub = ";";



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

            ooc = (index + 1).ToString();




            string oo;

            oo = ooa + ooc + oob;



            return oo;
        }




        return base.GetItemShareVar(shareVar, iter, index);
    }
}