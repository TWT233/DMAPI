namespace DMAPI;

public class Helper
{
    public Context Ctx { get; internal set; }
    public ILocalization I18N { get; internal set; }
    public ILog Log { get; internal set; }

    private Helper(Context ctx, ILocalization i18N, ILog log)
    {
        Ctx = ctx;
        I18N = i18N;
        Log = log;
    }

    public static Helper CreateInstance(Context ctx)
    {
        var log = ConsoleLog.CreateInstance(ctx);
        var i18N = YamlLocalization.CreateInstance(ctx);
        return new Helper(ctx, i18N, log);
    }
}