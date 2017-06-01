using Autofac;
using Calabonga.StateProcessor.Demo.Rules;
using Calabonga.StateProcessor.Demo.Statuses;
using Calabonga.StatusProcessor;

namespace Calabonga.StateProcessor.Demo
{
    public class DependencyContainer {

        internal static IContainer Initialize() {

            // Создаем построитель для контейнера
            var builder = new ContainerBuilder();

            // Регистрируем процессор обработки правил для Document
            builder.RegisterType<DocumentRuleProcessor>().AsSelf();

            // Регистрируем правила для сущности Document
            builder.RegisterType<DraftRule>().As<IStatusRule<Document, EntityStatus>>();
            builder.RegisterType<InValidationRule>().As<IStatusRule<Document, EntityStatus>>();
            builder.RegisterType<CompleteRule>().As<IStatusRule<Document, EntityStatus>>();

            // Регистрируем статусы для сущности Document
            builder.RegisterType<DraftStatus>().As<EntityStatus>();
            builder.RegisterType<InValidationStatus>().As<EntityStatus>();
            builder.RegisterType<CompleteStatus>().As<EntityStatus>();

            // Возвращаем готовый контейнер
            return builder.Build();
        }
    }
}