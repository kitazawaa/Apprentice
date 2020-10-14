using System;

namespace Entity
{
    public class Users
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime StartedOn { get; set; }

        public DateTime ExpiredOn { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}
