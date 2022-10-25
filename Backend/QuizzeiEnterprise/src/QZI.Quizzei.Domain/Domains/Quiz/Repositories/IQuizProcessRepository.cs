﻿using System;
using System.Threading.Tasks;
using QZI.Quizzei.Domain.Domains.Quiz.Entities;
using QZI.Quizzei.Domain.Domains.Quiz.Repositories.Base;

namespace QZI.Quizzei.Domain.Domains.Quiz.Repositories
{
    public interface IQuizProcessRepository : IRepository<QuizProcess>
    {
        Task<QuizProcess> GetQuizProcessById(Guid id);
    }
}
