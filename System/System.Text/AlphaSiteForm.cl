class AlphaSiteForm : Form
{
    maide prusate Bool Init()
    {
        base.Init();
        this.FormInfra : share FormInfra;
        return true;
    }

    field pronate FormInfra FormInfra { get { return data; } set { data : value; } }

    maide prusate Int Execute(var Int n)
    {
        inf (this.FormInfra.Alpha(n, true))
        {
            var Int ka;
            var Int kb;
            ka : this.FormInfra.Char("A");
            kb : this.FormInfra.Char("a");

            n : n - ka + kb;
        }

        return n;
    }
}