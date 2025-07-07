using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper;
using HairStylistMonkey.Displays.Projectiles;

namespace HairStylistMonkey;

public class HairStylistMonkey : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;

    public override string BaseTower => TowerType.DartMonkey;

    public override int Cost => 600;

    public override ParagonMode ParagonMode => ParagonMode.Base555;

    public override bool IncludeInRogueLegends => true;

    public override string Description => "He cuts the monkeys hair for free. He also cuts the Bloons hair, but for a price.";

    public override string DisplayName => "Hair Stylist Monkey";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;
       // var projectile = attackModel.weapons[0].projectile;
       // projectile.ApplyDisplay<ScissorsDisplay>();

        // range
        towerModel.range = 27;
        towerModel.GetAttackModel().range = 27;

        // attck speed
        weaponModel.rate = 1.04f;

        // Damage + pierce
        projectileModel.pierce = 2;
        projectileModel.GetDamageModel().damage = 2;
    }

    // Ultimate Crosspathing
    public override bool IsValidCrosspath(int[] tiers) =>
        ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);

}
