﻿using System.Data.SqlClient;
using Highway.Data;

// ReSharper disable CheckNamespace
namespace ProvenStyle.DemoWebApi.Data
{
    public class DeletePersonAdvancedCommand : AdvancedCommand
    {
        public DeletePersonAdvancedCommand(int id)
        {
            ContextQuery = c =>
                {
                    const string sql = "Delete Person where id = @p0";                    
                    c.ExecuteSqlCommand(sql, new SqlParameter("@p0", id));                    
                };
        }
    }
}
