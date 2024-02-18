namespace Avalon.Video;






public class Frame : Any
{
    public override bool Init()
    {
        base.Init();



        this.Intern = Extern.VideoFrame_New();


        Extern.VideoFrame_Init(this.Intern);



        return true;
    }



    public virtual bool Final()
    {
        Extern.VideoFrame_Final(this.Intern);


        Extern.VideoFrame_Delete(this.Intern);



        return true;
    }




    internal virtual ulong Intern { get; set; }





    public virtual bool GetVideo(Video video)
    {
        Extern.VideoFrame_GetImage(this.Intern, video.Intern);




        ulong size;


        size = Extern.Image_GetSize(video.Intern);



        ulong w;

        ulong h;



        w = Extern.Size_GetWidth(size);


        h = Extern.Size_GetHeight(size);



        int width;

        int height;


        width = (int)w;

        height = (int)h;



        video.Size.Width = width;


        video.Size.Height = height;



        return true;
    }
}