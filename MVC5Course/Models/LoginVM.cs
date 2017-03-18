using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class LoginVM : IValidatableObject
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string userPassword { get; set; }

        public bool loginCheck()
        {
            return this.userName == "will";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();

            if (!this.loginCheck())
            {
                yield return new ValidationResult("登入資料錯誤", new string[] { "userName" });
                yield break;
            }
            yield return ValidationResult.Success;
        }
    }
}