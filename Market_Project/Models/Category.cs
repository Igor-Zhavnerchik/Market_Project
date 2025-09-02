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
    public class Category : UserModel
    {
        // Fields
        private string? _name;
       
        // Model variables and data checks
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

        // Relationships
        public ICollection<Product> Products { get; set; }
    }
}
