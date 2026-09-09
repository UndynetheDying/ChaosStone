using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ChaosStone.Content.Projectiles
{
    public class LavaSpewerProjectile : ModProjectile
    {
        public override void SetDefaults() {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 8;     // Pierces up to 8 enemies like Golden Shower
            Projectile.alpha = 255;       // Hide base texture if using purely dust/particles
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.aiStyle = 0;       // Custom movement for gravity/arch
        }

        public override void AI() {
            // Apply gravity simulation (stream arches downward)
            Projectile.velocity.Y += 0.25f; 

            // Create trailing golden/yellow dust
            if (Main.rand.NextBool(2)) {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GoldFlame, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default, 1.2f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) {
            // Apply a custom debuff or vanilla Ichor debuff (BuffID.Ichor) for defense reduction
            target.AddBuff(BuffID.OnFire, 300); // 5 seconds of Ichor
        }
    }
}
