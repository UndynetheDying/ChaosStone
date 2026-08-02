using ChaosStone.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	public class TheHat : ModItem
	{
		public override void SetDefaults() {
			// Start by using CloneDefaults to clone all the basic item properties from the vanilla Last Prism.
			// For example, this copies sprite size, use style, sell price, and the item being a magic weapon.
			Item.CloneDefaults(ItemID.LastPrism);
			Item.mana = 4;
			Item.damage = 400;
			Item.shoot = ModContent.ProjectileType<Projectiles.MAHLAZER>();
			Item.shootSpeed = 30f;
		}

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.GoldBar, 4)
                .AddIngredient(ItemID.LunarBar, 30)
                .AddIngredient(ItemID.TopHat, 1)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
        }

		// Because this weapon fires a holdout projectile, it needs to block usage if its projectile already exists.
		public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.MAHLAZER>()] <= 0;
		}
	}
}