class IntLess : Less
{
    maide prusate Int Execute(var Any lite, var Any rite)
    {
        var Int liteInt;
        var Int riteInt;
        liteInt : cast Int(lite);
        riteInt : cast Int(rite);

        var Int k;
        k : 0;

        inf (liteInt < riteInt)
        {
            k : 0sn1;
        }

        inf (riteInt < liteInt)
        {
            k : 0sp1;
        }

        return k;
    }
}