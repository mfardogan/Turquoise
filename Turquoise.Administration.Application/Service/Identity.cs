﻿using System;

namespace Turquoise.Administration.Application.Service
{
    using Turquoise.Administration.Domain.Abstraction;

    public sealed class Identity : IIdentity
    {
        Guid? IIdentity.AdministratorId => throw new NotImplementedException();

        Guid? IIdentity.DoctorId => throw new NotImplementedException();
    }
}