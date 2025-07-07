using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.MiddlePath;

public class LongRangeCuts : ModUpgrade<HairStylistMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 1;

    public override int Cost => 240;

    public override string DisplayName => "Long Range Cuts";

    public override string Description => "I don't know how you can cut hair from far away, but this guy knows how to.";
    public override string Icon => "010";

    public override string Portrait => "010";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        towerModel.range += 18;
        towerModel.GetAttackModel().range += 18;
    }
}