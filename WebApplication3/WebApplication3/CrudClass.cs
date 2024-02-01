using System.Data.SqlClient;
using System.Data;
using WebApplication3.Model;
using System.Xml.Linq;

namespace WebApplication3
{
    public class CrudClass : Istudent
    {
        string constr = "data source=.; database=student; integrated security=SSPI";
        public IEnumerable<student> GetAllStudents()
        {
            List<student> students = new List<student>();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("getall", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    student student = new student
                    {
                        Id = (int)sdr["ID"],
                        Name = (string)sdr["Name"],
                        Dept = (string)sdr["Department"]
                    };
                    students.Add(student);
                }
                return students;
            }
        }

        public student GetStudentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                student stud = new student();
                SqlCommand cmd = new SqlCommand("select * from stu where Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    stud.Id = sdr.GetInt32(0);
                    stud.Name = sdr.GetString(1);
                    stud.Dept = sdr.GetString(2);
                    return stud;
                }
                return null;
                
            }
        }

        public int AddStudent(student student)
            {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("insert into stu values ( @id, @name, @dept)", conn);
                    cmd.Parameters.AddWithValue("@id", student.Id);
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@dept", student.Dept);
                    conn.Open();
                    int rowsaffected = cmd.ExecuteNonQuery();
                    return rowsaffected;
                }
            }

        public int UpdateStudent(student student)
        {
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("update stu set Name =@name, Department=@dept where ID = @id ", conn);
                    cmd.Parameters.AddWithValue("@id", student.Id);
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@dept", student.Dept);
                    conn.Open();
                    int rowsaffected = cmd.ExecuteNonQuery();
                    return rowsaffected;
                }
            }

        public int DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Delete from stu where ID = @id ", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                return rowsaffected;
            }
        }
    }
}
