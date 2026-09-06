using ChaosStone.Content.Buffs;
using ChaosStone.Content.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	public class OrderWhip : ModItem
	{
		public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(OrderWhipDebuff.TagDamage);

		public override void SetDefaults() {
			// This method quickly sets the whip's properties.
			// Mouse over to see its parameters.
			Item.DefaultToWhip(ModContent.ProjectileType<OrderWhipProjectile>(), 20, 2, 4);
			Item.rare = ItemRarityID.Green;
			Item.channel = true;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.DemoniteBar, 25)
				.AddTile(TileID.DemonAltar)
				.Register();
			CreateRecipe()
				.AddIngredient(ItemID.CrimtaneBar, 25)
				.AddTile(TileID.DemonAltar)
				.Register();
		}

		// Makes the whip receive melee prefixes
		public override bool MeleePrefix() {
			return true;
		}
	}
}