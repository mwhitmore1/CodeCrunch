namespace CodeCrunch.Core.Domain
{
    public class ProfilePicture
    {
        // Primary key.
        public int ProfilePictureId { get; set; }

        // Foreign key
        public string UserId { get; set; }

        // Other fields related to the model
        public byte[] Image { get; set; }

        // Relationships
        public virtual User User { get; set; }
    }
}