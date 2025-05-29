using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
   /// <inheritdoc />
   public partial class CreateCartDatabaseAndChangeIdToInt : Migration
   {
      /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
      {
         migrationBuilder.Sql("DROP TABLE IF EXISTS \"Users\";");
         migrationBuilder.Sql("DROP TABLE IF EXISTS \"Products\";");
         migrationBuilder.Sql("DROP TABLE IF EXISTS \"Carts\";");

         migrationBuilder.CreateTable(
             name: "Users",
             columns: table => new
             {
                Id = table.Column<int>(type: "integer", nullable: false)
                     .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_Users", x => x.Id);
             });

         migrationBuilder.CreateTable(
             name: "Products",
             columns: table => new
             {
                Id = table.Column<int>(type: "integer", nullable: false)
                     .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                Title = table.Column<string>(type: "text", nullable: false),
                Description = table.Column<string>(type: "text", nullable: false),
                Price = table.Column<decimal>(type: "numeric", nullable: false),
                Category = table.Column<string>(type: "text", nullable: false),
                Image = table.Column<string>(type: "text", nullable: false),
                RatingRate = table.Column<double>(type: "double precision", nullable: true),
                RatingCount = table.Column<int>(type: "integer", nullable: true),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_Products", x => x.Id);
             });

         migrationBuilder.CreateTable(
             name: "Carts",
             columns: table => new
             {
                Id = table.Column<int>(type: "integer", nullable: false)
                     .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                UserId = table.Column<int>(type: "integer", nullable: false),
                Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_Carts", x => x.Id);
             });
             
         migrationBuilder.CreateTable(
             name: "CartProduct",
             columns: table => new
             {
                Id = table.Column<int>(type: "integer", nullable: false)
                     .Annotation("Npgsql:ValueGenerationStrategy", Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                ProductId = table.Column<int>(type: "integer", nullable: false),
                Quantity = table.Column<int>(type: "integer", nullable: false),
                CartId = table.Column<int>(type: "integer", nullable: false)
             },
             constraints: table =>
             {
                table.PrimaryKey("PK_CartProduct", x => x.Id);
                table.ForeignKey(
                    name: "FK_CartProduct_Carts_CartId",
                    column: x => x.CartId,
                    principalTable: "Carts",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
             });

         migrationBuilder.CreateIndex(
             name: "IX_CartProduct_CartId",
             table: "CartProduct",
             column: "CartId");
         // ...existing code...
      }

      /// <inheritdoc />
      protected override void Down(MigrationBuilder migrationBuilder)
      {

      }
   }
}
