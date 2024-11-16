class TimeEventA : TimeEvent
{
    field prusate Phore Phore { get { return data; } set { data : value; } }

    maide prusate Bool Elapse()
    {
        this.Stop();

        this.Phore.Close();

        share Console.Out.Write("TIme Event Elapse Phore Close\n");

        return true;
    }
}