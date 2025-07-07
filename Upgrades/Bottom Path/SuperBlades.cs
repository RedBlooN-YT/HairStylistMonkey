using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.BottomPath;

public class SuperBlades : ModUpgrade<HairStylistMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 3;

    public override int Cost => 4030;

    public override string DisplayName => "Super Blades";

    public override string Description => "Why cut with scissors when you can cut with BLADES!!!";

    public override string Icon => "003";

    public override string Portrait => "003";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;
       // weaponModel.projectile.ApplyDisplay<KnifeDisplay>();

        projectileModel.GetDamageModel().damage += 3;
    }

}