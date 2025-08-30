using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganjBlog.Core.Domain.Content
{
    [Table("Posts")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Post
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public required string Slug { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [MaxLength(500)]
        public string? Thumbnail { get; set; }

        public string? Content { get; set; }

        [Required]
        public Guid AuthorUserId { get; set; }

        [MaxLength(128)]
        public string? Source { get; set; }

        [MaxLength(250)]
        public string? Tags { get; set; }

        [MaxLength(160)]
        public string? SeoDescription { get; set; }

        public int ViewCount { get; set; } = 0;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime? DateModified { get; set; }

        public bool IsPaid { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")]
        public decimal RoyaltyAmount { get; set; } = 0;

        public PostStatus Status { get; set; } = PostStatus.Draft;

        //// Navigation Properties
        //[ForeignKey(nameof(CategoryId))]
        //public virtual Category? Category { get; set; }

        //[ForeignKey(nameof(AuthorUserId))]
        //public virtual User? Author { get; set; }

        //// Collection Navigation Properties
        //public virtual ICollection<PostTag>? PostTags { get; set; }
        //public virtual ICollection<Comment>? Comments { get; set; }
    }

    public enum PostStatus
    {
        Draft = 1,
        Canceled = 2,
        WaitingForApproval = 3,
        Rejected = 4,
        WaitingForPublish = 5,
        Published = 6
    }
}