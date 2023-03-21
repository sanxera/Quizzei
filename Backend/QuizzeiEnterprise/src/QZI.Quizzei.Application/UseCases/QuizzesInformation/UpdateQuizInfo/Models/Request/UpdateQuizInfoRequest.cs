﻿namespace QZI.Quizzei.Application.UseCases.QuizzesInformation.UpdateQuizInfo.Models.Request;

public class UpdateQuizInfoRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; }
    public string ImageName { get; set; } = null!;
}