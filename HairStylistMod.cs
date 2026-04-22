using MelonLoader;
using BTD_Mod_Helper;
using HairStylistMonkey;
using BTD_Mod_Helper.Api.ModOptions;
using Harmony;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Data.Behaviors.Projectiles;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Data.Bloons;
using UnityEngine;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Api;
using HairStylistMonkey.Displays.Projectiles;
using BTD_Mod_Helper.Extensions;
using System;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System.IO;
using MelonLoader.Utils;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers;
using UnityEngine.UI;
using Il2CppInterop.Runtime.Injection;

[assembly: MelonInfo(typeof(HairStylistMonkey.HairStylistMod), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace HairStylistMonkey
{
    public class HairStylistMod : BloonsTD6Mod
    {

        public static readonly ModSettingBool Hair = new ModSettingBool(false)
        {
            displayName = "HairBloons",
            description = "If enabled all bloons will spawn with hair on them, Make sure all trophy store bloon skins are disabled or they will mess it up.",
            requiresRestart = false
        };
        public static readonly ModSettingBool HairProj = new ModSettingBool(false)
        {
            displayName = "HairProjectiles",
            description = "If enabled all projectiles will spawn with hair on them.",
            requiresRestart = false
        };
        public static readonly ModSettingBool HairTower = new ModSettingBool(false)
        {
            displayName = "HairTowers",
            description = "If enabled all towers will spawn with hair on them.",
            requiresRestart = false
        };
        public static readonly ModSettingBool HairInsane = new ModSettingBool(false)
        {
            displayName = "MutantHair",
            description = "Takes inspiration from Tewtiy's mutant/cursed tower mods. If enabled based on which other settings are enabled it will change the hair texture that is applied.",
            requiresRestart = false,
        };
        public static readonly ModSettingInt MutantLevel = new ModSettingInt(1)
        {
            slider = true,
            min = 1,
            max = 5,
            displayName = "MutantLevel",
            description = "The higher this number the crazier it gets. (Meant to only be increased if mutant hair is enabled, but works with out it too.)",
            requiresRestart = false,
        };

        public static Texture2D? HairTexture;
        public static Texture2D? HairInsaneTexture;
        public static Texture2D? FullHairTexture;

        public override void OnApplicationStart()
        {
            ClassInjector.RegisterTypeInIl2Cpp<HairWiggle>();

            
            var assembly = typeof(HairStylistMod).Assembly;

            using var stream = assembly.GetManifestResourceStream("HairStylistMonkey.Hair.png");
            if (stream == null)
            {
                MelonLogger.Msg("Failed to load embedded resource Hair.png");
                return;
            }

            using var ms = new MemoryStream();
            stream.CopyTo(ms);

            HairTexture = new Texture2D(2, 2);
            HairTexture.LoadImage(ms.ToArray());



            var assembly2 = typeof(HairStylistMod).Assembly;

            using var stream2 = assembly2.GetManifestResourceStream("HairStylistMonkey.HairInsane.png");
            if (stream2 == null)
            {
                MelonLogger.Msg("Failed to load embedded resource HairInsane.png");
                return;
            }

            using var ms2 = new MemoryStream();
            stream2.CopyTo(ms2);

            HairInsaneTexture = new Texture2D(2, 2);
            HairInsaneTexture.LoadImage(ms2.ToArray());


            var assembly3 = typeof(HairStylistMod).Assembly;

            using var stream3 = assembly3.GetManifestResourceStream("HairStylistMonkey.FullHair.png");
            if (stream3 == null)
            {
                MelonLogger.Msg("Failed to load embedded resource FullHair.png");
                return;
            }

            using var ms3 = new MemoryStream();
            stream3.CopyTo(ms3);

            FullHairTexture = new Texture2D(2, 2);
            FullHairTexture.LoadImage(ms3.ToArray());
        }
    }
}