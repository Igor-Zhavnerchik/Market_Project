using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.Models
{
    [Table("units_of_measure")]
    public class Unit : UserModel
    {
        // Fields
        private string _name;
        private string _fullName;
        private bool _isDivisible;

        //Model variables and data checks
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

        // Relationships
        public ICollection<Product> Products { get; set; }
    }
}
