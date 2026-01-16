using SharedKernel.Domain.Entities;

namespace Main.Domian.Entities;

public partial class test_table : BaseAuditableEntity
{
    public test_table () : base()
    {

    }

    public string ma {  get; set; }
    public string ten { get; set; }
}
