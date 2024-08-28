namespace Demo;

class ThreadPostState : State
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

        this.Phore.Close();

        long o;
        o = thread.ExecuteEventLoop();

        post.Final();

        Value aa;
        aa = new Value();
        aa.Init();
        aa.Int = o;

        this.Result = aa;
        return true;
    }
}