namespace Avalon.Comp;





public class Comp : Any
{
    public override bool Init()
    {
        base.Init();





        this.TriggerArg = this.CreateTriggerArg();




        this.ChangeEvent = new EventEvent();


        this.ChangeEvent.Init();





        return true;
    }






    protected virtual Change CreateTriggerArg()
    {
        Change a;


        a = new Change();


        a.Init();



        return a;
    }






    public virtual bool Change(Field field, Change change)
    {
        return true;
    }







    protected virtual bool Trigger(Field field)
    {
        this.TriggerArg.Comp = this;


        this.TriggerArg.Field = field;




        this.ChangeEvent.Trigger(this.TriggerArg);
        



        return true;
    }






    public virtual Change TriggerArg { get; set; }




    public virtual EventEvent ChangeEvent { get; set; }
}