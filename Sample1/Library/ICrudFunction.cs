using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample1.Library;

public interface ICrudFunction<in TModelCreate, TModel> where TModel : TModelCreate
{

    Task<ActionResult<List<TModel>>> ReadAllAsync(HttpRequest req, int limit = int.MaxValue,
        CancellationToken cancellationToken = default);

    Task<ActionResult<TModel>> CreateAndReturnAsync(HttpRequest req, TModelCreate item, CancellationToken cancellationToken = default);


    Task<ActionResult<TModel>> CreateWithSpecifiedIdAndReturnAsync(HttpRequest req, string id, TModelCreate item,
        CancellationToken cancellationToken = default);


    Task<ActionResult<TModel>> ReadAsync(HttpRequest req, string id, CancellationToken cancellationToken = default);


    Task<ActionResult<TModel>> UpdateAndReturnAsync(HttpRequest req, string id, TModel item,
        CancellationToken cancellationToken = default);


    Task<IActionResult> DeleteAsync(HttpRequest req, string id, CancellationToken cancellationToken = default);


    Task<IActionResult> DeleteAllAsync(HttpRequest req, CancellationToken cancellationToken = default);

}