using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lap2.Models
{
    public class Address
    {
        [Key]
        public int Addr_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Home_addr { get; set; }

        [Required]
        [StringLength(50)]
        public string Office_addr { get; set; }

        public ICollection<Client> Clients { get; set; }
    }

    public class Client
    {
        [Key]
        [StringLength(50)]
        public string clientName { get; set; }

        [Required]
        public int Address_ID { get; set; }

        [ForeignKey("Address_ID")]
        public Address Address { get; set; }

        [Required]
        [StringLength(10)]
        public string phoneNo { get; set; }
    }

    public class NhanVien
    {
        [Key]
        [StringLength(9)]
        public string MANV { get; set; }

        [Required]
        [StringLength(15)]
        public string HONV { get; set; }

        [Required]
        [StringLength(15)]
        public string TENLOT { get; set; }

        [Required]
        [StringLength(15)]
        public string TENNV { get; set; }

        [Required]
        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(30)]
        public string DCHI { get; set; }

        [Required]
        [StringLength(3)]
        public string PHAI { get; set; }

        [Required]
        public float LUONG { get; set; }

        [StringLength(9)]
        public string MA_NQL { get; set; }

        public int PHG { get; set; }

        public ICollection<ThanNhan> ThanNhans { get; set; }
    }

    public class ThanNhan
    {
        [Key, Column(Order = 0)]
        [StringLength(9)]
        public string MA_NVIEN { get; set; }

        [ForeignKey("MA_NVIEN")]
        public NhanVien NhanVien { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [StringLength(15)]
        public string TENTN { get; set; }

        [Required]
        [StringLength(3)]
        public string PHAI { get; set; }

        [Required]
        public DateTime NGSINH { get; set; }

        [Required]
        [StringLength(15)]
        public string QUANHE { get; set; }
    }
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
    }

    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<PersonCompany> PersonCompanies { get; set; }
    }

    public class PersonCompany
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FromYear { get; set; }

        public int? ToYear { get; set; }

        public bool Current { get; set; }

        [MaxLength(50)]
        public string Position { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}
