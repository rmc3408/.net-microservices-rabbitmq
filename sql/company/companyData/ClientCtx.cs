using System.Data.SqlClient;

namespace companyData
{
    public class ClientCtx : SQLServer
    {
        public void insertClientData(ClientDTO newClient) 
        {
            // Instantiate SQL Client
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = personalConnectionStringSQL;

            // Open Query commander
            SqlCommand comander = new SqlCommand();


            string SQL_Insert_ClientTable = "Insert into Client(Name, Sin, Age) Values (@name, @sin, @age);";

            comander.CommandText = SQL_Insert_ClientTable;
            comander.CommandType = System.Data.CommandType.Text;

            comander.Parameters.AddWithValue("@name", newClient.Name);
            comander.Parameters.AddWithValue("@sin", newClient.Sin);
            comander.Parameters.AddWithValue("@age", newClient.Age);

            comander.Connection = conexao;

            try
            {
                conexao.Open();
                comander.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally 
            { 
                conexao.Close(); 
            }

        }

        public void updateClientData(ClientDTO changeClient)
        {
            // Instantiate SQL Client
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = personalConnectionStringSQL;

            // Open Query commander
            SqlCommand comander = new SqlCommand();


            string SQL_update_ClientTable = "UPDATE Client SET Name=@name, Sin=@sin, Age=@age WHERE Id=@id;";

            comander.CommandText = SQL_update_ClientTable;
            comander.CommandType = System.Data.CommandType.Text;

            comander.Parameters.AddWithValue("@name", changeClient.Name);
            comander.Parameters.AddWithValue("@sin", changeClient.Sin);
            comander.Parameters.AddWithValue("@age", changeClient.Age);
            comander.Parameters.AddWithValue("@id", changeClient.Id);

            comander.Connection = conexao;

            try
            {
                conexao.Open();
                comander.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        public void deleteClientData(int clientId)
        {
            // Instantiate SQL Client
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = personalConnectionStringSQL;

            // Open Query commander
            SqlCommand comander = new SqlCommand();


            string SQL_update_ClientTable = "DELETE FROM Client WHERE Id=@id;";

            comander.CommandText = SQL_update_ClientTable;
            comander.CommandType = System.Data.CommandType.Text;

            comander.Parameters.AddWithValue("@id", clientId);

            comander.Connection = conexao;

            try
            {
                conexao.Open();
                comander.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conexao.Close();
            }

        }

        public ClientDTO getClientByIdData(int clientId)
        {
            // Instantiate SQL Client
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = personalConnectionStringSQL;

            // Open Query commander
            SqlCommand comander = new SqlCommand();


            string SQL_update_ClientTable = "SELECT * FROM Client WHERE Id=@id;";

            comander.CommandText = SQL_update_ClientTable;
            comander.CommandType = System.Data.CommandType.Text;

            comander.Parameters.AddWithValue("@id", clientId);

            comander.Connection = conexao;

            try
            {
                conexao.Open();
                //Return Data
                SqlDataReader tabela = comander.ExecuteReader();
                if(tabela.Read())
                {
                    ClientDTO theClient = new ClientDTO();
                    theClient.Id = int.Parse(tabela["Id"].ToString());
                    theClient.Name = tabela["Name"].ToString();
                    theClient.Sin = tabela["Sin"].ToString();
                    theClient.Age = int.Parse(tabela["Age"].ToString());
                    return theClient;
                }
                return null;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conexao.Close();
            }

        }
    }
}