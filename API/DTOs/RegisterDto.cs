using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDto
    {
        private string _knownAs = default;

        [Required] public string Username { get; set; }

        public string KnownAs { 
            get => string.IsNullOrEmpty(_knownAs) ? Username : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_knownAs);
            set => _knownAs = value;
        }

        [Required] public string Gender { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
