namespace Demo;






class ThreadPostState : ThreadExecuteState
{
    public State PostState { get; set; }



    public ThreadSemaphore Semaphore { get; set; }



    public ThreadPost Post { get; set; }




    public override bool Execute()
    {
        ThreadCurrent current;

        current = new ThreadCurrent();

        current.Init();




        ThreadThread thread;

        thread = current.Thread;




        ThreadPost post;

        post = new ThreadPost();

        post.Init();


        post.State = this.PostState;




        this.Post = post;



        this.Semaphore.Release();




        int o;

        o = thread.ExecuteEventLoop();




        post.Final();




        this.Result = o;



        return true;
    }
}