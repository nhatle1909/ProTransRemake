using System.Globalization;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CreatedDate { get; set; } = DateTime.Now.ToString("d", new CultureInfo("vi-VN"));

        public Guid? CreatedBy { get; set; }

        public string ModifiedDate { get; set; } = DateTime.Now.ToString("d", new CultureInfo("vi-VN"));

        public Guid? ModifiedBy { get; set; }

        public string DeletedDate { get; set; } = DateTime.Now.ToString("d", new CultureInfo("vi-VN"));

        public Guid? DeletedBy { get; set; }

        public bool? IsDeleted { get; set; } = false;
    }
}
