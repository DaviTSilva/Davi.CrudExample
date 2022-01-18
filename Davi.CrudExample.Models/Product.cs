using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Davi.CrudExample.Models
{
    public class Product : BaseEntity
    {
        #region Properties

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Column(TypeName = "varchar(150)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ImgLink { get; set; }

        [Column]
        public Category Category { get; set; }
        public long CategoryId { get; set; }

        #endregion

        #region Constructors

        public Product(long id, string name, double price, string description, string imgLink, long categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            ImgLink = imgLink;
            CategoryId = categoryId;
        }

        public Product()
        {
            Id = 0;
        }

        #endregion

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: R${Math.Round(Price,2)}, Description: {Description}, Image Link: {ImgLink}, Category: {Category?.Name}";
        }
    }
}
