using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;

namespace HairStylistMonkey.Upgrades.TopPath;

public class RecordTimeHaircuts : ModUpgrade<HairStylistMonkey>
{
    public override int Path => TOP;

    public override int Tier => 3;

    public override int Cost => 1870;

    public override string DisplayName => "Record-time Haircuts";

    public override string Description => "He can do it so fast, that he can basiccly do multiple haircuts at once!";
    public override string Icon => "300";
    public override string Portrait => "300";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.rate -= 0.13f;
        projectileModel.pierce = 5;
    }

}