class BoolLess : Less
{
    maide prusate Int Execute(var Any lite, var Any rite)
    {
        var Bool liteBool;
        var Bool riteBool;
        liteBool : cast Bool(lite);
        riteBool : cast Bool(rite);

        var Int liteInt;
        var Int riteInt;
        liteInt : this.BoolInt(liteBool);
        riteInt : this.BoolInt(riteBool);

        return liteInt - riteInt;
    }

    maide precate Int BoolInt(var Bool o)
    {
        var Int a;
        a : 0;
        inf (o)
        {
            a : 1;
        }
        return a;
    }
}