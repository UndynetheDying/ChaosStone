using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class PreHardmodeArc : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.ChaosStone.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 1000;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 10);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.IronBar, 2)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
