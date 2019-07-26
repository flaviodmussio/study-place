using Manage.Place.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manage.Place.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public EEntityStatus Status { get; protected set; }

        public virtual void Inactivate() => Status = EEntityStatus.Deleted;

        public virtual void Activate() => Status = EEntityStatus.Active;
    }
}
