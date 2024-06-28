namespace ACME.LearningCenter_Platform.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}