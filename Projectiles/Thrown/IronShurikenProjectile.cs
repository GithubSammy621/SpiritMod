using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
	public class IronShurikenProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iron Shuriken");

        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Shuriken);        
            projectile.width = 20;
            projectile.height = 20;


        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(25) == 0)
            {
                target.AddBuff(BuffID.BrokenArmor, 200, true);
            }            
        }

        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(0, 4) == 0)
            {
                Terraria.Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("IronShuriken"), 1, false, 0, false, false);
            }
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 8);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }

        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        //{
        //    Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
        //    for (int k = 0; k < projectile.oldPos.Length; k++)
        //    {
        //        Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
        //        Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
        //        spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
        //    }
        //    return true;
        //}
    }
}