using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace HairStylistMonkey.Upgrades.TopPath;

public class HypersonicScissormaster : ModUpgrade<HairStylistMonkey>
{
    public override int Path => TOP;

    public override int Tier => 5;

    public override int Cost => 34000;

    public override string DisplayName => "Hypersonic Scissormaster";

    public override string Description => "Even the biggest bloons get destryoed, (Cough, Cough) I mean... get their hair cut in seconds.";

    public override string Icon => "500";

    public override string Portrait => "500";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;
        foreach (var projectile in towerModel.GetWeapons().Select(weaponModel => weaponModel.projectile))

            weaponModel.rate -= 0.5f;
        projectileModel.GetDamageModel().damage += 10;

        towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 10, null, false, false);

        projectileModel.GetDamageModel().damage++;
        projectileModel.AddBehavior(new DamageModifierForTagModel("", "Moabs", 1, 10, false, false));
        projectileModel.hasDamageModifiers = true;
    }

}