using SWLOR.Game.Server.Legacy.Enumeration;
using SWLOR.Game.Server.Legacy.Quest;

namespace SWLOR.Game.Server.Legacy.Scripts.Quest.GuildTasks.ArmorsmithGuild
{
    public class ForceBeltII: AbstractQuest
    {
        public ForceBeltII()
        {
            CreateQuest(147, "Armorsmith Guild Task: 1x Force Belt II", "arm_tsk_147")
                .IsRepeatable()

                .AddObjectiveCollectItem(1, "force_belt_2", 1, true)

                .AddRewardGold(185)
                .AddRewardGuildPoints(GuildType.ArmorsmithGuild, 39);
        }
    }
}