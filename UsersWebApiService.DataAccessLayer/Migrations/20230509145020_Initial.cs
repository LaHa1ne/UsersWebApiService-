using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UsersWebApiService.DataAccessLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:group_code", "admin,user")
                .Annotation("Npgsql:Enum:state_code", "active,blocked");

            migrationBuilder.CreateTable(
                name: "user_groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_states",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_states", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Created_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    User_group_id = table.Column<int>(type: "integer", nullable: false),
                    User_state_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_user_groups_User_group_id",
                        column: x => x.User_group_id,
                        principalTable: "user_groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_users_user_states_User_state_id",
                        column: x => x.User_state_id,
                        principalTable: "user_states",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "user_groups",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Администратор" },
                    { 2, 2, "Пользователь" }
                });

            migrationBuilder.InsertData(
                table: "user_states",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, 1, "Активный" },
                    { 2, 2, "Заблокированный" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Created_date", "Login", "Password", "User_group_id", "User_state_id" },
                values: new object[,]
                {
                    { new Guid("0f39e34d-932f-46da-a18a-5bdf01d1b066"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7900), "Mary", "aebac53c46bbeff10fdd26ca0e2196a9bfc1d19bf88eb1efd65a36151c581051", 2, 2 },
                    { new Guid("11258619-a353-4e33-b2cb-b59aecf86dcf"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9563), "Thomas", "5dfcf9ef1fb1ecbce32fefe37ae99aff68832a7e2ac74f52daa5a1bcd8038118", 2, 1 },
                    { new Guid("1c812204-0548-4d26-b7f9-e0ed2a3634c7"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9598), "George", "3d28271ec52e3d07fe14f5f16d01f2c09cbcac1949f9904b305136d0edbee12d", 2, 1 },
                    { new Guid("579ab6eb-ee4d-4826-a10a-87c246d3ac22"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7946), "Jane", "4f23798d92708359b734a18172c9c864f1d48044a754115a0d4b843bca3a5332", 2, 1 },
                    { new Guid("6c0b000d-1ba5-484a-ab59-7245a989697b"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9240), "Wendy", "966b04e1166554524d9f310d3b0a7759ce74ce202fe04a9a51cd06fdc732d7fe", 2, 1 },
                    { new Guid("988d00ed-66e7-4436-acbe-d506eb533486"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9213), "Ann", "17239b6e250110330eda64a29c610bf146f89883371fab093feda03bec61b646", 2, 1 },
                    { new Guid("9bdcdbbc-5eb1-41e8-bc0d-4cf6cd2ee8a2"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(8346), "Jesse", "1ecb9e6bdf6cc8088693c11e366415fe5c73662ecdf08f3df337924d8ea26adc", 2, 2 },
                    { new Guid("9d82c7c4-88e4-4b8c-a4b6-af354051c805"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9262), "Gwen", "0fded9fb37b9359e8e8ee8554f48acd12d762591738b1748db0e9231a0ff6588", 2, 2 },
                    { new Guid("aed5f9f4-4db2-4089-be24-0523422e0bfd"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9312), "Oliver", "7efa869d0364eea0cd0106a2ef4d1ae9eaec58fe62928c3f1af8fa8da9204ea0", 2, 1 },
                    { new Guid("b0f7176f-8d78-436d-9e17-939f5caadf59"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9290), "Joan", "2d0f4c4eb78ce93adc09b60c696c76d0476185983c956a6f2a5bbf0afb9dbc2e", 2, 1 },
                    { new Guid("c1f34963-e5d7-47d6-b020-6dd99a27ea5a"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7924), "John", "a8cfcd74832004951b4408cdb0a5dbcd8c7e52d43f7fe244bf720582e05241da", 2, 1 },
                    { new Guid("c7607558-68f5-4429-b316-d59bbe78a0bc"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7859), "Alex", "db74c940d447e877d119df613edd2700c4a84cd1cf08beb7cbc319bcfaeab97a", 2, 1 },
                    { new Guid("dd93ad85-ff05-4bf9-88d8-0c005659645c"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9101), "Kate", "1a5d06a170dde413475957ca2b63396aa5e8fbecb7d379fcb668da3753fca5b6", 2, 1 },
                    { new Guid("ec85e537-ba8b-411f-a7bd-b4fdaf3fb3ce"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9471), "Jacob", "8141d2b17b7344d1c058e0cfaa031768e23bab8eb32613d3345655b37876436c", 2, 2 },
                    { new Guid("fe76b5bc-2e5e-4bea-9a09-a9e6282eadeb"), new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9620), "Oscar", "ca66a852a9e96c40f4cce7972d994914909b646b2564e8d25dd4003656b3dd63", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Login",
                table: "users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_User_group_id",
                table: "users",
                column: "User_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_User_state_id",
                table: "users",
                column: "User_state_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_groups");

            migrationBuilder.DropTable(
                name: "user_states");
        }
    }
}
