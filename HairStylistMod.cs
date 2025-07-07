using MelonLoader;
using BTD_Mod_Helper;
using HairStylistMonkey;

[assembly: MelonInfo(typeof(HairStylistMonkey.HairStylistMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace HairStylistMonkey;

public class HairStylistMod : BloonsTD6Mod

{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<HairStylistMod>("HairStylistMonkey loaded!");
    }
}