using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler
{
    public static class ClassDefAcctRepository
    {
        static int _DefRepo_id;
        public static int DefRepo_id
        {
            get
            {
                return _DefRepo_id;
            }
            set
            {
                _DefRepo_id = value;
            }
        }
        static string _DefPortal;
        public static string DefPortal
        {
            get
            {
                return _DefPortal;
            }
            set
            {
                _DefPortal = value;
            }
        }
        static string _DefProcessFolder;
        public static string DefProcessFolder
        {
            get
            {
                return _DefProcessFolder;
            }
            set
            {
                _DefProcessFolder = value;
            }
        }

        static string _DefCertPath;
        public static string DefCertPath
        {
            get
            {
                return _DefCertPath;
            }
            set
            {
                _DefCertPath = value;
            }
        }
        static string _DefBrowseXMLPro;
        public static string DefBrowseXMLPro
        {
            get
            {
                return _DefBrowseXMLPro;
            }
            set
            {
                _DefBrowseXMLPro = value;
            }
        }
        static string _DefBrowseQrCodePro;
        public static string DefBrowseQrCodePro
        {
            get
            {
                return _DefBrowseQrCodePro;
            }
            set
            {
                _DefBrowseQrCodePro = value;
            }
        }

        static string _DefBrowsePDFA3a;
        public static string DefBrowsePDFA3a
        {
            get
            {
                return _DefBrowsePDFA3a;
            }
            set
            {
                _DefBrowsePDFA3a = value;
            }
        }
        static string _DefBrowseSimInv;
        public static string DefBrowseSimInv
        {
            get
            {
                return _DefBrowseSimInv;
            }
            set
            {
                _DefBrowseSimInv = value;
            }
        }
        static string _DefBrowseSimDR;
        public static string DefBrowseSimDR
        {
            get
            {
                return _DefBrowseSimDR;
            }
            set
            {
                _DefBrowseSimDR = value;
            }
        }
        static string _DefBrowseSimCR;
        public static string DefBrowseSimCR
        {
            get
            {
                return _DefBrowseSimCR;
            }
            set
            {
                _DefBrowseSimCR = value;
            }
        }
        static string _DefBrowseStdInv;
        public static string DefBrowseStdInv
        {
            get
            {
                return _DefBrowseStdInv;
            }
            set
            {
                _DefBrowseStdInv = value;
            }
        }
        static string _DefBrowseStdDR;
        public static string DefBrowseStdDR
        {
            get
            {
                return _DefBrowseStdDR;
            }
            set
            {
                _DefBrowseStdDR = value;
            }
        }
        static string _DefBrowseStdCR;
        public static string DefBrowseStdCR
        {
            get
            {
                return _DefBrowseStdCR;
            }
            set
            {
                _DefBrowseStdCR = value;
            }
        }
        static int _Defend_id;
        public static int Defend_id
        {
            get
            {
                return _Defend_id;
            }
            set
            {
                _Defend_id = value;
            }
        }
        static int _DefAcctId;
        public static int DefAcctId
        {
            get
            {
                return _DefAcctId;
            }
            set
            {
                _DefAcctId = value;
            }
        }
        static int _DefCsOrg_Id;
        public static int DefCsOrg_Id
        {
            get
            {
                return _DefCsOrg_Id;
            }
            set
            {
                _DefCsOrg_Id = value;
            }
        }

        static string _DefProCert;
        public static string DefProCert
        {
            get
            {
                return _DefProCert;
            }
            set
            {
                _DefProCert = value;
            }
        }
        static string _DefProPrivatekey;
        public static string DefProPrivatekey
        {
            get
            {
                return _DefProPrivatekey;
            }
            set
            {
                _DefProPrivatekey = value;
            }
        }
        static string _DefProAuth;
        public static string DefProAuth
        {
            get
            {
                return _DefProAuth;
            }
            set
            {
                _DefProAuth = value;
            }
        }

        public static bool DefAcctRepository(int pEnp_id, int pAcct_id, int pAcctorg_id)
        {
            string Qry;
            try
            {
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                //SqlConfig.ServerConn.Open();

                Qry = string.Empty;
                Qry = "SELECT ";
                Qry += "unit_repository.repo_id,";
                Qry += "cs_unitendpoint.server_portal,";
                Qry += "unit_repository.processfolder,";
                Qry += "unit_repository.cert_path,";
                Qry += "unit_repository.browsexmlpro,";
                Qry += "unit_repository.browseqrcodepro,";
                Qry += "unit_repository.browsepdfa3a,";
                Qry += "unit_repository.browsesimInv,";
                Qry += "unit_repository.browsesimdr,";
                Qry += "unit_repository.browsesimcr,";
                Qry += "unit_repository.browsestdInv,";
                Qry += "unit_repository.browsestddr,";
                Qry += "unit_repository.browsestdcr,";
                Qry += "unit_repository.enp_id,";
                Qry += "unit_repository.acct_id,";
                Qry += "unit_repository.csorg_id,";
                Qry += "cs_orgunit.org_code ";
                Qry += "FROM ";
                Qry += "unit_repository ";
                Qry += "INNER JOIN cs_orgunit ON(unit_repository.csorg_id = cs_orgunit.csorg_id) ";
                Qry += "INNER JOIN cs_unitendpoint ON(unit_repository.enp_id = cs_unitendpoint.enp_id) ";
                Qry += "WHERE ";
                Qry += "unit_repository.enp_id = " + pEnp_id + " AND "; /* must live of apply Invoice Process  */
                Qry += "unit_repository.acct_id = " + pAcct_id + " AND ";
                Qry += "unit_repository.csorg_id = " + pAcctorg_id + "";


                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    _DefRepo_id = reader.GetInt32(reader.GetOrdinal("repo_id"));
                    _DefProcessFolder = reader.GetString(reader.GetOrdinal("processfolder"));
                    _DefCertPath = reader.GetString(reader.GetOrdinal("cert_path"));

                    _DefBrowseXMLPro = reader.GetString(reader.GetOrdinal("browsexmlpro"));
                    _DefBrowseQrCodePro = reader.GetString(reader.GetOrdinal("browseqrcodepro"));
                    _DefBrowsePDFA3a = reader.GetString(reader.GetOrdinal("browsepdfa3a"));

                    _DefBrowseSimInv = reader.GetString(reader.GetOrdinal("browsesimInv"));
                    _DefBrowseSimDR = reader.GetString(reader.GetOrdinal("browsesimdr"));
                    _DefBrowseSimCR = reader.GetString(reader.GetOrdinal("browsesimcr"));

                    _DefBrowseStdInv = reader.GetString(reader.GetOrdinal("browsestdInv"));
                    _DefBrowseStdDR = reader.GetString(reader.GetOrdinal("browsestddr"));
                    _DefBrowseStdCR = reader.GetString(reader.GetOrdinal("browsestdcr"));

                    _Defend_id = reader.GetInt32(reader.GetOrdinal("enp_id"));
                    _DefAcctId = reader.GetInt32(reader.GetOrdinal("acct_id"));
                    _DefCsOrg_Id = reader.GetInt32(reader.GetOrdinal("csorg_id"));

                    cmd.Dispose();
                    reader.Close();
                    SqlConfig.ServerConn.Close();

                    return true;

                }
                else
                {
                    _DefRepo_id = 0;
                    _DefPortal = string.Empty;
                    _DefProcessFolder = string.Empty;
                    _DefCertPath = string.Empty;

                    _DefBrowseXMLPro = string.Empty;
                    _DefBrowseQrCodePro = string.Empty;
                    _DefBrowsePDFA3a = string.Empty;

                    _DefBrowseSimInv = string.Empty;
                    _DefBrowseSimDR = string.Empty;
                    _DefBrowseSimCR = string.Empty;

                    _DefBrowseStdInv = string.Empty;
                    _DefBrowseStdDR = string.Empty;
                    _DefBrowseStdCR = string.Empty;

                    _Defend_id = 0;
                    _DefAcctId = 0;
                    _DefCsOrg_Id = 0;

                    cmd.Dispose();
                    reader.Close();
                    SqlConfig.ServerConn.Close();

                    return false;
                }
            }
            catch (SqlException ex)
            {
               // MessageBox.Show(ex.Message + MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
                return false;
            }

        }
        public static bool DefAcctCertificates(int pEnp_id, int pAcct_id, int pcsorg_id)
        {
            string Qry;
            try
            {
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                //SqlConfig.ServerConn.Open();

                Qry = string.Empty;
                Qry += "SELECT ";

                if (pEnp_id == 1 || pEnp_id == 2)
                {
                    Qry += "unit_certificates.ccsid_pem,";
                    Qry += "unit_certificates.com_authtokenstring_base64,";
                }
                else if (pEnp_id == 3)
                {
                    Qry += "unit_certificates.pcsid_pem,";
                    Qry += "unit_certificates.pro_authtokenstring_base64,";

                }
                Qry += "unit_certificates.private_key ";
                Qry += "FROM ";
                Qry += "cs_unitconfig ";
                Qry += "INNER JOIN unit_certificates ON(cs_unitconfig.csid = unit_certificates.csid) ";
                Qry += "INNER JOIN csr_unitconfig ON(cs_unitconfig.csrid = csr_unitconfig.csrid) ";
                Qry += "INNER JOIN acct_orgunit ON(cs_unitconfig.csorg_id = acct_orgunit.csorg_id) ";
                Qry += "WHERE ";
                Qry += "cs_unitconfig.enp_id = " + pEnp_id + " AND ";
                Qry += "cs_unitconfig.acct_id = " + pAcct_id + " AND ";
                Qry += "csr_unitconfig.cert_status = 1 AND ";
                Qry += "cs_unitconfig.csorg_id = " + pcsorg_id + "";


                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (pEnp_id == 1 || pEnp_id == 2)
                    {
                        _DefProCert = reader.GetString(reader.GetOrdinal("ccsid_pem"));
                        _DefProAuth = reader.GetString(reader.GetOrdinal("com_authtokenstring_base64"));
                    }
                    else if (pEnp_id == 3)
                    {
                        _DefProCert = reader.GetString(reader.GetOrdinal("pcsid_pem"));
                        _DefProAuth = reader.GetString(reader.GetOrdinal("pro_authtokenstring_base64"));
                    }

                    _DefProPrivatekey = reader.GetString(reader.GetOrdinal("private_key"));


                    cmd.Dispose();
                    reader.Close();
                    SqlConfig.ServerConn.Close();

                    return true;

                }
                else
                {
                    _DefProCert = string.Empty;
                    _DefProPrivatekey = string.Empty;
                    _DefProAuth = string.Empty;

                    cmd.Dispose();
                    reader.Close();
                    SqlConfig.ServerConn.Close();
                    return false;
                }


            }
            catch (SqlException ex)
            {
               // MessageBox.Show(ex.Message + MessageBoxIcon.Error);
                SqlConfig.ServerConn.Close();
                return false;
            }

        }

    }
}
