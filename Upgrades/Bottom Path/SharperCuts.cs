using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.BottomPath;

public class SharperCuts : ModUpgrade<HairStylistMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 1;

    public override int Cost => 340;

    public override string DisplayName => "Sharper Cuts";

    public override string Description => "I don't know why he needs sharper scissors to cut hair, but why not???";

    public override string Icon => "001";

    public override string Portrait => "001";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        projectileModel.GetDamageModel().damage += 2;
    }
}