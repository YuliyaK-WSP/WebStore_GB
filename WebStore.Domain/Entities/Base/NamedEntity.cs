using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Domain.Entities.Base.Interface;

namespace WebStore.Domain.Entities.Base
{
    public abstract class NamedEntity:Entity,INamedEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
