using System.Data.SqlClient;



namespace csharp_biblioteca_db
{
    internal class DB
    {
        private static string stringaDiConnessione = "Data Source=localhost;Initial Catalog=biblioteca;Integrated Security=True;Pooling=False";


        private static SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(stringaDiConnessione);
                try
                { 
                    conn.Open();
                
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                return conn;
            
        }

        //internal static int libroAdd(Libro libro)
        //{

        //    //Devo collegarmi e inviare un comando per inserire uno scaffale
        //    var conn = Connect();
        //    if (conn == null)
        //    {
        //        throw new Exception("Unable to connect to Database");
        //    }

        //    //Inserisco lo scaffale nella tabella scaffali
        //    var cmd = String.Format("insert into Libri (scaffale) values ('{0}')", s1);

        //    using (SqlCommand insert = new SqlCommand(cmd, conn))
        //    {
        //        try
        //        {

        //            var numrows = insert.ExecuteNonQuery();
        //            return numrows;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //            return 0;
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //    }
        //}

        internal static int scaffaleAdd(string s1)
        {

            //Devo collegarmi e inviare un comando per inserire uno scaffale
            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Unable to connect to Database");
            }

            //Inserisco lo scaffale nella tabella scaffali
            var cmd = String.Format("insert into Scaffale (scaffale) values ('{0}')", s1);

            using (SqlCommand insert = new SqlCommand(cmd, conn))
            {
                try
                {

                    var numrows = insert.ExecuteNonQuery();
                    return numrows;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal static List<string> scaffaliGet()
        { 
            List<string> ls = new List<string>();

            var conn = Connect();
            if (conn == null)
            {
                throw new Exception("Unable to connect to Database");
            }

            //Inserisco lo scaffale nella tabella scaffali
            var cmd = String.Format("select scaffale from Scaffale");

            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    Console.WriteLine(reader.FieldCount);
                    while (reader.Read())
                    { 
                        ls.Add(reader.GetString(0));
                    }
                }
            }
            conn.Close();

            return ls;
        }

        internal static List<Tuple<int, string, string, string, string, string>> documentiGet()
        {
            var ld = new List<Tuple<int, string, string, string, string, string>>();
            var conn = Connect();
            if (conn == null)
                throw new Exception("Unable to connect to the dabatase");
            var cmd = String.Format("select codice, Titolo, Settore, Stato, Tipo, Scaffale from Documenti");  //Li prendo tutti
            using (SqlCommand select = new SqlCommand(cmd, conn))
            {
                using (SqlDataReader reader = select.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var data = new Tuple<Int32, string, string, string, string, string>(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5));
                        ld.Add(data);
                    }
                }
            }
            conn.Close();
            return ld;
        }
    }
}