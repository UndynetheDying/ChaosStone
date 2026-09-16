using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
     
namespace ChaosStone.Content.Buffs
{
    public class UpliftDebuff : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex) {
        }
    }
}