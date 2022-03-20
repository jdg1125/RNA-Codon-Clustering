using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace RNACodonClustering
{
    public class DatabaseConnector
    {
        private MySqlConnection _connection;
        private MySqlCommand _saveCommand;
        private StringBuilder _commandBuilder = new StringBuilder();

        public bool TryOpenConnection(string userId, string password)
        {
            try
            {
                var connBuilder = new MySqlConnectionStringBuilder();
                connBuilder.Add("Database", "Results_MakeCluster_Algorithm");
                connBuilder.Add("Data Source", "localhost");
                connBuilder.Add("User Id", $"{userId}");
                connBuilder.Add("Password", $"{password}");  
                _connection = new MySqlConnection(connBuilder.ConnectionString);
                _saveCommand = _connection.CreateCommand();
                _connection.Open();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public void PrintValues(int index, List<string>[] clusters, double objectiveFuncResult)
        {
            AddIndexToSaveCommand(index);
            AddClustersToSaveCommand(clusters);
            AddFunctionResultToSaveCommand(objectiveFuncResult);
            Console.WriteLine( _commandBuilder.ToString());
        }

        public void SaveClusters(int index, List<string>[] clusters, double objectiveFuncResult)
        {
            AddIndexToSaveCommand(index);
            AddClustersToSaveCommand(clusters);
            AddFunctionResultToSaveCommand(objectiveFuncResult);
            _saveCommand.CommandText = _commandBuilder.ToString();
            _saveCommand.ExecuteNonQuery();
        }

        private void AddIndexToSaveCommand(int index)
        {
            _commandBuilder.Append("INSERT INTO Finished_Clusters VALUES (");
            _commandBuilder.Append(index.ToString() + ", ");
        }

        private void AddClustersToSaveCommand(List<string>[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                var clusters = ListToString(list[i]);
                _commandBuilder.Append(clusters + ",");
            }
        }

        private void AddFunctionResultToSaveCommand(double functionResult)
        {
            _commandBuilder.Append(functionResult + ");");
        }

        private string ListToString(List<string> cluster)
        {
            var concat = new StringBuilder();
            concat.Append("'");
            foreach (string s in cluster)
                concat.Append(s + ":");
            concat.Append("'");
            return concat.ToString();
        }
    }
}
