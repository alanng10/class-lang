class ConsoleOut : Out
{
    field pronate ConsoleIntern Intern { get { return data; } set { data : value; } }
    field pronate Int Stream { get { return data; } set { data : value; } }

    maide prusate Bool Write(var String k)
    {
        this.Intern.Write(this.Stream, k);
        return true;
    }
}