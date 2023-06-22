using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCleanArchitecture.Domain.Entities;
//public class Persona : AuditableEntity AuditableEntity no porque no tengo esos campos en la base}
public class Persona : BaseEntity
{
    public int DNI { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }
}
