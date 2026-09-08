using System.Reflection;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Items.Weapons
{
	public class LavaSpewer : ModItem
	{
		public override void SetDefaults() {
            Item.damage = 10;
            Item.DamageType = DamageClass.Magic;
            Item.knockBack = 1f;
			Item.width = 40;
			Item.height = 40;
			Item.UseSound = SoundID.Item71;
            Item.shoot = ModContent.ProjectileType<Projectiles.LavaSpewerProjectile>();
            Item.shootSpeed = 5;
			Item.SetShopValues(ItemRarityColor.LightRed4, 10000);
            Item.mana = 15;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
                .AddIngredient(ItemID.IronBar, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void ModifyManaCost(Player player, ref float reduce, ref float mult) {
			// We can use ModifyManaCost to dynamically adjust the mana cost of this item, similar to how Space Gun works with the Meteor armor set.
			// See ExampleHood to see how accessories give the reduce mana cost effect.
			if (player.statLife < player.statLifeMax2 / 2) {
				mult *= 0.5f; // Half the mana cost when at low health. Make sure to use multiplication with the mult parameter.
			}
		}
	}
}