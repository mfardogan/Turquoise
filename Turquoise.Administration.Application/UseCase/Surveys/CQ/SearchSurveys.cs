﻿using MediatR;

namespace Turquoise.Administration.Application.UseCase.Surveys.CQ
{
    using Turquoise.Administration.Domain.Aggregation.Common;
    using Turquoise.Administration.Application.UseCase.Surveys.DTO;
    public sealed class SearchSurveys : IRequest<SurveyViewModel[]>
    {
        public Pagination Pagination { get; set; }
        public SurveyViewModel Filters { get; set; }
    }
}
