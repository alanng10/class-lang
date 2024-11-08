class MemoryStream : Stream
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Intern : new InternStream;
        this.Intern.Init();
        return true;
    }
    
    maide prusate Bool Final()
    {
        this.Intern.Final();
        return true;
    }
    
    field private InternStream Intern { get { return data; } set { data : value; } }
}