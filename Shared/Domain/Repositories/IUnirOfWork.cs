﻿namespace catchupcomplete.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync(); 
}