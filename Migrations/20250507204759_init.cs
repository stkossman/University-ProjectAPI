using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dota2API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PrimaryAttribute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttackType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseHealth = table.Column<int>(type: "int", nullable: false),
                    BaseMana = table.Column<int>(type: "int", nullable: false),
                    BaseArmor = table.Column<float>(type: "real", nullable: false),
                    MoveSpeed = table.Column<int>(type: "int", nullable: false),
                    BaseAttackMin = table.Column<float>(type: "real", nullable: false),
                    BaseAttackMax = table.Column<float>(type: "real", nullable: false),
                    BaseStrength = table.Column<int>(type: "int", nullable: false),
                    StrengthGain = table.Column<float>(type: "real", nullable: false),
                    BaseAgility = table.Column<int>(type: "int", nullable: false),
                    AgilityGain = table.Column<float>(type: "real", nullable: false),
                    BaseIntelligence = table.Column<int>(type: "int", nullable: false),
                    IntelligenceGain = table.Column<float>(type: "real", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    IsRecipe = table.Column<bool>(type: "bit", nullable: false),
                    ShopTags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attributes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocalizedName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Affects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Damage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManaCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cooldown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "AgilityGain", "AttackType", "BaseAgility", "BaseArmor", "BaseAttackMax", "BaseAttackMin", "BaseHealth", "BaseIntelligence", "BaseMana", "BaseStrength", "ImageUrl", "IntelligenceGain", "LocalizedName", "MoveSpeed", "Name", "PrimaryAttribute", "Roles", "StrengthGain" },
                values: new object[] { 1, 2.8f, "Melee", 24, 0f, 33f, 29f, 200, 12, 75, 23, "https://api.opendota.com/apps/dota2/images/heroes/antimage_full.png", 1.8f, "Anti-Mage", 310, "anti-mage", "Agi", "Carry,Escape,Nuker", 1.3f });

            migrationBuilder.InsertData(
                table: "Abilities",
                columns: new[] { "Id", "AbilityType", "Affects", "Cooldown", "Damage", "Description", "HeroId", "ImageUrl", "LocalizedName", "ManaCost", "Name" },
                values: new object[,]
                {
                    { 1, "Passive", "Enemy Heroes", "0", "Physical", "Burns an opponent's mana on each attack and deals damage equal to a percentage of the mana burned.", 1, "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_mana_break.png", "Mana Break", "0", "mana_break" },
                    { 2, "Active", "Self", "15/12/9/6", "None", "Short distance teleportation that allows Anti-Mage to move in and out of combat.", 1, "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_blink.png", "Blink", "60", "blink" },
                    { 3, "Active", "Self", "15/11/7/3", "None", "Passively grants magic resistance. When activated, creates an anti-magic shell around Anti-Mage that reflects targeted spells.", 1, "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_counterspell.png", "Counterspell", "45/50/55/60", "counterspell" },
                    { 4, "Active", "Enemy Units", "70", "Magical", "Creates a violent ripple in space that drains mana and deals damage to enemies near the target based on their missing mana.", 1, "https://cdn.cloudflare.steamstatic.com/apps/dota2/images/dota_react/abilities/antimage_mana_void.png", "Mana Void", "100/200/300", "mana_void" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_HeroId",
                table: "Abilities",
                column: "HeroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
