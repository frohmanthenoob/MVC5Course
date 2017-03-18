namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public partial class ProductMetaData
    {
        public int ProductId { get; set; }
        [搜尋字串不能有null]
        [Required(ErrorMessage = "XXX")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "OOO")]
        [Range(1, 100, ErrorMessage = "價錢OO")]
        [DisplayFormat(DataFormatString = "NT$ {0:N0}")]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<decimal> Stock { get; set; }
        public bool isDeleted { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
