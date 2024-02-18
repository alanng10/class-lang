namespace Avalon.Event;




public class Event : Any
{
    public override bool Init()
    {
        base.Init();



        StateTable state;

        state = new StateTable();

        state.Init();



        this.State = state;



        this.StateIter = this.State.CreateIter();



        return true;
    }
    




    public virtual StateTable State { get; set; }





    protected virtual Iter StateIter { get; set; }






    public virtual bool Trigger(object arg)
    {
        Iter iter;


        iter = this.StateIter;



        this.State.SetIter(iter);




        while (iter.Next())
        {
            State state;


            state = (State)iter.Value;


            state.Arg = arg;


            state.Execute();
        }



        return true;
    }
}