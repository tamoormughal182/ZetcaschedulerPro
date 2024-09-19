using QRCoder;
using scheduler.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace scheduler
{ 
    class Program
    {
        //static void Main(string[] args)
        static async Task Main(string[] args)
        {
            Chilkat.Global glob = new Chilkat.Global(); 
           // bool success = glob.UnlockBundle("wJIkj3.CBX1128_vdRDVuAfDiE8");
           // bool success = glob.UnlockBundle("Anything for 30-day trial");
            bool success = glob.UnlockBundle("VEEUZ2.CBX082024_PLO7UGYKoDnA");
            if (success != true)
            {
                Console.WriteLine(glob.LastErrorText);
                //cons(glob.LastErrorText, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                #region MyRegion
                try
                {
                    //var psi = new ProcessStartInfo("iexplore.exe");
                    //psi.Arguments = "http://www.google.com/";
                    //Process.Start(psi);
                }
                catch (Exception ex)
                {

                    throw;
                }
                #endregion
                #region mail sch


                while (true)
                {
                    // Call your function here
                    #region Main Logic
                    //
                    DateTime currentDateTime = DateTime.Now;

                    // Subtract 10 minutes
                    DateTime p_from_date_ = currentDateTime.AddMinutes(-10);

                    DateTime p_to_date_ = DateTime.Now;
                    InvoiceRepository _getInvoice = new InvoiceRepository();
                    _getInvoice.del_from_tblprocessPIH();
                    // Format the date and time as "MM/dd/yyyy HH:mm:ss"
                    string p_from_date = p_from_date_.ToString("MM/dd/yyyy HH:mm:ss");
                    string p_to_date = p_to_date_.ToString("MM/dd/yyyy HH:mm:ss");
                    Console.WriteLine($"p_from_date: {p_from_date}");
                    Console.WriteLine($"p_to_date: {p_to_date}");
                    XML_api_call callAPI = new XML_api_call();
                    //
                   
                    //
                    //1st call api
                    Console.WriteLine($"step 1 start");
                    var returns = await callAPI.callAPIAsync(p_from_date, p_to_date);

                    if (returns == "yes")
                    {
                        Console.WriteLine($"step 1 complete");
                        Console.WriteLine($"step 2 start");

                        // 2nd step base64 to invoice insertion
                      
                        var insertion_raw_into_mainInvoice = callAPI.InsertionInInvice();
                        if (insertion_raw_into_mainInvoice == "yes")
                        {
                            Console.WriteLine($"step 2 complete");
                            Console.WriteLine($"step 3 start");
                            //step 3 main call to zaca
                            //get invoce
                            
                            _getInvoice.del_from_tblprocessPIH();
                            //
                          
                            #region stander inv
                            var getinvoce = _getInvoice.GetAllvw_salesinvoices();
                            //  var getinvoce = _getInvoice.GetAll_vw_cr_salesinvoices();
                            Console.WriteLine($"Total standard inv from api: {getinvoce.Count()}");
                            foreach (var item in getinvoce)
                            {
                                #region Pass zaca
                                xml x = new xml();

                                string brCode = item.branch_code;//string brCode = "00001";
                                string Invoice_No = item.inv_no;// string Invoice_No = "STDIN00003";//202300006
                                                                //  string Invoice_No = "202300006";//
                                string Inv_type = item.inv_type; //string Inv_type = "Standard Invoice";
                                string row = item.no_lines.ToString();// string row = "2";
                                // RetrieveBranchInfo
                                ClassMain Clm = new ClassMain();
                                Clm.varcur_code = "SAR";
                                Clm.varpay_code = "10";
                                Clm.varpay_inst = "CASH";
                                Clm.varcnt_items = row;
                                Clm.varbrCode = brCode;
                                Clm.varInvoice_No = Invoice_No;
                                Clm.varInv_type = Inv_type;
                                // Clm.varinv_index = "4";
                                Clm.varinv_index = item.inv_index.ToString();//Clm.varinv_index = "12";
                                //ClassMain.VarSta_inv_date = "2023-11-04";//2023-10-12
                                //ClassMain.VarSta_inv_date = item.inv_date;// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                //
                                string inputDateString = item.inv_date;

                                if (DateTime.TryParseExact(inputDateString, "MM/dd/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                {
                                    ClassMain.VarSta_inv_date = parsedDateTime.ToString("yyyy-MM-dd");// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                    string formattedDateString = parsedDateTime.ToString("yyyy-MM-dd");
                                    //Console.WriteLine("Formatted Date: " + formattedDateString);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format.");
                                }
                                //
                                ClassMain.VarSta_inv_time = item.branch_code;//ClassMain.VarSta_inv_time = "00001";
                                //ClassMain.VarSta_inv_no = "STDIN00003";
                                ClassMain.VarSta_inv_no = Invoice_No;
                                Clm.RetrieveBranchInfo(brCode);
                                //mDisplayBuyersInfo
                                // string brCode = wFrmInvoices.SetBr_Code;


                                ClassMain Clm2 = new ClassMain();
                                Clm.RetrieveBuyersInfo(Inv_type, brCode, Invoice_No);
                                //RetrieveXMLDetails
                                // string brCode = wFrmInvoices.SetBr_Code;
                                //string Invoice_No = wFrmInvoices.SetInvoice_No;
                                //string Inv_type = wFrmInvoices.SetInv_type;

                                ClassMain Clm3 = new ClassMain();
                                Clm.RetrieveXMLDetails(Inv_type, brCode, Invoice_No);
                                Clm.LogicalSelectedValues(Inv_type);
                                Clm.XMLUUID();

                                //x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm);
                                x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm, Invoice_No);
                                string STATUSs = x.btnPostXML_Click(Clm.varX_UUID, Invoice_No, "Standard Invoice");
                                #endregion
                                string STATUS = "";
                                //if (STATUSs=="true")
                                //{
                                //      STATUS = "CLEARED";
                                //}
                                //else
                                //{
                                //    STATUS = "REJECTED";
                                //}
                                #region chk status zatca
                                if (STATUSs == "true")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "CLEARED";
                                    #region atcmnet


                                    string inv_no = Invoice_No;//"18008";
                                    string inve_type = Inv_type;//"Standard Credit Note";
                                    var url = "http://localhost:80/home/PrintPDFView?inv_no=" + inv_no + "&inve_type=" + inve_type;
                                    var psi = new ProcessStartInfo("iexplore.exe");
                                    //psi.Arguments = "http://www.google.com/";
                                    psi.Arguments = url;
                                    Process.Start(psi);
                                    #endregion
                                }
                                else if (STATUSs == "false")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REJECTED";
                                }
                                else
                                {
                                    STATUS = STATUSs;
                                    item.ProcessZaca = "no";
                                }
                                #endregion
                                //api back call status update
                                string CUSTOMER_TRX_ID = item.CUSTOMER_TRX_ID;//"300000007684819";
                                string INV_NO = item.inv_no; //"202300004";

                                var returns2 = await callAPI.callAPIBACKAsync(CUSTOMER_TRX_ID, INV_NO, STATUS);
                                //eami send
                                //delet fro IS NULL
                                item.zaca_status = STATUS;
                                item.Post_back = returns2;
                                item.Mail_sent = "no";
                                _getInvoice.Updatestatus_vw_salesinvoicesr(item);
                                _getInvoice.del_from_tblprocessPIH();
                                Console.WriteLine($"************* end : " + item.inv_no + " *************");
                            }
                            Console.WriteLine($"************* end standerdd invoices  *************");
                            #endregion

                            #region vw_cr_salesinvoices
                            var getinvoce_sale_cr = _getInvoice.GetAll_vw_cr_salesinvoices();
                            Console.WriteLine($"Total cr_salesinvoices inv from api: {getinvoce_sale_cr.Count()}");
                            foreach (var item in getinvoce_sale_cr)
                            {
                                #region Pass zaca
                                xml x = new xml();

                                string brCode = item.branch_code;//string brCode = "00001";
                                string Invoice_No = item.inv_no;// string Invoice_No = "STDIN00003";//202300006
                                                                //  string Invoice_No = "202300006";//
                                string Inv_type = item.inv_type; //string Inv_type = "Standard Invoice";
                                string row = item.no_lines.ToString();// string row = "2";
                                // RetrieveBranchInfo
                                ClassMain Clm = new ClassMain();
                                Clm.varcur_code = "SAR";
                                Clm.varpay_code = "10";
                                Clm.varpay_inst = "CASH";
                                Clm.varcnt_items = row;
                                Clm.varbrCode = brCode;
                                Clm.varInvoice_No = Invoice_No;
                                Clm.varInv_type = Inv_type;
                                // Clm.varinv_index = "4";
                                Clm.varinv_index = item.inv_index.ToString();//Clm.varinv_index = "12";
                                //ClassMain.VarSta_inv_date = "2023-11-04";//2023-10-12
                                //ClassMain.VarSta_inv_date = item.inv_date;// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                //
                                string inputDateString = item.inv_date;

                                if (DateTime.TryParseExact(inputDateString, "MM/dd/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                {
                                    ClassMain.VarSta_inv_date = parsedDateTime.ToString("yyyy-MM-dd");// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                    string formattedDateString = parsedDateTime.ToString("yyyy-MM-dd");
                                    //Console.WriteLine("Formatted Date: " + formattedDateString);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format.");
                                }
                                //
                                ClassMain.VarSta_inv_time = item.branch_code;//ClassMain.VarSta_inv_time = "00001";
                                //ClassMain.VarSta_inv_no = "STDIN00003";
                                ClassMain.VarSta_inv_no = Invoice_No;
                                Clm.RetrieveBranchInfo(brCode);
                                //mDisplayBuyersInfo
                                // string brCode = wFrmInvoices.SetBr_Code;


                                ClassMain Clm2 = new ClassMain();
                                Clm.RetrieveBuyersInfo(Inv_type, brCode, Invoice_No);
                                //RetrieveXMLDetails
                                // string brCode = wFrmInvoices.SetBr_Code;
                                //string Invoice_No = wFrmInvoices.SetInvoice_No;
                                //string Inv_type = wFrmInvoices.SetInv_type;

                                ClassMain Clm3 = new ClassMain();
                                Clm.RetrieveXMLDetails(Inv_type, brCode, Invoice_No);
                                Clm.LogicalSelectedValues(Inv_type);
                                Clm.XMLUUID();

                                //x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm);
                                x.XMLProcessMode("MANUAL_PRO", "Standard Credit Note", Clm, Invoice_No);
                                string STATUSs = x.btnPostXML_Click(Clm.varX_UUID, Invoice_No, "Standard Credit Note");
                                #endregion
                                string STATUS = "";
                                //if (STATUSs == "true")
                                //{
                                //    STATUS = "CLEARED";
                                //}
                                //else
                                //{
                                //    STATUS = "REJECTED";
                                //}
                                #region chk status zatca
                                if (STATUSs == "true")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "CLEARED";
                                    #region atcmnet


                                    string inv_no = Invoice_No;//"18008";
                                    string inve_type = Inv_type;//"Standard Credit Note";
                                    var url = "http://localhost:80/home/PrintPDFView?inv_no=" + inv_no + "&inve_type=" + inve_type;
                                    var psi = new ProcessStartInfo("iexplore.exe");
                                    //psi.Arguments = "http://www.google.com/";
                                    psi.Arguments = url;
                                    Process.Start(psi);
                                    #endregion
                                }
                                else if (STATUSs == "false")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REJECTED";
                                }
                                else
                                {
                                    STATUS = STATUSs;
                                    item.ProcessZaca = "no";
                                }
                                #endregion
                                //api back call status update
                                string CUSTOMER_TRX_ID = item.CUSTOMER_TRX_ID;//"300000007684819";
                                string INV_NO = item.inv_no; //"202300004";

                                var returns2 = await callAPI.callAPIBACKAsync(CUSTOMER_TRX_ID, INV_NO, STATUS);
                                //eami send
                                //delet fro IS NULL
                                item.zaca_status = STATUS;
                                item.Post_back = returns2;
                                item.Mail_sent = "no";
                                _getInvoice.Updatestatus_vw_cr_salesinvoices(item);
                                _getInvoice.del_from_tblprocessPIH();
                                Console.WriteLine($"************* end : " + item.inv_no + " *************");
                            }
                            #endregion
                            #region vw_dr_salesinvoices
                            var getinvoce_sale_dr = _getInvoice.GetAll_vw_dr_salesinvoices();
                            Console.WriteLine($"Total dr_salesinvoices inv from api: {getinvoce_sale_cr.Count()}");
                            foreach (var item in getinvoce_sale_dr)
                            {
                                #region Pass zaca
                                xml x = new xml();

                                string brCode = item.branch_code;//string brCode = "00001";
                                string Invoice_No = item.inv_no;// string Invoice_No = "STDIN00003";//202300006
                                                                //  string Invoice_No = "202300006";//
                                string Inv_type = item.inv_type; //string Inv_type = "Standard Invoice";
                                string row = item.no_lines.ToString();// string row = "2";
                                // RetrieveBranchInfo
                                ClassMain Clm = new ClassMain();
                                Clm.varcur_code = "SAR";
                                Clm.varpay_code = "10";
                                Clm.varpay_inst = "CASH";
                                Clm.varcnt_items = row;
                                Clm.varbrCode = brCode;
                                Clm.varInvoice_No = Invoice_No;
                                Clm.varInv_type = Inv_type;
                                // Clm.varinv_index = "4";
                                Clm.varinv_index = item.inv_index.ToString();//Clm.varinv_index = "12";
                                //ClassMain.VarSta_inv_date = "2023-11-04";//2023-10-12
                                //ClassMain.VarSta_inv_date = item.inv_date;// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                //
                                string inputDateString = item.inv_date;

                                if (DateTime.TryParseExact(inputDateString, "MM/dd/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                {
                                    ClassMain.VarSta_inv_date = parsedDateTime.ToString("yyyy-MM-dd");// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                    string formattedDateString = parsedDateTime.ToString("yyyy-MM-dd");
                                    //Console.WriteLine("Formatted Date: " + formattedDateString);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format.");
                                }
                                //
                                ClassMain.VarSta_inv_time = item.branch_code;//ClassMain.VarSta_inv_time = "00001";
                                //ClassMain.VarSta_inv_no = "STDIN00003";
                                ClassMain.VarSta_inv_no = Invoice_No;
                                Clm.RetrieveBranchInfo(brCode);
                                //mDisplayBuyersInfo
                                // string brCode = wFrmInvoices.SetBr_Code;


                                ClassMain Clm2 = new ClassMain();
                                Clm.RetrieveBuyersInfo(Inv_type, brCode, Invoice_No);
                                //RetrieveXMLDetails
                                // string brCode = wFrmInvoices.SetBr_Code;
                                //string Invoice_No = wFrmInvoices.SetInvoice_No;
                                //string Inv_type = wFrmInvoices.SetInv_type;

                                ClassMain Clm3 = new ClassMain();
                                Clm.RetrieveXMLDetails(Inv_type, brCode, Invoice_No);
                                Clm.LogicalSelectedValues(Inv_type);
                                Clm.XMLUUID();

                                //x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm);
                                x.XMLProcessMode("MANUAL_PRO", "Standard Debit Note", Clm, Invoice_No);
                                string STATUSs = x.btnPostXML_Click(Clm.varX_UUID, Invoice_No, "Standard Debit Note");
                                #endregion
                                string STATUS = "";
                                #region chk status zatca
                                if (STATUSs == "true")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "CLEARED";
                                    #region atcmnet


                                    string inv_no = Invoice_No;//"18008";
                                    string inve_type = Inv_type;//"Standard Credit Note";
                                    var url = "http://localhost:80/home/PrintPDFView?inv_no=" + inv_no + "&inve_type=" + inve_type;
                                    var psi = new ProcessStartInfo("iexplore.exe");
                                    //psi.Arguments = "http://www.google.com/";
                                    psi.Arguments = url;
                                    Process.Start(psi);
                                    #endregion
                                }
                                else if (STATUSs == "false")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REJECTED";
                                }
                                else
                                {
                                    STATUS = STATUSs;
                                    item.ProcessZaca = "no";
                                }
                                #endregion
                               
                               
                                //api back call status update
                                string CUSTOMER_TRX_ID = item.CUSTOMER_TRX_ID;//"300000007684819";
                                string INV_NO = item.inv_no; //"202300004";

                                var returns2 = await callAPI.callAPIBACKAsync(CUSTOMER_TRX_ID, INV_NO, STATUS);
                                //eami send
                                //delet fro IS NULL
                                item.zaca_status = STATUS;
                                item.Post_back = returns2;
                                item.Mail_sent = "no";
                                

                                _getInvoice.Updatestatus_vw_dr_salesinvoices(item);
                                _getInvoice.del_from_tblprocessPIH();
                                Console.WriteLine($"************* end : " + item.inv_no + " *************");
                            }
                            #endregion
                            #region Simplified inv
                            var getinvoce_vw_cashsalesinvoices = _getInvoice.GetAllvw_salesinvoices_vw_cashsalesinvoices();
                            //  var getinvoce = _getInvoice.GetAll_vw_cr_salesinvoices();
                            Console.WriteLine($"Total simplified inv from api: {getinvoce_vw_cashsalesinvoices.Count()}");
                            foreach (var item in getinvoce_vw_cashsalesinvoices)
                            {
                                #region Pass zaca
                                xml x = new xml();

                                string brCode = item.branch_code;//string brCode = "00001";
                                string Invoice_No = item.inv_no;// string Invoice_No = "STDIN00003";//202300006
                                                                //  string Invoice_No = "202300006";//
                                string Inv_type = item.inv_type; //string Inv_type = "Standard Invoice";
                                string row = item.no_lines.ToString();// string row = "2";
                                // RetrieveBranchInfo
                                ClassMain Clm = new ClassMain();
                                Clm.varcur_code = "SAR";
                                Clm.varpay_code = "10";
                                Clm.varpay_inst = "CASH";
                                Clm.varcnt_items = row;
                                Clm.varbrCode = brCode;
                                Clm.varInvoice_No = Invoice_No;
                                Clm.varInv_type = Inv_type;
                                // Clm.varinv_index = "4";
                                Clm.varinv_index = item.inv_index.ToString();//Clm.varinv_index = "12";
                                //ClassMain.VarSta_inv_date = "2023-11-04";//2023-10-12
                                //ClassMain.VarSta_inv_date = item.inv_date;// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                //
                                string inputDateString = item.inv_date;

                                if (DateTime.TryParseExact(inputDateString, "MM/dd/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                {
                                    ClassMain.VarSta_inv_date = parsedDateTime.ToString("yyyy-MM-dd");// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                    string formattedDateString = parsedDateTime.ToString("yyyy-MM-dd");
                                    //Console.WriteLine("Formatted Date: " + formattedDateString);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format.");
                                }
                                //
                                ClassMain.VarSta_inv_time = item.branch_code;//ClassMain.VarSta_inv_time = "00001";
                                //ClassMain.VarSta_inv_no = "STDIN00003";
                                ClassMain.VarSta_inv_no = Invoice_No;
                                Clm.RetrieveBranchInfo(brCode);
                                //mDisplayBuyersInfo
                                // string brCode = wFrmInvoices.SetBr_Code;


                                ClassMain Clm2 = new ClassMain();
                                Clm.RetrieveBuyersInfo(Inv_type, brCode, Invoice_No);
                                //RetrieveXMLDetails
                                // string brCode = wFrmInvoices.SetBr_Code;
                                //string Invoice_No = wFrmInvoices.SetInvoice_No;
                                //string Inv_type = wFrmInvoices.SetInv_type;

                                ClassMain Clm3 = new ClassMain();
                                Clm.RetrieveXMLDetails(Inv_type, brCode, Invoice_No);
                                Clm.LogicalSelectedValues(Inv_type);
                                Clm.XMLUUID();

                                //x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm);
                                x.XMLProcessMode("MANUAL_PRO", "Simplified Invoice", Clm, Invoice_No);
                                string STATUSs = x.btnPostXML_Click(Clm.varX_UUID, Invoice_No, "Simplified Invoice");
                                #endregion
                                string STATUS = "";
                                //if (STATUSs=="true")
                                //{
                                //      STATUS = "CLEARED";
                                //}
                                //else
                                //{
                                //    STATUS = "REJECTED";
                                //}
                                #region chk status zatca
                                if (STATUSs == "true")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REPORTED";
                                    #region atcmnet


                                    string inv_no = Invoice_No;// "18008";
                                    string inve_type = Inv_type;// "Standard Credit Note";
                                    var url = "http://localhost:80/home/PrintPDFView?inv_no=" + inv_no + "&inve_type=" + inve_type;
                                    var psi = new ProcessStartInfo("iexplore.exe");
                                    //psi.Arguments = "http://www.google.com/";
                                    psi.Arguments = url;
                                    Process.Start(psi);
                                    #endregion
                                }
                                else if (STATUSs == "false")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REJECTED";
                                }
                                else
                                {
                                    STATUS = STATUSs;
                                    item.ProcessZaca = "no";
                                }
                                #endregion
                                //api back call status update
                                string CUSTOMER_TRX_ID = item.CUSTOMER_TRX_ID;//"300000007684819";
                                string INV_NO = item.inv_no; //"202300004";

                                var returns2 = await callAPI.callAPIBACKAsync(CUSTOMER_TRX_ID, INV_NO, STATUS);
                                //eami send
                                //delet fro IS NULL
                                item.zaca_status = STATUS;
                                item.Post_back = returns2;
                                item.Mail_sent = "no";
                                _getInvoice.Updatestatus_vw_salesinvoicesr_vw_cashsalesinvoices(item);
                                _getInvoice.del_from_tblprocessPIH();
                                Console.WriteLine($"************* end : " + item.inv_no + " *************");
                            }
                            Console.WriteLine($"************* end standerdd invoices  *************");
                            #endregion
                            #region cash cr
                            #region vw_dr_salesinvoices
                            var getinvoce_sale_dr_CASH = _getInvoice.GetAll_vw_dr_salesinvoices_CASH();
                            Console.WriteLine($"Total dr__CASH_invoices inv from api: {getinvoce_sale_dr_CASH.Count()}");
                            foreach (var item in getinvoce_sale_dr_CASH)
                            {
                                #region Pass zaca
                                xml x = new xml();

                                string brCode = item.branch_code;//string brCode = "00001";
                                string Invoice_No = item.inv_no;// string Invoice_No = "STDIN00003";//202300006
                                                                //  string Invoice_No = "202300006";//
                                string Inv_type = item.inv_type; //string Inv_type = "Standard Invoice";
                                string row = item.no_lines.ToString();// string row = "2";
                                // RetrieveBranchInfo
                                ClassMain Clm = new ClassMain();
                                Clm.varcur_code = "SAR";
                                Clm.varpay_code = "10";
                                Clm.varpay_inst = "CASH";
                                Clm.varcnt_items = row;
                                Clm.varbrCode = brCode;
                                Clm.varInvoice_No = Invoice_No;
                                Clm.varInv_type = Inv_type;
                                // Clm.varinv_index = "4";
                                Clm.varinv_index = item.inv_index.ToString();//Clm.varinv_index = "12";
                                //ClassMain.VarSta_inv_date = "2023-11-04";//2023-10-12
                                //ClassMain.VarSta_inv_date = item.inv_date;// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                //
                                string inputDateString = item.inv_date;

                                if (DateTime.TryParseExact(inputDateString, "MM/dd/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                {
                                    ClassMain.VarSta_inv_date = parsedDateTime.ToString("yyyy-MM-dd");// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                    string formattedDateString = parsedDateTime.ToString("yyyy-MM-dd");
                                    //Console.WriteLine("Formatted Date: " + formattedDateString);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format.");
                                }
                                //
                                ClassMain.VarSta_inv_time = item.branch_code;//ClassMain.VarSta_inv_time = "00001";
                                //ClassMain.VarSta_inv_no = "STDIN00003";
                                ClassMain.VarSta_inv_no = Invoice_No;
                                Clm.RetrieveBranchInfo(brCode);
                                //mDisplayBuyersInfo
                                // string brCode = wFrmInvoices.SetBr_Code;


                                ClassMain Clm2 = new ClassMain();
                                Clm.RetrieveBuyersInfo(Inv_type, brCode, Invoice_No);
                                //RetrieveXMLDetails
                                // string brCode = wFrmInvoices.SetBr_Code;
                                //string Invoice_No = wFrmInvoices.SetInvoice_No;
                                //string Inv_type = wFrmInvoices.SetInv_type;

                                ClassMain Clm3 = new ClassMain();
                                Clm.RetrieveXMLDetails(Inv_type, brCode, Invoice_No);
                                Clm.LogicalSelectedValues(Inv_type);
                                Clm.XMLUUID();

                                //x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm);
                                x.XMLProcessMode("MANUAL_PRO", "Simplified Debit Note", Clm, Invoice_No);
                                string STATUSs = x.btnPostXML_Click(Clm.varX_UUID, Invoice_No, "Simplified Debit Note");
                                #endregion
                                string STATUS = "";
                                #region chk status zatca
                                if (STATUSs == "true")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REPORTED";
                                    #region atcmnet


                                    string inv_no = Invoice_No;//"18008";
                                    string inve_type = Inv_type;//"Standard Credit Note";
                                    var url = "http://localhost:80/home/PrintPDFView?inv_no=" + inv_no + "&inve_type=" + inve_type;
                                    var psi = new ProcessStartInfo("iexplore.exe");
                                    //psi.Arguments = "http://www.google.com/";
                                    psi.Arguments = url;
                                    Process.Start(psi);
                                    #endregion
                                }
                                else if (STATUSs == "false")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REJECTED";
                                }
                                else
                                {
                                    STATUS = STATUSs;
                                    item.ProcessZaca = "no";
                                }
                                #endregion


                                //api back call status update
                                string CUSTOMER_TRX_ID = item.CUSTOMER_TRX_ID;//"300000007684819";
                                string INV_NO = item.inv_no; //"202300004";

                                var returns2 = await callAPI.callAPIBACKAsync(CUSTOMER_TRX_ID, INV_NO, STATUS);
                                //eami send
                                //delet fro IS NULL
                                item.zaca_status = STATUS;
                                item.Post_back = returns2;
                                item.Mail_sent = "no";


                                _getInvoice.Updatestatus_vw_dr_salesinvoices_CASH(item);
                                _getInvoice.del_from_tblprocessPIH();
                                Console.WriteLine($"************* end : " + item.inv_no + " *************");
                            }
                            #endregion
                            #region vw_cr_cashsalesinvoices
                            var getinvoce_sale_cr_CASH = _getInvoice.GetAll_vw_cr_salesinvoices_CASH();
                            Console.WriteLine($"Total Simplified Credit Note inv from api: {getinvoce_sale_dr_CASH.Count()}");
                            foreach (var item in getinvoce_sale_cr_CASH)
                            {
                                #region Pass zaca
                                xml x = new xml();

                                string brCode = item.branch_code;//string brCode = "00001";
                                string Invoice_No = item.inv_no;// string Invoice_No = "STDIN00003";//202300006
                                                                //  string Invoice_No = "202300006";//
                                string Inv_type = item.inv_type; //string Inv_type = "Standard Invoice";
                                string row = item.no_lines.ToString();// string row = "2";
                                // RetrieveBranchInfo
                                ClassMain Clm = new ClassMain();
                                Clm.varcur_code = "SAR";
                                Clm.varpay_code = "10";
                                Clm.varpay_inst = "CASH";
                                Clm.varcnt_items = row;
                                Clm.varbrCode = brCode;
                                Clm.varInvoice_No = Invoice_No;
                                Clm.varInv_type = Inv_type;
                                // Clm.varinv_index = "4";
                                Clm.varinv_index = item.inv_index.ToString();//Clm.varinv_index = "12";
                                //ClassMain.VarSta_inv_date = "2023-11-04";//2023-10-12
                                //ClassMain.VarSta_inv_date = item.inv_date;// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                //
                                string inputDateString = item.inv_date;

                                if (DateTime.TryParseExact(inputDateString, "MM/dd/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDateTime))
                                {
                                    ClassMain.VarSta_inv_date = parsedDateTime.ToString("yyyy-MM-dd");// // ClassMain.VarSta_inv_date = "2023-10-12";//
                                    string formattedDateString = parsedDateTime.ToString("yyyy-MM-dd");
                                    //Console.WriteLine("Formatted Date: " + formattedDateString);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid date format.");
                                }
                                //
                                ClassMain.VarSta_inv_time = item.branch_code;//ClassMain.VarSta_inv_time = "00001";
                                //ClassMain.VarSta_inv_no = "STDIN00003";
                                ClassMain.VarSta_inv_no = Invoice_No;
                                Clm.RetrieveBranchInfo(brCode);
                                //mDisplayBuyersInfo
                                // string brCode = wFrmInvoices.SetBr_Code;


                                ClassMain Clm2 = new ClassMain();
                                Clm.RetrieveBuyersInfo(Inv_type, brCode, Invoice_No);
                                //RetrieveXMLDetails
                                // string brCode = wFrmInvoices.SetBr_Code;
                                //string Invoice_No = wFrmInvoices.SetInvoice_No;
                                //string Inv_type = wFrmInvoices.SetInv_type;

                                ClassMain Clm3 = new ClassMain();
                                Clm.RetrieveXMLDetails(Inv_type, brCode, Invoice_No);
                                Clm.LogicalSelectedValues(Inv_type);
                                Clm.XMLUUID();

                                //x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm);Simplified Credit Note
                                x.XMLProcessMode("MANUAL_PRO", "Simplified Credit Note", Clm, Invoice_No);
                                string STATUSs = x.btnPostXML_Click(Clm.varX_UUID, Invoice_No, "Simplified Credit Note");
                                #endregion
                                string STATUS = "";
                                #region chk status zatca
                                if (STATUSs == "true")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REPORTED";
                                    #region atcmnet


                                    string inv_no = Invoice_No;// "18008";
                                    string inve_type = Inv_type;// "Standard Credit Note";
                                    var url = "http://localhost:80/home/PrintPDFView?inv_no=" + inv_no + "&inve_type=" + inve_type;
                                    var psi = new ProcessStartInfo("iexplore.exe");
                                    //psi.Arguments = "http://www.google.com/";
                                    psi.Arguments = url;
                                    Process.Start(psi);
                                    #endregion
                                }
                                else if (STATUSs == "false")
                                {
                                    item.ProcessZaca = "yes";
                                    STATUS = "REJECTED";
                                }
                                else
                                {
                                    STATUS = STATUSs;
                                    item.ProcessZaca = "no";
                                }
                                #endregion


                                //api back call status update
                                string CUSTOMER_TRX_ID = item.CUSTOMER_TRX_ID;//"300000007684819";
                                string INV_NO = item.inv_no; //"202300004";

                                var returns2 = await callAPI.callAPIBACKAsync(CUSTOMER_TRX_ID, INV_NO, STATUS);
                                //eami send
                                //delet fro IS NULL
                                item.zaca_status = STATUS;
                                item.Post_back = returns2;
                                item.Mail_sent = "no";


                                _getInvoice.Updatestatus_vw_cr_salesinvoices_CASH(item);
                                _getInvoice.del_from_tblprocessPIH();
                                Console.WriteLine($"************* end : " + item.inv_no + " *************");
                            }
                            #endregion
                            #endregion
                            Console.WriteLine($"************* end   *************");
                        }
                        else
                        {
                            Console.WriteLine($"step 2 not complete ");
                        }

                    }
                    else
                    {
                        Console.WriteLine($"step 1 not complete ");
                    }

                    #endregion

                    // Wait for 1 minute before the next iteration
                    await Task.Delay(TimeSpan.FromMinutes(2));
                }


                #endregion
                //try       




                //var returns = callAPI.callAPIAsync();

                #region Pass zaca
                //xml x = new xml();
                ////
                ////x.btnPostXML_Click("e6101a6a-219a-4df0-9498-08382917d517");
                ////
                //string brCode = "JEDCO";
                //string Invoice_No = "STDIN00003";//202300006
                //                                 //  string Invoice_No = "202300006";//
                //string Inv_type = "Standard Invoice";
                //string row = "2";
                //// RetrieveBranchInfo
                //ClassMain Clm = new ClassMain();
                //Clm.varcur_code = "SAR";
                //Clm.varpay_code = "10";
                //Clm.varpay_inst = "CASH";
                //Clm.varcnt_items = row;
                //Clm.varbrCode = brCode;
                //Clm.varInvoice_No = Invoice_No;
                //Clm.varInv_type = Inv_type;
                //// Clm.varinv_index = "4";
                //Clm.varinv_index = "12";
                ////ClassMain.VarSta_inv_date = "2023-11-04";//2023-10-12
                //ClassMain.VarSta_inv_date = "2023-10-12";//
                //ClassMain.VarSta_inv_time = "JEDCO";
                ////ClassMain.VarSta_inv_no = "STDIN00003";
                //ClassMain.VarSta_inv_no = Invoice_No;
                //Clm.RetrieveBranchInfo(brCode);
                ////mDisplayBuyersInfo
                //// string brCode = wFrmInvoices.SetBr_Code;


                //ClassMain Clm2 = new ClassMain();
                //Clm.RetrieveBuyersInfo(Inv_type, brCode, Invoice_No);
                ////RetrieveXMLDetails
                //// string brCode = wFrmInvoices.SetBr_Code;
                ////string Invoice_No = wFrmInvoices.SetInvoice_No;
                ////string Inv_type = wFrmInvoices.SetInv_type;

                //ClassMain Clm3 = new ClassMain();
                //Clm.RetrieveXMLDetails(Inv_type, brCode, Invoice_No);
                //Clm.LogicalSelectedValues(Inv_type);
                //Clm.XMLUUID();

                //x.XMLProcessMode("MANUAL_PRO", "Standard Invoice", Clm, Invoice_No);
                //x.btnPostXML_Click(Clm.varX_UUID);
                #endregion

                // var returns=  callAPI.callAPIAsync();




            }
        }
       
        
    }
  
    class xml
    {
        public string Qry { get; set; }
        int sFilter;
        bool XMLPosted = false;
        string SelXMLInv_Base64 = String.Empty;//?
        string SelinvoiceHashTag = String.Empty;//?
        string Selcbcuuid = String.Empty;//?
        long IndexNo = 0;//?
        long IndexPosted = 0;

        string Selbranch_code = String.Empty;
        public static string SetBr_Code = String.Empty;
        public static string SetInvoice_No = String.Empty;
        public static string SetInv_type = String.Empty;

        #region MyRegion
        public string XMLProcessMode(string ProcessMode, string InvoiceType, ClassMain Clm,string inv_no)
        {
            string XMLProcessMode_return = "no";
            try
            {
                switch (ProcessMode)
                {
                    case "AUTO_PRO":

                        break;
                    case "MANUAL_PRO":

                        //  ClassMain Clm = new ClassMain();



                        string ExDrInvoice = "Debit";
                        string ExCrInvoice = "Credit";
                        /* Use indexof if component exist */
                        //int LookValDr = this.cboinv_type.Text.IndexOf(ExDrInvoice);
                        //int LookValCr = this.cboinv_type.Text.IndexOf(ExCrInvoice);
                        int LookValDr = -1;
                        int LookValCr = -1;

                        if ((LookValDr >= 0) || (LookValCr >= 0))
                        {
                            //Clm.varrefinv_no = this.txtInvoice_ref.Text;
                            //Clm.varRef_Date = this.txtInvRef_Date.Text;
                            //Clm.varinstruction_code = this.cboinstruction_code.Text;
                        }

                        //  txtLine_Count.Text = Clm.varcnt_items;

                        //Clm.varmode_ofpay = this.cbomode_ofpay.Text;
                        //Clm.vardeli_date = this.txtdeli_date.Text;
                        //Clm.varactdeli_date = this.txtactdeli_date.Text;

                        //Clm.varvat_breakdown = this.cbovat_breakdown.Text;
                        //Clm.varTotamnt_allow = this.txtTotamnt_allow.Text;
                        //Clm.varTotamnt_disc = this.txtTotamnt_disc.Text;
                        //Clm.vargTotamnt_vat = this.txtgTotamnt_vat.Text;
                        //Clm.vargTot_LineExtAmount = this.txtgTot_LineExtAmount.Text;
                        //Clm.vargTotamnt_disc = this.txtgTotamnt_disc.Text;
                        //Clm.vargTotamnt_allow = this.txtgTotamnt_allow.Text;
                        //Clm.vargTot_TaxExclAmount = this.txtgTot_TaxExclAmount.Text;
                        //Clm.vargTot_TaxInclAmount = this.txtgTot_TaxInclAmount.Text;
                        //Clm.vargTotamnt_vat = this.txtMgTotamnt_vat.Text;
                        //Clm.vargTotamnt_prepaid = this.txtgTotamnt_prepaid.Text;
                        //Clm.vargTotamnt_payable = this.txtgTotamnt_payable.Text;

                        // Clm.XMLInvoice0102_Composition("", "dataGridViewItems", txtbranch_code.Text, txtinv_no.Text);
                       // Clm.XMLInvoice0102_Composition(null, "dataGridViewItems", "JEDCO", "STDIN00002");//inv_no
                        Clm.XMLInvoice0102_Composition(null, "dataGridViewItems", "JEDCOP", inv_no);//inv_no
                        //Clm.varPIH = rTxtPIH.Text;
                        //Clm.varPIH = "";
                        string Def_varinv_type = Clm.varInv_type;

                        if (Clm.Pro_XMLInvoice_Reqmnts(Def_varinv_type, inv_no) == false)
                        {
                            // tmrProcess.Enabled = false;
                            XMLProcessMode_return = "no";
                            Console.Write("Processed XML Invoice, Failed", "XML Invoice");
                            break;
                        }
                        else
                        {

                        }

                        /* Use compare if variable exist */
                        string ExInvoiceType = "Standard";
                        int LookInvoiceType = InvoiceType.IndexOf(ExInvoiceType);

                        if (LookInvoiceType == 0)
                        {
                            //this.txtHashXMLTag6.Text = Clm.varHashXMLTag6;
                            Console.Write(Clm.varHashXMLTag6);
                            //this.txtEcdsa_sigTag7.Text = Clm.varEcdsa_sigTag7;
                            Console.Write(Clm.varEcdsa_sigTag7);
                        }
                        else
                        {

                            //this.txttsellers_nameTag1.Text = Clm.varsellers_nameTag1;
                            //this.txtsel_vatregTag2.Text = Clm.varsel_vatregTag2;
                            //this.txtTimeStampTag3.Text = Clm.varTimeStampTag3;
                            //this.txtgTotamnt_payableTag4.Text = Clm.vargTotamnt_payableTag4;
                            //this.txtMgTotamnt_vatTag5.Text = Clm.varMgTotamnt_vatTag5;

                            //this.txtHashXMLTag6.Text = Clm.varHashXMLTag6;
                            //this.txtEcdsa_sigTag7.Text = Clm.varEcdsa_sigTag7;
                            //this.txtEcdsa_PubTag8.Text = Clm.varEcdsa_PubTag8;
                            //this.txtCrypt_StampTag9.Text = Clm.varCrypt_StampTag9;
                            //this.rTxtQrCodeBase64.Text = Clm.varQrCodeBase64;

                            //string Img_Loc;
                            //string QRCode_ImgFilename = Regex.Replace(Clm.varInvoice_No, "[^A-Za-z0-9 ]", "");

                            ///*Change Path settings */
                            //Img_Loc = ClassDefAcctRepository.DefBrowseQrCodePro + @"\" + QRCode_ImgFilename + ".jpg";

                            //picQrCode.Image = generateQRImage(Clm.varQrCodeBase64);
                            //this.rTxtQrCodeBase64.Text = (Clm.varQrCodeBase64);
                            //SaveImage(picQrCode.Image, Img_Loc);
                        }

                        string xml = ClassMain.XMLInvoiceUTF8File;

                        //tmrProcess.Enabled = false;
                        Console.Write("Processed XML Invoice Successfulyy XML Invoice");
                        XMLProcessMode_return = "yes";
                        break;
                }
            }
            catch (Exception ex)
            {
                XMLProcessMode_return = "no";
                //throw;
            }
            return XMLProcessMode_return;
        }

        //xml post to fatora
        public string btnPostXML_Click(string varicv_uuid,string INVOICE_NUMBER,string invoicetype)
        {
            string status = "true";
            RetrieveZekhahUpdates(varicv_uuid);
            //if (XMLPosted == true)
            //{
            //    MessageBox.Show("Selected XML Invoice, Already Posted", "Posted", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //ClassMain.VarEnp_id = Convert.ToInt32(txtEnp_id.Text);//2
            //    ClassMain.VarCsOrg_Id = Convert.ToInt32(txtcsorg_id.Text);//9
            
            ClassMain.VarEnp_id =3;//2
            ClassMain.VarCsOrg_Id =12;//9
            Selbranch_code = "JEDCOP";
            SetInv_type = invoicetype;//"Standard Invoice";
            Selcbcuuid = varicv_uuid;
            Qry = string.Empty;
            Qry = "SELECT cs_unitendpoint.server_portal FROM cs_unitendpoint WHERE  cs_unitendpoint.enp_id = " + ClassMain.VarEnp_id + " ";
            string OrgServer_Portal = ClassMain.GetFieldValue(Qry);

            if (string.Compare(SetInv_type, "Standard") > 0)
            {
                Qry = string.Empty;
                Qry = "SELECT TOP 1 cs_unitendpoint.requestedbody_standard FROM unit_repository LEFT OUTER JOIN cs_unitendpoint ON (unit_repository.enp_id = cs_unitendpoint.enp_id) WHERE cs_unitendpoint.enp_id = " + ClassMain.VarEnp_id + " AND unit_repository.csorg_id = " + ClassMain.VarCsOrg_Id + " ORDER BY unit_repository.enp_id ASC";

            }
            else
            {
                Qry = string.Empty;
                Qry = "SELECT TOP 1 cs_unitendpoint.requestedbody_simplified FROM unit_repository LEFT OUTER JOIN cs_unitendpoint ON (unit_repository.enp_id = cs_unitendpoint.enp_id) WHERE cs_unitendpoint.enp_id = " + ClassMain.VarEnp_id + " AND unit_repository.csorg_id = " + ClassMain.VarCsOrg_Id + " ORDER BY unit_repository.enp_id ASC";

            }

            string OrgBody_EndPoint = ClassMain.GetFieldValue(Qry);

            if ((OrgBody_EndPoint == null) || (OrgBody_EndPoint == string.Empty))
            {
               // MessageBox.Show("Portal Endpoint Not found in this Account, Please Setup end point", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Console.Write("Portal Endpoint Not found in this Account, Please Setup end point Warning" );
                status = "Portal Endpoint Not found in this Account";
                return status;
            }

            ClassMain.VarLive_EndPoint = OrgBody_EndPoint;
            string Post_Endpoint = ClassMain.VarLive_EndPoint;

            ClassMain Clm = new ClassMain();

            Qry = string.Empty;
            Qry = "SELECT unit_certificates.pro_authtokenstring_base64, cs_unitconfig.orgcode, csr_unitconfig.cert_status, cs_unitendpoint.enp_id, cs_unitconfig.csorg_id FROM unit_certificates INNER JOIN cs_unitconfig ON unit_certificates.csid = cs_unitconfig.csid INNER JOIN csr_unitconfig ON unit_certificates.cert_id = csr_unitconfig.cert_id INNER JOIN cs_unitendpoint ON cs_unitconfig.enp_id = cs_unitendpoint.enp_id WHERE cs_unitconfig.orgcode = '" + Selbranch_code + "' AND cs_unitendpoint.enp_id = " + ClassMain.VarEnp_id + " AND cs_unitconfig.csorg_id = " + ClassMain.VarCsOrg_Id + " ORDER BY cs_unitendpoint.enp_id ASC";
            string OrgUnit_Authentication = ClassMain.GetFieldValue(Qry);

            //bool PoxtX_Success;
            string PoxtX_Success;

            PoxtX_Success = Clm.POSTXML_PortalLive(SetInv_type, OrgServer_Portal, Post_Endpoint, Selcbcuuid, SelinvoiceHashTag, SelXMLInv_Base64, OrgUnit_Authentication, IndexPosted, INVOICE_NUMBER) ;
            if (PoxtX_Success == "Server Down" || PoxtX_Success == "Check Connection") //if (PoxtX_Success != true)
            {
                status = "Pending";
                //MessageBox.Show("Failed to Upload XML Invoice", "POST Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.Write("Failed to Upload XML Invoice POST Invoice" );
            }

            if (string.Compare(SetInv_type, "Standard") > 0)
            {
                if (PoxtX_Success == "true")
                {
                        status = "true";
                        //lblResStatus.Text = "CLEARED REPORTED";
                        Console.Write("CLEARED REPORTED");

                }
                 else if (PoxtX_Success == "false")
                {
                        status = "false";
                        //lblResStatus.Text = "NOT CLEARED";
                 }
                // if (PoxtX_Success == true)
                //{
                //    status = "true";
                //    //lblResStatus.Text = "CLEARED REPORTED";
                //    Console.Write("CLEARED REPORTED");

                //}
                //else
                //{
                //    status = "false";
                //    //lblResStatus.Text = "NOT CLEARED";
                //    Console.Write("NOT CLEARED");
                //}
            }
            else
            {
                //if (PoxtX_Success == true)
                //{

                //    //lblResStatus.Text = "PASSED REPORTED";
                //    Console.Write("PASSED REPORTED");

                //}
                //else
                //{
                //    //lblResStatus.Text = "NOT REPORTED";
                //    Console.Write("NOT REPORTED");
                //}
                if (PoxtX_Success == "true")
                {
                    status = "true";
                    //lblResStatus.Text = "CLEARED REPORTED";
                    Console.Write("CLEARED REPORTED");

                }
                else if (PoxtX_Success == "false")
                {
                    status = "false";
                    //lblResStatus.Text = "NOT CLEARED";
                }
            }

            //if (PoxtX_Success == true)
            //{
            //    //XMLPosted = DisplayInvoicePosted(this.Selbranch_code, cboInvoiceType.ToString(), txtInvoiceno.Text, IndexNo);
            //    //FormatInvoicesPosted();
            //}
            //rTxtResponsebody.Text = ClassMain.Var_restResponseBody;
            //lblResCode.Text = ClassMain.RespCode.ToString();
            return status;
        }

        public void RetrieveZekhahUpdates(string fld_cbcuuid)
        {
            try
            {
                Qry = string.Empty;
                Qry = "SELECT * from  ZekhahUpdates ";
               
                Qry += "WHERE ";
                Qry += "fld_cbcuuid = '" + fld_cbcuuid + "'";


                SqlConfig.ConnectToServer(SqlConfig.ConnectionString);
                SqlCommand cmd = new SqlCommand(Qry, SqlConfig.ServerConn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //Put condition here of process mode

                    //IndexPosted = long.Parse(reader.GetString(reader.GetOrdinal("fld_indexzatca"))) ;
                    //SelinvoiceHashTag = reader.GetString(reader.GetOrdinal("invoicetaghash"));
                    //SelXMLInv_Base64 = reader.GetString(reader.GetOrdinal("xmlBase64"));
                    IndexPosted = reader.IsDBNull(reader.GetOrdinal("fld_indexzatca"))
           ? 0  // Default value if the column is NULL
           : reader.GetInt32(reader.GetOrdinal("fld_indexzatca"));

                    SelinvoiceHashTag = reader.IsDBNull(reader.GetOrdinal("invoicetaghash"))
                        ? string.Empty  // Default value if the column is NULL
                        : reader.GetString(reader.GetOrdinal("invoicetaghash"));

                    SelXMLInv_Base64 = reader.IsDBNull(reader.GetOrdinal("xmlBase64"))
                        ? string.Empty  // Default value if the column is NULL
                        : reader.GetString(reader.GetOrdinal("xmlBase64"));

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
        //private bool DisplayInvoicePosted(string pBr_Code, string InvoiceType, string Sel_InvoiceNo, long RecIndex)
        //{
        //    try
        //    {

        //        SqlConfig.ConnectToServer(SqlConfig.ConnectionString);

        //        if (sFilter == 1)
        //        {

        //            Qry = string.Empty;
        //            Qry = "SELECT fld_index, fld_doc_no, fld_doc_type, fld_doc_date, fld_time, fld_brcode, invoicePHI, invoicetaghash, fld_cbcuuid, xmlBase64, xmlBase64Approved, refreprocess, 'Posted', DeviceName FROM ZekhahUpdates WHERE fld_index = " + RecIndex + " AND fld_brcode = '" + pBr_Code + "' AND fld_doc_type = '" + InvoiceType + "' AND fld_update = 1 AND fld_doc_no = '" + Sel_InvoiceNo + "' ORDER BY fld_indexzatca";
        //        }
        //        else
        //        {
        //            Qry = string.Empty;
        //            Qry = "SELECT fld_index, fld_doc_no, fld_doc_type, fld_doc_date, fld_time, fld_brcode, invoicePHI, invoicetaghash, fld_cbcuuid, xmlBase64, xmlBase64Approved, refreprocess, 'Posted', DeviceName FROM ZekhahUpdates WHERE fld_index = " + RecIndex + " AND fld_brcode = '" + pBr_Code + "' AND fld_doc_type = '" + InvoiceType + "' AND fld_update = 1 AND fld_doc_no = '" + Sel_InvoiceNo + "' ORDER BY fld_indexzatca";

        //        }

        //        SqlCommand Cmd = new SqlCommand(Qry, SqlConfig.ServerConn);
        //        SqlDataAdapter MySqlAdtr = new SqlDataAdapter(Cmd);
        //        DataTable Data_Set = new DataTable();
        //        MySqlAdtr.Fill(Data_Set);
        //        dtvInvoiceDetail.DataSource = Data_Set;

        //        if (Data_Set.Rows.Count > 0)
        //        {
        //            SqlConfig.ServerConn.Close();
        //            SetRowNumberDetails();
        //            return true;
        //        }
        //        else
        //        {
        //            SqlConfig.ServerConn.Close();
        //            SetRowNumberDetails();
        //            return false;
        //        }


        //    }
        //    catch (SqlException ex)
        //    {
        //        SqlConfig.ServerConn.Close();
        //        MessageBox.Show($"Error: {ex.Message}");
        //        return false;
        //    }

        //}
        //private Bitmap generateQRImage(string text)
        //{
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(5);
        //    return qrCodeImage;
        //}
        //public void SaveImage(Image image, string location)
        //{

        //    try
        //    {
        //        string directory = System.IO.Path.GetDirectoryName(location);
        //        if (!Directory.Exists(directory))
        //        {
        //            Directory.CreateDirectory(directory);
        //        }

        //        image.Save(location);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Error: {e.Message}");
        //    }
        //}
        #endregion
    }
}
