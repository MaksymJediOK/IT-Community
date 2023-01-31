using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT_Community.Server.Core.Migrations
{
    public partial class Create_Test_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "599eab22-8414-41d9-941b-e911349be7da", "e33452e8-7ffe-47fb-9ccc-a49c85a55eb2", "Moderator", "MODERATOR" },
                    { "5d87a76f-fba9-4127-84fe-14e3ed8253f1", "a0249600-fa83-462f-b773-b1fb32f0662a", "User", "USER" },
                    { "7bcccdd6-4537-459b-a194-436a5bb25833", "f33414ae-5250-4b22-b7a4-8d5f726bc7cb", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "321e5318-8a80-47c4-9c6f-a7c81f286fbd", 0, "cb61037c-746f-4896-848d-1fed66987348", "user@gmails.com", true, false, null, "USER@GMAIL.COM", "USER@GMAIL.COM", "AQAAAAEAACcQAAAAEP3e2F9Do5oUtMCL8CZmu15ZtGFCAA98ze4NlHjJJOMSfLDTkRT7Exor6oUzxT9RWw==", null, false, "c47aa94b-d62d-40d1-817b-16203ca43757", false, "user@gmail.com" },
                    { "a877d56c-a9f7-442f-b0e8-055fce5b55a0", 0, "73410376-15d7-4c2c-918a-17f0b655af94", "moder@gmail.com", true, false, null, "MODER@GMAIL.COM", "MODER@GMAIL.COM", "AQAAAAEAACcQAAAAENMyR81243UPTPPIQTiaJIf+rBhaRnzY8fv8D2mB/mS3QXewQ18yFetOilLBixTxcw==", null, false, "3b867fa9-052d-43df-8e19-e6c592569b55", false, "moder@gmail.com" },
                    { "ccc08b53-92fd-4154-bfd2-0329997e5601", 0, "cf0111c8-9fd2-4d0b-adf2-3a26175381e0", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGvSIuBH0uv1Gnb8iQMMFsjrBJnCnLEo8beqaazTIir4eMdyklLwCg8nUDKT6ATsKg==", null, false, "9bc48f9d-6fb5-46a3-a1a0-001e8bf9b988", false, "admin@gmail.com" }
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
                    { "5d87a76f-fba9-4127-84fe-14e3ed8253f1", "321e5318-8a80-47c4-9c6f-a7c81f286fbd" },
                    { "599eab22-8414-41d9-941b-e911349be7da", "a877d56c-a9f7-442f-b0e8-055fce5b55a0" },
                    { "7bcccdd6-4537-459b-a194-436a5bb25833", "ccc08b53-92fd-4154-bfd2-0329997e5601" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Body", "Date", "Description", "ForumId", "Thumbnail", "Title", "UserId", "Views" },
                values: new object[,]
                {
                    { 1, "2022 рік став складним для держави, всіх українців і зокрема для ІТ-індустрії. Ми вирішили розібратися, чого галузі чекати від наступного 2023 року.\nМи поспілкувалися з представниками державних установ, кластерами, компаніями та айтівцями про те, які виклики чекають на ІТ у майбутньому, чи зможе галузь відновити зростання, утримувати та залучати нових клієнтів та ключових розробників.\n\n## Плани Мінцифри: military-tech, Дія City, стартапи\n\nУ Міністерстві цифрової трансформації 2023 року сфокусуються на підтриманні та розвитку таких великих проєктів, як Дія City (нині там уже 413 резидентів), military-tech, технологічних стартапів на основі систем штучного інтелекту й робототехніки.\n«Наша країна має всі шанси стати світовим лідером з розвитку military-tech. У нас для цього є високопрофесійні розробники, сильна ІТ-індустрія, яка демонструє зростання навіть під час війни, та можливість оперативного випробування технологій на полі бою», — коментують у Мінцифри.\nВідомство також має план розвитку ІТ, розроблений спільно з представниками галузі, що передбачає підтримку чотирьох напрямів: венчурної та стартап-екосистеми, ІТ-освіти, digital resistance, просування бренду України як IT-держави.\nКрім того, у своїй діяльності міністерство робитиме акцент на підтриманні продуктового напряму.", new DateTime(2023, 1, 27, 20, 34, 1, 406, DateTimeKind.Local).AddTicks(7951), "Ми вирішили розібратися, чого галузі чекати від наступного 2023 року. Поспілкувалися з представниками державних установ, кластерами, компаніями та айтівцями про те, які виклики чекають на ІТ у майбутньому, чи зможе галузь відновити зростання, утримувати та залучати нових клієнтів та ключових розробників.", 10, "https://s.dou.ua/img/announces/forecasts_cover-840.jpg", "«Українці — пункт № 1 в будь-якому Risk Assessment Report». До чого готуватись українському IT у 2023 році", "321e5318-8a80-47c4-9c6f-a7c81f286fbd", 10 },
                    { 2, "Всім привіт! Мене звати Богдан Чупіка, я працюю в Edtech-стартапі Mate academy на позиції Team Lead/ Java Coach. Серед моїх обовʼязків є рев’ю коду нашої команди девелоперів, перевірка коду студентів і проведення співбесід в команду.\n\nПід час лайв кодингу на співбесідах (один з обовʼязкових етапів) я зустрічав дуже багато випадків, коли кандидати пишуть не ок код. Навіть після прохання привести їх до вигляду, який буде запушений в мастер. При чому помилки бувають як в джунів, так і в сеньйорів (у меншій кількості, але все ж).\n\nУ цій статті я зберу не тільки власний весь досвід, а і досвід команди з понад 70 девелоперів і менторів у нашій компанії. І, головне — відповім на питання: Як потрібно якісно писати код? Звичайно ж, з прикладами і порадами. Текст буде корисний і тим, хто пише код, і тим, хто його читає.\n\nПогодьтеся, що набагато приємніше і швидше читати код, який за своїм стилем схожий на той, що ви пишете в рамках поточного проєкту. Якби щодо код стайлу панувала анархія, скоро цей код було б дуже важко і читати, і підтримувати.\n\nНЕ якісний код НЕ повинен потрапити в мастер (мейн) гілку. Для цього існує процес code review. ", new DateTime(2023, 1, 27, 20, 34, 1, 406, DateTimeKind.Local).AddTicks(8000), "Team Lead і Java Coach Богдан Чупіка зібрав у цьому матеріалі досвід колег щодо проведення code review і розбирає на конкретному прикладі, як організувати цей процес якісно та корисно для проєкту.", 4, "https://s.dou.ua/img/announces/23tech_review_2.jpg", "Хороший, поганий код: як code review рятує проєкт", "321e5318-8a80-47c4-9c6f-a7c81f286fbd", 10 },
                    { 3, "Усім привіт, на зв’язку Богдан Свердлюк, я люблю розбиратись у налаштуваннях «розумного» будинку та IoT, і ділитись своїм досвідом з українською ІТ-спільнотою. Сьогодні поговоримо про те, як встановити Node-Red в Home Assistant. російський військовий корабель, іди нах***!\n\nNode-RED — це інструмент блокового програмування потоків даних пристроїв, API та онлайн-сервісів. Часто використовується для створення автоматизацій. Це браузерний редактор, який спрощує об’єднання потоків, використовуючи широкий діапазон вузлів (нодів) у палітрі, виконання яких можна запустити в один клік.\n\nЩоб встановити додаток в інтерфейсі Home Assistant перейдіть у бічне меню >> Конфігурація >> Додатки >> Магазин доповнень >> у розділі Community Add-ons натисніть та встановіть додаток Node-RED.", new DateTime(2023, 1, 27, 20, 34, 1, 406, DateTimeKind.Local).AddTicks(8004), "Node-RED — це інструмент блокового програмування потоків даних пристроїв, API та онлайн-сервісів. Як налаштувати цей додаток в інтерфейсі Home Assistant — розповідає Богдан Свердлюк.", 10, "https://s.dou.ua/img/announces/tech_nr_image.jpg", "Встановлюємо Node-Red в Home Assistant. Інструкція", "321e5318-8a80-47c4-9c6f-a7c81f286fbd", 10 },
                    { 4, "Всім привіт! Мене звати Олександр, час від часу я ділюся своїм досвідом роботи з Java з технічною спільнотою. В попередній раз я писав про фреймворк для тестування API сервісів на Java і в мене виникла ідея написати про загальніший фреймворк, який буде додатково містити частини для тестування UI, можливість взаємодіяти з базою даних та логування з репортом.\nДо об’єкта тестування я висував наступні вимоги:\n\nсистема має мати UI та API інтерфейси;\nсистема має мати взаємодією з базою даних;\nсистема має бути опенсорс та безкоштовною;\nрозгортання системи локально має бути максимально простим.\n\nЯк об’єкт тестування я вибрав KanBoard, оскільки це програмне забезпечення задовольняє всім моїм вимогам. Kanboard — це опенсорс програмне забезпечення, яке дозволяє створювати проєктні дашборди із завданнями.\n\nРозгортається система локально однією командою docker compose up з папки, де знаходиться docker-compose.yml. У випадку фреймворку цей файл знаходиться у root папці. Я не буду описувати, як встановити docker, цю інформацію можна отримати за посиланням. Якщо не змінювати налаштування у docker-compose.yml файлі, то інтерфейс буде доступний за лінкою http://127.0.0.1/login, юзер має креди admin/admin.", new DateTime(2023, 1, 27, 20, 34, 1, 406, DateTimeKind.Local).AddTicks(8010), "Олександр Подоляко розбирає приклад використання фреймворку для автоматичного тестування UI, зокрема і розповідає, як налаштувати можливість взаємодіяти з базою даних та логування з репортом.", 4, "https://s.dou.ua/img/announces/tech_frontend_j_2.png", "Фреймворк для тестування UI. Як його налаштувати на Java", "321e5318-8a80-47c4-9c6f-a7c81f286fbd", 5 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "Date", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, "Дуже якісна та інформативна статистика!\nРаджу почитати оригінальне дослідження щоб зрозуміти масштаби\nitukraine.org.ua/...​2/DoITLikeUkraine2022.pdf", new DateTime(2023, 1, 27, 20, 34, 1, 406, DateTimeKind.Local).AddTicks(8039), 1, "321e5318-8a80-47c4-9c6f-a7c81f286fbd" },
                    { 2, "Як створювали саму структуру проекту? Через можливості IDE або maven generate?", new DateTime(2023, 1, 27, 20, 34, 1, 406, DateTimeKind.Local).AddTicks(8045), 4, "321e5318-8a80-47c4-9c6f-a7c81f286fbd" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "321e5318-8a80-47c4-9c6f-a7c81f286fbd" },
                    { 2, 3, "321e5318-8a80-47c4-9c6f-a7c81f286fbd" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5d87a76f-fba9-4127-84fe-14e3ed8253f1", "321e5318-8a80-47c4-9c6f-a7c81f286fbd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "599eab22-8414-41d9-941b-e911349be7da", "a877d56c-a9f7-442f-b0e8-055fce5b55a0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7bcccdd6-4537-459b-a194-436a5bb25833", "ccc08b53-92fd-4154-bfd2-0329997e5601" });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "599eab22-8414-41d9-941b-e911349be7da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d87a76f-fba9-4127-84fe-14e3ed8253f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bcccdd6-4537-459b-a194-436a5bb25833");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a877d56c-a9f7-442f-b0e8-055fce5b55a0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccc08b53-92fd-4154-bfd2-0329997e5601");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "321e5318-8a80-47c4-9c6f-a7c81f286fbd");

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Forums",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
