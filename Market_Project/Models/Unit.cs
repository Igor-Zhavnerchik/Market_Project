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
    [Table("units_of_measure")]
    public class Unit : BaseModel
    {
        //changeable variables
        private string _name;
        private string _fullName;
        private bool _isDivisible;
        private bool _isActive;
        private DateTime? _updatedAt;
        private int? _updatedBy;

        //model variables and data checks
        [Key]
        [Column("id")]
        public int Id // cant be changed
        { 
            get;
            private set;
        }

        [Column("name")]
        [StringLength(5)]
        public string Name // cant be empty
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

        [Column("full_name")]
        [StringLength(15)]
        public string FullName // cant be empty
        {
            get => _fullName;
            set
            {
                if (_fullName != value && !value.IsNullOrEmpty())
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("is_divisible")]
        public bool IsDivisible // can be changed only in checkbox
        {
            get => _isDivisible;
            set
            {
                if (_isDivisible != value)
                {
                    _isDivisible = value;
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

        //relationships
        public ICollection<Product> Products { get; set; }
    }
}
