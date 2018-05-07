﻿using System.Collections.Generic;
using System.Data.SqlClient;
using OrmBenchmark.Core;

namespace OrmBenchmark.Ado
{
    public class PureAdoExecuter : IOrmExecuter
    {
        private SqlConnection conn;

        public string Name => "ADO (Pure)";

        public void Init(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public IPost GetItemAsObject(int id)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"select * from Posts where Id = @Id";
            var idParam = cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int);
            idParam.Value = id;

            Post obj;
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();
                obj = new Post
                {
                    Id = reader.GetInt32(0),
                    Text = reader.GetNullableString(1),
                    CreationDate = reader.GetDateTime(2),
                    LastChangeDate = reader.GetDateTime(3),
                    Counter1 = reader.GetNullableValue<int>(4),
                    Counter2 = reader.GetNullableValue<int>(5),
                    Counter3 = reader.GetNullableValue<int>(6),
                    Counter4 = reader.GetNullableValue<int>(7),
                    Counter5 = reader.GetNullableValue<int>(8),
                    Counter6 = reader.GetNullableValue<int>(9),
                    Counter7 = reader.GetNullableValue<int>(10),
                    Counter8 = reader.GetNullableValue<int>(11),
                    Counter9 = reader.GetNullableValue<int>(12),
                };
            }

            return obj;
        }

        public IList<IPost> GetAllItemsAsObject()
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"select * from Posts";

            List<IPost> list = new List<IPost>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Post obj = new Post
                    {
                        Id = reader.GetInt32(0),
                        Text = reader.GetNullableString(1),
                        CreationDate = reader.GetDateTime(2),
                        LastChangeDate = reader.GetDateTime(3),
                        Counter1 = reader.GetNullableValue<int>(4),
                        Counter2 = reader.GetNullableValue<int>(5),
                        Counter3 = reader.GetNullableValue<int>(6),
                        Counter4 = reader.GetNullableValue<int>(7),
                        Counter5 = reader.GetNullableValue<int>(8),
                        Counter6 = reader.GetNullableValue<int>(9),
                        Counter7 = reader.GetNullableValue<int>(10),
                        Counter8 = reader.GetNullableValue<int>(11),
                        Counter9 = reader.GetNullableValue<int>(12),
                    };

                    list.Add(obj);
                }
            }

            return list;
        }

        public void Finish()
        {
            conn.Close();
        }
    }
}
