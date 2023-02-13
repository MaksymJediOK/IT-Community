using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_Community.Server.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeesAmount = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacancies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Views = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForumId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Forums_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VacancyId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answers_Vacancies_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryVacancy",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    VacanciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVacancy", x => new { x.CategoriesId, x.VacanciesId });
                    table.ForeignKey(
                        name: "FK_CategoryVacancy_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryVacancy_Vacancies_VacanciesId",
                        column: x => x.VacanciesId,
                        principalTable: "Vacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14157175-0426-4475-afe4-79f63f146bfc", "f2e9d685-cfe6-4943-b5d9-aea1ee0b0e41", "Moderator", "MODERATOR" },
                    { "5145f240-ac4c-4a56-98c5-b57b45da28c3", "383229f6-1919-4503-88dd-b634e505bf03", "Admin", "ADMIN" },
                    { "8d6348d9-9900-49d7-832f-4973d37cb00c", "38806f02-436c-48db-bc53-536f993e58a5", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePhoto", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "76698a64-fc76-41ed-b070-9cf5d99c80ca", 0, null, "66379ef5-a1b7-455c-85b8-65fdd8c85a9a", "moder@gmail.com", true, false, null, "MODER@GMAIL.COM", "MODER@GMAIL.COM", "AQAAAAEAACcQAAAAEJL6PNiwbkJ/j+tz19KFn6NZczMuWb3NHI9CBoddRw/M1/u3PUY4I32nAlG2VOfSSQ==", null, false, null, "80c838f3-948c-4f5b-acf1-5039e66c43bc", false, "moder@gmail.com" },
                    { "e5e8e0fe-b9fa-41c9-892e-da063666c8e6", 0, null, "2f9782f0-a7cb-4c21-9ac6-5cdff0624fd5", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENWNMlyF8h7kQ4Fx6FPewBEvFaFw4k+qYLgmP4DZhziKcamXteaOWb6LCl9S1DOg1w==", null, false, null, "4b448b62-adb3-4826-9373-5481c564dc75", false, "admin@gmail.com" },
                    { "e941f6bd-9ad1-49a8-923b-a04faece00f5", 0, null, "401ebc3f-8da1-4d21-9628-2ee50b22be42", "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEOp4FIPUiZctXuj3m7MlOsLrFCGxFkIQb3pkMd7VP/UyRwttJr5f2jsIxURM/1Z39g==", null, false, null, "1c1195cf-a1ff-4eb8-9fe4-149d119b13ea", false, "user@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Forums",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Branding" },
                    { 2, "Web Design" },
                    { 3, "UI/UX" },
                    { 4, "Software Development" },
                    { 5, "FrontEnd" },
                    { 6, "BackEnd" },
                    { 7, "DevOps" },
                    { 8, "Project Managament" },
                    { 9, "Hiring" },
                    { 10, "Guide" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, ".Net" },
                    { 2, "DevOps" },
                    { 3, "GitHub" },
                    { 4, "tech" },
                    { 5, "Go" },
                    { 6, "JavaScript" },
                    { 7, "PHP" },
                    { 8, "project management" },
                    { 9, "Web" },
                    { 10, "IT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "14157175-0426-4475-afe4-79f63f146bfc", "76698a64-fc76-41ed-b070-9cf5d99c80ca" },
                    { "5145f240-ac4c-4a56-98c5-b57b45da28c3", "e5e8e0fe-b9fa-41c9-892e-da063666c8e6" },
                    { "8d6348d9-9900-49d7-832f-4973d37cb00c", "e941f6bd-9ad1-49a8-923b-a04faece00f5" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Date", "Description", "ForumId", "Thumbnail", "Title", "UserId", "Views" },
                values: new object[,]
                {
                    { 1, "2022 рік став складним для держави, всіх українців і зокрема для ІТ-індустрії. Ми вирішили розібратися, чого галузі чекати від наступного 2023 року.\nМи поспілкувалися з представниками державних установ, кластерами, компаніями та айтівцями про те, які виклики чекають на ІТ у майбутньому, чи зможе галузь відновити зростання, утримувати та залучати нових клієнтів та ключових розробників.\n\n## Плани Мінцифри: military-tech, Дія City, стартапи\n\nУ Міністерстві цифрової трансформації 2023 року сфокусуються на підтриманні та розвитку таких великих проєктів, як Дія City (нині там уже 413 резидентів), military-tech, технологічних стартапів на основі систем штучного інтелекту й робототехніки.\n«Наша країна має всі шанси стати світовим лідером з розвитку military-tech. У нас для цього є високопрофесійні розробники, сильна ІТ-індустрія, яка демонструє зростання навіть під час війни, та можливість оперативного випробування технологій на полі бою», — коментують у Мінцифри.\nВідомство також має план розвитку ІТ, розроблений спільно з представниками галузі, що передбачає підтримку чотирьох напрямів: венчурної та стартап-екосистеми, ІТ-освіти, digital resistance, просування бренду України як IT-держави.\nКрім того, у своїй діяльності міністерство робитиме акцент на підтриманні продуктового напряму.", new DateTime(2023, 2, 13, 11, 28, 54, 90, DateTimeKind.Local).AddTicks(8514), "Ми вирішили розібратися, чого галузі чекати від наступного 2023 року. Поспілкувалися з представниками державних установ, кластерами, компаніями та айтівцями про те, які виклики чекають на ІТ у майбутньому, чи зможе галузь відновити зростання, утримувати та залучати нових клієнтів та ключових розробників.", 10, "https://s.dou.ua/img/announces/forecasts_cover-840.jpg", "«Українці — пункт № 1 в будь-якому Risk Assessment Report». До чого готуватись українському IT у 2023 році", "e941f6bd-9ad1-49a8-923b-a04faece00f5", 10 },
                    { 2, "Всім привіт! Мене звати Богдан Чупіка, я працюю в Edtech-стартапі Mate academy на позиції Team Lead/ Java Coach. Серед моїх обовʼязків є рев’ю коду нашої команди девелоперів, перевірка коду студентів і проведення співбесід в команду.\n\nПід час лайв кодингу на співбесідах (один з обовʼязкових етапів) я зустрічав дуже багато випадків, коли кандидати пишуть не ок код. Навіть після прохання привести їх до вигляду, який буде запушений в мастер. При чому помилки бувають як в джунів, так і в сеньйорів (у меншій кількості, але все ж).\n\nУ цій статті я зберу не тільки власний весь досвід, а і досвід команди з понад 70 девелоперів і менторів у нашій компанії. І, головне — відповім на питання: Як потрібно якісно писати код? Звичайно ж, з прикладами і порадами. Текст буде корисний і тим, хто пише код, і тим, хто його читає.\n\nПогодьтеся, що набагато приємніше і швидше читати код, який за своїм стилем схожий на той, що ви пишете в рамках поточного проєкту. Якби щодо код стайлу панувала анархія, скоро цей код було б дуже важко і читати, і підтримувати.\n\nНЕ якісний код НЕ повинен потрапити в мастер (мейн) гілку. Для цього існує процес code review. ", new DateTime(2023, 2, 13, 11, 28, 54, 90, DateTimeKind.Local).AddTicks(8552), "Team Lead і Java Coach Богдан Чупіка зібрав у цьому матеріалі досвід колег щодо проведення code review і розбирає на конкретному прикладі, як організувати цей процес якісно та корисно для проєкту.", 4, "https://s.dou.ua/img/announces/23tech_review_2.jpg", "Хороший, поганий код: як code review рятує проєкт", "e941f6bd-9ad1-49a8-923b-a04faece00f5", 10 },
                    { 3, "Усім привіт, на зв’язку Богдан Свердлюк, я люблю розбиратись у налаштуваннях «розумного» будинку та IoT, і ділитись своїм досвідом з українською ІТ-спільнотою. Сьогодні поговоримо про те, як встановити Node-Red в Home Assistant. російський військовий корабель, іди нах***!\n\nNode-RED — це інструмент блокового програмування потоків даних пристроїв, API та онлайн-сервісів. Часто використовується для створення автоматизацій. Це браузерний редактор, який спрощує об’єднання потоків, використовуючи широкий діапазон вузлів (нодів) у палітрі, виконання яких можна запустити в один клік.\n\nЩоб встановити додаток в інтерфейсі Home Assistant перейдіть у бічне меню >> Конфігурація >> Додатки >> Магазин доповнень >> у розділі Community Add-ons натисніть та встановіть додаток Node-RED.", new DateTime(2023, 2, 13, 11, 28, 54, 90, DateTimeKind.Local).AddTicks(8554), "Node-RED — це інструмент блокового програмування потоків даних пристроїв, API та онлайн-сервісів. Як налаштувати цей додаток в інтерфейсі Home Assistant — розповідає Богдан Свердлюк.", 10, "https://s.dou.ua/img/announces/tech_nr_image.jpg", "Встановлюємо Node-Red в Home Assistant. Інструкція", "e941f6bd-9ad1-49a8-923b-a04faece00f5", 10 },
                    { 4, "Всім привіт! Мене звати Олександр, час від часу я ділюся своїм досвідом роботи з Java з технічною спільнотою. В попередній раз я писав про фреймворк для тестування API сервісів на Java і в мене виникла ідея написати про загальніший фреймворк, який буде додатково містити частини для тестування UI, можливість взаємодіяти з базою даних та логування з репортом.\nДо об’єкта тестування я висував наступні вимоги:\n\nсистема має мати UI та API інтерфейси;\nсистема має мати взаємодією з базою даних;\nсистема має бути опенсорс та безкоштовною;\nрозгортання системи локально має бути максимально простим.\n\nЯк об’єкт тестування я вибрав KanBoard, оскільки це програмне забезпечення задовольняє всім моїм вимогам. Kanboard — це опенсорс програмне забезпечення, яке дозволяє створювати проєктні дашборди із завданнями.\n\nРозгортається система локально однією командою docker compose up з папки, де знаходиться docker-compose.yml. У випадку фреймворку цей файл знаходиться у root папці. Я не буду описувати, як встановити docker, цю інформацію можна отримати за посиланням. Якщо не змінювати налаштування у docker-compose.yml файлі, то інтерфейс буде доступний за лінкою http://127.0.0.1/login, юзер має креди admin/admin.", new DateTime(2023, 2, 13, 11, 28, 54, 90, DateTimeKind.Local).AddTicks(8556), "Олександр Подоляко розбирає приклад використання фреймворку для автоматичного тестування UI, зокрема і розповідає, як налаштувати можливість взаємодіяти з базою даних та логування з репортом.", 4, "https://s.dou.ua/img/announces/tech_frontend_j_2.png", "Фреймворк для тестування UI. Як його налаштувати на Java", "e941f6bd-9ad1-49a8-923b-a04faece00f5", 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "Date", "ParentId", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Дуже якісна та інформативна статистика!\nРаджу почитати оригінальне дослідження щоб зрозуміти масштаби\nitukraine.org.ua/...​2/DoITLikeUkraine2022.pdf", new DateTime(2023, 2, 13, 11, 28, 54, 90, DateTimeKind.Local).AddTicks(8581), null, 1, "e941f6bd-9ad1-49a8-923b-a04faece00f5" },
                    { 2, "Як створювали саму структуру проекту? Через можливості IDE або maven generate?", new DateTime(2023, 2, 13, 11, 28, 54, 90, DateTimeKind.Local).AddTicks(8584), null, 4, "e941f6bd-9ad1-49a8-923b-a04faece00f5" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "e941f6bd-9ad1-49a8-923b-a04faece00f5" },
                    { 2, 3, "e941f6bd-9ad1-49a8-923b-a04faece00f5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_UserId",
                table: "Answers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_VacancyId",
                table: "Answers",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyId",
                table: "AspNetUsers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVacancy_VacanciesId",
                table: "CategoryVacancy",
                column: "VacanciesId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentId",
                table: "Comments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ForumId",
                table: "Posts",
                column: "ForumId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_CompanyId",
                table: "Vacancies",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CategoryVacancy");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Forums");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
