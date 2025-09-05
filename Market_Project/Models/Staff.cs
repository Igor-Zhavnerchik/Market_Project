using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.Models
{
    [Table("staff")]
    public class Staff : UserModel
    {
        // Fields
        private string? _name;
        private string? _lastName;
        private int _statusId;
        private int _positionId;
        private string _tel;
        private string _mail;


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

        [Column("last_name")]
        [MaxLength(50)]
        public string? LastName // cant be empty
        {
            get => _lastName;
            set
            {
                if (_lastName != value && !value.IsNullOrEmpty())
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("status_id")]
        public int StatusId // can be chosen only from available units
        {
            get => _statusId;
            set
            {
                if (_statusId != value)
                {
                    _statusId = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("position_id")]
        public int PositionId // can be chosen only from available units
        {
            get => _positionId;
            set
            {
                if (_positionId != value)
                {
                    _positionId = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("tel")]
        [MaxLength(20)]
        public string? Tel // cant be empty
        {
            get => _tel;
            set
            {
                if (_tel != value && !value.IsNullOrEmpty())
                {
                    _tel = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("mail")]
        [MaxLength(50)]
        public string? Mail // cant be empty
        {
            get => _mail;
            set
            {
                if (_mail != value && !value.IsNullOrEmpty())
                {
                    _mail = value;
                    OnPropertyChanged();
                }
            }
        }

        // Relationships
        SecurityDetail SecurityDetail { get; set; }
        Position Position { get; set; }
        Status Status { get; set; }

    }
}
