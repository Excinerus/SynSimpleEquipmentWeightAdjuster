using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim; 
using EquipmentWeightAdjuster;

namespace SynSimpleEquipmentWeightAdjuster
{
    public class Program
    {
        static Lazy<Settings> _LazySettings = null!;
        static Settings Settings => _LazySettings.Value;
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetAutogeneratedSettings(
                    nickname: "Settings",
                    path: "settings.json",
                    out _LazySettings)
                .SetTypicalOpen(GameRelease.SkyrimSE, "SynSimpleEquipmentWeightAdjuster.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            foreach (var m in state.LoadOrder.PriorityOrder.Weapon().WinningOverrides())
            {
                if (m.Data !=null && m.BasicStats !=null && m.BasicStats.Weight > 0.01)
                {
                    var mn = m.DeepCopy();

                    float multiplier = 1;
                    switch (m.Data.AnimationType)
                    {
                        case WeaponAnimationType.HandToHand:
                            break;
                        case WeaponAnimationType.OneHandSword:
                            multiplier = Settings.Sword_1H_WeightMultiplier;
                            break;
                        case WeaponAnimationType.OneHandDagger:
                            multiplier = Settings.Dagger_1H_WeightMultiplier;
                            break;
                        case WeaponAnimationType.OneHandAxe:
                            multiplier = Settings.Axe_1H_WeightMultiplier;
                            break;
                        case WeaponAnimationType.OneHandMace:
                            multiplier = Settings.Mace_1H_WeightMultiplier;
                            break;
                        case WeaponAnimationType.TwoHandSword:
                            multiplier = Settings.Sword_2H_WeightMultiplier;
                            break;
                        case WeaponAnimationType.TwoHandAxe:
                            multiplier = Settings.Other_2H_WeightMultiplier;
                            break;
                        case WeaponAnimationType.Bow:
                            multiplier = Settings.Weapon_Bows_WeightMultiplier;
                            break;
                        case WeaponAnimationType.Staff:
                            multiplier = Settings.Weapon_Staves_WeightMultiplier;
                            break;
                        case WeaponAnimationType.Crossbow:
                            multiplier = Settings.Weapon_xBows_WeightMultiplier;
                            break;
                    }
                    if (multiplier != 1 && mn.BasicStats!=null)
                    {
                        mn.BasicStats.Weight *= multiplier;
                        state.PatchMod.Weapons.Set(mn);
                    }
                }
            }
            foreach (var m in state.LoadOrder.PriorityOrder.Armor().WinningOverrides())
            {
                var mn = m.DeepCopy();
                if (m.Weight > 0 && m.BodyTemplate != null && m.BodyTemplate.FirstPersonFlags.HasFlag(BipedObjectFlag.Shield))
                {
                    switch (m.BodyTemplate.ArmorType)
                    {
                        case ArmorType.LightArmor:
                            mn.Weight *= Settings.Shield_Light_WeightMultiplier;
                            break;
                        case ArmorType.HeavyArmor:

                            mn.Weight *= Settings.Shield_Heavy_WeightMultiplier;
                            break;
                    }
                    state.PatchMod.Armors.Set(mn);
                }

            }
        }
    }
}

