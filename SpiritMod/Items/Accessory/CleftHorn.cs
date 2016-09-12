using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class CleftHorn : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cleft Horn";
			item.toolTip = "+4% melee damage and crit chance";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeCrit += 4;
			player.meleeDamage += 0.04f;
		}
	}
}
