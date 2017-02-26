using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class GrassVine : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Droseran Trapper";
            npc.displayName = "Droseran Trapper";
            npc.width = 34;
            npc.height = 32;
            npc.damage = 23;
            npc.defense = 6;
            npc.lifeMax = 55;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 360f;
            npc.knockBackResist = .1f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = 4;
        }
        public override void AI()
        {
            {
                npc.spriteDirection = npc.direction;
            }
            Player target = Main.player[npc.target];
            int distance = (int)Math.Sqrt((npc.Center.X - target.Center.X) * (npc.Center.X - target.Center.X) + (npc.Center.Y - target.Center.Y) * (npc.Center.Y - target.Center.Y));
            if (distance < 600)
            {
                npc.ai[0]++;
                if (npc.ai[0] >= 120)
                {
                    int type = ProjectileID.PoisonSeedPlantera;
                    int p = Terraria.Projectile.NewProjectile(npc.position.X, npc.position.Y, -(npc.position.X - target.position.X) / distance * 4, -(npc.position.Y - target.position.Y) / distance * 4, type, (int)((npc.damage * .5)), 0);
                    Main.projectile[p].friendly = false;
                    Main.projectile[p].hostile = true;
                    npc.ai[0] = 0;
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneReach && !Main.dayTime ? 6f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LeafGreen"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LeafGreen"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/LeafHead"), 1f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 180);
        }
    }
}
