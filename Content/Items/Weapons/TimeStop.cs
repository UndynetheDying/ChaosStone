using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Threading;

namespace ChaosStone.Content.Items.Weapons
{
	public class TimeStop : ModItem
	{
		public override void SetDefaults() {
			// Modders can use Item.DefaultToRangedWeapon to quickly set many common properties, such as: useTime, useAnimation, useStyle, autoReuse, DamageType, shoot, shootSpeed, useAmmo, and noMelee. These are all shown individually here for teaching purposes.

			// Common Properties
			Item.width = 32; // Hitbox width of the item.
			Item.height = 32; // Hitbox height of the item.
			Item.rare = ItemRarityID.Red; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 55; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 55; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
			Item.UseSound = SoundID.NPCHit27; // The sound that this item plays when used.
		}
        public override bool? UseItem(Player player)
        {
            Main.NewText("Stopping time for roughly a minute...");
            Thread.Sleep(60001);
            return null;
        }
    }
}