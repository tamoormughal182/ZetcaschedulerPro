using System;
using System.Management;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

using Aspose.Pdf;
using QRCoder;
using System.Globalization;
using Newtonsoft.Json;
using System.Net;
using System.Data.Common;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Chilkat;
using System.Diagnostics.Eventing.Reader;

using Aspose.Pdf.Operators;
using System.Data.SqlTypes;

using Org.BouncyCastle.Asn1.IsisMtt.Ocsp;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.CompilerServices.RuntimeHelpers;
 

namespace scheduler
{
  public  class ClassMain
    {
        public Chilkat.Rest rest = new Chilkat.Rest();
        public static string Var_restClearInvoice { get; set; }
        public static string Var_restResponseBody { get; set; }

        public string varcur_code { get; set; }
        public string varbrCode { get; set; }
        public string varInvoice_No { get; set; }
        public string varInv_type { get; set; }


        public string varinv_index { get; set; }
        public string varX_UUID { get; set; }
        public string varPIH { get; set; }

        public long AttPIHId { get; set; }
        public string AttPIH { get; set; }
        public string INVXMLFilename { get; set; }

        public string varbranch_Id { get; set; }
        public string sbranch_code { get; set; }
        public string varbranch_code { get; set; }
        public string varsellers_name { get; set; }
        public string varsel_vatreg { get; set; }
        public string varsel_cntycode { get; set; }
        public string varsel_typeId { get; set; }
        public string varsellers_id { get; set; }
        public string varsel_cityname { get; set; }
        public string varsel_streetname { get; set; }
        public string varsel_buildingname { get; set; }
        public string varsel_buildno { get; set; }
        public string varsel_plotid { get; set; }
        public string varsel_adbuildno { get; set; }
        public string varsel_postalzone { get; set; }
        public string varsel_subcitysubname { get; set; }
        public string varsel_countrySubentity { get; set; }

        public string varinvbranch_Id { get; set; }
        public string varinvbranch_code { get; set; }
        public string varbuyers_name { get; set; }
        public string varbuy_vatno { get; set; }

        public string varbuy_typeId { get; set; }
        public string varbuy_id { get; set; }
        public string varbuy_countrycode { get; set; }
        public string varbuy_cityname { get; set; }
        public string varbuy_streetname { get; set; }
        public string varbuy_buildingname;
        public string varbuy_buildno { get; set; }
        public string varbuy_plotid { get; set; }
        public string varbuy_adbuildno { get; set; }
        public string varbuy_postalzone { get; set; }
        public string varbuy_subcitysubname { get; set; }
        public string varbuy_countrySubentity { get; set; }
        public string varinv_type { get; set; }
        public string varinv_no { get; set; }
        public string varinv_date { get; set; }
        public string varinv_time { get; set; }
        public string varrefinv_no { get; set; }
        public string varRef_Date { get; set; }
        public string varinstruction_code { get; set; }
        public string varmode_ofpay { get; set; }
        public string vardeli_date { get; set; }
        public string varactdeli_date { get; set; }
        public string varvat_breakdown { get; set; }

        public string varTotamnt_allow;
        public string varTotamnt_disc { get; set; }
        public string vargTotamnt_vat { get; set; }
        public string vargTot_LineExtAmount { get; set; }
        public string vargTotamnt_disc { get; set; }
        public string vargTotamnt_allow { get; set; }
        public string vargTot_TaxExclAmount { get; set; }
        public string vargTot_TaxInclAmount { get; set; }
        public string vargTotamnt_prepaid { get; set; }
        public string vargTotamnt_payable;
        public string varicv_uuid { get; set; }
        public string varinv_typecode { get; set; }
        public string varinv_code { get; set; }
        public string varSub_Type { get; set; }
        public string varpay_code { get; set; }
        public string varpay_inst { get; set; }
        public string varcnt_items { get; set; }
        public string varinvlne_taxcode { get; set; }
        public string varCntTaxCom { get; set; }
        public double varInvICV { get; set; }


        public string varsellers_nameTag1 { get; set; }
        public string varsel_vatregTag2 { get; set; }
        public string varTimeStampTag3 { get; set; }
        public string vargTotamnt_payableTag4 { get; set; }
        public string varMgTotamnt_vatTag5 { get; set; }
        public string varHashXMLTag6 { get; set; }
        public string varEcdsa_sigTag7 { get; set; }
        public string varEcdsa_PubTag8 { get; set; }
        public string varCrypt_StampTag9 { get; set; }
        public string varQrCodeBase64 { get; set; }
        public string varXMLInvoiceString { get; set; }
        public string varXMLFileBase64 { get; set; }
        public string varCur_InvoiceHASH_SHA256 { get; set; }


        public object[,] GroupTaxTotaldata;
        public object[,] GroupTaxTotaldataSEOZ;

        public object[,] ParseInvoiceLinedata;

        public int InvGp_ItemCount;
        public int InvGp_ItemCountSEOZ;

        public int Inv_ItemCount;
        public string Path_InvoiceFile;
        public static string UserId { get; set; }
        public static string UserPass { get; set; }

        public static int Varrepoid { get; set; }
        public static int Varacctid { get; set; }
        public static string Varserverportal { get; set; }
        public static string Varlivecompliance { get; set; }
        public static string Varrequestbodysim { get; set; }
        public static string Varrequestbodystd { get; set; }
        public static string Varprocessfolder { get; set; }
        public static string VarCertfolder { get; set; }
        public static string Varcertauthentication { get; set; }
        public static string Varbrowsexmlpro { get; set; }
        public static string Varbrowseqrcodepro { get; set; }
        public static string Varbrowsepdfa3a { get; set; }
        public static string VarbrowsesimInv { get; set; }
        public static string Varbrowsesimdr { get; set; }
        public static string Varbrowsesimcr { get; set; }
        public static string VarbrowsestdInv { get; set; }
        public static string Varbrowsestddr { get; set; }
        public static string Varbrowsestdcr { get; set; }

        public static string Varccsidprivate_key { get; set; }
        public static string Varccsid_pem { get; set; }
        public static string Varccsid_string { get; set; }
        public static string Varccsid_secret { get; set; }

        public static string Varpcsidprivate_key { get; set; }
        public static string Varpcsid_pem { get; set; }
        public static string Varpcsid_string { get; set; }
        public static string Varpcsid_secret { get; set; }

        public static int VarEnp_id { get; set; }
        public static int VarCsOrg_Id { get; set; }

        public static string VarOrgCom_EndPoint { get; set; }
        public static string VarLive_EndPoint { get; set; }

        public static string VarPathcsrconfig { get; set; }
        public static string VaGencertPath { get; set; }

        //use upload details
        public static string VarSta_inv_date { get; set; }
        public static string VarSta_inv_time { get; set; }
        public static string VarSta_inv_no { get; set; }



        /* For Standard//SimplifiedInvoice */
        public static string XMLDigital_CryptResult { get; set; }
        public static int RespCode { get; set; }

        string Qry { get; set; }
        static string QryC { get; set; }

        /*
        public static int UserAcctId { get; set; }
        */
        static int _UserAcctId;
        public static int UserAcctId
        {
            get
            {
                return _UserAcctId;
            }
            set
            {
                _UserAcctId = value;
            }
        }

        static string _XMLInvoiceUTF8File;
        public static string XMLInvoiceUTF8File
        {
            get
            {
                return _XMLInvoiceUTF8File;
            }
            set
            {
                _XMLInvoiceUTF8File = value;
            }
        }
        public bool ConnectToPortal(string pServerPortal)
        {

            bool bTls = true;
            int port = 443;
            bool bAutoReconnect = true;
            bool Conn_Success;

            //
            //pServerPortal= "https://gw-apic-gov.gazt.gov.sa/e-invoicing/developer-portal/compliance";
            //

            //pServerPortal = "https://gw-fatoora.zatca.gov.sa/e-invoicing/developer-portal/production/csids";
            //pServerPortal = "https://gw-fatoora.zatca.gov.sa/e-invoicing/simulation/production/csids";
            //pServerPortal = "https://gw-fatoora.zatca.gov.sa/e-invoicing/core/production/csids";

            //
            Conn_Success = rest.Connect(pServerPortal, port, bTls, bAutoReconnect);
            if (Conn_Success != true)
            {
                //MessageBox.Show("Failed to Connect Portal: " + Convert.ToString(rest.ConnectFailReason), "Portal Connection", //MessageBoxButtons.OK, //MessageBoxIcon.Exclamation);
                return Conn_Success;
            }

            return Conn_Success;

        }

        public void Def_Repository(int rep_AcctId)
        {
            try
            {

                Qry = string.Empty;
                Qry = "SELECT ";
                Qry += "unit_repository.repo_id,";
                Qry += "unit_repository.serverportal,";
                Qry += "unit_repository.livecompliance,";
                Qry += "unit_repository.requestbodysim,";
                Qry += "unit_repository.requestbodystd,";
                Qry += "unit_repository.processfolder,";
                Qry += "unit_repository.certfolder,";
                Qry += "unit_repository.certauthentication,";
                Qry += "unit_repository.browsexmlpro,";
                Qry += "unit_repository.browseqrcodepro,";
                Qry += "unit_repository.browsepdfa3a,";
                Qry += "unit_repository.browsesimInv,";
                Qry += "unit_repository.browsesimdr,";
                Qry += "unit_repository.browsesimcr,";
                Qry += "unit_repository.browsestdInv,";
                Qry += "unit_repository.browsestddr,";
                Qry += "unit_repository.browsestdcr ";
                Qry += "FROM ";
                Qry += "unit_repository ";
                Qry += "WHERE ";
                Qry += "unit_repository.acct_id =  " + rep_AcctId + ";";

                if (SqlConfig.ServerConn != null && SqlConfig.ServerConn.State == ConnectionState.Closed) { SqlConfig.ConnectToServer(SqlConfig.ConnectionString); }
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Varacctid = rep_AcctId;

                    Varrepoid = (int)reader["repo_id"];
                    Varserverportal = reader.GetString(reader.GetOrdinal("serverportal"));
                    Varlivecompliance = reader.GetString(reader.GetOrdinal("livecompliance"));
                    Varrequestbodysim = reader.GetString(reader.GetOrdinal("requestbodysim"));
                    Varrequestbodystd = reader.GetString(reader.GetOrdinal("requestbodystd"));
                    Varprocessfolder = reader.GetString(reader.GetOrdinal("processfolder"));
                    VarCertfolder = reader.GetString(reader.GetOrdinal("certfolder"));
                    Varcertauthentication = reader.GetString(reader.GetOrdinal("certauthentication"));
                    Varbrowsexmlpro = reader.GetString(reader.GetOrdinal("browsexmlpro"));
                    Varbrowseqrcodepro = reader.GetString(reader.GetOrdinal("browseqrcodepro"));
                    Varbrowsepdfa3a = reader.GetString(reader.GetOrdinal("browsepdfa3a"));
                    VarbrowsesimInv = reader.GetString(reader.GetOrdinal("browsesimInv"));
                    Varbrowsesimdr = reader.GetString(reader.GetOrdinal("browsesimdr"));
                    Varbrowsesimcr = reader.GetString(reader.GetOrdinal("browsesimcr"));
                    VarbrowsestdInv = reader.GetString(reader.GetOrdinal("browsestdInv"));
                    Varbrowsestddr = reader.GetString(reader.GetOrdinal("browsestddr"));
                    Varbrowsestdcr = reader.GetString(reader.GetOrdinal("browsestdcr"));

                }
                else
                {
                    Varacctid = 0;
                    Varrepoid = 0;
                    Varserverportal = String.Empty;
                    Varlivecompliance = String.Empty;
                    Varrequestbodysim = String.Empty;
                    Varrequestbodystd = String.Empty;
                    Varprocessfolder = String.Empty;
                    VarCertfolder = String.Empty;
                    Varcertauthentication = String.Empty;
                    Varbrowsexmlpro = String.Empty;
                    Varbrowseqrcodepro = String.Empty;
                    Varbrowsepdfa3a = String.Empty;
                    VarbrowsesimInv = String.Empty;
                    Varbrowsesimdr = String.Empty;
                    Varbrowsesimcr = String.Empty;
                    VarbrowsestdInv = String.Empty;
                    Varbrowsestddr = String.Empty;
                    Varbrowsestdcr = String.Empty;

                }
                cmd.Dispose();
                reader.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
            }
            finally
            {
                SqlConfig.ServerConn.Close();
            }
        }
        public void DefCcsid_Certificates(string BrCOde)
        {
            try
            {

                Qry = string.Empty;
                Qry = "SELECT ";
                Qry += "unit_certificates.private_key,";
                Qry += "unit_certificates.ccsid_pem,";
                Qry += "unit_certificates.ccsid_string,";
                Qry += "unit_certificates.ccsid_secret ";
                Qry += "FROM ";
                Qry += "unit_certificates ";
                Qry += "INNER JOIN cs_unitconfig ON(unit_certificates.csid = cs_unitconfig.csid)";
                Qry += "WHERE ";
                Qry += "cs_unitconfig.orgcode = '" + BrCOde + "';";


                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    Varccsidprivate_key = reader.GetString(reader.GetOrdinal("private_key"));
                    Varccsid_pem = reader.GetString(reader.GetOrdinal("ccsid_pem"));
                    Varccsid_string = reader.GetString(reader.GetOrdinal("ccsid_string"));
                    Varccsid_secret = reader.GetString(reader.GetOrdinal("ccsid_secret"));
                }
                else
                {

                    Varccsidprivate_key = String.Empty;
                    Varccsid_pem = String.Empty;
                    Varccsid_string = String.Empty;
                    Varccsid_secret = String.Empty;

                }
                cmd.Dispose();
                reader.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
            }
            finally
            {
                SqlConfig.ServerConn.Close();
            }
        }
        public void DefPcsid_Certificates(string BrCOde)
        {
            try
            {

                Qry = string.Empty;
                Qry = "SELECT ";
                Qry += "unit_certificates.private_key,";
                Qry += "unit_certificates.pcsid_pem,";
                Qry += "unit_certificates.pcsid_string,";
                Qry += "unit_certificates.pcsid_secret ";
                Qry += "FROM ";
                Qry += "unit_certificates ";
                Qry += "INNER JOIN cs_unitconfig ON(unit_certificates.csid = cs_unitconfig.csid)";
                Qry += "WHERE ";
                Qry += "cs_unitconfig.orgcode = '" + BrCOde + "';";


                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    Varpcsidprivate_key = reader.GetString(reader.GetOrdinal("private_key"));
                    Varpcsid_pem = reader.GetString(reader.GetOrdinal("pcsid_pem"));
                    Varpcsid_string = reader.GetString(reader.GetOrdinal("pcsid_string"));
                    Varpcsid_secret = reader.GetString(reader.GetOrdinal("pcsid_secret"));
                }
                else
                {

                    Varpcsidprivate_key = String.Empty;
                    Varpcsid_pem = String.Empty;
                    Varpcsid_string = String.Empty;
                    Varpcsid_secret = String.Empty;

                }
                cmd.Dispose();
                reader.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
            }
            finally
            {
                SqlConfig.ServerConn.Close();
            }
        }
        public void RetrieveXMLCompliance(string InvoiceType, string Branch_code, string Invoice_No)

        {

            try
            {

                //Different Type of Invoices
                if (InvoiceType == "Standard Invoice")
                {
                    Qry = string.Empty;
                    Qry += "SELECT  vw_salesinvoices.inv_index, vw_salesinvoices.cur_code ";
                    Qry += "FROM ";
                    Qry += "vw_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_salesinvoices.inv_no = '" + Invoice_No + "' AND vw_salesinvoices.branch_code = '" + Branch_code + "'";

                }
                else if (InvoiceType == "Standard Debit Note")
                {
                    Qry = string.Empty;
                    Qry += "SELECT  vw_dr_salesinvoices.inv_index, vw_dr_salesinvoices.cur_code ";
                    Qry += "FROM ";
                    Qry += "vw_dr_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_dr_salesinvoices.inv_no = '" + Invoice_No + "' AND vw_dr_salesinvoices.branch_code = '" + Branch_code + "'";
                }
                else if (InvoiceType == "Standard Credit Note")
                {
                    Qry = string.Empty;
                    Qry += "SELECT  vw_cr_salesinvoices.inv_index, vw_cr_salesinvoices.cur_code ";
                    Qry += "FROM ";
                    Qry += "vw_cr_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cr_salesinvoices.inv_no = '" + Invoice_No + "' AND vw_cr_salesinvoices.branch_code = '" + Branch_code + "'";
                }
                else if (InvoiceType == "Simplified Invoice")
                {
                    Qry = string.Empty;
                    Qry += "SELECT  vw_cashsalesinvoices.inv_index, vw_cashsalesinvoices.cur_code ";
                    Qry += "FROM ";
                    Qry += "vw_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cashsalesinvoices.inv_no = '" + Invoice_No + "' AND vw_cashsalesinvoices.branch_code = '" + Branch_code + "'";
                }
                else if (InvoiceType == "Simplified Debit Note")
                {
                    Qry = string.Empty;
                    Qry += "SELECT  vw_dr_cashsalesinvoices.inv_index, vw_dr_cashsalesinvoices.cur_code ";
                    Qry += "FROM ";
                    Qry += "vw_dr_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_dr_cashsalesinvoices.inv_no = '" + Invoice_No + "' AND vw_dr_cashsalesinvoices.branch_code = '" + Branch_code + "'";
                }
                else if (InvoiceType == "Simplified Credit Note")
                {
                    Qry = string.Empty;
                    Qry += "SELECT  vw_cr_cashsalesinvoices.inv_index, vw_cr_cashsalesinvoices.cur_code ";
                    Qry += "FROM ";
                    Qry += "vw_cr_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cr_cashsalesinvoices.inv_no = '" + Invoice_No + "' AND vw_cr_cashsalesinvoices.branch_code = '" + Branch_code + "'";
                }

                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //Put condition here of process mode

                    varinv_index = reader.GetValue(reader.GetOrdinal("inv_index")).ToString();
                    varcur_code = GetDataSafe(reader, "cur_code");


                }
                else
                {
                    varinv_index = String.Empty;
                    varcur_code = String.Empty;


                }

                cmd.Dispose();
                reader.Close();
                SqlConfig.ServerConn.Close();

            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
            }
        }
        public void XMLUUID()
        {

            try
            {
                Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
                string uuid = crypt.GenerateUuid();

                varX_UUID = uuid;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);

            }

        }
        public void RetrieveBranchInfo(string Branch_code)
        {
            try
            {
                Qry = string.Empty;
                Qry = "SELECT cs_orgunit.csorg_id,";
                Qry += "cs_orgunit.org_code,";
                Qry += "cs_orgunit.orgname,";
                Qry += "cs_orgunit.regunitId,";
                Qry += "cs_orgunit.sel_cntycode,";
                Qry += "cs_orgunit.sel_typeId,";
                Qry += "cs_orgunit.uniquename,";
                Qry += "cs_orgunit.sel_cityname,";
                Qry += "cs_orgunit.sel_streetname,";
                Qry += "cs_orgunit.sel_buildingname,";
                Qry += "cs_orgunit.sel_buildno,";
                Qry += "cs_orgunit.sel_plotid,";
                Qry += "cs_orgunit.sel_adbuildno,";
                Qry += "cs_orgunit.sel_postalzone,";
                Qry += "cs_orgunit.sel_subcitysubname,";
                Qry += "cs_orgunit.sel_countrySubentity ";
                Qry += "FROM cs_orgunit ";
                Qry += "WHERE ";
                Qry += "cs_orgunit.org_code = '" + Branch_code + "'";


                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //Put condition here of process mode

                    varbranch_Id = Convert.ToString(reader.GetValue(reader.GetOrdinal("csorg_id")));

                    varbranch_code = reader.GetString(reader.GetOrdinal("org_code"));
                    varsellers_name = reader.GetString(reader.GetOrdinal("orgname"));
                    varsel_vatreg = reader.GetString(reader.GetOrdinal("regunitId"));
                    varsel_cntycode = reader.GetString(reader.GetOrdinal("sel_cntycode"));
                    varsel_typeId = reader.GetString(reader.GetOrdinal("sel_typeId"));
                    varsellers_id = reader.GetString(reader.GetOrdinal("uniquename"));

                    varsel_cityname = GetDataSafe(reader, "sel_cityname") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_cityname"));
                    varsel_streetname = GetDataSafe(reader, "sel_streetname") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_streetname"));
                    varsel_buildingname = GetDataSafe(reader, "sel_buildingname") == String.Empty ? "." : GetDataSafe(reader, "sel_buildingname");
                    varsel_buildno = GetDataSafe(reader, "sel_buildno") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_buildno"));
                    varsel_plotid = GetDataSafe(reader, "sel_plotid") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_plotid"));
                    varsel_adbuildno = GetDataSafe(reader, "sel_adbuildno") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_adbuildno"));
                    varsel_postalzone = GetDataSafe(reader, "sel_postalzone") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_postalzone"));
                    varsel_subcitysubname = GetDataSafe(reader, "sel_subcitysubname") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_subcitysubname"));
                    varsel_countrySubentity = GetDataSafe(reader, "sel_countrySubentity") == String.Empty ? "." : reader.GetString(reader.GetOrdinal("sel_countrySubentity"));

                }
                else
                {
                    varbranch_code = String.Empty;
                    varsellers_name = String.Empty;
                    varsel_vatreg = String.Empty;
                    varsel_cntycode = String.Empty;
                    varsel_typeId = String.Empty;
                    varsellers_id = String.Empty;
                    varsel_cityname = String.Empty;
                    varsel_streetname = String.Empty;
                    varsel_buildingname = String.Empty;
                    varsel_buildno = String.Empty;
                    varsel_plotid = String.Empty;
                    varsel_adbuildno = String.Empty;
                    varsel_postalzone = String.Empty;
                    varsel_subcitysubname = String.Empty;
                    varsel_countrySubentity = String.Empty;

                }
                cmd.Dispose();
                reader.Close();
                SqlConfig.ServerConn.Close();

            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
            }
        }
        public void RetrieveBuyersInfo(string InvoiceType, string Branch_code, string Invoice_no)
        {
            try
            {



                if (InvoiceType == "Standard Invoice")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_salesinvoices.branch_id,";
                    Qry += "vw_salesinvoices.branch_code,";
                    Qry += "vw_salesinvoices.buy_name,";
                    Qry += "vw_salesinvoices.buy_vatno,";
                    Qry += "vw_salesinvoices.buy_countrycode,";
                    Qry += "vw_salesinvoices.buy_typeId,";
                    Qry += "vw_salesinvoices.buy_id,";
                    Qry += "vw_salesinvoices.buy_cityname,";
                    Qry += "vw_salesinvoices.buy_streetname,";
                    Qry += "vw_salesinvoices.buy_buildingname,";
                    Qry += "vw_salesinvoices.buy_buildno,";
                    Qry += "vw_salesinvoices.buy_plotid,";
                    Qry += "vw_salesinvoices.buy_adbuildno,";
                    Qry += "vw_salesinvoices.buy_postalzone,";
                    Qry += "vw_salesinvoices.buy_subcitysubname,";
                    Qry += "vw_salesinvoices.buy_countrySubentity ";
                    Qry += "FROM vw_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_salesinvoices.branch_code = '" + Branch_code + "' AND vw_salesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Standard Debit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_salesinvoices.branch_id,";
                    Qry += "vw_dr_salesinvoices.branch_code,";
                    Qry += "vw_dr_salesinvoices.buy_name,";
                    Qry += "vw_dr_salesinvoices.buy_vatno,";
                    Qry += "vw_dr_salesinvoices.buy_countrycode,";
                    Qry += "vw_dr_salesinvoices.buy_typeId,";
                    Qry += "vw_dr_salesinvoices.buy_id,";
                    Qry += "vw_dr_salesinvoices.buy_cityname,";
                    Qry += "vw_dr_salesinvoices.buy_streetname,";
                    Qry += "vw_dr_salesinvoices.buy_buildingname,";
                    Qry += "vw_dr_salesinvoices.buy_buildno,";
                    Qry += "vw_dr_salesinvoices.buy_plotid,";
                    Qry += "vw_dr_salesinvoices.buy_adbuildno,";
                    Qry += "vw_dr_salesinvoices.buy_postalzone,";
                    Qry += "vw_dr_salesinvoices.buy_subcitysubname,";
                    Qry += "vw_dr_salesinvoices.buy_countrySubentity ";
                    Qry += "FROM vw_dr_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_dr_salesinvoices.branch_code = '" + Branch_code + "' AND vw_dr_salesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Standard Credit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_salesinvoices.branch_id,";
                    Qry += "vw_cr_salesinvoices.branch_code,";
                    Qry += "vw_cr_salesinvoices.buy_name,";
                    Qry += "vw_cr_salesinvoices.buy_vatno,";
                    Qry += "vw_cr_salesinvoices.buy_countrycode,";
                    Qry += "vw_cr_salesinvoices.buy_typeId,";
                    Qry += "vw_cr_salesinvoices.buy_id,";
                    Qry += "vw_cr_salesinvoices.buy_cityname,";
                    Qry += "vw_cr_salesinvoices.buy_streetname,";
                    Qry += "vw_cr_salesinvoices.sel_buildingname buy_buildingname,";
                    Qry += "vw_cr_salesinvoices.buy_buildno,";
                    Qry += "vw_cr_salesinvoices.buy_plotid,";
                    Qry += "vw_cr_salesinvoices.buy_adbuildno,";
                    Qry += "vw_cr_salesinvoices.buy_postalzone,";
                    Qry += "vw_cr_salesinvoices.buy_citysubname buy_subcitysubname,";
                    Qry += "vw_cr_salesinvoices.buy_countrySubentity ";
                    Qry += "FROM vw_cr_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cr_salesinvoices.branch_code = '" + Branch_code + "' AND vw_cr_salesinvoices.inv_no = '" + Invoice_no + "'";
                    //--sel_buildingname  buy_buildingname 
                    //--buy_citysubname buy_subcitysubname
                }
                else if (InvoiceType == "Simplified Invoice")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_cashsalesinvoices.branch_id,";
                    Qry += "vw_cashsalesinvoices.branch_code,";
                    Qry += "vw_cashsalesinvoices.buy_name,";
                    Qry += "vw_cashsalesinvoices.buy_vatno,";
                    Qry += "vw_cashsalesinvoices.buy_countrycode,";
                    Qry += "vw_cashsalesinvoices.buy_typeId,";
                    Qry += "vw_cashsalesinvoices.buy_id,";
                    Qry += "vw_cashsalesinvoices.buy_cityname,";
                    Qry += "vw_cashsalesinvoices.buy_streetname,";
                    Qry += "vw_cashsalesinvoices.buy_buildingname,";
                    Qry += "vw_cashsalesinvoices.buy_buildno,";
                    Qry += "vw_cashsalesinvoices.buy_plotid,";
                    Qry += "vw_cashsalesinvoices.buy_adbuildno,";
                    Qry += "vw_cashsalesinvoices.buy_postalzone,";
                    Qry += "vw_cashsalesinvoices.buy_subcitysubname,";
                    Qry += "vw_cashsalesinvoices.buy_countrySubentity ";
                    Qry += "FROM vw_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cashsalesinvoices.branch_code = '" + Branch_code + "' AND vw_cashsalesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Simplified Debit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_cashsalesinvoices.branch_id,";
                    Qry += "vw_dr_cashsalesinvoices.branch_code,";
                    Qry += "vw_dr_cashsalesinvoices.buy_name,";
                    Qry += "vw_dr_cashsalesinvoices.buy_vatno,";
                    Qry += "vw_dr_cashsalesinvoices.buy_countrycode,";
                    Qry += "vw_dr_cashsalesinvoices.buy_typeId,";
                    Qry += "vw_dr_cashsalesinvoices.buy_id,";
                    Qry += "vw_dr_cashsalesinvoices.buy_cityname,";
                    Qry += "vw_dr_cashsalesinvoices.buy_streetname,";
                    Qry += "vw_dr_cashsalesinvoices.buy_buildingname,";
                    Qry += "vw_dr_cashsalesinvoices.buy_buildno,";
                    Qry += "vw_dr_cashsalesinvoices.buy_plotid,";
                    Qry += "vw_dr_cashsalesinvoices.buy_adbuildno,";
                    Qry += "vw_dr_cashsalesinvoices.buy_postalzone,";
                    Qry += "vw_dr_cashsalesinvoices.buy_subcitysubname,";
                    Qry += "vw_dr_cashsalesinvoices.buy_countrySubentity ";
                    Qry += "FROM vw_dr_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_dr_cashsalesinvoices.branch_code = '" + Branch_code + "' AND vw_dr_cashsalesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Simplified Credit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_cashsalesinvoices.branch_id,";
                    Qry += "vw_cr_cashsalesinvoices.branch_code,";
                    Qry += "vw_cr_cashsalesinvoices.buy_name,";
                    Qry += "vw_cr_cashsalesinvoices.buy_vatno,";
                    Qry += "vw_cr_cashsalesinvoices.buy_countrycode,";
                    Qry += "vw_cr_cashsalesinvoices.buy_typeId,";
                    Qry += "vw_cr_cashsalesinvoices.buy_id,";
                    Qry += "vw_cr_cashsalesinvoices.buy_cityname,";
                    Qry += "vw_cr_cashsalesinvoices.buy_streetname,";
                    Qry += "vw_cr_cashsalesinvoices.buy_buildingname,";
                    Qry += "vw_cr_cashsalesinvoices.buy_buildno,";
                    Qry += "vw_cr_cashsalesinvoices.buy_plotid,";
                    Qry += "vw_cr_cashsalesinvoices.buy_adbuildno,";
                    Qry += "vw_cr_cashsalesinvoices.buy_postalzone,";
                    Qry += "vw_cr_cashsalesinvoices.buy_subcitysubname,";
                    Qry += "vw_cr_cashsalesinvoices.buy_countrySubentity ";
                    Qry += "FROM vw_cr_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cr_cashsalesinvoices.branch_code = '" + Branch_code + "' AND vw_cr_cashsalesinvoices.inv_no = '" + Invoice_no + "'";


                }



                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //Put condition here of process mode

                    varinvbranch_Id = Convert.ToString(reader.GetOrdinal("branch_id"));

                    varinvbranch_code = GetDataSafe(reader, "branch_code");
                    varbuyers_name = GetDataSafe(reader, "buy_name");
                    varbuy_vatno = GetDataSafe(reader, "buy_vatno");
                    varbuy_countrycode = GetDataSafe(reader, "buy_countrycode");
                    varbuy_typeId = GetDataSafe(reader, "buy_typeId");
                    varbuy_id = GetDataSafe(reader, "buy_id");
                    varbuy_cityname = GetDataSafe(reader, "buy_cityname");
                    varbuy_streetname = GetDataSafe(reader, "buy_streetname");
                    varbuy_buildingname = GetDataSafe(reader, "buy_buildingname");
                    varbuy_buildno = GetDataSafe(reader, "buy_buildno");
                    varbuy_plotid = GetDataSafe(reader, "buy_plotid");
                    varbuy_adbuildno = GetDataSafe(reader, "buy_adbuildno");
                    varbuy_postalzone = GetDataSafe(reader, "buy_postalzone");
                    varbuy_subcitysubname = GetDataSafe(reader, "buy_subcitysubname");
                    varbuy_countrySubentity = GetDataSafe(reader, "buy_countrySubentity");

                }
                else
                {
                    varinvbranch_code = String.Empty;
                    varbuyers_name = String.Empty;
                    varbuy_vatno = String.Empty;
                    varbuy_countrycode = String.Empty;
                    varbuy_typeId = String.Empty;
                    varbuy_id = String.Empty;
                    varbuy_cityname = String.Empty;
                    varbuy_streetname = String.Empty;
                    varbuy_buildingname = String.Empty;
                    varbuy_buildno = String.Empty;
                    varbuy_plotid = String.Empty;
                    varbuy_adbuildno = String.Empty;
                    varbuy_postalzone = String.Empty;
                    varbuy_subcitysubname = String.Empty;
                    varbuy_countrySubentity = String.Empty;

                }
                cmd.Dispose();
                reader.Close();
                SqlConfig.ServerConn.Close();

            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
            }
        }
        public static void DisplayOrgUnitAcct(string connectionString, int AcctId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //string query = $"SELECT * FROM {tableName}";

                    string query = "SELECT ";
                    query += "acct_orgunit.csorg_id,";
                    query += "cs_orgunit.org_code,";
                    query += "FROM ";
                    query += "acct_orgunit ";
                    query += "LEFT OUTER JOIN cs_orgunit ON(acct_orgunit.csorg_id = cs_orgunit.csorg_id)";
                    query += "WHERE ";
                    query += "acct_orgunit.acct_id = " + AcctId + "";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> records = new List<string>();

                            while (reader.Read())
                            {
                                string record = reader.GetString(0);  // Assuming the first column contains the record to display
                                records.Add(record);
                            }
                            /*
                            Console.WriteLine("Records in ComboBox:");

                            foreach (string record in records)
                            {
                                Console.WriteLine(record);
                            }
                            */
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);

                }
            }
        }
        //public void RetrieveModeOfPayment(ComboBox ListModeOfPayment)
        //{
        //    try
        //    {
        //        ListModeOfPayment.DropDownStyle = ComboBoxStyle.DropDownList;
        //        Qry = string.Empty;
        //        Qry = "SELECT tblmodeofpayment.mpay_id,";
        //        Qry += "tblmodeofpayment.modepaycode,";
        //        Qry += "tblmodeofpayment.modeofpayment ";
        //        Qry += "FROM tblmodeofpayment ";
        //        Qry += "ORDER BY ";
        //        Qry += "tblmodeofpayment.mpay_id ASC";


        //        SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
        //        SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

        //        SqlDataReader reader = cmd.ExecuteReader();


        //        while (reader.Read())
        //        {

        //            string varmodepaycode = reader.GetString(reader.GetOrdinal("modepaycode"));
        //            string strmodeofpayment = reader.GetString(reader.GetOrdinal("modeofpayment"));

        //            ListModeOfPayment.Items.Add(strmodeofpayment);
        //            ListModeOfPayment.ValueMember = varmodepaycode;
        //        }
        //        cmd.Dispose();
        //        reader.Close();
        //        SqlConfig.ServerConn.Close();

        //    }
        //    catch (SqlException ex)
        //    {

        //        //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
        //        SqlConfig.ServerConn.Close();
        //    }
        //}
        //public void RetrieveModeOfPaymentTable(ComboBox ListModeOfPayment)
        //{
        //    try
        //    {
        //        ListModeOfPayment.DropDownStyle = ComboBoxStyle.DropDownList;
        //        Qry = string.Empty;
        //        Qry = "SELECT tblmodeofpayment.mpay_id,";
        //        Qry += "tblmodeofpayment.modepaycode,";
        //        Qry += "tblmodeofpayment.modeofpayment ";
        //        Qry += "FROM tblmodeofpayment ";
        //        Qry += "ORDER BY ";
        //        Qry += "tblmodeofpayment.mpay_id ASC";


        //        SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
        //        SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable table = new DataTable();
        //        adapter.Fill(table);

        //        // Bind data to combo box
        //        ListModeOfPayment.DataSource = table;
        //        ListModeOfPayment.DisplayMember = "modeofpayment";
        //        ListModeOfPayment.ValueMember = "modepaycode";

        //        cmd.Dispose();
        //        adapter.Dispose();
        //        SqlConfig.ServerConn.Close();

        //    }
        //    catch (SqlException ex)
        //    {
        //        //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
        //        SqlConfig.ServerConn.Close();
        //    }
        //}
        //public void RetrieveTaxExemptCode(ComboBox ListModeOfPayment)
        //{
        //    try
        //    {
        //        ListModeOfPayment.DropDownStyle = ComboBoxStyle.DropDownList;

        //        Qry = string.Empty;
        //        Qry = "SELECT ";
        //        Qry += "tbltaxexcept.taxexcid,";
        //        Qry += "tbltaxexcept.taxexceptcode ";
        //        Qry += "FROM ";
        //        Qry += "tbltaxexcept ";
        //        Qry += "ORDER BY ";
        //        Qry += "tbltaxexcept.taxexcid";

        //        SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
        //        SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable table = new DataTable();
        //        adapter.Fill(table);

        //        // Bind data to combo box
        //        ListModeOfPayment.DataSource = table;
        //        ListModeOfPayment.DisplayMember = "taxexceptcode";
        //        ListModeOfPayment.ValueMember = "taxexcid";

        //        cmd.Dispose();
        //        adapter.Dispose();
        //        SqlConfig.ServerConn.Close();

        //    }
        //    catch (SqlException ex)
        //    {
        //        //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
        //        SqlConfig.ServerConn.Close();
        //    }
        //}
        //public void RetrievetypeOfEndpoint(ComboBox ListModeOfPayment)
        //{
        //    try
        //    {
        //        ListModeOfPayment.DropDownStyle = ComboBoxStyle.DropDownList;
        //        Qry = string.Empty;
        //        Qry = "SELECT cs_unitendpoint.type_endpoint, ";
        //        Qry += "cs_unitendpoint.enp_id ";
        //        Qry += "FROM cs_unitendpoint ";
        //        Qry += "ORDER BY ";
        //        Qry += "cs_unitendpoint.enp_id ASC";


        //        SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
        //        SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

        //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //        DataTable table = new DataTable();
        //        adapter.Fill(table);

        //        // Bind data to combo box
        //        ListModeOfPayment.DataSource = table;
        //        ListModeOfPayment.DisplayMember = "type_endpoint";
        //        ListModeOfPayment.ValueMember = "enp_id";

        //        cmd.Dispose();
        //        adapter.Dispose();
        //        SqlConfig.ServerConn.Close();

        //    }
        //    catch (SqlException ex)
        //    {
        //        //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
        //        SqlConfig.ServerConn.Close();
        //    }
        //}

        public void RetrieveXMLDetails(string InvoiceType, string Branch_code, string Invoice_no)
        {
            try
            {
                if (InvoiceType == "Standard Invoice")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_salesinvoices.inv_type,";
                    Qry += "vw_salesinvoices.inv_no,";
                    Qry += "vw_salesinvoices.inv_date,";
                    Qry += "vw_salesinvoices.inv_time,";
                    Qry += "vw_salesinvoices.mode_ofpay,";
                    Qry += "vw_salesinvoices.deli_date,";
                    Qry += "vw_salesinvoices.actdeli_date,";
                    Qry += "vw_salesinvoices.Totamnt_allow,";
                    Qry += "vw_salesinvoices.Totamnt_disc,";
                    Qry += "vw_salesinvoices.gTotamnt_vat,";
                    Qry += "vw_salesinvoices.gTot_LineExtAmount,";
                    Qry += "vw_salesinvoices.gTotamnt_disc,";
                    Qry += "vw_salesinvoices.gTotamnt_allow,";
                    Qry += "vw_salesinvoices.gTot_TaxExclAmount,";
                    Qry += " vw_salesinvoices.gTot_TaxInclAmount,";
                    Qry += "vw_salesinvoices.gTotamnt_prepaid,";
                    Qry += "vw_salesinvoices.gTotamnt_payable ";
                    Qry += " FROM ";
                    Qry += "vw_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_salesinvoices.branch_code = '" + Branch_code + "' AND vw_salesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Standard Debit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_salesinvoices.inv_type,";
                    Qry += "vw_dr_salesinvoices.inv_no,";
                    Qry += "vw_dr_salesinvoices.inv_date,";
                    Qry += "vw_dr_salesinvoices.inv_time,";
                    Qry += "vw_dr_salesinvoices.refinv_no,";
                    Qry += "vw_dr_salesinvoices.InvRef_Date,";
                    Qry += "vw_dr_salesinvoices.instruction_code,";
                    Qry += "vw_dr_salesinvoices.mode_ofpay,";
                    Qry += "vw_dr_salesinvoices.deli_date,";
                    Qry += "vw_dr_salesinvoices.actdeli_date,";
                    Qry += "vw_dr_salesinvoices.Totamnt_allow,";
                    Qry += "vw_dr_salesinvoices.Totamnt_disc,";
                    Qry += "vw_dr_salesinvoices.gTotamnt_vat,";
                    Qry += "vw_dr_salesinvoices.gTot_LineExtAmount,";
                    Qry += "vw_dr_salesinvoices.gTotamnt_disc,";
                    Qry += "vw_dr_salesinvoices.gTotamnt_allow,";
                    Qry += "vw_dr_salesinvoices.gTot_TaxExclAmount,";
                    Qry += "vw_dr_salesinvoices.gTot_TaxInclAmount,";
                    Qry += "vw_dr_salesinvoices.gTotamnt_prepaid,";
                    Qry += "vw_dr_salesinvoices.gTotamnt_payable ";
                    Qry += " FROM ";
                    Qry += "vw_dr_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_dr_salesinvoices.branch_code = '" + Branch_code + "' AND vw_dr_salesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Standard Credit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_salesinvoices.inv_type,";
                    Qry += "vw_cr_salesinvoices.inv_no,";
                    Qry += "vw_cr_salesinvoices.inv_date,";
                    Qry += "vw_cr_salesinvoices.inv_time,";
                    Qry += "vw_cr_salesinvoices.invref_no refinv_no,";
                    Qry += "vw_cr_salesinvoices.InvRef_Date,";
                    Qry += "vw_cr_salesinvoices.instruction_code,";
                    Qry += "vw_cr_salesinvoices.mode_ofpay,";
                    Qry += "vw_cr_salesinvoices.deli_date,";
                    Qry += "vw_cr_salesinvoices.actdeli_date,";
                    Qry += "vw_cr_salesinvoices.gTotamnt_allow Totamnt_allow,";
                    Qry += "vw_cr_salesinvoices.gTotamnt_disc Totamnt_disc,";
                    Qry += "vw_cr_salesinvoices.gTotamnt_vat,";
                    Qry += "vw_cr_salesinvoices.gTot_LineExtAmount,";
                    Qry += "vw_cr_salesinvoices.gTotamnt_disc,";
                    Qry += "vw_cr_salesinvoices.gTotamnt_allow,";
                    Qry += "vw_cr_salesinvoices.gTot_TaxExclAmount,";
                    Qry += " vw_cr_salesinvoices.gTot_TaxInclAmount,";
                    Qry += "vw_cr_salesinvoices.gTotamnt_prepaid,";
                    Qry += "vw_cr_salesinvoices.gTotamnt_allow gTotamnt_payable ";
                    Qry += " FROM ";
                    Qry += "vw_cr_salesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cr_salesinvoices.branch_code = '" + Branch_code + "' AND vw_cr_salesinvoices.inv_no = '" + Invoice_no + "'";
//                    --invref_no  refinv_no
//--gTotamnt_allow Totamnt_allow
//--gTotamnt_disc Totamnt_disc
//--gTotamnt_allow gTotamnt_payable

                }
                else if (InvoiceType == "Simplified Invoice")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_cashsalesinvoices.inv_type,";
                    Qry += "vw_cashsalesinvoices.inv_no,";
                    Qry += "vw_cashsalesinvoices.inv_date,";
                    Qry += "vw_cashsalesinvoices.inv_time,";
                    Qry += "vw_cashsalesinvoices.mode_ofpay,";
                    Qry += "vw_cashsalesinvoices.deli_date,";
                    Qry += "vw_cashsalesinvoices.actdeli_date,";
                    Qry += "vw_cashsalesinvoices.Totamnt_allow,";
                    Qry += "vw_cashsalesinvoices.Totamnt_disc,";
                    Qry += "vw_cashsalesinvoices.gTotamnt_vat,";
                    Qry += "vw_cashsalesinvoices.gTot_LineExtAmount,";
                    Qry += "vw_cashsalesinvoices.gTotamnt_disc,";
                    Qry += "vw_cashsalesinvoices.gTotamnt_allow,";
                    Qry += "vw_cashsalesinvoices.gTot_TaxExclAmount,";
                    Qry += " vw_cashsalesinvoices.gTot_TaxInclAmount,";
                    Qry += "vw_cashsalesinvoices.gTotamnt_prepaid,";
                    Qry += "vw_cashsalesinvoices.gTotamnt_payable ";
                    Qry += " FROM ";
                    Qry += "vw_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cashsalesinvoices.branch_code = '" + Branch_code + "' AND vw_cashsalesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Simplified Debit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_cashsalesinvoices.inv_type,";
                    Qry += "vw_dr_cashsalesinvoices.inv_no,";
                    Qry += "vw_dr_cashsalesinvoices.inv_date,";
                    Qry += "vw_dr_cashsalesinvoices.inv_time,";
                    Qry += "vw_dr_cashsalesinvoices.refinv_no,";
                    Qry += "vw_dr_cashsalesinvoices.InvRef_Date,";
                    Qry += "vw_dr_cashsalesinvoices.instruction_code,";
                    Qry += "vw_dr_cashsalesinvoices.mode_ofpay,";
                    Qry += "vw_dr_cashsalesinvoices.deli_date,";
                    Qry += "vw_dr_cashsalesinvoices.actdeli_date,";
                    Qry += "vw_dr_cashsalesinvoices.Totamnt_allow,";
                    Qry += "vw_dr_cashsalesinvoices.Totamnt_disc,";
                    Qry += "vw_dr_cashsalesinvoices.gTotamnt_vat,";
                    Qry += "vw_dr_cashsalesinvoices.gTot_LineExtAmount,";
                    Qry += "vw_dr_cashsalesinvoices.gTotamnt_disc,";
                    Qry += "vw_dr_cashsalesinvoices.gTotamnt_allow,";
                    Qry += "vw_dr_cashsalesinvoices.gTot_TaxExclAmount,";
                    Qry += " vw_dr_cashsalesinvoices.gTot_TaxInclAmount,";
                    Qry += "vw_dr_cashsalesinvoices.gTotamnt_prepaid,";
                    Qry += "vw_dr_cashsalesinvoices.gTotamnt_payable ";
                    Qry += " FROM ";
                    Qry += "vw_dr_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_dr_cashsalesinvoices.branch_code = '" + Branch_code + "' AND vw_dr_cashsalesinvoices.inv_no = '" + Invoice_no + "'";

                }
                else if (InvoiceType == "Simplified Credit Note")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_cashsalesinvoices.inv_type,";
                    Qry += "vw_cr_cashsalesinvoices.inv_no,";
                    Qry += "vw_cr_cashsalesinvoices.inv_date,";
                    Qry += "vw_cr_cashsalesinvoices.inv_time,";
                    Qry += "vw_cr_cashsalesinvoices.refinv_no,";
                    Qry += "vw_cr_cashsalesinvoices.InvRef_Date,";
                    Qry += "vw_cr_cashsalesinvoices.instruction_code,";
                    Qry += "vw_cr_cashsalesinvoices.mode_ofpay,";
                    Qry += "vw_cr_cashsalesinvoices.deli_date,";
                    Qry += "vw_cr_cashsalesinvoices.actdeli_date,";
                    Qry += "vw_cr_cashsalesinvoices.Totamnt_allow,";
                    Qry += "vw_cr_cashsalesinvoices.Totamnt_disc,";
                    Qry += "vw_cr_cashsalesinvoices.gTotamnt_vat,";
                    Qry += "vw_cr_cashsalesinvoices.gTot_LineExtAmount,";
                    Qry += "vw_cr_cashsalesinvoices.gTotamnt_disc,";
                    Qry += "vw_cr_cashsalesinvoices.gTotamnt_allow,";
                    Qry += "vw_cr_cashsalesinvoices.gTot_TaxExclAmount,";
                    Qry += " vw_cr_cashsalesinvoices.gTot_TaxInclAmount,";
                    Qry += "vw_cr_cashsalesinvoices.gTotamnt_prepaid,";
                    Qry += "vw_cr_cashsalesinvoices.gTotamnt_payable ";
                    Qry += " FROM ";
                    Qry += "vw_cr_cashsalesinvoices ";
                    Qry += "WHERE ";
                    Qry += "vw_cr_cashsalesinvoices.branch_code = '" + Branch_code + "' AND vw_cr_cashsalesinvoices.inv_no = '" + Invoice_no + "'";

                }


                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //Put condition here of process mode
                    varinv_type = GetDataSafe(reader, "inv_type");
                    varinv_no = GetDataSafe(reader, "inv_no");

                    varinv_date = reader.GetDateTime(reader.GetOrdinal("inv_date")).ToString("yyyy-MM-dd");
                    //varinv_date = reader.GetString(reader.GetOrdinal("inv_date"));

                    varinv_time = GetDataSafe(reader, "inv_time");

                    string ExDrInvoice = "Debit";
                    string ExCrInvoice = "Credit";

                    int LookValDr = varinv_type.IndexOf(ExDrInvoice);
                    int LookValCr = varinv_type.IndexOf(ExCrInvoice);

                    if ((LookValDr > 0) || (LookValCr > 0))
                    {
                        varrefinv_no = GetDataSafe(reader, "refinv_no");
                        varRef_Date = reader.GetDateTime(reader.GetOrdinal("InvRef_Date")).ToString("yyyy-MM-dd");
                        varinstruction_code = GetDataSafe(reader, "instruction_code");
                    }

                    varmode_ofpay = GetDataSafe(reader, "mode_ofpay");
                    vardeli_date = reader.GetDateTime(reader.GetOrdinal("deli_date")).ToString("yyyy-MM-dd");
                    //vardeli_date = reader.GetString(reader.GetOrdinal("deli_date"));

                    varactdeli_date = reader.GetDateTime(reader.GetOrdinal("actdeli_date")).ToString("yyyy-MM-dd");
                    //varactdeli_date = reader.GetString(reader.GetOrdinal("actdeli_date"));

                    varTotamnt_allow = Convert.ToString(reader.GetValue(reader.GetOrdinal("Totamnt_allow")));
                    varTotamnt_disc = Convert.ToString(reader.GetValue(reader.GetOrdinal("Totamnt_disc")));
                    vargTotamnt_vat = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTotamnt_vat")));
                    vargTot_LineExtAmount = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTot_LineExtAmount")));
                    vargTotamnt_disc = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTotamnt_disc")));
                    vargTotamnt_allow = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTotamnt_allow")));
                    vargTot_TaxExclAmount = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTot_TaxExclAmount")));
                    vargTot_TaxInclAmount = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTot_TaxInclAmount")));
                    vargTotamnt_prepaid = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTotamnt_prepaid")));
                    vargTotamnt_payable = Convert.ToString(reader.GetValue(reader.GetOrdinal("gTotamnt_payable")));

                }
                else
                {

                    varinv_no = String.Empty;
                    varinv_date = String.Empty;
                    varinv_time = String.Empty;
                    varinstruction_code = String.Empty;
                    varmode_ofpay = String.Empty;
                    vardeli_date = String.Empty;
                    varactdeli_date = String.Empty;
                    varvat_breakdown = String.Empty;
                    varTotamnt_allow = String.Empty;
                    varTotamnt_disc = String.Empty;
                    vargTotamnt_vat = String.Empty;
                    vargTot_LineExtAmount = String.Empty;
                    vargTotamnt_disc = String.Empty;
                    vargTotamnt_allow = String.Empty;
                    vargTot_TaxExclAmount = String.Empty;
                    vargTot_TaxInclAmount = String.Empty;
                    vargTotamnt_prepaid = String.Empty;
                    vargTotamnt_payable = String.Empty;

                }
                cmd.Dispose();
                reader.Close();
                SqlConfig.ServerConn.Close();

            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
            }
        }
        //public void DisplayInvoiceLineItems(DataGridView sDataGridView, string InvoiceType, string Sel_InvoiceNo, double refInvIndex)
        //{
        //    try
        //    {
        //        SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

        //        if (InvoiceType == "Standard Invoice")
        //        {
        //            Qry = string.Empty;
        //            Qry = "SELECT vw_saleinvoicesdetails.dtl_index, ";
        //            Qry += "vw_saleinvoicesdetails.item_description,";
        //            Qry += "vw_saleinvoicesdetails.item_qty, ";
        //            Qry += "vw_saleinvoicesdetails.item_unit, ";
        //            Qry += "vw_saleinvoicesdetails.item_price, ";
        //            Qry += "vw_saleinvoicesdetails.lineExtAmount, ";
        //            Qry += "vw_saleinvoicesdetails.amnt_disc, ";
        //            Qry += "vw_saleinvoicesdetails.taxExclAmount, ";
        //            Qry += "vw_saleinvoicesdetails.tax_code, ";
        //            Qry += "vw_saleinvoicesdetails.tax_exceptcode,";
        //            Qry += "vw_saleinvoicesdetails.except_reason, ";
        //            Qry += "vw_saleinvoicesdetails.per_vat, ";
        //            Qry += "vw_saleinvoicesdetails.amnt_vat, ";
        //            Qry += "vw_saleinvoicesdetails.taxInclAmount ";
        //            Qry += "FROM vw_saleinvoicesdetails ";
        //            Qry += "WHERE vw_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND ";
        //            Qry += "vw_saleinvoicesdetails.inv_index = " + refInvIndex + " ORDER BY vw_saleinvoicesdetails.inv_index";

        //        }
        //        else if (InvoiceType == "Standard Debit Note")
        //        {
        //            Qry = string.Empty;
        //            Qry = "SELECT '', ";
        //            Qry += "vw_dr_saleinvoicesdetails.item_description,";
        //            Qry += "vw_dr_saleinvoicesdetails.item_qty, ";
        //            Qry += "vw_dr_saleinvoicesdetails.item_unit, ";
        //            Qry += "vw_dr_saleinvoicesdetails.item_price, ";
        //            Qry += "vw_dr_saleinvoicesdetails.lineExtAmount, ";
        //            Qry += "vw_dr_saleinvoicesdetails.amnt_disc, ";
        //            Qry += "vw_dr_saleinvoicesdetails.taxExclAmount, ";
        //            Qry += "vw_dr_saleinvoicesdetails.tax_code, ";
        //            Qry += "vw_dr_saleinvoicesdetails.tax_exceptcode,";
        //            Qry += "vw_dr_saleinvoicesdetails.except_reason, ";
        //            Qry += "vw_dr_saleinvoicesdetails.per_vat, ";
        //            Qry += "vw_dr_saleinvoicesdetails.amnt_vat, ";
        //            Qry += "vw_dr_saleinvoicesdetails.taxInclAmount ";
        //            Qry += "FROM vw_dr_saleinvoicesdetails ";
        //            Qry += "WHERE vw_dr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND ";
        //            Qry += "vw_dr_saleinvoicesdetails.inv_index = " + refInvIndex + " ORDER BY vw_dr_saleinvoicesdetails.inv_index";
        //        }
        //        else if (InvoiceType == "Standard Credit Note")
        //        {
        //            Qry = string.Empty;
        //            Qry = "SELECT '', ";
        //            Qry += "vw_cr_saleinvoicesdetails.item_description,";
        //            Qry += "vw_cr_saleinvoicesdetails.item_qty, ";
        //            Qry += "vw_cr_saleinvoicesdetails.item_unit, ";
        //            Qry += "vw_cr_saleinvoicesdetails.item_price, ";
        //            Qry += "vw_cr_saleinvoicesdetails.lineExtAmount, ";
        //            Qry += "vw_cr_saleinvoicesdetails.amnt_disc, ";
        //            Qry += "vw_cr_saleinvoicesdetails.taxExclAmount, ";
        //            Qry += "vw_cr_saleinvoicesdetails.tax_code, ";
        //            Qry += "vw_cr_saleinvoicesdetails.tax_exceptcode,";
        //            Qry += "vw_cr_saleinvoicesdetails.except_reason, ";
        //            Qry += "vw_cr_saleinvoicesdetails.per_vat, ";
        //            Qry += "vw_cr_saleinvoicesdetails.amnt_vat, ";
        //            Qry += "vw_cr_saleinvoicesdetails.taxInclAmount ";
        //            Qry += "FROM vw_cr_saleinvoicesdetails ";
        //            Qry += "WHERE vw_cr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND ";
        //            Qry += "vw_cr_saleinvoicesdetails.inv_index = " + refInvIndex + " ORDER BY vw_cr_saleinvoicesdetails.inv_index";
        //        }
        //        else if (InvoiceType == "Simplified Invoice")
        //        {
        //            Qry = string.Empty;
        //            Qry = "SELECT '', ";
        //            Qry += "vw_cashsaleinvoicesdetails.item_description,";
        //            Qry += "vw_cashsaleinvoicesdetails.item_qty, ";
        //            Qry += "vw_cashsaleinvoicesdetails.item_unit, ";
        //            Qry += "vw_cashsaleinvoicesdetails.item_price, ";
        //            Qry += "vw_cashsaleinvoicesdetails.lineExtAmount, ";
        //            Qry += "vw_cashsaleinvoicesdetails.amnt_disc, ";
        //            Qry += "vw_cashsaleinvoicesdetails.taxExclAmount, ";
        //            Qry += "vw_cashsaleinvoicesdetails.tax_code, ";
        //            Qry += "vw_cashsaleinvoicesdetails.tax_exceptcode,";
        //            Qry += "vw_cashsaleinvoicesdetails.except_reason, ";
        //            Qry += "vw_cashsaleinvoicesdetails.per_vat, ";
        //            Qry += "vw_cashsaleinvoicesdetails.amnt_vat, ";
        //            Qry += "vw_cashsaleinvoicesdetails.taxInclAmount ";
        //            Qry += "FROM vw_cashsaleinvoicesdetails ";
        //            Qry += "WHERE vw_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND ";
        //            Qry += "vw_cashsaleinvoicesdetails.inv_index = " + refInvIndex + " ORDER BY vw_cashsaleinvoicesdetails.inv_index";
        //        }
        //        else if (InvoiceType == "Simplified Debit Note")
        //        {
        //            Qry = string.Empty;
        //            Qry = "SELECT '', ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.item_description,";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.item_qty, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.item_unit, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.item_price, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.lineExtAmount, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.amnt_disc, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.taxExclAmount, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.tax_code, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.tax_exceptcode,";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.except_reason, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.per_vat, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.amnt_vat, ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.taxInclAmount ";
        //            Qry += "FROM vw_dr_cashsaleinvoicesdetails ";
        //            Qry += "WHERE vw_dr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND ";
        //            Qry += "vw_dr_cashsaleinvoicesdetails.inv_index = " + refInvIndex + " ORDER BY vw_dr_cashsaleinvoicesdetails.inv_index";
        //        }
        //        else if (InvoiceType == "Simplified Credit Note")
        //        {
        //            Qry = string.Empty;
        //            Qry = "SELECT '', ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.item_description,";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.item_qty, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.item_unit, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.item_price, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.lineExtAmount, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.amnt_disc, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.taxExclAmount, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.tax_code, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.tax_exceptcode,";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.except_reason, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.per_vat, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.amnt_vat, ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.taxInclAmount ";
        //            Qry += "FROM vw_cr_cashsaleinvoicesdetails ";
        //            Qry += "WHERE vw_cr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND ";
        //            Qry += "vw_cr_cashsaleinvoicesdetails.inv_index = " + refInvIndex + " ORDER BY vw_cr_cashsaleinvoicesdetails.inv_index";
        //        }

        //        SqlCommand Cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
        //        SqlDataAdapter SqlAdtr = new SqlDataAdapter(Cmd);
        //        DataTable Data_Set = new DataTable();
        //        SqlAdtr.Fill(Data_Set);
        //        sDataGridView.DataSource = Data_Set;

        //        Cmd.Dispose();
        //        SqlAdtr.Dispose();
        //        SqlConfig.ServerConn.Close();

        //    }
        //    catch (SqlException ex)
        //    {
        //        //MessageBox.Show($"Error: {ex.Message}");
        //        SqlConfig.ServerConn.Close();
        //    }

        //}
        //public static void AddComboBoxToCellControl(DataGridView dataGridView, int rowIndex, int columnIndex, string[] items)
        //{
        //    // Create a new ComboBox control.
        //    var comboBox = new ComboBox();

        //    // Set the ComboBox properties.
        //    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        //    comboBox.Items.AddRange(items);

        //    // Add the ComboBox control to the DataGridView cell.
        //    dataGridView.Controls.Add(comboBox);
        //    comboBox.Visible = true;

        //    // Set the ComboBox location and size to match the cell.
        //    var cellRect = dataGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false);
        //    comboBox.Location = new System.Drawing.Point(cellRect.X, cellRect.Y);
        //    comboBox.Size = new Size(cellRect.Width, cellRect.Height);
        //}
        //public static void AddComboBoxToCell(DataGridView dataGridView, ComboBox comboBox, int rowIndex, int columnIndex)
        //{

        //    comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        //    dataGridView.Controls.Add(comboBox);
        //    comboBox.Visible = true;

        //    var cellRect = dataGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false);
        //    comboBox.Location = new System.Drawing.Point(cellRect.X, cellRect.Y);
        //    comboBox.Size = new Size(cellRect.Width, cellRect.Height);
        //}
        public void XMLGroupTaxTotal(string InvoiceType, string Sel_InvoiceNo)
        {
            try
            {


                if (InvoiceType == "Standard Invoice")
                {
                    //Qry = string.Empty;
                    //Qry = "SELECT SUM(vw_saleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    //Qry +=  "SUM(vw_saleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    //Qry +=  "vw_saleinvoicesdetails.tax_code,";
                    //Qry +=  "vw_saleinvoicesdetails.per_vat,";
                    //Qry +=  "vw_saleinvoicesdetails.tax_exceptcode,";
                    //Qry +=  "vw_saleinvoicesdetails.except_reason";
                    //Qry +=  " FROM ";
                    //Qry +=  "vw_saleinvoicesdetails";
                    //Qry +=  " WHERE ";
                    //Qry +=  "vw_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    //Qry +=  " GROUP BY ";
                    //Qry +=  "vw_saleinvoicesdetails.tax_code,";
                    //Qry +=  "vw_saleinvoicesdetails.per_vat,";
                    //Qry +=  "vw_saleinvoicesdetails.tax_exceptcode,";
                    //Qry +=  "vw_saleinvoicesdetails.except_reason";
                    Qry = string.Empty;
                    Qry = "SELECT vw_saleinvoicesdetails.amnt_vat AS Totalamnt_vat,";
                    Qry += "vw_saleinvoicesdetails.taxExclAmount AS TotaltaxExclAmount,";
                    Qry += "vw_saleinvoicesdetails.tax_code,";
                    Qry += "vw_saleinvoicesdetails.per_vat,";
                    Qry += "vw_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_saleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_saleinvoicesdetails.dtl_index";

                }
                else if (InvoiceType == "Standard Debit Note")
                {
                    //Qry = string.Empty;
                    //Qry = "SELECT SUM(vw_dr_saleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    //Qry += "SUM(vw_dr_saleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    //Qry += "vw_dr_saleinvoicesdetails.tax_code,";
                    //Qry += "vw_dr_saleinvoicesdetails.per_vat,";
                    //Qry += "vw_dr_saleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_dr_saleinvoicesdetails.except_reason";
                    //Qry += " FROM ";
                    //Qry += "vw_dr_saleinvoicesdetails";
                    //Qry += " WHERE ";
                    //Qry += "vw_dr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    //Qry += " GROUP BY ";
                    //Qry += "vw_dr_saleinvoicesdetails.tax_code,";
                    //Qry += "vw_dr_saleinvoicesdetails.per_vat,";
                    //Qry += "vw_dr_saleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_dr_saleinvoicesdetails.except_reason";

                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_saleinvoicesdetails.amnt_vat AS Totalamnt_vat,";
                    Qry += "vw_dr_saleinvoicesdetails.taxExclAmount AS TotaltaxExclAmount,";
                    Qry += "vw_dr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_dr_saleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_dr_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_dr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_dr_saleinvoicesdetails.dtl_index";


                }
                else if (InvoiceType == "Standard Credit Note")
                {
                    //Qry = string.Empty;
                    //Qry = "SELECT SUM(vw_cr_saleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    //Qry += "SUM(vw_cr_saleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    //Qry += "vw_cr_saleinvoicesdetails.tax_code,";
                    //Qry += "vw_cr_saleinvoicesdetails.per_vat,";
                    //Qry += "vw_cr_saleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_cr_saleinvoicesdetails.except_reason";
                    //Qry += " FROM ";
                    //Qry += "vw_cr_saleinvoicesdetails";
                    //Qry += " WHERE ";
                    //Qry += "vw_cr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    //Qry += " GROUP BY ";
                    //Qry += "vw_cr_saleinvoicesdetails.tax_code,";
                    //Qry += "vw_cr_saleinvoicesdetails.per_vat,";
                    //Qry += "vw_cr_saleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_cr_saleinvoicesdetails.except_reason";

                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_saleinvoicesdetails.amnt_vat AS Totalamnt_vat,";
                    Qry += "vw_cr_saleinvoicesdetails.taxExclAmount AS TotaltaxExclAmount,";
                    Qry += "vw_cr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cr_saleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_cr_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_cr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_cr_saleinvoicesdetails.dtl_index";

                }
                else if (InvoiceType == "Simplified Invoice")
                {

                    //Qry = string.Empty;
                    //Qry = "SELECT SUM(vw_cashsaleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    //Qry +=  "SUM(vw_cashsaleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    //Qry +=  "vw_cashsaleinvoicesdetails.tax_code,";
                    //Qry +=  "vw_cashsaleinvoicesdetails.per_vat,";
                    //Qry +=  "vw_cashsaleinvoicesdetails.tax_exceptcode,";
                    //Qry +=  "vw_cashsaleinvoicesdetails.except_reason";
                    //Qry +=  " FROM ";
                    //Qry +=  "vw_cashsaleinvoicesdetails";
                    //Qry +=  " WHERE ";
                    //Qry +=  "vw_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    //Qry +=  " GROUP BY ";
                    //Qry +=  "vw_cashsaleinvoicesdetails.tax_code,";
                    //Qry +=  "vw_cashsaleinvoicesdetails.per_vat,";
                    //Qry +=  "vw_cashsaleinvoicesdetails.tax_exceptcode,";
                    //Qry +=  "vw_cashsaleinvoicesdetails.except_reason";
                    //Qry = string.Empty;
                    Qry = "SELECT vw_cashsaleinvoicesdetails.amnt_vat AS Totalamnt_vat,";
                    Qry += "vw_cashsaleinvoicesdetails.taxExclAmount AS TotaltaxExclAmount,";
                    Qry += "vw_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cashsaleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_cashsaleinvoicesdetails.dtl_index";

                }
                else if (InvoiceType == "Simplified Debit Note")
                {
                    //Qry = string.Empty;
                    //Qry = "SELECT SUM(vw_dr_cashsaleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    //Qry += "SUM(vw_dr_cashsaleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.tax_code,";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.per_vat,";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.except_reason";
                    //Qry += " FROM ";
                    //Qry += "vw_dr_cashsaleinvoicesdetails";
                    //Qry += " WHERE ";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    //Qry += " GROUP BY ";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.tax_code,";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.per_vat,";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_dr_cashsaleinvoicesdetails.except_reason";

                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_cashsaleinvoicesdetails.amnt_vat AS Totalamnt_vat,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.taxExclAmount AS TotaltaxExclAmount,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_dr_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_dr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_dr_cashsaleinvoicesdetails.dtl_index";


                }
                else if (InvoiceType == "Simplified Credit Note")
                {
                    //Qry = string.Empty;
                    //Qry = "SELECT SUM(vw_cr_cashsaleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    //Qry += "SUM(vw_cr_cashsaleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.tax_code,";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.per_vat,";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.except_reason";
                    //Qry += " FROM ";
                    //Qry += "vw_cr_cashsaleinvoicesdetails";
                    //Qry += " WHERE ";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    //Qry += " GROUP BY ";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.tax_code,";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.per_vat,";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.tax_exceptcode,";
                    //Qry += "vw_cr_cashsaleinvoicesdetails.except_reason"

                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_cashsaleinvoicesdetails.amnt_vat AS Totalamnt_vat,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.taxExclAmount AS TotaltaxExclAmount,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_cr_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_cr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " GROUP BY ";
                    Qry += "vw_cr_cashsaleinvoicesdetails.dtl_index";

                }

                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
                SqlDataReader reader = cmd.ExecuteReader();

                //object[,] GroupTaxTotal = new object[reader.FieldCount, reader.RecordsAffected];
                GroupTaxTotaldata = new object[reader.FieldCount, reader.VisibleFieldCount];


                // Loop through the data and store it in the array
                int row = 0;
                while (reader.Read())
                {
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        GroupTaxTotaldata[col, row] = reader.GetValue(col);
                    }
                    row++;
                }
                InvGp_ItemCount = row;

                cmd.Dispose();
                reader.Close();
                SqlConfig.ServerConn.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
                SqlConfig.ServerConn.Close();
            }


        }
        public void XMLGroupTaxTotalSEOZ(string InvoiceType, string Sel_InvoiceNo)
        {
            try
            {


                if (InvoiceType == "Standard Invoice")
                {
                    Qry = string.Empty;
                    Qry = "SELECT SUM(vw_saleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    Qry += "SUM(vw_saleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    Qry += "vw_saleinvoicesdetails.tax_code,";
                    Qry += "vw_saleinvoicesdetails.per_vat,";
                    Qry += "vw_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_saleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " GROUP BY ";
                    Qry += "vw_saleinvoicesdetails.tax_code,";
                    Qry += "vw_saleinvoicesdetails.per_vat,";
                    Qry += "vw_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_saleinvoicesdetails.except_reason";


                }
                else if (InvoiceType == "Standard Debit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT SUM(vw_dr_saleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    Qry += "SUM(vw_dr_saleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    Qry += "vw_dr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_dr_saleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_dr_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_dr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " GROUP BY ";
                    Qry += "vw_dr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_dr_saleinvoicesdetails.except_reason";




                }
                else if (InvoiceType == "Standard Credit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT SUM(vw_cr_saleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    Qry += "SUM(vw_cr_saleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    Qry += "vw_cr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cr_saleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_cr_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_cr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " GROUP BY ";
                    Qry += "vw_cr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_saleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cr_saleinvoicesdetails.except_reason";


                }
                else if (InvoiceType == "Simplified Invoice")
                {

                    Qry = string.Empty;
                    Qry = "SELECT SUM(vw_cashsaleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    Qry += "SUM(vw_cashsaleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    Qry += "vw_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cashsaleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " GROUP BY ";
                    Qry += "vw_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cashsaleinvoicesdetails.except_reason";


                }
                else if (InvoiceType == "Simplified Debit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT SUM(vw_dr_cashsaleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    Qry += "SUM(vw_dr_cashsaleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_dr_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_dr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " GROUP BY ";
                    Qry += "vw_dr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.except_reason";


                }
                else if (InvoiceType == "Simplified Credit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT SUM(vw_cr_cashsaleinvoicesdetails.amnt_vat) AS Totalamnt_vat,";
                    Qry += "SUM(vw_cr_cashsaleinvoicesdetails.taxExclAmount) AS TotaltaxExclAmount,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.except_reason";
                    Qry += " FROM ";
                    Qry += "vw_cr_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += "vw_cr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " GROUP BY ";
                    Qry += "vw_cr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.tax_exceptcode,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.except_reason";



                }

                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
                SqlDataReader reader = cmd.ExecuteReader();

                //object[,] GroupTaxTotal = new object[reader.FieldCount, reader.RecordsAffected];
                GroupTaxTotaldataSEOZ = new object[reader.FieldCount, reader.VisibleFieldCount];


                // Loop through the data and store it in the array
                int row = 0;
                while (reader.Read())
                {
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        GroupTaxTotaldataSEOZ[col, row] = reader.GetValue(col);
                    }
                    row++;
                }
                InvGp_ItemCountSEOZ = row;

                cmd.Dispose();
                reader.Close();
                SqlConfig.ServerConn.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
                SqlConfig.ServerConn.Close();
            }


        }
        public void XMLInvoiceLine(string InvoiceType, string Sel_InvoiceNo)
        {
            try
            {

                if (InvoiceType == "Standard Invoice")
                {
                    Qry = string.Empty;
                    Qry = "SELECT vw_saleinvoicesdetails.dtl_index,";
                    Qry += "vw_saleinvoicesdetails.item_qty,";
                    Qry += "vw_saleinvoicesdetails.item_description,";
                    Qry += "vw_saleinvoicesdetails.taxExclAmount,";
                    Qry += "vw_saleinvoicesdetails.amnt_disc,";
                    Qry += "vw_saleinvoicesdetails.amnt_vat,";
                    Qry += "vw_saleinvoicesdetails.taxInclAmount,";
                    Qry += "vw_saleinvoicesdetails.tax_code,";
                    Qry += "vw_saleinvoicesdetails.per_vat,";
                    Qry += "vw_saleinvoicesdetails.item_price,";
                    Qry += "vw_saleinvoicesdetails.item_qty AS BaseQTY";
                    Qry += " FROM";
                    Qry += " vw_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += " vw_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_saleinvoicesdetails.dtl_index";
                }
                else if (InvoiceType == "Standard Debit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_saleinvoicesdetails.dtl_index,";
                    Qry += "vw_dr_saleinvoicesdetails.item_qty,";
                    Qry += "vw_dr_saleinvoicesdetails.item_description,";
                    Qry += "vw_dr_saleinvoicesdetails.taxExclAmount,";
                    Qry += "vw_dr_saleinvoicesdetails.amnt_disc,";
                    Qry += "vw_dr_saleinvoicesdetails.amnt_vat,";
                    Qry += "vw_dr_saleinvoicesdetails.taxInclAmount,";
                    Qry += "vw_dr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_saleinvoicesdetails.item_price,";
                    Qry += "vw_dr_saleinvoicesdetails.item_qty AS BaseQTY";
                    Qry += " FROM";
                    Qry += " vw_dr_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += " vw_dr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_dr_saleinvoicesdetails.dtl_index";

                }
                else if (InvoiceType == "Standard Credit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_saleinvoicesdetails.dtl_index,";
                    Qry += "vw_cr_saleinvoicesdetails.item_qty,";
                    Qry += "vw_cr_saleinvoicesdetails.item_description,";
                    Qry += "vw_cr_saleinvoicesdetails.taxExclAmount,";
                    Qry += "vw_cr_saleinvoicesdetails.amnt_disc,";
                    Qry += "vw_cr_saleinvoicesdetails.amnt_vat,";
                    Qry += "vw_cr_saleinvoicesdetails.taxInclAmount,";
                    Qry += "vw_cr_saleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_saleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_saleinvoicesdetails.item_price,";
                    Qry += "vw_cr_saleinvoicesdetails.item_qty AS BaseQTY";
                    Qry += " FROM";
                    Qry += " vw_cr_saleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += " vw_cr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_cr_saleinvoicesdetails.dtl_index";

                }
                else if (InvoiceType == "Simplified Invoice")
                {

                    Qry = string.Empty;
                    Qry = "SELECT vw_cashsaleinvoicesdetails.dtl_index,";
                    Qry += "vw_cashsaleinvoicesdetails.item_qty,";
                    Qry += "vw_cashsaleinvoicesdetails.item_description,";
                    Qry += "vw_cashsaleinvoicesdetails.taxExclAmount,";
                    Qry += "vw_cashsaleinvoicesdetails.amnt_disc,";
                    Qry += "vw_cashsaleinvoicesdetails.amnt_vat,";
                    Qry += "vw_cashsaleinvoicesdetails.taxInclAmount,";
                    Qry += "vw_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cashsaleinvoicesdetails.item_price,";
                    Qry += "vw_cashsaleinvoicesdetails.item_qty AS BaseQTY";
                    Qry += " FROM";
                    Qry += " vw_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += " vw_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_cashsaleinvoicesdetails.dtl_index";

                }
                else if (InvoiceType == "Simplified Debit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT vw_dr_cashsaleinvoicesdetails.dtl_index,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.item_qty,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.item_description,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.taxExclAmount,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.amnt_disc,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.amnt_vat,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.taxInclAmount,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.item_price,";
                    Qry += "vw_dr_cashsaleinvoicesdetails.item_qty AS BaseQTY";
                    Qry += " FROM";
                    Qry += " vw_dr_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += " vw_dr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_dr_cashsaleinvoicesdetails.dtl_index";

                }
                else if (InvoiceType == "Simplified Credit Note")
                {
                    Qry = string.Empty;
                    Qry = "SELECT vw_cr_cashsaleinvoicesdetails.dtl_index,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.item_qty,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.item_description,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.taxExclAmount,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.amnt_disc,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.amnt_vat,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.taxInclAmount,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.tax_code,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.per_vat,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.item_price,";
                    Qry += "vw_cr_cashsaleinvoicesdetails.item_qty AS BaseQTY";
                    Qry += " FROM";
                    Qry += " vw_cr_cashsaleinvoicesdetails";
                    Qry += " WHERE ";
                    Qry += " vw_cr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "'";
                    Qry += " ORDER BY ";
                    Qry += "vw_cr_cashsaleinvoicesdetails.dtl_index";

                }

                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
                SqlDataReader reader = cmd.ExecuteReader();

                //object[,] GroupTaxTotal = new object[reader.FieldCount, reader.RecordsAffected];
                ParseInvoiceLinedata = new object[reader.FieldCount, reader.VisibleFieldCount];


                // Loop through the data and store it in the array
                int row = 0;
                while (reader.Read())
                {
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        ParseInvoiceLinedata[col, row] = reader.GetValue(col);
                    }
                    row++;
                }
                Inv_ItemCount = row;

                cmd.Dispose();
                reader.Close();
                SqlConfig.ServerConn.Close();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
                SqlConfig.ServerConn.Close();
            }


        }
        public static string GetDataSafe(SqlDataReader reader, string fieldName)
        {
            try
            {
                if (reader.IsDBNull(reader.GetOrdinal(fieldName)))
                {
                    return ".";
                }
                else
                {

                    return reader.GetString(reader.GetOrdinal(fieldName));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                reader.Close();
                return ".";
            }
        }

        public static string GetDatanNull(SqlDataReader reader, string fieldName)
        {
            try
            {
                if (reader.IsDBNull(reader.GetOrdinal(fieldName)))
                {
                    return "";
                }
                else
                {

                    return reader.GetString(reader.GetOrdinal(fieldName));
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
                reader.Close();
                return "";
            }
        }
        public void TypeTaxCom(string InvoiceType, string Sel_InvoiceNo, double refInvIndex)
        {
            try
            {
                if (InvoiceType == "Standard Invoice")
                {
                    QryC = string.Empty;
                    QryC = "SELECT COUNT(DISTINCT(vw_saleinvoicesdetails.per_vat)) as  [CntTaxCom] ";
                    QryC = QryC + "FROM vw_saleinvoicesdetails ";
                    QryC = QryC + "WHERE ";
                    QryC = QryC + "vw_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND vw_saleinvoicesdetails.inv_index = " + refInvIndex + ";";

                }
                else if (InvoiceType == "Standard Debit Note")
                {

                    QryC = string.Empty;
                    QryC = "SELECT COUNT(DISTINCT(vw_dr_saleinvoicesdetails.per_vat)) as  [CntTaxCom] ";
                    QryC = QryC + "FROM vw_dr_saleinvoicesdetails ";
                    QryC = QryC + "WHERE ";
                    QryC = QryC + "vw_dr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND vw_dr_saleinvoicesdetails.inv_index = " + refInvIndex + ";";

                }
                else if (InvoiceType == "Standard Credit Note")
                {

                    QryC = string.Empty;
                    QryC = "SELECT COUNT(DISTINCT(vw_cr_saleinvoicesdetails.per_vat)) as  [CntTaxCom] ";
                    QryC = QryC + "FROM vw_cr_saleinvoicesdetails ";
                    QryC = QryC + "WHERE ";
                    QryC = QryC + "vw_cr_saleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND vw_cr_saleinvoicesdetails.inv_index = " + refInvIndex + ";";

                }
                else if (InvoiceType == "Simplified Invoice")
                {

                    QryC = string.Empty;
                    QryC = "SELECT COUNT(DISTINCT(vw_cashsaleinvoicesdetails.per_vat)) as  [CntTaxCom] ";
                    QryC = QryC + "FROM vw_cashsaleinvoicesdetails ";
                    QryC = QryC + "WHERE ";
                    QryC = QryC + "vw_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND vw_cashsaleinvoicesdetails.inv_index = " + refInvIndex + ";";

                }
                else if (InvoiceType == "Simplified Debit Note")
                {

                    QryC = string.Empty;
                    QryC = "SELECT COUNT(DISTINCT(vw_dr_cashsaleinvoicesdetails.per_vat)) as  [CntTaxCom] ";
                    QryC = QryC + "FROM vw_dr_cashsaleinvoicesdetails ";
                    QryC = QryC + "WHERE ";
                    QryC = QryC + "vw_dr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND vw_dr_cashsaleinvoicesdetails.inv_index = " + refInvIndex + ";";

                }
                else if (InvoiceType == "Simplified Credit Note")
                {

                    QryC = string.Empty;
                    QryC = "SELECT COUNT(DISTINCT(vw_cr_cashsaleinvoicesdetails.per_vat)) as  [CntTaxCom] ";
                    QryC = QryC + "FROM vw_cr_cashsaleinvoicesdetails ";
                    QryC = QryC + "WHERE ";
                    QryC = QryC + "vw_cr_cashsaleinvoicesdetails.inv_no = '" + Sel_InvoiceNo + "' AND vw_cr_cashsaleinvoicesdetails.inv_index = " + refInvIndex + ";";

                }
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                SqlCommand cmd = new SqlCommand(QryC, SqlConfig.ServerConn);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 1)
                {
                    varvat_breakdown = "VAT Combination";
                }
                else
                {
                    varvat_breakdown = "VAT Non-Combinative";
                }
                cmd.Dispose();
                SqlConfig.ServerConn.Close();
            }
            catch (Exception ex)
            {
                SqlConfig.ServerConn.Close();
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);
            }

        }
        public void LogicalSelectedValues(string refInv_type)
        {

            try
            {

                if (refInv_type == "Standard Invoice")
                {
                    varinv_typecode = "0100000";
                    varinv_code = "388";
                    varSub_Type = "01";
                }

                else if (refInv_type == "Standard Debit Note")
                {
                    varinv_typecode = "0100000";
                    varinv_code = "383";
                    varSub_Type = "01";
                }
                else if (refInv_type == "Standard Credit Note")
                {
                    varinv_typecode = "0100000";
                    varinv_code = "381";
                    varSub_Type = "01";
                }
                else if (refInv_type == "Simplified Invoice")
                {
                    varinv_typecode = "0200000";
                    varinv_code = "388";
                    varSub_Type = "02";
                }

                else if (refInv_type == "Simplified Debit Note")
                {
                    varinv_typecode = "0200000";
                    varinv_code = "383";
                    varSub_Type = "02";
                }

                else if (refInv_type == "Simplified Credit Note")
                {
                    varinv_typecode = "0200000";
                    varinv_code = "381";
                    varSub_Type = "02";
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + //MessageBoxIcon.Error);

            }

        }

        public void GetInvICV(string sValue, int Remlength)
        {
            if (String.IsNullOrEmpty(sValue)) varInvICV = 0;

            // Sample: Extract the last 3 chars "EFG" from "ABCDEFG"
            // Important: Don't forget to make sure the string is not empty or too short!
            string Inv_Char = sValue;
            string Inv_Icv = Inv_Char.Substring(Inv_Char.Length - Remlength, Remlength);
            varInvICV = Convert.ToDouble(Inv_Icv);
        }
        public static string GetFieldValue(string sQry)
        {
            try
            {
                SqlConfig Connection = new SqlConfig();
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                //SqlConfig.ServerConn.Open();

                SqlCommand GetFldCommand = new SqlCommand(sQry, SqlConfig.ServerConn);
                string fieldValue;
                if (GetFldCommand.ExecuteScalar() == null)
                {
                    fieldValue = string.Empty;
                }
                else
                {
                    fieldValue = GetFldCommand.ExecuteScalar().ToString();
                }

                SqlConfig.ServerConn.Close();
                return fieldValue;


            }
            catch (Exception)
            {
                SqlConfig.ServerConn.Close();
                return string.Empty;
            }
        }
        public static string[] GetMultipleFieldValues(string tableName, string[] fieldNames, string pCondition)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException("Table name cannot be empty or null.");
            }

            if (fieldNames == null || fieldNames.Length == 0)
            {
                throw new ArgumentException("Field names cannot be empty or null.");
            }

            List<string> fieldValues = new List<string>();
            SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
            //SqlConfig.ServerConn.Open();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //connection.Open();

                string query = $"SELECT {string.Join(", ", fieldNames)} FROM {tableName} {pCondition}";

                //using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlCommand command = new SqlCommand(query, SqlConfig.ServerConn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            foreach (string fieldName in fieldNames)
                            {
                                fieldValues.Add(reader[fieldName].ToString());
                            }
                        }
                    }
                }
            }
            SqlConfig.ServerConn.Close();

            return fieldValues.ToArray();
        }
        //public void clearTxt(Control container)
        //{
        //    try
        //    {
        //        //'for each txt as control in this(object).control
        //        foreach (Control txt in container.Controls)
        //        {
        //            //conditioning the txt as control by getting it's type.
        //            //the type of txt as control must be textbox.
        //            if (txt is TextBox)
        //            {
        //                //if the object(textbox) is present. The result is, the textbox will be cleared.
        //                txt.Text = "";
        //            }
        //            if (txt is RichTextBox)
        //            {
        //                txt.Text = "";
        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show(ex.Message);
        //    }
        //}
        //public string checkOption(CheckBox chk)
        //{
        //    string yesno;

        //    if (chk.Checked)
        //    {
        //        yesno = "Yes";
        //    }
        //    else
        //    {
        //        yesno = "No";
        //    }
        //    return yesno;
        //}

        //Public Sub checkOption(ByVal chk As CheckBox, ByRef yesno As String)
        //    If chk.CheckState = CheckState.Checked Then
        //        yesno = "Yes"
        //    Else
        //        yesno = "No"
        //    End If
        // End Sub



        //initialize the validating method
        static Regex Valid_Name = StringOnly();
        static Regex Valid_Contact = NumbersOnly();
        static Regex Valid_Password = ValidPassword();
        static Regex Valid_Email = Email_Address();



        //Method for validating email address
        private static Regex Email_Address()
        {
            string Email_Pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(Email_Pattern, RegexOptions.IgnoreCase);
        }
        //Method for string validation only
        private static Regex StringOnly()
        {
            string StringAndNumber_Pattern = "^[a-zA-Z]";

            return new Regex(StringAndNumber_Pattern, RegexOptions.IgnoreCase);
        }
        //Method for numbers validation only
        private static Regex NumbersOnly()
        {
            string StringAndNumber_Pattern = "^[0-9]*$";

            return new Regex(StringAndNumber_Pattern, RegexOptions.IgnoreCase);
        }
        //Method for password validation only
        private static Regex ValidPassword()
        {
            string Password_Pattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$";

            return new Regex(Password_Pattern, RegexOptions.IgnoreCase);
        }
        //public void ResponsiveDtg(DataGridView dtg)
        //{
        //    dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //}

        public static string OpenTextFile(string filePath)
        {
            /*
            This function opens a text file and returns its contents as a string.

            Parameters:
            filePath (string): The path to the text file to be opened

            Returns:
            string: The contents of the text file
            */

            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found", filePath);
                }

                // Read the contents of the file and return as a string
                return File.ReadAllText(filePath);
            }
            catch (FileNotFoundException e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
        }
        public static void TrimAndSaveTextFile(string filePath)
        {
            /*
             * This function opens a text file, trims its contents and saves it as a new text file.
             * 
             * Parameters:
             * filePath (string): The path to the text file to be trimmed and saved.
             * 
             * Returns:
             * void
             */

            try
            {
                // Read the contents of the file
                string fileContents = File.ReadAllText(filePath);

                // Trim the contents
                string trimmedContents = fileContents.Trim();

                // Get the directory and filename of the original file
                string directory = Path.GetDirectoryName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string extension = Path.GetExtension(filePath);

                // Create a new file path for the trimmed file
                string newFilePath = Path.Combine(directory, $"{fileName}_trimmed{extension}");

                // Write the trimmed contents to the new file
                File.WriteAllText(newFilePath, trimmedContents);

                Console.WriteLine($"Trimmed file saved as {newFilePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public string GetComputerName()
        {
            try
            {
                // Get the name of the computer
                string computerName = Environment.MachineName;

                // Return the computer name
                return computerName;
            }
            catch (Exception)
            {
                // Log the error
                //MessageBox.Show("Failed to get Unit Name", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return "";
            }
        }

        public void UploadInvoiceInPortal(string filePath)
        {
            /*
            This function uploads an invoice file to a portal.

            Parameters:
            filePath (string): The path of the invoice file to be uploaded

            Returns:
            None
            */

            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("File not found", filePath);
                }

                // Upload the file to the portal
                // Code to upload the file goes here

                Console.WriteLine("Invoice uploaded successfully");
            }
            catch (FileNotFoundException e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
            }
            catch (Exception e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        static void TimeDiff(string[] args)
        {
            DateTime date1 = new DateTime(2021, 10, 1);
            DateTime date2 = new DateTime(2021, 10, 10);

            Console.WriteLine($"The difference between {date1.ToShortDateString()} and {date2.ToShortDateString()} is {DateDifference(date1, date2)} days.");
        }

        /// <summary>
        /// Calculates the difference in days between two dates.
        /// </summary>
        /// <param name="date1">The first date.</param>
        /// <param name="date2">The second date.</param>
        /// <returns>The difference in days between the two dates.</returns>
        static int DateDifference(DateTime date1, DateTime date2)
        {
            TimeSpan difference = date2 - date1;
            return difference.Days;
        }
        //public bool SearchInDataGridView(DataGridView dataGridView, string searchText)
        //{
        //    try
        //    {
        //        // Check if the DataGridView control is empty
        //        if (dataGridView.Rows.Count == 0)
        //        {
        //            throw new Exception("The DataGridView control is empty");
        //        }

        //        // Loop through each row in the DataGridView control
        //        foreach (DataGridViewRow row in dataGridView.Rows)
        //        {
        //            // Loop through each cell in the current row
        //            foreach (DataGridViewCell cell in row.Cells)
        //            {
        //                // Check if the cell value contains the search text
        //                if (cell.Value != null && cell.Value.ToString().Contains(searchText))
        //                {
        //                    // Select the matching cell
        //                    dataGridView.CurrentCell = cell;
        //                    return true;
        //                }
        //            }
        //        }

        //        // No match was found
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        // Log the error
        //        Console.WriteLine($"Error: {e.Message}");
        //        return false;
        //    }
        //}
        public string ReadFileText(string filePath)
        {
            /*
            This function reads the contents of a text file and returns it as a string.

            Parameters:
            filePath (string): The path to the text file to be read.

            Returns:
            string: The contents of the text file.
            */

            try
            {
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("The specified file does not exist.");
                }

                // Read the contents of the file and return as string
                return File.ReadAllText(filePath);
            }
            catch (FileNotFoundException ex)
            {
                // Log the error
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
            catch (IOException ex)
            {
                // Log the error
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public static void SaveStringToFile(string text, string filePath)
        {
            /*
             * This function saves a string to a text file.
             * 
             * Parameters:
             * text (string): The string to be saved to the file.
             * filePath (string): The path of the file where the string will be saved.
             * 
             * Returns:
             * void
             */

            try
            {
                // Check if the file already exists, if it does, delete it
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Create a new file and write the string to it
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(text);
                }
            }
            catch (Exception e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        public static string GetBase64FromFile(string filePath)
        {
            /*
            This function reads a text file and returns its base64 encoded string.

            Parameters:
            filePath (string): The path of the text file to be encoded

            Returns:
            string: The base64 encoded string of the text file
            */

            try
            {
                // Read the text file as a byte array
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Convert the byte array to base64 string
                string base64String = Convert.ToBase64String(fileBytes);

                return base64String;
            }
            catch (Exception e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
                return null;
            }
        }
        public static string Base64Encode(string plainText)
        {
            /*
            This function takes a string as input and returns its base64 encoded version.

            Parameters:
            plainText (string): The string to be encoded.

            Returns:
            string: The base64 encoded string.
            */

            try
            {
                // Convert the plain text to a byte array
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                // Encode the byte array to base64 string
                string base64EncodedText = Convert.ToBase64String(plainTextBytes);

                return base64EncodedText;
            }
            catch (Exception e)
            {
                // Log the error
                Console.WriteLine($"Error: {e.Message}");
                return "";
            }
        }
        public static string Base64Decode(string plainText)
        {


            try
            {

                byte[] plainTextBytes = Convert.FromBase64String(plainText);
                string base64DecodedText = System.Text.Encoding.UTF8.GetString(plainTextBytes);


                return base64DecodedText;
            }
            catch (Exception e)
            {

                Console.WriteLine($"Error: {e.Message}");
                return "";
            }
        }

        public string SaveTextFileAsString(ref string inText, string IN_sFilePath)
        {
            try
            {
                // Trim the text before writing it to the file.
                inText = inText.Trim();

                // Create a file stream to write the text to the file.
                using (FileStream fs = new FileStream(IN_sFilePath, FileMode.Create, System.IO.FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(inText);
                    }
                }

                return inText;
            }
            catch (Exception ex)
            {
                // Log the exception.
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Reads a text file and returns its content as a string.
        /// </summary>
        /// <param name="filePath">The path of the file to read.</param>
        /// <returns>The content of the file as a string.</returns>
        public string ReadTextFileAsString(string filePath)
        {
            string myString = string.Empty;

            try
            {
                // Make sure file exists:
                if (File.Exists(filePath))
                {
                    // Open the file to read from.
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        myString = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while reading the file: {0}", ex.Message);
            }

            return myString;
        }
        public void ConvertPDFAttXML(ref string LicensePath, string PDFPath, String XMLPath, string PDFA3aOUtput)
        {
            Aspose.Pdf.License License = new Aspose.Pdf.License();
            License.SetLicense(LicensePath + "/PDFA3aPDF/License.lic");

            string DataDir = PDFPath;
            Document pdfDocument = new Document(DataDir);
            FileSpecification embeddedPDF = new FileSpecification(XMLPath);
            pdfDocument.EmbeddedFiles.Add(embeddedPDF);
            pdfDocument.Convert(Path.Combine(DataDir + "Conversion.log"), PdfFormat.PDF_A_3A, ConvertErrorAction.Delete);
            // Save output document
            pdfDocument.Save(PDFA3aOUtput + "/PDFA3aPDF/OutPutXMLPDF/Debit_Note_XMLPDF_A3a.pdf");
        }
        //public Bitmap generateQRImage(string text)
        //{
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(20);
        //    return qrCodeImage;
        //}
        public static long GetFieldValuePIH(string get_Qry)
        {
            try
            {
                int GetValue;
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                SqlCommand Cmd = new SqlCommand(get_Qry, SqlConfig.ServerConn);
                IDataReader reader = Cmd.ExecuteReader();
                if (reader != null && reader.Read())
                {

                    GetValue = reader.GetInt32(0);

                }
                else
                {
                    return 0;
                }
                reader.Close();
                Cmd.Dispose();

                SqlConfig.ServerConn.Close();
                return GetValue;
            }
            catch (SqlException)
            {
                return 0;


            }

        }

        private static long CurrentPIHId(string pBranchCode, string pTypereports, string pInvoiceNo)
        {
            string Qry;
            long cPih;

            SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
            Qry = "";
            Qry = "INSERT INTO tblprocessPIH(branchcode, invoicetype, fld_doc_no) " +
                    "VALUES('" + pBranchCode + "', '" + pTypereports + "', '" + pInvoiceNo + "');";

            try
            {
                SqlCommand Cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();

                SqlConfig.ServerConn.Close();

            }

            catch (SqlException ex)
            {
                SqlConfig.ServerConn.Close();
                //MessageBox.Show($"Error Found: {ex.Message}", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return 0;
            }

            //GetFieldValuePIH

            Qry = "";
            Qry = "SELECT TOP 1 pih_id From tblprocessPIH WHERE branchcode = '" + pBranchCode + "' AND invoicetype = '" + pTypereports + "' AND fld_doc_no = '" + pInvoiceNo + "' ORDER By pih_id Desc ;";
            cPih = GetFieldValuePIH(Qry);

            if (cPih > 0)
            {
                return cPih;
            }
            else
            {
                return 0;
            }
        }
        public string PreviousInvoiceHash(long PrIdHash)
        {

            string Qry;
            long cPIH;

            string invHashValue;
            //long ProTag;

            try
            {

                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                //count number of PIH
                Qry = "";
                Qry = "SELECT COUNT(pih_id) as rec_pih From tblprocessPIH;";
                //Qry = "SELECT @@ROW_COUNT() as rec_pih From tblprocessPIH;";

                cPIH = GetFieldValuePIH(Qry);

                if (cPIH == 1)
                {
                    return "NWZlY2ViNjZmZmM4NmYzOGQ5NTI3ODZjNmQ2OTZjNzljMmRiYzIzOWRkNGU5MWI0NjcyOWQ3M2EyN2ZiNTdlOQ==";

                }
                else
                {


                    try
                    {
                        SqlConfig Connection = new SqlConfig();
                        SqlConfig.ConnectToServer(SqlConfig.ConnectionString);


                        invHashValue = string.Empty;

                        Qry = "";
                        Qry = "SELECT TOP 1 invHash, pih_id From tblprocessPIH WHERE branchCode = '" + varbranch_code + "' AND pih_id < " + PrIdHash + " ORDER BY pih_id DESC;";

                        SqlCommand Cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
                        IDataReader reader = Cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            if (reader != null)
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    invHashValue = reader.GetString(0);
                                }
                                else
                                {
                                    invHashValue = string.Empty;
                                }
                                //invHashValue = reader.GetString(reader.GetOrdinal("invHash"));// reader["invHash"].ToString();\
                                int Id_PIH = Convert.ToInt32(reader["pih_id"]);

                                if (invHashValue != string.Empty)
                                {

                                    reader.Close();
                                    Cmd.Dispose();
                                    SqlConfig.ServerConn.Close();

                                    return invHashValue;
                                }
                            }

                        }
                        if (invHashValue == string.Empty)
                        {
                            PreviousInvoiceHash(PrIdHash);
                        }

                        reader.Close();
                        Cmd.Dispose();
                        SqlConfig.ServerConn.Close();
                        return "";
                    }
                    catch (SqlException)
                    {
                        return "";
                    }
                }
            }
            catch (SqlException)
            {
                return "";
            }
        }
        public void XMLInvoice0102_Composition(string form, string dataGridViewName, string Branch_code, string Invoice_no)
        {

            //bool success = true;
            Chilkat.Xml xml = new Chilkat.Xml();

            xml.Tag = "Invoice";
            xml.AddAttribute("xmlns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
            xml.AddAttribute("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xml.AddAttribute("xmlns:cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xml.AddAttribute("xmlns:ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xml.UpdateChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionURI", "urn:oasis:names:specification:ubl:dsig:enveloped:xades");
            xml.UpdateAttrAt("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures", true, "xmlns:sig", "urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2");
            xml.UpdateAttrAt("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures", true, "xmlns:sac", "urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2");
            xml.UpdateAttrAt("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures", true, "xmlns:sbc", "urn:oasis:names:specification:ubl:schema:xsd:SignatureBasicComponents-2");
            xml.UpdateChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|cbc:ID", "urn:oasis:names:specification:ubl:signature:1");
            xml.UpdateChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|sbc:ReferencedSignatureID", "urn:oasis:names:specification:ubl:signature:Invoicesadas");
            xml.UpdateChildContent("cbc:ProfileID", "reporting:1.0");
            xml.UpdateChildContent("cbc:ID", varInvoice_No);
            xml.UpdateChildContent("cbc:UUID", varX_UUID);
            xml.UpdateChildContent("cbc:IssueDate", varinv_date);
            //
            varinv_time = "00:00:00";
            //
            xml.UpdateChildContent("cbc:IssueTime", DateTime.Parse(varinv_time).ToString("HH:mm:ss"));

            xml.UpdateAttrAt("cbc:InvoiceTypeCode", true, "name", varinv_typecode);
            xml.UpdateChildContent("cbc:InvoiceTypeCode", varinv_code);
            xml.UpdateChildContent("cbc:DocumentCurrencyCode", "SAR");
            xml.UpdateChildContent("cbc:TaxCurrencyCode", "SAR");
            xml.UpdateChildContent("cbc:LineCountNumeric", varcnt_items); //Number of Items


            if ((varInv_type == "Standard Debit Note") || (varInv_type == "Standard Credit Note"))
            {
                xml.UpdateChildContent("cac:BillingReference|cac:InvoiceDocumentReference|cbc:ID", varrefinv_no);
            }
            if ((varInv_type == "Simplified Debit Note") || (varInv_type == "Simplified Credit Note"))
            {
                string Bill_ref = "Invoice Number: " + varrefinv_no + ";" + "Invoice Issue Date: " + varRef_Date;
                xml.UpdateChildContent("cac:BillingReference|cac:InvoiceDocumentReference|cbc:ID", Bill_ref);
            }


            xml.UpdateChildContent("cac:AdditionalDocumentReference|cbc:ID", "ICV");
            xml.UpdateChildContent("cac:AdditionalDocumentReference|cbc:UUID", Convert.ToString(varInvICV));
            xml.UpdateChildContent("cac:AdditionalDocumentReference[1]|cbc:ID", "PIH");
            xml.UpdateAttrAt("cac:AdditionalDocumentReference[1]|cac:Attachment|cbc:EmbeddedDocumentBinaryObject", true, "mimeCode", "text/plain");

            AttPIHId = CurrentPIHId(varbranch_code, varInv_type, varinv_no);
            AttPIH = PreviousInvoiceHash(AttPIHId);
            varPIH = AttPIH;

            xml.UpdateChildContent("cac:AdditionalDocumentReference[1]|cac:Attachment|cbc:EmbeddedDocumentBinaryObject", varPIH);
            xml.UpdateChildContent("cac:Signature|cbc:ID", "urn:oasis:names:specification:ubl:signature:Invoice");
            xml.UpdateChildContent("cac:Signature|cbc:SignatureMethod", "urn:oasis:names:specification:ubl:dsig:enveloped:xades");

            //Accounting party
            xml.UpdateAttrAt("cac:AccountingSupplierParty|cac:Party|cac:PartyIdentification|cbc:ID", true, "schemeID", varsel_typeId);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyIdentification|cbc:ID", varsellers_id);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyName|cbc:Name", varsellers_name);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:StreetName", varsel_streetname);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:BuildingNumber", varsel_buildno);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:PlotIdentification", varsel_adbuildno);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:CitySubdivisionName", varsel_subcitysubname);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:CityName", varsel_cityname);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:PostalZone", varsel_postalzone);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:CountrySubentity", varsel_countrySubentity);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cac:Country|cbc:IdentificationCode", varsel_cntycode);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyTaxScheme|cbc:CompanyID", varsel_vatreg);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyTaxScheme|cac:TaxScheme|cbc:ID", "VAT");
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyLegalEntity|cbc:RegistrationName", varsellers_name);

            //Customer Party
            xml.UpdateAttrAt("cac:AccountingCustomerParty|cac:Party|cac:PartyIdentification|cbc:ID", true, "schemeID", varbuy_typeId);
            if (varbuy_typeId == "CRN")
            {

                xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyName|cbc:Name", varbuy_vatno);

            }
            else
            {
                xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyIdentification|cbc:ID", varbuy_id);
            }

            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:StreetName", varbuy_streetname);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:BuildingNumber", varbuy_buildno);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:PlotIdentification", varbuy_plotid);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:CitySubdivisionName", varbuy_subcitysubname);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:CityName", varbuy_cityname);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:PostalZone", varbuy_postalzone);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:CountrySubentity", varbuy_countrySubentity);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cac:Country|cbc:IdentificationCode", varbuy_countrycode);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyTaxScheme|cac:TaxScheme|cbc:ID", "VAT");
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyLegalEntity|cbc:RegistrationName", varbuyers_name);

            xml.UpdateChildContent("cac:Delivery|cbc:ActualDeliveryDate", varactdeli_date);
            xml.UpdateChildContent("cac:Delivery|cbc:LatestDeliveryDate", varactdeli_date);


            xml.UpdateChildContent("cac:PaymentMeans|cbc:PaymentMeansCode", varpay_code);

            string ExInvoice = "Invoice";
            string ExDrInvoice = "Debit";
            string ExCrInvoice = "Credit";

            int LookValInv = varinv_type.IndexOf(ExInvoice);
            int LookValDr = varinv_type.IndexOf(ExDrInvoice);
            int LookValCr = varinv_type.IndexOf(ExCrInvoice);

            if (LookValInv > 0)
            {
                xml.UpdateChildContent("cac:PaymentMeans|cbc:InstructionNote", varpay_inst);
            }

            if ((LookValDr > 0) || (LookValCr > 0))
            {
                xml.UpdateChildContent("cac:PaymentMeans|cbc:InstructionNote", varinstruction_code);
            }


            XMLInvoiceLine(varInv_type, Invoice_no);

            xml.UpdateChildContent("cac:AllowanceCharge[0]|cbc:ChargeIndicator", "false");
            xml.UpdateChildContent("cac:AllowanceCharge[0]|cbc:AllowanceChargeReason", "discount");
            xml.UpdateAttrAt("cac:AllowanceCharge[0]|cbc:Amount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:AllowanceCharge[0]|cbc:Amount", "0.00");



            int i;
            int Ar_Row;
            string Tax_Cat;
            decimal Tax_per;

            i = 0;
            while (i < Convert.ToInt32(Inv_ItemCount))// loop number of index here

            {
                //Optional for Single Tax Activate this for Header Discount and Header Tax
                Ar_Row = i;
                Tax_Cat = Convert.ToString(ParseInvoiceLinedata[7, Ar_Row]);

                Tax_per = Convert.ToDecimal(ParseInvoiceLinedata[8, Ar_Row]) * 100;


                xml.I = i;
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:ID", true, "schemeID", "UN/ECE 5305");
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:ID", true, "schemeAgencyID", "6");
                xml.UpdateChildContent("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:ID", Tax_Cat);
                xml.UpdateChildContent("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:Percent", Tax_per.ToString("0.00"));
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                xml.UpdateChildContent("cac:AllowanceCharge|cac:TaxCategory[i]|cac:TaxScheme|cbc:ID", "VAT");

                i = i + 1;
            }

            XMLGroupTaxTotal(varInv_type, Invoice_no);

            string Gp_TaxCode;

            /*Count Group of Items */

            int Cnt_Items = Convert.ToInt32(InvGp_ItemCount);
            switch (Cnt_Items)
            {
                /*One items S / EOZ */
                case 1:


                    /* 1 invoice Line */
                    i = 0;
                    Ar_Row = 0;

                    xml.I = i;
                    xml.UpdateAttrAt("cac:TaxTotal[i]|cbc:TaxAmount", true, "currencyID", "SAR");
                    xml.UpdateChildContent("cac:TaxTotal[i]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                    xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                    xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, Ar_Row]));
                    xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");
                    xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                    xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                    xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");
                    xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, Ar_Row]));
                    //xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]).ToString("0.00"));
                    //Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, 0]) * 100)
                    xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]) * 100));
                    var test = Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]).ToString("0.00");
                    var test2 = Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]) * 100);
                    /*Tax Excemtion Z, O, E or No Vat... this will Appear */

                    Gp_TaxCode = Convert.ToString(GroupTaxTotaldata[2, Ar_Row]);

                    if ((Gp_TaxCode == "Z") || (Gp_TaxCode == "O") || (Gp_TaxCode == "E"))
                    {
                        xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, Ar_Row]));
                        xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, Ar_Row]));
                    }

                    xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                    xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                    xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");


                    /*if ((Gp_TaxCode != "Z") || (Gp_TaxCode != "O") || (Gp_TaxCode != "E"))
                    {

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);
                    }*/

                    break;
                case 2:

                    string str1 = "S";
                    string str2 = "ZEO";

                    int Cat01 = str1.IndexOf(Convert.ToString(GroupTaxTotaldata[2, 0]));
                    int Cat02 = str1.IndexOf(Convert.ToString(GroupTaxTotaldata[2, 1]));

                    int Mx01 = str2.IndexOf(Convert.ToString(GroupTaxTotaldata[2, 0]));
                    int Mx02 = str2.IndexOf(Convert.ToString(GroupTaxTotaldata[2, 1]));

                    // S and
                    //if ((Cat01 == -1 || Mx01 == -1) && (Cat02 == -1 || Mx02 == -1))
                    if (Cat01 == 0 && Cat02 == 0)
                    {
                        /*
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, 0]));
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, 0]));
                        
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, 0]));
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, 0]));
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, 0]) * 100));
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");

                        Ar_Row = 1;
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cbc:TaxableAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, Ar_Row]));
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, Ar_Row]));
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]) * 100));
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, Ar_Row]));
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, Ar_Row]));

                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                        xml.UpdateAttrAt("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cac:TaxSubtotal[0]|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);
                        */

                        xml.UpdateAttrAt("cac:TaxTotal[0]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cbc:TaxAmount", vargTotamnt_vat);

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, 0]));
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");

                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxAmount", vargTotamnt_vat);
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");

                        //tax Category
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", str1);
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", "15.00");

                        //Constant
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");

                    }
                    else if ((Cat01 == 0 || Mx02 >= 0) && (Cat02 == 0 || Mx01 >= 0))
                    {

                        xml.UpdateAttrAt("cac:TaxTotal[0]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cbc:TaxAmount", vargTotamnt_vat);


                        xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);


                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, 0]));//Ar_Row = 0;
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");


                        if (Convert.ToString(GroupTaxTotaldata[2, 0]) == "S")

                        {
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, 0]));//Ar_Row = 0;
                        }

                        else

                        {
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxAmount", "0.00");
                        }

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");

                        //tax Category
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, 0]));
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, 0]) * 100));
                                                                                                         

                        //Constant
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");

                        //Update Sub Total
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cbc:TaxableAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, 1]));//check
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");

                        if (Convert.ToString(GroupTaxTotaldata[2, 1]) == "S")//sub
                        {
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, 1]));//Ar_Row = 1;
                        }

                        else
                        {
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cbc:TaxAmount", "0.00");
                        }

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");

                        //tax Category
                        if (Convert.ToString(GroupTaxTotaldata[2, 1]) == "S")//sub
                        {
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, 1]));
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, 1]) * 100));
                                                                                                                         
                        }
                        else
                        {
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, 1]));
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:Percent", "0.00");
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, 1]));
                            xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, 1]));

                        }
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal[1]|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                    }

                    else if (Cat01 == 0 && Cat02 == 0)
                    {
                        xml.UpdateAttrAt("cac:TaxTotal|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal|cbc:TaxAmount", "0.00");

                        i = 0;
                        while (i < Convert.ToInt32(InvGp_ItemCount))
                        {

                            xml.I = i;
                            /*Update Sub Total*/
                            xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxableAmount", true, "currencyID", "SAR");
                            xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, i]));
                            xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxAmount", true, "currencyID", "SAR");
                            xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, i]));
                            xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                            xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");

                            /*tax Category*/
                            xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, i]));
                            xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:Percent", "0.00");
                            xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, 1]));
                            xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, 1]));

                            /*Constant*/
                            xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                            xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                            xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                            i++;

                        }

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);
                    }
                    /*    

                   else
                   {
                       xml.UpdateAttrAt("cac:TaxTotal|cbc:TaxAmount", true, "currencyID", "SAR");
                       xml.UpdateChildContent("cac:TaxTotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, 0]));

                       i = 0;
                       while (i < Convert.ToInt32(InvGp_ItemCount))  
                   {

                       Ar_Row = i;
                       xml.I = i;

                       xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxableAmount", true, "currencyID", "SAR");
                       xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, Ar_Row]));
                       xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxAmount", true, "currencyID", "SAR");
                       xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                       xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                       xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");

                       xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, Ar_Row]));
                       xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]) * 100));
                       xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, Ar_Row]));
                       xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, Ar_Row]));


                       xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                       xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                       xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                       i++;
                   }

                   xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");
                   xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);
                    }
                   */

                    break;
                case 3 when Cnt_Items >= 3:


                    XMLGroupTaxTotalSEOZ(varInv_type, Invoice_no);

                    string Gp_TaxCodeSEOZ;
                    //int Cnt_ItemsSEOZ = Convert.ToInt32(InvGp_ItemCountSEOZ);

                    i = 0;

                    int VStndCounter = 0;

                    int LenNumGroup = Convert.ToInt32(InvGp_ItemCountSEOZ);
                    for (int SCat = 0; SCat < LenNumGroup; SCat++)
                    {
                        if (Convert.ToString(GroupTaxTotaldataSEOZ[2, SCat]) == "S")
                        {
                            VStndCounter++;
                        }

                    }
                    if (VStndCounter == LenNumGroup)
                    {

                        xml.UpdateAttrAt("cac:TaxTotal[0]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cbc:TaxAmount", vargTotamnt_vat);

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);

                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxableAmount", vargTot_TaxExclAmount);
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");

                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cbc:TaxAmount", vargTotamnt_vat);
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");

                        //tax Category
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", "S");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", "15.00");

                        //Constant
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", false, "schemeID", "UN/ECE 5153");
                        xml.UpdateAttrAt("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", false, "schemeAgencyID", "6");
                        xml.UpdateChildContent("cac:TaxTotal[1]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                    }
                    else
                    {

                        xml.UpdateAttrAt("cac:TaxTotal[0]|cbc:TaxAmount", true, "currencyID", "SAR");
                        xml.UpdateChildContent("cac:TaxTotal[0]|cbc:TaxAmount", "0.00");


                        //For Ar_Row = 1 To.RecordCount
                        for (i = 0; i < LenNumGroup; i++)
                        {
                            xml.I = i;
                            xml.UpdateAttrAt("cac:TaxTotal[i]|cbc:TaxAmount", true, "currencyID", "SAR");
                            xml.UpdateChildContent("cac:TaxTotal[i]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldataSEOZ[0, i]));
                            xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                            xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldataSEOZ[1, i]));
                            xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");
                            xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldataSEOZ[0, i]));
                            xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                            xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");
                            xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldataSEOZ[2, i]));
                            //Tax Excemtion Z, O, E or No Vat... this will Appear

                            Gp_TaxCodeSEOZ = Convert.ToString(GroupTaxTotaldataSEOZ[2, i]);

                            if ((Gp_TaxCodeSEOZ == "Z") || (Gp_TaxCodeSEOZ == "O") || (Gp_TaxCodeSEOZ == "E"))
                            {
                                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", "0.00");
                                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldataSEOZ[4, i]));
                                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldataSEOZ[5, i]));
                            }
                            else
                            {
                                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", "15.00");
                            }

                            xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                            xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                            xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                        }

                    }
                    xml.UpdateAttrAt("cac:TaxTotal[1]|cbc:TaxAmount", true, "currencyID", "SAR");

                    if (Convert.ToString(GroupTaxTotaldataSEOZ[2, i]) != "S")
                    {
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", "0.00");

                    }
                    else
                    {
                        xml.UpdateChildContent("cac:TaxTotal[1]|cbc:TaxAmount", vargTotamnt_vat);
                    }

                    break;
                    //bool Stnd = false;

                    //int LenNumGroup = Convert.ToInt32(InvGp_ItemCount);
                    //for (int SCat = 0; SCat < LenNumGroup; SCat++)
                    //{
                    //    if (Convert.ToString(GroupTaxTotaldata[2, SCat]) == "S")
                    //    {
                    //        Stnd = true;
                    //        break;
                    //    }

                    //}

                    //bool MXEx = false;
                    //int XLenNumGroup = Convert.ToInt32(InvGp_ItemCount);
                    //for (int XSCat = 0; XSCat < XLenNumGroup; XSCat++)
                    //{

                    //    if (Convert.ToString(GroupTaxTotaldata[2, XSCat]) != "S")

                    //    {
                    //        MXEx = true;
                    //        break;
                    //    }

                    //}

                    ///*S */

                    //if (Stnd == true)
                    //{

                    //    i = 0;
                    //    while (i < Convert.ToInt32(InvGp_ItemCount))  /* loop number of index here */
                    //    {
                    //        /* More than 2 items */
                    //        Ar_Row = i;
                    //        xml.I = i;
                    //        xml.UpdateAttrAt("cac:TaxTotal[i]|cbc:TaxAmount", true, "currencyID", "SAR");
                    //        xml.UpdateChildContent("cac:TaxTotal[i]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                    //        xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                    //        xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, Ar_Row]));
                    //        xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");
                    //        xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                    //        xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                    //        xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");
                    //        xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, Ar_Row]));
                    //        xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]) * 100));

                    //        /* Tax Excemtion Z, O, E or No Vat... this will Appear */

                    //        Gp_TaxCode = Convert.ToString(GroupTaxTotaldata[2, Ar_Row]);

                    //        if ((Gp_TaxCode == "Z") || (Gp_TaxCode == "O") || (Gp_TaxCode == "E"))
                    //        {
                    //            xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, Ar_Row]));
                    //            xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, Ar_Row]));

                    //        }

                    //        xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                    //        xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                    //        xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");

                    //        i = i + 1;
                    //    }
                    //    int exTn = Convert.ToInt32(InvGp_ItemCount) + 1;
                    //    if (MXEx == false)
                    //        xml.I = exTn;
                    //        xml.UpdateAttrAt("cac:TaxTotal[exTn]|cbc:TaxAmount", true, "currencyID", "SAR");
                    //        xml.UpdateChildContent("cac:TaxTotal[exTn]|cbc:TaxAmount", vargTotamnt_vat);

                    //}

                    ///*EOZ only */
                    //else
                    //{

                    //    xml.UpdateAttrAt("cac:TaxTotal|cbc:TaxAmount", true, "currencyID", "SAR");
                    //    xml.UpdateChildContent("cac:TaxTotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, 0]));

                    //    i = 0;
                    //    while (i < Convert.ToInt32(InvGp_ItemCount))  /* loop number of index here */
                    //    {

                    //        Ar_Row = i;
                    //        xml.I = i;
                    //        /*Update Sub Total */
                    //        xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxableAmount", true, "currencyID", "SAR");
                    //        xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, Ar_Row]));
                    //        xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxAmount", true, "currencyID", "SAR");
                    //        xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                    //        xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                    //        xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");
                    //        /*tax Category */
                    //        xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, Ar_Row]));
                    //        xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]) * 100));
                    //        xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, Ar_Row]));
                    //        xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, Ar_Row]));

                    //        /*Constant */
                    //        xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                    //        xml.UpdateAttrAt("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                    //        xml.UpdateChildContent("cac:TaxTotal|cac:TaxSubtotal[i]|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                    //        i++;

                    //    }
                    //    int exTn = Convert.ToInt32(InvGp_ItemCount) + 1;
                    //    if (Stnd == false)
                    //        xml.I = exTn;
                    //        xml.UpdateAttrAt("cac:TaxTotal[exTn]|cbc:TaxAmount", true, "currencyID", "SAR");
                    //        xml.UpdateChildContent("cac:TaxTotal[exTn]|cbc:TaxAmount", vargTotamnt_vat);

                    //}

            }

            /* Legal Monetary */
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:LineExtensionAmount", true, "currencyID", "SAR");
            /* for version 1 */
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:LineExtensionAmount", vargTot_TaxExclAmount);

            /* for version 2 not validated
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:LineExtensionAmount", vargTot_LineExtAmount);
            */

            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:TaxExclusiveAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:TaxExclusiveAmount", vargTot_TaxExclAmount);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:TaxInclusiveAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:TaxInclusiveAmount", vargTot_TaxInclAmount);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:AllowanceTotalAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:AllowanceTotalAmount", vargTotamnt_allow);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:PrepaidAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:PrepaidAmount", vargTotamnt_prepaid);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:PayableAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:PayableAmount", vargTotamnt_payable);


            /* int i; */
            int varCBC_ID;
            double varLn_Itm_Qty;
            string varItem_Desc;
            decimal varLnEx_Amount;
            decimal varLnAlw_ChargeDisc;
            decimal varLn_TaxTotal;
            decimal varLnExcl_Rounding;
            string varLn_TaxCode;
            decimal varLn_TaxPer;
            decimal varLn_PriceAmnt;
            double varLn_BaseQty;

            i = 0;

            /* XMLInvoiceLine("Standard Invoice", Invoice_no); */

            while (i < Convert.ToInt32(Inv_ItemCount)) /* Loop number of invoice line here */
            {
                varCBC_ID = Convert.ToInt32(ParseInvoiceLinedata[0, i]);

                varLn_Itm_Qty = Convert.ToDouble(ParseInvoiceLinedata[1, i]);
                varItem_Desc = Convert.ToString(ParseInvoiceLinedata[2, i]);
                varLnEx_Amount = Convert.ToDecimal(ParseInvoiceLinedata[3, i]);
                varLnAlw_ChargeDisc = Convert.ToDecimal(ParseInvoiceLinedata[4, i]);

                varLn_TaxTotal = Convert.ToDecimal(ParseInvoiceLinedata[5, i]);
                varLnExcl_Rounding = Convert.ToDecimal(ParseInvoiceLinedata[6, i]);

                varLn_TaxCode = Convert.ToString(ParseInvoiceLinedata[7, i]);
                varLn_TaxPer = Convert.ToDecimal(ParseInvoiceLinedata[8, i]) * 100;
                varLn_PriceAmnt = Convert.ToDecimal(ParseInvoiceLinedata[9, i]);
                varLn_BaseQty = Convert.ToDouble("1.0000"); /*Base Quantity */

                /* Version 1 */
                xml.I = i;
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:ID", Convert.ToString(varCBC_ID));/*1 here is item id*/
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:InvoicedQuantity", varLn_Itm_Qty.ToString("0.0000"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cbc:LineExtensionAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:LineExtensionAmount", varLnEx_Amount.ToString("0.00"));

                /*New Update discount place under price amount or header invoice line(Same correct as per in manual)*/
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:ChargeIndicator", "false");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:AllowanceChargeReasonCode", "95");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:AllowanceChargeReason", "Discount");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:Amount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:Amount", varLnAlw_ChargeDisc.ToString("0.00"));

                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", varLn_TaxTotal.ToString("0.00"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", varLnExcl_Rounding.ToString("0.00"));

                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cbc:Name", varItem_Desc);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:ID", varLn_TaxCode);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:Percent", varLn_TaxPer.ToString("0.00"));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", varLn_PriceAmnt.ToString("0.00"));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:BaseQuantity", varLn_BaseQty.ToString("0.0000"));


                /*Version 2 not Validated
                xml.I = i;
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:ID", Convert.ToString(varCBC_ID));// 1 here is item id
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cbc:InvoicedQuantity", true, "unitCode", "PCE");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:InvoicedQuantity", varLn_Itm_Qty.ToString("0.0000"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cbc:LineExtensionAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:LineExtensionAmount", varLnEx_Amount.ToString("0.00"));

                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", varLn_TaxTotal.ToString("0.00"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", varLnExcl_Rounding.ToString("0.00"));

                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cbc:Name", varItem_Desc);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:ID", varLn_TaxCode);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:Percent", Convert.ToString(varLn_TaxPer));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", varLn_PriceAmnt.ToString("0.00"));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:BaseQuantity", varLn_BaseQty.ToString("0.0000"));

                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:ChargeIndicator", "false");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:AllowanceChargeReason", "discount");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:Amount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:Amount", varLnAlw_ChargeDisc.ToString("0.00"));
                */

                i = i + 1;
            }

            /*Certificate Loader */
            int enp_Live = ClassMain.VarEnp_id;
            //bool successLoadCert = ClassDefAcctRepository.DefAcctCertificates(enp_Live, ClassMain.UserAcctId, ClassMain.VarCsOrg_Id);
            //bool successLoadCert = ClassDefAcctRepository.DefAcctCertificates(2,3,11);
            bool successLoadCert = ClassDefAcctRepository.DefAcctCertificates(3, 3, 12);
            if (successLoadCert == true)
            {
                this.SignedXMLFiles(xml, ClassDefAcctRepository.DefProCert, ClassDefAcctRepository.DefProPrivatekey);
            }
            else
            {
                //MessageBox.Show("Certificates Not Loaded", "Certificate", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
            }

        }
        public void XMLInvoice0102_CompositionBackup(string form, string dataGridViewName, string Branch_code, string Invoice_no)
        {

            //bool success = true;
            Chilkat.Xml xml = new Chilkat.Xml();

            xml.Tag = "Invoice";
            xml.AddAttribute("xmlns", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
            xml.AddAttribute("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xml.AddAttribute("xmlns:cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xml.AddAttribute("xmlns:ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
            xml.UpdateChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionURI", "urn:oasis:names:specification:ubl:dsig:enveloped:xades");
            xml.UpdateAttrAt("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures", true, "xmlns:sig", "urn:oasis:names:specification:ubl:schema:xsd:CommonSignatureComponents-2");
            xml.UpdateAttrAt("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures", true, "xmlns:sac", "urn:oasis:names:specification:ubl:schema:xsd:SignatureAggregateComponents-2");
            xml.UpdateAttrAt("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures", true, "xmlns:sbc", "urn:oasis:names:specification:ubl:schema:xsd:SignatureBasicComponents-2");
            xml.UpdateChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|cbc:ID", "urn:oasis:names:specification:ubl:signature:1");
            xml.UpdateChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|sbc:ReferencedSignatureID", "urn:oasis:names:specification:ubl:signature:Invoicesadas");
            xml.UpdateChildContent("cbc:ProfileID", "reporting:1.0");
            xml.UpdateChildContent("cbc:ID", varInvoice_No);
            xml.UpdateChildContent("cbc:UUID", varX_UUID);
            xml.UpdateChildContent("cbc:IssueDate", varinv_date);
            xml.UpdateChildContent("cbc:IssueTime", varinv_time);

            xml.UpdateAttrAt("cbc:InvoiceTypeCode", true, "name", varinv_typecode);
            xml.UpdateChildContent("cbc:InvoiceTypeCode", varinv_code);
            xml.UpdateChildContent("cbc:DocumentCurrencyCode", "SAR");
            xml.UpdateChildContent("cbc:TaxCurrencyCode", "SAR");
            xml.UpdateChildContent("cbc:LineCountNumeric", varcnt_items); //Number of Items


            if ((varInv_type == "Standard Debit Note") || (varInv_type == "Standard Credit Note"))
            {
                xml.UpdateChildContent("cac:BillingReference|cac:InvoiceDocumentReference|cbc:ID", varrefinv_no);
            }
            if ((varInv_type == "Simplified Debit Note") || (varInv_type == "Simplified Credit Note"))
            {
                string Bill_ref = "Invoice Number: " + varrefinv_no + ";" + "Invoice Issue Date: " + varRef_Date;
                xml.UpdateChildContent("cac:BillingReference|cac:InvoiceDocumentReference|cbc:ID", Bill_ref);
            }


            xml.UpdateChildContent("cac:AdditionalDocumentReference|cbc:ID", "ICV");
            xml.UpdateChildContent("cac:AdditionalDocumentReference|cbc:UUID", Convert.ToString(varInvICV));
            xml.UpdateChildContent("cac:AdditionalDocumentReference[1]|cbc:ID", "PIH");
            xml.UpdateAttrAt("cac:AdditionalDocumentReference[1]|cac:Attachment|cbc:EmbeddedDocumentBinaryObject", true, "mimeCode", "text/plain");
            xml.UpdateChildContent("cac:AdditionalDocumentReference[1]|cac:Attachment|cbc:EmbeddedDocumentBinaryObject", varPIH);
            xml.UpdateChildContent("cac:Signature|cbc:ID", "urn:oasis:names:specification:ubl:signature:Invoice");
            xml.UpdateChildContent("cac:Signature|cbc:SignatureMethod", "urn:oasis:names:specification:ubl:dsig:enveloped:xades");

            //Accounting party
            xml.UpdateAttrAt("cac:AccountingSupplierParty|cac:Party|cac:PartyIdentification|cbc:ID", true, "schemeID", varsel_typeId);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyIdentification|cbc:ID", varsellers_id);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyName|cbc:Name", varsellers_name);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:StreetName", varsel_streetname);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:BuildingNumber", varsel_buildno);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:PlotIdentification", varsel_adbuildno);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:CitySubdivisionName", varsel_subcitysubname);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:CityName", varsel_cityname);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:PostalZone", varsel_postalzone);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cbc:CountrySubentity", varsel_countrySubentity);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PostalAddress|cac:Country|cbc:IdentificationCode", varsel_cntycode);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyTaxScheme|cbc:CompanyID", varsel_vatreg);
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyTaxScheme|cac:TaxScheme|cbc:ID", "VAT");
            xml.UpdateChildContent("cac:AccountingSupplierParty|cac:Party|cac:PartyLegalEntity|cbc:RegistrationName", varsellers_name);

            //Customer Party
            xml.UpdateAttrAt("cac:AccountingCustomerParty|cac:Party|cac:PartyIdentification|cbc:ID", true, "schemeID", varbuy_typeId);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyIdentification|cbc:ID", varbuy_id);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyName|cbc:Name", varbuy_vatno);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:StreetName", varbuy_streetname);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:BuildingNumber", varbuy_buildno);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:PlotIdentification", varbuy_plotid);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:CitySubdivisionName", varbuy_subcitysubname);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:CityName", varbuy_cityname);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:PostalZone", varbuy_postalzone);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cbc:CountrySubentity", varbuy_countrySubentity);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PostalAddress|cac:Country|cbc:IdentificationCode", varbuy_countrycode);
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyTaxScheme|cac:TaxScheme|cbc:ID", "VAT");
            xml.UpdateChildContent("cac:AccountingCustomerParty|cac:Party|cac:PartyLegalEntity|cbc:RegistrationName", varbuyers_name);

            xml.UpdateChildContent("cac:Delivery|cbc:ActualDeliveryDate", varactdeli_date);
            xml.UpdateChildContent("cac:Delivery|cbc:LatestDeliveryDate", varactdeli_date);


            xml.UpdateChildContent("cac:PaymentMeans|cbc:PaymentMeansCode", varpay_code);

            string ExInvoice = "Invoice";
            string ExDrInvoice = "Debit";
            string ExCrInvoice = "Credit";

            int LookValInv = varinv_type.IndexOf(ExInvoice);
            int LookValDr = varinv_type.IndexOf(ExDrInvoice);
            int LookValCr = varinv_type.IndexOf(ExCrInvoice);

            if (LookValInv > 0)
            {
                xml.UpdateChildContent("cac:PaymentMeans|cbc:InstructionNote", varpay_inst);
            }

            if ((LookValDr > 0) || (LookValCr > 0))
            {
                xml.UpdateChildContent("cac:PaymentMeans|cbc:InstructionNote", varinstruction_code);
            }


            XMLInvoiceLine(varInv_type, Invoice_no);

            xml.UpdateChildContent("cac:AllowanceCharge[0]|cbc:ChargeIndicator", "false");
            xml.UpdateChildContent("cac:AllowanceCharge[0]|cbc:AllowanceChargeReason", "discount");
            xml.UpdateAttrAt("cac:AllowanceCharge[0]|cbc:Amount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:AllowanceCharge[0]|cbc:Amount", "0.00");

            int i;
            int Ar_Row;
            string Tax_Cat;
            decimal Tax_per;

            i = 0;
            while (i < Convert.ToInt32(Inv_ItemCount))// loop number of index here

            {
                //Optional for Single Tax Activate this for Header Discount and Header Tax
                Ar_Row = i;
                Tax_Cat = Convert.ToString(ParseInvoiceLinedata[7, Ar_Row]);
                Tax_per = Convert.ToDecimal(ParseInvoiceLinedata[8, Ar_Row]) * 100;
                xml.I = i;
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:ID", true, "schemeID", "UN/ECE 5305");
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:ID", true, "schemeAgencyID", "6");
                xml.UpdateChildContent("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:ID", Tax_Cat);
                xml.UpdateChildContent("cac:AllowanceCharge|cac:TaxCategory[i]|cbc:Percent", Tax_per.ToString("0.00"));
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                xml.UpdateAttrAt("cac:AllowanceCharge|cac:TaxCategory[i]|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                xml.UpdateChildContent("cac:AllowanceCharge|cac:TaxCategory[i]|cac:TaxScheme|cbc:ID", "VAT");
                i = i + 1;
            }

            XMLGroupTaxTotal(varInv_type, Invoice_no);
            /*Total Tax Amount 
            Optional Activate if Single Tax*/

            xml.UpdateAttrAt("cac:TaxTotal[0]|cbc:TaxAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:TaxTotal[0]|cbc:TaxAmount", vargTotamnt_vat);

            string Gp_TaxCode;
            /* Activate of single Tax
            i = 1;
            */
            i = 0;
            while (i < Convert.ToInt32(InvGp_ItemCount))// loop number of index here

            {
                Ar_Row = i;

                xml.I = i;
                xml.UpdateAttrAt("cac:TaxTotal[i]|cbc:TaxAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:TaxTotal[i]|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxableAmount", Convert.ToString(GroupTaxTotaldata[1, Ar_Row]));
                xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cbc:TaxAmount", Convert.ToString(GroupTaxTotaldata[0, Ar_Row]));
                xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeID", "UN/ECE 5305");
                xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", true, "schemeAgencyID", "6");
                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:ID", Convert.ToString(GroupTaxTotaldata[2, Ar_Row]));
                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:Percent", Convert.ToString(Convert.ToDecimal(GroupTaxTotaldata[3, Ar_Row]) * 100));

                /*Tax Excemtion Z, O, E or No Vat... this will Appear
                ===================================================*/
                Gp_TaxCode = Convert.ToString(GroupTaxTotaldata[2, Ar_Row]);

                if ((Gp_TaxCode == "Z") || (Gp_TaxCode == "O") || (Gp_TaxCode == "E"))
                {
                    xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReasonCode", Convert.ToString(GroupTaxTotaldata[4, Ar_Row]));
                    xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cbc:TaxExemptionReason", Convert.ToString(GroupTaxTotaldata[5, Ar_Row]));
                }

                xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeID", "UN/ECE 5153");
                xml.UpdateAttrAt("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", true, "schemeAgencyID", "6");
                xml.UpdateChildContent("cac:TaxTotal[i]|cac:TaxSubtotal|cac:TaxCategory|cac:TaxScheme|cbc:ID", "VAT");

                i = i + 1;
            }


            //Legal Monetary
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:LineExtensionAmount", true, "currencyID", "SAR");
            /* for version 1 */
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:LineExtensionAmount", vargTot_TaxExclAmount);

            /* for version 2 not validated
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:LineExtensionAmount", vargTot_LineExtAmount);
            */

            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:TaxExclusiveAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:TaxExclusiveAmount", vargTot_TaxExclAmount);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:TaxInclusiveAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:TaxInclusiveAmount", vargTot_TaxInclAmount);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:AllowanceTotalAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:AllowanceTotalAmount", vargTotamnt_allow);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:PrepaidAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:PrepaidAmount", vargTotamnt_prepaid);
            xml.UpdateAttrAt("cac:LegalMonetaryTotal|cbc:PayableAmount", true, "currencyID", "SAR");
            xml.UpdateChildContent("cac:LegalMonetaryTotal|cbc:PayableAmount", vargTotamnt_payable);


            //int i;
            int varCBC_ID;
            double varLn_Itm_Qty;
            string varItem_Desc;
            decimal varLnEx_Amount;
            decimal varLnAlw_ChargeDisc;
            decimal varLn_TaxTotal;
            decimal varLnExcl_Rounding;
            string varLn_TaxCode;
            decimal varLn_TaxPer;
            decimal varLn_PriceAmnt;
            double varLn_BaseQty;

            i = 0;

            //XMLInvoiceLine("Standard Invoice", Invoice_no);

            while (i < Convert.ToInt32(Inv_ItemCount)) //Loop number of invoice line here
            {
                varCBC_ID = Convert.ToInt32(ParseInvoiceLinedata[0, i]);

                varLn_Itm_Qty = Convert.ToDouble(ParseInvoiceLinedata[1, i]);
                varItem_Desc = Convert.ToString(ParseInvoiceLinedata[2, i]);
                varLnEx_Amount = Convert.ToDecimal(ParseInvoiceLinedata[3, i]);
                varLnAlw_ChargeDisc = Convert.ToDecimal(ParseInvoiceLinedata[4, i]);

                varLn_TaxTotal = Convert.ToDecimal(ParseInvoiceLinedata[5, i]);
                varLnExcl_Rounding = Convert.ToDecimal(ParseInvoiceLinedata[6, i]);

                varLn_TaxCode = Convert.ToString(ParseInvoiceLinedata[7, i]);
                varLn_TaxPer = Convert.ToDecimal(ParseInvoiceLinedata[8, i]) * 100;
                varLn_PriceAmnt = Convert.ToDecimal(ParseInvoiceLinedata[9, i]);
                varLn_BaseQty = Convert.ToDouble("1.0000"); //Base Quantity

                /* Version 1 */
                xml.I = i;
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:ID", Convert.ToString(varCBC_ID));// 1 here is item id
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:InvoicedQuantity", varLn_Itm_Qty.ToString("0.0000"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cbc:LineExtensionAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:LineExtensionAmount", varLnEx_Amount.ToString("0.00"));

                //New Update discount place under price amount or header invoice line(Same correct as per in manual)
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:ChargeIndicator", "false");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:AllowanceChargeReasonCode", "95");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:AllowanceChargeReason", "Discount");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:Amount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:AllowanceCharge|cbc:Amount", varLnAlw_ChargeDisc.ToString("0.00"));

                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", varLn_TaxTotal.ToString("0.00"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", varLnExcl_Rounding.ToString("0.00"));

                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cbc:Name", varItem_Desc);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:ID", varLn_TaxCode);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:Percent", Convert.ToString(varLn_TaxPer));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", varLn_PriceAmnt.ToString("0.00"));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:BaseQuantity", varLn_BaseQty.ToString("0.0000"));


                /*Version 2 not Validated
                xml.I = i;
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:ID", Convert.ToString(varCBC_ID));// 1 here is item id
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cbc:InvoicedQuantity", true, "unitCode", "PCE");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:InvoicedQuantity", varLn_Itm_Qty.ToString("0.0000"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cbc:LineExtensionAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cbc:LineExtensionAmount", varLnEx_Amount.ToString("0.00"));

                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:TaxAmount", varLn_TaxTotal.ToString("0.00"));
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:TaxTotal|cbc:RoundingAmount", varLnExcl_Rounding.ToString("0.00"));

                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cbc:Name", varItem_Desc);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:ID", varLn_TaxCode);
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cbc:Percent", Convert.ToString(varLn_TaxPer));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Item|cac:ClassifiedTaxCategory|cac:TaxScheme|cbc:ID", "VAT");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:PriceAmount", varLn_PriceAmnt.ToString("0.00"));
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cbc:BaseQuantity", varLn_BaseQty.ToString("0.0000"));

                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:ChargeIndicator", "false");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:AllowanceChargeReason", "discount");
                xml.UpdateAttrAt("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:Amount", true, "currencyID", "SAR");
                xml.UpdateChildContent("cac:InvoiceLine[i]|cac:Price|cac:AllowanceCharge|cbc:Amount", varLnAlw_ChargeDisc.ToString("0.00"));
                */

                i = i + 1;
            }
            //SignedXMLFiles(xml);
        }

        public void SignedXMLFiles(Chilkat.Xml XMLInv, string Cert_StrPem, string privkey_StrPem)
        {
            Chilkat.XmlDSigGen gen = new Chilkat.XmlDSigGen();
            bool success;

            gen.SigLocation = "Invoice|ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation";
            gen.SigLocationMod = 0;
            gen.SigId = "signature";
            gen.SigNamespacePrefix = "ds";
            gen.SigNamespaceUri = "http://www.w3.org/2000/09/xmldsig#";
            gen.SignedInfoCanonAlg = "C14N_11";
            gen.SignedInfoDigestMethod = "sha256";

            Chilkat.Xml object1 = new Chilkat.Xml();
            object1.Tag = "xades:QualifyingProperties";
            object1.AddAttribute("xmlns:xades", "http://uri.etsi.org/01903/v1.3.2#");
            object1.AddAttribute("Target", "signature");
            object1.UpdateAttrAt("xades:SignedProperties", true, "Id", "xadesSignedProperties");
            object1.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningTime", "TO BE GENERATED BY CHILKAT");
            object1.UpdateAttrAt("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:CertDigest|ds:DigestMethod", true, "Algorithm", "http://www.w3.org/2001/04/xmlenc#sha256");
            object1.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:CertDigest|ds:DigestValue", "TO BE GENERATED BY CHILKAT");
            object1.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:IssuerSerial|ds:X509IssuerName", "TO BE GENERATED BY CHILKAT");
            object1.UpdateChildContent("xades:SignedProperties|xades:SignedSignatureProperties|xades:SigningCertificate|xades:Cert|xades:IssuerSerial|ds:X509SerialNumber", "TO BE GENERATED BY CHILKAT");

            gen.AddObject("", object1.GetXml(), "", "");

            Chilkat.Xml xml1 = new Chilkat.Xml();

            xml1.Tag = "ds:Transforms";
            xml1.UpdateAttrAt("ds:Transform", true, "Algorithm", "http://www.w3.org/TR/1999/REC-xpath-19991116");
            xml1.UpdateChildContent("ds:Transform|ds:XPath", "not(//ancestor-or-self::ext:UBLExtensions)");
            xml1.UpdateAttrAt("ds:Transform[1]", true, "Algorithm", "http://www.w3.org/TR/1999/REC-xpath-19991116");
            xml1.UpdateChildContent("ds:Transform[1]|ds:XPath", "not(//ancestor-or-self::cac:Signature)");
            xml1.UpdateAttrAt("ds:Transform[2]", true, "Algorithm", "http://www.w3.org/TR/1999/REC-xpath-19991116");
            xml1.UpdateChildContent("ds:Transform[2]|ds:XPath", "not(//ancestor-or-self::cac:AdditionalDocumentReference[cbc:ID='QR'])");
            xml1.UpdateAttrAt("ds:Transform[3]", true, "Algorithm", "http://www.w3.org/2006/12/xml-c14n11");

            gen.AddSameDocRef2("", "sha256", xml1, "");
            gen.SetRefIdAttr("", "invoiceSignedData");

            //-------- Reference 2 --------
            gen.AddObjectRef("xadesSignedProperties", "sha256", "", "", "http://www.w3.org/2000/09/xmldsig#SignatureProperties");

            /*
            Provide a certificate + private key. (PFX password is test123)
            if (Module_Clas.PFX == "test123")
            {
                Chilkat.Cert certFromPfx = new Chilkat.Cert();
                success = certFromPfx.LoadPfxFile(Application.StartupPath + @"\Certificates\PCSID.pfx", "123");
                if (success == false)
                {
                    Debug.Print(certFromPfx.LastErrorText);
                    //MessageBox.Show(certFromPfx.LastErrorText);
                    return;
                }
            }
            Alternatively, if your certificate and private key are in separate PEM files, do this:
            */

            Chilkat.Cert cert = new Chilkat.Cert();
            //success = cert.LoadFromFile(Application.StartupPath + @"\Certificates\cert.pem");
            //success = cert.LoadFromFile(Application.StartupPath + @"\Certificates\cert.pem");
            //success = cert.LoadPem(Cert_StrPem);
            success = cert.SetFromEncoded(Cert_StrPem);




            if (success == false)
            {
                //MessageBox.Show(cert.LastErrorText);
                return;
            }

            //Load the private key.
            Chilkat.PrivateKey privKey = new Chilkat.PrivateKey();
            //success = privKey.LoadPemFile(Application.StartupPath + @"\Certificates\ec-secp256k1-priv-key.pem");
            success = privKey.LoadPem(privkey_StrPem);


            if (success == false)
            {
                //MessageBox.Show(privKey.LastErrorText);
                return;
            }

            /*
            Debug.Print "Key Type: " & privKey.KeyType
            Associate the private key with the certificate.
            success = cert.SetPrivateKey(certFromPfx)
            If (success <> 1) Then
            MsgBox cert.LastErrorText
            Exit Sub
            End If
            */
            success = cert.SetPrivateKey(privKey);
            if (success == false)
            {
                //MessageBox.Show(cert.LastErrorText);
                return;
            }
            gen.SetX509Cert(cert, true);
            gen.KeyInfoType = "X509Data";
            gen.X509Type = "Certificate";

            Chilkat.StringBuilder sbXml = new Chilkat.StringBuilder();
            XMLInv.GetXmlSb(sbXml);
            gen.Behaviors = "IndentedSignature,TransformSignatureXPath,ZATCA";

            string XMLVersion;
            /* XMLVersion = "<?xml version=" + ((char)34).ToString() + "1.0" + ((char)34).ToString() + " encoding=" + ((char)34).ToString() + "utf-8" + ((char)34).ToString() + "?>" + "\r\n"; */
            XMLVersion = "<?xml version=\"" + "1.0" + "\"" + " encoding=\"" + "utf-8" + "\"" + "?>" + "\r\n";
            sbXml.Replace(XMLVersion, "\r\n");
            success = gen.CreateXmlDSigSb(sbXml);
            if (success == false)
            {
                //MessageBox.Show(gen.LastErrorText, "Signing Certificate Error");
                return;
            }
            string DocInvoiceType;
            DocInvoiceType = varInv_type;

            string ExDrInvoice_Type = "Standard";
            int LookVal_InvTYpe = DocInvoiceType.IndexOf(ExDrInvoice_Type);

            if (LookVal_InvTYpe >= 0)
            {

                /*success = sbXml.WriteFile(Application.StartupPath + @"//tempXML//Temp_StandardSigned.xml", "utf-8", false);*/


                if (success == false)
                {
                    //MessageBox.Show("Failed to Create the Standard XML Invoice...");
                    return;
                }
                /*Verify the signatures we just produced */
                Chilkat.XmlDSig verifier = new Chilkat.XmlDSig();
                success = verifier.LoadSignatureSb(sbXml);
                if (success == false)
                {
                    //MessageBox.Show(verifier.LastErrorText);
                    return;
                }
                verifier.UncommonOptions = "ZATCA";
                /*ulong numSigs; */
                ulong numSigs;
                numSigs = ulong.Parse(verifier.NumSignatures.ToString());
                /*numSigs = verifier.NumSignatures; */
                ulong verifyIdx;
                verifyIdx = 0;
                while (verifyIdx < numSigs)
                {
                    verifier.Selector = (int)verifyIdx;
                    bool verified = new bool();

                    verified = verifier.VerifySignature(true);
                    if (verified == false)
                    {
                        //MessageBox.Show(verifier.LastErrorText, "Digital Signature Error", //MessageBoxButtons.OK, //MessageBoxIcon.Warning);
                        return;
                    }
                    verifyIdx = verifyIdx + 1;
                }

                _XMLInvoiceUTF8File = sbXml.GetAsString();
            }
            else
            {
                this.SimplifiedCryptStamp(sbXml);
            }
        }

        private void SimplifiedCryptStamp(Chilkat.StringBuilder xmlSignedSb)
        {

            Chilkat.BinData bdTlv = new Chilkat.BinData();
            string charset;
            int Tag;
            Boolean success = new Boolean();

            Chilkat.Xml xmlSigned = new Chilkat.Xml();
            success = xmlSigned.LoadSb(xmlSignedSb, false);
            if (success == false)
            {
                //MessageBox.Show(xmlSigned.LastErrorText);
                return;
            }

            charset = "utf-8";
            Tag = 1;
            bdTlv.AppendByte(Tag);
            bdTlv.AppendCountedString(1, false, varsellers_name, charset);
            /* Tag 1 */
            varsellers_nameTag1 = varsellers_name;



            Tag = Tag + 1;
            bdTlv.AppendByte(Tag);
            bdTlv.AppendCountedString(1, false, varsel_vatreg, charset);
            /* Tag 2 */
            varsel_vatregTag2 = varsel_vatreg;

            //Reference
            //DateTime now = DateTime.Now;
            //string DateT = now.ToString("yyyy-MM-dd");
            //string TimeZ = now.ToString("HH:mm:ss");


            string DateT = DateTime.Parse(varinv_date).ToString("yyyy-MM-dd") + "T";
            string TimeZ = DateTime.Parse(varinv_time).ToString("HH:mm:ss");

            string InvTimeStamp = DateT + TimeZ;

            Tag = Tag + 1;
            bdTlv.AppendByte(Tag);
            bdTlv.AppendCountedString(1, false, InvTimeStamp, charset);

            /* Tag 3 */
            varTimeStampTag3 = InvTimeStamp;

            Tag = Tag + 1;
            bdTlv.AppendByte(Tag);
            bdTlv.AppendCountedString(1, false, vargTotamnt_payable, charset);
            /* Tag 4 */
            vargTotamnt_payableTag4 = vargTotamnt_payable;

            Tag = Tag + 1;
            bdTlv.AppendByte(Tag);
            bdTlv.AppendCountedString(1, false, vargTotamnt_vat, charset);
            /* Tag 5 */
            varMgTotamnt_vatTag5 = vargTotamnt_vat;

            Chilkat.StringBuilder sbDigestValue = new Chilkat.StringBuilder();
            success = xmlSigned.GetChildContentSb("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|ds:Signature|ds:SignedInfo|ds:Reference[0]|ds:DigestValue", sbDigestValue);
            if (success == false)
            {
                //MessageBox.Show("Failed to get DigestValue from signed XML.", "DigestValue", //MessageBoxButtons.OK, //MessageBoxIcon.Exclamation);
                return;
            }

            Tag = 6;
            bdTlv.AppendByte(Tag);
            bdTlv.AppendByte(sbDigestValue.Length);
            bdTlv.AppendSb(sbDigestValue, "utf-8");
            /* Tag 6 */
            varHashXMLTag6 = sbDigestValue.GetAsString();

            Chilkat.StringBuilder sbSignatureValue = new Chilkat.StringBuilder();
            success = xmlSigned.GetChildContentSb("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|ds:Signature|ds:SignatureValue", sbSignatureValue);
            if (success == false)
            {
                //MessageBox.Show("Failed to get SignatureValue from signed XML.");
                return;
            }


            Tag = 7;
            bdTlv.AppendByte(Tag);
            bdTlv.AppendByte(sbSignatureValue.Length);
            bdTlv.AppendSb(sbSignatureValue, "utf-8");
            /* Tag 7 */
            varEcdsa_sigTag7 = sbSignatureValue.GetAsString();

            string x509Certificate;
            x509Certificate = xmlSigned.GetChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|ds:Signature|ds:KeyInfo|ds:X509Data|ds:X509Certificate");
            if (xmlSigned.LastMethodSuccess == false)
            {
                //MessageBox.Show("Failed to get X509Certificate from the signed XML.");
                return;
            }

            Chilkat.Cert cert = new Chilkat.Cert();
            success = cert.SetFromEncoded(x509Certificate);
            if (success == false)
            { //MessageBox.Show("Failed to load signing certificate from base64.");
              return; }

                Chilkat.BinData bdPubKey = new Chilkat.BinData();
                success = cert.GetPubKeyDer(true, bdPubKey);
                if (success == false)
                {
                    //MessageBox.Show("Failed to get certificate's public key.");
                    return;
                }

                Tag = 8;
                bdTlv.AppendByte(Tag);
                bdTlv.AppendByte(bdPubKey.NumBytes);
                bdTlv.AppendBd(bdPubKey);
                /* Tag 8 */
                varEcdsa_PubTag8 = bdPubKey.GetEncoded("base64");

                Chilkat.BinData bdCertSig = new Chilkat.BinData();
                success = cert.GetSignature(bdCertSig);
                if (success == false)
                {
                    //MessageBox.Show("Failed to get certificate's signature.");
                    return;
                }

                Tag = 9;
                bdTlv.AppendByte(Tag);
                bdTlv.AppendByte(bdCertSig.NumBytes);
                bdTlv.AppendBd(bdCertSig);

                /* Tag 9 */
                varCrypt_StampTag9 = bdCertSig.GetEncoded("hex");

                Chilkat.Xml xmlQR = new Chilkat.Xml();
                xmlQR.Tag = "cac:AdditionalDocumentReference";
                xmlQR.UpdateChildContent("cbc:ID", "QR");
                xmlQR.UpdateAttrAt("cac:Attachment|cbc:EmbeddedDocumentBinaryObject", true, "mimeCode", "text/plain");
                xmlQR.UpdateChildContent("cac:Attachment|cbc:EmbeddedDocumentBinaryObject", bdTlv.GetEncoded("base64"));

                Chilkat.StringBuilder sbReplaceStr = new Chilkat.StringBuilder();
                xmlQR.EmitXmlDecl = false;
                xmlQR.EmitCompact = true;
                sbReplaceStr.Append(xmlQR.GetXml());
                sbReplaceStr.Append("<cac:Signature>");
                success = xmlSignedSb.ReplaceFirst("<cac:Signature>", sbReplaceStr.GetAsString());
                if (success == false)
                {
                    //MessageBox.Show("Did not find <cac:Signature> in the signed XML");
                    return;
                }
                varQrCodeBase64 = bdTlv.GetEncoded("base64");

                //Default Directory
                //xmlSignedSb.WriteFile(Application.StartupPath + @"//tempXML//Temp_SimplifieddSigned.xml", "utf-8", false);

                Chilkat.XmlDSig verifier = new Chilkat.XmlDSig();
                success = verifier.LoadSignatureSb(xmlSignedSb);
                if (success == false)
                {
                    //MessageBox.Show(verifier.LastErrorText, "", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return;
                }

                verifier.UncommonOptions = "ZATCA";

                int numSigs = verifier.NumSignatures;
                int verifyIdx = 0;
                while (verifyIdx < numSigs)
                {
                    verifier.Selector = verifyIdx;
                    bool verified = verifier.VerifySignature(true);
                    if (verified != true)
                    {
                        //MessageBox.Show(verifier.LastErrorText, "Crypt Stamp Error", //MessageBoxButtons.OK, //MessageBoxIcon.Warning);
                        return;
                    }

                    verifyIdx = verifyIdx + 1;
                }
                _XMLInvoiceUTF8File = xmlSignedSb.GetAsString();

            
        }
        public Boolean Pro_XMLInvoice_Reqmnts(string refInv_type, string INVOICE_NUMBER)
        {

            try
            {

                varHashXMLTag6 = GetInvioceTagHash(XMLInvoiceUTF8File);
                if (varHashXMLTag6 == null)
                {
                    //MessageBox.Show("XML Invoice HASH Tag 6 Failed to Retrieve..", "ECDSA Signed", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return false;
                }

                varEcdsa_sigTag7 = GetXMLSignedtring(XMLInvoiceUTF8File);
                if (varEcdsa_sigTag7 == null)
                {
                    //MessageBox.Show("XML Invoice ECDSA Failed to retrieve..", "ECDSA Signed", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return false;
                }

                varXMLInvoiceString = GetXMLViews(XMLInvoiceUTF8File);

                if (varXMLInvoiceString == null)
                {
                    //MessageBox.Show("XML Invoice utf-8 Failed..", "XML String", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return false;
                }

                varXMLFileBase64 = Base64Encode(XMLInvoiceUTF8File);

                if (varXMLFileBase64 == null)
                {
                    //MessageBox.Show("Process XML FIle Base64 Failed..", "XML Base64", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return false;
                }

                varCur_InvoiceHASH_SHA256 = GetInvoiceHASH_SHA256(XMLInvoiceUTF8File);

                if (varCur_InvoiceHASH_SHA256 == null)
                {
                    //MessageBox.Show("Process Invoice Hash Failed..", "Invoice Hash", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return false;
                }

                //Update Proceess tag
                bool UpdateSuccess;
                UpdateSuccess = UpdateInvoiceHash(AttPIHId, AttPIH, varCur_InvoiceHASH_SHA256, varinv_no);

                if (UpdateSuccess == false)
                {
                    //MessageBox.Show("Update Invoice Hash Failed..", "Invoice Hash", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return false;
                }

                //Update DB Here

                /*Finalized XML Process*/
                //bool repCheck = ClassDefAcctRepository.DefAcctRepository(ClassMain.VarEnp_id, ClassMain.UserAcctId, ClassMain.VarCsOrg_Id);
                //if (repCheck == false)
                //{
                //    //MessageBox.Show("Please Create Repository of this Account..", "Repository", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                //    return false;
                //}

                /*  string Temp_InvoiceFilePath = Application.StartupPath;
                  string Inv_RootPath = Shared_InvoiceFilePath;
                */
                string Fdate = varinv_date.Replace("-", "");
                string FTime = varinv_time.Replace(":", "");
                string Firn = varinv_no.Replace("/", "");

                string XMLFilename = varsel_vatreg + "_" + Fdate.Replace(":", "") + "T" + FTime + "_" + Firn + ".xml";
                ClassMain Clm = new ClassMain();

                Clm.INVXMLFilename = XMLFilename;

                switch (refInv_type)
                {

                    //case "Standard Invoice":
                    //    Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdInv + @"\" + XMLFilename;

                    //    break;
                    //case "Standard Debit Note":
                    //    Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdDR + @"\" + XMLFilename;
                    //    break;
                    //case "Standard Credit Note":
                    //    Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdCR + @"\" + XMLFilename;
                    //    break;
                    //case "Simplified Invoice":
                    //    Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimInv + @"\" + XMLFilename;
                    //    break;
                    //case "Simplified Debit Note":
                    //    Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimDR + @"\" + XMLFilename;
                    //    break;
                    //case "Simplified Credit Note":
                    //    Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimCR + @"\" + XMLFilename;
                    //    break;
                    //default:
                    #region new
                    case "Standard Invoice":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdInv + @"\" + XMLFilename;
                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\StandardInvoice\\\\" + Path_InvoiceFile;
                        //
                        //return Path_InvoiceFile;
                        break;
                    case "Standard Debit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdDR + @"\" + XMLFilename;
                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\StandardDr\\\\" + Path_InvoiceFile;
                        //
                        //return Path_InvoiceFile;
                        break;
                    case "Standard Credit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdCR + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\StandardCr\\\\" + Path_InvoiceFile;
                        //

                        //return Path_InvoiceFile;
                        break;
                    case "Simplified Invoice":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimInv + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\SimplifiedInvoice\\\\" + Path_InvoiceFile;
                        //

                        //return Path_InvoiceFile;
                        break;
                    case "Simplified Debit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimDR + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\SimplifiedDr\\\\" + Path_InvoiceFile;
                        //

                        //return Path_InvoiceFile;
                        break;
                    case "Simplified Credit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimCR + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\SimplifiedCr\\\\" + Path_InvoiceFile;
                        //

                        // return Path_InvoiceFile;
                        break;
                    #endregion
                    default:
                        //MessageBox.Show("Process XML Invoice, Failed", "XML Invoice", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                        return false;
                }

                /* Change to Compose XML
                  File.Copy(InvTemp_Filename, Path_InvoiceFile, true);
                  Application.DoEvents();
                */
                string Q_QrCodeBase64 = string.Empty;
                if ((refInv_type == "Simplified Invoice") || (refInv_type == "Simplified Debit Note") || (refInv_type == "Simplified Credit Note"))
                {
                    bool buff_Success = Compose_XMLInvoices(refInv_type, XMLInvoiceUTF8File, Path_InvoiceFile,   INVOICE_NUMBER, "no");
                    if (buff_Success == false)
                    {
                        return false;

                    }
                    else
                    {
                        Q_QrCodeBase64 = GetQrCodeBase64_ZATCA_CryptStamp(Path_InvoiceFile);
                    }
                    if (File.Exists(Path_InvoiceFile))
                    {
                        //return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Q_QrCodeBase64 = string.Empty;
                }

                UpdateSuccess = DocFileUpdates(XMLInvoiceUTF8File, AttPIH, varCur_InvoiceHASH_SHA256, XMLFilename, Q_QrCodeBase64);

                if (UpdateSuccess == false)
                {
                    //MessageBox.Show("Update Invoice in table for upload Failed..", "XML Update", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                    return false;
                }

                return true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Reading InvoiceXML String", ex.Message, //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return false;
            }


        }

        private bool DocFileUpdates(string pvarXMLFileBase64, string pAttPIH, string pvarCur_InvoiceHASH_SHA256, string pXMLFileName, string pQrcodeBase64)
        {
            try
            {
                string QryInv;
                long xFileEx;

                string computername = System.Environment.MachineName;


                QryInv = "SELECT fld_indexzatca from ZekhahUpdates WHERE fld_doc_no='" + varinv_no + "' AND fld_doc_type='" + varInv_type + "' AND refreprocess IS NULL ORDER BY fld_indexzatca DESC;";
                xFileEx = ClassZATCACertCreation.GetFieldValueNumeric(QryInv);

                QryInv = string.Empty;
                string XMLBase64Encode = Base64Encode(pvarXMLFileBase64);
                QryInv = "INSERT INTO ZekhahUpdates(fld_index, fld_doc_no, fld_doc_type, fld_doc_date, fld_time, fld_update, fld_brcode, fld_note_id, invoicePHI, invoicetaghash, invoicehash, xmlBase64, fld_cbcuuid, xmlTempFilename, qrcodebase64, DeviceName)" +
                         "VALUES(" + Convert.ToInt32(varinv_index) + ", '" + varinv_no + "', '" + varInv_type + "', '" + varinv_date + "', '" + DateTime.Parse(varinv_time).ToString("HH:mm:ss") + "', 0, '" + varbrCode + "', 0, '" + pAttPIH + "', '" + varHashXMLTag6 + "', '" + pvarCur_InvoiceHASH_SHA256 + "', '" + XMLBase64Encode + "', '" + varX_UUID + "', '" + pXMLFileName + "', '" + pQrcodeBase64 + "', '" + computername + "');";


                SqlConfig Connection = new SqlConfig();
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                SqlCommand Cmd = new SqlCommand(QryInv, SqlConfig.ServerConn);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                SqlConfig.ServerConn.Close();

                if (xFileEx > 0)
                {
                    string RefPro;
                    string QryRef;
                    double CurRef;

                    QryRef = string.Empty;
                    QryRef = "SELECT MAX(fld_indexzatca) as LastIndexZa from ZekhahUpdates WHERE fld_doc_no='" + varinv_no + "' AND fld_doc_type='" + varInv_type + "' AND DeviceName='" + computername + "';";
                    CurRef = ClassZATCACertCreation.GetFieldValueNumeric(QryRef);

                    QryRef = string.Empty;
                    RefPro = "RefIndex#" + CurRef;
                    QryRef = "UPDATE ZekhahUpdates Set refreprocess='" + RefPro + "' WHERE fld_indexzatca=" + xFileEx + ";";

                    SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                    SqlCommand CmdU = new SqlCommand(QryRef, SqlConfig.ServerConn);

                    CmdU.ExecuteNonQuery();
                    CmdU.Dispose();
                    SqlConfig.ServerConn.Close();

                }
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool UpdateInvoiceHash(long cPIHId, string pInvHash, string cHash, string pvarinv_no)

        {

            string Qry;

            try
            {
                SqlConfig Connection = new SqlConfig();
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);


                Qry = string.Empty;
                Qry = "UPDATE ";
                Qry += "tblprocessPIH  ";
                Qry += "SET ";
                Qry += "processedTag  = 1,";
                Qry += "invPIH = '" + pInvHash + "',";
                Qry += "invHash = '" + cHash + "',";
                Qry += "fld_doc_no = '" + pvarinv_no + "' ";
                Qry += "WHERE pih_id = " + cPIHId + ";";

                SqlCommand Cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                SqlConfig.ServerConn.Close();
                return true;


            }
            catch (SqlException)
            {
                return false;
            }

        }
        public string GetInvioceTagHash(string pXMLInvoiceUTF8File)
        {
            Boolean IsSuccess;

            Chilkat.Xml xml = new Chilkat.Xml();
            /*string signedXmlFilePath = Temp_InvoiceFilePath + Temp_Filename(varInv_type);*/
            string signedXmlString = pXMLInvoiceUTF8File;

            //IsSuccess = xml.LoadXmlFile(signedXmlFilePath);
            IsSuccess = xml.LoadXml(signedXmlString);

            if (IsSuccess == false)
            {
                //MessageBox.Show(xml.LastErrorText);
                //MessageBox.Show(signedXmlString);
                return null;
            }

            xml.ChilkatPath("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|ds:Signature|ds:SignedInfo|ds:Reference[0]|ds:DigestMethod|(Algorithm)");
            string ds_DigestValue = xml.GetChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|ds:Signature|ds:SignedInfo|ds:Reference[0]|ds:DigestValue");
            return ds_DigestValue;
        }
        private string GetXMLSignedtring(string pXMLInvoiceUTF8File)
        {
            bool IsSuccess;
            new Chilkat.StringBuilder();

            Chilkat.Xml xml = new Chilkat.Xml();
            //string signedXmlFilePath;
            //signedXmlFilePath = Temp_InvoiceFilePath + Temp_Filename(varInv_type);

            IsSuccess = xml.LoadXml(pXMLInvoiceUTF8File);
            if (IsSuccess == false)
            {
                //MessageBox.Show(xml.LastErrorText);
                //MessageBox.Show(pXMLInvoiceUTF8File);
                return null;
            }

            string ds_SignatureValue;
            ds_SignatureValue = xml.GetChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|ds:Signature|ds:SignatureValue");
            return ds_SignatureValue;
        }
        /*
        private string GetXMLFileViews(string Temp_InvoiceFilePath)
        {
            _ = new Chilkat.Crypt2();
            string XMLReadString = Temp_InvoiceFilePath + Temp_Filename(varInv_type);
           
            Chilkat.FileAccess Facc = new Chilkat.FileAccess();

            Boolean success;
            success = Facc.OpenForRead(XMLReadString);
            success = Facc.OpenForRead(XMLReadString);

            if (success == false)
            {
                //MessageBox.Show(Facc.LastErrorText);
                return null;
            }
           
            Chilkat.BinData bd = new Chilkat.BinData();
            
            int maxBytesToRead = 99999999;
            success = Facc.FileReadBd(maxBytesToRead, bd);
            if (success == false)
            {
                //MessageBox.Show(Facc.LastErrorText);
                return null;
            }
            string XMLFileViews = bd.GetEncoded("utf-8"); //ansi
            Facc.FileClose();
            return XMLFileViews;
        }
        */
        private string GetXMLViews(string pXMLInvoiceUTF8File)
        {
            return pXMLInvoiceUTF8File.ToString();
        }
        /*
        private string GetXMLFileBase64(string Temp_InvoiceFilePath)
        {
            var fac = new Chilkat.FileAccess();

            var xmlBase64 = fac.ReadBinaryToEncoded(Temp_InvoiceFilePath + Temp_Filename(varInv_type), "base64");
           

            if (fac.LastMethodSuccess != true)
            {
                //MessageBox.Show(fac.LastErrorText);
                
                return null;
            }

            return xmlBase64;
        }
        */
        private string GetInvoiceHASH_SHA256(string pXMLInvoiceUTF8File)
        {
            bool success;
            string strXml;
            Chilkat.Xml xml = new Chilkat.Xml();

            success = xml.LoadXml(pXMLInvoiceUTF8File);
            if (success == false)
            {
                //MessageBox.Show("Failed to load for for Hashing PIH", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return "";
            }
            xml.RemoveChild("ext:UBLExtensions");
            xml.RemoveChild("cac:AdditionalDocumentReference[2]");

            strXml = xml.GetXml();

            Chilkat.XmlDSig xmldsig = new Chilkat.XmlDSig();
            string canonXml;

            canonXml = xmldsig.CanonicalizeXml(strXml, "C14N", false);

            string strTextToHash;
            strTextToHash = canonXml;

            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();

            crypt.Charset = "utf-8";
            crypt.EncodingMode = "hexlower";
            crypt.HashAlgorithm = "SHA256";

            Chilkat.StringBuilder sb = new Chilkat.StringBuilder();
            sb.Append(strTextToHash);
            sb.ToCRLF();

            Chilkat.BinData bd = new Chilkat.BinData();
            string strBase64;


            bd.AppendString(crypt.HashStringENC(sb.GetAsString()), "utf-8");
            strBase64 = bd.GetEncoded("base64");

            return strBase64;
        }
        private string Temp_Filename(string sInvType)

        {
            string InvTemp_Filename;
            string ExDrInvoice_Type = "Standard";
            int LookVal_InvTYpe = sInvType.IndexOf(ExDrInvoice_Type);

            if (LookVal_InvTYpe >= 0)
            {
                InvTemp_Filename = "Temp_StandardSigned.xml";
            }
            else
            {
                InvTemp_Filename = "Temp_SimplifieddSigned.xml";
            }
            return InvTemp_Filename;
        }
        private void Update_ZATCA_DATABASE()
        {

        }



        private void Pro_ResponsedXMLInvoice_Standard(string refInv_type, string Temp_InvoiceFilePath, string Shared_InvoiceFilePath)
        {
            /*
               GetZatca Responsed
               Composed XMLInvoice
               GetQrCodeBase64

             */
        }
        //For Compliance Update
        public bool POSTXML_Portal(string pInvoice_Type, string pServer_Portal, string pPost_Endpoint, string pXMLInv_Base64, string Unit_Authentication)
        {
            /*Check Connection */
            if (ConnectToPortal(string.Concat(pServer_Portal, pPost_Endpoint)) != true)
            {
                return false;
            }
            string XMLBase64Decode = Base64Decode(pXMLInv_Base64);
            Chilkat.Xml xml = new Chilkat.Xml();
            string ds_DigestValue;
            bool success;

            success = xml.LoadXml(XMLBase64Decode);
            if (success != true)
            {
                //MessageBox.Show("Failed to Load XML " + xml.LastErrorText, "XML", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return false;
            }

            string cbc_UUID = xml.GetChildContent("cbc:UUID");
            ds_DigestValue = xml.GetChildContent("ext:UBLExtensions|ext:UBLExtension|ext:ExtensionContent|sig:UBLDocumentSignatures|sac:SignatureInformation|ds:Signature|ds:SignedInfo|ds:Reference[0]|ds:DigestValue");

            Chilkat.JsonObject json = new Chilkat.JsonObject();

            json.UpdateString("summary", pInvoice_Type);
            json.UpdateString("invoiceHash", ds_DigestValue);
            json.UpdateString("uuid", cbc_UUID);
            json.UpdateString("invoice", pXMLInv_Base64);

            rest.AddHeader("accept", "application/json");
            rest.AddHeader("Content-Type", "application/json");
            rest.AddHeader("Accept-Language", "en");
            rest.AddHeader("Accept-Version", "V2");

            Chilkat.StringBuilder sbRequestBody = new Chilkat.StringBuilder();
            json.EmitSb(sbRequestBody);

            Chilkat.StringBuilder sbResponseBody = new Chilkat.StringBuilder();
            rest.AddHeader("Authorization", "Basic " + Unit_Authentication);
            success = rest.FullRequestSb("POST", pPost_Endpoint, sbRequestBody, sbResponseBody);
            int respStatusCode = rest.ResponseStatusCode;

            RespCode = 0;
            if (success != true)
            {
                //MessageBox.Show(rest.LastErrorText);
                RespCode = respStatusCode;
                return false;
            }

            if ((respStatusCode >= 200) && (respStatusCode < 400) && sbResponseBody.GetAsString() != null)
            {
                dynamic responseObj = JsonConvert.DeserializeObject(sbResponseBody.GetAsString());

                string ExDrInvoice_Type = "Standard";
                int LookVal_InvTYpe = pInvoice_Type.IndexOf(ExDrInvoice_Type);

                if (LookVal_InvTYpe >= 0)
                {
                    string restClearInvoice = responseObj.clearanceStatus;
                    Var_restClearInvoice = Convert.ToString(restClearInvoice);
                }

                Var_restResponseBody = sbResponseBody.GetAsString();
                RespCode = respStatusCode;
                return true;
            }
            else
            {
                RespCode = respStatusCode;
                Var_restResponseBody = sbResponseBody.GetAsString();
                return false;
            }


        }

        public string POSTXML_PortalLive(string pInvoice_Type, string pServer_Portal, string pPost_Endpoint, string pPuid, string pInvoiceHash, string pXMLInv_Base64, string Unit_Authentication, long pIndexPosted,string INVOICE_NUMBER)
        {
            string _return = "";
            /*Check Connection */
            if (ConnectToPortal(string.Concat(pServer_Portal, pPost_Endpoint)) != true)
            {
                _return = "Check Connection";
                return _return;
                // return false;
            }
            bool success;

            Chilkat.JsonObject json = new Chilkat.JsonObject();

            json.UpdateString("summary", pInvoice_Type);
            json.UpdateString("invoiceHash", pInvoiceHash);
            json.UpdateString("uuid", pPuid);
            json.UpdateString("invoice", pXMLInv_Base64);

            rest.AddHeader("accept", "application/json");
            rest.AddHeader("Content-Type", "application/json");
            rest.AddHeader("Accept-Language", "en");
            rest.AddHeader("Accept-Version", "V2");

            Chilkat.StringBuilder sbRequestBody = new Chilkat.StringBuilder();
            json.EmitSb(sbRequestBody);

            Chilkat.StringBuilder sbResponseBody = new Chilkat.StringBuilder();
            rest.AddHeader("Authorization", "Basic " + Unit_Authentication);
            success = rest.FullRequestSb("POST", pPost_Endpoint, sbRequestBody, sbResponseBody);
            int respStatusCode = rest.ResponseStatusCode;

            RespCode = 0;
            if (success != true)
            {
                //MessageBox.Show(rest.LastErrorText);
                RespCode = respStatusCode;
                _return = "Server Down";
                return _return;
               // return false;
            }
            string restClearInvoice;
            string Loaded_ClearInvoiceBase64;
            string Loaded_ClearInvoice;

            if ((respStatusCode >= 200) && (respStatusCode < 400) && sbResponseBody.GetAsString() != null)
            {
                dynamic responseObj = JsonConvert.DeserializeObject(sbResponseBody.GetAsString());

                string ExDrInvoice_Type = "Standard";
                int LookVal_InvTYpe = pInvoice_Type.IndexOf(ExDrInvoice_Type);

                if (LookVal_InvTYpe >= 0)
                {
                    restClearInvoice = responseObj.clearedInvoice;
                    Var_restClearInvoice = Convert.ToString(restClearInvoice);
                    Loaded_ClearInvoice = Base64Decode(restClearInvoice);
                }
                else
                {
                    Loaded_ClearInvoice = XMLInvoiceUTF8File;
                }
                string BuffXMLPath = XMLPathOfXMLInvoices(pInvoice_Type);
                bool BuffCompose = Compose_XMLInvoices(pInvoice_Type, Loaded_ClearInvoice, BuffXMLPath, INVOICE_NUMBER, sbResponseBody.GetAsString());


                string QryInv = string.Empty;
                if (BuffCompose != true)
                {
                    //MessageBox.Show("Failed to Composes XML File", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                }
                else
                {
                    //Retrieve Qr code
                    if (LookVal_InvTYpe >= 0) // Standard
                    {
                        string BuffQrCodeBase64 = this.GetQrCodeBase64_ZATCA_CryptStamp(BuffXMLPath);
                        Loaded_ClearInvoiceBase64 = responseObj.clearedInvoice;
                        QryInv = "UPDATE ZekhahUpdates SET fld_update = 1, datetimeupload = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', xmlBase64Approved = '" + Loaded_ClearInvoiceBase64 + "', qrcodebase64 = '" + BuffQrCodeBase64 + "' WHERE fld_indexzatca = " + pIndexPosted + "";
                    }
                    else
                    {
                        QryInv = "UPDATE ZekhahUpdates SET fld_update = 1, datetimeupload = '" + DateTime.Now.ToString("hh:mm:ss") + "' WHERE fld_indexzatca = " + pIndexPosted + "";

                    }
                    SqlConfig Connection = new SqlConfig();
                    SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                    SqlCommand Cmd = new SqlCommand(QryInv, SqlConfig.ServerConn);

                    Cmd.ExecuteNonQuery();
                    Cmd.Dispose();
                    SqlConfig.ServerConn.Close();
                }
                Var_restResponseBody = sbResponseBody.GetAsString();
                RespCode = respStatusCode;
                _return = "true";
                return _return;
               // return true;
            }
            else
            {
                string QryInv = string.Empty;
                QryInv = "UPDATE ZekhahUpdates SET fld_update = 1, datetimeupload = '" + DateTime.Now.ToString("hh:mm:ss") + "' WHERE fld_indexzatca = " + pIndexPosted + "";


                SqlConfig Connection = new SqlConfig();
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

                SqlCommand Cmd = new SqlCommand(QryInv, SqlConfig.ServerConn);

                Cmd.ExecuteNonQuery();
                Cmd.Dispose();
                SqlConfig.ServerConn.Close();
                
                Console.WriteLine("resp Status Code:"+ respStatusCode+ " , in_voice:" + INVOICE_NUMBER);
                RespCode = respStatusCode;
                Var_restResponseBody = sbResponseBody.GetAsString();
                //update
                InvoiceRepository _getInvoice = new InvoiceRepository();
                
                #region wrte 
               
                string xmlFile_name = "";
                #region  write 
                if (pInvoice_Type == "Standard Invoice")
                {
                    var update_in = _getInvoice.Update_zaca_status_detail(INVOICE_NUMBER, Var_restResponseBody);
                    var get_in = _getInvoice.get_allinvoice_data(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + "_" + get_in.inv_type;
                }
                else if (pInvoice_Type == "Standard Credit Note")
                {
                    var update_in = _getInvoice.Update_zaca_status_detail_vw_cr_salesinvoices(INVOICE_NUMBER, Var_restResponseBody);
                    var get_in = _getInvoice.get_allinvoice_data_vw_cr_salesinvoices(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + "_" + get_in.inv_type;

                }
                else if (pInvoice_Type == "Standard Debit Note")
                {
                    var update_in = _getInvoice.Update_zaca_status_detail_vw_dr_salesinvoices(INVOICE_NUMBER, Var_restResponseBody);
                    var get_in = _getInvoice.get_allinvoice_data_vw_dr_salesinvoices(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + "_" + get_in.inv_type;

                }
                else if (pInvoice_Type == "Simplified Invoice")
                {
                    var update_in = _getInvoice.Update_zaca_status_detail_vw_cashsalesinvoices(INVOICE_NUMBER, Var_restResponseBody);
                    var get_in = _getInvoice.get_allinvoice_data_vw_cashsalesinvoices(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + "_" + get_in.inv_type;
                }
                else if (pInvoice_Type == "Simplified Debit Note")
                {
                    var update_in = _getInvoice.Update_zaca_status_detail_vw_dr_salesinvoices_CASH(INVOICE_NUMBER, Var_restResponseBody);
                    var get_in = _getInvoice.get_allinvoice_data_vw_dr_salesinvoices_CASH(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + "_" + get_in.inv_type;

                }
                else if (pInvoice_Type == "Simplified Credit Note")
                {
                    var update_in = _getInvoice.Update_zaca_status_detail_vw_cr_salesinvoices_CASH(INVOICE_NUMBER, Var_restResponseBody);
                    var get_in = _getInvoice.get_allinvoice_data_vw_cr_salesinvoices_CASH(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + "_" + get_in.inv_type;

                }
                #endregion
                //get invoice data
                //update
                //var get_in = _getInvoice.get_allinvoice_data(INVOICE_NUMBER);
                //xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index+"_"+ get_in.inv_type;

                //

                string savePathFile1reject = "";


                savePathFile1reject = "C:\\\\ProRepository\\\\ZetcaREJECT\\\\" + xmlFile_name;

                //"C:\\\\Repository\\\\StandardInvoice\\310761410500003_20231104T00001_STDIN00002.xml"

                System.IO.File.WriteAllText(savePathFile1reject, Var_restResponseBody, Encoding.UTF8);
                #endregion
                //
                _return = "false";
                return _return;
               // return false;
            }


        }
        public string XMLPathOfXMLInvoices(string prefInv_type)
        {
            try
            {
                //ClassMain.VarSta_inv_date = "2023-11-04";
                //    ClassMain.VarSta_inv_time = "00001";
                //ClassMain.VarSta_inv_no = "STDIN00002";


                ClassDefAcctRepository.DefAcctRepository(ClassMain.VarEnp_id, ClassMain.UserAcctId, ClassMain.VarCsOrg_Id);

            string Fdate = ClassMain.VarSta_inv_date.Replace("-", "");
            string FTime = ClassMain.VarSta_inv_time.Replace(":", "");
            string Firn = ClassMain.VarSta_inv_no.Replace("/", "");

            Qry = string.Empty;
            Qry = "SELECT regunitid FROM cs_orgunit WHERE csorg_id =  " + ClassMain.VarCsOrg_Id + "";
            string Unit_varsel_vatreg = GetFieldValue(Qry);

            string XMLFilename = Unit_varsel_vatreg + "_" + Fdate.Replace(":", "") + "T" + FTime + "_" + Firn + ".xml";
                switch (prefInv_type)
                {
                    case "Standard Invoice":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdInv + @"\" + XMLFilename;
                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\StandardInvoice\\\\" + Path_InvoiceFile;
                        //
                        return Path_InvoiceFile;
                    case "Standard Debit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdDR + @"\" + XMLFilename;
                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\StandardDr\\\\" + Path_InvoiceFile;
                        //
                        return Path_InvoiceFile;
                    case "Standard Credit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdCR + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\StandardCr\\\\" + Path_InvoiceFile;
                        //

                        return Path_InvoiceFile;
                    case "Simplified Invoice":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimInv + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\SimplifiedInvoice\\\\" + Path_InvoiceFile;
                        //

                        return Path_InvoiceFile;
                    case "Simplified Debit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimDR + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\SimplifiedDr\\\\" + Path_InvoiceFile;
                        //

                        return Path_InvoiceFile;
                    case "Simplified Credit Note":
                        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimCR + @"\" + XMLFilename;

                        //
                        Path_InvoiceFile = "C:\\\\ProRepository\\\\SimplifiedCr\\\\" + Path_InvoiceFile;
                        //

                        return Path_InvoiceFile;
                    default:
                        return string.Empty;
                }
                //switch (prefInv_type)
                //{
                //    case "Standard Invoice":
                //        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdInv + @"\" + XMLFilename;
                //        return Path_InvoiceFile;
                //    case "Standard Debit Note":
                //        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdDR + @"\" + XMLFilename;
                //        return Path_InvoiceFile;
                //    case "Standard Credit Note":
                //        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseStdCR + @"\" + XMLFilename;
                //        return Path_InvoiceFile;
                //    case "Simplified Invoice":
                //        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimInv + @"\" + XMLFilename;
                //        return Path_InvoiceFile;
                //    case "Simplified Debit Note":
                //        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimDR + @"\" + XMLFilename;
                //        return Path_InvoiceFile;
                //    case "Simplified Credit Note":
                //        Path_InvoiceFile = ClassDefAcctRepository.DefBrowseSimCR + @"\" + XMLFilename;
                //        return Path_InvoiceFile;
                //    default:
                //        return string.Empty;
                //}
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static string Get_FieldValue(string get_Qry)
        {
            try
            {
                string GetValue;
                if (SqlConfig.ServerConn != null && SqlConfig.ServerConn.State == ConnectionState.Closed) { SqlConfig.ConnectToServer(SqlConfig.ConnectionString); }
                SqlCommand Cmd = new SqlCommand(get_Qry, SqlConfig.ServerConn);
                IDataReader reader = Cmd.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    GetValue = reader.GetString(0);
                }
                else
                {
                    SqlConfig.ServerConn.Close();
                    return string.Empty;
                }
                reader.Close();
                Cmd.Dispose();

                SqlConfig.ServerConn.Close();
                return GetValue;
            }
            catch (SqlException)
            {
                SqlConfig.ServerConn.Close();
                return string.Empty;


            }

        }

        /*=================================*/
        private string connectionString;
        public void DatabaseReader(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetFieldsFromTable(string tableName, List<string> fieldNames)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create the SQL query to retrieve the specified fields from the table.
                string query = $"SELECT {string.Join(", ", fieldNames)} FROM {tableName}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        return dataTable;
                    }
                }
            }
        }
        /* // Example usage of the GetFieldsFromTable function.
        string connectionString = "your_connection_string_here";
        string tableName = "your_table_name_here";
        List<string> fieldNames = new List<string> { "field1", "field2", "field3" };
 
        var databaseReader = new DatabaseReader(connectionString);
        DataTable dataTable = databaseReader.GetFieldsFromTable(tableName, fieldNames);
 
        // Display the retrieved fields.
        foreach (DataRow row in dataTable.Rows)
        {
            foreach (string fieldName in fieldNames)
            {
                Console.WriteLine($"{fieldName}: {row[fieldName]}");
            }
            Console.WriteLine();  // Newline for separation.
        }
        ************/

        //public static string Get_MultipleFieldValue(string get_Qry)
        //{

        //}

        /*
        public static bool Compose_InvoicesBase64(string prefInv_type, string sXMLPath, string XMLInvoiceUTF8File)
        {
            Boolean success;
            Chilkat.BinData XMLData = new Chilkat.BinData();

            string ExTypeInvoice = "Standard";
            int LookValExType = prefInv_type.IndexOf(ExTypeInvoice);
            
            if (LookValExType > 0)
             {
                XMLData.AppendEncoded(XMLInvoiceUTF8File, "base64");
            }
            
            success = XMLData.WriteFile(sXMLPath);
            
            if (success == false)
            {
                //MessageBox.Show("Failed to Composes XML File", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return false;
            }
            return true;
                       
        }
        */
        //public static bool Contains(this string source, string toCheck, StringComparison comp)
        //{
        //    return source.IndexOf(toCheck, comp) >= 0;
        //}
        //string title = "STRING";
        //bool contains = title.Contains("string", StringComparison.OrdinalIgnoreCase);
        public static bool Compose_XMLInvoices(string prefInv_type, string XMLInvoiceUTF8File, string sbXMLPathFile, string INVOICE_NUMBER, string zackaresponce)
        {

            //Chilkat.Xml XMLData = new Chilkat.Xml();
            //Chilkat.StringBuilder sbXml = new Chilkat.StringBuilder();

            //sbXml.Append(XMLInvoiceUTF8File);

            //XMLData.GetXmlSb(sbXml);
            //Buff_success = XMLData.LoadXml(XMLInvoiceUTF8File);

            //if (Buff_success == false)
            //{
            //    //MessageBox.Show("XM File Not Loaded", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Information );
            //}

            //Buff_success = XMLData.SaveXml(sbXMLPathFile);
            try
            {
                //inv_index, inv_no, inve_type, xml_name,xml_path
            
                InvoiceRepository _getInvoice = new InvoiceRepository();
                string xmlFile_name = "";
                string inv_index = ""; string inv_no = "";
                //get invoice data
                //update
                string CleardIncocie = "";
                //
                string sbXMLPathFile2 = "";
                string sbXMLPathFile1 = "";
                if (prefInv_type == "Standard Invoice")
                {
                    var get_in = _getInvoice.get_allinvoice_data(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + ".xml";
                    //
                    inv_index = get_in.inv_index.ToString();
                        inv_no = INVOICE_NUMBER;
                    //
                    var update_in = _getInvoice.update_xml_name_for_attachemnt(INVOICE_NUMBER, sbXMLPathFile);
                    //sbXMLPathFile1 = "C:\\\\ProRepository\\\\StandardInvoice" + sbXMLPathFile;
                    sbXMLPathFile1 = sbXMLPathFile;
                    sbXMLPathFile2 = "C:\\\\ProRepository\\\\StandardInvoice\\\\" + xmlFile_name;
                    System.IO.File.WriteAllText(sbXMLPathFile1, XMLInvoiceUTF8File, Encoding.UTF8);
                    System.IO.File.WriteAllText(sbXMLPathFile2, XMLInvoiceUTF8File, Encoding.UTF8);
                }
                else if (prefInv_type == "Standard Credit Note")
                {
                     
                    var get_in = _getInvoice.get_allinvoice_data_vw_cr_salesinvoices(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + ".xml";
                    //
                    inv_index = get_in.inv_index.ToString();
                    inv_no = INVOICE_NUMBER;
                    //
                    var update_in = _getInvoice.update_xml_name_for_attachemnt_vw_cr_salesinvoices(INVOICE_NUMBER, sbXMLPathFile);
                    //sbXMLPathFile1 = "C:\\\\ProRepository\\\\StandardCr" + sbXMLPathFile;
                    sbXMLPathFile1 = sbXMLPathFile;
                    sbXMLPathFile2 = "C:\\\\ProRepository\\\\StandardCr\\\\" + xmlFile_name;
                    System.IO.File.WriteAllText(sbXMLPathFile1, XMLInvoiceUTF8File, Encoding.UTF8);
                    System.IO.File.WriteAllText(sbXMLPathFile2, XMLInvoiceUTF8File, Encoding.UTF8);
                     
                }
                else if (prefInv_type == "Standard Debit Note")
                {

                    var get_in = _getInvoice.get_allinvoice_data_vw_dr_salesinvoices(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + ".xml";
                    //
                    inv_index = get_in.inv_index.ToString();
                    inv_no = INVOICE_NUMBER;
                    //
                    var update_in = _getInvoice.update_xml_name_for_attachemnt_vw_dr_salesinvoices(INVOICE_NUMBER, sbXMLPathFile);
                    //sbXMLPathFile1 = "C:\\\\ProRepository\\\\StandardDr" + sbXMLPathFile;
                    sbXMLPathFile1 = sbXMLPathFile;
                    sbXMLPathFile2 = "C:\\\\ProRepository\\\\StandardDr\\\\" + xmlFile_name;
                    System.IO.File.WriteAllText(sbXMLPathFile1, XMLInvoiceUTF8File, Encoding.UTF8);
                    System.IO.File.WriteAllText(sbXMLPathFile2, XMLInvoiceUTF8File, Encoding.UTF8);

                }

                else if (prefInv_type == "Simplified Invoice")
                {
                    var get_in = _getInvoice.get_allinvoice_data_vw_cashsalesinvoices(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + ".xml";
                    //
                    inv_index = get_in.inv_index.ToString();
                    inv_no = INVOICE_NUMBER;
                    //
                    var update_in = _getInvoice.update_xml_name_for_attachemnt_vw_cashsalesinvoices(INVOICE_NUMBER, sbXMLPathFile);
                    //sbXMLPathFile1 = "C:\\\\Repository\\\\StandardInvoice" + sbXMLPathFile;
                    sbXMLPathFile1 = sbXMLPathFile;
                    sbXMLPathFile2 = "C:\\\\ProRepository\\\\SimplifiedInvoice\\\\" + xmlFile_name;
                    System.IO.File.WriteAllText(sbXMLPathFile1, XMLInvoiceUTF8File, Encoding.UTF8);
                    System.IO.File.WriteAllText(sbXMLPathFile2, XMLInvoiceUTF8File, Encoding.UTF8);
                }
                else if (prefInv_type == "Simplified Debit Note")
                {

                    var get_in = _getInvoice.get_allinvoice_data_vw_dr_salesinvoices_CASH(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + ".xml";
                    //
                    inv_index = get_in.inv_index.ToString();
                    inv_no = INVOICE_NUMBER;
                    //
                    var update_in = _getInvoice.update_xml_name_for_attachemnt_vw_dr_salesinvoices_CASH(INVOICE_NUMBER, sbXMLPathFile);
                    //sbXMLPathFile1 = "C:\\\\Repository\\\\StandardDr" + sbXMLPathFile;
                    sbXMLPathFile1 = sbXMLPathFile;
                    sbXMLPathFile2 = "C:\\\\ProRepository\\\\SimplifiedDr\\\\" + xmlFile_name;
                    System.IO.File.WriteAllText(sbXMLPathFile1, XMLInvoiceUTF8File, Encoding.UTF8);
                    System.IO.File.WriteAllText(sbXMLPathFile2, XMLInvoiceUTF8File, Encoding.UTF8);

                }

                else if (prefInv_type == "Simplified Credit Note")
                {

                    var get_in = _getInvoice.get_allinvoice_data_vw_cr_salesinvoices_CASH(INVOICE_NUMBER);
                    xmlFile_name = "inv_" + get_in.inv_no + "_rec_" + get_in.inv_index + ".xml";
                    //
                    inv_index = get_in.inv_index.ToString();
                    inv_no = INVOICE_NUMBER;
                    //
                    var update_in = _getInvoice.update_xml_name_for_attachemnt_vw_cr_salesinvoices_CASH(INVOICE_NUMBER, sbXMLPathFile);
                    //sbXMLPathFile1 = "C:\\\\Repository\\\\StandardDr" + sbXMLPathFile;
                    sbXMLPathFile1 = sbXMLPathFile;
                    sbXMLPathFile2 = "C:\\\\ProRepository\\\\SimplifiedCr\\\\" + xmlFile_name;
                    System.IO.File.WriteAllText(sbXMLPathFile1, XMLInvoiceUTF8File, Encoding.UTF8);
                    System.IO.File.WriteAllText(sbXMLPathFile2, XMLInvoiceUTF8File, Encoding.UTF8);

                }

                //"C:\\\\Repository\\\\StandardInvoice\\310761410500003_20231104T00001_STDIN00002.xml"
                if (zackaresponce == "no")
                {

                }
                else
                {
                    attachemnt_mail insertattachemnt_mail = new attachemnt_mail();
                    insertattachemnt_mail.inve_type = prefInv_type;
                    insertattachemnt_mail.inv_index = inv_index;
                    insertattachemnt_mail.inv_no = inv_no;
                    insertattachemnt_mail.xml_path = sbXMLPathFile2;
                    insertattachemnt_mail.xml_name = xmlFile_name;
                    //
                    insertattachemnt_mail.ZacaRes = zackaresponce;
                    //
                    string savePathFile1reject = "";
                    Guid newGuid = Guid.NewGuid();
                    CleardIncocie = "Cleard_" + INVOICE_NUMBER + prefInv_type + newGuid;
                    savePathFile1reject = "C:\\\\ProRepository\\\\ZetcaREJECT\\\\" + CleardIncocie;

                    insertattachemnt_mail.ZacaPath = savePathFile1reject;
                    //
                    int insert_att = _getInvoice.InsertAttachmentMail(insertattachemnt_mail);
                    System.IO.File.WriteAllText(savePathFile1reject, zackaresponce, Encoding.UTF8);
                }
                //
                 
                return true;
                //if (Buff_success == false)
                //{
                //    //MessageBox.Show("Failed to Composes XML File", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                //    return false;
                //}
            }
            catch (SqlException)
            {
                return false;

            }


        }
        public static bool Compose_XMLInvoicesResponsed(string prefInv_type, string XMLInvoiceUTF8File, string sbXMLPathFile)
        {
            Boolean Buff_success;
            Chilkat.Xml XMLData = new Chilkat.Xml();
            Chilkat.StringBuilder sbXml = new Chilkat.StringBuilder();

            string ExTypeInvoice = "Simplified";
            int LookValExType = prefInv_type.IndexOf(ExTypeInvoice);

            if (LookValExType >= 0)
            {
                sbXml.Append(XMLInvoiceUTF8File);
            }
            else
            {
                sbXml.Decode(XMLInvoiceUTF8File, "base64");
            }

            XMLData.GetXmlSb(sbXml);

            Buff_success = sbXml.WriteFile(sbXMLPathFile, "utf-8", false);
            if (Buff_success == false)
            {
                //MessageBox.Show("Failed to Composes XML File", "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private string GetQrCodeBase64_ZATCA_CryptStamp(string InvoiceFilePath)
        {

            string cbc_EmbeddedDocumentBinaryObject;
            Chilkat.Xml xml = new Chilkat.Xml();
            string signedXmlFilePath;

            Boolean isSuccess;

            signedXmlFilePath = InvoiceFilePath;

            isSuccess = xml.LoadXmlFile(signedXmlFilePath);
            if (isSuccess == false)
            {
                //MessageBox.Show(xml.LastErrorText, "Error", //MessageBoxButtons.OK, //MessageBoxIcon.Error);
                return null;
            }
            cbc_EmbeddedDocumentBinaryObject = xml.GetChildContent("cac:AdditionalDocumentReference[2]|cac:Attachment|cbc:EmbeddedDocumentBinaryObject");
            return cbc_EmbeddedDocumentBinaryObject;

        }
        public static string GetRandomChar(int pLenght, string pChar)
        {
            Random res = new Random();
            int size = pLenght;
            String randomstring = "";

            for (int i = 0; i < size; i++)
            {
                int x = res.Next(pChar.Length);
                randomstring = randomstring + pChar[x];
            }
            return randomstring;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }



       
    }
}
