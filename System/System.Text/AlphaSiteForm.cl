class AlphaSiteForm : Form
{
    maide prusate Bool Init()
    {
        base.Init();
        this.FormInfra : share FormInfra;
        return true;
    }

    field pronate FormInfra FormInfra { get { return data; } set { data : value; } }

    maide prusate Int Execute(var Int value)
    {
        inf (this.FormInfra.Alpha(value, true))
        {
            var Int ka;
            var Int kb;
            ka : this.FormInfra.Char("A");
            kb : this.FormInfra.Char("a");

            value : value - ka + kb;
        }

        return value;
    }
}