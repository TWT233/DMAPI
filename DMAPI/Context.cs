using Duckov.Modding;

namespace DMAPI;

public class Context
{
    public ModManager ModManager { get; internal set; }
    public ModInfo ModInfo { get; internal set; }

    public string ModName => ModInfo.name;
    public string ModDir => ModInfo.path;

    public Context(ModManager master, ModInfo info)
    {
        ModManager = master;
        ModInfo = info;
    }
}