class Intern : Any
{
    maide prusate Int Memory(var Any any) { }

    maide prusate Int StateArgMemory(var Any any) { }

    maide prusate String StringNew() { }

    maide prusate Any StringValueGet(var String string) { }

    maide prusate Bool StringValueSet(var String string, var Any value) { }

    maide prusate Int StringCountGet(var String string) { }

    maide prusate Bool StringCountSet(var String string, var Int value) { }

    maide prusate Any DataNew(var Int count) { }

    maide prusate Int DataGet(var Any data, var Int index) { }

    maide prusate Bool DataSet(var Any data, var Int index, var Int value) { }

    maide prusate Any ArrayNew(var Int count) { }

    maide prusate Any ArrayGet(var Any array, var Int index) { }

    maide prusate Bool ArraySet(var Any array, var Int index, var Any value) { }

    maide prusate Int RefLess(var Any lite, var Any rite) { }

    maide prusate Any ThisThread() { }

    maide prusate Bool MainThreadSet(var Any thread) { }

    maide prusate Bool InitThread(var Int thread, var Any threadAny) { }

    maide prusate Bool FinalThread(var Int thread) { }

    maide prusate Int ArgCount() { }

    maide prusate String Arg(var Int index) { }

    maide prusate Int StateThreadExecute() { }

    maide prusate Int StateTimeEventElapse() { }

    maide prusate Int StateNetworkStatusEvent() { }

    maide prusate Int StateNetworkCaseEvent() { }

    maide prusate Int StateNetworkDataEvent() { }

    maide prusate Int StateNetworkHostNewPeer() { }

    maide prusate Int StateFrameTypeEvent() { }

    maide prusate Int StateFrameDrawEvent() { }

    maide prusate Int StateVideoOutFrameEvent() { }
}