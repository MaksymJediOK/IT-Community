using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_Community.Server.Core.Migrations
{
    public partial class fix_seeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "686e678b-b338-4edb-8cb3-001c68e14c5b", "0407db09-d7c3-4f31-b1b9-eb44075e9fa2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "99deea5c-5e16-48e0-a28a-ff5d5754a9b6", "0b836683-a0d8-49fe-87e6-13f8767cbd7d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e4976f2-f121-4ef5-acb1-4f984db8c8da", "6151ecc1-5ada-4a80-b086-6748891e900e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "686e678b-b338-4edb-8cb3-001c68e14c5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e4976f2-f121-4ef5-acb1-4f984db8c8da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99deea5c-5e16-48e0-a28a-ff5d5754a9b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0407db09-d7c3-4f31-b1b9-eb44075e9fa2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b836683-a0d8-49fe-87e6-13f8767cbd7d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6151ecc1-5ada-4a80-b086-6748891e900e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77c678d5-c4be-47e0-9e19-f69cda7b5423", "7c4ef1a0-2fc7-45fe-870e-1901e1948b7b", "User", "USER" },
                    { "c4505a72-17a5-4586-9750-059db93ca030", "739fa33d-b5fa-4209-8899-ebbbed042b04", "Admin", "ADMIN" },
                    { "d354eb8d-08c8-4c71-b108-eba2c2f0f759", "d74870fc-9bb5-483c-b4f7-7e79ce3c9a0e", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1302de60-44d2-47e0-b8a6-35df74b9731e", 0, null, "809e1ea4-ac0a-4a1f-8d5b-373f2470dc6f", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDinxDjLQMYOLwCffgiF63e1TWu1mc5lGdn9bHJGRll2/4KRkyrlg3cMduguwdylBQ==", null, false, "1f86ae79-bbe5-4c49-b875-f628fbf3e413", false, "admin@gmail.com" },
                    { "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989", 0, null, "97d6d0c2-1aed-46d7-ab6d-7b43a9d0abf3", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAED5pqx7/SHIwvs3PdztRTMRnQy2RO5y0aB1fSMG3ECtOsCMFw+BxdUemCUZXeo8AoA==", null, false, "53a20da2-4d5e-49ff-b595-567b381710ef", false, "user@gmail.com" },
                    { "5734d6c4-81d8-45da-bc38-2291447a3092", 0, null, "d5590711-63e5-4a76-a6c9-343cd412111a", "moder@gmail.com", true, false, null, "MODER@GMAIL.COM", "MODER@GMAIL.COM", "AQAAAAEAACcQAAAAEI1PiVxXsLBzhCJnhlrnQMmOj6tLQGaQWWjwA3WE3vRXB3LoO2F+fmrIIy13eGIALA==", null, false, "c3dac0cb-57fa-4c8d-aff3-a9d3621af2f1", false, "moder@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c4505a72-17a5-4586-9750-059db93ca030", "1302de60-44d2-47e0-b8a6-35df74b9731e" },
                    { "77c678d5-c4be-47e0-9e19-f69cda7b5423", "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" },
                    { "d354eb8d-08c8-4c71-b108-eba2c2f0f759", "5734d6c4-81d8-45da-bc38-2291447a3092" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 10, 11, 36, 9, 520, DateTimeKind.Local).AddTicks(5706), "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 10, 11, 36, 9, 520, DateTimeKind.Local).AddTicks(5712), "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" });

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989");

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 10, 11, 36, 9, 520, DateTimeKind.Local).AddTicks(5616), "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 10, 11, 36, 9, 520, DateTimeKind.Local).AddTicks(5667), "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 10, 11, 36, 9, 520, DateTimeKind.Local).AddTicks(5672), "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 10, 11, 36, 9, 520, DateTimeKind.Local).AddTicks(5677), "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c4505a72-17a5-4586-9750-059db93ca030", "1302de60-44d2-47e0-b8a6-35df74b9731e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "77c678d5-c4be-47e0-9e19-f69cda7b5423", "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d354eb8d-08c8-4c71-b108-eba2c2f0f759", "5734d6c4-81d8-45da-bc38-2291447a3092" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77c678d5-c4be-47e0-9e19-f69cda7b5423");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4505a72-17a5-4586-9750-059db93ca030");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d354eb8d-08c8-4c71-b108-eba2c2f0f759");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1302de60-44d2-47e0-b8a6-35df74b9731e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3d8aafa5-a2ac-4ce6-98e7-1be558ac2989");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5734d6c4-81d8-45da-bc38-2291447a3092");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "686e678b-b338-4edb-8cb3-001c68e14c5b", "d8b58c75-9bc0-49f6-bb12-eb7c8508fb9b", "Moderator", "MODERATOR" },
                    { "8e4976f2-f121-4ef5-acb1-4f984db8c8da", "3a4c6553-caef-498a-925d-2d3beefdc374", "Admin", "ADMIN" },
                    { "99deea5c-5e16-48e0-a28a-ff5d5754a9b6", "f1dbef5b-9cdf-4ef4-bede-6a4eb7c018fd", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0407db09-d7c3-4f31-b1b9-eb44075e9fa2", 0, null, "4596a95d-ac15-4070-aac6-da86999d12e6", "moder@gmail.com", true, false, null, "MODER@GMAIL.COM", "MODER@GMAIL.COM", "AQAAAAEAACcQAAAAEMfKdxOTMeYshLAwNJDefiml6Q33MmtvtTH/iyFifkpwYZ3kurrKUZt1fdtMzuGucA==", null, false, "31fda3ea-72cb-41a8-9c0d-165875fa5aa9", false, "moder@gmail.com" },
                    { "0b836683-a0d8-49fe-87e6-13f8767cbd7d", 0, null, "efc756aa-0325-44cc-b36c-54c0d1d06078", "user@gmails.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEB5kMYdAjdzRH0HaLHe40gRJKJ2aGYEsutL0lZQxEbltCedRGf+oO9Y2zyfT+4fZxg==", null, false, "ddc457eb-3163-4296-a724-7988d3e11e40", false, "user@gmail.com" },
                    { "6151ecc1-5ada-4a80-b086-6748891e900e", 0, null, "234bf871-1d68-4c3b-85ef-3f2fa5cf5a94", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPycLCD5AzAIBKanKRCQ+ELAdeBnuar5ccTnRMCi8IcrkAWn9gSb/IJy2S5M9ZUq6w==", null, false, "91bb24d3-9dc4-4d71-9488-53b1bad8b5f8", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "686e678b-b338-4edb-8cb3-001c68e14c5b", "0407db09-d7c3-4f31-b1b9-eb44075e9fa2" },
                    { "99deea5c-5e16-48e0-a28a-ff5d5754a9b6", "0b836683-a0d8-49fe-87e6-13f8767cbd7d" },
                    { "8e4976f2-f121-4ef5-acb1-4f984db8c8da", "6151ecc1-5ada-4a80-b086-6748891e900e" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 9, 1, 8, 54, 770, DateTimeKind.Local).AddTicks(796), "0b836683-a0d8-49fe-87e6-13f8767cbd7d" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 9, 1, 8, 54, 770, DateTimeKind.Local).AddTicks(798), "0b836683-a0d8-49fe-87e6-13f8767cbd7d" });

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "0b836683-a0d8-49fe-87e6-13f8767cbd7d");

            migrationBuilder.UpdateData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "0b836683-a0d8-49fe-87e6-13f8767cbd7d");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 9, 1, 8, 54, 770, DateTimeKind.Local).AddTicks(726), "0b836683-a0d8-49fe-87e6-13f8767cbd7d" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 9, 1, 8, 54, 770, DateTimeKind.Local).AddTicks(770), "0b836683-a0d8-49fe-87e6-13f8767cbd7d" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 9, 1, 8, 54, 770, DateTimeKind.Local).AddTicks(772), "0b836683-a0d8-49fe-87e6-13f8767cbd7d" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2023, 2, 9, 1, 8, 54, 770, DateTimeKind.Local).AddTicks(775), "0b836683-a0d8-49fe-87e6-13f8767cbd7d" });
        }
    }
}
