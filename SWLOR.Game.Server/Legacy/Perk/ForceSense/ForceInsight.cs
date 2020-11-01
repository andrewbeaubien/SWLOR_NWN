﻿using System;
using System.Linq;
using SWLOR.Game.Server.Core.NWScript;
using SWLOR.Game.Server.Core.NWScript.Enum;
using SWLOR.Game.Server.Core.NWScript.Enum.VisualEffect;
using SWLOR.Game.Server.Legacy.GameObject;
using SWLOR.Game.Server.Legacy.Service;
using PerkType = SWLOR.Game.Server.Legacy.Enumeration.PerkType;
using SkillType = SWLOR.Game.Server.Legacy.Enumeration.SkillType;

namespace SWLOR.Game.Server.Legacy.Perk.ForceSense
{
    public class ForceInsight : IPerkHandler
    {
        public PerkType PerkType => PerkType.ForceInsight;
        public string CanCastSpell(NWCreature oPC, NWObject oTarget, int spellTier)
        {
            return string.Empty;
        }

        public int FPCost(NWCreature oPC, int baseFPCost, int spellTier)
        {
            return baseFPCost;
        }

        public float CastingTime(NWCreature oPC, float baseCastingTime, int spellTier)
        {
            return baseCastingTime;
        }

        public float CooldownTime(NWCreature oPC, float baseCooldownTime, int spellTier)
        {
            return baseCooldownTime;
        }

        public int? CooldownCategoryID(NWCreature creature, int? baseCooldownCategoryID, int spellTier)
        {
            return baseCooldownCategoryID;
        }

        public void OnImpact(NWCreature creature, NWObject target, int perkLevel, int spellTier)
        {
        }

        public void OnPurchased(NWCreature creature, int newLevel)
        {
        }

        public void OnRemoved(NWCreature creature)
        {
        }

        public void OnItemEquipped(NWCreature creature, NWItem oItem)
        {
        }

        public void OnItemUnequipped(NWCreature creature, NWItem oItem)
        {
        }

        public void OnCustomEnmityRule(NWCreature creature, int amount)
        {
        }

        public bool IsHostile()
        {
            return false;
        }

        public void OnConcentrationTick(NWCreature creature, NWObject target, int perkLevel, int tick)
        {
            int abamount;
            int acamount;

            // Handle effects for differing spellTier values
            switch (perkLevel)
            {
                case 1:
                    abamount = 3;
                    acamount = 0;
                    break;
                case 2:
                    abamount = 5;
                    acamount = 2;
                    break;
                case 3:
                    abamount = 5;
                    acamount = 4;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(perkLevel));
            }

            var effect = NWScript.EffectACIncrease(acamount);
            effect = NWScript.EffectLinkEffects(effect, NWScript.EffectAttackIncrease(abamount));
            effect = NWScript.TagEffect(effect, "EFFECT_FORCE_INSIGHT");

            // Remove any existing force insight effects.
            foreach(var existing in creature.Effects.Where(x => NWScript.GetEffectTag(x) == "EFFECT_FORCE_INSIGHT"))
            {
                NWScript.RemoveEffect(creature, existing);
            }
            
            // Apply the new effect.
            NWScript.ApplyEffectToObject(DurationType.Temporary, effect, creature, 6.1f);
            NWScript.ApplyEffectToObject(DurationType.Instant, NWScript.EffectVisualEffect(VisualEffect.Vfx_Dur_Magic_Resistance), target);

            // Register players to all combat targets for Force Sense.
            if (creature.IsPlayer)
            {
                SkillService.RegisterPCToAllCombatTargetsForSkill(creature.Object, SkillType.ForceSense, null);
            }

            EnmityService.AdjustEnmityOnAllTaggedCreatures(creature, 4);
        }
    }
}