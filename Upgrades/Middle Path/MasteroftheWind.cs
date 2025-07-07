using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppSystem.Linq;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppSystem.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;


namespace HairStylistMonkey.Upgrades.MiddlePath;

public class MasteroftheWind : ModUpgrade<HairStylistMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 5;

    public override int Cost => 59000;

    public override string DisplayName => "Master of the Wind";

    public override string Description => "Nobody else knows how to use hair driers to their full potential.";

    public override string Icon => "050";

    public override string Portrait => "050";
    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        projectileModel.GetDamageModel().damage += 10;

        towerModel.range += 5;
        towerModel.GetAttackModel().range += 5;


        // Stronger burn
        var projectiles = new List<ProjectileModel>(
            towerModel.GetDescendants<ProjectileModel>()
        );

        foreach (var proj in projectiles)
        {
            var dot = proj.GetBehavior<DamageOverTimeModel>();
            if (dot != null)
            {
                dot.damage = 20f;
                dot.interval = 0.5f;
            }






        }
            //Permahairdrier

            var druid300 = Game.instance.model.GetTowerModel("Druid", 3, 0, 0);
            var tornadoTpl = druid300.GetAttackModels().First(a => a.name.Contains("Tornado"));

            var tornadoAttack = tornadoTpl.Duplicate("HairDryer_T5_TornadoAttack");

            tornadoAttack.RemoveFilter<FilterInvisibleModel>();
            tornadoAttack.weapons[0].projectile.SetHitCamo(true);

            var tornadoWeapon = tornadoAttack.weapons[0];
            tornadoWeapon.Rate = 0.75f;
            tornadoWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);

            towerModel.AddBehavior(tornadoAttack);




            //ability

            var existingAbilities = towerModel.GetBehaviors<AbilityModel>().ToArray();
            foreach (var abil in existingAbilities)
                towerModel.RemoveBehavior(abil);


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
