using SWLOR.Game.Server.Enumeration;
using SWLOR.Game.Server.Quest;

namespace SWLOR.Game.Server.Scripts.Quest.GuildTasks.ArmorsmithGuild
{
    public class HeavyBeltI: AbstractQuest
    {
        public HeavyBeltI()
        {
            CreateQuest(130, "Armorsmith Guild Task: 1x Heavy Belt I", "arm_tsk_130")
                .IsRepeatable()

                .AddObjectiveCollectItem(1, "heavy_belt_1", 1, true)

                .AddRewardGold(85)
                .AddRewardGuildPoints(GuildType.ArmorsmithGuild, 19);
        }
    }
}
