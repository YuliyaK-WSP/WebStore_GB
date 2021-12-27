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
    [Index(nameof(Name),IsUnique = true)]
    public class Section : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        //public int? ParentId { get; set; } = null -- При наличии "?" у типа данных можно указать что поле может иметь нулевое значение
        public int? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]//--Внешний ключ
        public Section Parent { get; set; } //-- Навигационное свойство

        public ICollection<Product> Products { get; set; }
    }

}
