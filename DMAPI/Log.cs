namespace DMAPI;

public enum LogLevel
{
    Trace = 'T',
    Debug = 'D',
    Info = 'I',
    Warn = 'W',
    Error = 'E',
    Fatal = 'F',
}

public interface ILog
{
    void Log(string msg, LogLevel level = LogLevel.Debug);

    void Trace(string msg);
    void Debug(string msg);
    void Info(string msg);
    void Warn(string msg);
    void Error(string msg);
    void Fatal(string msg);
}

public class ConsoleLog : ILog
{
    private readonly Context _ctx;

    private ConsoleLog(Context ctx)
    {
        _ctx = ctx;
    }

    public static ConsoleLog CreateInstance(Context ctx)
    {
        return new ConsoleLog(ctx);
    }

    public void Log(string msg, LogLevel level = LogLevel.Debug)
    {
        UnityEngine.Debug.Log($"[{_ctx.ModName}][{(char)level}] {msg}");
    }

    public void Trace(string msg)
    {
        Log(msg, LogLevel.Trace);
    }

    public void Debug(string msg)
    {
        Log(msg, LogLevel.Debug);
    }

    public void Info(string msg)
    {
        Log(msg, LogLevel.Info);
    }

    public void Warn(string msg)
    {
        Log(msg, LogLevel.Warn);
    }

    public void Error(string msg)
    {
        Log(msg, LogLevel.Error);
    }

    public void Fatal(string msg)
    {
        Log(msg, LogLevel.Fatal);
    }
}