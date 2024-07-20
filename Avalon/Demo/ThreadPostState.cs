namespace Demo;

class ThreadPostState : ThreadExecuteState
{
    public State PostState { get; set; }
    public ThreadPhore Phore { get; set; }
    public ThreadPost Post { get; set; }

    public override bool Execute()
    {
        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;

        ThreadPost post;
        post = new ThreadPost();
        post.Init();
        post.State = this.PostState;

        this.Post = post;

        this.Phore.Release();

        int o;
        o = thread.ExecuteEventLoop();

        post.Final();

        this.Result = o;
        return true;
    }
}