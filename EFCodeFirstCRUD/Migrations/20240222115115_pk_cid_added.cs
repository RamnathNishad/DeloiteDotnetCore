using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCodeFirstCRUD.Migrations
{
    /// <inheritdoc />
    public partial class pk_cid_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Customers",
                newName: "Cid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cid",
                table: "Customers",
                newName: "CustomerId");
        }
    }
}
