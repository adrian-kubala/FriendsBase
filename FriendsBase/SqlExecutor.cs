using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FriendsBase
{
    class SqlExecutor
    {
        public SqlConnection connection = new SqlConnection(Properties.Resources.socialMediaConnectionString);
        private SqlCommand command;
        private SqlDataAdapter dataAdapter;

        public int id = 0;

        public SqlCommand GetCommand()
        {
            return command;
        }

        public SqlDataAdapter GetAdapter()
        {
            return dataAdapter;
        }

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

    }
}
