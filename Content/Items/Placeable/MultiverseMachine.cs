using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Placeable
{
	public class MultiverseMachine : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.MultiverseMachine>());
			Item.width = 38;
			Item.height = 24;
			Item.value = 150;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<TheParticle>(3)
                .AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}