using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{ 
	// This is a basic item template.
	// Please see tModLoader's ExampleMod for every other example:
	// https://github.com/tModLoader/tModLoader/tree/stable/ExampleMod
	public class Obsitana : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.ChaosStone.hjson' file.
		public override void SetDefaults()
		{
			Item.damage = 15;
			Item.DamageType = DamageClass.Melee;
			Item.width = 100;
			Item.height = 100;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(silver: 10);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.DD2PhoenixBowShot;
			Item.shootSpeed = 10;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.HellstoneBar, 5)
				.AddIngredient(ItemID.Obsidian, 50)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
