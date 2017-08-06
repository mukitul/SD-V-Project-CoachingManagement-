using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CoachingManagement
{
    class ClassDAO
    {


        ConnectionDB connectionDB = new ConnectionDB();
        private DataSet dataSet;

        public ClassDAO()
        {
            
        }

        public DataSet GetClassComboBoxItems()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select ClassName from Class";
            dataSet = new DataSet();
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
            
        }

        public DataSet GetClass()
        {
            connectionDB.OpenConnection();
            string sqlQuery = "select ClassName as [Class Name], ClassCode as [Class Code], MonthlyFee as [Monthly Fee], NumberOfStd as [Number of Admitted Student], AvailableSeat as [Available Seat],TotalSeat as [Total Seat], ClassId as [Row Id] from Class";
            dataSet = new DataSet();
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }

      
        public DataSet GetClassCode(string classname)
        {

            connectionDB.OpenConnection();
            string sqlQuery = "select ClassCode from Class where ClassName = '" + classname + "'"; dataSet = new DataSet();
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;


        }

        public DataSet GetClassFee(string classname)
        {
       
            connectionDB.OpenConnection();
            string sqlQuery = "select MonthlyFee from Class where ClassName = '" + classname + "'"; 
            dataSet = new DataSet();
            connectionDB.ExecuteQueries(sqlQuery);
            dataSet = connectionDB.DataAdapter();
            connectionDB.CloseConnection();
            return dataSet;
        }
        public void CreateClass(ClassDTO classDTO)
        {
            try
            {
                //insertion code
                connectionDB.OpenConnection();
                string sqlQuery = "insert into Class values('" + classDTO.CLASSNAME + "','" + classDTO.CLASSCODE + "','" + classDTO.CLASSFEE + "','0','0','0')";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();
                MessageBox.Show(classDTO.CLASSNAME+" added to the database successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               

            }
            catch (SqlException ex)
            {
                if (ex.Number>0)
                {
                    //Violation of primary key. Handle Exception
                    connectionDB.CloseConnection();
                    MessageBox.Show("Class Name or Class Code Already Exists!", "Insertion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            
        }
        public void UpdateClassAfterAddStudent(string classname)
        {

            connectionDB.OpenConnection();
            string sqlQuery = "update Class set TotalSeat = isnull((select sum(MaxBatchStd) from Batch where ClassName = '" + classname + "'),0), NumberOfStd = isnull((select sum(NumberOfStd) from Batch where ClassName = '" + classname + "'),0), AvailableSeat = isnull((select sum(AvailableSeat) from Batch where ClassName = '" + classname + "'),0) where ClassName = '" + classname + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
        }

        public void UpdateClassAfterDelStudent(string classname)
        {

            connectionDB.OpenConnection();
            string sqlQuery = "update Class set TotalSeat = isnull((select sum(MaxBatchStd) from Batch where ClassName = '" + classname + "'),0), NumberOfStd = isnull((select sum(NumberOfStd) from Batch where ClassName = '" + classname + "'),0), AvailableSeat = isnull((select sum(AvailableSeat) from Batch where ClassName = '" + classname + "'),0) where ClassName = '" + classname + "'";
            connectionDB.ExecuteQueries(sqlQuery);
            connectionDB.CloseConnection();
        }

        public void UpdateClass(string classname,string classcode,string classfee,string tmpcode,string tmpclass,string totalseat, string numberofstd, string availableseat,string id)
        {

           try
             {

                 connectionDB.OpenConnection();
                 string sqlQuery1 = "update Class set ClassName = '" + classname + "',ClassCode='" + classcode + "', MonthlyFee = '"+classfee+"' where ClassId = '" + id + "'";
                 connectionDB.ExecuteQueries(sqlQuery1);
                 connectionDB.CloseConnection();

                 connectionDB.OpenConnection();
                 string sqlQuery2 = "update Batch set ClassName = '" + classname + "' where ClassCode = '" + classcode + "'";
                 connectionDB.ExecuteQueries(sqlQuery2);
                 connectionDB.CloseConnection();

                 connectionDB.OpenConnection();
                 string sqlQuery3 = "update Student set ClassName = '" + classname + "' where ClassCode = '" + classcode + "'";
                 connectionDB.ExecuteQueries(sqlQuery3);
                 connectionDB.CloseConnection();

                 connectionDB.OpenConnection();
                 string sqlQuery4 = "update StudentResult set ClassName = '" + classname + "' where ClassName = '" + tmpclass + "'";
                 connectionDB.ExecuteQueries(sqlQuery4);
                 connectionDB.CloseConnection();

                 connectionDB.OpenConnection();
                 string sqlQuery5 = "update Subjects set ClassName = '" + classname + "' where ClassCode = '" + classcode + "'";
                 connectionDB.ExecuteQueries(sqlQuery5);
                 connectionDB.CloseConnection();

                 connectionDB.OpenConnection();
                 string sqlQuery6 = "update StudentFee set ClassName = '" + classname + "' where ClassName = '" + tmpclass + "'";
                 connectionDB.ExecuteQueries(sqlQuery6);
                 connectionDB.CloseConnection();

                 connectionDB.OpenConnection();
                 string sqlQuery7 = "update Teacher set ClassName = '" + classname + "' where ClassName = '" + tmpclass + "'";
                 connectionDB.ExecuteQueries(sqlQuery7);
                 connectionDB.CloseConnection();


                 MessageBox.Show("Class Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
             }
             catch (SqlException ex)
             {
                 if (ex.Number > 0)
                 {
                     connectionDB.CloseConnection();
                     MessageBox.Show("Class Name or Class Code may already exists. \n Try a new one.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }




        }


        public void DeleteClass(string classname)
        {
                connectionDB.OpenConnection();
                string sqlQuery = "delete from Class where ClassName = '" + classname + "'";
                connectionDB.ExecuteQueries(sqlQuery);
                connectionDB.CloseConnection();

                connectionDB.OpenConnection();
                string sqlQuery1 = "delete from StudentFee where ClassName='"+ classname +"'";
                connectionDB.ExecuteQueries(sqlQuery1);
                connectionDB.CloseConnection();
                MessageBox.Show("Class Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }
    }
}
