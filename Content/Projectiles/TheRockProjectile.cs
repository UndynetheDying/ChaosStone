using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Projectiles
{
	public class TheRockProjectile : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 22;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 600;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0) {
				Projectile.Kill();
			}
			else {
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X) {
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y) {
					Projectile.velocity.Y = -oldVelocity.Y;
				}
				Projectile.velocity *= 0.75f;
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
			}
			return false;
		}

		public override void OnKill(int timeLeft) {
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position); // Play a sound when the projectile dies. In this case, that is when it hits a block or a liquid.

			if (Projectile.owner == Main.myPlayer && !Projectile.noDropItem) {
				int dropItemType = ModContent.ItemType<Items.TheRock>(); // This the item we want the paper airplane to drop.
				int newItem = Item.NewItem(Projectile.GetSource_DropAsItem(), Projectile.Hitbox, dropItemType); // Create a new item in the world.
				Main.item[newItem].noGrabDelay = 0; // Set the new item to be able to be picked up instantly

				// Here we need to make sure the item is synced in multiplayer games.
				if (Main.netMode == NetmodeID.MultiplayerClient && newItem >= 0) {
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, newItem, 1f);
				}
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			Projectile.ai[0] += 0.1f;
			Projectile.velocity *= 0.75f;
		}
	}
}