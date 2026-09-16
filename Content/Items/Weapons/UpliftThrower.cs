using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	// This is an example showing how to create a weapon that fires custom ammunition
	// The most important property is "Item.useAmmo". It tells you which item to use as ammo.
	// You can see the description of other parameters in the ExampleGun class and at https://github.com/tModLoader/tModLoader/wiki/Item-Class-Documentation
	public class UpliftThrower : ModItem
	{
		public override void SetDefaults() {
			Item.width = 40; // The width of item hitbox
			Item.height = 40; // The height of item hitbox

			Item.autoReuse = true;  // Whether or not you can hold click to automatically use it again.
			Item.damage = 35; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			Item.DamageType = DamageClass.Ranged; // What type of damage does this item affect?
			Item.knockBack = 4f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			Item.noMelee = true; // So the item's animation doesn't do damage.
			Item.rare = ItemRarityID.Yellow; // The color that the item's name will be in-game.
			Item.shootSpeed = 10f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAnimation = 5; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			Item.useTime = 5; // The item's use time in ticks (60 ticks == 1 second.)
			Item.UseSound = SoundID.Item34; // The sound that this item plays when used.
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, shoot, etc.)
			Item.value = Item.buyPrice(gold: 2); // The value of the weapon in copper coins
			Item.shoot = ProjectileID.Flames;
			Item.useAmmo = AmmoID.Gel;
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
		private int lastAmmoConsumeTime = 0;
		public override bool CanConsumeAmmo(Item ammo, Player player) {
    		// Main.GameUpdateCount is a timer that goes up by 1 sixty times every second
    		// 90 ticks = 1.5 seconds
    		if (Main.GameUpdateCount - lastAmmoConsumeTime >= 20) {
        		// Save the current time because we are using ammo now
        		lastAmmoConsumeTime = (int)Main.GameUpdateCount;
        		return true; 
    		}

    	// If 1.5 seconds haven't passed, shoot for free!
    	return false; 
		}
	}
}
