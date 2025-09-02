using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Market_Project.Services.Implementations;
using Market_Project.Services.Interfaces;

namespace Market_Project.Models
{
    public class UserModel : BaseModel
    {
        // Common fields
       
        private bool _isActive;
        private DateTime? _updatedAt;
        private int? _updatedBy;

        // Common Model variables and data checks
       
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

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(Id != 0  && !(propertyName is nameof(Id) or nameof(UpdatedBy) or nameof(UpdatedAt)))
            {
                UpdatedAt = DateTime.Now;
                UpdatedBy = App.ServiceProvider.GetRequiredService<IActiveUserContext>().Id;
            }
            base.OnPropertyChanged(propertyName);
        }
    }
}
