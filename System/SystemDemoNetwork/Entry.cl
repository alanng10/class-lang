class Entry : ModuleEntry
{
    maide precate Int ExecuteMain()
    {
        var ThreadNetworkState state;
        state : new ThreadNetworkState;
        state.Init();

        state.Execute();
        return 0;
    }
}