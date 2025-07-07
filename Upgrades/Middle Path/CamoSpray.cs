using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Filters;

namespace HairStylistMonkey.Upgrades.MiddlePath;

public class CamoSpray : ModUpgrade<HairStylistMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 2;

    public override int Cost => 3000;

    public override string DisplayName => "Camo Spray";

    public override string Description => "Can see all Bloon types.";
    public override string Icon => "020";

    public override string Portrait => "020";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;
     
     // hit all bloon types
        weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

        towerModel.GetAttackModel().RemoveFilter<FilterInvisibleModel>();
        towerModel.GetAttackModel().weapons[0].projectile.SetHitCamo(true);

        towerModel.range += 5;
        towerModel.GetAttackModel().range += 5;
    }

}