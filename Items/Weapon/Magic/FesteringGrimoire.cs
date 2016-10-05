using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class FesteringGrimoire : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Festering Grimoire";
			item.damage = 38;
			item.magic = true;
			item.mana = 13;
			item.width = 40;
			item.height = 40;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 3;
			item.value = 0200;
			item.rare = 2;
			item.useSound = 20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GrimoireScythe");
			item.shootSpeed = 2f;
		}
	}
}