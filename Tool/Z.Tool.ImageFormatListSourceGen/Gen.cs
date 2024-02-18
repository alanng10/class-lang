namespace Z.Tool.ImageFormatListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Avalon.Draw";


        this.ClassName = "ImageFormatList";


        this.BaseClassName = "Any";


        this.ItemClassName = "ImageFormat";


        this.ArrayClassName = "Array";




        this.Export = true;




        this.StatItemClassName = "ImageFormat";
        



        this.ItemListFileName = this.GetStatItemListFileName();




        return true;
    }
}