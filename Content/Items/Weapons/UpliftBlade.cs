using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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

        // 2. Adjust stats when right-clicking (Optional)
        public override bool CanUseItem(Player player) {
            if (player.altFunctionUse == 2)
            {
                // Settings specific to the right-click function
                Item.useTime = 70;
                Item.useAnimation = 70;
            }
            else
            {
                // Reset to default settings for left-click
                Item.useTime = 20;
                Item.useAnimation = 20;
            }
            return true;
        }

        // 3. Apply the sharp upward velocity
        public override bool? UseItem(Player player) {
            // Check if this specific use action is the right-click
            if (player.altFunctionUse == 2)
            {
                // A negative Y value moves the player UPWARD.
                // -15f is a sharp jump. Adjust this value to change the intensity.
                player.velocity.Y = -15f; 

                // Optional: Sync the movement in multiplayer worlds
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    NetMessage.SendData(MessageID.PlayerControls, number: player.whoAmI);
                }
            }
            return true;
        }
	}
}
