using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Davi.CrudExample.Models
{
    public class Category : BaseEntity
    {
        #region Properties

        [Column(TypeName ="varchar(25)")]
        public string Name { get; set; }

        #endregion

        #region Contructors

        public Category(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public Category()
        {
            Id = 0;
        }

        #endregion
    }

}
