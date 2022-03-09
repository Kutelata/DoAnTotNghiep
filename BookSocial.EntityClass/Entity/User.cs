namespace BookSocial.EntityClass.Entity
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string Friend { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }
    }
}
