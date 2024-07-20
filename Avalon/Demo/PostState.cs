namespace Demo;

public class PostState : State
{
    public override bool Execute()
    {
        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;
        thread.ExitEventLoop(0x89f6);

        Console console;
        console = Console.This;
        console.Out.Write("PostState.Execute Aaa\n");
        return true;
    }
}