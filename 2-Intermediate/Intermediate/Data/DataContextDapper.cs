using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Intermediate.Data;

public class DataContextDapper
{
    private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false; User Id=sa;Password=Hello123;";

    public IEnumerable<T> LoadData<T>(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_connectionString);
        return dbConnection.Query<T>(sql);
    }

    public T LoadDataSingle<T>(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_connectionString);
        return dbConnection.QuerySingle<T>(sql);
    }

    public bool ExecuteSql(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_connectionString);
        return (dbConnection.Execute(sql) > 0);
    }

    public int ExecuteSqlWithRowCount(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(_connectionString);
        return dbConnection.Execute(sql);
    }
}