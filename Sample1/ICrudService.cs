namespace Sample1;

public interface ICrudService<in TModelCreate, TModel> where TModel : TModelCreate
{
    Task<IValueResult<List<TModel>>> ReadAllAsync(int limit = int.MaxValue, CancellationToken cancellationToken = default);

    Task<IValueResult<TModel>> CreateAndReturnAsync(TModelCreate item, CancellationToken cancellationToken = default);

    Task<IValueResult<TModel>> CreateWithSpecifiedIdAndReturnAsync(string id, TModelCreate item, CancellationToken cancellationToken = default);

    Task<IValueResult<TModel>> ReadAsync(string id, CancellationToken cancellationToken = default);

    Task<IValueResult<TModel>> UpdateAndReturnAsync(string id, TModel item, CancellationToken cancellationToken = default);

    Task<IResult> DeleteAsync(string id, CancellationToken cancellationToken = default);

    Task<IResult> DeleteAllAsync(CancellationToken cancellationToken = default);
}