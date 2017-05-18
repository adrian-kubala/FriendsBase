using System.Data;
using System.Data.SqlClient;

namespace FriendsBase
{
    class SqlExecutor
    {
        private SqlConnection connection = new SqlConnection(Properties.Resources.socialMediaConnectionString);
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;

        public int id = 0;

        public DataTable Select(string commandText)
        {
            DataTable table = new DataTable();

            command = new SqlCommand(commandText, connection);
            dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(table);

            return table;
        }

        public void InsertFriend(string name, string lastName)
        {
            command = new SqlCommand(Properties.Resources.insertZnajomy, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@lastName", lastName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            id = 0;
        }

        public void UpdateFriend(string name, string lastName)
        {
            command = new SqlCommand(Properties.Resources.updateZnajomy, connection);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@lastName", lastName);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            id = 0;
        }

        internal bool Delete()
        {
            if (id != 0)
            {
                command = new SqlCommand("DELETE Znajomy where Id_znajomego = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
