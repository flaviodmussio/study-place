using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manage.Place.Domain.Events
{
    public interface IDomainNotificationHandler
    {
        void AddErrorMessages(List<ValidationFailure> errorMessage);

        List<ErrorResponseModel> GetErrors();

        bool HasError();

        void AddErrorMessage(string error);
    }
}
