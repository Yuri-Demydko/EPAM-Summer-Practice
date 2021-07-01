using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDAO.Migrations
{
    public partial class init02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_UserProfiles_EFUserProfileId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_UserProfiles_EFUserProfileId1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_EFUserProfileId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "EFUserProfileId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "EFUserProfileId1",
                table: "Books",
                newName: "EUserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_EFUserProfileId1",
                table: "Books",
                newName: "IX_Books_EUserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_UserProfiles_EUserProfileId",
                table: "Books",
                column: "EUserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_UserProfiles_EUserProfileId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "EUserProfileId",
                table: "Books",
                newName: "EFUserProfileId1");

            migrationBuilder.RenameIndex(
                name: "IX_Books_EUserProfileId",
                table: "Books",
                newName: "IX_Books_EFUserProfileId1");

            migrationBuilder.AddColumn<int>(
                name: "EFUserProfileId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_EFUserProfileId",
                table: "Books",
                column: "EFUserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_UserProfiles_EFUserProfileId",
                table: "Books",
                column: "EFUserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_UserProfiles_EFUserProfileId1",
                table: "Books",
                column: "EFUserProfileId1",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
