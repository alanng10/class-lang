namespace Avalon.Draw;





public class ImageFormatList : Any
{
    public static ImageFormatList This { get; } = ShareCreate();




    private static ImageFormatList ShareCreate()
    {
        ImageFormatList share;


        share = new ImageFormatList();



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




        ulong share;

        share = Extern.Infra_Share();



        ulong stat;

        stat = Extern.Share_Stat(share);




        this.Bmp = this.AddItem(Extern.Stat_ImageFormatBmp(stat));
        this.Jpg = this.AddItem(Extern.Stat_ImageFormatJpg(stat));
        this.Png = this.AddItem(Extern.Stat_ImageFormatPng(stat));






        return true;
    }




    public virtual ImageFormat Bmp { get; set; }
    public virtual ImageFormat Jpg { get; set; }
    public virtual ImageFormat Png { get; set; }




    protected virtual ImageFormat AddItem(ulong o)
    {
        ImageFormat item;

        item = new ImageFormat();

        item.Init();

        item.Index = this.Index;

        item.Intern = o;



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
            return 3;
        } 
        set
        {
        }
    }




    public virtual int Count { get; set; }




    public virtual ImageFormat Get(int index)
    {
        return (ImageFormat)this.Array.Get(index);
    }



    
    protected virtual int Index { get; set; }

}