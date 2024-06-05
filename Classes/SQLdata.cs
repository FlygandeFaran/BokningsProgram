using BokningsProgram.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BokningsProgram.Classes
{
    public class SQLdata
    {
        private ClinicalManager cm;
        private static SqlConnection connection = null;
        public SQLdata(ClinicalManager clinicalManager)
        {
            cm = clinicalManager;
        }
        public void Connect()
        {
            MessageBox.Show("Hej");
            string connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = \\ltvastmanland.se\ltv\shares\rhosonk\Strålbehandling\Bookning\BookingDB.mdf; Integrated Security = False; Connect Timeout=2; user id = SuperAdmin; password = SuperAdmin";
            connection = new SqlConnection(connectionString);
            if (connection == null)
            {
                MessageBox.Show("Kunde inte ansluta");
            }
            MessageBox.Show(connection.DataSource);
            connection.Open();
            MessageBox.Show("Hej3");
            MessageBox.Show("Success!");
        }
        public void Disconnect()
        {
            connection.Close();
        }
        public DataTable Query(string queryString)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection) { MissingMappingAction = MissingMappingAction.Passthrough, MissingSchemaAction = MissingSchemaAction.Add };
                adapter.Fill(dataTable);
                adapter.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
        public void SQLtest()
        {
            Connect();
            DataTable datatable = Query(@"  SELECT *
                                            FROM Ssk
                                            ");
            Disconnect();
            MessageBox.Show(connection.DataSource);
        }
        public void InsertSSK()
        {
            Connect();
            DataTable datatable = Query(@"  INSERT INTO Ssk(SskSer, HsaId, Name)
                                            VALUES(1, '34vb', 'Erik Fura');
                                            ");
            Disconnect();
        }
    }
}
