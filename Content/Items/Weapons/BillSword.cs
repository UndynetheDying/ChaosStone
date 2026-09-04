using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	public class BillSword : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 15;
			Item.knockBack = 4f;
			Item.useStyle = ItemUseStyleID.Rapier; // Makes the player do the proper arm motion
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.DamageType = DamageClass.MeleeNoSpeed;
			Item.autoReuse = false;
			Item.noUseGraphic = true; // The sword is actually a "projectile", so the item should not be visible when used
			Item.noMelee = true; // The projectile will do the damage and not the item

			Item.rare = ItemRarityID.White;
			Item.value = Item.sellPrice(0, 0, 0, 10);
		}

		// Since this weapon is a projectile (uses noUseGraphic), it isn't naturally considered a melee weapon for the purposes of prefixes. This allows the expected prefixes to be applied.
		public override bool MeleePrefix() => true;

		/* Here is an example of using ApplyPrefix to apply item-specific tweaks to a specific prefix.
		public override void ApplyPrefix(int pre) {
			if(pre == PrefixID.Agile) {
				Item.crit += 10;
			}
		}
		*/

		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.IronBar, 5)
                .AddIngredient(ItemID.CopperShortsword, 1)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}