using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.TopPath;

public class RushedHaircuts : ModUpgrade<HairStylistMonkey>
{
    public override int Path => TOP;

    public override int Tier => 2;

    public override int Cost => 820;

    public override string DisplayName => "Rushed Haircuts";

    public override string Description => "He's going for a record time. He doesn't have time to do good quality haircuts.";

    public override string Icon => "200";

    public override string Portrait => "200";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.rate -= 0.27f;
    }

}