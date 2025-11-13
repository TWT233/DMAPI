namespace DMAPI;

public class Mod : Duckov.Modding.ModBehaviour
{
    public Helper Helper { get; internal set; } = null!;

    protected override void OnAfterSetup()
    {
        base.OnAfterSetup();
        Helper = Helper.CreateInstance(new Context(master, info));
    }
}