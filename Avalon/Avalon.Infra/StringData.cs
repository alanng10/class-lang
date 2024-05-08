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

        return this.Value[index];
    }

    public virtual bool ContainChar(int index)
    {
        return this.InfraInfra.CheckIndex(this.Value.Length, index);
    }
}