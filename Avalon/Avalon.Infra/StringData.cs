namespace Avalon.Infra;

public class StringData : Data
{
    public new virtual string Value { get; set; }

    public virtual int GetChar(int index)
    {
        if (!this.ContainChar(index))
        {
            return -1;
        }

        char oc;
        oc = this.Value[index];
        
        int a;
        a = oc;
        return a;
    }

    public virtual bool ContainChar(int index)
    {
        return this.InfraInfra.CheckIndex(this.Value.Length, index);
    }
}