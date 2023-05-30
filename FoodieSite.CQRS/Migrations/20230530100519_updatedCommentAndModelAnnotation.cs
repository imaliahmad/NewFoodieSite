using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodieSite.CQRS.Migrations
{
    public partial class updatedCommentAndModelAnnotation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreMaster_RestaurantMaster_RestaurantId",
                table: "StoreMaster");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StoreMaster",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "StoreMaster",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "StoreMaster",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "StoreMaster",
                newName: "restaurant_id");

            migrationBuilder.RenameColumn(
                name: "ContactNumber2",
                table: "StoreMaster",
                newName: "contact_number_2");

            migrationBuilder.RenameColumn(
                name: "ContactNumber1",
                table: "StoreMaster",
                newName: "contact_number_1");

            migrationBuilder.RenameIndex(
                name: "IX_StoreMaster_RestaurantId",
                table: "StoreMaster",
                newName: "IX_StoreMaster_restaurant_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RestaurantMaster",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "RestaurantMaster",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "RestaurantMaster",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "RestaurantMaster",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "RestaurantCode",
                table: "RestaurantMaster",
                newName: "restaurant_code");

            migrationBuilder.RenameColumn(
                name: "ContactNumber2",
                table: "RestaurantMaster",
                newName: "contact_number_2");

            migrationBuilder.RenameColumn(
                name: "ContactNumber1",
                table: "RestaurantMaster",
                newName: "contact_number_1");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "StoreMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "StoreMaster",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "StoreMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "contact_number_2",
                table: "StoreMaster",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "contact_number_1",
                table: "StoreMaster",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "RestaurantMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "RestaurantMaster",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "RestaurantMaster",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "restaurant_code",
                table: "RestaurantMaster",
                type: "nvarchar(350)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "contact_number_2",
                table: "RestaurantMaster",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "contact_number_1",
                table: "RestaurantMaster",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreMaster_RestaurantMaster_restaurant_id",
                table: "StoreMaster",
                column: "restaurant_id",
                principalTable: "RestaurantMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreMaster_RestaurantMaster_restaurant_id",
                table: "StoreMaster");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "StoreMaster",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "StoreMaster",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "StoreMaster",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "restaurant_id",
                table: "StoreMaster",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "contact_number_2",
                table: "StoreMaster",
                newName: "ContactNumber2");

            migrationBuilder.RenameColumn(
                name: "contact_number_1",
                table: "StoreMaster",
                newName: "ContactNumber1");

            migrationBuilder.RenameIndex(
                name: "IX_StoreMaster_restaurant_id",
                table: "StoreMaster",
                newName: "IX_StoreMaster_RestaurantId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "RestaurantMaster",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "RestaurantMaster",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "RestaurantMaster",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "RestaurantMaster",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "restaurant_code",
                table: "RestaurantMaster",
                newName: "RestaurantCode");

            migrationBuilder.RenameColumn(
                name: "contact_number_2",
                table: "RestaurantMaster",
                newName: "ContactNumber2");

            migrationBuilder.RenameColumn(
                name: "contact_number_1",
                table: "RestaurantMaster",
                newName: "ContactNumber1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "StoreMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "StoreMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "StoreMaster",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber2",
                table: "StoreMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber1",
                table: "StoreMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RestaurantMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "RestaurantMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "RestaurantMaster",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantCode",
                table: "RestaurantMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber2",
                table: "RestaurantMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber1",
                table: "RestaurantMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreMaster_RestaurantMaster_RestaurantId",
                table: "StoreMaster",
                column: "RestaurantId",
                principalTable: "RestaurantMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
