namespace Class.Infra;



public class ModuleStore : Any
{
    public override bool Init()
    {
        base.Init();

        
        
        this.InfraConstant = InfraConstant.This;



        this.InitRootPath();
        


        this.BinaryFileName = "-";

        

        return true;
    }
    


    public virtual ModuleRef Ref { get; set; }
    
    
    public virtual Data Data { get; set; }
    
    
    
    
    protected virtual InfraConstant InfraConstant { get; set; }



    
    protected virtual bool InitRootPath()
    {
        string userFoldPath;

        userFoldPath = null;
        
        try
        {
            userFoldPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }
        catch
        {
        }

        

        bool ba;

        ba = false;
        

        if (!ba)
        {
            if (userFoldPath == null)
            {
                ba = true;
            }
        }

        
        if (!ba)
        {
            if (userFoldPath.Length == 0)
            {
                ba = true;
            }
        }
        
        
        if (ba)
        {
            Environment.Exit(0x10001);
        }

        

        
        string rootPath;
            
        rootPath = userFoldPath + this.InfraConstant.PathCombine + "Module";


        
        bool b;

        b = false;

        
        try
        {
            b = Directory.Exists(rootPath);
        }
        catch
        {
        }
        
        
        
        if (!b)
        {
            Environment.Exit(0x10002);
        }


        
        this.RootPath = rootPath;



        return true;
    }
    
    
    
    
    public virtual bool ExecuteGet()
    {
        string foldPath;

        foldPath = this.GetModuleRefFoldPath(this.Ref);


        
        bool b;
        

        try
        {
            b = Directory.Exists(foldPath);
        }
        catch
        {
            return false;
        }

        

        if (!b)
        {
            return false;
        }
        

        
        string filePath;

        filePath = foldPath + this.InfraConstant.PathCombine + this.BinaryFileName;



        bool ba;


        try
        {
            ba = File.Exists(filePath);
        }
        catch
        {
            return false;
        }


        if (!ba)
        {
            return false;
        }



        byte[] u;

        try
        {
            u = File.ReadAllBytes(filePath);
        }
        catch
        {
            return false;
        }

        
        
        Data data;

        data = new Data();

        data.Init();

        data.Value = u;



        this.Data = data;
        
        


        return true;
    }

    
    

    public virtual bool ExecuteSet()
    {
        string foldPath;

        foldPath = this.GetModuleRefFoldPath(this.Ref);


        try
        {
            Directory.CreateDirectory(foldPath);
        }
        catch
        {
            return false;
        }

        
        
        bool b;
        

        try
        {
            b = Directory.Exists(foldPath);
        }
        catch
        {
            return false;
        }
        
        
        if (!b)
        {
            return false;
        }
        
        
        
        
        string filePath;

        filePath = foldPath + this.InfraConstant.PathCombine + this.BinaryFileName;


        try
        {
            File.WriteAllBytes(filePath, this.Data.Value);
        }
        catch
        {
            return false;
        }
        
        
        
        
        return true;
    }


    

    public virtual bool ExecuteExist()
    {
        string foldPath;

        foldPath = this.GetModuleRefFoldPath(this.Ref);


        
        bool b;
        

        try
        {
            b = Directory.Exists(foldPath);
        }
        catch
        {
            return false;
        }

        

        if (!b)
        {
            return false;
        }
        

        
        string filePath;

        filePath = foldPath + this.InfraConstant.PathCombine + this.BinaryFileName;



        bool ba;


        try
        {
            ba = File.Exists(filePath);
        }
        catch
        {
            return false;
        }


        if (!ba)
        {
            return false;
        }
        


        return true;
    }
    
    
    


    protected virtual string GetModuleRefFoldPath(ModuleRef varRef)
    {
        string k;

        k = this.RootPath;
        
        
        k = k + this.InfraConstant.PathCombine + this.IntHexString(varRef.Int.Group);
        
        k = k + this.InfraConstant.PathCombine + this.IntHexString(varRef.Int.Value);
        
        k = k + this.InfraConstant.PathCombine + this.IntHexString(varRef.Ver);


        return k;
    }



    protected virtual string IntHexString(long a)
    {
        if (a < 0)
        {
            return null;
        }


        ulong k;

        k = (ulong)a;


        string o;

        o = k.ToString("x15");
        
        

        return o;
    }
    
    
    
    protected virtual string RootPath { get; set; }
    
    
    protected virtual string BinaryFileName { get; set; }
}