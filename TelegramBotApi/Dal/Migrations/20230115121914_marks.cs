using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class marks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsersSchedule",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsersInfo",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "UsersSchedule",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "UsersInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UsersMarks",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    point = table.Column<double>(type: "double precision", nullable: false),
                    mark = table.Column<string>(type: "text", nullable: false),
                    UserModelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersMarks", x => x.id);
                    table.ForeignKey(
                        name: "FK_UsersMarks_Users_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersSchedule_UserModelId",
                table: "UsersSchedule",
                column: "UserModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_UserModelId",
                table: "UsersInfo",
                column: "UserModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersMarks_UserModelId",
                table: "UsersMarks",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_Users_UserModelId",
                table: "UsersInfo",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersSchedule_Users_UserModelId",
                table: "UsersSchedule",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersInfo_Users_UserModelId",
                table: "UsersInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersSchedule_Users_UserModelId",
                table: "UsersSchedule");

            migrationBuilder.DropTable(
                name: "UsersMarks");

            migrationBuilder.DropIndex(
                name: "IX_UsersSchedule_UserModelId",
                table: "UsersSchedule");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfo_UserModelId",
                table: "UsersInfo");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "UsersSchedule");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "UsersInfo");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UsersSchedule",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UsersInfo",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");
        }
    }
}
