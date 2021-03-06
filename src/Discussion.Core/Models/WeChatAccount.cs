using System.ComponentModel.DataAnnotations.Schema;
using Discussion.Core.Models.UserAvatar;

namespace Discussion.Core.Models
{
    public class WeChatAccount : Entity, IAuthor
    {
        public int UserId { get; set; }
        
        public string WxId { get; set; }
        public string WxAccount { get; set; }

        [NotMapped]
        public string DisplayName => NickName;
        public string NickName { get; set; }

        [ForeignKey("AvatarFileId")]
        public FileRecord AvatarFile { get; set; }
        public int? AvatarFileId { get; set; }

        public IUserAvatar GetAvatar()
        {
            if (AvatarFileId == null)
            {
                return new DefaultAvatar();
            }

            return new StorageFileAvatar {StorageFileSlug = AvatarFile.Slug};
        }
    }
}