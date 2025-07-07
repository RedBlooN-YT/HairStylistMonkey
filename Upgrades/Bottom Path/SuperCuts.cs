using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.BottomPath;

public class SuperCuts : ModUpgrade<HairStylistMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 2;

    public override int Cost => 1420;

    public override string DisplayName => "Super Cuts";

    public override string Description => "These scissors are SUPER sharp! I really don't know why he needs them to cut hair.";

    public override string Icon => "002";

    public override string Portrait => "002";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        projectileModel.GetDamageModel().damage += 2;
    }

}