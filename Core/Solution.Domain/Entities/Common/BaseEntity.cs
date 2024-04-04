﻿namespace Solution.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
    }
}
