class TimeEventA : TimeEvent
{
    field prusate Thread Thread { get { return data; } set { data : value; } }    
    field prusate Phore Phore { get { return data; } set { data : value; } }

    maide prusate Bool Elapse()
    {
        this.Stop();

        this.Phore.Close();

        share Console.Out.Write("Time Event Elapse Phore Close\n");

        this.Thread.Exit(0);

        return true;
    }
}