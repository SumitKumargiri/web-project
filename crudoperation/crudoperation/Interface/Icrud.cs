using crudoperation.Model;

namespace crudoperation.Interface
{
    public interface Icrud
    {
        Task<ResultModel<object>> Getcrud();
        Task<ResultModel<object>> InsertCrud(Crud model);
        Task<ResultModel<object>> UpdateCrud(Crud model);
        Task<ResultModel<object>> DeleteCrud(int id);
    }
}
