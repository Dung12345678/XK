using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Xml;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Reflection;
using System.Drawing;
using IE.Model;
using IE.Exceptions;
using IE.Utils;
using IE.Facade;
using IE.Business;
using DevExpress.XtraPrinting;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using DevExpress.XtraEditors.Repository;
using System.Collections.Generic;
using System.Data.OleDb;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Net.Mail;
using Microsoft.VisualBasic;
using System.Diagnostics;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using System.Drawing.Imaging;

namespace BMS
{
    public class LibIE
    {
        #region Variables
        static private SqlConnection mySqlConnection;
        public static DateTime MIN_DATE = new DateTime(1950, 1, 1);
        #endregion Variables

        public LibIE()
        {
        }

        #region Lấy dữ liệu từ cơ sở dữ liệu
        static private bool connect()
        {
            string str = DBUtils.GetDBConnectionString();
            try
            {
                mySqlConnection = new SqlConnection(str);
                mySqlConnection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static private bool disconnect()
        {
            try
            {
                mySqlConnection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        static public DataTable GetTable(string procedureName, SqlParameter mySqlParameter, string nameSetToTable)
        {
            DataTable table = new DataTable();
            try
            {
                if (connect())
                {
                    SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
                    DataSet myDataSet = new DataSet();
                    if (mySqlParameter != null)
                        mySqlCommand.Parameters.Add(mySqlParameter);
                    //mySqlCommand.ExecuteNonQuery();
                    mySqlDataAdapter.Fill(myDataSet, nameSetToTable);
                    table = myDataSet.Tables[nameSetToTable];
                }
            }
            catch (SqlException ex)
            {
                return new DataTable();
            }
            finally
            {
                disconnect();
            }
            return table;
        }

        static public DataTable GetTable(string procedureName, string nameSetToTable, params SqlParameter[] mySqlParameter)
        {
            DataTable table = new DataTable();
            try
            {
                if (connect())
                {
                    SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                    mySqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);
                    DataSet myDataSet = new DataSet();
                    for (int i = 0; i < mySqlParameter.Length; i++)
                        mySqlCommand.Parameters.Add(mySqlParameter[i]);
                    //mySqlCommand.ExecuteNonQuery();
                    mySqlDataAdapter.Fill(myDataSet, nameSetToTable);
                    table = myDataSet.Tables[nameSetToTable];
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                disconnect();
            }
            return table;
        }

        static public DataTable Select(string strComm)
        {
            SqlConnection cnn = new SqlConnection(DBUtils.GetDBConnectionString());
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cnn.Open();
                cmd = new SqlCommand("spSearchAllForTrans", cnn);
                cmd.CommandTimeout = 6000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@sqlCommand", strComm));
                //cmd.ExecuteNonQuery();

                da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (SqlException se)
            {
                return new DataTable();
                //throw new Exception("Sellect error :" + se.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        public static DataTable Select(string tableName, Expression exp)
        {
            return TextUtils.Select(DBUtils.SQLSelect(tableName, exp));
        }

        public static void ExcuteSQL(string strSQL)
        {
            try
            {
                SqlConnection cn = new SqlConnection(DBUtils.GetDBConnectionString());
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cn.Open();
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {
            }
        }

        //public static void ExcuteSQLImport(string strSQL)
        //{
        //    try
        //    {
        //        SqlConnection cn = new SqlConnection(DBUtils.GetDBConnectionString());
        //        SqlCommand cmd = new SqlCommand(strSQL, cn);
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandTimeout = 60;
        //        cn.Open();
        //        cmd.CommandText = strSQL;
        //        cmd.ExecuteNonQuery();
        //        cn.Close();
        //    }
        //    catch
        //    {
        //    }
        //}

        public static object ExcuteScalar(string strSQL)
        {
            object value = null;
            try
            {
                SqlConnection cn = new SqlConnection(DBUtils.GetDBConnectionString());
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cn.Open();
                cmd.CommandText = strSQL;
                value = cmd.ExecuteScalar();
                cn.Close();
            }
            catch
            {
            }
            return value;
        }

        public static Boolean UpdateByCommand(string command)
        {
            SqlConnection cnn = new SqlConnection(DBUtils.GetDBConnectionString());
            Boolean update = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cnn.Open();
                cmd = new SqlCommand("spSearchAllForTrans", cnn);
                cmd.CommandTimeout = 6000;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@sqlCommand", command));
                cmd.ExecuteNonQuery();
                update = true;
            }
            catch (SqlException se)
            {
                throw new Exception("UPDATE_ERROR :" + se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return update;
        }

        public static void ExcuteProcedure(string storeProcedureName, string[] paramName, object[] paramValue)
        {
            SqlConnection cn = new SqlConnection(DBUtils.GetDBConnectionString());
            try
            {
                cn = new SqlConnection(DBUtils.GetDBConnectionString());
                SqlCommand cmd = new SqlCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter sqlParam;
                cn.Open();
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        cmd.Parameters.Add(sqlParam);
                    }
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                cn.Close();
            }

        }

        public static DataTable LoadDataFromSP(string procedureName, string nameSetToTable, string[] paramName, object[] paramValue)
        {
            DataTable table = new DataTable();
            SqlConnection mySqlConnection = new SqlConnection(DBUtils.GetDBConnectionString(60));
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandTimeout = 0;
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);

                DataSet myDataSet = new DataSet();
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }
                //mySqlCommand.ExecuteNonQuery();

                mySqlDataAdapter.Fill(myDataSet, nameSetToTable);

                table = myDataSet.Tables[nameSetToTable];
            }
            catch (SqlException e)
            {
                throw new FacadeException(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return table;
        }
        public static DataTable GetDataTableFromSP(string procedureName, string[] paramName, object[] paramValue)
        {
            DataTable table = new DataTable();
            SqlConnection mySqlConnection = new SqlConnection(DBUtils.GetDBConnectionString(60));
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandTimeout = 0;
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);

                DataSet myDataSet = new DataSet();
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }
                //mySqlCommand.ExecuteNonQuery();

                mySqlDataAdapter.Fill(myDataSet);

                table = myDataSet.Tables[0];
            }
            catch (SqlException e)
            {
                throw new FacadeException(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return table;
        }
        public static DataSet GetListDataFromSP(string procedureName, string[] paramName, object[] paramValue)
        {
            DataSet myDataSet = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(DBUtils.GetDBConnectionString(60));
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandTimeout = 0;
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);

                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }

                mySqlDataAdapter.Fill(myDataSet);
            }
            catch (SqlException e)
            {
            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataSet;
        }
        public static DataSet LoadDataSetFromSP(string procedureName, string[] paramName, object[] paramValue)
        {
            DataSet myDataSet = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(DBUtils.GetDBConnectionString(60));
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandTimeout = 0;
                SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter(mySqlCommand);


                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }

                mySqlDataAdapter.Fill(myDataSet);

            }
            catch (SqlException e)
            {
                throw new FacadeException(e.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }

            return myDataSet;
        }
        #endregion Các hàm lấy dữ liệu từ cơ sở dữ liệu

    }
}

