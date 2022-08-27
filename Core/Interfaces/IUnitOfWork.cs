using System;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //ICourseRepository Courses { get; }
        //IAuthorRepository Authors { get; }
        IIssueRepository Issues { get; }
        int Complete();
    }
}