using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CaseStudyProject
{
    class CourseAlreadyTaken : ApplicationException
    {
        internal CourseAlreadyTaken(string msg) : base(msg) { }
    }
    class PersistentAppEngine:InterfaceAppEg
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                    "Data Source = LAPTOP-5UT6216M; Initial Catalog = CBIT; Integrated Security = true");
            con.Open();
            return con;
        }

        
        public void Introduce()
        {
            
            int Id, Duration,Fees;
            string Name, Level;
            bool IsPlacementAvailable;
            int rowsAffected;
            try 
            {
                con = GetConnection();
                Console.WriteLine("Enter the ID:");
                Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter the duration:");
                Duration = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the fees");
                Fees = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(" Enter 1 for Degree and 2 for Diploma Course");
                int Input = Convert.ToInt32(Console.ReadLine());
                switch (Input)
                {
                    case 1:
                        Console.WriteLine("Type Bachelors or Masters");
                        Level = Console.ReadLine();
                        Console.WriteLine("Please type true if placements available and false if not");
                        IsPlacementAvailable = Convert.ToBoolean(Console.ReadLine());

                        cmd = new SqlCommand("IntroduceDegreeCourse", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Duration", Duration);
                        cmd.Parameters.AddWithValue("@Fees", Fees);
                        cmd.Parameters.AddWithValue("@courselevel", Level);
                        if (IsPlacementAvailable)
                            cmd.Parameters.AddWithValue("@IsPlacementAvailable", 1);
                        else
                            cmd.Parameters.AddWithValue("@IsPlacementAvailable", 0);

                        rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows Affected:{ rowsAffected}");
                        break;
                    case 2:
                        Console.WriteLine("Type professional or academic");
                        string DiplomaType = Console.ReadLine();

                        cmd = new SqlCommand("IntroduceDiplomaCourse", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@Name", Name);
                        cmd.Parameters.AddWithValue("@Duration", Duration);
                        cmd.Parameters.AddWithValue("@Fees", Fees);
                        cmd.Parameters.AddWithValue("@Type", DiplomaType);

                        rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine($"Rows Affected:{ rowsAffected}");
                        break;
                    default:
                        break;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }

        }
        internal void Register()
        {
            
            string phoneno_1, phoneno_2;
            string Name;
            DateTime dob;
            int rowsAffected;
            try
            {
                con = GetConnection();
                Console.WriteLine("Enter the Name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter your Primary phone Number");
                phoneno_1 = Console.ReadLine();
                Console.WriteLine("Enter your Secondary Number");
                phoneno_2 = Console.ReadLine();
                Console.WriteLine(" Enter date of joining");
                dob = Convert.ToDateTime(Console.ReadLine());

                cmd = new SqlCommand("Register", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DateofBirth", dob);
                cmd.Parameters.AddWithValue("@Phoneno_1", phoneno_1);
                cmd.Parameters.AddWithValue("@Phoneno_2", phoneno_2);
                rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"Rows Affected:{ rowsAffected}");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void Enroll()
        {
            int IsAvailable;

            Console.WriteLine("Enter the student ID");
            int sid = Convert.ToInt32(Console.ReadLine());

            CallDisplayCourses();

            Console.WriteLine("Enter the Course ID that you want");
            int cid = Convert.ToInt32(Console.ReadLine());

            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("CourseAlreadyTaken", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@sid", sid);
                IsAvailable = Convert.ToInt32(cmd.ExecuteScalar());
                if (IsAvailable == 1)
                {
                    throw new CourseAlreadyTaken("Course Already Taken by the student.");
                }
                else
                {
                    cmd = new SqlCommand("spu_AddEnrollment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cid", cid);
                    cmd.Parameters.AddWithValue("@sid", sid);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Rows Affected: {rowsAffected}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void CallDisplayStudent()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("DisplayStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " " + dr[4]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void CallDisplayCourses()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("CallDisplayCourses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3] + " " + dr[4] + " " + dr[5] + " " + dr[6]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        internal void CallDisplayEnrollments()
        {
            try
            {
                con = GetConnection();
                //Procedure name in sqlServer
                cmd = new SqlCommand("DisplayEnrollments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }

    }
}
