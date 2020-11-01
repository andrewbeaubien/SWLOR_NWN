using SWLOR.Game.Server.Legacy.Enumeration;
using SWLOR.Game.Server.Legacy.Quest;

namespace SWLOR.Game.Server.Legacy.Scripts.Quest.GuildTasks.WeaponsmithGuild
{
    public class FinesseVibrobladeR1: AbstractQuest
    {
        public FinesseVibrobladeR1()
        {
            CreateQuest(255, "Weaponsmith Guild Task: 1x Finesse Vibroblade R1", "wpn_tsk_255")
                .IsRepeatable()

                .AddObjectiveCollectItem(1, "rapier_1", 1, true)

                .AddRewardGold(85)
                .AddRewardGuildPoints(GuildType.WeaponsmithGuild, 19);
        }
    }
}