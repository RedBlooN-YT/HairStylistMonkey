using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.TopPath;

public class SuperScissorHandler : ModUpgrade<HairStylistMonkey>
{
    public override int Path => TOP;

    public override int Tier => 4;

    public override int Cost => 8660;

    public override string DisplayName => "Super Scissor Handler";

    public override string Description => "He's the super handler of the scissors. He practiced 24/7 to get this good!";

    public override string Icon => "400";

    public override string Portrait => "400";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.rate -= 0.11f;
        projectileModel.GetDamageModel().damage += 10;
    }

}