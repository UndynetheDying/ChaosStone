using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	public class UpliftTome : ModItem
	{
		public override void SetDefaults() {
			Item.width = 34;
			Item.height = 40;
			Item.UseSound = SoundID.Item71;
			Item.SetShopValues(ItemRarityColor.LightRed4, 10000);
			Item.damage = 70;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.shoot = ProjectileID.SnowBallFriendly;
			Item.shootSpeed = 20;
			Item.mana = 15;
			Item.useStyle = ItemUseStyleID.Shoot;
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