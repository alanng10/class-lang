namespace Avalon.View;

public class Grid : View
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.RowField = this.CreateRowField();
        this.ColField = this.CreateColField();
        this.ChildListField = this.CreateGridChildField();
        this.DestField = this.CreateDestField();
        this.Row = this.CreateRow();
        this.Col = this.CreateCol();
        this.ChildList = this.CreateChildList();
        this.Dest = this.CreateDest();

        this.Back = this.DrawInfra.TransparentBrush;

        this.ChildPosData = this.CreateChildPosList();
        this.RowIter = this.Row.IterCreate();
        this.ColIter = this.Col.IterCreate();
        this.ChildListIter = this.ChildList.IterCreate();

        this.StackGridChildListRect = this.CreateStackGridChildListRect();
        this.StackGridChildListPos = this.CreateStackGridChildListPos();
        this.StackGridChildRect = this.CreateStackGridChildRect();
        this.StackGridChildPos = this.CreateStackGridChildPos();
        return true;
    }
    
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Iter RowIter { get; set; }
    protected virtual Iter ColIter { get; set; }
    protected virtual Iter ChildListIter { get; set; }
    protected virtual Data ChildPosData { get; set; }

    protected virtual DrawRect StackGridChildListRect { get; set; }
    protected virtual DrawPos StackGridChildListPos { get; set; }
    protected virtual DrawRect StackGridChildRect { get; set; }
    protected virtual DrawPos StackGridChildPos { get; set; }

    protected virtual Field CreateRowField()
    {
        return this.ViewInfra.FieldCreate(this);
    }
    
    protected virtual Field CreateColField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateGridChildField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual Field CreateDestField()
    {
        return this.ViewInfra.FieldCreate(this);
    }

    protected virtual List CreateRow()
    {
        List a;
        a = new List();
        a.Init();
        return a;
    }

    protected virtual List CreateCol()
    {
        List a;
        a = new List();
        a.Init();
        return a;
    }

    protected virtual List CreateChildList()
    {
        List a;
        a = new List();
        a.Init();
        return a;
    }

    protected virtual Rect CreateDest()
    {
        Rect a;
        a = new Rect();
        a.Init();
        return a;
    }

    protected virtual Data CreateChildPosList()
    {
        Data a;
        a = new Data();
        a.Count = 0;
        a.Init();
        return a;
    }

    protected virtual DrawRect CreateStackGridChildRect()
    {
        DrawRect rect;
        rect = new DrawRect();
        rect.Init();
        rect.Pos = new DrawPos();
        rect.Pos.Init();
        rect.Size = new DrawSize();
        rect.Size.Init();
        return rect;
    }

    protected virtual DrawPos CreateStackGridChildPos()
    {
        DrawPos pos;
        pos = new DrawPos();
        pos.Init();
        return pos;
    }

    protected virtual DrawRect CreateStackGridChildListRect()
    {
        DrawRect rect;
        rect = new DrawRect();
        rect.Init();
        rect.Pos = new DrawPos();
        rect.Pos.Init();
        rect.Size = new DrawSize();
        rect.Size.Init();
        return rect;
    }

    protected virtual DrawPos CreateStackGridChildListPos()
    {
        DrawPos pos;
        pos = new DrawPos();
        pos.Init();
        return pos;
    }

    public virtual Field RowField { get; set; }

    public virtual List Row
    {
        get
        {
            return (List)this.RowField.Get();
        }

        set
        {
            this.RowField.Set(value);
        }
    }

    protected virtual bool ChangeRow(Change change)
    {
        if ((this.Row == null) | (this.Col == null) | (this.ChildList == null))
        {
            return true;
        }
        this.UpdateLayout();
        this.Event(this.RowField);
        return true;
    }

    public virtual Field ColField { get; set; }

    public virtual List Col
    {
        get
        {
            return (List)this.ColField.Get();
        }

        set
        {
            this.ColField.Set(value);
        }
    }

    protected virtual bool ChangeCol(Change change)
    {
        if ((this.Row == null) | (this.Col == null) | (this.ChildList == null))
        {
            return true;
        }
        this.UpdateLayout();
        this.Event(this.ColField);
        return true;
    }

    public virtual Field ChildListField { get; set; }

    public virtual List ChildList
    {
        get
        {
            return (List)this.ChildListField.Get();
        }

        set
        {
            this.ChildListField.Set(value);
        }
    }

    protected virtual bool ChangeChildList(Change change)
    {
        if ((this.Row == null) | (this.Col == null) | (this.ChildList == null))
        {
            return true;
        }
        this.Event(this.ChildListField);
        return true;
    }

    public virtual Field DestField { get; set; }

    public virtual Rect Dest
    {
        get
        {
            return (Rect)this.DestField.Get();
        }
        set
        {
            this.DestField.Set(value);
        }
    }

    protected virtual bool ChangeDest(Change change)
    {
        this.Event(this.DestField);
        return true;
    }

    protected virtual bool UpdateLayout()
    {
        int count;
        count = this.Col.Count + this.Row.Count;

        int oa;
        oa = count * sizeof(uint);
        long oo;
        oo = this.ChildPosData.Count;
        int ob;
        ob = (int)oo;
        if (ob < oa)
        {
            Data data;
            data = new Data();
            data.Count = oa;
            data.Init();
            this.ChildPosData = data;
        }
        
        this.SetChildLeftArray();
        this.SetChildUpArray();
        return true;
    }

    protected override bool ValidDrawChild()
    {
        return true;
    }

    protected override bool ExecuteChildDraw(DrawDraw draw)
    {
        this.ExecuteDrawGridChildList(draw);
        return true;
    }

    protected virtual bool ExecuteDrawGridChildList(DrawDraw draw)
    {
        int left;
        left = this.Dest.Pos.Col;
        left = left + draw.Pos.Col;
        int up;
        up = this.Dest.Pos.Row;
        up = up + draw.Pos.Row;
        int width;
        width = this.Dest.Size.Width;
        int height;
        height = this.Dest.Size.Height;

        this.DrawRectA.Pos.Col = left;
        this.DrawRectA.Pos.Row = up;
        this.DrawRectA.Size.Width = width;
        this.DrawRectA.Size.Height = height;

        this.SetChildArea(this.DrawRectA);

        this.ViewInfra.StackPushChild(draw, this.StackGridChildListRect, this.StackGridChildListPos, this.DrawRectA, this.DrawPosA);

        this.ExecuteGridChildListDraw(draw);

        this.ViewInfra.StackPopChild(draw, this.StackGridChildListRect, this.StackGridChildListPos);
        return true;
    }

    protected virtual bool ExecuteGridChildListDraw(DrawDraw draw)
    {
        Iter iter;
        iter = this.ChildListIter;
        this.ChildList.IterSet(iter);
        while (iter.Next())
        {
            GridChild child;
            child = (GridChild)iter.Value;

            if (this.ValidDrawGridChild(child))
            {
                this.ExecuteDrawGridChild(draw, child);
            }
        }
        return true;
    }

    protected virtual bool ValidDrawGridChild(GridChild child)
    {
        return !(child.View == null);
    }

    protected virtual bool ExecuteDrawGridChild(DrawDraw draw, GridChild child)
    {
        Rect gridRect;
        gridRect = child.Rect;

        if (!this.ValidGridRect(gridRect))
        {
            return false;
        }

        Pos gridPos;
        gridPos = gridRect.Pos;
        Size gridSize;
        gridSize = gridRect.Size;

        int startCol;
        startCol = gridPos.Col;
        int endCol;
        endCol = startCol + gridSize.Width;
        int startRow;
        startRow = gridPos.Row;
        int endRow;
        endRow = startRow + gridSize.Height;

        int leftA;
        leftA = this.GridColLeft(startCol);
        int upA;
        upA = this.GridRowUp(startRow);
        int left;
        left = leftA + draw.Pos.Col;
        int up;
        up = upA + draw.Pos.Row;
        
        int right;
        right = this.GridColLeft(endCol);
        int down;
        down = this.GridRowUp(endRow);

        int width;
        width = right - leftA;
        int height;
        height = down - upA;

        DrawRect rect;
        rect = this.DrawRectA;
        rect.Pos.Col = left;
        rect.Pos.Row = up;
        rect.Size.Width = width;
        rect.Size.Height = height;

        this.SetChildArea(rect);

        this.ViewInfra.StackPushChild(draw, this.StackGridChildRect, this.StackGridChildPos, rect, this.DrawPosA);

        this.ExecuteGridChildDraw(draw, child);

        this.ViewInfra.StackPopChild(draw, this.StackGridChildRect, this.StackGridChildPos);
        return true;
    }

    protected virtual bool ExecuteGridChildDraw(DrawDraw draw, GridChild child)
    {
        child.View.ExecuteDraw(draw);
        return true;
    }

    protected virtual bool ValidGridRect(Rect rect)
    {
        Pos pos;
        pos = rect.Pos;
        Size size;
        size = rect.Size;

        bool ba;
        ba = this.InfraInfra.ValidRange(this.Col.Count, pos.Col, size.Width);

        bool bb;
        bb = this.InfraInfra.ValidRange(this.Row.Count, pos.Row, size.Height);

        bool a;
        a = ba & bb;
        return a;
    }

    protected virtual int GridColLeft(int col)
    {
        return this.GridPosPixelPos(col, 0);
    }

    protected virtual int GridRowUp(int row)
    {
        return this.GridPosPixelPos(row, this.Col.Count);
    }

    protected virtual int GridPosPixelPos(int pos, int start)
    {
        int t;
        t = pos;
        bool b;
        int u;
        u = 0;

        b = (t < 1);
        if (!b)
        {
            t = t - 1;
            int index;
            index = start + t;
            int byteIndex;
            byteIndex = this.IntByteIndex(index);

            uint uu;
            uu = this.InfraInfra.DataMidGet(this.ChildPosData, byteIndex);
            u = (int)uu;
        }
        int ret;
        ret = u;
        return ret;
    }

    protected virtual bool SetChildLeftArray()
    {
        int start;
        start = 0;
        Iter iter;
        iter = this.ColIter;
        this.Col.IterSet(iter);
        int left;
        left = 0;

        int i;
        i = 0;
        while (iter.Next())
        {
            Count gridCol;
            gridCol = (Count)iter.Value;
            left = left + gridCol.Value;

            int index;
            index = start + i;
            int byteIndex;
            byteIndex = this.IntByteIndex(index);
            uint u;
            u = (uint)left;
            this.InfraInfra.DataMidSet(this.ChildPosData, byteIndex, u);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool SetChildUpArray()
    {
        int start;
        start = this.Col.Count;
        Iter iter;
        iter = this.RowIter;
        this.Row.IterSet(iter);
        int up;
        up = 0;

        int i;
        i = 0;
        while (iter.Next())
        {
            Count gridRow;
            gridRow = (Count)iter.Value;
            up = up + gridRow.Value;

            int index;
            index = start + i;
            int byteIndex;
            byteIndex = this.IntByteIndex(index);
            uint u;
            u = (uint)up;
            this.InfraInfra.DataMidSet(this.ChildPosData, byteIndex, u);
            i = i + 1;
        }
        return true;
    }

    public override bool Change(Field varField, Change change)
    {
        base.Change(varField, change);
        if (this.RowField == varField)
        {
            this.ChangeRow(change);
        }
        if (this.ColField == varField)
        {
            this.ChangeCol(change);
        }
        if (this.ChildListField == varField)
        {
            this.ChangeChildList(change);
        }
        if (this.DestField == varField)
        {
            this.ChangeDest(change);
        }
        return true;
    }

    protected virtual int IntByteIndex(int index)
    {
        return index * sizeof(uint);
    }
}