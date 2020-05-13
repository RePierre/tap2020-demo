using System;

namespace Uaic.Tap2020Demo.Core.Identity
{
    public class Role : IEntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
