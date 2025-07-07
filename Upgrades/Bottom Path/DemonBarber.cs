using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;


namespace HairStylistMonkey.Upgrades.BottomPathPath;

public class DemonBarber : ModUpgrade<HairStylistMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 5;

    public override int Cost => 44500;

    public override string DisplayName => "The Demon Barber";

    public override string Description => "The bloons have no choice but to get their hair cut by this crazy demon.";

    public override string Icon => "005";
    
    public override string Portrait => "005";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;
        foreach (var projectile in towerModel.GetWeapons().Select(weaponModel => weaponModel.projectile))

        projectileModel.pierce += 15;
        projectileModel.GetDamageModel().damage += 80;
        weaponModel.rate -= 0.7f;

        towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 10, null, false, false);

        projectileModel.GetDamageModel().damage++;
        projectileModel.AddBehavior(new DamageModifierForTagModel("", "Moabs", 1, 35, false, false));
        projectileModel.hasDamageModifiers = true;
    }
}