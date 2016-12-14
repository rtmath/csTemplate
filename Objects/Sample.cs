using System;
using System.Data.SqlClient;
using System.Collections.Generic;

//Template for class with Equals override, GetAll(), Find(), Save(), Update() and Delete() and DeleteAll() methods for SQL queries
// Find and replace all instances of CLASSNAME with the name of your class (e.g. Client), and all instances of lowerclassname with the name of your class without any capitalization (e.g. client)
// CLASSNAME
// lowerclassname

namespace NAMESPACE.Objects
{
    public class CLASSNAME
    {
        public int Id { get; set; }
        public string Property1 { get; set; }

        public CLASSNAME(string classProperty1, int classId = 0)
        {
            this.Property1 = classProperty1;
            this.Id = classId;
        }

        public override bool Equals(System.Object otherCLASSNAME)
        {
            if (!(otherCLASSNAME is CLASSNAME))
            {
                return false;
            }
            else
            {
                CLASSNAME newCLASSNAME = (CLASSNAME)otherCLASSNAME;
                bool checkId = (this.Id == newCLASSNAME.Id);
                bool checkProperty1 = (this.Property1 == newCLASSNAME.Property1);
                return (checkId && checkProperty1);
            }
        }

        public override int GetHashCode()
        {
            return this.Property1.GetHashCode();
        }

        public static List<CLASSNAME> GetAll()
        {
            List<CLASSNAME> allCLASSNAMEs = new List<CLASSNAME> { };

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM lowerclassnames;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int lowerclassnameId = rdr.GetInt32(0);
                string lowerclassnameProperty1 = rdr.GetString(1);
                CLASSNAME newCLASSNAME = new CLASSNAME(lowerclassnameProperty1, lowerclassnameId);
                allCLASSNAMEs.Add(newCLASSNAME);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allCLASSNAMEs;
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO lowerclassnames (name) OUTPUT INSERTED.id VALUES(@CLASSNAMEProperty1)", conn);

            SqlParameter nameParam = new SqlParameter();
            nameParam.ParameterProperty1 = "@CLASSNAMEProperty1";
            nameParam.Value = this.Property1;
            cmd.Parameters.Add(nameParam);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                this.Id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static CLASSNAME Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM lowerclassnames WHERE id = (@CLASSNAMEId)", conn);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterProperty1 = "@CLASSNAMEId";
            idParam.Value = id.ToString();
            cmd.Parameters.Add(idParam);
            SqlDataReader rdr = cmd.ExecuteReader();

            int foundCLASSNAMEId = 0;
            string foundCLASSNAMEProperty1 = null;

            while (rdr.Read())
            {
                foundCLASSNAMEId = rdr.GetInt32(0);
                foundCLASSNAMEProperty1 = rdr.GetString(1);
            }
            CLASSNAME newCLASSNAME = new CLASSNAME(foundCLASSNAMEProperty1, foundCLASSNAMEId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return newCLASSNAME;
        }

        public void Update(string newProperty1)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE lowerclassnames SET name = @newProperty1 OUTPUT INSERTED.name WHERE id = @CLASSNAMEId;", conn);

            SqlParameter newProperty1Param = new SqlParameter();
            newProperty1Param.ParameterProperty1 = "@newProperty1";
            newProperty1Param.Value = newProperty1;
            cmd.Parameters.Add(newProperty1Param);

            SqlParameter idParam = new SqlParameter();
            idParam.ParameterProperty1 = "@CLASSNAMEId";
            idParam.Value = this.Id;
            cmd.Parameters.Add(idParam);

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                this.Property1 = rdr.GetString(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public void Delete()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM lowerclassnames WHERE id = @CLASSNAMEId", conn);
            SqlParameter idParam = new SqlParameter();
            idParam.ParameterProperty1 = "@CLASSNAMEId";
            idParam.Value = this.Id;
            cmd.Parameters.Add(idParam);
            cmd.ExecuteNonQuery();

            if (conn != null)
            {
                conn.Close();
            }
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM lowerclassnames;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
