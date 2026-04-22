using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Simulation.SMath;

namespace HairStylistMonkey.Displays.Projectiles
{
    public class HairStylistMonkeyBaseDisplay : ModTowerDisplay<HairStylistMonkey>
    {
        public override string Name => "HairStylistMonkeyBaseDisplay";
        public override string BaseDisplay => Generic2dDisplay;
        public override bool UseForTower(int[] tiers)
        {
            return !IsParagon(tiers) && tiers[2] != 5;
        }
        public override Vector3 PositionOffset => new Vector3(0, 0, 15);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Monkey");
        }
    }

    public class HairStylistMonkeyParagonDisplay : ModTowerDisplay<HairStylistMonkey>
    {
        public override string Name => "HairStylistMonkeyParagonDisplay";
        public override string BaseDisplay => Generic2dDisplay;
        public override bool UseForTower(int[] tiers)
        {
            return IsParagon(tiers);
        }
        public override Vector3 PositionOffset => new Vector3(0, 0, 15);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "ParaTower");
        }
    }
    public class HairStylistMonkeyDemonDisplay : ModTowerDisplay<HairStylistMonkey>
    {
        public override string Name => "HairStylistMonkeyDemonDisplay";
        public override string BaseDisplay => Generic2dDisplay;
        public override bool UseForTower(int[] tiers)
        {
            return !IsParagon(tiers) && tiers[2] == 5;
        }
        public override Vector3 PositionOffset => new Vector3(0, 0, 15);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "DemonTower");
        }
    } 
}
