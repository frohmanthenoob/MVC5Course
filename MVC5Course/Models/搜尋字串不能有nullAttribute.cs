using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class 搜尋字串不能有nullAttribute: DataTypeAttribute
    {
        public 搜尋字串不能有nullAttribute() : base(DataType.Text)
        {
            this.ErrorMessage = "商品名稱不能有null字串";
        }
        public override bool IsValid(object value)
        {
            string str = Convert.ToString(value);
            if (str.Contains("null"))
            {
                return false;
            }
            return true;
        }

    }
}