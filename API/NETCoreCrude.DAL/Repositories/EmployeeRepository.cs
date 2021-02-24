using Microsoft.Extensions.Options;
using NETCoreCrude.Base;
using NETCoreCrude.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NETCoreCrude.DAL.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public class EmployeeRepository
        : IEmployeeRepository
    {
        /// <summary>
        ///
        /// </summary>
        private readonly IOptions<Base.Settting.AppConnectionStrings> _Connection;

        /// <summary>
        ///
        /// </summary>
        /// <param name="pConnection"></param>
        public EmployeeRepository(IOptions<Base.Settting.AppConnectionStrings> pConnection)
        {
            _Connection = pConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetList()
        {
            var varResult = new List<Employee>();
            using (SqlConnection varSqlConnection = new SqlConnection(_Connection.Value.DefaultConnection))
            {
                try
                {
                    varSqlConnection.Open();
                    SqlCommand varSqlCommand = new SqlCommand("dbo.zSp_GetListEmployee", varSqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    using (SqlDataReader varSqlDataReader = varSqlCommand.ExecuteReader())
                    {
                        while (varSqlDataReader.Read())
                        {
                            varResult.Add(new Employee()
                            {
                                EmployeeID = varSqlDataReader.GetInt32(0),
                                DocumentTypeID = varSqlDataReader.GetInt32(1),
                                DocumentNumber = varSqlDataReader.GetString(2),
                                Name = varSqlDataReader.GetString(3),
                                LastName = varSqlDataReader.GetString(4),
                                BirthDate = varSqlDataReader.GetDateTime(5),
                                AreaID = varSqlDataReader.GetInt32(6)
                            });
                        }
                        return varResult;
                    }
                }
                catch (Exception varException)
                {
                    throw new AppFailure<DocumentTypeRepository>("Failure in IEnumerable<Employee> GetList() Exception: " + varException.Message);
                }
                finally
                {
                    varSqlConnection.Close();
                    varSqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDocumentNumber"></param>
        /// <returns></returns>
        public Employee GetByDocumentNumber(string pDocumentNumber)
        {
            var varResult = new Employee();
            using (SqlConnection varSqlConnection = new SqlConnection(_Connection.Value.DefaultConnection))
            {
                try
                {
                    varSqlConnection.Open();
                    SqlCommand varSqlCommand = new SqlCommand("dbo.zSp_GetEmployeeByCode", varSqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    varSqlCommand.Parameters.AddWithValue("@pDocumentNumber", pDocumentNumber);
                    using (SqlDataReader varSqlDataReader = varSqlCommand.ExecuteReader())
                    {
                        while (varSqlDataReader.Read())
                        {
                            varResult = new Employee()
                            {
                                EmployeeID = varSqlDataReader.GetInt32(0),
                                DocumentTypeID = varSqlDataReader.GetInt32(1),
                                DocumentNumber = varSqlDataReader.GetString(2),
                                Name = varSqlDataReader.GetString(3),
                                LastName = varSqlDataReader.GetString(4),
                                BirthDate = varSqlDataReader.GetDateTime(5),
                                AreaID = varSqlDataReader.GetInt32(6)
                            };
                        }
                        return varResult;
                    }
                }
                catch (Exception varException)
                {
                    throw new AppFailure<DocumentTypeRepository>("Failure in Employee GetByCode(string pCode) Exception: " + varException.Message);
                }
                finally
                {
                    varSqlConnection.Close();
                    varSqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        public Employee Create(Employee pEmployee)
        {
            var varResult = new Employee();
            using (SqlConnection varSqlConnection = new SqlConnection(_Connection.Value.DefaultConnection))
            {
                try
                {
                    varSqlConnection.Open();
                    SqlCommand varSqlCommand = new SqlCommand("dbo.zSp_CreateEmployee", varSqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    varSqlCommand.Parameters.AddWithValue("@pDocumentTypeID", pEmployee.DocumentTypeID);
                    varSqlCommand.Parameters.AddWithValue("@pDocumentNumber", pEmployee.DocumentNumber);
                    varSqlCommand.Parameters.AddWithValue("@pName", pEmployee.Name);
                    varSqlCommand.Parameters.AddWithValue("@pLastName", pEmployee.LastName);
                    varSqlCommand.Parameters.AddWithValue("@pBirthDate", pEmployee.BirthDate);
                    varSqlCommand.Parameters.AddWithValue("@pAreaID", pEmployee.AreaID);

                    using (SqlDataReader varSqlDataReader = varSqlCommand.ExecuteReader())
                    {
                        while (varSqlDataReader.Read())
                        {
                            varResult.EmployeeID = varSqlDataReader.GetInt32(0);
                            varResult.DocumentTypeID = varSqlDataReader.GetInt32(1);
                            varResult.DocumentNumber = varSqlDataReader.GetString(2);
                            varResult.Name = varSqlDataReader.GetString(3);
                            varResult.LastName = varSqlDataReader.GetString(4);
                            varResult.BirthDate = varSqlDataReader.GetDateTime(5);
                            varResult.AreaID = varSqlDataReader.GetInt32(6);
                        }

                        return varResult;
                    }
                }
                catch (Exception varException)
                {
                    throw new AppFailure<DocumentTypeRepository>("Failure in Employee Create() Exception: " + varException.Message);
                }
                finally
                {
                    varSqlConnection.Close();
                    varSqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <param name="pEmployee"></param>
        /// <returns></returns>
        public Employee Update(int pEmployeeID, Employee pEmployee)
        {
            var varResult = new Employee();
            using (SqlConnection varSqlConnection = new SqlConnection(_Connection.Value.DefaultConnection))
            {
                try
                {
                    varSqlConnection.Open();
                    SqlCommand varSqlCommand = new SqlCommand("dbo.zSp_UpdateEmployee", varSqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    varSqlCommand.Parameters.AddWithValue("@pEmployeeID", pEmployeeID);
                    varSqlCommand.Parameters.AddWithValue("@pDocumentTypeID", pEmployee.DocumentTypeID);
                    varSqlCommand.Parameters.AddWithValue("@pDocumentNumber", pEmployee.DocumentNumber);
                    varSqlCommand.Parameters.AddWithValue("@pName", pEmployee.Name);
                    varSqlCommand.Parameters.AddWithValue("@pLastName", pEmployee.LastName);
                    varSqlCommand.Parameters.AddWithValue("@pBirthDate", pEmployee.BirthDate);
                    varSqlCommand.Parameters.AddWithValue("@pAreaID", pEmployee.AreaID);

                    using (SqlDataReader varSqlDataReader = varSqlCommand.ExecuteReader())
                    {
                        while (varSqlDataReader.Read())
                        {
                            varResult.EmployeeID = varSqlDataReader.GetInt32(0);
                            varResult.DocumentTypeID = varSqlDataReader.GetInt32(1);
                            varResult.DocumentNumber = varSqlDataReader.GetString(2);
                            varResult.Name = varSqlDataReader.GetString(3);
                            varResult.LastName = varSqlDataReader.GetString(4);
                            varResult.BirthDate = varSqlDataReader.GetDateTime(5);
                            varResult.AreaID = varSqlDataReader.GetInt32(6);
                        }

                        return varResult;
                    }
                }
                catch (Exception varException)
                {
                    throw new AppFailure<DocumentTypeRepository>("Failure in Employee Update(Employee pEmployee) Exception: " + varException.Message);
                }
                finally
                {
                    varSqlConnection.Close();
                    varSqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEmployeeID"></param>
        /// <returns></returns>
        public int Delete(int pEmployeeID)
        {
            var varResult = 0;
            using (SqlConnection varSqlConnection = new SqlConnection(_Connection.Value.DefaultConnection))
            {
                try
                {
                    varSqlConnection.Open();
                    SqlCommand varSqlCommand = new SqlCommand("dbo.zSp_DeleteEmployee", varSqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    varSqlCommand.Parameters.AddWithValue("@pEmployeeID", pEmployeeID);

                    using (SqlDataReader varSqlDataReader = varSqlCommand.ExecuteReader())
                    {
                        while (varSqlDataReader.Read())
                        {
                            varResult = varSqlDataReader.GetInt32(0);
                        }

                        return varResult;
                    }
                }
                catch (Exception varException)
                {
                    throw new AppFailure<DocumentTypeRepository>("Failure in int Delete(int pEmployeeID) Exception: " + varException.Message);
                }
                finally
                {
                    varSqlConnection.Close();
                    varSqlConnection.Dispose();
                }
            }
        }
    }
}