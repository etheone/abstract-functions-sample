using Microsoft.AspNetCore.Http.Features;
using Sample1.Library;
using Sample1.Library.Result;
using Sample1.Models;

namespace Sample1;

public class FooService : ICrudService<FooCreate, Foo>
{
    public List<Foo> Items { get; set; } = new List<Foo>()
    {
        new Foo
        {
            Id = Guid.Parse("013F3C65-943F-4CB9-B7F3-681EFB499443").ToString(), Bar = "One"
        },
        new Foo
        {
            Id = Guid.NewGuid().ToString(), Bar = "Two"
        },
        new Foo
        {
            Id = Guid.NewGuid().ToString(), Bar = "Three"
        },    new Foo
        {
            Id = Guid.NewGuid().ToString(), Bar = "Four"
        }
    };

    public async Task<IValueResult<List<Foo>>> ReadAllAsync(int limit = Int32.MaxValue, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(Items.ToResult());
    }

    public async Task<IValueResult<Foo>> CreateAndReturnAsync(FooCreate item, CancellationToken cancellationToken = default)
    {
        var createdItem = new Foo
        {
            Bar = item.Bar,
            Id = Guid.NewGuid().ToString()
        };

        Items.Add(createdItem);

        return await Task.FromResult(createdItem.ToResult());
    }

    public async Task<IValueResult<Foo>> CreateWithSpecifiedIdAndReturnAsync(string id, FooCreate item, CancellationToken cancellationToken = default)
    {
        Guid.TryParse(id, out var guid);
        if (guid == Guid.Empty) throw new ArgumentException("Expected id to be convertible to a guid", nameof(id));

        var createdItem = new Foo
        {
            Bar = item.Bar,
            Id = Guid.NewGuid().ToString()
        };

        Items.Add(createdItem);

        return await Task.FromResult(createdItem.ToResult());
    }

    public async Task<IValueResult<Foo>> ReadAsync(string id, CancellationToken cancellationToken = default)
    {
        var item = Items.FirstOrDefault(x => x.Id == id);
        return await Task.FromResult(item.ToResult());
    }

    public async Task<IValueResult<Foo>> UpdateAndReturnAsync(string id, Foo item, CancellationToken cancellationToken = default)
    {
        var existingItem = Items.FirstOrDefault(x => x.Id == id);
        if (existingItem == null) throw new ArgumentException("No item found", nameof(id));
        existingItem.Bar = item.Bar;
        return await Task.FromResult(existingItem.ToResult());
    }

    public async Task<IResult> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var index = Items.FindIndex(x => x.Id == id);
        if (index != -1)
            Items.RemoveAt(index);

        return await Task.FromResult(new Result());
    }

    public async Task<IResult> DeleteAllAsync(CancellationToken cancellationToken = default)
    {
        Items.Clear();
        return await Task.FromResult(new Result());
    }
}