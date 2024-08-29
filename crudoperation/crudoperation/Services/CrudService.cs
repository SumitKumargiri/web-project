using crudoperation.Interface;
using crudoperation.Model;
using crudoperation.utility;
using Dapper;
using System;
namespace crudoperation.Services
{
    public class CrudService : Icrud
    {
        private readonly DBGateway _DBGateway;

        public CrudService(string connection)
        {
            _DBGateway = new DBGateway(connection);
        }

        public async Task<ResultModel<object>> Getcrud()
        {
            ResultModel<object> result = new ResultModel<object>();
            try
            {
                var employees = await _DBGateway.ExeQueryList<Crud>("SELECT * FROM crud", null);

                if (employees != null)
                {
                    result.Message = "Employees retrieved successfully";
                    result.Model = employees;
                }
                else
                {
                    result.Message = "No employees found";
                }
            }
            catch (Exception ex)
            {
                result.Message = $"Error while retrieving employees: {ex.Message}";
            }
            return result;
        }


        public async Task<ResultModel<object>> InsertCrud(Crud model)
        {
            try
            {
                var query = "INSERT INTO Crud (name, email, country) VALUES (@Name, @Email, @Country)";
                var parameters = new DynamicParameters();
                parameters.Add("@Name", model.name);
                parameters.Add("@Email", model.email);
                parameters.Add("@Country", model.country);

                var result = await _DBGateway.ExecuteAsync(query, parameters);

                if (result > 0)
                {
                    return new ResultModel<object>
                    {
                        Success = true,
                        Message = "Record inserted successfully",
                        
                    };
                }
                else
                {
                    return new ResultModel<object>
                    {
                        Success = false,
                        Message = "Failed to insert record"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }



        }
        public async Task<ResultModel<object>> UpdateCrud(Crud model)
        {
            try
            {
                var query = "UPDATE Crud SET name = @Name, email = @Email, country = @Country WHERE id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", model.id);
                parameters.Add("@Name", model.name);
                parameters.Add("@Email", model.email);
                parameters.Add("@Country", model.country);

                var result = await _DBGateway.ExecuteAsync(query, parameters);

                if (result > 0)
                {
                    return new ResultModel<object>
                    {
                        Success = true,
                        Message = "Record updated successfully",
                    };
                }
                else
                {
                    return new ResultModel<object>
                    {
                        Success = false,
                        Message = "Failed to update record"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }

        public async Task<ResultModel<object>> DeleteCrud(int id)
        {
            try
            {
                var query = "DELETE FROM Crud WHERE id = @Id";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = await _DBGateway.ExecuteAsync(query, parameters);

                if (result > 0)
                {
                    return new ResultModel<object>
                    {
                        Success = true,
                        Message = "Record deleted successfully"
                    };
                }
                else
                {
                    return new ResultModel<object>
                    {
                        Success = false,
                        Message = "Failed to delete record"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel<object>
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
    }
}
