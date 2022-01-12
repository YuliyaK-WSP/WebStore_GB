using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base.Interface;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Domain.Entities
{
    //[Table("Свое название таблицы")]
    [Index(nameof(Name), IsUnique = true)]

    public class Brand : NamedEntity, IOrderedEntity
    {
       // [Column("Свое название столбца")]
        public int Order { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    
}
