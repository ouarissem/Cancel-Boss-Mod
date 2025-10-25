using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CancelBossMod.Items
{
    public class CancelBossItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.rare = ItemRarityID.Green;
            Item.consumable = false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 2);
            recipe.AddIngredient(ItemID.StoneBlock, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override bool? UseItem(Player player)
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && npc.boss)
                {
                    npc.active = false;
                }
            }

            Main.NewText("⚡ Boss cancelled!", 255, 50, 50);
            return true;
        }
    }
}
