﻿using System;
using SWLOR.Game.Server.Legacy.GameObject;
using SWLOR.Game.Server.Legacy.Mod.Contracts;

namespace SWLOR.Game.Server.Legacy.Mod
{
    public class LuckMod: IModHandler
    {
        public int ModTypeID => 21;
        private const int MaxValue = 5;

        public string CanApply(NWPlayer player, NWItem target, params string[] args)
        {
            if (target.LuckBonus >= MaxValue)
                return "You cannot improve that item's luck bonus any further.";

            return null;
        }

        public void Apply(NWPlayer player, NWItem target, params string[] args)
        {
            var value = Convert.ToInt32(args[0]);
            var newValue = target.LuckBonus + value;
            if (newValue > MaxValue) newValue = MaxValue;
            target.LuckBonus = newValue;
        }

        public string Description(NWPlayer player, NWItem target, params string[] args)
        {
            var value = Convert.ToInt32(args[0]);
            return "Luck +" + value;
        }
    }
}