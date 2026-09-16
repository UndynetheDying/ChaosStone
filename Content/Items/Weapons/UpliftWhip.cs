using ChaosStone.Content.Buffs;
using ChaosStone.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	public class UpliftWhip : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(UpliftWhipDebuff.TagDamage);

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<UpliftWhipProjectile>(), 60, 2, 4);
			Item.rare = ItemRarityID.Green;
			Item.channel = true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Cloud, 30)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}

        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override bool? UseItem(Player player) {
                // Check if this specific use action is the right-click
            if (player.altFunctionUse == 2)
            {
				if (!player.HasBuff(ModContent.BuffType<Buffs.UpliftDebuff>())) {
					// A negative Y value moves the player UPWARD.
					// -15f is a sharp jump. Adjust this value to change the intensity.
					player.velocity.Y = -15f; 
					player.AddBuff(ModContent.BuffType<Buffs.UpliftDebuff>(), 180); // 3 seconds

					if (Main.netMode == NetmodeID.MultiplayerClient)
					{
							NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
					}
				}
            }
            return true;
        }

		// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}
	}
}