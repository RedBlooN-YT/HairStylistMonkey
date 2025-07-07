using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.TopPath;

public class QuickerCutting : ModUpgrade<HairStylistMonkey>
{
    public override int Path => TOP;

    public override int Tier => 1;

    public override int Cost => 380;

    public override string DisplayName => "Quicker Cutting";

    public override string Description => "Gives haircuts 50% faster";

    public override string Icon => "100";

    public override string Portrait => "100";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.rate -= 0.35f;
    }

}