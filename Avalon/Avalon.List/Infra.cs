namespace Avalon.List;





public class Infra : Any
{
    public static Infra This { get; } = ShareCreate();




    private static Infra ShareCreate()
    {
        Infra share;

        share = new Infra();



        Any a;

        a = share;

        a.Init();
        


        return share;
    }






    public virtual Array CreateArray(List list)
    {
        Array a;

        a = new Array();

        a.Count = list.Count;

        a.Init();
        



        Iter iter;

        iter = list.CreateIter();



        list.SetIter(iter);




        int count;

        count = a.Count;


        int i;

        i = 0;


        while (i < count)
        {
            iter.Next();


            object aa;

            aa = iter.Value;



            a.Set(i, aa);



            i = i + 1;
        }




        return a;
    }
}