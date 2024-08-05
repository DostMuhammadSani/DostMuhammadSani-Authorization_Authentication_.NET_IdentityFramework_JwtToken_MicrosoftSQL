using ClassLibraryModel;
using System.Data.SqlClient;

namespace DALLibrary
{
    public class DALClass
    {
        public static void CUD ( PersonModel p)
        {
            SqlConnection conn = DBHelper.getConnection();
            conn.Open ();
            SqlCommand cmd= new SqlCommand ("SavePerson", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", p.Id);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Email", p.Email);
            cmd.Parameters.AddWithValue("@Phone", p.Phone);
            cmd.ExecuteNonQuery ();
            conn.Close ();
        }

    }
}
