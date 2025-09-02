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
    [Table("products")]
    public class Product : UserModel
    {
        // Fields
        private string _name;
        private decimal _stock;
        private int _unitId;
        private decimal _price;
        private decimal _discount;
        private int _categoryId;

        // Model variables and data checks

        [Column("name")]
        [MaxLength(100)]
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

        [Column("stock", TypeName = "decimal(10,2)")]
        public decimal Stock // cant be lower than 0
        {
            get => _stock;
            set
            {
                if (_stock != value && value >= 0)
                {
                    _stock = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("unit_id")]
        public int UnitId // can be chosen only from available units
        {
            get => _unitId;
            set
            {
                if (_unitId != value)
                {
                    _unitId = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("price", TypeName = "decimal(10,2)")]
        public decimal Price // cant be lower than 0
        {
            get => _price;
            set
            {
                if (_price != value && value >= 0)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("discount", TypeName = "decimal(3,2)")]
        public decimal Discount // should be in range between 0 and 1
        {
            get => _discount;
            set
            {
                if (_discount != value && value >= 0 && value <= 1)
                {
                    _discount = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("category_id")]
        public int CategoryId // can be chosen only from available units
        {
            get => _categoryId;
            set
            {
                if (_categoryId != value)
                {
                    _categoryId = value;
                    OnPropertyChanged();
                }
            }
        }

        // Relationships
        public Category Category { get; set; }
        public Unit Unit { get; set; }
    }
}
