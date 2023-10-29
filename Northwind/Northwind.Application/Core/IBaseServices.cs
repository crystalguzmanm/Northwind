namespace Northwind.Application.Core
{
    public interface IBaseServices<TDtoAdd, TDtoUpdate, TDtoRemove>
    {
        ServiceResult GetAll();

        ServiceResult GetById(int id);

        ServiceResult Save(TDtoAdd dtoAdd);

        ServiceResult Update (TDtoUpdate dtoUpdate);

        ServiceResult Remove(TDtoRemove dtoRemove);
    }
}
