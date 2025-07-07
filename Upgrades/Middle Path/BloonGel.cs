using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;


namespace HairStylistMonkey.Upgrades.MiddlePath;

public class BloonGel : ModUpgrade<HairStylistMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 3;

    public override int Cost => 2700;

    public override string DisplayName => "Bloon Gel";

    public override string Description => "This monkey isn't doing his job! Hair gel isn't supposed to set things on fire; it's supposed to make hair sticky!";

    public override string Icon => "030";

    public override string Portrait => "030";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

        if (Game.instance?.model == null)
            return;


        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        towerModel.range += 10;
        towerModel.GetAttackModel().range += 10;

//Burn

        AddBehaviorToBloonModel burn = Game.instance.model.GetTower("WizardMonkey", 0, 3, 0).GetDescendant<AddBehaviorToBloonModel>().Duplicate();
        towerModel.GetDescendants<ProjectileModel>().ForEach(x => x.AddBehavior(burn));

        towerModel.GetDescendants<ProjectileModel>().ForEach(x => x.UpdateCollisionPassList());

        
    }
}