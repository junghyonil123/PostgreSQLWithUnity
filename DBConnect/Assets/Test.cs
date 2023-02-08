using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Npgsql;
using System;

public class Test : MonoBehaviour
{
    public void ConnectToDB()
    {
        using (var conn = new NpgsqlConnection("host=localhost;username=postgres;password=1234;database=DataTable"))
        {
            try
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText =
                        "SELECT * " +
                        "FROM public.\"Data\"";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Debug.Log(reader["temp1"].ToString());
                            //listBox1.Items.Add(reader.GetString(0));
                            //or listBox1.Items.Add(reader["table_name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }

    public void Start()
    {
        ConnectToDB();
    }
}
