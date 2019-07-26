using Manage.Place.Application.Tests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manage.Place.Application.Tests
{
    public abstract class ApplicationTestBase
    {
        protected Fake Fake { get; } = new Fake();
    }
}
