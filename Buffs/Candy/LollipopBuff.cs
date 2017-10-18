using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Candy
{
	public class LollipopBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Lollipop");
			Description.SetDefault("Increased life regeneration");

			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.lifeRegen += 2;
		}
	}
}