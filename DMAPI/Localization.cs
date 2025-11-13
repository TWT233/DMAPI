using UnityEngine;

namespace DMAPI;

public interface ILocalization
{
    void Load(Context ctx, SystemLanguage language);

    string Get(string key);
}

public class YamlLocalization : ILocalization
{
    private readonly Context _ctx;

    private YamlLocalization(Context ctx)
    {
        _ctx = ctx;
    }

    public static YamlLocalization CreateInstance(Context ctx)
    {
        return new YamlLocalization(ctx);
    }

    public void Load(Context ctx, SystemLanguage language)
    {
    }

    public string Get(string key)
    {
        return string.Empty;
    }
}