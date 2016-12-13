﻿using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class BloodfireStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bloodfire Staff";
            item.width = 28;
            item.height = 28;
            item.value = 10000;
            item.rare = 6;

            item.crit = 4;
            item.mana = 9;
            item.damage = 17;
            item.knockBack = 3;

            item.useStyle = 5;
            item.useTime = 27;
            item.useAnimation = 27;

            item.magic = true;
            item.noMelee = true;
            item.autoReuse = false;
            Item.staff[item.type] = true;

            item.shoot = mod.ProjectileType("BloodClump");
            item.shootSpeed = 8f;

            item.useSound = 20;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BloodFire", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
