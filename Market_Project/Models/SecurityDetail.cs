using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_Project.Models
{
    [Table("security_details")]
    public class SecurityDetail : SystemModel
    {
        private string? _login;
        private string? _password;
        private bool _hasAccess;
        private DateTime _updatedAt;
        private int? _updatedBy;
        private DateTime _lastLogin;

        [Column("staff_id")]
        public int StaffId // generates automatically, cant be changed
        {
            get;
            set;
        }

        [Column("login")]
        public string? Login // cant be empty
        {
            get => _login;
            set
            {
                if (_login != value && !value.IsNullOrEmpty())
                {
                    _login = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("password")]
        public string? Password // cant be empty
        {
            get => _password;
            set
            {
                if (_password != value && !value.IsNullOrEmpty())
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("has_access")]
        public bool HasAccess // cant be changed directly
        {
            get => _hasAccess;
            set
            {
                if (_hasAccess != value)
                {
                    _hasAccess = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("updated_at")]
        public DateTime UpdatedAt // generates automatically
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
        public int? UpdatedBy // generates automatically
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


        [Column("last_login")]
        public DateTime LastLogin // generates automatically
        {
            get => _lastLogin;
            set
            {
                if (_lastLogin != value)
                {
                    _lastLogin = value;
                    OnPropertyChanged();
                }
            }
        }

        // Relationships
        public Staff Staff { get; set; }
    }
}
