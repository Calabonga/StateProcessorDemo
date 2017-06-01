using System;
using System.Linq;
using Autofac;
using Calabonga.StateProcessor.Demo.Data;
using Calabonga.StateProcessor.Demo.Statuses;

namespace Calabonga.StateProcessor.Demo {

    class Program {

        static void Main(string[] args) {
            var container = DependencyContainer.Initialize();

            var processor = container.Resolve<DocumentRuleProcessor>();

            // Метод Create создает экземпляр класса Document с установленным по умолчанию статусом.
            // Статус по умолчанию задается в DocumentRuleProcessor при переопределении метода InitialStatus
            // При вызове метода Create будет проведена проверка правил
            var document = processor.Create();

            // Создаем экземпляр класса с указанием автора
            var document2 = new Document {
                Author = "Director"
            };

            // Список всех статусов всегда доступен в процессоре
            var statusDraft = processor.Statuses.Single(x => x.Name.Equals(DocumentStatus.Draft.ToString()));

            // Устанавливаем статус документу
            processor.UpdateStatus(document2, statusDraft);

            // Получение Enum из Guid
            var result1 = processor.ToEnum<DocumentStatus>("Draft");
            if (result1.Ok) {
                DocumentStatus status1 = result1.Result;
                Console.WriteLine($"Test 1 converted : {status1.ToString()}");
            }

            // Получение Enum из строки (String) по имени статуса
            var result2 = processor.ToEnum<DocumentStatus>(Guid.Parse("49446068-0CCE-4168-B7AC-CD36E032F2BC"));
            if (result2.Ok) {
                DocumentStatus status2 = result2.Result;
                Console.WriteLine($"Test 2 converted : {status2.ToString()}");
            }

            // Получение Enum из EntityStatus
            var statusInProcessor = processor.Statuses.SingleOrDefault(x => x.Id == Guid.Parse("49446068-0CCE-4168-B7AC-CD36E032F2BC"));
            var result3 = processor.ToEnum<DocumentStatus>(statusInProcessor);
            if (result3.Ok) {
                DocumentStatus status3 = result3.Result;
                Console.WriteLine($"Test 3 converted : {status3.ToString()}");
            }

            using (var db = new ApplicationDbContext()) {

                // сохраним созданый выше документ в базу данных
                db.Documents.Add(document2);
                db.SaveChanges();

                PrintStatus(document2, processor);

                // загрузим снова документ базы данных
                var documentInDatabase = db.Documents.SingleOrDefault(x => x.Id == document2.Id);
                if (documentInDatabase != null) {

                    // Выберем новый статус для сущности. А для этого выбираем статус из всех доступных
                    var entityStatus = processor.Statuses.SingleOrDefault(x => x.Name.Equals(DocumentStatus.InValidation.ToString()));

                    document2.Number = "Номер строгой отчетности";

                    // и обновляем его у сущности
                    processor.UpdateStatus(documentInDatabase, entityStatus);

                    PrintStatus(documentInDatabase, processor);

                    // сохраним изменения
                    db.SaveChanges();
                }
            }

            Console.ReadLine();

        }

        static void PrintStatus(Document document, DocumentRuleProcessor processor) {
            // приведем текущий статус документ к удобному виду
            var convertResult = processor.ToEnum<DocumentStatus>(document.EntityActiveStatus);

            // отобразим в консоле
            Console.WriteLine($"{document.EntityActiveStatus} соответствует статусу {convertResult.Result}");
        }
    }
}
