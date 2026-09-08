using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosStone.Content.Projectiles
{
	public class LavaSpewerProjectile : ModProjectile
	{
		public override void SetDefaults() {
			Projectile.width = 5; // The width of projectile hitbox
			Projectile.height = 5; // The height of projectile hitbox

			// Copy the ai of any given projectile using AIType, since we want
			// the projectile to essentially behave the same way as the vanilla projectile.
			Projectile.aiStyle = ProjAIStyleID.GoldenShowerFriendly;
			aiType = ProjectileID.GoldenShowerFrie;

			Projectile.friendly = true; // Can the projectile deal damage to enemies?
			Projectile.DamageType = DamageClass.Magic; // Is the projectile shoot by a ranged weapon?
			Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
			Projectile.tileCollide = false; // Can the projectile collide with tiles?
			Projectile.timeLeft = 60; // Each update timeLeft is decreased by 1. Once timeLeft hits 0, the Projectile will naturally despawn. (60 ticks = 1 second)

			Projectile.penetrate = -1;
			// 1: Projectile.penetrate = 1; // Will hit even if npc is currently immune to player
			// 2a: Projectile.penetrate = -1; // Will hit and unless 3 is use, set 10 ticks of immunity
			// 2b: Projectile.penetrate = 3; // Same, but max 3 hits before dying
			// 5: Projectile.usesLocalNPCImmunity = true;
			// 5a: Projectile.localNPCHitCooldown = -1; // 1 hit per npc max
			// 5b: Projectile.localNPCHitCooldown = 20; // 20 ticks before the same npc can be hit again
		}

		// See comments at the beginning of the class
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
			// 3a: target.immune[Projectile.owner] = 20;
			// 3b: target.immune[Projectile.owner] = 5;
		}
	}
}