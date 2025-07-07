using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using System.Linq;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;


namespace HairStylistMonkey.Upgrades.MiddlePath;

public class HairDryer : ModUpgrade<HairStylistMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 4;

    public override int Cost => 7500;

    public override string DisplayName => "Hair Drier";

    public override string Description => "Ability: When activated, he uses a hairdrier to blow back bloons.";

    public override string Icon => "040";

    public override string Portrait => "040";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        projectileModel.GetDamageModel().damage += 2;

        towerModel.range += 5;
        towerModel.GetAttackModel().range += 5;
        // stronger burn
        var dots = towerModel.GetDescendants<DamageOverTimeModel>().ToList();

        foreach (var dot in dots)
        {
            dot.damage = 10f;
        }



        

        //ability
        var ability = Game.instance.model.GetTowerModel("DartlingGunner", 1, 4, 0).GetAbility().Duplicate("HairDryerTornadoBlast");
        ability.cooldown = 40;

        var activate = ability.GetBehavior<ActivateAttackModel>();
        activate.lifespan = 10;

        var druid300 = Game.instance.model.GetTowerModel("Druid", 3, 0, 0);
        var tornadoTemplate = druid300.GetAttackModels().First(a => a.name.Contains("Tornado"));
        var tornadoAttack = tornadoTemplate.Duplicate("HairDryerTornadoAttack");

        tornadoAttack.RemoveFilter<FilterInvisibleModel>();
        tornadoAttack.weapons[0].projectile.SetHitCamo(true);

        activate.attacks[0] = tornadoAttack;

        var tornadoWeapon = tornadoAttack.weapons[0];

        tornadoWeapon.Rate = 0.3f;
        tornadoWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);

        towerModel.AddBehavior(ability);
    }
}