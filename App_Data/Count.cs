using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Diagnostics;

namespace CBOProactiveChecks
{
    public class Count
    {
        int TotalStores = 0, ActiveScripts = 0, First = 0, Second = 0, Third = 0;

        public Count()
        {
            TotalStores = TotalStoreList();
            ActiveScripts = GetActiveScripts();
            First = Convert.ToInt32(ConfigurationManager.AppSettings["First"]);
            Second = Convert.ToInt32(ConfigurationManager.AppSettings["Second"]);
            Third = Convert.ToInt32(ConfigurationManager.AppSettings["Third"]);
        }

        internal string GetBragColor(int falseCount, int storecount)
        {
            string color = "Blue";
            float BragCount = 0.0F;
            try
            {
                if (storecount > 0)
                {
                    BragCount = 100 - ((float)falseCount / (float)storecount) * 100;
                    if (BragCount == First)
                    {
                        color = "Blue";
                    }
                    if ((BragCount >= Second) && (BragCount < First))
                    {
                        color = "Green";
                    }
                    if ((BragCount >= Third) && (BragCount < Second))
                    {
                        color = "Amber";
                    }
                    if ((BragCount < Third))
                    {
                        color = "Red";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return color;
        }

        internal int GetActiveScripts()
        {
            int Total = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                string BragColor = string.Empty;
                cmd.CommandText = "GetActiveScripts";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Total = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Total;
        }

        internal int TotalStoreList()
        {
            int Total = 0;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                string BragColor = string.Empty;
                cmd.CommandText = "GetAllStores";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Total = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return Total;
        }

        public ArrayList BroadCastDisplay(int StoreId)
        {
            int TotalSent, TotalFailed, Sent, Failed;
            string brag, BatchNo, Query;
            TotalSent = TotalFailed = Sent = Failed = 0;
            brag = BatchNo = Query = String.Empty;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

            if (StoreId != 0)
            {
                Query = "Select * from TB_Batch1 where StoreId=" + StoreId + " union Select * from TB_Batch2 where StoreId=" + StoreId + " ";
            }
            else
            {
                Query = "Select * from TB_Batch1 union select * from TB_Batch2 ";
            }

            SqlDataAdapter da = new SqlDataAdapter(Query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                BatchNo = ds.Tables[0].Rows[0][2].ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    Sent = Convert.ToInt32(ds.Tables[0].Rows[i][6].ToString());
                    TotalSent = TotalSent + Sent;
                    int success = Convert.ToInt32(ds.Tables[0].Rows[i][5].ToString());
                    if (success == 0)
                    {
                        Failed = Convert.ToInt32(ds.Tables[0].Rows[i][6].ToString());
                        TotalFailed = TotalFailed + Failed;
                    }
                }
            }
            else
            {
                BatchNo = "0";
                TotalSent = TotalFailed = 0;
            }

            int PTG = 0;

            if (TotalSent > 0)
                PTG = (TotalFailed / TotalSent) * 100;

            if (PTG > 10)
            {
                brag = "Red";
            }
            else
            {
                brag = "Green";
            }

            ArrayList al = new ArrayList();

            al.Add(BatchNo);
            al.Add(TotalSent);
            al.Add(TotalFailed);
            al.Add(brag);
            return al;
        }

        public DataSet GetBroadCastDetails(int StoreId)
        {
            SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "GetBroadCastDetails";

            cmd1.Parameters.Clear();
            cmd1.Parameters.AddWithValue("@StoreId", StoreId);

            con1.Open();
            cmd1.ExecuteNonQuery();
            Console.WriteLine("Procedure3 Executed");
            con1.Close();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            return ds1;
        }

        public ArrayList OfflineTillsCount(int StoreId)
        {
            SqlConnection conCount = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

            ArrayList TillCount = new ArrayList();
            try
            {
                string ActiveTill_Count, SignedOn_Count, SignedOff_Count, OfflineTill_Count;
                SqlCommand cmdOffLine_Count = new SqlCommand();
                cmdOffLine_Count.CommandType = CommandType.StoredProcedure;
                cmdOffLine_Count.Connection = conCount;
                cmdOffLine_Count.CommandText = "GetTillDetails";
                cmdOffLine_Count.Parameters.Clear();
                cmdOffLine_Count.Parameters.Add("@StoreId", SqlDbType.Int).Value = StoreId;

                DataSet DSOfflineTills_Count = new DataSet();
                conCount.Open();
                SqlDataAdapter adapOffline = new SqlDataAdapter(cmdOffLine_Count);
                adapOffline.Fill(DSOfflineTills_Count);

                if (DSOfflineTills_Count.Tables[0].Rows.Count > 0)
                {
                    ActiveTill_Count = DSOfflineTills_Count.Tables[0].Rows[0][1].ToString();
                    SignedOn_Count = DSOfflineTills_Count.Tables[0].Rows[0][3].ToString();
                    SignedOff_Count = DSOfflineTills_Count.Tables[0].Rows[0][5].ToString();
                    OfflineTill_Count = DSOfflineTills_Count.Tables[0].Rows[0][7].ToString();

                    TillCount.Add(ActiveTill_Count);
                    TillCount.Add(SignedOn_Count);
                    TillCount.Add(SignedOff_Count);
                    TillCount.Add(OfflineTill_Count);

                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                conCount.Close();
            }
            return TillCount;
        }

        public ArrayList OfflineTillsList(int storeId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

            ArrayList TillDetails = new ArrayList();
            try
            {
                string Active_Tills, SingnedOn_Tills, SignedOf_Tills, Offline_Tills;
                SqlCommand cmdOffLine = new SqlCommand();
                string BragColorOffline = string.Empty;

                cmdOffLine.CommandType = CommandType.StoredProcedure;
                cmdOffLine.Connection = con;
                cmdOffLine.CommandText = "GetTillDetails";
                cmdOffLine.Parameters.Clear();
                cmdOffLine.Parameters.Add("@StoreId", SqlDbType.Int).Value = storeId;

                DataSet DSOfflineTills = new DataSet();
                con.Open();
                SqlDataAdapter adapOffline = new SqlDataAdapter(cmdOffLine);
                adapOffline.Fill(DSOfflineTills);

                if (DSOfflineTills.Tables[0].Rows.Count > 0)
                {
                    Active_Tills = DSOfflineTills.Tables[0].Rows[0][0].ToString();
                    SingnedOn_Tills = DSOfflineTills.Tables[0].Rows[0][2].ToString();
                    SignedOf_Tills = DSOfflineTills.Tables[0].Rows[0][4].ToString();
                    Offline_Tills = DSOfflineTills.Tables[0].Rows[0][6].ToString();

                    TillDetails.Add(Active_Tills);
                    TillDetails.Add(SingnedOn_Tills);
                    TillDetails.Add(SignedOf_Tills);
                    TillDetails.Add(Offline_Tills);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return TillDetails;
        }

        public string PosMenuVarient(int StoreDomainId)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            SqlCommand cmd = new SqlCommand();
            string BragColor = string.Empty;
            string PosMenuFailed = string.Empty;
            int PosFailedCount = 0;
            DataSet PosMenu = new DataSet();
            try
            {
                string query = "SELECT DISTINCT(PLU_CRO_COU_Check.StoreId),PLU_CRO_COU_Check.PosMenuVarientFail FROM PLU_CRO_COU_Check JOIN StoreDetails ON(StoreDetails.StoreId=PLU_CRO_COU_Check.StoreId) WHERE CONVERT(VARCHAR,CreatedOn,103) = (SELECT CONVERT(VARCHAR,MAX(CreatedOn),103) FROM PLU_CRO_COU_Check) AND StoreDetails.UkOrRoi=" + StoreDomainId + "";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(PosMenu, "PLU_CRO_COU_Check");
                int TotalStoresCount = PosMenu.Tables[0].Rows.Count;
                if (PosMenu.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < PosMenu.Tables[0].Rows.Count; i++)
                    {
                        PosMenuFailed = PosMenu.Tables[0].Rows[i][1].ToString().Trim();
                        if (PosMenuFailed.Length > 0)
                        {
                            PosFailedCount++;
                        }
                    }
                    BragColor = GetBragColor(PosFailedCount, TotalStoresCount);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return BragColor;
        }
    }
}