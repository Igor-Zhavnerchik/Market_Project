using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.Models
{
    [Table("categories")]
    public class Category : BaseModel
    {
        // Fields
        private int _id;
        private string? _name;
        private bool _isActive;
        private DateTime? _updatedAt;
        private int? _updatedBy;

        // Model variables and data checks
        [Key]
        [Column("id")]
        public int Id  // cant be changed
        {
            get => _id;
            set {  _id = value; OnPropertyChanged(); }
        }

        [Column("name")]
        [MaxLength(50)]
        public string? Name // cant be empty
        {
            get => _name;
            set
            {
                if (_name != value && !value.IsNullOrEmpty())
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("is_active")]
        public bool IsActive // can be changed only in checkbox
        {
            get => _isActive;
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } // cant be changed

        [Column("created_by")]
        public int CreatedBy { get; set; } // cant be changed

        [Column("updated_at")]
        public DateTime? UpdatedAt // cant be changed by user
        {
            get => _updatedAt;
            set
            {
                if (_updatedAt != value)
                {
                    _updatedAt = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("updated_by")]
        public int? UpdatedBy // cant be changed by user
        {
            get => _updatedBy;
            set
            {
                if (_updatedBy != value)
                {
                    _updatedBy = value;
                    OnPropertyChanged();
                }
            }
        }

        // Relationships
        public ICollection<Product> Products { get; set; }
    }
}
