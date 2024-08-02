using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
 
using System.Management;

using System.IO;
using System.Net;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;

namespace scheduler
{
    class ClassZATCACertCreation
    {
        public string MessagesEvents { get; set; }
        public string emailAddress { get; set; }
        public string Country_RegCode { get; set; }
        public string Org_Unit { get; set; }
        public string Org_Name { get; set; }
        public string Unique_Name { get; set; }
        public string Unique_Id { get; set; }
        public string certificateTemplateNameExt { get; set; }
        public string Unit_Id { get; set; }
        public string Title_DocType { get; set; }
        public string registeredAddress { get; set; }
        public string businessCategory { get; set; }

        public string Str_CsConfig { get; set; }

        public string EventsMessages { get; set; }

        public static int Set_Csid { get; set; }
        public static bool Set_Modify { get; set; }
        public static int Set_Pcsid { get; set; }




        public void Create_Csr_Config(string pcsr_config)

        {
            try
            {
                string oid_section = "OIDs";
                string certificateTemplateName = "1.3.6.1.4.1.311.20.2";
                int default_bits = 2048;
                /*emailAddress = "myMail@gmail.com";*/
                string req_extensions = "v3_req";
                string x509_extensions = "v3_ca";
                string prompt = "no";
                string default_md = "sha 256";
                string distinguished_name = "dn";
                /*string C = "SA";//parse
                string OU = "Riyad Branch";//parse
                string O = "ArraTech";//parse
                string CN = "EA123456789";*/
                string basicConstraints = "CA:FALSE";
                string keyUsage = "digitalSignature, nonRepudiation, keyEncipherment";
                /*string certificateTemplateNameExt = "ASN1:PRINTABLESTRING:TSTZATCACodeSigning";*/
                string subjectAltName = "dirName:alt_names";
                /*string SN = "1-TST|2-ARA|3-1022aff4-14c5-11ee-be56-0242ac120002";
                string UID = "310122393500103";
                string Title_DocType = "1100";
                string registeredAddress = "Riyadh";
                string businessCategory = "IT";*/

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"oid_section = {oid_section}");
                sb.AppendLine("[OIDs]");
                sb.AppendLine($"certificateTemplateName = {certificateTemplateName}");
                sb.AppendLine("[req]");
                sb.AppendLine($"default_bits = {default_bits}");
                sb.AppendLine($"emailAddress = {emailAddress}");
                sb.AppendLine($"req_extensions = {req_extensions}");
                sb.AppendLine($"x509_extensions = {x509_extensions}");
                sb.AppendLine($"prompt = {prompt.ToString().ToLower()}");
                sb.AppendLine($"default_md = {default_md}");
                sb.AppendLine($"req_extensions = req_ext");
                sb.AppendLine($"distinguished_name = {distinguished_name}");
                sb.AppendLine("[dn]");
                sb.AppendLine($"C={Country_RegCode}");
                sb.AppendLine($"OU={Org_Unit}");
                sb.AppendLine($"O={Org_Name}");
                sb.AppendLine($"CN={Unique_Name}");
                sb.AppendLine("[v3_req]");
                sb.AppendLine($"basicConstraints = {basicConstraints}");
                sb.AppendLine($"keyUsage = {keyUsage}");
                sb.AppendLine("[req_ext]");
                sb.AppendLine($"certificateTemplateName = {certificateTemplateNameExt}");
                sb.AppendLine($"subjectAltName = {subjectAltName}");
                sb.AppendLine("[alt_names]");
                sb.AppendLine($"SN={Unique_Id}");
                sb.AppendLine($"UID={Unit_Id}");
                sb.AppendLine($"title={Title_DocType}");
                sb.AppendLine($"registeredAddress={registeredAddress}");
                sb.AppendLine($"businessCategory={businessCategory}");

                //return sb.ToString().Trim();
                //Change Here Base on Location Default
                Str_CsConfig = pcsr_config;
                Encoding isoLatin1Encoding = Encoding.UTF8;
                TextWriter Text_Wtr = new StreamWriter(Str_CsConfig, false, isoLatin1Encoding);
                Text_Wtr.WriteLine(sb.ToString().Trim());
                Text_Wtr.Close();
                File.WriteAllText(Str_CsConfig, sb.ToString().Trim());
            }
            catch (Exception ex)
            {
                ////MessageBox.Show($"CSR Configuration, Failed to update ..\n{ex.Message}", "CSR Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ////wFrmComCertCreation.Succ_Process = false;
                return;
            }

            /* Optional store to Drive
            Str_CsConfig = @"C:\zatcatest3\GeneratedCertificates\PowershellScript\csr_config.txt";
            Encoding isoLatin1Encoding = Encoding.UTF8;
            TextWriter Text_Wtr = new StreamWriter(Str_CsConfig, false, isoLatin1Encoding);
            Text_Wtr.WriteLine(sb.ToString().Trim());
            Text_Wtr.Close();
            File.WriteAllText(Str_CsConfig, sb.ToString().Trim());
            */
        }
        public string ConvertToPfx(string privateKeyPath, string certificatePath, string password)
        {
            try
            {

                string privateKey = File.ReadAllText(privateKeyPath);
                string certificate = File.ReadAllText(certificatePath);
                X509Certificate2 x509Certificate = new X509Certificate2(
                    Convert.FromBase64String(certificate),
                    password,
                    X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet
                );

                string pfxPath = Path.Combine(Path.GetTempPath(), "pcsid_Cert.pfx");
                File.WriteAllBytes(pfxPath, x509Certificate.Export(X509ContentType.Pfx, password));

                return pfxPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
        public string Generate_Uuid()
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();

            string uuid = crypt.GenerateUuid();

            return uuid;
        }
        public static void CutAndMoveFiles(string sourceDirectory, string destinationDirectory)
        {
            try
            {
                // Check if the source directory exists
                if (!Directory.Exists(sourceDirectory))
                {
                    throw new DirectoryNotFoundException($"Source directory '{sourceDirectory}' does not exist.");
                }

                // Check if the destination directory exists, create it if not
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Get all files in the source directory
                string[] files = Directory.GetFiles(sourceDirectory);

                // Move each file to the destination directory
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(destinationDirectory, fileName);
                    File.Move(file, destinationPath);
                }
            }
            catch (SqlException e)
            {
                throw new Exception($"An error occurred while cutting and moving files: {e.Message}");
            }
        }
        public static string Get_FieldValue(string get_Qry)
        {
            try
            {
                string GetValue;
                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                //SqlConfig.ServerConn.Open();
                SqlCommand Cmd = new SqlCommand(get_Qry, SqlConfig.ServerConn);
                IDataReader reader = Cmd.ExecuteReader();
                if (reader != null && reader.Read())
                {
                    GetValue = (string)reader[0].ToString();
                    //GetValue = (string)reader.GetString(0);

                }
                else
                {
                    return string.Empty;
                }
                reader.Close();
                Cmd.Dispose();

                SqlConfig.ServerConn.Close();
                return GetValue;
            }
            catch (SqlException)
            {
                return string.Empty;


            }

        }
        public static int GetFieldValueNumeric(string get_Qry)
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



    }
}
