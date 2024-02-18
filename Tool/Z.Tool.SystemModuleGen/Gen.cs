namespace Z.Tool.SystemModuleGen;





public class Gen : Any
{
    public virtual int Execute()
    {
        Create create;

        create = new Create();

        create.Init();

        
        create.Execute();
        
        

        Module module;

        module = create.Module;


        create.Module = null;



        BinaryWrite write;

        write = new BinaryWrite();

        write.Init();


        write.Module = module;


        write.Execute();


        
        Data data;

        data = write.Data;


        write.Data = null;



        ModuleStore store;

        store = new ModuleStore();

        store.Init();


        Stat stat;

        stat = Stat.This;


        store.Ref = stat.SystemModuleRef;

        store.Data = data;



        bool o;

        o = store.ExecuteSet();


        if (!o)
        {
            return 0x1000000;
        }
        
        
        
        return 0;
    }
}