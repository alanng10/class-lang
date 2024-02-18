namespace Z.Tool.PenKindListSourceGen;






public class Gen : SourceGen
{
    public override bool Init()
    {
        base.Init();





        this.Namespace = "Avalon.Draw";


        this.ClassName = "PenKindList";


        this.BaseClassName = "Any";


        this.ItemClassName = "PenKind";


        this.ArrayClassName = "Array";




        this.Export = true;




        this.StatItemClassName = "PenKind";
        



        this.ItemListFileName = this.GetStatItemListFileName();




        return true;
    }
}