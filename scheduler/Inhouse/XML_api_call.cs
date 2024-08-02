using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using scheduler.Inhouse;
using scheduler.ServiceReference1;
 
namespace scheduler
{
   public class XML_api_call
    {
        public async Task<string> callAPIAsync(string p_from_date, string p_to_date)
        {
            string _return = "no";
            try
            {

                string soapRequestBody = $@"<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:pub='http://xmlns.oracle.com/oxp/service/PublicReportService'>
    <soap:Header/>
   <soap:Body>
       <pub:runReport>
         <pub:reportRequest>
            <pub:attributeFormat>xml</pub:attributeFormat>
            <pub:parameterNameValues>
               <pub:item>
                  <pub:name>P_TRX_ID</pub:name>
                  <pub:values>
                     <pub:item></pub:item>
                  </pub:values>
               </pub:item>
               <pub:item>
                  <pub:name>p_from_date</pub:name>
                  <pub:values>
                     <pub:item>{p_from_date}</pub:item>
                  </pub:values>
               </pub:item>
              <pub:item>
                  <pub:name>p_to_date</pub:name>
                  <pub:values>
                     <pub:item>{p_to_date}</pub:item>
                  </pub:values>
               </pub:item>
            </pub:parameterNameValues>
            <pub:reportAbsolutePath>/Custom/JEDCO_Custom/Reports/Receivables/XX_AR_INVOICE_REPORT.xdo</pub:reportAbsolutePath>
            <pub:sizeOfDataChunkDownload>-1</pub:sizeOfDataChunkDownload>
         </pub:reportRequest>
      </pub:runReport>
      </soap:Body>
      </soap:Envelope>";
                #region MyRegion


                //              string soapRequestBody = @"<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:pub='http://xmlns.oracle.com/oxp/service/PublicReportService'>
                // <soap:Header/>
                //<soap:Body>
                //    <pub:runReport>
                //      <pub:reportRequest>
                //         <pub:attributeFormat>xml</pub:attributeFormat>
                //         <pub:parameterNameValues>
                //            <pub:item>
                //               <pub:name>P_TRX_ID</pub:name>
                //               <pub:values>
                //                  <pub:item>300000007684941</pub:item>
                //               </pub:values>
                //            </pub:item>
                //            <pub:item>
                //               <pub:name>p_from_date</pub:name>
                //               <pub:values>
                //                  <pub:item>null</pub:item>
                //               </pub:values>
                //            </pub:item>
                //           <pub:item>
                //               <pub:name>p_to_date</pub:name>
                //               <pub:values>
                //                  <pub:item>null</pub:item>
                //               </pub:values>
                //            </pub:item>
                //         </pub:parameterNameValues>
                //         <pub:reportAbsolutePath>/Custom/JEDCO_Custom/Reports/Receivables/XX_AR_INVOICE_REPORT.xdo</pub:reportAbsolutePath>
                //         <pub:sizeOfDataChunkDownload>-1</pub:sizeOfDataChunkDownload>
                //      </pub:reportRequest>
                //   </pub:runReport>
                //   </soap:Body>
                //   </soap:Envelope>";
                #endregion
                string url = "https://fa-ewnh-saasfaprod1.fa.ocs.oraclecloud.com:443/xmlpserver/services/ExternalReportWSSService";
                                
                string username = "Jderp";
                string password = "Fusion@987";
                string domain = "https://fa-ewnh-test-saasfaprod1.fa.ocs.oraclecloud.com";


               
                #region new raw
                using (var httpClient = new HttpClient())
                {
                    // Set basic authentication header
                    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                    // Construct your SOAP envelope and send the request
                    var soapEnvelope = @"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:pub=""http://xmlns.oracle.com/oxp/service/PublicReportService"">
    <soap:Header/>
   <soap:Body>
      <pub:runReport>
         <pub:reportRequest>
            <pub:attributeFormat>xml</pub:attributeFormat>
            <pub:reportAbsolutePath>/Custom/JEDCO_Custom/Reports/Receivables/ZATCA Invoice Report/XX_AR_INVOICE_REPORT.xdo</pub:reportAbsolutePath>
            <pub:sizeOfDataChunkDownload>-1</pub:sizeOfDataChunkDownload>
         </pub:reportRequest>
      </pub:runReport>
   </soap:Body>
</soap:Envelope>"; // Construct your SOAP envelope soapRequestBody
                    #region wite file
                    WriteToFile("   ***********  *******************************************************", "GetBase64Api");

                    string w_input = "Date time(" + DateTime.Now + " )URL:(" + url + ") User name:(" + username + ") Password:(" + password + ") Body:(" + soapEnvelope + ")";
                    WriteToFile(" Input object :-->" + w_input, "GetBase64Api");

                    #endregion
                    var content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml");
                    //  var content = new StringContent(soapRequestBody, Encoding.UTF8, "application/soap+xml");
                    // var response = await httpClient.PostAsync(url, content);
                   
                    var response = await httpClient.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        //var responseContent = await response.Content.ReadAsStringAsync();
                        var responseContent = await response.Content.ReadAsStringAsync();
                        try
                        {
                            // Deserialize XML to C# object
                            XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                            using (StringReader reader = new StringReader(responseContent))
                            {
                                Envelope envelope = (Envelope)serializer.Deserialize(reader);

                                // Access C# object properties
                               // Console.WriteLine(envelope.Body.RunReportResponse.RunReportReturn.ReportBytes);
                                //Insertion
                                #region insrtion
                                if (envelope.Body.RunReportResponse.RunReportReturn.ReportBytes !=null)
                                {
                                    InvoiceRepository _temp = new InvoiceRepository();
                                    InvoiceFromAPI_oracel _add = new InvoiceFromAPI_oracel();
                                    _add.Status = "0";
                                    _add.DateTimeInsertion = DateTime.Now;
                                    _add.Base64 = envelope.Body.RunReportResponse.RunReportReturn.ReportBytes;
                                    var insrt = _temp.Insert_InvoiceFromAPI_oracel(_add);
                                    if (insrt>0)
                                    {
                                        _return = "yes";
                                        // InsertionInInvice();
                                    }
                                }

                                #endregion
                                #region wite file
                                string w_output = "Date time(" + DateTime.Now + " )URL:(" + url + ") User name:(" + username + ") Password:(" + password + ") out body base64:(" + envelope.Body.RunReportResponse.RunReportReturn.ReportBytes + ")";
                                WriteToFile(" Out object :-->" + w_output, "GetBase64Api");
                                WriteToFile("   ***********  *******************************************************", "GetBase64Api");

                                #endregion
                            }
                        }
                        catch (Exception ex)
                        {
                            _return = "no";
                            Console.WriteLine($"setep1 callAPIAsync Exception: {ex}");
                            #region wite file
                            string w_ex = "Date time(" + DateTime.Now + " )URL:(" + url + ") User name:(" + username + ") Password:(" + password + ") exception :(" + ex + ")";
                            WriteToFile("  Exception :-->" + ex, "GetBase64Api");
                            WriteToFile("   ***********  *******************************************************", "GetBase64Api");

                            #endregion
                            throw;
                        }
                        // Process the successful response content
                         
                    }
                    // Process the response as needed
                }
                #endregion
                 
             
               

            }
            catch (Exception ex)
            {

                throw;
            }
            return _return;

        }
        public async Task<string> callAPIBACKAsync(string CUSTOMER_TRX_ID, string INV_NO, string STATUS)
        {
            string _return = "no";
            try
            {
                string body = $@" <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:typ=""http://xmlns.oracle.com/apps/financials/commonModules/shared/model/erpIntegrationService/types/"" xmlns:erp=""http://xmlns.oracle.com/apps/financials/commonModules/shared/model/erpIntegrationService/"">
<soapenv:Header/>
<soapenv:Body>
<typ:updateDffEntityDetails>
<typ:operationMode>SINGLE</typ:operationMode>
<!--Optional:-->
<typ:object>
<!--Optional:-->
<erp:EntityName>Receivables Invoice</erp:EntityName>
<!--Optional:-->
<erp:ContextValue>#NULL</erp:ContextValue>
<!--Optional:-->
<erp:UserKeyA>{INV_NO}</erp:UserKeyA>
<!--Optional:-->
<erp:UserKeyB>#NULL</erp:UserKeyB>
<!--Optional:-->
<erp:UserKeyC>#NULL</erp:UserKeyC>
<!--Optional:-->
<erp:UserKeyD>{CUSTOMER_TRX_ID}</erp:UserKeyD>
<!--Optional:-->
<erp:UserKeyE>#NULL</erp:UserKeyE>
<!--Optional:-->
<erp:DFFAttributes>{{""ATTRIBUTE3"":""{STATUS}""}}</erp:DFFAttributes>
</typ:object>
</typ:updateDffEntityDetails>
</soapenv:Body>
</soapenv:Envelope>

";
                
               
                string url = "https://fa-ewnh-saasfaprod1.fa.ocs.oraclecloud.com:443/fscmService/ErpObjectDFFUpdateService";
                string username = "Jderp";
                string password = "Fusion@987";
                string domain = "https://fa-ewnh-test-saasfaprod1.fa.ocs.oraclecloud.com";


                #region wite file
                WriteToFile("   ***********  *******************************************************", "UpdateStatusApi");

                string w_input = "Date time(" + DateTime.Now + " )URL:(" + url + ") User name:(" + username + ") Password:(" + password + ") Body:(" + body + ")";
                WriteToFile(" Input object :-->" + w_input, "UpdateStatusApi");

                #endregion
                #region new raw
                using (var httpClient = new HttpClient())
                {
                    // Set basic authentication header
                    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                    // Construct your SOAP envelope and send the request
                    var soapEnvelope = @"<soap:Envelope xmlns:soap='http://www.w3.org/2003/05/soap-envelope' xmlns:pub='http://xmlns.oracle.com/oxp/service/PublicReportService'>
    <soap:Header/>
   <soap:Body>
       <pub:runReport>
         <pub:reportRequest>
            <pub:attributeFormat>xml</pub:attributeFormat>
            <pub:parameterNameValues>
               <pub:item>
                  <pub:name>P_TRX_ID</pub:name>
                  <pub:values>
                     <pub:item></pub:item>
                  </pub:values>
               </pub:item>
               <pub:item>
                  <pub:name>p_from_date</pub:name>
                  <pub:values>
                     <pub:item>1/20/2023 16:54:51</pub:item>
                  </pub:values>
               </pub:item>
              <pub:item>
                  <pub:name>p_to_date</pub:name>
                  <pub:values>
                     <pub:item>12/25/2024 16:54:51</pub:item>
                  </pub:values>
               </pub:item>
            </pub:parameterNameValues>
            <pub:reportAbsolutePath>/Custom/JEDCO_Custom/Reports/Receivables/XX_AR_INVOICE_REPORT.xdo</pub:reportAbsolutePath>
            <pub:sizeOfDataChunkDownload>-1</pub:sizeOfDataChunkDownload>
         </pub:reportRequest>
      </pub:runReport>
      </soap:Body>
      </soap:Envelope>"; // Construct your SOAP envelope soapRequestBody

                    // var content = new StringContent(soapEnvelope, Encoding.UTF8, "application/soap+xml");
                    var content = new StringContent(body, Encoding.UTF8, "text/xml");
                    // var response = await httpClient.PostAsync(url, content);
                    var response = await httpClient.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        //var responseContent = await response.Content.ReadAsStringAsync();
                        var responseContent = await response.Content.ReadAsStringAsync();
                        _return = "yes";
                        #region wite file
                        string w_output = " status 200 OK --> Date time(" + DateTime.Now + " )URL:(" + url + ") User name:(" + username + ") Password:(" + password + ") out body  :(" + responseContent + ")";
                        WriteToFile(" {{Input object :-->" + w_input  + "}} *********** {{Out object :-->" + w_output+"}}", "UpdateStatusApi");
                        WriteToFile("   ***********  *******************************************************", "UpdateStatusApi");

                        #endregion
                        // Process the successful response content

                    }
                    else
                    {
                        #region wite file
                        string w_output = " status not  OK --> Date time(" + DateTime.Now + " )URL:(" + url + ") User name:(" + username + ") Password:(" + password + ") out body  :  )";
                        WriteToFile(" {{Input object :-->" + w_input + "}} *********** {{Out object :-->" + w_output + "}}", "UpdateStatusApi");
                        WriteToFile("   ***********  *******************************************************", "UpdateStatusApi");

                        #endregion
                    }
                    // Process the response as needed
                }
                #endregion




            }
            catch (Exception ex)
            {
                #region wite file
                WriteToFile("Exception      :-->" + ex, "UpdateStatusApi");
                WriteToFile("   ***********  *******************************************************", "UpdateStatusApi");

                #endregion
                throw;
            }



            return _return;

        }
        public string InsertionInInvice()
        {
            string _return = "no";
            try
            {

          
            InvoiceRepository _InvoiceRepository = new InvoiceRepository();
            
            #region isnserion Bae64 convert into key valyue for raw table
            #region BASE 64 
            // Base64-encoded XML data
            InvoiceRepository _temp = new InvoiceRepository();
            var get0 = _temp.GetAllInvoiceFromAPI_oracel();
            foreach (var item in get0)
            {
                // Step 1: Decode Base64
                ////string decodedData = DecodeBase64(base64Data);
                //string decodedData = DecodeBase64(item.Base64);
                //string csvData = @decodedData;
                //step 2 :  Parse CSV data
                #region xml decode
                string xmlString = DecodeBase64String(item.Base64);

                // Load the XML content into an XmlDocument
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                //
                // DataDs dataDs;
                ///////
                ///
                XmlSerializer serializer1 = new XmlSerializer(typeof(DATA_DS));
                using (var reader = new System.IO.StringReader(xmlString))
                {
                    var invoice = (DATA_DS)serializer1.Deserialize(reader);
                    foreach (var dataDs in invoice.G_1)
                    {
                            #region write
                            string w_output = "ID("+ item .Id+ ") INV:( "+ dataDs.INV_NO  + " ) type ( "+ dataDs.INV_TYPE + " )";
                            WriteToFile(    w_output  , "GetINV_FromXML");

                            #endregion
                            #region old woking
                            //if (dataDs.PARTY_ID == "27005" || dataDs.PARTY_ID == "20005")
                            //{

                            //    #region cash
                            //    if (dataDs.INV_TYPE.Contains("Debit Memo"))
                            //    {
                            //        #region vw_cr_salesinvoices
                            //        #region header

                            //        vw_dr_salesinvoices Inert_salesinvoices = new vw_dr_salesinvoices();
                            //        Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                            //        Inert_salesinvoices.ProcessZaca = "no";
                            //        Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                            //        Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                            //        //
                            //        Inert_salesinvoices.refinv_no = dataDs.ORG_INV_NUMBER ?? "00";//"202300007";//ORG_INV_NUMBER 
                            //        //Inert_salesinvoices.InvRef_Date = "2023-12-10";//ORG_INV_DATE
                            //        Inert_salesinvoices.instruction_code = dataDs.CREDIT_REASON ?? "00";// "CANCELLATION_OR_TERMINATION";//CREDIT_REASON

                            //        string dateString1 = dataDs.ORG_INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format1 = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString1, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result1))
                            //        {
                            //            Inert_salesinvoices.InvRef_Date = result1.ToString("yyyy-MM-dd");//date


                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.InvRef_Date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //
                            //        if (true)
                            //        {
                            //            if (dataDs.INV_TYPE.Contains("Debit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Simplified Debit Note";
                            //            }
                            //            else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Simplified Credit Note";
                            //            }
                            //            else
                            //            {
                            //                Inert_salesinvoices.inv_type = "Simplified Invoice";
                            //            }

                            //        }
                            //        else
                            //        {

                            //        }

                            //        //
                            //        string dateString = dataDs.INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                            //        {
                            //            // Inert_salesinvoices.issued_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                            //        }
                            //        else
                            //        {
                            //            //issued_date
                            //            // Inert_salesinvoices.issued_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                            //        //
                            //        Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                            //        //
                            //        //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                            //        //{
                            //        //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                            //        //}
                            //        //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                            //        Inert_salesinvoices.mode_ofpay = "CASH";
                            //        //
                            //        //gTotamnt_prepaid
                            //        Inert_salesinvoices.gTotamnt_prepaid = "0";
                            //        Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                            //        Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";// Math.Abs(value)
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                            //        if (dataDs.TOT_INV_PER_VAT == "N/A")
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = "0";
                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT.Replace("-", "") ?? "00";
                            //        }

                            //        Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE.Replace("-", "") ?? "00";
                            //        //? Inert_salesinvoices.Totamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                            //        Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING.Replace("-", "") ?? "00";
                            //        //Inert_salesinvoices.branch_id = "11";
                            //        //Inert_salesinvoices.branch_code = "JEDCO";
                            //        Inert_salesinvoices.branch_id = "12";// "11";
                            //        Inert_salesinvoices.branch_code = "JEDCOP";
                            //        //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                            //        Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00"; ;
                            //        Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                            //        Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                            //        Inert_salesinvoices.buy_typeId = "TIN";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                            //        Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                            //        Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                            //        //? Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                            //        //? Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.idx_ztcaupload = "0";
                            //        Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                            //        Inert_salesinvoices.no_lines = dataDs.G_2.Count().ToString();
                            //        int isdel = _InvoiceRepository.Delete_dublicate_vw_dr_salesinvoices_CASH(Inert_salesinvoices);
                            //        long getp = _InvoiceRepository.Insert_vw_dr_salesinvoices_CASH(Inert_salesinvoices);
                            //        if (getp > 0)
                            //        {
                            //            vw_dr_salesinvoices update = new vw_dr_salesinvoices();
                            //            update.rec_index = getp;
                            //            update.inv_index = getp;
                            //            var updte = _InvoiceRepository.Update_vw_dr_salesinvoices_CASH(update);
                            //            if (updte > 0)
                            //            {
                            //                #region lines
                            //                foreach (var lines in dataDs.G_2)
                            //                {
                            //                    vw_dr_saleinvoicesdetails lines_insert = new vw_dr_saleinvoicesdetails();

                            //                    lines_insert.inv_index = getp;
                            //                    lines_insert.rec_index = getp;
                            //                    lines_insert.item_description = lines.LINE_DESC ?? "00";
                            //                    lines_insert.item_qty = lines.QTY ?? "00";
                            //                    lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                            //                    lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                            //                    lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                            //                    lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                            //                    lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                            //                    //lines_insert.per_vat =  lines.VAT_RATE ;
                            //                    //if (lines.VAT_RATE == "N/A")
                            //                    //{
                            //                    //    lines_insert.per_vat = "0";
                            //                    //}
                            //                    //else
                            //                    //{
                            //                    //    if (lines.VAT_RATE.Contains("%"))
                            //                    //    {
                            //                    //        // Remove "%" from the string
                            //                    //      string  inputString = lines.VAT_RATE.Replace("%", "");
                            //                    //        double percentage = double.Parse(inputString);

                            //                    //        // Convert percentage to decimal
                            //                    //        double decimalValue = percentage / 100.0;

                            //                    //        lines_insert.per_vat = decimalValue.ToString();
                            //                    //    }
                            //                    //    else
                            //                    //    {
                            //                    //        lines_insert.per_vat = "0";
                            //                    //    }
                            //                    //   // lines_insert.per_vat = lines.VAT_RATE;
                            //                    //}
                            //                    if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                            //                    {
                            //                        lines_insert.per_vat = "0.15";
                            //                    }
                            //                    else
                            //                    {
                            //                        lines_insert.per_vat = "0";
                            //                    }
                            //                    lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                            //                    lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                            //                    lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                            //                    lines_insert.amnt_vat = lines.LINE_VAT_AMT.Replace("-", "") ?? "00";
                            //                    // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;Math. Abs(value)
                            //                    #region add
                            //                    //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                            //                    decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX.Replace("-", ""), out var results) ? results : 0m;
                            //                    decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT.Replace("-", ""), out var results2) ? results2 : 0m;
                            //                    decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                            //                    #endregion
                            //                    lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                            //                                                                           //taxInclAmount = (taxExclAmount + amnt_vat)
                            //                    lines_insert.inv_no = dataDs.INV_NO ?? "00";
                            //                    var insertlines = _InvoiceRepository.Insert_vw_dr_saleinvoicesdetails_CASH(lines_insert);
                            //                }
                            //                #endregion
                            //            }
                            //        }
                            //        #endregion
                            //        #endregion
                            //    }
                            //    else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                            //    {

                            //    }
                            //    else
                            //    {
                            //        #region Inert__vw_cashsalesinvoices
                            //        #region header

                            //        vw_salesinvoices Inert_salesinvoices = new vw_salesinvoices();
                            //        Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                            //        Inert_salesinvoices.ProcessZaca = "no";
                            //        Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                            //        Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                            //        if (true)
                            //        {
                            //            if (dataDs.INV_TYPE.Contains("Debit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Simplified Debit Note";
                            //            }
                            //            else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Simplified Credit Note";
                            //            }
                            //            else
                            //            {
                            //                Inert_salesinvoices.inv_type = "Simplified Invoice";
                            //            }

                            //        }
                            //        else
                            //        {

                            //        }

                            //        //
                            //        string dateString = dataDs.INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                            //        {
                            //            Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                            //        //
                            //        Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                            //        //
                            //        //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                            //        //{
                            //        //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                            //        //}
                            //        //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                            //        Inert_salesinvoices.mode_ofpay = "CASH";
                            //        //
                            //        Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                            //        Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                            //        Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT ?? "00";
                            //        if (dataDs.TOT_INV_PER_VAT == "N/A")
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = "0";
                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT ?? "00";
                            //        }

                            //        Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID ?? "00";
                            //        Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE ?? "00";
                            //        Inert_salesinvoices.gTotamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                            //        Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING ?? "00";
                            //        //Inert_salesinvoices.branch_id = 11;
                            //        //Inert_salesinvoices.branch_code = "JEDCO";
                            //        Inert_salesinvoices.branch_id = 12;// "11";
                            //        Inert_salesinvoices.branch_code = "JEDCOP";
                            //        //Inert_salesinvoices.buy_vatno= dataDs.G1.VAT_REG_NUM.ToString();
                            //        //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                            //        Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00"; ;
                            //        Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                            //        Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                            //        Inert_salesinvoices.buy_typeId = "NAT";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                            //        Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                            //        Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                            //        Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.idx_ztcaupload = 0;
                            //        Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                            //        Inert_salesinvoices.no_lines = dataDs.G_2.Count();
                            //        int isdel = _InvoiceRepository.Delete_dublicate_inv_no_vw_cashsalesinvoices(Inert_salesinvoices);
                            //        long getp = _InvoiceRepository.InsertSalesInvoice_vw_cashsalesinvoices(Inert_salesinvoices);
                            //        if (getp > 0)
                            //        {
                            //            vw_salesinvoices update = new vw_salesinvoices();
                            //            update.rec_index = getp;
                            //            update.inv_index = getp;
                            //            var updte = _InvoiceRepository.Update_vw_salesinvoicesr_vw_cashsalesinvoices(update);
                            //            if (updte > 0)
                            //            {
                            //                #region lines
                            //                foreach (var lines in dataDs.G_2)
                            //                {
                            //                    vw_saleinvoicesdetails lines_insert = new vw_saleinvoicesdetails();

                            //                    lines_insert.inv_index = getp;
                            //                    lines_insert.rec_index = getp;
                            //                    lines_insert.item_description = lines.LINE_DESC ?? "00";
                            //                    lines_insert.item_qty = lines.QTY ?? "00";
                            //                    lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                            //                    lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                            //                    lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX ?? "00";
                            //                    lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                            //                    lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX ?? "00";
                            //                    //lines_insert.per_vat =  lines.VAT_RATE ;
                            //                    //if (lines.VAT_RATE == "N/A")
                            //                    //{
                            //                    //    lines_insert.per_vat = "0";
                            //                    //}
                            //                    //else
                            //                    //{
                            //                    //    if (lines.VAT_RATE.Contains("%"))
                            //                    //    {
                            //                    //        // Remove "%" from the string
                            //                    //      string  inputString = lines.VAT_RATE.Replace("%", "");
                            //                    //        double percentage = double.Parse(inputString);

                            //                    //        // Convert percentage to decimal
                            //                    //        double decimalValue = percentage / 100.0;

                            //                    //        lines_insert.per_vat = decimalValue.ToString();
                            //                    //    }
                            //                    //    else
                            //                    //    {
                            //                    //        lines_insert.per_vat = "0";
                            //                    //    }
                            //                    //   // lines_insert.per_vat = lines.VAT_RATE;
                            //                    //}
                            //                    if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                            //                    {
                            //                        lines_insert.per_vat = "0.15";
                            //                    }
                            //                    else
                            //                    {
                            //                        lines_insert.per_vat = "0";
                            //                    }
                            //                    lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                            //                    lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                            //                    lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                            //                    lines_insert.amnt_vat = lines.LINE_VAT_AMT ?? "00";
                            //                    // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;
                            //                    #region add
                            //                    //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                            //                    decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX, out var results) ? results : 0m;
                            //                    decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT, out var results2) ? results2 : 0m;
                            //                    decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                            //                    #endregion
                            //                    lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                            //                                                                           //taxInclAmount = (taxExclAmount + amnt_vat)
                            //                    lines_insert.inv_no = dataDs.INV_NO ?? "00";
                            //                    var insertlines = _InvoiceRepository.InsertCASHInvoiceDetails(lines_insert);
                            //                }
                            //                #endregion
                            //            }
                            //        }
                            //        #endregion

                            //        #endregion
                            //    }
                            //    #endregion
                            //}
                            //else
                            //{
                            //    if (dataDs.INV_TYPE.Contains("Debit Memo"))
                            //    {
                            //        //Inert_salesinvoices.inv_type = "Standard Debit Note";
                            //        #region vw_cr_salesinvoices
                            //        #region header

                            //        vw_dr_salesinvoices Inert_salesinvoices = new vw_dr_salesinvoices();
                            //        Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                            //        Inert_salesinvoices.ProcessZaca = "no";
                            //        Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                            //        Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                            //        //
                            //        Inert_salesinvoices.refinv_no = dataDs.ORG_INV_NUMBER ?? "00";//"202300007";//ORG_INV_NUMBER 
                            //        //Inert_salesinvoices.InvRef_Date = "2023-12-10";//ORG_INV_DATE
                            //        Inert_salesinvoices.instruction_code = dataDs.CREDIT_REASON ?? "00";// "CANCELLATION_OR_TERMINATION";//CREDIT_REASON

                            //        string dateString1 = dataDs.ORG_INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format1 = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString1, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result1))
                            //        {
                            //            Inert_salesinvoices.InvRef_Date = result1.ToString("yyyy-MM-dd");//date


                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.InvRef_Date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //
                            //        if (true)
                            //        {
                            //            if (dataDs.INV_TYPE.Contains("Debit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Debit Note";
                            //            }
                            //            else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Credit Note";
                            //            }
                            //            else
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Invoice";
                            //            }

                            //        }
                            //        else
                            //        {

                            //        }

                            //        //
                            //        string dateString = dataDs.INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                            //        {
                            //            // Inert_salesinvoices.issued_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                            //        }
                            //        else
                            //        {
                            //            //issued_date
                            //            // Inert_salesinvoices.issued_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                            //        //
                            //        Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                            //        //
                            //        //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                            //        //{
                            //        //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                            //        //}
                            //        //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                            //        Inert_salesinvoices.mode_ofpay = "CASH";
                            //        //
                            //        //gTotamnt_prepaid
                            //        Inert_salesinvoices.gTotamnt_prepaid = "0";
                            //        Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                            //        Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";// Math.Abs(value)
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                            //        if (dataDs.TOT_INV_PER_VAT == "N/A")
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = "0";
                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT.Replace("-", "") ?? "00";
                            //        }

                            //        Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE.Replace("-", "") ?? "00";
                            //        //? Inert_salesinvoices.Totamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                            //        Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.branch_id = "12";// "11";
                            //        Inert_salesinvoices.branch_code = "JEDCOP";

                            //        //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                            //        Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00";
                            //        Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                            //        Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                            //        Inert_salesinvoices.buy_typeId = "TIN";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                            //        Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                            //        Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                            //        //? Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                            //        //? Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.idx_ztcaupload = "0";
                            //        Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                            //        Inert_salesinvoices.no_lines = dataDs.G_2.Count().ToString();
                            //        int isdel = _InvoiceRepository.Delete_dublicate_vw_dr_salesinvoices(Inert_salesinvoices);
                            //        long getp = _InvoiceRepository.Insert_vw_dr_salesinvoices(Inert_salesinvoices);
                            //        if (getp > 0)
                            //        {
                            //            vw_dr_salesinvoices update = new vw_dr_salesinvoices();
                            //            update.rec_index = getp;
                            //            update.inv_index = getp;
                            //            var updte = _InvoiceRepository.Update_vw_dr_salesinvoices(update);
                            //            if (updte > 0)
                            //            {
                            //                #region lines
                            //                foreach (var lines in dataDs.G_2)
                            //                {
                            //                    vw_dr_saleinvoicesdetails lines_insert = new vw_dr_saleinvoicesdetails();

                            //                    lines_insert.inv_index = getp;
                            //                    lines_insert.rec_index = getp;
                            //                    lines_insert.item_description = lines.LINE_DESC ?? "00";
                            //                    lines_insert.item_qty = lines.QTY ?? "00";
                            //                    lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                            //                    lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                            //                    lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                            //                    lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                            //                    lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                            //                    //lines_insert.per_vat =  lines.VAT_RATE ;
                            //                    //if (lines.VAT_RATE == "N/A")
                            //                    //{
                            //                    //    lines_insert.per_vat = "0";
                            //                    //}
                            //                    //else
                            //                    //{
                            //                    //    if (lines.VAT_RATE.Contains("%"))
                            //                    //    {
                            //                    //        // Remove "%" from the string
                            //                    //      string  inputString = lines.VAT_RATE.Replace("%", "");
                            //                    //        double percentage = double.Parse(inputString);

                            //                    //        // Convert percentage to decimal
                            //                    //        double decimalValue = percentage / 100.0;

                            //                    //        lines_insert.per_vat = decimalValue.ToString();
                            //                    //    }
                            //                    //    else
                            //                    //    {
                            //                    //        lines_insert.per_vat = "0";
                            //                    //    }
                            //                    //   // lines_insert.per_vat = lines.VAT_RATE;
                            //                    //}
                            //                    if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                            //                    {
                            //                        lines_insert.per_vat = "0.15";
                            //                    }
                            //                    else
                            //                    {
                            //                        lines_insert.per_vat = "0";
                            //                    }
                            //                    lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                            //                    lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                            //                    lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                            //                    lines_insert.amnt_vat = lines.LINE_VAT_AMT.Replace("-", "") ?? "00";
                            //                    // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;Math. Abs(value)
                            //                    #region add
                            //                    //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                            //                    decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX.Replace("-", ""), out var results) ? results : 0m;
                            //                    decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT.Replace("-", ""), out var results2) ? results2 : 0m;
                            //                    decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                            //                    #endregion
                            //                    lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                            //                                                                           //taxInclAmount = (taxExclAmount + amnt_vat)
                            //                    lines_insert.inv_no = dataDs.INV_NO ?? "00";
                            //                    var insertlines = _InvoiceRepository.Insert_vw_dr_saleinvoicesdetails(lines_insert);
                            //                }
                            //                #endregion
                            //            }
                            //        }
                            //        #endregion
                            //        #endregion

                            //    }
                            //    else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                            //    {
                            //        //Inert_salesinvoices.inv_type = "Standard Credit Note";
                            //        #region vw_cr_salesinvoices
                            //        #region header

                            //        vw_cr_salesinvoices Inert_salesinvoices = new vw_cr_salesinvoices();
                            //        Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                            //        Inert_salesinvoices.ProcessZaca = "no";
                            //        Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                            //        Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                            //        //
                            //        Inert_salesinvoices.invref_no = dataDs.ORG_INV_NUMBER ?? "00";//"202300007";//ORG_INV_NUMBER 
                            //        //Inert_salesinvoices.InvRef_Date = "2023-12-10";//ORG_INV_DATE
                            //        Inert_salesinvoices.instruction_code = dataDs.CREDIT_REASON ?? "00";// "CANCELLATION_OR_TERMINATION";//CREDIT_REASON

                            //        string dateString1 = dataDs.ORG_INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format1 = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString1, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result1))
                            //        {
                            //            Inert_salesinvoices.InvRef_Date = result1.ToString("yyyy-MM-dd");//date


                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.InvRef_Date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //
                            //        if (true)
                            //        {
                            //            if (dataDs.INV_TYPE.Contains("Debit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Debit Note";
                            //            }
                            //            else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Credit Note";
                            //            }
                            //            else
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Invoice";
                            //            }

                            //        }
                            //        else
                            //        {

                            //        }

                            //        //
                            //        string dateString = dataDs.INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                            //        {
                            //            Inert_salesinvoices.issued_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                            //        }
                            //        else
                            //        {
                            //            //issued_date
                            //            Inert_salesinvoices.issued_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                            //        //
                            //        Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                            //        //
                            //        //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                            //        //{
                            //        //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                            //        //}
                            //        //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                            //        Inert_salesinvoices.mode_ofpay = "CASH";
                            //        //
                            //        Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                            //        Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";// Math.Abs(value)
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                            //        if (dataDs.TOT_INV_PER_VAT == "N/A")
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = "0";
                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT.Replace("-", "") ?? "00";
                            //        }

                            //        Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE.Replace("-", "") ?? "00";
                            //        //? Inert_salesinvoices.Totamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                            //        Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING.Replace("-", "") ?? "00";
                            //        Inert_salesinvoices.branch_id = "12";//"11" ;
                            //        Inert_salesinvoices.branch_code = "JEDCOP";

                            //        //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                            //        Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00";
                            //        Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                            //        Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                            //        Inert_salesinvoices.buy_typeId = "NAT";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                            //        Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                            //        Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                            //        //? Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                            //        //? Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.idx_ztcaupload = "0";
                            //        Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                            //        Inert_salesinvoices.no_lines = dataDs.G_2.Count();
                            //        int isdel = _InvoiceRepository.Delete_dublicate_vw_cr_salesinvoices(Inert_salesinvoices);
                            //        long getp = _InvoiceRepository.Insert_vw_cr_salesinvoices(Inert_salesinvoices);
                            //        if (getp > 0)
                            //        {
                            //            vw_cr_salesinvoices update = new vw_cr_salesinvoices();
                            //            update.rec_index = getp;
                            //            update.inv_index = getp;
                            //            var updte = _InvoiceRepository.Update_vw_cr_salesinvoices(update);
                            //            if (updte > 0)
                            //            {
                            //                #region lines
                            //                foreach (var lines in dataDs.G_2)
                            //                {
                            //                    vw_cr_saleinvoicesdetails lines_insert = new vw_cr_saleinvoicesdetails();

                            //                    lines_insert.inv_index = getp;
                            //                    lines_insert.rec_index = getp;
                            //                    lines_insert.item_description = lines.LINE_DESC ?? "00";
                            //                    lines_insert.item_qty = lines.QTY ?? "00";
                            //                    lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                            //                    lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                            //                    lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                            //                    lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                            //                    lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                            //                    //lines_insert.per_vat =  lines.VAT_RATE ;
                            //                    //if (lines.VAT_RATE == "N/A")
                            //                    //{
                            //                    //    lines_insert.per_vat = "0";
                            //                    //}
                            //                    //else
                            //                    //{
                            //                    //    if (lines.VAT_RATE.Contains("%"))
                            //                    //    {
                            //                    //        // Remove "%" from the string
                            //                    //      string  inputString = lines.VAT_RATE.Replace("%", "");
                            //                    //        double percentage = double.Parse(inputString);

                            //                    //        // Convert percentage to decimal
                            //                    //        double decimalValue = percentage / 100.0;

                            //                    //        lines_insert.per_vat = decimalValue.ToString();
                            //                    //    }
                            //                    //    else
                            //                    //    {
                            //                    //        lines_insert.per_vat = "0";
                            //                    //    }
                            //                    //   // lines_insert.per_vat = lines.VAT_RATE;
                            //                    //}
                            //                    if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                            //                    {
                            //                        lines_insert.per_vat = "0.15";
                            //                    }
                            //                    else
                            //                    {
                            //                        lines_insert.per_vat = "0";
                            //                    }
                            //                    lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                            //                    lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                            //                    lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                            //                    lines_insert.amnt_vat = lines.LINE_VAT_AMT.Replace("-", "") ?? "00";
                            //                    // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;Math. Abs(value)
                            //                    #region add
                            //                    //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                            //                    decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX.Replace("-", ""), out var results) ? results : 0m;
                            //                    decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT.Replace("-", ""), out var results2) ? results2 : 0m;
                            //                    decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                            //                    #endregion
                            //                    lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                            //                                                                           //taxInclAmount = (taxExclAmount + amnt_vat)
                            //                    lines_insert.inv_no = dataDs.INV_NO ?? "00";
                            //                    var insertlines = _InvoiceRepository.Insert_vw_cr_saleinvoicesdetails(lines_insert);
                            //                }
                            //                #endregion
                            //            }
                            //        }
                            //        #endregion
                            //        #endregion
                            //    }
                            //    else
                            //    {
                            //        #region Inert_salesinvoicesion
                            //        #region header

                            //        vw_salesinvoices Inert_salesinvoices = new vw_salesinvoices();
                            //        Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                            //        Inert_salesinvoices.ProcessZaca = "no";
                            //        Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                            //        Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                            //        if (true)
                            //        {
                            //            if (dataDs.INV_TYPE.Contains("Debit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Debit Note";
                            //            }
                            //            else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Credit Note";
                            //            }
                            //            else
                            //            {
                            //                Inert_salesinvoices.inv_type = "Standard Invoice";
                            //            }

                            //        }
                            //        else
                            //        {

                            //        }

                            //        //
                            //        string dateString = dataDs.INV_DATE;

                            //        // Specify the exact format of the date string
                            //        string format = "dd-MM-yyyy";

                            //        // Try to parse the date string
                            //        // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            //        if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                            //        {
                            //            Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                            //            Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                            //            Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                            //        }
                            //        //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                            //        //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                            //        //
                            //        Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                            //        //
                            //        //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                            //        //{
                            //        //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                            //        //}
                            //        //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                            //        Inert_salesinvoices.mode_ofpay = "CASH";
                            //        //
                            //        Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                            //        Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                            //        Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                            //        Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT ?? "00";
                            //        if (dataDs.TOT_INV_PER_VAT == "N/A")
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = "0";
                            //        }
                            //        else
                            //        {
                            //            Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT ?? "00";
                            //        }

                            //        Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT ?? "00";
                            //        Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID ?? "00";
                            //        Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE ?? "00";
                            //        Inert_salesinvoices.gTotamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                            //        Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING ?? "00";
                            //        Inert_salesinvoices.branch_id = 12;//11;
                            //        Inert_salesinvoices.branch_code = "JEDCOP";
                            //        //Inert_salesinvoices.buy_vatno= dataDs.G1.VAT_REG_NUM.ToString();
                            //        //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                            //        Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00";
                            //        Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                            //        Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                            //        Inert_salesinvoices.buy_typeId = "NAT";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                            //        Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                            //        Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                            //        Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                            //        Inert_salesinvoices.idx_ztcaupload = 0;
                            //        Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                            //        Inert_salesinvoices.no_lines = dataDs.G_2.Count();
                            //        int isdel = _InvoiceRepository.Delete_dublicate_inv_no(Inert_salesinvoices);
                            //        long getp = _InvoiceRepository.InsertSalesInvoice(Inert_salesinvoices);
                            //        if (getp > 0)
                            //        {
                            //            vw_salesinvoices update = new vw_salesinvoices();
                            //            update.rec_index = getp;
                            //            update.inv_index = getp;
                            //            var updte = _InvoiceRepository.Update_vw_salesinvoicesr(update);
                            //            if (updte > 0)
                            //            {
                            //                #region lines
                            //                foreach (var lines in dataDs.G_2)
                            //                {
                            //                    vw_saleinvoicesdetails lines_insert = new vw_saleinvoicesdetails();

                            //                    lines_insert.inv_index = getp;
                            //                    lines_insert.rec_index = getp;
                            //                    lines_insert.item_description = lines.LINE_DESC ?? "00";
                            //                    lines_insert.item_qty = lines.QTY ?? "00";
                            //                    lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                            //                    lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                            //                    lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX ?? "00";
                            //                    lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                            //                    lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX ?? "00";
                            //                    //lines_insert.per_vat =  lines.VAT_RATE ;
                            //                    //if (lines.VAT_RATE == "N/A")
                            //                    //{
                            //                    //    lines_insert.per_vat = "0";
                            //                    //}
                            //                    //else
                            //                    //{
                            //                    //    if (lines.VAT_RATE.Contains("%"))
                            //                    //    {
                            //                    //        // Remove "%" from the string
                            //                    //      string  inputString = lines.VAT_RATE.Replace("%", "");
                            //                    //        double percentage = double.Parse(inputString);

                            //                    //        // Convert percentage to decimal
                            //                    //        double decimalValue = percentage / 100.0;

                            //                    //        lines_insert.per_vat = decimalValue.ToString();
                            //                    //    }
                            //                    //    else
                            //                    //    {
                            //                    //        lines_insert.per_vat = "0";
                            //                    //    }
                            //                    //   // lines_insert.per_vat = lines.VAT_RATE;
                            //                    //}
                            //                    if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                            //                    {
                            //                        lines_insert.per_vat = "0.15";
                            //                    }
                            //                    else
                            //                    {
                            //                        lines_insert.per_vat = "0";
                            //                    }
                            //                    lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                            //                    lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                            //                    lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                            //                    lines_insert.amnt_vat = lines.LINE_VAT_AMT ?? "00";
                            //                    // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;
                            //                    #region add
                            //                    //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                            //                    decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX, out var results) ? results : 0m;
                            //                    decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT, out var results2) ? results2 : 0m;
                            //                    decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                            //                    #endregion
                            //                    lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                            //                                                                           //taxInclAmount = (taxExclAmount + amnt_vat)
                            //                    lines_insert.inv_no = dataDs.INV_NO ?? "00";
                            //                    var insertlines = _InvoiceRepository.InsertSaleInvoiceDetails(lines_insert);
                            //                }
                            //                #endregion
                            //            }
                            //        }
                            //        #endregion

                            //        #endregion
                            //    }
                            //}
                            #endregion
                            #region new
                            if (dataDs.PARTY_ID == "27005" || dataDs.PARTY_ID == "20005")
                            {

                                #region cash
                                if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                {
                                    #region vw_cr_salesinvoices
                                    #region header

                                    vw_dr_salesinvoices Inert_salesinvoices = new vw_dr_salesinvoices();
                                    Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                                    Inert_salesinvoices.ProcessZaca = "no";
                                    Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                                    Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                                    //
                                    //TRX_SOURCE
                                    Inert_salesinvoices.TRX_SOURCE = dataDs.TRX_SOURCE ?? "00";
                                    //
                                    Inert_salesinvoices.refinv_no = dataDs.ORG_INV_NUMBER ?? "00";//"202300007";//ORG_INV_NUMBER 
                                    //Inert_salesinvoices.InvRef_Date = "2023-12-10";//ORG_INV_DATE
                                    Inert_salesinvoices.instruction_code = dataDs.CREDIT_REASON ?? "00";// "CANCELLATION_OR_TERMINATION";//CREDIT_REASON

                                    string dateString1 = dataDs.ORG_INV_DATE;

                                    // Specify the exact format of the date string
                                    string format1 = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString1, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result1))
                                    {
                                        Inert_salesinvoices.InvRef_Date = result1.ToString("yyyy-MM-dd");//date


                                    }
                                    else
                                    {
                                        Inert_salesinvoices.InvRef_Date = DateTime.Now.Date.ToString();//date
                                    }
                                    //
                                    if (true)
                                    {
                                        if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Debit Note";
                                        }
                                        else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Credit Note";
                                        }
                                        else
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Invoice";
                                        }

                                    }
                                    else
                                    {

                                    }

                                    //
                                    string dateString = dataDs.INV_DATE;

                                    // Specify the exact format of the date string
                                    string format = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                                    {
                                        // Inert_salesinvoices.issued_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                                    }
                                    else
                                    {
                                        //issued_date
                                        // Inert_salesinvoices.issued_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                                    }
                                    //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                                    //
                                    Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                                    //
                                    //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                                    //{
                                    //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                                    //}
                                    //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                                    Inert_salesinvoices.mode_ofpay = "CASH";
                                    //
                                    //gTotamnt_prepaid
                                    Inert_salesinvoices.gTotamnt_prepaid = "0";
                                    Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                                    Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";// Math.Abs(value)
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    if (dataDs.TOT_INV_PER_VAT == "N/A")
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = "0";
                                    }
                                    else
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT.Replace("-", "") ?? "00";
                                    }

                                    Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE.Replace("-", "") ?? "00";
                                    //? Inert_salesinvoices.Totamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.branch_id = "12";
                                    Inert_salesinvoices.branch_code = "JEDCOP";

                                    //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                                    Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00"; ;
                                    Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                                    Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                                    Inert_salesinvoices.buy_typeId = "TIN";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                                    Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                                    Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                                    //? Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                                    //? Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.idx_ztcaupload = "0";
                                    Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                                    Inert_salesinvoices.no_lines = dataDs.G_2.Count().ToString();
                                    int isdel = _InvoiceRepository.Delete_dublicate_vw_dr_salesinvoices_CASH(Inert_salesinvoices);
                                    long getp = _InvoiceRepository.Insert_vw_dr_salesinvoices_CASH(Inert_salesinvoices);
                                    if (getp > 0)
                                    {
                                        vw_dr_salesinvoices update = new vw_dr_salesinvoices();
                                        update.rec_index = getp;
                                        update.inv_index = getp;
                                        var updte = _InvoiceRepository.Update_vw_dr_salesinvoices_CASH(update);
                                        if (updte > 0)
                                        {
                                            #region lines
                                            foreach (var lines in dataDs.G_2)
                                            {
                                                vw_dr_saleinvoicesdetails lines_insert = new vw_dr_saleinvoicesdetails();

                                                lines_insert.inv_index = getp;
                                                lines_insert.rec_index = getp;
                                                lines_insert.item_description = lines.LINE_DESC ?? "00";
                                                lines_insert.item_qty = lines.QTY ?? "00";
                                                lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                                                lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                                                lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                                                lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                //lines_insert.per_vat =  lines.VAT_RATE ;
                                                //if (lines.VAT_RATE == "N/A")
                                                //{
                                                //    lines_insert.per_vat = "0";
                                                //}
                                                //else
                                                //{
                                                //    if (lines.VAT_RATE.Contains("%"))
                                                //    {
                                                //        // Remove "%" from the string
                                                //      string  inputString = lines.VAT_RATE.Replace("%", "");
                                                //        double percentage = double.Parse(inputString);

                                                //        // Convert percentage to decimal
                                                //        double decimalValue = percentage / 100.0;

                                                //        lines_insert.per_vat = decimalValue.ToString();
                                                //    }
                                                //    else
                                                //    {
                                                //        lines_insert.per_vat = "0";
                                                //    }
                                                //   // lines_insert.per_vat = lines.VAT_RATE;
                                                //}
                                                if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                                                {
                                                    lines_insert.per_vat = "0.15";
                                                }
                                                else
                                                {
                                                    lines_insert.per_vat = "0";
                                                }
                                                lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                                                lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                                                lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                                                lines_insert.amnt_vat = lines.LINE_VAT_AMT.Replace("-", "") ?? "00";
                                                // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;Math. Abs(value)
                                                #region add
                                                //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                                                decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX.Replace("-", ""), out var results) ? results : 0m;
                                                decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT.Replace("-", ""), out var results2) ? results2 : 0m;
                                                decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                                                #endregion
                                                lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                                                                                                       //taxInclAmount = (taxExclAmount + amnt_vat)
                                                lines_insert.inv_no = dataDs.INV_NO ?? "00";
                                                var insertlines = _InvoiceRepository.Insert_vw_dr_saleinvoicesdetails_CASH(lines_insert);
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                    #endregion
                                }
                                else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                {

                                    #region vw_cr_salesinvoices
                                    #region header

                                    vw_dr_salesinvoices Inert_salesinvoices = new vw_dr_salesinvoices();
                                    Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                                    Inert_salesinvoices.ProcessZaca = "no";
                                    Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                                    Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                                    //
                                    //TRX_SOURCE
                                    Inert_salesinvoices.TRX_SOURCE = dataDs.TRX_SOURCE ?? "00";
                                    //
                                    Inert_salesinvoices.refinv_no = dataDs.ORG_INV_NUMBER ?? "00";//"202300007";//ORG_INV_NUMBER 
                                    //Inert_salesinvoices.InvRef_Date = "2023-12-10";//ORG_INV_DATE
                                    Inert_salesinvoices.instruction_code = dataDs.CREDIT_REASON ?? "00";// "CANCELLATION_OR_TERMINATION";//CREDIT_REASON

                                    string dateString1 = dataDs.ORG_INV_DATE;

                                    // Specify the exact format of the date string
                                    string format1 = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString1, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result1))
                                    {
                                        Inert_salesinvoices.InvRef_Date = result1.ToString("yyyy-MM-dd");//date


                                    }
                                    else
                                    {
                                        Inert_salesinvoices.InvRef_Date = DateTime.Now.Date.ToString();//date
                                    }
                                    //
                                    if (true)
                                    {
                                        if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Debit Note";
                                        }
                                        else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Credit Note";
                                        }
                                        else
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Invoice";
                                        }

                                    }
                                    else
                                    {

                                    }

                                    //
                                    string dateString = dataDs.INV_DATE;

                                    // Specify the exact format of the date string
                                    string format = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                                    {
                                        // Inert_salesinvoices.issued_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                                    }
                                    else
                                    {
                                        //issued_date
                                        // Inert_salesinvoices.issued_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                                    }
                                    //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                                    //
                                    Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                                    //
                                    //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                                    //{
                                    //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                                    //}
                                    //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                                    Inert_salesinvoices.mode_ofpay = "CASH";
                                    //
                                    //gTotamnt_prepaid
                                    Inert_salesinvoices.gTotamnt_prepaid = "0";
                                    Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                                    Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";// Math.Abs(value)
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    if (dataDs.TOT_INV_PER_VAT == "N/A")
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = "0";
                                    }
                                    else
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT.Replace("-", "") ?? "00";
                                    }

                                    Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE.Replace("-", "") ?? "00";
                                    //? Inert_salesinvoices.Totamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.branch_id = "12";
                                    Inert_salesinvoices.branch_code = "JEDCOP";

                                    //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                                    Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00"; ;
                                    Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                                    Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                                    Inert_salesinvoices.buy_typeId = "TIN";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                                    Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                                    Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                                    //? Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                                    //? Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.idx_ztcaupload = "0";
                                    Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                                    Inert_salesinvoices.no_lines = dataDs.G_2.Count().ToString();
                                    int isdel = _InvoiceRepository.Delete_dublicate_vw_cr_salesinvoices_CASH(Inert_salesinvoices);
                                    long getp = _InvoiceRepository.Insert_vw_cr_salesinvoices_CASH(Inert_salesinvoices);
                                    if (getp > 0)
                                    {
                                        vw_dr_salesinvoices update = new vw_dr_salesinvoices();
                                        update.rec_index = getp;
                                        update.inv_index = getp;
                                        var updte = _InvoiceRepository.Update_vw_cr_salesinvoices_CASH(update);
                                        if (updte > 0)
                                        {
                                            #region lines
                                            foreach (var lines in dataDs.G_2)
                                            {
                                                vw_dr_saleinvoicesdetails lines_insert = new vw_dr_saleinvoicesdetails();

                                                lines_insert.inv_index = getp;
                                                lines_insert.rec_index = getp;
                                                lines_insert.item_description = lines.LINE_DESC ?? "00";
                                                lines_insert.item_qty = lines.QTY ?? "00";
                                                lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                                                lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                                                lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                                                lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                //lines_insert.per_vat =  lines.VAT_RATE ;
                                                //if (lines.VAT_RATE == "N/A")
                                                //{
                                                //    lines_insert.per_vat = "0";
                                                //}
                                                //else
                                                //{
                                                //    if (lines.VAT_RATE.Contains("%"))
                                                //    {
                                                //        // Remove "%" from the string
                                                //      string  inputString = lines.VAT_RATE.Replace("%", "");
                                                //        double percentage = double.Parse(inputString);

                                                //        // Convert percentage to decimal
                                                //        double decimalValue = percentage / 100.0;

                                                //        lines_insert.per_vat = decimalValue.ToString();
                                                //    }
                                                //    else
                                                //    {
                                                //        lines_insert.per_vat = "0";
                                                //    }
                                                //   // lines_insert.per_vat = lines.VAT_RATE;
                                                //}
                                                if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                                                {
                                                    lines_insert.per_vat = "0.15";
                                                }
                                                else
                                                {
                                                    lines_insert.per_vat = "0";
                                                }
                                                lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                                                lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                                                lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                                                lines_insert.amnt_vat = lines.LINE_VAT_AMT.Replace("-", "") ?? "00";
                                                // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;Math. Abs(value)
                                                #region add
                                                //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                                                decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX.Replace("-", ""), out var results) ? results : 0m;
                                                decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT.Replace("-", ""), out var results2) ? results2 : 0m;
                                                decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                                                #endregion
                                                lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                                                                                                       //taxInclAmount = (taxExclAmount + amnt_vat)
                                                lines_insert.inv_no = dataDs.INV_NO ?? "00";
                                                var insertlines = _InvoiceRepository.Insert_vw_cr_saleinvoicesdetails_CASH(lines_insert);
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                    #endregion
                                }
                                else
                                {
                                    #region Inert__vw_cashsalesinvoices
                                    #region header

                                    vw_salesinvoices Inert_salesinvoices = new vw_salesinvoices();
                                    Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                                    Inert_salesinvoices.ProcessZaca = "no";
                                    Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                                    Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                                    if (true)
                                    {
                                        if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Debit Note";
                                        }
                                        else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Credit Note";
                                        }
                                        else
                                        {
                                            Inert_salesinvoices.inv_type = "Simplified Invoice";
                                        }

                                    }
                                    else
                                    {

                                    }

                                    //
                                    string dateString = dataDs.INV_DATE;

                                    // Specify the exact format of the date string
                                    string format = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                                    {
                                        Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                                    }
                                    else
                                    {
                                        Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                                    }
                                    //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                                    //
                                    Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                                    //
                                    //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                                    //{
                                    //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                                    //}
                                    //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                                    Inert_salesinvoices.mode_ofpay = "CASH";
                                    //
                                    Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                                    Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                                    Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT ?? "00";
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT ?? "00";
                                    Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT ?? "00";
                                    if (dataDs.TOT_INV_PER_VAT == "N/A")
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = "0";
                                    }
                                    else
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT ?? "00";
                                    }

                                    Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT ?? "00";
                                    Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID ?? "00";
                                    Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.gTotamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING ?? "00";
                                    Inert_salesinvoices.branch_id = 12;
                                    Inert_salesinvoices.branch_code = "JEDCOP";
                                    //Inert_salesinvoices.buy_vatno= dataDs.G1.VAT_REG_NUM.ToString();
                                    //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                                    Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00"; ;
                                    Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                                    //Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                                    Inert_salesinvoices.buy_id = dataDs.CUST_ID_NUMBER ?? "00";
                                    //TRX_SOURCE
                                    Inert_salesinvoices.TRX_SOURCE = dataDs.TRX_SOURCE ?? "00";
                                    //

                                    Inert_salesinvoices.buy_typeId = "NAT";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                                    Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                                    Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                                    Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.idx_ztcaupload = 0;
                                    Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                                    Inert_salesinvoices.no_lines = dataDs.G_2.Count();
                                    int isdel = _InvoiceRepository.Delete_dublicate_inv_no_vw_cashsalesinvoices(Inert_salesinvoices);
                                    long getp = _InvoiceRepository.InsertSalesInvoice_vw_cashsalesinvoices(Inert_salesinvoices);
                                    if (getp > 0)
                                    {
                                        vw_salesinvoices update = new vw_salesinvoices();
                                        update.rec_index = getp;
                                        update.inv_index = getp;
                                        var updte = _InvoiceRepository.Update_vw_salesinvoicesr_vw_cashsalesinvoices(update);
                                        if (updte > 0)
                                        {
                                            #region lines
                                            foreach (var lines in dataDs.G_2)
                                            {
                                                vw_saleinvoicesdetails lines_insert = new vw_saleinvoicesdetails();

                                                lines_insert.inv_index = getp;
                                                lines_insert.rec_index = getp;
                                                lines_insert.item_description = lines.LINE_DESC ?? "00";
                                                lines_insert.item_qty = lines.QTY ?? "00";
                                                lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                                                lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                                                lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX ?? "00";
                                                lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                                                lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX ?? "00";
                                                //lines_insert.per_vat =  lines.VAT_RATE ;
                                                //if (lines.VAT_RATE == "N/A")
                                                //{
                                                //    lines_insert.per_vat = "0";
                                                //}
                                                //else
                                                //{
                                                //    if (lines.VAT_RATE.Contains("%"))
                                                //    {
                                                //        // Remove "%" from the string
                                                //      string  inputString = lines.VAT_RATE.Replace("%", "");
                                                //        double percentage = double.Parse(inputString);

                                                //        // Convert percentage to decimal
                                                //        double decimalValue = percentage / 100.0;

                                                //        lines_insert.per_vat = decimalValue.ToString();
                                                //    }
                                                //    else
                                                //    {
                                                //        lines_insert.per_vat = "0";
                                                //    }
                                                //   // lines_insert.per_vat = lines.VAT_RATE;
                                                //}
                                                if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                                                {
                                                    lines_insert.per_vat = "0.15";
                                                }
                                                else
                                                {
                                                    lines_insert.per_vat = "0";
                                                }
                                                lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                                                lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                                                lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                                                lines_insert.amnt_vat = lines.LINE_VAT_AMT ?? "00";
                                                // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;
                                                #region add
                                                //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                                                decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX, out var results) ? results : 0m;
                                                decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT, out var results2) ? results2 : 0m;
                                                decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                                                #endregion
                                                lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                                                                                                       //taxInclAmount = (taxExclAmount + amnt_vat)
                                                lines_insert.inv_no = dataDs.INV_NO ?? "00";
                                                var insertlines = _InvoiceRepository.InsertCASHInvoiceDetails(lines_insert);
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion

                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {

                                #region sale
                                if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                {
                                    //Inert_salesinvoices.inv_type = "Standard Debit Note";
                                    #region vw_cr_salesinvoices
                                    #region header

                                    vw_dr_salesinvoices Inert_salesinvoices = new vw_dr_salesinvoices();
                                    Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                                    Inert_salesinvoices.ProcessZaca = "no";
                                    Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                                    Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                                    //
                                    //TRX_SOURCE
                                    Inert_salesinvoices.TRX_SOURCE = dataDs.TRX_SOURCE ?? "00";
                                    //
                                    Inert_salesinvoices.refinv_no = dataDs.ORG_INV_NUMBER ?? "00";//"202300007";//ORG_INV_NUMBER 
                                    //Inert_salesinvoices.InvRef_Date = "2023-12-10";//ORG_INV_DATE
                                    Inert_salesinvoices.instruction_code = dataDs.CREDIT_REASON ?? "00";// "CANCELLATION_OR_TERMINATION";//CREDIT_REASON

                                    string dateString1 = dataDs.ORG_INV_DATE;

                                    // Specify the exact format of the date string
                                    string format1 = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString1, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result1))
                                    {
                                        Inert_salesinvoices.InvRef_Date = result1.ToString("yyyy-MM-dd");//date


                                    }
                                    else
                                    {
                                        Inert_salesinvoices.InvRef_Date = DateTime.Now.Date.ToString();//date
                                    }
                                    //
                                    if (true)
                                    {
                                        if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Debit Note";
                                        }
                                        else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Credit Note";
                                        }
                                        else
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Invoice";
                                        }

                                    }
                                    else
                                    {

                                    }

                                    //
                                    string dateString = dataDs.INV_DATE;

                                    // Specify the exact format of the date string
                                    string format = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                                    {
                                        // Inert_salesinvoices.issued_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                                    }
                                    else
                                    {
                                        //issued_date
                                        // Inert_salesinvoices.issued_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                                    }
                                    //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                                    //
                                    Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                                    //
                                    //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                                    //{
                                    //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                                    //}
                                    //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                                    Inert_salesinvoices.mode_ofpay = "CASH";
                                    //
                                    //gTotamnt_prepaid
                                    Inert_salesinvoices.gTotamnt_prepaid = "0";
                                    Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                                    Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";// Math.Abs(value)
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    if (dataDs.TOT_INV_PER_VAT == "N/A")
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = "0";
                                    }
                                    else
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT.Replace("-", "") ?? "00";
                                    }

                                    Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE.Replace("-", "") ?? "00";
                                    //? Inert_salesinvoices.Totamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.branch_id = "12";
                                    Inert_salesinvoices.branch_code = "JEDCOP";

                                    //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                                    Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00"; ;
                                    Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                                    Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                                    Inert_salesinvoices.buy_typeId = "TIN";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                                    Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                                    Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                                    //? Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                                    //? Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.idx_ztcaupload = "0";
                                    Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                                    Inert_salesinvoices.no_lines = dataDs.G_2.Count().ToString();
                                    int isdel = _InvoiceRepository.Delete_dublicate_vw_dr_salesinvoices(Inert_salesinvoices);
                                    long getp = _InvoiceRepository.Insert_vw_dr_salesinvoices(Inert_salesinvoices);
                                    if (getp > 0)
                                    {
                                        vw_dr_salesinvoices update = new vw_dr_salesinvoices();
                                        update.rec_index = getp;
                                        update.inv_index = getp;
                                        var updte = _InvoiceRepository.Update_vw_dr_salesinvoices(update);
                                        if (updte > 0)
                                        {
                                            #region lines
                                            foreach (var lines in dataDs.G_2)
                                            {
                                                vw_dr_saleinvoicesdetails lines_insert = new vw_dr_saleinvoicesdetails();

                                                lines_insert.inv_index = getp;
                                                lines_insert.rec_index = getp;
                                                lines_insert.item_description = lines.LINE_DESC ?? "00";
                                                lines_insert.item_qty = lines.QTY ?? "00";
                                                lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                                                lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                                                lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                                                lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                //lines_insert.per_vat =  lines.VAT_RATE ;
                                                //if (lines.VAT_RATE == "N/A")
                                                //{
                                                //    lines_insert.per_vat = "0";
                                                //}
                                                //else
                                                //{
                                                //    if (lines.VAT_RATE.Contains("%"))
                                                //    {
                                                //        // Remove "%" from the string
                                                //      string  inputString = lines.VAT_RATE.Replace("%", "");
                                                //        double percentage = double.Parse(inputString);

                                                //        // Convert percentage to decimal
                                                //        double decimalValue = percentage / 100.0;

                                                //        lines_insert.per_vat = decimalValue.ToString();
                                                //    }
                                                //    else
                                                //    {
                                                //        lines_insert.per_vat = "0";
                                                //    }
                                                //   // lines_insert.per_vat = lines.VAT_RATE;
                                                //}
                                                if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                                                {
                                                    lines_insert.per_vat = "0.15";
                                                }
                                                else
                                                {
                                                    lines_insert.per_vat = "0";
                                                }
                                                lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                                                lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                                                lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                                                lines_insert.amnt_vat = lines.LINE_VAT_AMT.Replace("-", "") ?? "00";
                                                // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;Math. Abs(value)
                                                #region add
                                                //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                                                decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX.Replace("-", ""), out var results) ? results : 0m;
                                                decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT.Replace("-", ""), out var results2) ? results2 : 0m;
                                                decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                                                #endregion
                                                lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                                                                                                       //taxInclAmount = (taxExclAmount + amnt_vat)
                                                lines_insert.inv_no = dataDs.INV_NO ?? "00";
                                                var insertlines = _InvoiceRepository.Insert_vw_dr_saleinvoicesdetails(lines_insert);
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                    #endregion

                                }
                                else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                {
                                    //Inert_salesinvoices.inv_type = "Standard Credit Note";
                                    #region vw_cr_salesinvoices
                                    #region header

                                    vw_cr_salesinvoices Inert_salesinvoices = new vw_cr_salesinvoices();
                                    Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                                    Inert_salesinvoices.ProcessZaca = "no";
                                    Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                                    Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                                    //
                                    //TRX_SOURCE
                                    Inert_salesinvoices.TRX_SOURCE = dataDs.TRX_SOURCE ?? "00";
                                    //
                                    Inert_salesinvoices.invref_no = dataDs.ORG_INV_NUMBER ?? "00";//"202300007";//ORG_INV_NUMBER 
                                    //Inert_salesinvoices.InvRef_Date = "2023-12-10";//ORG_INV_DATE
                                    Inert_salesinvoices.instruction_code = dataDs.CREDIT_REASON ?? "00";// "CANCELLATION_OR_TERMINATION";//CREDIT_REASON

                                    string dateString1 = dataDs.ORG_INV_DATE;

                                    // Specify the exact format of the date string
                                    string format1 = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString1, format1, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result1))
                                    {
                                        Inert_salesinvoices.InvRef_Date = result1.ToString("yyyy-MM-dd");//date


                                    }
                                    else
                                    {
                                        Inert_salesinvoices.InvRef_Date = DateTime.Now.Date.ToString();//date
                                    }
                                    //
                                    if (true)
                                    {
                                        if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Debit Note";
                                        }
                                        else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Credit Note";
                                        }
                                        else
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Invoice";
                                        }

                                    }
                                    else
                                    {

                                    }

                                    //
                                    string dateString = dataDs.INV_DATE;

                                    // Specify the exact format of the date string
                                    string format = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                                    {
                                        Inert_salesinvoices.issued_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                                    }
                                    else
                                    {
                                        //issued_date
                                        Inert_salesinvoices.issued_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                                    }
                                    //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                                    //
                                    Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                                    //
                                    //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                                    //{
                                    //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                                    //}
                                    //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                                    Inert_salesinvoices.mode_ofpay = "CASH";
                                    //
                                    Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                                    Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";// Math.Abs(value)
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    if (dataDs.TOT_INV_PER_VAT == "N/A")
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = "0";
                                    }
                                    else
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT.Replace("-", "") ?? "00";
                                    }

                                    Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE.Replace("-", "") ?? "00";
                                    //? Inert_salesinvoices.Totamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING.Replace("-", "") ?? "00";
                                    Inert_salesinvoices.branch_id = "12";
                                    Inert_salesinvoices.branch_code = "JEDCOP";

                                    // Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                                    Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM.ToString();
                                    Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                                    Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                                    Inert_salesinvoices.buy_typeId = "NAT";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                                    Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                                    Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                                    //? Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                                    //? Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.idx_ztcaupload = "0";
                                    Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                                    Inert_salesinvoices.no_lines = dataDs.G_2.Count();
                                    int isdel = _InvoiceRepository.Delete_dublicate_vw_cr_salesinvoices(Inert_salesinvoices);
                                    long getp = _InvoiceRepository.Insert_vw_cr_salesinvoices(Inert_salesinvoices);
                                    if (getp > 0)
                                    {
                                        vw_cr_salesinvoices update = new vw_cr_salesinvoices();
                                        update.rec_index = getp;
                                        update.inv_index = getp;
                                        var updte = _InvoiceRepository.Update_vw_cr_salesinvoices(update);
                                        if (updte > 0)
                                        {
                                            #region lines
                                            foreach (var lines in dataDs.G_2)
                                            {
                                                vw_cr_saleinvoicesdetails lines_insert = new vw_cr_saleinvoicesdetails();

                                                lines_insert.inv_index = getp;
                                                lines_insert.rec_index = getp;
                                                lines_insert.item_description = lines.LINE_DESC ?? "00";
                                                lines_insert.item_qty = lines.QTY ?? "00";
                                                lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                                                lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                                                lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                                                lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX.Replace("-", "") ?? "00";
                                                //lines_insert.per_vat =  lines.VAT_RATE ;
                                                //if (lines.VAT_RATE == "N/A")
                                                //{
                                                //    lines_insert.per_vat = "0";
                                                //}
                                                //else
                                                //{
                                                //    if (lines.VAT_RATE.Contains("%"))
                                                //    {
                                                //        // Remove "%" from the string
                                                //      string  inputString = lines.VAT_RATE.Replace("%", "");
                                                //        double percentage = double.Parse(inputString);

                                                //        // Convert percentage to decimal
                                                //        double decimalValue = percentage / 100.0;

                                                //        lines_insert.per_vat = decimalValue.ToString();
                                                //    }
                                                //    else
                                                //    {
                                                //        lines_insert.per_vat = "0";
                                                //    }
                                                //   // lines_insert.per_vat = lines.VAT_RATE;
                                                //}
                                                if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                                                {
                                                    lines_insert.per_vat = "0.15";
                                                }
                                                else
                                                {
                                                    lines_insert.per_vat = "0";
                                                }
                                                lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                                                lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                                                lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                                                lines_insert.amnt_vat = lines.LINE_VAT_AMT.Replace("-", "") ?? "00";
                                                // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;Math. Abs(value)
                                                #region add
                                                //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                                                decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX.Replace("-", ""), out var results) ? results : 0m;
                                                decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT.Replace("-", ""), out var results2) ? results2 : 0m;
                                                decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                                                #endregion
                                                lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                                                                                                       //taxInclAmount = (taxExclAmount + amnt_vat)
                                                lines_insert.inv_no = dataDs.INV_NO ?? "00";
                                                var insertlines = _InvoiceRepository.Insert_vw_cr_saleinvoicesdetails(lines_insert);
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion
                                    #endregion
                                }
                                else
                                {
                                    #region Inert_salesinvoicesion
                                    #region header

                                    vw_salesinvoices Inert_salesinvoices = new vw_salesinvoices();
                                    Inert_salesinvoices.RewBase64ID = item.Id.ToString();
                                    Inert_salesinvoices.ProcessZaca = "no";
                                    Inert_salesinvoices.inv_no = dataDs.INV_NO ?? "00";
                                    //TRX_SOURCE
                                    Inert_salesinvoices.TRX_SOURCE = dataDs.TRX_SOURCE ?? "00";
                                    //
                                    Inert_salesinvoices.CUSTOMER_TRX_ID = dataDs.CUSTOMER_TRX_ID ?? "00";
                                    if (true)
                                    {
                                        if (dataDs.INV_TYPE.Contains("Debit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Debit Note";
                                        }
                                        else if (dataDs.INV_TYPE.Contains("Credit Memo"))
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Credit Note";
                                        }
                                        else
                                        {
                                            Inert_salesinvoices.inv_type = "Standard Invoice";
                                        }

                                    }
                                    else
                                    {

                                    }

                                    //
                                    string dateString = dataDs.INV_DATE;

                                    // Specify the exact format of the date string
                                    string format = "dd-MM-yyyy";

                                    // Try to parse the date string
                                    // if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                                    {
                                        Inert_salesinvoices.inv_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.deli_date = result.ToString("yyyy-MM-dd");//date
                                        Inert_salesinvoices.actdeli_date = result.ToString("yyyy-MM-dd");//date

                                    }
                                    else
                                    {
                                        Inert_salesinvoices.inv_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.deli_date = DateTime.Now.Date.ToString();//date
                                        Inert_salesinvoices.actdeli_date = DateTime.Now.Date.ToString();//date
                                    }
                                    //Inert_salesinvoices.inv_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.deli_date = dataDs.INV_DATE;//date
                                    //Inert_salesinvoices.actdeli_date = dataDs.INV_DATE;//date

                                    //
                                    Inert_salesinvoices.inv_time = dataDs.INV_TIME ?? "00";
                                    //
                                    //if (dataDs.MD_PAY.Contains("Bank Trasnfer"))
                                    //{
                                    //    Inert_salesinvoices.mode_ofpay = "PAYMENT TO BANK ACCOUNT";
                                    //}
                                    //Inert_salesinvoices.mode_ofpay = dataDs.MD_PAY;
                                    Inert_salesinvoices.mode_ofpay = "CASH";
                                    //
                                    Inert_salesinvoices.cur_code = dataDs.CURR_CODE ?? "00";
                                    Inert_salesinvoices.Totamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.Totamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.buy_name = dataDs.CUST_NAME ?? "00";
                                    Inert_salesinvoices.gTot_LineExtAmount = dataDs.BF_VAT ?? "00";
                                    Inert_salesinvoices.gTotamnt_disc = dataDs.TOTAL_DISCOUNT ?? "00";
                                    Inert_salesinvoices.gTotamnt_allow = dataDs.TOTAL_ALLOWANCE ?? "00";
                                    Inert_salesinvoices.gTot_TaxExclAmount = dataDs.BF_VAT ?? "00";
                                    Inert_salesinvoices.gTotamnt_vatExch = dataDs.TOTAL_VAT ?? "00";
                                    if (dataDs.TOT_INV_PER_VAT == "N/A")
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = "0";
                                    }
                                    else
                                    {
                                        Inert_salesinvoices.gTotinvper_vat = dataDs.TOT_INV_PER_VAT ?? "00";
                                    }

                                    Inert_salesinvoices.gTotamnt_vat = dataDs.TOTAL_VAT ?? "00";
                                    Inert_salesinvoices.gTotamnt_prepaid = dataDs.TOT_AMNT_PREPAID ?? "00";
                                    Inert_salesinvoices.gTot_TaxInclAmount = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.gTotamnt_payable = dataDs.TOTAL_PAYABLE ?? "00";
                                    Inert_salesinvoices.proc_pending = dataDs.PROC_PENDING ?? "00";
                                    Inert_salesinvoices.branch_id = 12;
                                    Inert_salesinvoices.branch_code = "JEDCOP";
                                    //Inert_salesinvoices.buy_vatno= dataDs.G1.VAT_REG_NUM.ToString();
                                    //Inert_salesinvoices.buy_vatno = dataDs.PARTY_ID.ToString();
                                    Inert_salesinvoices.buy_vatno = dataDs.VAT_REG_NUM ?? "00";
                                    Inert_salesinvoices.buy_countrycode = dataDs.COUNTRY ?? "00";
                                    Inert_salesinvoices.buy_id = dataDs.PARTY_ID ?? "00";
                                    Inert_salesinvoices.buy_typeId = "NAT";//Inert_salesinvoices.buy_typeId = dataDs.PARTY_TYPE;
                                    Inert_salesinvoices.buy_cityname = dataDs.CITY ?? "00";
                                    Inert_salesinvoices.buy_streetname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildingname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_buildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_plotid = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_adbuildno = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_postalzone = dataDs.POSTAL_CODE ?? "00";
                                    Inert_salesinvoices.buy_subcitysubname = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.buy_countrySubentity = dataDs.ADDRESS ?? "00";
                                    Inert_salesinvoices.idx_ztcaupload = 0;
                                    Inert_salesinvoices.Eamil = dataDs.EMAIL_ADDRESS ?? "00";
                                    Inert_salesinvoices.no_lines = dataDs.G_2.Count();
                                    int isdel = _InvoiceRepository.Delete_dublicate_inv_no(Inert_salesinvoices);
                                    long getp = _InvoiceRepository.InsertSalesInvoice(Inert_salesinvoices);
                                    if (getp > 0)
                                    {
                                        vw_salesinvoices update = new vw_salesinvoices();
                                        update.rec_index = getp;
                                        update.inv_index = getp;
                                        var updte = _InvoiceRepository.Update_vw_salesinvoicesr(update);
                                        if (updte > 0)
                                        {
                                            #region lines
                                            foreach (var lines in dataDs.G_2)
                                            {
                                                vw_saleinvoicesdetails lines_insert = new vw_saleinvoicesdetails();

                                                lines_insert.inv_index = getp;
                                                lines_insert.rec_index = getp;
                                                lines_insert.item_description = lines.LINE_DESC ?? "00";
                                                lines_insert.item_qty = lines.QTY ?? "00";
                                                lines_insert.item_unit = "Each";//lines_insert.item_unit = lines.ITEM_UNIT;
                                                lines_insert.item_price = lines.ITEM_PRICE.Replace("-", "") ?? "00";
                                                lines_insert.lineExtAmount = lines.TOT_WITHOUT_TAX ?? "00";
                                                lines_insert.amnt_disc = lines.LINE_AMNT_DISC ?? "00";
                                                lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX ?? "00";
                                                //lines_insert.per_vat =  lines.VAT_RATE ;
                                                //if (lines.VAT_RATE == "N/A")
                                                //{
                                                //    lines_insert.per_vat = "0";
                                                //}
                                                //else
                                                //{
                                                //    if (lines.VAT_RATE.Contains("%"))
                                                //    {
                                                //        // Remove "%" from the string
                                                //      string  inputString = lines.VAT_RATE.Replace("%", "");
                                                //        double percentage = double.Parse(inputString);

                                                //        // Convert percentage to decimal
                                                //        double decimalValue = percentage / 100.0;

                                                //        lines_insert.per_vat = decimalValue.ToString();
                                                //    }
                                                //    else
                                                //    {
                                                //        lines_insert.per_vat = "0";
                                                //    }
                                                //   // lines_insert.per_vat = lines.VAT_RATE;
                                                //}
                                                if (lines.AMOUNT_INCLUDES_TAX_FLAG == "S")
                                                {
                                                    lines_insert.per_vat = "0.15";
                                                }
                                                else
                                                {
                                                    lines_insert.per_vat = "0";
                                                }
                                                lines_insert.tax_code = lines.AMOUNT_INCLUDES_TAX_FLAG ?? "00";
                                                lines_insert.tax_exceptcode = lines.TAX_EXCEPTCODE ?? "00";
                                                lines_insert.except_reason = lines.EXCEPT_REASON ?? "00";
                                                lines_insert.amnt_vat = lines.LINE_VAT_AMT ?? "00";
                                                // lines_insert.taxInclAmount = lines.TOTAL_LINE_AMOUNT;
                                                #region add
                                                //decimal taxExclAmount_ = decimal.Parse(lines.TOT_WITHOUT_TAX);
                                                decimal taxExclAmount_ = decimal.TryParse(lines?.TOT_WITHOUT_TAX, out var results) ? results : 0m;
                                                decimal amnt_vat_ = decimal.TryParse(lines?.LINE_VAT_AMT, out var results2) ? results2 : 0m;
                                                decimal taxInclAmount_ = taxExclAmount_ + amnt_vat_;
                                                #endregion
                                                lines_insert.taxInclAmount = taxInclAmount_.ToString();//lines_insert.taxExclAmount = lines.TOT_WITHOUT_TAX;
                                                                                                       //taxInclAmount = (taxExclAmount + amnt_vat)
                                                lines_insert.inv_no = dataDs.INV_NO ?? "00";
                                                var insertlines = _InvoiceRepository.InsertSaleInvoiceDetails(lines_insert);
                                            }
                                            #endregion
                                        }
                                    }
                                    #endregion

                                    #endregion
                                }
                                #endregion
                            }
                            #endregion



                        }
                        //update status
                        InvoiceFromAPI_oracel _InvoiceFromAPI_oracel = new InvoiceFromAPI_oracel();
                        _InvoiceFromAPI_oracel.Status = "1";
                        _InvoiceFromAPI_oracel.Id = item.Id;
                        _InvoiceFromAPI_oracel.NoOfLine = invoice.G_1.Count().ToString();
                        var ints = _InvoiceRepository.Update_InvoiceFromAPI_oracel(_InvoiceFromAPI_oracel);
                    }

                #endregion
              
                     
            }

                _return = "yes";

                #endregion
                #endregion
                return _return;
            }
            catch (Exception ex)
            {
                _return = "no";
                Console.WriteLine($"setep2 InsertionInInvice Exception: {ex}");
                throw;
            }
        }
        static string DecodeBase64(string base64Data)
        {
            byte[] data = Convert.FromBase64String(base64Data);
            return Encoding.UTF8.GetString(data);
        }
        static Dictionary<string, string> ParseCsv(string csvData)
        {
            try
            {
                var dataDict = new Dictionary<string, string>();

                // Split CSV lines by both \r\n and \n
                string[] lines = csvData.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // Extract headers
                string[] headers = lines[0].Split(',');

                // Extract values from each line
                 foreach (var line in lines.Skip(1))
                //foreach (var line in lines)
                {
                    string[] values = ParseCsvLine(line);

                    // Combine headers and values into key-value pairs
                    var keyValuePairs = headers.Zip(values, (h, v) => new KeyValuePair<string, string>(h, v));

                    // Add key-value pairs to the dictionary
                    foreach (var kvp in keyValuePairs)
                    {
                        dataDict[kvp.Key] = kvp.Value;
                    }
                }

                return dataDict;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately
                throw;
            }
        }

        static string[] ParseCsvLine(string line)
        {
            // Split the line into values while handling quotes
            return line.Split(',').Select(value => value.Trim('"')).ToArray();
        }
        #region XML base 64 converter
        static string DecodeBase64String(string base64String)
        {
            byte[] data = Convert.FromBase64String(base64String);
            return Encoding.UTF8.GetString(data);
        }
        #endregion
        #region write file
        public void WriteToFile(string Message, string prefix)
        {
            try
            {
                string path = "C:\\FsuionLogsProduction";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filepath = path + "\\" + prefix + "_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                //string filepath = path + "\\" +"test.txt";
                //Console.WriteLine("Filepath: " + filepath);

                if (!File.Exists(filepath))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        #endregion
    }

}
public class CustomMessageInspector : IClientMessageInspector
{
    private readonly string username;
    private readonly string password;

    public CustomMessageInspector(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public void AfterReceiveReply(ref Message reply, object correlationState)
    {
        // No action needed in this case
    }

    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        var httpRequestProperty = new HttpRequestMessageProperty();
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
        httpRequestProperty.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;

        request.Properties[HttpRequestMessageProperty.Name] = httpRequestProperty;
        return null;
    }
}

public class CustomMessageInspectorBehavior : IEndpointBehavior
{
    private readonly string username;
    private readonly string password;

    public CustomMessageInspectorBehavior(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
        clientRuntime.ClientMessageInspectors.Add(new CustomMessageInspector(username, password));
    }

    // Other IEndpointBehavior methods (not needed for this scenario)
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }
    public void Validate(ServiceEndpoint endpoint) { }
}