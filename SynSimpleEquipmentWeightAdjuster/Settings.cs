using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mutagen.Bethesda.Synthesis.Settings;

namespace EquipmentWeightAdjuster
{
    public record Settings
    {
        [SynthesisOrder]
        [SynthesisSettingName("Daggers Weight Multiplier, Default: 0.4")]
        public float Dagger_1H_WeightMultiplier = 0.4f;

        [SynthesisSettingName("One Handed Swords Weight Multiplier, Default: 0.4")]
        public float Sword_1H_WeightMultiplier = 0.4f;

        [SynthesisSettingName("One Handed Axes Weight Multiplier, Default: 0.4")]
        public float Axe_1H_WeightMultiplier = 0.4f;

        [SynthesisSettingName("One Handed Maces Weight Multiplier, Default: 0.4")]
        public float Mace_1H_WeightMultiplier = 0.4f;



        [SynthesisSettingName("Two Handed Swords Weight Multiplier, Default: 0.4")]
        public float Sword_2H_WeightMultiplier = 0.4f;

        [SynthesisSettingName("Two Handed Axes and Maces Weight Multiplier, Default: 0.4")]
        public float Other_2H_WeightMultiplier = 0.4f;

        [SynthesisSettingName("Bows Weight Multiplier, Default: 0.4")]
        public float Weapon_Bows_WeightMultiplier = 0.4f;
        [SynthesisSettingName("Crossbows Weight Multiplier, Default: 0.6")]
        public float Weapon_xBows_WeightMultiplier = 0.6f;
        [SynthesisSettingName("Staves Weight Multiplier, Default: 0.8")]
        public float Weapon_Staves_WeightMultiplier = 0.8f;
        [SynthesisSettingName("Shield Weight Multiplier, Default: 0.8")]
        public float Shield_Light_WeightMultiplier = 0.8f;
        [SynthesisSettingName("Shield Weight Multiplier, Default: 0.75")]
        public float Shield_Heavy_WeightMultiplier = 0.75f;
    }
}
