using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	public class ThieveryTome : ModItem
	{
		public override void SetDefaults() {
			// DefaultToStaff handles setting various Item values that magic staff weapons use.
			// Hover over DefaultToStaff in Visual Studio to read the documentation!
			// Shoot a black bolt, also known as the projectile shot from the onyx blaster.
			Item.width = 34;
			Item.height = 40;
			Item.UseSound = SoundID.Item71;

			// A special method that sets the damage, knockback, and bonus critical strike chance.
			// This weapon has a crit of 32% which is added to the players default crit chance of 4%
			Item.SetWeaponValues(10, 20, 5);

			Item.SetShopValues(ItemRarityColor.LightRed4, 10000);
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
	}
}