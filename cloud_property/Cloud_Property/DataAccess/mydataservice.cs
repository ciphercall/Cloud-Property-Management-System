﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Cloud_Property.Models;

namespace Cloud_Property.DataAccess
{
    public class mydataservice
    {

        public IEnumerable TopcategoriesListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDbContext"].ToString());

            var query = string.Format("SELECT STK_ITEMMST.CATNM AS CATNM, SUM(STK_TRANS.GROSSAMT) AS VALUE " +
                       " FROM  STK_ITEM INNER JOIN " +
                  " STK_TRANS ON STK_ITEM.COMPID = STK_TRANS.COMPID AND STK_ITEM.ITEMID = STK_TRANS.ITEMID INNER JOIN " +
                "  STK_ITEMMST ON STK_ITEM.CATID = STK_ITEMMST.CATID " +
                " WHERE STK_TRANS.TRANSTP = 'IISS' AND STK_TRANS.COMPID='" + loggedcompid + "' AND STK_TRANS.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "' " +
                " GROUP BY STK_ITEMMST.CATNM " +
                " ORDER BY VALUE DESC ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["CATNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["VALUE"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }



        public IEnumerable TopItemsByQtyListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDbContext"].ToString());

            var query = string.Format("SELECT STK_ITEM.ITEMNM AS ITEMNM, SUM(STK_TRANS.QTY) QTY " +
                      " FROM  STK_ITEM INNER JOIN " +
                      " STK_TRANS ON STK_ITEM.COMPID = STK_TRANS.COMPID AND STK_ITEM.ITEMID = STK_TRANS.ITEMID " +
                      " WHERE STK_TRANS.TRANSTP = 'IISS' AND STK_TRANS.COMPID='" + loggedcompid + "' AND STK_TRANS.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "' " +
                      " GROUP BY STK_ITEM.ITEMNM " +
                      " ORDER BY QTY DESC  ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["ITEMNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["QTY"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }




        public IEnumerable TopItemsByValueListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDbContext"].ToString());

            var query = string.Format("SELECT STK_ITEM.ITEMNM AS ITEMNM, SUM(STK_TRANS.GROSSAMT) VALUE  " +
                    " FROM STK_ITEM INNER JOIN " +
                   "   STK_TRANS ON STK_ITEM.COMPID = STK_TRANS.COMPID AND STK_ITEM.ITEMID = STK_TRANS.ITEMID " +
                    " WHERE STK_TRANS.TRANSTP = 'IISS' AND STK_TRANS.COMPID='" + loggedcompid + "' AND STK_TRANS.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'" +
                   "   GROUP BY STK_ITEM.ITEMNM " +
                    "  ORDER BY VALUE DESC");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["ITEMNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["VALUE"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }

        public IEnumerable TopProjectsByValueListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDbContext"].ToString());

            var query = string.Format("SELECT GL_COSTPOOL.COSTPNM AS ITEMNM, SUM(GL_MASTER.DEBITAMT) VALUE  " +
                    " FROM GL_COSTPOOL INNER JOIN GL_MASTER ON GL_COSTPOOL.COMPID = GL_MASTER.COMPID AND GL_COSTPOOL.COSTPID = GL_MASTER.COSTPID " +
                   " WHERE GL_COSTPOOL.COMPID='" + loggedcompid + "' AND SUBSTRING(CAST(DEBITCD as varchar(38)),4,1)='4' AND TRANSDRCR = 'DEBIT' AND GL_MASTER.TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'" +
                    " GROUP BY GL_COSTPOOL.COSTPNM "+
                 
                    " ORDER BY VALUE DESC");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["ITEMNM"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["VALUE"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }



        public IEnumerable CollectionDataListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDbContext"].ToString());

            var query = string.Format("SELECT CONVERT(NVARCHAR(20),TRANSDT,103) AS TRANSDT, SUM(DEBITAMT) COLLECT " +
                " FROM GL_MASTER " +
                " WHERE TRANSTP='MREC' AND COMPID='" + loggedcompid + "' AND TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'  " +
                " GROUP BY TRANSDT");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["TRANSDT"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["COLLECT"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }



        public IEnumerable TimeWiseSellDataListdata(Int64 loggedcompid, string todate, string frdate)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PropertyDbContext"].ToString());

            var query = string.Format(" SELECT DISTINCT CONVERT(NVARCHAR(20),dateadd(hour, datediff(hour, 0, dateadd(mi, 30, INSTIME)), 0) ,108) AS INSTIME, SUM(TOTGROSS) AMOUNT " +
                " FROM STK_TRANSMST " +
                " WHERE TRANSTP='IISS' AND COMPID='" + loggedcompid + "' AND TRANSDT  BETWEEN '" + todate + "' AND  '" + frdate + "'" +
               " GROUP BY CONVERT(NVARCHAR(20),dateadd(hour, datediff(hour, 0, dateadd(mi, 30, INSTIME)), 0) ,108)");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);

            IList<Outputclass> transList = new List<Outputclass>();
            // var GetList = ds.ToList();

            foreach (DataRow row in ds.Rows)
            {
                transList.Add(new Outputclass()
                {
                    PlanName = row["INSTIME"].ToString(),
                    PaymentAmount = Convert.ToInt64(row["AMOUNT"])

                });
            }
            // var list = con.Query<Outputclass>("Usp_Getdata").AsEnumerable();
            // List of type Outputclass which it will return .
            return transList;
        }

    }
}