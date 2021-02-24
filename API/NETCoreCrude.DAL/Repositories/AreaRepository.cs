using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NETCoreCrude.DAL.Repositories
{
    using NETCoreCrude.Base;
    using NETCoreCrude.DAL.Models;

    /// <summary>
    ///
    /// </summary>
    public class AreaRepository
        : IAreaRepository
    {
        /// <summary>
        ///
        /// </summary>
        internal readonly IOptions<Base.Settting.AppConnectionStrings> _Connection;

        /// <summary>
        ///
        /// </summary>
        /// <param name="pConnection"></param>
        public AreaRepository(IOptions<Base.Settting.AppConnectionStrings> pConnection)
        {
            _Connection = pConnection;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Area> GetList()
        {
            var varResult = new List<Area>();
            using (SqlConnection varSqlConnection = new SqlConnection(_Connection.Value.DefaultConnection))
            {
                try
                {
                    varSqlConnection.Open();
                    SqlCommand varSqlCommand = new SqlCommand("dbo.zSp_GetListArea", varSqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    using (SqlDataReader varSqlDataReader = varSqlCommand.ExecuteReader())
                    {
                        while (varSqlDataReader.Read())
                        {
                            varResult.Add(new Area()
                            {
                                AreaID = varSqlDataReader.GetInt32(0),
                                Name = varSqlDataReader.GetString(1)
                            });
                        }
                        return varResult;
                    }
                }
                catch (Exception varException)
                {
                    throw new AppFailure<DocumentTypeRepository>("Failure in IEnumerable<Area> GetList() Exception: " + varException.Message);
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