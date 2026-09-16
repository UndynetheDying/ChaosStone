using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ChaosStone.Content.Buffs;

namespace ChaosStone.Content.Items.Weapons
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class UpliftBlade : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.ChaosStone.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 70;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 10);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.SnowBallFriendly;
			Item.shootSpeed = 20;
		}

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
				if (!player.HasBuff(ModContent.BuffType<UpliftDebuff>())) {
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
