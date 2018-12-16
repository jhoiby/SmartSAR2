using SmartSAR.BC.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

// For an excellent article on DDD base classes see
// https://github.com/dotnet/docs/blob/master/docs/standard/microservices-architecture/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces.md
// Much of this class is based on the examples there.

namespace SmartSAR.BC.Common.Bases
{
    public abstract class EntityBase : IEntity
    {
        private Guid _id;

        public EntityBase()
        {
            _id = Guid.NewGuid();
        }

        public Guid Id
        {
            get { return _id; }
            protected set { _id = value; }
        }
    }
}
