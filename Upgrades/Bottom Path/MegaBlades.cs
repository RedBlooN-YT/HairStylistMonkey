using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace HairStylistMonkey.Upgrades.BottomPath;
public class MegaBlades : ModUpgrade<HairStylistMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 4;

    public override int Cost => 15350;

    public override string DisplayName => "Megablades";

    public override string Description => "These blades are huge, and they can cut through a MOABS's hair. Just don't use it to cut a monkey's hair!";

    public override string Icon => "004";

    public override string Portrait => "004";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;
            foreach (var projectile in towerModel.GetWeapons().Select(weaponModel => weaponModel.projectile))
       
        weaponModel.rate -= 0.5f;
        projectileModel.GetDamageModel().damage += 10;

        projectileModel.GetDamageModel().damage++;
        projectileModel.AddBehavior(new DamageModifierForTagModel("", "Moabs", 1, 30, false, false));
        projectileModel.hasDamageModifiers = true;
    }
    
}
