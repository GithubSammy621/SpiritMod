using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RoguePlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Rogue Plate";
            item.width = 30;
            item.height = 18;
            AddTooltip("Increases Throwing Damage by 5%");
            item.value = 1000;
            item.rare = 2;
            item.defense = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.05f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OldLeather", 1);
            recipe.AddIngredient(ItemID.CopperBar, 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "OldLeather", 1);
            recipe.AddIngredient(ItemID.TinBar, 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}