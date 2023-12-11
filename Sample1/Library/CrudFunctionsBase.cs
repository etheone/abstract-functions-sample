using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Sample1.Library.Result;

namespace Sample1.Library;

public abstract class CrudFunctions<TModelCreate, TModel> : ICrudFunction<TModelCreate, TModel>
    where TModel : TModelCreate
{
    protected CrudFunctions(ICrudService<TModelCreate, TModel> crudService)
    {
        CrudService = crudService;
    }

    public ICrudService<TModelCreate, TModel> CrudService { get; }

    [Function("ReadAllAsync")]
    public async Task<ActionResult<List<TModel>>> ReadAllAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "")] HttpRequest req, int limit = int.MaxValue, CancellationToken cancellationToken = default)
    {
        var result = await CrudService.ReadAllAsync(limit, cancellationToken);
        return result.ToResponse();
    }


    [Function("CreateAndReturnAsync")]
    public async Task<ActionResult<TModel>> CreateAndReturnAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "")] HttpRequest req, TModelCreate item, CancellationToken cancellationToken = default)
    {
        var result = await CrudService.CreateAndReturnAsync(item, cancellationToken);
        return result.ToResponse();
    }

    [Function("CreateWithSpecifiedIdAndReturnAsync")]
    public async Task<ActionResult<TModel>> CreateWithSpecifiedIdAndReturnAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "{id}")] HttpRequest req, string id, TModelCreate item, CancellationToken cancellationToken = default)
    {
        var result = await CrudService.CreateWithSpecifiedIdAndReturnAsync(id, item, cancellationToken);
        return result.ToResponse();
    }

    [Function("ReadAsync")]
    public async Task<ActionResult<TModel>> ReadAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "{id}")] HttpRequest req, string id, CancellationToken cancellationToken = default)
    {
        var result = await CrudService.ReadAsync(id, cancellationToken);
        return result.ToResponse();
    }

    [Function("UpdateAndReturnAsync")]
    public async Task<ActionResult<TModel>> UpdateAndReturnAsync([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "{id}")] HttpRequest req, string id, TModel item, CancellationToken cancellationToken = default)
    {

        var result = await CrudService.UpdateAndReturnAsync(id, item, cancellationToken);
        return result.ToResponse();
    }

    [Function("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "{id}")] HttpRequest req, string id, CancellationToken cancellationToken = default)
    {
        var result = await CrudService.DeleteAsync(id, cancellationToken);
        return result.ToResponse();
    }

    [Function("DeleteAllAsync")]
    public async Task<IActionResult> DeleteAllAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "")] HttpRequest req, CancellationToken cancellationToken = default)
    {
        var result = await CrudService.DeleteAllAsync(cancellationToken);
        return result.ToResponse();
    }
}