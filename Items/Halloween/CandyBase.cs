﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Halloween
{
	public abstract class CandyBase : ModItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			if (CanRightClick())
				tooltips.Add(new TooltipLine(mod, "RightclickHint", "Right click to put into Candy Bag"));
		}

		public override bool CanRightClick()
		{
			Item[] inv = Main.player[Main.myPlayer].inventory;
			for (int i = 0; i < 50; i++)
			{
				if (inv[i].IsAir || inv[i].type != CandyBag._type)
					continue;
				if (!((CandyBag)inv[i].modItem).Full)
					return true;
			}
			return false;
		}

		public override void RightClick(Player player)
		{
			Item[] inv = player.inventory;
			for (int i = 0; i < 50; i++)
			{
				if (inv[i].IsAir || inv[i].type != CandyBag._type)
					continue;
				if (((CandyBag)inv[i].modItem).TryAdd(this))
				{
					Main.PlaySound(7, (int)player.position.X, (int)player.position.Y);
					return;
				}
			}
			//No bags with free space found.

			//Needed to counter the default consuption.
			item.stack++;
		}
	}
}