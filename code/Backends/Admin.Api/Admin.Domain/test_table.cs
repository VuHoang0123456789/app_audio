using SharedKernel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain;

public class test_table : BaseAuditableEntity
{
    public string ma {  get; set; }
    public string ten { get; set; }
}
