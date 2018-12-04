using System;

namespace Gv1WebApi.Models
{
    public class UserAlerts
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime createdAt { get; set; }
    }
}