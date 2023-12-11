using Microsoft.Extensions.Logging;
using Sample1.Library;
using Sample1.Models;

namespace Sample1.Functions;

public class FooFunctions : CrudFunctions<FooCreate, Foo>
{
    public FooFunctions(ICrudService<FooCreate, Foo> service) : base(service)
    {
    }
}