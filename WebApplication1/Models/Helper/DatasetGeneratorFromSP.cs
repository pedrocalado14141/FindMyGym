using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DatasetGeneratorFromSP
    {
        public DataSet ConsumeSP(string SPCommand, SqlParameter[] parameters, SqlConnection conn2)
        {
            var dataset = new DataSet();
            var adapter = new SqlDataAdapter();
            var command = new SqlCommand("EXECUTE dbo.SP_GetGym @id", conn2);
            command.Parameters.AddRange(parameters);
            adapter.SelectCommand = command;
            adapter.Fill(dataset);
            return dataset;
        } 
        
    }
}
