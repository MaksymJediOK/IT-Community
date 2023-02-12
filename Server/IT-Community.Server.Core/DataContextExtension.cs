using IT_Community.Server.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Core
{
    public static class DataContextExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string MODER_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = MODER_ROLE_ID,
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "User",
                    NormalizedName = "USER"
                });

            string ADMIN_ID = Guid.NewGuid().ToString();
            string MODER_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper()
            };

            var moder = new User
            {
                Id = MODER_ID,
                UserName = "moder@gmail.com",
                Email = "moder@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "moder@gmail.com".ToUpper(),
                NormalizedUserName = "moder@gmail.com".ToUpper()
            };

            var user = new User
            {
                Id = USER_ID,
                UserName = "user@gmail.com",
                Email = "user@gmails.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@gmail.com".ToUpper(),
                NormalizedUserName = "user@gmail.com".ToUpper()
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$Pass1");
            moder.PasswordHash = hasher.HashPassword(moder, "moder$Pass1");
            user.PasswordHash = hasher.HashPassword(user, "user$Pass1");

            builder.Entity<User>().HasData(admin, moder, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MODER_ROLE_ID,
                    UserId = MODER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });

            builder.Entity<Forum>().HasData(
                new Forum
                {
                    Id = 1,
                    Name = "Branding"
                },
                new Forum
                {
                    Id = 2,
                    Name = "Web Design"
                },
                new Forum
                {
                    Id = 3,
                    Name = "UI/UX"
                },
                new Forum
                {
                    Id = 4,
                    Name = "Software Development"
                },
                new Forum
                {
                    Id = 5,
                    Name = "FrontEnd"
                },
                new Forum
                {
                    Id = 6,
                    Name = "BackEnd"
                },
                new Forum
                {
                    Id = 7,
                    Name = "DevOps"
                },
                new Forum
                {
                    Id = 8,
                    Name = "Project Managament"
                },
                new Forum
                {
                    Id = 9,
                    Name = "Hiring"
                },
                new Forum
                {
                    Id = 10,
                    Name = "Guide"
                });

            var tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = ".Net"
                },
                new Tag
                {
                    Id = 2,
                    Name = "DevOps",
                },
                new Tag
                {
                    Id = 3,
                    Name = "GitHub"
                },
                new Tag
                {
                    Id = 4,
                    Name = "tech"
                },
                new Tag
                {
                    Id = 5,
                    Name = "Go"
                },
                new Tag
                {
                    Id = 6,
                    Name = "JavaScript"
                },
                new Tag
                {
                    Id = 7,
                    Name = "PHP"
                },
                new Tag
                {
                    Id = 8,
                    Name = "project management"
                },
                new Tag
                {
                    Id = 9,
                    Name = "Web"
                },
                new Tag
                {
                    Id = 10,
                    Name = "IT"
                }
            };

            builder.Entity<Tag>().HasData(tags);

            builder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "«Українці — пункт № 1 в будь-якому Risk Assessment Report». До чого готуватись українському IT у 2023 році",
                    Description = "Ми вирішили розібратися, чого галузі чекати від наступного 2023 року. Поспілкувалися з представниками державних установ, кластерами, компаніями та айтівцями про те, які виклики чекають на ІТ у майбутньому, чи зможе галузь відновити зростання, утримувати та залучати нових клієнтів та ключових розробників.",
                    Body = "2022 рік став складним для держави, всіх українців і зокрема для ІТ-індустрії. Ми вирішили розібратися, чого галузі чекати від наступного 2023 року.\nМи поспілкувалися з представниками державних установ, кластерами, компаніями та айтівцями про те, які виклики чекають на ІТ у майбутньому, чи зможе галузь відновити зростання, утримувати та залучати нових клієнтів та ключових розробників.\n\n## Плани Мінцифри: military-tech, Дія City, стартапи\n\nУ Міністерстві цифрової трансформації 2023 року сфокусуються на підтриманні та розвитку таких великих проєктів, як Дія City (нині там уже 413 резидентів), military-tech, технологічних стартапів на основі систем штучного інтелекту й робототехніки.\n«Наша країна має всі шанси стати світовим лідером з розвитку military-tech. У нас для цього є високопрофесійні розробники, сильна ІТ-індустрія, яка демонструє зростання навіть під час війни, та можливість оперативного випробування технологій на полі бою», — коментують у Мінцифри.\nВідомство також має план розвитку ІТ, розроблений спільно з представниками галузі, що передбачає підтримку чотирьох напрямів: венчурної та стартап-екосистеми, ІТ-освіти, digital resistance, просування бренду України як IT-держави.\nКрім того, у своїй діяльності міністерство робитиме акцент на підтриманні продуктового напряму.",
                    Views = 10,
                    Date = DateTime.Now,
                    Thumbnail = "https://s.dou.ua/img/announces/forecasts_cover-840.jpg",
                    ForumId = 10,
                    UserId = USER_ID,
                },
                new Post
                {
                    Id = 2,
                    Title = "Хороший, поганий код: як code review рятує проєкт",
                    Description = "Team Lead і Java Coach Богдан Чупіка зібрав у цьому матеріалі досвід колег щодо проведення code review і розбирає на конкретному прикладі, як організувати цей процес якісно та корисно для проєкту.",
                    Body = "Всім привіт! Мене звати Богдан Чупіка, я працюю в Edtech-стартапі Mate academy на позиції Team Lead/ Java Coach. Серед моїх обовʼязків є рев’ю коду нашої команди девелоперів, перевірка коду студентів і проведення співбесід в команду.\n\nПід час лайв кодингу на співбесідах (один з обовʼязкових етапів) я зустрічав дуже багато випадків, коли кандидати пишуть не ок код. Навіть після прохання привести їх до вигляду, який буде запушений в мастер. При чому помилки бувають як в джунів, так і в сеньйорів (у меншій кількості, але все ж).\n\nУ цій статті я зберу не тільки власний весь досвід, а і досвід команди з понад 70 девелоперів і менторів у нашій компанії. І, головне — відповім на питання: Як потрібно якісно писати код? Звичайно ж, з прикладами і порадами. Текст буде корисний і тим, хто пише код, і тим, хто його читає.\n\nПогодьтеся, що набагато приємніше і швидше читати код, який за своїм стилем схожий на той, що ви пишете в рамках поточного проєкту. Якби щодо код стайлу панувала анархія, скоро цей код було б дуже важко і читати, і підтримувати.\n\nНЕ якісний код НЕ повинен потрапити в мастер (мейн) гілку. Для цього існує процес code review. ",
                    Views = 10,
                    Date = DateTime.Now,
                    Thumbnail = "https://s.dou.ua/img/announces/23tech_review_2.jpg",
                    ForumId = 4,
                    UserId = USER_ID
                },
                new Post
                {
                    Id = 3,
                    Title = "Встановлюємо Node-Red в Home Assistant. Інструкція",
                    Description = "Node-RED — це інструмент блокового програмування потоків даних пристроїв, API та онлайн-сервісів. Як налаштувати цей додаток в інтерфейсі Home Assistant — розповідає Богдан Свердлюк.",
                    Body = "Усім привіт, на зв’язку Богдан Свердлюк, я люблю розбиратись у налаштуваннях «розумного» будинку та IoT, і ділитись своїм досвідом з українською ІТ-спільнотою. Сьогодні поговоримо про те, як встановити Node-Red в Home Assistant. російський військовий корабель, іди нах***!\n\nNode-RED — це інструмент блокового програмування потоків даних пристроїв, API та онлайн-сервісів. Часто використовується для створення автоматизацій. Це браузерний редактор, який спрощує об’єднання потоків, використовуючи широкий діапазон вузлів (нодів) у палітрі, виконання яких можна запустити в один клік.\n\nЩоб встановити додаток в інтерфейсі Home Assistant перейдіть у бічне меню >> Конфігурація >> Додатки >> Магазин доповнень >> у розділі Community Add-ons натисніть та встановіть додаток Node-RED.",
                    Views = 10,
                    Date = DateTime.Now,
                    Thumbnail = "https://s.dou.ua/img/announces/tech_nr_image.jpg",
                    ForumId = 10,
                    UserId = USER_ID
                },
                new Post
                {
                    Id = 4,
                    Title = "Фреймворк для тестування UI. Як його налаштувати на Java",
                    Description = "Олександр Подоляко розбирає приклад використання фреймворку для автоматичного тестування UI, зокрема і розповідає, як налаштувати можливість взаємодіяти з базою даних та логування з репортом.",
                    Body = "Всім привіт! Мене звати Олександр, час від часу я ділюся своїм досвідом роботи з Java з технічною спільнотою. В попередній раз я писав про фреймворк для тестування API сервісів на Java і в мене виникла ідея написати про загальніший фреймворк, який буде додатково містити частини для тестування UI, можливість взаємодіяти з базою даних та логування з репортом.\nДо об’єкта тестування я висував наступні вимоги:\n\nсистема має мати UI та API інтерфейси;\nсистема має мати взаємодією з базою даних;\nсистема має бути опенсорс та безкоштовною;\nрозгортання системи локально має бути максимально простим.\n\nЯк об’єкт тестування я вибрав KanBoard, оскільки це програмне забезпечення задовольняє всім моїм вимогам. Kanboard — це опенсорс програмне забезпечення, яке дозволяє створювати проєктні дашборди із завданнями.\n\nРозгортається система локально однією командою docker compose up з папки, де знаходиться docker-compose.yml. У випадку фреймворку цей файл знаходиться у root папці. Я не буду описувати, як встановити docker, цю інформацію можна отримати за посиланням. Якщо не змінювати налаштування у docker-compose.yml файлі, то інтерфейс буде доступний за лінкою http://127.0.0.1/login, юзер має креди admin/admin.",
                    Views = 5,
                    Date = DateTime.Now,
                    Thumbnail = "https://s.dou.ua/img/announces/tech_frontend_j_2.png",
                    ForumId = 4,
                    UserId = USER_ID
                });

            builder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Body = "Дуже якісна та інформативна статистика!\nРаджу почитати оригінальне дослідження щоб зрозуміти масштаби\nitukraine.org.ua/...​2/DoITLikeUkraine2022.pdf",
                    Date = DateTime.Now,
                    UserId = USER_ID,
                    PostId = 1
                },
                new Comment
                {
                    Id = 2,
                    Body = "Як створювали саму структуру проекту? Через можливості IDE або maven generate?",
                    Date = DateTime.Now,
                    UserId = USER_ID,
                    PostId = 4
                });

            builder.Entity<Like>().HasData(
                new Like
                {
                    Id = 1,
                    UserId = USER_ID,
                    PostId = 1
                },
                new Like
                {
                    Id = 2,
                    UserId = USER_ID,
                    PostId = 3
                });
        }
    }
}
