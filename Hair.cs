using BTD_Mod_Helper.Api.ModOptions;
using HairStylistMonkey;
using HarmonyLib;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.Achievements.List;

//using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppSystem;
using JetBrains.Annotations;
using MelonLoader;
using UnityEngine;
using UnityEngine.Playables;


namespace HairStylistMonkey.Upgrades
{
    [HarmonyPatch(typeof(UnityDisplayNode), "Initialize")]
    public static class HairMoabPatch
    {
        static void Postfix(UnityDisplayNode __instance)
        {
            bool Hair = (bool)HairStylistMod.Hair.GetValue();
            bool Hairinsane = (bool)HairStylistMod.HairInsane.GetValue();


            if (Hair == false)
            {
                return;
            }

            var name = __instance.name ?? "";

            bool isMoab =
                name.Contains("Moab") ||
                name.Contains("Bfb") ||
                name.Contains("Zomg") ||
                name.Contains("Ddt") ||
                name.Contains("Bad") ||
                name.Contains("TestBloonMoab") ||
                name.Contains("Bloonarius") ||
                name.Contains("Vortex") ||
                name.Contains("Diamondback") ||
                name.Contains("Phayze") ||
                name.Contains("Dreadbloon") ||
                name.Contains("Lych") ||
                name.Contains("Blastapopoulos");


            bool isBloon =
                name.Contains("Red") ||
                name.Contains("Blue") ||
                name.Contains("Green") ||
                name.Contains("Yellow") ||
                name.Contains("Pink") ||
                name.Contains("Black") ||
                name.Contains("White") ||
                name.Contains("Purple") ||
                name.Contains("Lead") ||
                name.Contains("Rainbow") ||
                name.Contains("Ceramic") ||
                name.Contains("Gold") ||
                name.Contains("Aura") ||
                name.Contains("Glass") ||
                name.Contains("Dynamite") ||
                name.Contains("Ringleader") ||
                name.Contains("Retribution") ||
                name.Contains("TestBloon") ||
                name.Contains("DiamondBloon") ||
                name.Contains("DreadRockBloon") ||
                name.Contains("Dosh");

            bool isOther =
                name.Contains("Marble");


            Transform? display = null;
            if (isMoab)
            {

                for (int i = 0; i < __instance.transform.childCount; i++)
                {
                    var child = __instance.transform.GetChild(i);

                    if (child.GetComponentInChildren<MeshRenderer>() != null)
                    {
                        display = child;
                        break;
                    }
                }

                if (display == null)
                {
                    display = __instance.transform;
                }
            }
            else if (isOther)
            {
                return;
            }
            else if (isBloon)
            {
                display = __instance.transform;
            }
            else
            {
                return;
            }




            var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);


            var wiggle = quad.AddComponent<HairWiggle>();
            wiggle.isMoab = isMoab;
            wiggle.isBloon = isBloon;
            wiggle.isTower = false;


            quad.name = "HairOverlayQuad";
            quad.transform.SetParent(display, false);


            quad.layer = __instance.gameObject.layer;


            var renderer = quad.GetComponent<MeshRenderer>();
            renderer.material = new Material(Shader.Find("UI/Default"));





            /* if (Hairinsane == true && MutantLevel > 1)
             {
                 renderer.material.mainTexture = HairStylistMod.FullHairTexture;
             }
             else if (Hairinsane == true)
             {
                 renderer.material.mainTexture = HairStylistMod.HairInsaneTexture;
             }
             else if (Hairinsane == false)
             {
                 renderer.material.mainTexture = HairStylistMod.HairTexture;
             }


            if (isMoab)
            {
                quad.AddComponent<CameraLooker>();
                quad.transform.rotation = Quaternion.LookRotation(Camera.main.transform.position);
                quad.transform.Rotate(0, 0, 90, Space.Self);
                quad.transform.localScale = Vector3.one * 110f * ((MutantLevel + 1f) / 2f);
            }
            else
            {
                quad.transform.localScale = Vector3.one * 50f * ((MutantLevel + 1f) / 2f);
            }*/
        }
    }
    [HarmonyPatch(typeof(UnityDisplayNode), "Initialize")]
    public static class HairProjPatch
    {
        static void Postfix(UnityDisplayNode __instance)
        {
            bool Hairproj = (bool)HairStylistMod.HairProj.GetValue();
            bool Hairinsane = (bool)HairStylistMod.HairInsane.GetValue();


            if (Hairproj == false)
            {
                return;
            }

            var name = __instance.name ?? "";

            bool isMoab =
                name.Contains("Moab") ||
                name.Contains("Bfb") ||
                name.Contains("Zomg") ||
                name.Contains("Ddt") ||
                name.Contains("Bad") ||
                name.Contains("TestBloonMoab") ||
                name.Contains("Bloonarius") ||
                name.Contains("Vortex") ||
                name.Contains("Diamondback") ||
                name.Contains("Phayze") ||
                name.Contains("Dreadbloon") ||
                name.Contains("Lych") ||
                name.Contains("Blastapopoulos");


            bool isBloon =
                name.Contains("Red") ||
                name.Contains("Blue") ||
                name.Contains("Green") ||
                name.Contains("Yellow") ||
                name.Contains("Pink") ||
                name.Contains("Black") ||
                name.Contains("White") ||
                name.Contains("Purple") ||
                name.Contains("Lead") ||
                name.Contains("Rainbow") ||
                name.Contains("Ceramic") ||
                name.Contains("Gold") ||
                name.Contains("Aura") ||
                name.Contains("Glass") ||
                name.Contains("Dynamite") ||
                name.Contains("Ringleader") ||
                name.Contains("Retribution") ||
                name.Contains("TestBloon") ||
                name.Contains("DiamondBloon") ||
                name.Contains("DreadRockBloon") ||
                name.Contains("Dosh");

            bool isTower =
                name.Contains("Dart") ||
                name.Contains("Boomerang") ||
                name.Contains("Bomb") ||
                name.Contains("Tack") ||
                name.Contains("Ice") ||
                name.Contains("Glue") ||
                name.Contains("Desperado") ||
                name.Contains("Sniper") ||
                name.Contains("MonkeySub") ||
                name.Contains("MonkeyBuccaneer") ||
                name.Contains("MonkeyAce") ||
                name.Contains("HeliPilot") ||
                name.Contains("Mortar") ||
                name.Contains("Dartling") ||
                name.Contains("Wizard") ||
                name.Contains("SuperMonkey") ||
                name.Contains("NinjaMonkey") ||
                name.Contains("Alchemist") ||
                name.Contains("Druid") ||
                name.Contains("Mermonkey") ||
                name.Contains("BananaFarm") ||
                name.Contains("SpikeFactory") ||
                name.Contains("MonkeyVillage") ||
                name.Contains("EngineerMonkey") ||
                name.Contains("BeastHandler") ||
                name.Contains("Sentry") ||
                name.Contains("Beast") ||
                name.Contains("Hero") ||
                name.Contains("Pet") ||
                name.Contains("HairStylistMonkey") ||
                name.Contains("MarbleMonkey") ||
                name.Contains("GasStationMonkey") ||
                name.Contains("ArmyBase") ||
                name.Contains("Tower") ||
                name.Contains("Quincy") ||
                name.Contains("Gwendolin") ||
                name.Contains("StrikerJones") ||
                name.Contains("ObynGreenfoot") ||
                name.Contains("CaptainChurchill") ||
                name.Contains("Benjamin") ||
                name.Contains("Ezili") ||
                name.Contains("AdmiralBrickell") ||
                name.Contains("PatFusty") ||
                name.Contains("Etienne") ||
                name.Contains("Sauda") ||
                name.Contains("Psi") ||
                name.Contains("Adora") ||
                name.Contains("Corvus") ||
                name.Contains("Rosalia") ||
                name.Contains("Silas") ||
                name.Contains("Geraldo") ||
                name.Contains("Gyrfalcon") ||
                name.Contains("Microraptor") ||
                name.Contains("Piranha");

            if (isMoab || isBloon || isTower || name.Contains("Pop") || name.Contains("Explosion") || name.Contains("Effect") || name.Contains("Bloon"))
            {
                if (!name.Contains("Marble") || !name.Contains("Spike"))
                {
                    return;
                }

            }

            Transform? display = null;


            display = __instance.transform;





            var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

            var wiggle = quad.AddComponent<HairWiggle>();
            wiggle.isMoab = isMoab;
            wiggle.isBloon = isBloon;
            wiggle.isTower = isTower;


            quad.name = "HairOverlayQuad";
            quad.transform.SetParent(display, false);


            quad.layer = __instance.gameObject.layer + 5;


            var renderer = quad.GetComponent<MeshRenderer>();
            renderer.material = new Material(Shader.Find("UI/Default"));


            /* if (Hairinsane == true && MutantLevel > 1)
             {
                 renderer.material.mainTexture = HairStylistMod.FullHairTexture;
             }
             else if (Hairinsane == true)
             {
                 renderer.material.mainTexture = HairStylistMod.HairInsaneTexture;
             }
             else if (Hairinsane == false)
             {
                 renderer.material.mainTexture = HairStylistMod.HairTexture;
             }

             quad.transform.localScale = Vector3.one * 75f * ((MutantLevel + 1f) / 2f);*/

        }
    }

    [HarmonyPatch(typeof(UnityDisplayNode), "Initialize")]
    public static class HairTowerPatch
    {
        static void Postfix(UnityDisplayNode __instance)
        {
            bool Hairtower = (bool)HairStylistMod.HairTower.GetValue();
            bool Hairinsane = (bool)HairStylistMod.HairInsane.GetValue();



            if (Hairtower == false)
            {
                return;
            }

            var name = __instance.name ?? "";

            bool isMoab =
                name.Contains("Moab") ||
                name.Contains("Bfb") ||
                name.Contains("Zomg") ||
                name.Contains("Ddt") ||
                name.Contains("Bad") ||
                name.Contains("TestBloonMoab") ||
                name.Contains("Bloonarius") ||
                name.Contains("Vortex") ||
                name.Contains("Diamondback") ||
                name.Contains("Phayze") ||
                name.Contains("Dreadbloon") ||
                name.Contains("Lych") ||
                name.Contains("Blastapopoulos");


            bool isBloon =
                name.Contains("Red") ||
                name.Contains("Blue") ||
                name.Contains("Green") ||
                name.Contains("Yellow") ||
                name.Contains("Pink") ||
                name.Contains("Black") ||
                name.Contains("White") ||
                name.Contains("Purple") ||
                name.Contains("Lead") ||
                name.Contains("Rainbow") ||
                name.Contains("Ceramic") ||
                name.Contains("Gold") ||
                name.Contains("Aura") ||
                name.Contains("Glass") ||
                name.Contains("Dynamite") ||
                name.Contains("Ringleader") ||
                name.Contains("Retribution") ||
                name.Contains("TestBloon") ||
                name.Contains("DiamondBloon") ||
                name.Contains("DreadRockBloon") ||
                name.Contains("Dosh");

            bool isTower =
              name.Contains("Dart") ||
              name.Contains("Boomerang") ||
              name.Contains("Bomb") ||
              name.Contains("Tack") ||
              name.Contains("Ice") ||
              name.Contains("Glue") ||
              name.Contains("Desperado") ||
              name.Contains("Sniper") ||
              name.Contains("MonkeySub") ||
              name.Contains("MonkeyBuccaneer") ||
              name.Contains("MonkeyAce") ||
              name.Contains("HeliPilot") ||
              name.Contains("Mortar") ||
              name.Contains("Dartling") ||
              name.Contains("Wizard") ||
              name.Contains("SuperMonkey") ||
              name.Contains("NinjaMonkey") ||
              name.Contains("Alchemist") ||
              name.Contains("Druid") ||
              name.Contains("Mermonkey") ||
              name.Contains("BananaFarm") ||
              name.Contains("SpikeFactory") ||
              name.Contains("MonkeyVillage") ||
              name.Contains("EngineerMonkey") ||
              name.Contains("BeastHandler") ||
              name.Contains("Sentry") ||
              name.Contains("Beast") ||
              name.Contains("Hero") ||
              name.Contains("Pet") ||
              name.Contains("HairStylistMonkey") ||
              name.Contains("MarbleMonkey") ||
              name.Contains("GasStationMonkey") ||
              name.Contains("ArmyBase") ||
              name.Contains("Tower") ||
              name.Contains("Quincy") ||
              name.Contains("Gwendolin") ||
              name.Contains("StrikerJones") ||
              name.Contains("ObynGreenfoot") ||
              name.Contains("CaptainChurchill") ||
              name.Contains("Benjamin") ||
              name.Contains("Ezili") ||
              name.Contains("AdmiralBrickell") ||
              name.Contains("PatFusty") ||
              name.Contains("Etienne") ||
              name.Contains("Sauda") ||
              name.Contains("Psi") ||
              name.Contains("Adora") ||
              name.Contains("Corvus") ||
              name.Contains("Rosalia") ||
              name.Contains("Silas") ||
              name.Contains("Geraldo") ||
              name.Contains("Gyrfalcon") ||
              name.Contains("Microraptor") ||
              name.Contains("Piranha");

            if (!isTower)
            {
                return;
            }

            Transform? display = null;


            display = __instance.transform;



            var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

            var wiggle = quad.AddComponent<HairWiggle>();
            wiggle.isMoab = isMoab;
            wiggle.isBloon = isBloon;
            wiggle.isTower = isTower;



            quad.name = "HairOverlayQuad";
            quad.transform.SetParent(display, false);


            quad.layer = __instance.gameObject.layer + 999;


            var renderer = quad.GetComponent<MeshRenderer>();
            renderer.material = new Material(Shader.Find("UI/Default"));

            /* if (Hairinsane == true && MutantLevel > 1)
             {
                 renderer.material.mainTexture = HairStylistMod.FullHairTexture;
             }
             else if (Hairinsane == true)
             {
                 renderer.material.mainTexture = HairStylistMod.HairInsaneTexture;
             }
             else if (Hairinsane == false)
             {
                 renderer.material.mainTexture = HairStylistMod.HairTexture;
             }


             quad.transform.localScale = Vector3.one * 75f * ((MutantLevel + 1f) / 2f);*/
        }
    }
}
[HarmonyPatch(typeof(ModSettingBool), nameof(ModSettingBool.SetValue))]
public static class HairAddPatch
{
    static void Postfix(ModSettingBool __instance)
    {
        bool Hairtower = (bool)HairStylistMod.HairTower.GetValue();
        bool hair = (bool)HairStylistMod.Hair.GetValue();
        bool hairproj = (bool)HairStylistMod.HairProj.GetValue();

        bool bloonChanged = false;
        bool projChanged = false;
        bool towerChanged = false;

        if (__instance == HairStylistMod.Hair)
        {
            bloonChanged = true;
        }
        if (__instance == HairStylistMod.HairProj)
        {
            projChanged = true;
        }
        if (__instance == HairStylistMod.HairTower)
        {
            towerChanged = true;
        }


        foreach (var node in GameObject.FindObjectsOfType<UnityDisplayNode>())
        {
            bool isMoab =
                node.name.Contains("Moab") ||
                node.name.Contains("Bfb") ||
                node.name.Contains("Zomg") ||
                node.name.Contains("Ddt") ||
                node.name.Contains("Bad") ||
                node.name.Contains("TestBloonMoab") ||
                node.name.Contains("Bloonarius") ||
                node.name.Contains("Vortex") ||
                node.name.Contains("Diamondback") ||
                node.name.Contains("Phayze") ||
                node.name.Contains("Dreadbloon") ||
                node.name.Contains("Lych") ||
                node.name.Contains("Blastapopoulos");


            bool isBloon =
                node.name.Contains("Red") ||
                node.name.Contains("Blue") ||
                node.name.Contains("Green") ||
                node.name.Contains("Yellow") ||
                node.name.Contains("Pink") ||
                node.name.Contains("Black") ||
                node.name.Contains("White") ||
                node.name.Contains("Purple") ||
                node.name.Contains("Lead") ||
                node.name.Contains("Rainbow") ||
                node.name.Contains("Ceramic") ||
                node.name.Contains("Gold") ||
                node.name.Contains("Aura") ||
                node.name.Contains("Glass") ||
                node.name.Contains("Dynamite") ||
                node.name.Contains("Ringleader") ||
                node.name.Contains("Retribution") ||
                node.name.Contains("TestBloon") ||
                node.name.Contains("DiamondBloon") ||
                node.name.Contains("DreadRockBloon") ||
                node.name.Contains("Dosh");

            bool isTower =
              node.name.Contains("Dart") ||
              node.name.Contains("Boomerang") ||
              node.name.Contains("Bomb") ||
              node.name.Contains("Tack") ||
              node.name.Contains("Ice") ||
              node.name.Contains("Glue") ||
              node.name.Contains("Desperado") ||
              node.name.Contains("Sniper") ||
              node.name.Contains("MonkeySub") ||
              node.name.Contains("MonkeyBuccaneer") ||
              node.name.Contains("MonkeyAce") ||
              node.name.Contains("HeliPilot") ||
              node.name.Contains("Mortar") ||
              node.name.Contains("Dartling") ||
              node.name.Contains("Wizard") ||
              node.name.Contains("SuperMonkey") ||
              node.name.Contains("NinjaMonkey") ||
              node.name.Contains("Alchemist") ||
              node.name.Contains("Druid") ||
              node.name.Contains("Mermonkey") ||
              node.name.Contains("BananaFarm") ||
              node.name.Contains("SpikeFactory") ||
              node.name.Contains("MonkeyVillage") ||
              node.name.Contains("EngineerMonkey") ||
              node.name.Contains("BeastHandler") ||
              node.name.Contains("Sentry") ||
              node.name.Contains("Beast") ||
              node.name.Contains("Hero") ||
              node.name.Contains("Pet") ||
              node.name.Contains("HairStylistMonkey") ||
              node.name.Contains("MarbleMonkey") ||
              node.name.Contains("GasStationMonkey") ||
              node.name.Contains("ArmyBase") ||
              node.name.Contains("Tower") ||
              node.name.Contains("Quincy") ||
              node.name.Contains("Gwendolin") ||
              node.name.Contains("StrikerJones") ||
              node.name.Contains("ObynGreenfoot") ||
              node.name.Contains("CaptainChurchill") ||
              node.name.Contains("Benjamin") ||
              node.name.Contains("Ezili") ||
              node.name.Contains("AdmiralBrickell") ||
              node.name.Contains("PatFusty") ||
              node.name.Contains("Etienne") ||
              node.name.Contains("Sauda") ||
              node.name.Contains("Psi") ||
              node.name.Contains("Adora") ||
              node.name.Contains("Corvus") ||
              node.name.Contains("Rosalia") ||
              node.name.Contains("Silas") ||
              node.name.Contains("Geraldo") ||
              node.name.Contains("Gyrfalcon") ||
              node.name.Contains("Microraptor") ||
              node.name.Contains("Piranha");




            if (towerChanged == true && isTower)
            {
                AttachQuad(node);
            }
            if (!isMoab && !isBloon && !isTower && !node.name.Contains("Pop") && !node.name.Contains("Explosion") && !node.name.Contains("Effect") && !node.name.Contains("Bloon") && projChanged == true)
            {
                AttachQuad(node);
            }
            if (node.name.Contains("Marble") || node.name.Contains("Spike") && projChanged == true)
            {
                AttachQuad(node);
            }
            if (isMoab || isBloon && bloonChanged == true)
            {
                AttachQuad(node);
            }

        }

    }
    public static void AttachQuad(UnityDisplayNode node)
    {
        bool isMoab =
                node.name.Contains("Moab") ||
                node.name.Contains("Bfb") ||
                node.name.Contains("Zomg") ||
                node.name.Contains("Ddt") ||
                node.name.Contains("Bad") ||
                node.name.Contains("TestBloonMoab") ||
                node.name.Contains("Bloonarius") ||
                node.name.Contains("Vortex") ||
                node.name.Contains("Diamondback") ||
                node.name.Contains("Phayze") ||
                node.name.Contains("Dreadbloon") ||
                node.name.Contains("Lych") ||
                node.name.Contains("Blastapopoulos");
        bool isBloon =
               node.name.Contains("Red") ||
               node.name.Contains("Blue") ||
               node.name.Contains("Green") ||
               node.name.Contains("Yellow") ||
               node.name.Contains("Pink") ||
               node.name.Contains("Black") ||
               node.name.Contains("White") ||
               node.name.Contains("Purple") ||
               node.name.Contains("Lead") ||
               node.name.Contains("Rainbow") ||
               node.name.Contains("Ceramic") ||
               node.name.Contains("Gold") ||
               node.name.Contains("Aura") ||
               node.name.Contains("Glass") ||
               node.name.Contains("Dynamite") ||
               node.name.Contains("Ringleader") ||
               node.name.Contains("Retribution") ||
               node.name.Contains("TestBloon") ||
               node.name.Contains("DiamondBloon") ||
               node.name.Contains("DreadRockBloon") ||
               node.name.Contains("Dosh");

        bool isTower =
          node.name.Contains("Dart") ||
          node.name.Contains("Boomerang") ||
          node.name.Contains("Bomb") ||
          node.name.Contains("Tack") ||
          node.name.Contains("Ice") ||
          node.name.Contains("Glue") ||
          node.name.Contains("Desperado") ||
          node.name.Contains("Sniper") ||
          node.name.Contains("MonkeySub") ||
          node.name.Contains("MonkeyBuccaneer") ||
          node.name.Contains("MonkeyAce") ||
          node.name.Contains("HeliPilot") ||
          node.name.Contains("Mortar") ||
          node.name.Contains("Dartling") ||
          node.name.Contains("Wizard") ||
          node.name.Contains("SuperMonkey") ||
          node.name.Contains("NinjaMonkey") ||
          node.name.Contains("Alchemist") ||
          node.name.Contains("Druid") ||
          node.name.Contains("Mermonkey") ||
          node.name.Contains("BananaFarm") ||
          node.name.Contains("SpikeFactory") ||
          node.name.Contains("MonkeyVillage") ||
          node.name.Contains("EngineerMonkey") ||
          node.name.Contains("BeastHandler") ||
          node.name.Contains("Sentry") ||
          node.name.Contains("Beast") ||
          node.name.Contains("Hero") ||
          node.name.Contains("Pet") ||
          node.name.Contains("HairStylistMonkey") ||
          node.name.Contains("MarbleMonkey") ||
          node.name.Contains("GasStationMonkey") ||
          node.name.Contains("ArmyBase") ||
          node.name.Contains("Tower") ||
          node.name.Contains("Quincy") ||
          node.name.Contains("Gwendolin") ||
          node.name.Contains("StrikerJones") ||
          node.name.Contains("ObynGreenfoot") ||
          node.name.Contains("CaptainChurchill") ||
          node.name.Contains("Benjamin") ||
          node.name.Contains("Ezili") ||
          node.name.Contains("AdmiralBrickell") ||
          node.name.Contains("PatFusty") ||
          node.name.Contains("Etienne") ||
          node.name.Contains("Sauda") ||
          node.name.Contains("Psi") ||
          node.name.Contains("Adora") ||
          node.name.Contains("Corvus") ||
          node.name.Contains("Rosalia") ||
          node.name.Contains("Silas") ||
          node.name.Contains("Geraldo") ||
          node.name.Contains("Gyrfalcon") ||
          node.name.Contains("Microraptor") ||
          node.name.Contains("Piranha");

        Transform? display = null;

        if (isMoab)
        {

            for (int i = 0; i < node.transform.childCount; i++)
            {
                var child = node.transform.GetChild(i);

                if (child.GetComponentInChildren<MeshRenderer>() != null)
                {
                    display = child;
                    break;
                }
            }

            if (display == null)
            {
                display = node.transform;
            }
        }
        else
        {
            display = node.transform;
        }



        var quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

        var wiggle = quad.AddComponent<HairWiggle>();
        wiggle.isMoab = isMoab;
        wiggle.isBloon = isBloon;
        wiggle.isTower = isTower;



        quad.name = "HairOverlayQuad";
        quad.transform.SetParent(display, false);

        quad.transform.localRotation = Quaternion.identity;

        quad.layer = node.gameObject.layer + 999;


        var renderer = quad.GetComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("UI/Default"));
    }
}


public class HairWiggle : MonoBehaviour
{
    private MeshRenderer? renderer;

    private bool Hairinsane;
    private bool Hair;
    private bool Hairproj;
    private bool Hairtower;
    private float t = 0f;
    private long MutantLevel;
    private Vector3[]? baseVerts;

    public bool isMoab;
    public bool isBloon;
    public bool isTower;
    private float h = 0f;
    private float s = 1f;
    private float v = 1f;


    void Awake()
    {
        renderer = GetComponent<MeshRenderer>();


        var mesh = GetComponent<MeshFilter>().mesh;


        var il2cppVerts = mesh.vertices;
        baseVerts = new Vector3[il2cppVerts.Length];

        for (int i = 0; i < il2cppVerts.Length; i++)
        {
            baseVerts[i] = il2cppVerts[i];
        }
    }

    void Update()
    {
        Hairinsane = (bool)HairStylistMod.HairInsane.GetValue();

        MutantLevel = (long)HairStylistMod.MutantLevel.GetValue();

        Hair = (bool)HairStylistMod.Hair.GetValue();
        Hairproj = (bool)HairStylistMod.HairProj.GetValue();
        Hairtower = (bool)HairStylistMod.HairTower.GetValue();


        if (isTower && Hairtower == false)
        {
            Destroy(gameObject);
        }
        if (isMoab && Hair == false)
        {
            Destroy(gameObject);
        }
        if (isBloon && Hair == false)
        {
            Destroy(gameObject);
        }
        if (!isMoab && !isBloon && !isTower && !name.Contains("Pop") && !name.Contains("Explosion") && !name.Contains("Effect") && !name.Contains("Bloon") && Hairproj == false)
        {
            Destroy(gameObject);
        }
        if (name.Contains("Marble") || name.Contains("Spike") && Hairproj == false)
        {
            Destroy(gameObject);
        }


        if (renderer == null)
        {
            return;
        }

        if (Hairinsane == true && MutantLevel > 1)
        {
            renderer.material.mainTexture = HairStylistMod.FullHairTexture;
        }
        else if (Hairinsane == true)
        {
            renderer.material.mainTexture = HairStylistMod.HairInsaneTexture;
        }
        else if (Hairinsane == false)
        {
            renderer.material.mainTexture = HairStylistMod.HairTexture;
        }

        if (isMoab)
        {

            transform.localScale = Vector3.one * 110f * ((MutantLevel + 1f) / 2f);
            Quaternion billboard = Quaternion.LookRotation(Camera.main.transform.forward, Vector3.up);
            transform.rotation = billboard;

            if (MutantLevel > 2)
            {
                
                t += Time.deltaTime;


                float wiggle = Mathf.Sin(t * 4f) * 10f * MutantLevel;
                float spin = t * 20f * MutantLevel;


                Quaternion Spin = Quaternion.Euler(0, 0, wiggle + spin);

                transform.rotation = billboard * Spin;
            }

            transform.Rotate(0, 0, 90, Space.Self);
        }
        else if (isBloon)
        {
            transform.localScale = Vector3.one * 50f * ((MutantLevel + 1f) / 2f);
        }
        else
        {
            transform.localScale = Vector3.one * 75f * ((MutantLevel + 1f) / 2f);
        }


        if (MutantLevel > 2)
        {
            t += Time.deltaTime;


            float wiggle = Mathf.Sin(t * 4f) * 10f * MutantLevel;
            float spin = t * 20f * MutantLevel;


            Quaternion Spin = Quaternion.Euler(0, 0, wiggle + spin);

            if (!isMoab)
            {
                transform.rotation = Spin;
            }

            if (baseVerts == null)
            {
                return;
            }

            var mesh = GetComponent<MeshFilter>().mesh;

            var verts = new Vector3[baseVerts.Length];

            if (MutantLevel > 3)
            {
                float bulge = Mathf.Sin(t * 6f) * 0.6f * (MutantLevel - 3f);

                for (int i = 0; i < baseVerts.Length; i++)
                {
                    float x = baseVerts[i].x;
                    float y = baseVerts[i].y;

                    verts[i] = new Vector3(x * (1f + bulge), y * (1f + bulge * 0.3f), 0f);
                }
            }
            else
            {
                for (int i = 0; i < baseVerts.Length; i++)
                {
                    verts[i] = baseVerts[i];
                }
            }

            mesh.vertices = verts;
            mesh.RecalculateNormals();

            h += Time.deltaTime * 0.1f * MutantLevel; // speed of color change
            if (h > 1f)
            {
                h -= 1f;
            }


            Color rgb = Color.HSVToRGB(h, s, v);


            renderer.material.color = rgb;
        }
    }
}