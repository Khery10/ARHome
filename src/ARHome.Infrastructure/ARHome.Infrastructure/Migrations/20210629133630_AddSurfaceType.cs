using ARHome.Core.Categories;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ARHome.Infrastructure.Migrations
{
    public partial class AddSurfaceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<SurfaceTypeCode>(
                name: "SurfaceType",
                table: "Categories",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SurfaceType",
                table: "Categories");
        }
    }
}
