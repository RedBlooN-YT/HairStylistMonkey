using System.Linq;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppSystem.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace HairStylistMonkey.Upgrades;

public class SupermasterOfStyling : ModParagonUpgrade<HairStylistMonkey>
{

    public override int Cost => 752400;

    public override string DisplayName => "Supermaster of Styling";

    public override string Description => "He's the true master of the scissors... the bloons have no idea what they're in for.";

    public override string Icon => "555";

    public override string Portrait => "555";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
var ability = Game.instance.model.GetTowerModel("DartlingGunner", 1, 4, 0).GetAbility().Duplicate("MasterOfTheWindTornadoBlast");
            ability.cooldown = 60;

            var activate = ability.GetBehavior<ActivateAttackModel>();
            activate.lifespan = 20;


            var druid500 = Game.instance.model.GetTowerModel("Druid", 5, 0, 0);


            var tornadoAttackTemplate = druid500.GetAttackModels().First(a => a.weapons.Any(w => w.name.Contains("SuperstormTornado")));


            var superStormAttack = tornadoAttackTemplate.Duplicate<AttackModel>("MasterOfTheWindTornadoAttack");


            var baseWeapon = tornadoAttackTemplate.weapons.First(w => w.name.Contains("SuperstormTornado"));

            var superStormWeapon = baseWeapon.Duplicate<WeaponModel>("MasterOfTheWindTornadoWeapon");


            superStormAttack.RemoveFilter<FilterInvisibleModel>();

            superStormWeapon.projectile.SetHitCamo(true);

            superStormWeapon.Rate = 0.3f;

            superStormWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);


            superStormAttack.weapons[0] = superStormWeapon;


            activate.attacks[0] = superStormAttack;


            towerModel.AddBehavior(ability);
    }

}