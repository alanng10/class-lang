namespace Z.Tool.SourceSpace;

public class SourceSpace : Base
{
    public override bool Init()
    {
        base.Init();
        this.StorageComp = StorageComp.This;
        return true;
    }

    protected virtual StorageComp StorageComp { get; set; }

    public virtual long Execute()
    {
        return 0;
    }
}