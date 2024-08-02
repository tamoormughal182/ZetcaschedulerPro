using Dapper;
using iText.Barcodes.Dmcode;
using iText.Kernel.Crypto.Securityhandler;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler
{
    public class InvoiceRepository
    {

        string conn = DBHelper.Connectionstring();

        // Insert
        #region invoice raw
        public int Insert_InvoiceFromAPI_oracel(InvoiceFromAPI_oracel group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "INSERT INTO InvoiceFromAPI_oracel(Base64, DateTimeInsertion, Status) " +
                         "VALUES (@Base64, @DateTimeInsertion,  @Status)";

                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {
                            group.Base64,
                            //

                            group.DateTimeInsertion,
                            group.Status

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        //get
        public List<InvoiceFromAPI_oracel> GetAllInvoiceFromAPI_oracel()
        {
            List<InvoiceFromAPI_oracel> _objList = new List<InvoiceFromAPI_oracel>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM InvoiceFromAPI_oracel where STATUS  ='0'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<InvoiceFromAPI_oracel>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }

        public int Update_InvoiceFromAPI_oracel(InvoiceFromAPI_oracel group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "UPDATE InvoiceFromAPI_oracel " +
                   "SET    Status=@Status,NoOfLine=@NoOfLine " +

                " WHERE Id = @Id";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.Status,
                            group.NoOfLine,

                            group.Id

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        #endregion
        public int del_from_tblprocessPIH()
        {
            try
            {

                int rowsAffected = 0;

                string query = " delete  FROM  tblprocessPIH   where invPIH IS NULL";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {


                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        #region invoice clean vw_salesinvoices
        public int Updatestatus_vw_salesinvoicesr(vw_salesinvoices group)
        {
            try
            {
                // group.ProcessZaca = "yes";
                int rowsAffected = 0;

                string query = "UPDATE vw_salesinvoices " +
                   "SET    ProcessZaca=@ProcessZaca,Post_back=@Post_back ,zaca_status=@zaca_status  ,Mail_sent=@Mail_sent  " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,
                            group.Post_back,
                            group.zaca_status,
                            group.Mail_sent,
                            group.ProcessZaca

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }

        public List<vw_salesinvoices> GetAdel_from_tblprocessPIHllvw_salesinvoices()
        {
            List<vw_salesinvoices> _objList = new List<vw_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_salesinvoices where inv_type='Standard Invoice' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        public List<vw_salesinvoices> GetAllvw_salesinvoices()
        {
            List<vw_salesinvoices> _objList = new List<vw_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_salesinvoices where inv_type='Standard Invoice' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        public long InsertSalesInvoice(vw_salesinvoices group)
        {
            try
            {
                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
INSERT INTO vw_salesinvoices (
   inv_no, inv_type, inv_date, inv_time, deli_date, actdeli_date,
    mode_ofpay, cur_code, Totamnt_disc, Totamnt_allow, buy_name,
    gTot_LineExtAmount, gTotamnt_disc, gTotamnt_allow, gTot_TaxExclAmount,
    gTotamnt_vatExch, gTotinvper_vat, gTotamnt_vat, gTotamnt_prepaid,
    gTot_TaxInclAmount, gTotamnt_payable, proc_pending, branch_id, branch_code,
    buy_vatno, buy_countrycode, buy_id, buy_typeId, buy_cityname, buy_streetname,
    buy_buildingname, buy_buildno, buy_plotid, buy_adbuildno, buy_postalzone,
    buy_subcitysubname, buy_countrySubentity, idx_ztcaupload, Eamil, no_lines,RewBase64ID,ProcessZaca,CUSTOMER_TRX_ID,TRX_SOURCE
)
VALUES (
    @inv_no,@inv_type, @inv_date, @inv_time, @deli_date, @actdeli_date,
    @mode_ofpay, @cur_code, @Totamnt_disc, @Totamnt_allow, @buy_name,
    @gTot_LineExtAmount, @gTotamnt_disc, @gTotamnt_allow, @gTot_TaxExclAmount,
    @gTotamnt_vatExch, @gTotinvper_vat, @gTotamnt_vat, @gTotamnt_prepaid,
    @gTot_TaxInclAmount, @gTotamnt_payable, @proc_pending, @branch_id, @branch_code,
    @buy_vatno, @buy_countrycode, @buy_id, @buy_typeId, @buy_cityname, @buy_streetname,
    @buy_buildingname, @buy_buildno, @buy_plotid, @buy_adbuildno, @buy_postalzone,
    @buy_subcitysubname, @buy_countrySubentity, @idx_ztcaupload, @Eamil, @no_lines , @RewBase64ID, @ProcessZaca, @CUSTOMER_TRX_ID ,@TRX_SOURCE
);
SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    //RewBase64ID,ProcessZaca
                    parameters.Add("@RewBase64ID", group.RewBase64ID?.Trim());
                    parameters.Add("@ProcessZaca", group.ProcessZaca?.Trim());
                    //CUSTOMER_TRX_ID
                    parameters.Add("@CUSTOMER_TRX_ID", group.CUSTOMER_TRX_ID?.Trim());
                    parameters.Add("@inv_no", group.inv_no?.Trim());
                    parameters.Add("@inv_type", group.inv_type?.Trim());
                    parameters.Add("@inv_date", group.inv_date?.Trim());
                    parameters.Add("@inv_time", group.inv_time?.Trim());
                    parameters.Add("@deli_date", group.deli_date?.Trim());
                    parameters.Add("@actdeli_date", group.actdeli_date?.Trim());
                    parameters.Add("@mode_ofpay", group.mode_ofpay?.Trim());
                    parameters.Add("@cur_code", group.cur_code?.Trim());
                    parameters.Add("@Totamnt_disc", group.Totamnt_disc);
                    parameters.Add("@Totamnt_allow", group.Totamnt_allow);
                    parameters.Add("@buy_name", group.buy_name?.Trim());
                    parameters.Add("@gTot_LineExtAmount", group.gTot_LineExtAmount);
                    parameters.Add("@gTotamnt_disc", group.gTotamnt_disc);
                    parameters.Add("@gTotamnt_allow", group.gTotamnt_allow);
                    parameters.Add("@gTot_TaxExclAmount", group.gTot_TaxExclAmount);
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTotinvper_vat", group.gTotinvper_vat);
                    parameters.Add("@gTotamnt_vat", group.gTotamnt_vat);
                    parameters.Add("@gTotamnt_prepaid", group.gTotamnt_prepaid);
                    parameters.Add("@gTot_TaxInclAmount", group.gTot_TaxInclAmount);
                    parameters.Add("@gTotamnt_payable", group.gTotamnt_payable);
                    parameters.Add("@proc_pending", group.proc_pending?.Trim());
                    parameters.Add("@branch_id", group.branch_id);
                    parameters.Add("@branch_code", group.branch_code?.Trim());
                    parameters.Add("@buy_vatno", group.buy_vatno?.Trim());
                    parameters.Add("@buy_countrycode", group.buy_countrycode?.Trim());
                    parameters.Add("@buy_id", group.buy_id?.Trim());
                    parameters.Add("@buy_typeId", group.buy_typeId?.Trim());
                    parameters.Add("@buy_cityname", group.buy_cityname?.Trim());
                    parameters.Add("@buy_streetname", group.buy_streetname?.Trim());
                    parameters.Add("@buy_buildingname", group.buy_buildingname?.Trim());
                    parameters.Add("@buy_buildno", group.buy_buildno?.Trim());
                    parameters.Add("@buy_plotid", group.buy_plotid?.Trim());
                    parameters.Add("@buy_adbuildno", group.buy_adbuildno?.Trim());
                    parameters.Add("@buy_postalzone", group.buy_postalzone?.Trim());
                    parameters.Add("@buy_subcitysubname", group.buy_subcitysubname?.Trim());
                    parameters.Add("@buy_countrySubentity", group.buy_countrySubentity?.Trim());
                    parameters.Add("@idx_ztcaupload", group.idx_ztcaupload);
                    parameters.Add("@Eamil", group.Eamil?.Trim());
                    parameters.Add("@no_lines", group.no_lines);
                    //TRX_SOURCE
                    parameters.Add("@TRX_SOURCE", group.TRX_SOURCE);
                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }


                return insertedId;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update_vw_salesinvoicesr(vw_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "UPDATE vw_salesinvoices " +
                   "SET    inv_index=@inv_index " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,


                            group.inv_index

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Delete_dublicate_inv_no(vw_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "DELETE FROM vw_saleinvoicesdetails WHERE inv_no = @inv_no; " +
                     "DELETE FROM vw_salesinvoices WHERE inv_no = @inv_no;";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int InsertSaleInvoiceDetails(vw_saleinvoicesdetails details)
        {
            try
            {


                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
        INSERT INTO vw_saleinvoicesdetails (
            inv_index, rec_index, item_description, item_qty, item_unit,
            item_price, lineExtAmount, amnt_disc, taxExclAmount, per_vat,
            tax_code, tax_exceptcode, except_reason, amnt_vat, taxInclAmount, inv_no
        )
        VALUES (
            @inv_index, @rec_index, @item_description, @item_qty, @item_unit,
            @item_price, @lineExtAmount, @amnt_disc, @taxExclAmount, @per_vat,
            @tax_code, @tax_exceptcode, @except_reason, @amnt_vat, @taxInclAmount, @inv_no
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@inv_index", details.inv_index);
                    parameters.Add("@rec_index", details.rec_index);
                    parameters.Add("@item_description", details.item_description);
                    parameters.Add("@item_qty", details.item_qty);
                    parameters.Add("@item_unit", details.item_unit);
                    parameters.Add("@item_price", details.item_price);
                    parameters.Add("@lineExtAmount", details.lineExtAmount);
                    parameters.Add("@amnt_disc", details.amnt_disc);
                    parameters.Add("@taxExclAmount", details.taxExclAmount);
                    parameters.Add("@per_vat", details.per_vat);
                    parameters.Add("@tax_code", details.tax_code);
                    parameters.Add("@tax_exceptcode", details.tax_exceptcode);
                    parameters.Add("@except_reason", details.except_reason);
                    parameters.Add("@amnt_vat", details.amnt_vat);
                    parameters.Add("@taxInclAmount", details.taxInclAmount);
                    parameters.Add("@inv_no", details.inv_no);

                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }

                rowsAffected = insertedId != 0 ? 1 : 0;
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //update zaca_status_detail
        public int Update_zaca_status_detail(string inv_nos, string zaca_status_details)
        {
            try
            {
                vw_salesinvoices group = new vw_salesinvoices();
                group.inv_no = inv_nos;
                group.zaca_status_detail = zaca_status_details;
                int rowsAffected = 0;

                string query = "UPDATE vw_salesinvoices " +
                   "SET    zaca_status_detail=@zaca_status_detail " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.zaca_status_detail

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //update_xml_name_for_attachemnt
        public int update_xml_name_for_attachemnt(string inv_nos, string xmlName)
        {
            try
            {
                vw_salesinvoices group = new vw_salesinvoices();
                group.inv_no = inv_nos;
                group.xmlName = xmlName;
                int rowsAffected = 0;

                string query = "UPDATE vw_salesinvoices " +
                   "SET    xmlName=@xmlName " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.xmlName

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //get_allinvoice_data


        public vw_salesinvoices get_allinvoice_data(string inv_nos)
        {
            vw_salesinvoices _objList = new vw_salesinvoices();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_salesinvoices   WHERE inv_no = '" + inv_nos + "'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.QueryFirstOrDefault<vw_salesinvoices>(query, commandType: CommandType.Text, param: dbParams);

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        #endregion
        #region vw_cr_salesinvoices
        public int Updatestatus_vw_cr_salesinvoices(vw_cr_salesinvoices group)
        {
            try
            {
                //group.ProcessZaca = "yes";
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_salesinvoices " +
                   "SET    ProcessZaca=@ProcessZaca,Post_back=@Post_back ,zaca_status=@zaca_status  ,Mail_sent=@Mail_sent  " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,
                            group.Post_back,
                            group.zaca_status,
                            group.Mail_sent,
                            group.ProcessZaca

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public long Insert_vw_cr_salesinvoices(vw_cr_salesinvoices group)
        {
            try
            {
                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
    INSERT INTO vw_cr_salesinvoices 
    (inv_index, inv_no, invref_no, InvRef_Date, instruction_code, 
    inv_type, inv_date, inv_time, issued_date, deli_date, actdeli_date, 
    tax_code, tax_exceptcode, except_reason, mode_ofpay, cur_code, 
    buy_name, gTot_LineExtAmount, gTotamnt_disc, gTotamnt_allow, 
    gTot_TaxExclAmount, gTotinvper_vat, gTotamnt_vat, gTotamnt_vatExch, 
    gTot_TaxInclAmount, proc_pending, branch_id, branch_code, 
    buy_vatno, buy_countrycode, buy_id, sel_typeId, buy_cityname, 
    buy_streetname, sel_buildingname, buy_buildno, buy_plotid, 
    buy_adbuildno, buy_postalzone, buy_citysubname, buy_countrySubentity, 
    idx_ztcaupload, buy_typeId, gTotamnt_prepaid, Eamil, no_lines, 
    RewBase64ID, ProcessZaca, Post_back, zaca_status, Mail_sent, 
    CUSTOMER_TRX_ID, zaca_status_detail, xmlName, TRX_SOURCE)
    VALUES
    (@inv_index, @inv_no, @invref_no, @InvRef_Date, @instruction_code, 
    @inv_type, @inv_date, @inv_time, @issued_date, @deli_date, @actdeli_date, 
    @tax_code, @tax_exceptcode, @except_reason, @mode_ofpay, @cur_code, 
    @buy_name, @gTot_LineExtAmount, @gTotamnt_disc, @gTotamnt_allow, 
    @gTot_TaxExclAmount, @gTotinvper_vat, @gTotamnt_vat, @gTotamnt_vatExch, 
    @gTot_TaxInclAmount, @proc_pending, @branch_id, @branch_code, 
    @buy_vatno, @buy_countrycode, @buy_id, @sel_typeId, @buy_cityname, 
    @buy_streetname, @sel_buildingname, @buy_buildno, @buy_plotid, 
    @buy_adbuildno, @buy_postalzone, @buy_citysubname, @buy_countrySubentity, 
    @idx_ztcaupload, @buy_typeId, @gTotamnt_prepaid, @Eamil, @no_lines, 
    @RewBase64ID, @ProcessZaca, @Post_back, @zaca_status, @Mail_sent, 
    @CUSTOMER_TRX_ID, @zaca_status_detail, @xmlName, @TRX_SOURCE);
    SELECT CAST(SCOPE_IDENTITY() AS INT)";


                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    //RewBase64ID,ProcessZaca
                    parameters.Add("@rec_index", group.rec_index);
                    parameters.Add("@inv_index", group.inv_index);
                    parameters.Add("@inv_no", group.inv_no?.Trim());
                    parameters.Add("@invref_no", group.invref_no?.Trim());
                    parameters.Add("@InvRef_Date", group.InvRef_Date?.Trim());
                    parameters.Add("@instruction_code", group.instruction_code?.Trim());
                    parameters.Add("@inv_type", group.inv_type?.Trim());
                    parameters.Add("@inv_date", group.inv_date?.Trim());
                    parameters.Add("@inv_time", group.inv_time?.Trim());
                    parameters.Add("@issued_date", group.issued_date?.Trim());
                    parameters.Add("@deli_date", group.deli_date?.Trim());
                    parameters.Add("@actdeli_date", group.actdeli_date?.Trim());
                    parameters.Add("@tax_code", group.tax_code?.Trim());
                    parameters.Add("@tax_exceptcode", group.tax_exceptcode?.Trim());
                    parameters.Add("@except_reason", group.except_reason?.Trim());
                    parameters.Add("@mode_ofpay", group.mode_ofpay?.Trim());
                    parameters.Add("@cur_code", group.cur_code?.Trim());
                    parameters.Add("@buy_name", group.buy_name?.Trim());
                    parameters.Add("@gTot_LineExtAmount", group.gTot_LineExtAmount?.Trim());
                    parameters.Add("@gTotamnt_disc", group.gTotamnt_disc?.Trim());
                    parameters.Add("@gTotamnt_allow", group.gTotamnt_allow?.Trim());
                    parameters.Add("@gTot_TaxExclAmount", group.gTot_TaxExclAmount?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTotinvper_vat", group.gTotinvper_vat?.Trim());
                    parameters.Add("@gTotamnt_vat", group.gTotamnt_vat?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTot_TaxInclAmount", group.gTot_TaxInclAmount?.Trim());
                    parameters.Add("@proc_pending", group.proc_pending?.Trim());
                    parameters.Add("@branch_id", group.branch_id?.Trim());
                    parameters.Add("@branch_code", group.branch_code?.Trim());
                    parameters.Add("@buy_vatno", group.buy_vatno?.Trim());
                    parameters.Add("@buy_countrycode", group.buy_countrycode?.Trim());
                    parameters.Add("@buy_id", group.buy_id?.Trim());
                    parameters.Add("@sel_typeId", group.sel_typeId?.Trim());
                    parameters.Add("@buy_cityname", group.buy_cityname?.Trim());
                    parameters.Add("@buy_streetname", group.buy_streetname?.Trim());
                    parameters.Add("@sel_buildingname", group.sel_buildingname?.Trim());
                    parameters.Add("@buy_buildno", group.buy_buildno?.Trim());
                    parameters.Add("@buy_plotid", group.buy_plotid?.Trim());
                    parameters.Add("@buy_adbuildno", group.buy_adbuildno?.Trim());
                    parameters.Add("@buy_postalzone", group.buy_postalzone?.Trim());
                    parameters.Add("@buy_citysubname", group.buy_citysubname?.Trim());
                    parameters.Add("@buy_countrySubentity", group.buy_countrySubentity?.Trim());
                    parameters.Add("@idx_ztcaupload", group.idx_ztcaupload?.Trim());
                    parameters.Add("@buy_typeId", group.buy_typeId?.Trim());
                    parameters.Add("@gTotamnt_prepaid", group.gTotamnt_prepaid?.Trim());
                    parameters.Add("@Eamil", group.Eamil?.Trim());
                    parameters.Add("@no_lines", group.no_lines);
                    parameters.Add("@RewBase64ID", group.RewBase64ID?.Trim());
                    parameters.Add("@ProcessZaca", group.ProcessZaca?.Trim());
                    parameters.Add("@Post_back", group.Post_back?.Trim());
                    parameters.Add("@zaca_status", group.zaca_status?.Trim());
                    parameters.Add("@Mail_sent", group.Mail_sent?.Trim());
                    parameters.Add("@CUSTOMER_TRX_ID", group.CUSTOMER_TRX_ID?.Trim());
                    parameters.Add("@zaca_status_detail", group.zaca_status_detail?.Trim());
                    parameters.Add("@xmlName", group.xmlName?.Trim());
                    parameters.Add("@TRX_SOURCE", group.TRX_SOURCE);
                    // parameters.Add("@gTotamnt_payable", group.gTotamnt_payable?.Trim());
                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }


                return insertedId;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<vw_cr_salesinvoices> GetAll_vw_cr_salesinvoices()
        {
            List<vw_cr_salesinvoices> _objList = new List<vw_cr_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_cr_salesinvoices where inv_type='Standard Credit Note' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_cr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        //
        public int Update_vw_cr_salesinvoices(vw_cr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_salesinvoices " +
                   "SET    inv_index=@inv_index " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,


                            group.inv_index

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Delete_dublicate_vw_cr_salesinvoices(vw_cr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "DELETE FROM vw_cr_saleinvoicesdetails WHERE inv_no = @inv_no; " +
                     "DELETE FROM vw_cr_salesinvoices WHERE inv_no = @inv_no;";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Insert_vw_cr_saleinvoicesdetails(vw_cr_saleinvoicesdetails details)
        {
            try
            {


                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
        INSERT INTO vw_cr_saleinvoicesdetails (
            inv_index, rec_index, item_description, item_qty, item_unit,
            item_price, lineExtAmount, amnt_disc, taxExclAmount, per_vat,
            tax_code, tax_exceptcode, except_reason, amnt_vat, taxInclAmount, inv_no
        )
        VALUES (
            @inv_index, @rec_index, @item_description, @item_qty, @item_unit,
            @item_price, @lineExtAmount, @amnt_disc, @taxExclAmount, @per_vat,
            @tax_code, @tax_exceptcode, @except_reason, @amnt_vat, @taxInclAmount, @inv_no
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@inv_index", details.inv_index);
                    parameters.Add("@rec_index", details.rec_index);
                    parameters.Add("@item_description", details.item_description);
                    parameters.Add("@item_qty", details.item_qty);
                    parameters.Add("@item_unit", details.item_unit);
                    parameters.Add("@item_price", details.item_price);
                    parameters.Add("@lineExtAmount", details.lineExtAmount);
                    parameters.Add("@amnt_disc", details.amnt_disc);
                    parameters.Add("@taxExclAmount", details.taxExclAmount);
                    parameters.Add("@per_vat", details.per_vat);
                    parameters.Add("@tax_code", details.tax_code);
                    parameters.Add("@tax_exceptcode", details.tax_exceptcode);
                    parameters.Add("@except_reason", details.except_reason);
                    parameters.Add("@amnt_vat", details.amnt_vat);
                    parameters.Add("@taxInclAmount", details.taxInclAmount);
                    parameters.Add("@inv_no", details.inv_no);

                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }

                rowsAffected = insertedId != 0 ? 1 : 0;
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //update zaca_status_detail
        public int Update_zaca_status_detail_vw_cr_salesinvoices(string inv_nos, string zaca_status_details)
        {
            try
            {
                vw_cr_salesinvoices group = new vw_cr_salesinvoices();
                group.inv_no = inv_nos;
                group.zaca_status_detail = zaca_status_details;
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_salesinvoices " +
                   "SET    zaca_status_detail=@zaca_status_detail " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.zaca_status_detail

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //update_xml_name_for_attachemnt
        public int update_xml_name_for_attachemnt_vw_cr_salesinvoices(string inv_nos, string xmlName)
        {
            try
            {
                vw_cr_salesinvoices group = new vw_cr_salesinvoices();
                group.inv_no = inv_nos;
                group.xmlName = xmlName;
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_salesinvoices " +
                   "SET    xmlName=@xmlName " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.xmlName

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //get_allinvoice_data


        public vw_cr_salesinvoices get_allinvoice_data_vw_cr_salesinvoices(string inv_nos)
        {
            vw_cr_salesinvoices _objList = new vw_cr_salesinvoices();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_cr_salesinvoices   WHERE inv_no = '" + inv_nos + "'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.QueryFirstOrDefault<vw_cr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams);

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }

        #endregion
        //vw_dr_salesinvoices
        #region vw_dr_salesinvoices
        public int Updatestatus_vw_dr_salesinvoices(vw_dr_salesinvoices group)
        {
            try
            {
                //group.ProcessZaca = "yes";
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_salesinvoices " +
                   "SET    ProcessZaca=@ProcessZaca,Post_back=@Post_back ,zaca_status=@zaca_status  ,Mail_sent=@Mail_sent  " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,
                            group.Post_back,
                            group.zaca_status,
                            group.Mail_sent,
                            group.ProcessZaca

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public long Insert_vw_dr_salesinvoices(vw_dr_salesinvoices group)
        {
            try
            {
                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
    INSERT INTO vw_dr_salesinvoices 
    (inv_index, inv_no, refinv_no, InvRef_Date, instruction_code, 
    inv_type, inv_date, inv_time, deli_date, actdeli_date, mode_ofpay, cur_code, 
    buy_name, gTot_LineExtAmount, gTotamnt_disc, gTotamnt_allow, 
    gTot_TaxExclAmount, gTotinvper_vat, gTotamnt_vat, gTotamnt_vatExch, 
    gTot_TaxInclAmount, proc_pending, branch_id, branch_code, 
    buy_vatno, buy_countrycode, buy_id, buy_typeId, buy_cityname, 
    buy_streetname, buy_buildingname, buy_buildno, buy_plotid, 
    buy_adbuildno, buy_postalzone, buy_subcitysubname, buy_countrySubentity, 
    idx_ztcaupload, no_lines, Eamil, RewBase64ID, 
    ProcessZaca, Post_back, zaca_status, Mail_sent, 
    CUSTOMER_TRX_ID, zaca_status_detail, xmlName, Totamnt_allow, Totamnt_disc, gTotamnt_payable, gTotamnt_prepaid, TRX_SOURCE)
    VALUES
    (@inv_index, @inv_no, @refinv_no, @InvRef_Date, @instruction_code, 
    @inv_type, @inv_date, @inv_time, @deli_date, @actdeli_date, @mode_ofpay, @cur_code, 
    @buy_name, @gTot_LineExtAmount, @gTotamnt_disc, @gTotamnt_allow, 
    @gTot_TaxExclAmount, @gTotinvper_vat, @gTotamnt_vat, @gTotamnt_vatExch, 
    @gTot_TaxInclAmount, @proc_pending, @branch_id, @branch_code, 
    @buy_vatno, @buy_countrycode, @buy_id, @buy_typeId, @buy_cityname, 
    @buy_streetname, @buy_buildingname, @buy_buildno, @buy_plotid, 
    @buy_adbuildno, @buy_postalzone, @buy_subcitysubname, @buy_countrySubentity, 
    @idx_ztcaupload, @no_lines, @Eamil,  @RewBase64ID, 
    @ProcessZaca, @Post_back, @zaca_status, @Mail_sent, 
    @CUSTOMER_TRX_ID, @zaca_status_detail, @xmlName, @Totamnt_allow, @Totamnt_disc, @gTotamnt_payable, @gTotamnt_prepaid, @TRX_SOURCE);
    SELECT CAST(SCOPE_IDENTITY() AS INT)";


                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    //gTotamnt_payable
                    parameters.Add("@gTotamnt_payable", group.gTot_TaxInclAmount);
                    //Totamnt_allow
                    parameters.Add("@Totamnt_allow", group.Totamnt_allow);
                    //Totamnt_disc
                    parameters.Add("@Totamnt_disc", group.Totamnt_disc);
                    parameters.Add("@inv_index", group.inv_index);
                    parameters.Add("@inv_no", group.inv_no?.Trim());
                    parameters.Add("@refinv_no", group.refinv_no?.Trim());
                    parameters.Add("@InvRef_Date", group.InvRef_Date?.Trim());
                    parameters.Add("@instruction_code", group.instruction_code?.Trim());
                    parameters.Add("@inv_type", group.inv_type?.Trim());
                    parameters.Add("@inv_date", group.inv_date?.Trim());
                    parameters.Add("@inv_time", group.inv_time?.Trim());
                    //parameters.Add("@issued_date", group.issued_date?.Trim());
                    parameters.Add("@deli_date", group.deli_date?.Trim());
                    parameters.Add("@actdeli_date", group.actdeli_date?.Trim());

                    parameters.Add("@mode_ofpay", group.mode_ofpay?.Trim());
                    parameters.Add("@cur_code", group.cur_code?.Trim());
                    parameters.Add("@buy_name", group.buy_name?.Trim());
                    parameters.Add("@gTot_LineExtAmount", group.gTot_LineExtAmount?.Trim());
                    parameters.Add("@gTotamnt_disc", group.gTotamnt_disc?.Trim());
                    parameters.Add("@gTotamnt_allow", group.gTotamnt_allow?.Trim());
                    parameters.Add("@gTot_TaxExclAmount", group.gTot_TaxExclAmount?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTotinvper_vat", group.gTotinvper_vat?.Trim());
                    parameters.Add("@gTotamnt_vat", group.gTotamnt_vat?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTot_TaxInclAmount", group.gTot_TaxInclAmount?.Trim());
                    parameters.Add("@proc_pending", group.proc_pending?.Trim());
                    parameters.Add("@branch_id", group.branch_id?.Trim());
                    parameters.Add("@branch_code", group.branch_code?.Trim());
                    parameters.Add("@buy_vatno", group.buy_vatno?.Trim());
                    parameters.Add("@buy_countrycode", group.buy_countrycode?.Trim());
                    parameters.Add("@buy_id", group.buy_id?.Trim());

                    parameters.Add("@buy_cityname", group.buy_cityname?.Trim());
                    parameters.Add("@buy_streetname", group.buy_streetname?.Trim());
                    parameters.Add("@buy_buildingname", group.buy_buildingname?.Trim());//parameters.Add("@sel_buildingname", group.sel_buildingname?.Trim());
                    parameters.Add("@buy_buildno", group.buy_buildno?.Trim());
                    parameters.Add("@buy_plotid", group.buy_plotid?.Trim());
                    parameters.Add("@buy_adbuildno", group.buy_adbuildno?.Trim());
                    parameters.Add("@buy_postalzone", group.buy_postalzone?.Trim());
                    parameters.Add("@buy_subcitysubname", group.buy_subcitysubname?.Trim());//parameters.Add("@buy_citysubname", group.buy_citysubname?.Trim());
                    parameters.Add("@buy_countrySubentity", group.buy_countrySubentity?.Trim());
                    parameters.Add("@idx_ztcaupload", group.idx_ztcaupload?.Trim());
                    parameters.Add("@buy_typeId", group.buy_typeId?.Trim());
                    parameters.Add("@gTotamnt_prepaid", group.gTotamnt_prepaid?.Trim());
                    parameters.Add("@Eamil", group.Eamil?.Trim());
                    parameters.Add("@no_lines", group.no_lines);
                    parameters.Add("@RewBase64ID", group.RewBase64ID?.Trim());
                    parameters.Add("@ProcessZaca", group.ProcessZaca?.Trim());
                    parameters.Add("@Post_back", group.Post_back?.Trim());
                    parameters.Add("@zaca_status", group.zaca_status?.Trim());
                    parameters.Add("@Mail_sent", group.Mail_sent?.Trim());
                    parameters.Add("@CUSTOMER_TRX_ID", group.CUSTOMER_TRX_ID?.Trim());
                    parameters.Add("@zaca_status_detail", group.zaca_status_detail?.Trim());
                    parameters.Add("@xmlName", group.xmlName?.Trim());
                    parameters.Add("@TRX_SOURCE", group.TRX_SOURCE);
                    // parameters.Add("@gTotamnt_payable", group.gTotamnt_payable?.Trim());
                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }


                return insertedId;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<vw_dr_salesinvoices> GetAll_vw_dr_salesinvoices()
        {
            List<vw_dr_salesinvoices> _objList = new List<vw_dr_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_dr_salesinvoices where inv_type='Standard Debit Note' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_dr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        //
        public int Update_vw_dr_salesinvoices(vw_dr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_salesinvoices " +
                   "SET    inv_index=@inv_index " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,


                            group.inv_index

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Delete_dublicate_vw_dr_salesinvoices(vw_dr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "DELETE FROM vw_dr_saleinvoicesdetails WHERE inv_no = @inv_no; " +
                     "DELETE FROM vw_dr_salesinvoices WHERE inv_no = @inv_no;";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Insert_vw_dr_saleinvoicesdetails(vw_dr_saleinvoicesdetails details)
        {
            try
            {


                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
        INSERT INTO vw_dr_saleinvoicesdetails (
            inv_index, rec_index, item_description, item_qty, item_unit,
            item_price, lineExtAmount, amnt_disc, taxExclAmount, per_vat,
            tax_code, tax_exceptcode, except_reason, amnt_vat, taxInclAmount, inv_no
        )
        VALUES (
            @inv_index, @rec_index, @item_description, @item_qty, @item_unit,
            @item_price, @lineExtAmount, @amnt_disc, @taxExclAmount, @per_vat,
            @tax_code, @tax_exceptcode, @except_reason, @amnt_vat, @taxInclAmount, @inv_no
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@inv_index", details.inv_index);
                    parameters.Add("@rec_index", details.rec_index);
                    parameters.Add("@item_description", details.item_description);
                    parameters.Add("@item_qty", details.item_qty);
                    parameters.Add("@item_unit", details.item_unit);
                    parameters.Add("@item_price", details.item_price);
                    parameters.Add("@lineExtAmount", details.lineExtAmount);
                    parameters.Add("@amnt_disc", details.amnt_disc);
                    parameters.Add("@taxExclAmount", details.taxExclAmount);
                    parameters.Add("@per_vat", details.per_vat);
                    parameters.Add("@tax_code", details.tax_code);
                    parameters.Add("@tax_exceptcode", details.tax_exceptcode);
                    parameters.Add("@except_reason", details.except_reason);
                    parameters.Add("@amnt_vat", details.amnt_vat);
                    parameters.Add("@taxInclAmount", details.taxInclAmount);
                    parameters.Add("@inv_no", details.inv_no);

                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }

                rowsAffected = insertedId != 0 ? 1 : 0;
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //update zaca_status_detail
        public int Update_zaca_status_detail_vw_dr_salesinvoices(string inv_nos, string zaca_status_details)
        {
            try
            {
                vw_dr_salesinvoices group = new vw_dr_salesinvoices();
                group.inv_no = inv_nos;
                group.zaca_status_detail = zaca_status_details;
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_salesinvoices " +
                   "SET    zaca_status_detail=@zaca_status_detail " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.zaca_status_detail

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //update_xml_name_for_attachemnt
        public int update_xml_name_for_attachemnt_vw_dr_salesinvoices(string inv_nos, string xmlName)
        {
            try
            {
                vw_dr_salesinvoices group = new vw_dr_salesinvoices();
                group.inv_no = inv_nos;
                group.xmlName = xmlName;
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_salesinvoices " +
                   "SET    xmlName=@xmlName " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.xmlName

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //get_allinvoice_data


        public vw_dr_salesinvoices get_allinvoice_data_vw_dr_salesinvoices(string inv_nos)
        {
            vw_dr_salesinvoices _objList = new vw_dr_salesinvoices();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_dr_salesinvoices   WHERE inv_no = '" + inv_nos + "'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.QueryFirstOrDefault<vw_dr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams);

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }

        #endregion

        #region attachemnt_mail
        public int InsertAttachmentMail(attachemnt_mail group)
        {
            try
            {
                group.xml_creation_date = DateTime.Now;
                int rowsAffected = 0;

                string query = "INSERT INTO attachemnt_mail(inv_index, inv_no, inve_type, xml_name ,xml_creation_date, xml_path, ZacaRes, ZacaPath) " +
                                                  "VALUES (@inv_index, @inv_no,  @inve_type , @xml_name, @xml_creation_date, @xml_path, @ZacaRes, @ZacaPath)";

                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {
                            group.inv_index,
                            //

                            group.inv_no,
                            group.inve_type,
                            group.xml_name,
                            group.xml_creation_date,
                            group.xml_path,
                            group.ZacaRes,
                            group.ZacaPath

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region cash
        #region vw_cashsalesinvoices
        public int Updatestatus_vw_salesinvoicesr_vw_cashsalesinvoices(vw_salesinvoices group)
        {
            try
            {
                // group.ProcessZaca = "yes";
                int rowsAffected = 0;

                string query = "UPDATE vw_cashsalesinvoices " +
                   "SET    ProcessZaca=@ProcessZaca,Post_back=@Post_back ,zaca_status=@zaca_status  ,Mail_sent=@Mail_sent  " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,
                            group.Post_back,
                            group.zaca_status,
                            group.Mail_sent,
                            group.ProcessZaca

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }

        public List<vw_salesinvoices> GetAdel_from_tblprocessPIHllvw_salesinvoices_vw_cashsalesinvoices()
        {
            List<vw_salesinvoices> _objList = new List<vw_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_cashsalesinvoices where inv_type='Standard Invoice' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        public List<vw_salesinvoices> GetAllvw_salesinvoices_vw_cashsalesinvoices()
        {
            List<vw_salesinvoices> _objList = new List<vw_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_cashsalesinvoices where inv_type='Simplified Invoice' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        public long InsertSalesInvoice_vw_cashsalesinvoices(vw_salesinvoices group)
        {
            try
            {
                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
INSERT INTO vw_cashsalesinvoices (
   inv_no, inv_type, inv_date, inv_time, deli_date, actdeli_date,
    mode_ofpay, cur_code, Totamnt_disc, Totamnt_allow, buy_name,
    gTot_LineExtAmount, gTotamnt_disc, gTotamnt_allow, gTot_TaxExclAmount,
    gTotamnt_vatExch, gTotinvper_vat, gTotamnt_vat, gTotamnt_prepaid,
    gTot_TaxInclAmount, gTotamnt_payable, proc_pending, branch_id, branch_code,
    buy_vatno, buy_countrycode, buy_id, buy_typeId, buy_cityname, buy_streetname,
    buy_buildingname, buy_buildno, buy_plotid, buy_adbuildno, buy_postalzone,
    buy_subcitysubname, buy_countrySubentity, idx_ztcaupload, Eamil, no_lines,RewBase64ID,ProcessZaca,CUSTOMER_TRX_ID, TRX_SOURCE
)
VALUES (
    @inv_no,@inv_type, @inv_date, @inv_time, @deli_date, @actdeli_date,
    @mode_ofpay, @cur_code, @Totamnt_disc, @Totamnt_allow, @buy_name,
    @gTot_LineExtAmount, @gTotamnt_disc, @gTotamnt_allow, @gTot_TaxExclAmount,
    @gTotamnt_vatExch, @gTotinvper_vat, @gTotamnt_vat, @gTotamnt_prepaid,
    @gTot_TaxInclAmount, @gTotamnt_payable, @proc_pending, @branch_id, @branch_code,
    @buy_vatno, @buy_countrycode, @buy_id, @buy_typeId, @buy_cityname, @buy_streetname,
    @buy_buildingname, @buy_buildno, @buy_plotid, @buy_adbuildno, @buy_postalzone,
    @buy_subcitysubname, @buy_countrySubentity, @idx_ztcaupload, @Eamil, @no_lines , @RewBase64ID, @ProcessZaca, @CUSTOMER_TRX_ID, @TRX_SOURCE
);
SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    //RewBase64ID,ProcessZaca
                    parameters.Add("@RewBase64ID", group.RewBase64ID?.Trim());
                    parameters.Add("@ProcessZaca", group.ProcessZaca?.Trim());
                    //CUSTOMER_TRX_ID
                    parameters.Add("@CUSTOMER_TRX_ID", group.CUSTOMER_TRX_ID?.Trim());
                    parameters.Add("@inv_no", group.inv_no?.Trim());
                    parameters.Add("@inv_type", group.inv_type?.Trim());
                    parameters.Add("@inv_date", group.inv_date?.Trim());
                    parameters.Add("@inv_time", group.inv_time?.Trim());
                    parameters.Add("@deli_date", group.deli_date?.Trim());
                    parameters.Add("@actdeli_date", group.actdeli_date?.Trim());
                    parameters.Add("@mode_ofpay", group.mode_ofpay?.Trim());
                    parameters.Add("@cur_code", group.cur_code?.Trim());
                    parameters.Add("@Totamnt_disc", group.Totamnt_disc);
                    parameters.Add("@Totamnt_allow", group.Totamnt_allow);
                    parameters.Add("@buy_name", group.buy_name?.Trim());
                    parameters.Add("@gTot_LineExtAmount", group.gTot_LineExtAmount);
                    parameters.Add("@gTotamnt_disc", group.gTotamnt_disc);
                    parameters.Add("@gTotamnt_allow", group.gTotamnt_allow);
                    parameters.Add("@gTot_TaxExclAmount", group.gTot_TaxExclAmount);
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTotinvper_vat", group.gTotinvper_vat);
                    parameters.Add("@gTotamnt_vat", group.gTotamnt_vat);
                    parameters.Add("@gTotamnt_prepaid", group.gTotamnt_prepaid);
                    parameters.Add("@gTot_TaxInclAmount", group.gTot_TaxInclAmount);
                    parameters.Add("@gTotamnt_payable", group.gTotamnt_payable);
                    parameters.Add("@proc_pending", group.proc_pending?.Trim());
                    parameters.Add("@branch_id", group.branch_id);
                    parameters.Add("@branch_code", group.branch_code?.Trim());
                    parameters.Add("@buy_vatno", group.buy_vatno?.Trim());
                    parameters.Add("@buy_countrycode", group.buy_countrycode?.Trim());
                    parameters.Add("@buy_id", group.buy_id?.Trim());
                    parameters.Add("@buy_typeId", group.buy_typeId?.Trim());
                    parameters.Add("@buy_cityname", group.buy_cityname?.Trim());
                    parameters.Add("@buy_streetname", group.buy_streetname?.Trim());
                    parameters.Add("@buy_buildingname", group.buy_buildingname?.Trim());
                    parameters.Add("@buy_buildno", group.buy_buildno?.Trim());
                    parameters.Add("@buy_plotid", group.buy_plotid?.Trim());
                    parameters.Add("@buy_adbuildno", group.buy_adbuildno?.Trim());
                    parameters.Add("@buy_postalzone", group.buy_postalzone?.Trim());
                    parameters.Add("@buy_subcitysubname", group.buy_subcitysubname?.Trim());
                    parameters.Add("@buy_countrySubentity", group.buy_countrySubentity?.Trim());
                    parameters.Add("@idx_ztcaupload", group.idx_ztcaupload);
                    parameters.Add("@Eamil", group.Eamil?.Trim());
                    parameters.Add("@no_lines", group.no_lines);
                    parameters.Add("@TRX_SOURCE", group.TRX_SOURCE);
                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }


                return insertedId;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update_vw_salesinvoicesr_vw_cashsalesinvoices(vw_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "UPDATE vw_cashsalesinvoices " +
                   "SET    inv_index=@inv_index " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,


                            group.inv_index

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Delete_dublicate_inv_no_vw_cashsalesinvoices(vw_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "DELETE FROM vw_cashsaleinvoicesdetails WHERE inv_no = @inv_no; " +
                     "DELETE FROM vw_cashsalesinvoices WHERE inv_no = @inv_no;";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int InsertCASHInvoiceDetails(vw_saleinvoicesdetails details)
        {
            try
            {


                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
        INSERT INTO vw_cashsaleinvoicesdetails (
            inv_index, rec_index, item_description, item_qty, item_unit,
            item_price, lineExtAmount, amnt_disc, taxExclAmount, per_vat,
            tax_code, tax_exceptcode, except_reason, amnt_vat, taxInclAmount, inv_no
        )
        VALUES (
            @inv_index, @rec_index, @item_description, @item_qty, @item_unit,
            @item_price, @lineExtAmount, @amnt_disc, @taxExclAmount, @per_vat,
            @tax_code, @tax_exceptcode, @except_reason, @amnt_vat, @taxInclAmount, @inv_no
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@inv_index", details.inv_index);
                    parameters.Add("@rec_index", details.rec_index);
                    parameters.Add("@item_description", details.item_description);
                    parameters.Add("@item_qty", details.item_qty);
                    parameters.Add("@item_unit", details.item_unit);
                    parameters.Add("@item_price", details.item_price);
                    parameters.Add("@lineExtAmount", details.lineExtAmount);
                    parameters.Add("@amnt_disc", details.amnt_disc);
                    parameters.Add("@taxExclAmount", details.taxExclAmount);
                    parameters.Add("@per_vat", details.per_vat);
                    parameters.Add("@tax_code", details.tax_code);
                    parameters.Add("@tax_exceptcode", details.tax_exceptcode);
                    parameters.Add("@except_reason", details.except_reason);
                    parameters.Add("@amnt_vat", details.amnt_vat);
                    parameters.Add("@taxInclAmount", details.taxInclAmount);
                    parameters.Add("@inv_no", details.inv_no);

                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }

                rowsAffected = insertedId != 0 ? 1 : 0;
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //update zaca_status_detail
        public int Update_zaca_status_detail_vw_cashsalesinvoices(string inv_nos, string zaca_status_details)
        {
            try
            {
                vw_salesinvoices group = new vw_salesinvoices();
                group.inv_no = inv_nos;
                group.zaca_status_detail = zaca_status_details;
                int rowsAffected = 0;

                string query = "UPDATE vw_cashsalesinvoices " +
                   "SET    zaca_status_detail=@zaca_status_detail " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.zaca_status_detail

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //update_xml_name_for_attachemnt
        public int update_xml_name_for_attachemnt_vw_cashsalesinvoices(string inv_nos, string xmlName)
        {
            try
            {
                vw_salesinvoices group = new vw_salesinvoices();
                group.inv_no = inv_nos;
                group.xmlName = xmlName;
                int rowsAffected = 0;

                string query = "UPDATE vw_cashsalesinvoices " +
                   "SET    xmlName=@xmlName " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.xmlName

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //get_allinvoice_data


        public vw_salesinvoices get_allinvoice_data_vw_cashsalesinvoices(string inv_nos)
        {
            vw_salesinvoices _objList = new vw_salesinvoices();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_cashsalesinvoices   WHERE inv_no = '" + inv_nos + "'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.QueryFirstOrDefault<vw_salesinvoices>(query, commandType: CommandType.Text, param: dbParams);

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        #endregion

        #region vw_dr_cashsalesinvoices  vw_dr_salesinvoices
        #region vw_dr_cashsalesinvoices
        public int Updatestatus_vw_dr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                //group.ProcessZaca = "yes";
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_cashsalesinvoices " +
                   "SET    ProcessZaca=@ProcessZaca,Post_back=@Post_back ,zaca_status=@zaca_status  ,Mail_sent=@Mail_sent  " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,
                            group.Post_back,
                            group.zaca_status,
                            group.Mail_sent,
                            group.ProcessZaca

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public long Insert_vw_dr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
    INSERT INTO vw_dr_cashsalesinvoices 
    (inv_index, inv_no, refinv_no, InvRef_Date, instruction_code, 
    inv_type, inv_date, inv_time, deli_date, actdeli_date, mode_ofpay, cur_code, 
    buy_name, gTot_LineExtAmount, gTotamnt_disc, gTotamnt_allow, 
    gTot_TaxExclAmount, gTotinvper_vat, gTotamnt_vat, gTotamnt_vatExch, 
    gTot_TaxInclAmount, proc_pending, branch_id, branch_code, 
    buy_vatno, buy_countrycode, buy_id, buy_typeId, buy_cityname, 
    buy_streetname, buy_buildingname, buy_buildno, buy_plotid, 
    buy_adbuildno, buy_postalzone, buy_subcitysubname, buy_countrySubentity, 
    idx_ztcaupload, no_lines, Eamil, RewBase64ID, 
    ProcessZaca, Post_back, zaca_status, Mail_sent, 
    CUSTOMER_TRX_ID, zaca_status_detail, xmlName, Totamnt_allow, Totamnt_disc, gTotamnt_payable, gTotamnt_prepaid, TRX_SOURCE)
    VALUES
    (@inv_index, @inv_no, @refinv_no, @InvRef_Date, @instruction_code, 
    @inv_type, @inv_date, @inv_time, @deli_date, @actdeli_date, @mode_ofpay, @cur_code, 
    @buy_name, @gTot_LineExtAmount, @gTotamnt_disc, @gTotamnt_allow, 
    @gTot_TaxExclAmount, @gTotinvper_vat, @gTotamnt_vat, @gTotamnt_vatExch, 
    @gTot_TaxInclAmount, @proc_pending, @branch_id, @branch_code, 
    @buy_vatno, @buy_countrycode, @buy_id, @buy_typeId, @buy_cityname, 
    @buy_streetname, @buy_buildingname, @buy_buildno, @buy_plotid, 
    @buy_adbuildno, @buy_postalzone, @buy_subcitysubname, @buy_countrySubentity, 
    @idx_ztcaupload, @no_lines, @Eamil,  @RewBase64ID, 
    @ProcessZaca, @Post_back, @zaca_status, @Mail_sent, 
    @CUSTOMER_TRX_ID, @zaca_status_detail, @xmlName, @Totamnt_allow, @Totamnt_disc, @gTotamnt_payable, @gTotamnt_prepaid, @TRX_SOURCE);
    SELECT CAST(SCOPE_IDENTITY() AS INT)";


                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    //gTotamnt_payable
                    parameters.Add("@gTotamnt_payable", group.gTot_TaxInclAmount);
                    //Totamnt_allow
                    parameters.Add("@Totamnt_allow", group.Totamnt_allow);
                    //Totamnt_disc
                    parameters.Add("@Totamnt_disc", group.Totamnt_disc);
                    parameters.Add("@inv_index", group.inv_index);
                    parameters.Add("@inv_no", group.inv_no?.Trim());
                    parameters.Add("@refinv_no", group.refinv_no?.Trim());
                    parameters.Add("@InvRef_Date", group.InvRef_Date?.Trim());
                    parameters.Add("@instruction_code", group.instruction_code?.Trim());
                    parameters.Add("@inv_type", group.inv_type?.Trim());
                    parameters.Add("@inv_date", group.inv_date?.Trim());
                    parameters.Add("@inv_time", group.inv_time?.Trim());
                    //parameters.Add("@issued_date", group.issued_date?.Trim());
                    parameters.Add("@deli_date", group.deli_date?.Trim());
                    parameters.Add("@actdeli_date", group.actdeli_date?.Trim());

                    parameters.Add("@mode_ofpay", group.mode_ofpay?.Trim());
                    parameters.Add("@cur_code", group.cur_code?.Trim());
                    parameters.Add("@buy_name", group.buy_name?.Trim());
                    parameters.Add("@gTot_LineExtAmount", group.gTot_LineExtAmount?.Trim());
                    parameters.Add("@gTotamnt_disc", group.gTotamnt_disc?.Trim());
                    parameters.Add("@gTotamnt_allow", group.gTotamnt_allow?.Trim());
                    parameters.Add("@gTot_TaxExclAmount", group.gTot_TaxExclAmount?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTotinvper_vat", group.gTotinvper_vat?.Trim());
                    parameters.Add("@gTotamnt_vat", group.gTotamnt_vat?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTot_TaxInclAmount", group.gTot_TaxInclAmount?.Trim());
                    parameters.Add("@proc_pending", group.proc_pending?.Trim());
                    parameters.Add("@branch_id", group.branch_id?.Trim());
                    parameters.Add("@branch_code", group.branch_code?.Trim());
                    parameters.Add("@buy_vatno", group.buy_vatno?.Trim());
                    parameters.Add("@buy_countrycode", group.buy_countrycode?.Trim());
                    parameters.Add("@buy_id", group.buy_id?.Trim());

                    parameters.Add("@buy_cityname", group.buy_cityname?.Trim());
                    parameters.Add("@buy_streetname", group.buy_streetname?.Trim());
                    parameters.Add("@buy_buildingname", group.buy_buildingname?.Trim());//parameters.Add("@sel_buildingname", group.sel_buildingname?.Trim());
                    parameters.Add("@buy_buildno", group.buy_buildno?.Trim());
                    parameters.Add("@buy_plotid", group.buy_plotid?.Trim());
                    parameters.Add("@buy_adbuildno", group.buy_adbuildno?.Trim());
                    parameters.Add("@buy_postalzone", group.buy_postalzone?.Trim());
                    parameters.Add("@buy_subcitysubname", group.buy_subcitysubname?.Trim());//parameters.Add("@buy_citysubname", group.buy_citysubname?.Trim());
                    parameters.Add("@buy_countrySubentity", group.buy_countrySubentity?.Trim());
                    parameters.Add("@idx_ztcaupload", group.idx_ztcaupload?.Trim());
                    parameters.Add("@buy_typeId", group.buy_typeId?.Trim());
                    parameters.Add("@gTotamnt_prepaid", group.gTotamnt_prepaid?.Trim());
                    parameters.Add("@Eamil", group.Eamil?.Trim());
                    parameters.Add("@no_lines", group.no_lines);
                    parameters.Add("@RewBase64ID", group.RewBase64ID?.Trim());
                    parameters.Add("@ProcessZaca", group.ProcessZaca?.Trim());
                    parameters.Add("@Post_back", group.Post_back?.Trim());
                    parameters.Add("@zaca_status", group.zaca_status?.Trim());
                    parameters.Add("@Mail_sent", group.Mail_sent?.Trim());
                    parameters.Add("@CUSTOMER_TRX_ID", group.CUSTOMER_TRX_ID?.Trim());
                    parameters.Add("@zaca_status_detail", group.zaca_status_detail?.Trim());
                    parameters.Add("@xmlName", group.xmlName?.Trim());
                    parameters.Add("@TRX_SOURCE", group.TRX_SOURCE);
                    // parameters.Add("@gTotamnt_payable", group.gTotamnt_payable?.Trim());
                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }


                return insertedId;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<vw_dr_salesinvoices> GetAll_vw_dr_salesinvoices_CASH()
        {
            List<vw_dr_salesinvoices> _objList = new List<vw_dr_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_dr_cashsalesinvoices where inv_type='Simplified Debit Note' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_dr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        //
        public int Update_vw_dr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_cashsalesinvoices " +
                   "SET    inv_index=@inv_index " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,


                            group.inv_index

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Delete_dublicate_vw_dr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "DELETE FROM vw_dr_cashsaleinvoicesdetails WHERE inv_no = @inv_no; " +
                     "DELETE FROM vw_dr_cashsalesinvoices WHERE inv_no = @inv_no;";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Insert_vw_dr_saleinvoicesdetails_CASH(vw_dr_saleinvoicesdetails details)
        {
            try
            {


                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
        INSERT INTO vw_dr_cashsaleinvoicesdetails (
            inv_index, rec_index, item_description, item_qty, item_unit,
            item_price, lineExtAmount, amnt_disc, taxExclAmount, per_vat,
            tax_code, tax_exceptcode, except_reason, amnt_vat, taxInclAmount, inv_no
        )
        VALUES (
            @inv_index, @rec_index, @item_description, @item_qty, @item_unit,
            @item_price, @lineExtAmount, @amnt_disc, @taxExclAmount, @per_vat,
            @tax_code, @tax_exceptcode, @except_reason, @amnt_vat, @taxInclAmount, @inv_no
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@inv_index", details.inv_index);
                    parameters.Add("@rec_index", details.rec_index);
                    parameters.Add("@item_description", details.item_description);
                    parameters.Add("@item_qty", details.item_qty);
                    parameters.Add("@item_unit", details.item_unit);
                    parameters.Add("@item_price", details.item_price);
                    parameters.Add("@lineExtAmount", details.lineExtAmount);
                    parameters.Add("@amnt_disc", details.amnt_disc);
                    parameters.Add("@taxExclAmount", details.taxExclAmount);
                    parameters.Add("@per_vat", details.per_vat);
                    parameters.Add("@tax_code", details.tax_code);
                    parameters.Add("@tax_exceptcode", details.tax_exceptcode);
                    parameters.Add("@except_reason", details.except_reason);
                    parameters.Add("@amnt_vat", details.amnt_vat);
                    parameters.Add("@taxInclAmount", details.taxInclAmount);
                    parameters.Add("@inv_no", details.inv_no);

                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }

                rowsAffected = insertedId != 0 ? 1 : 0;
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //update zaca_status_detail
        public int Update_zaca_status_detail_vw_dr_salesinvoices_CASH(string inv_nos, string zaca_status_details)
        {
            try
            {
                vw_dr_salesinvoices group = new vw_dr_salesinvoices();
                group.inv_no = inv_nos;
                group.zaca_status_detail = zaca_status_details;
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_cashsalesinvoices " +
                   "SET    zaca_status_detail=@zaca_status_detail " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.zaca_status_detail

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //update_xml_name_for_attachemnt
        public int update_xml_name_for_attachemnt_vw_dr_salesinvoices_CASH(string inv_nos, string xmlName)
        {
            try
            {
                vw_dr_salesinvoices group = new vw_dr_salesinvoices();
                group.inv_no = inv_nos;
                group.xmlName = xmlName;
                int rowsAffected = 0;

                string query = "UPDATE vw_dr_cashsalesinvoices " +
                   "SET    xmlName=@xmlName " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.xmlName

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //get_allinvoice_data


        public vw_dr_salesinvoices get_allinvoice_data_vw_dr_salesinvoices_CASH(string inv_nos)
        {
            vw_dr_salesinvoices _objList = new vw_dr_salesinvoices();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_dr_cashsalesinvoices   WHERE inv_no = '" + inv_nos + "'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.QueryFirstOrDefault<vw_dr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams);

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }

        #endregion
        #endregion

        #region vw_cr_cashsalesinvoices
        #region vw_cr_cashsalesinvoices
        public int Updatestatus_vw_cr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                //group.ProcessZaca = "yes";
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_cashsalesinvoices " +
                   "SET    ProcessZaca=@ProcessZaca,Post_back=@Post_back ,zaca_status=@zaca_status  ,Mail_sent=@Mail_sent  " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,
                            group.Post_back,
                            group.zaca_status,
                            group.Mail_sent,
                            group.ProcessZaca

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public long Insert_vw_cr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
    INSERT INTO vw_cr_cashsalesinvoices 
    (inv_index, inv_no, refinv_no, InvRef_Date, instruction_code, 
    inv_type, inv_date, inv_time, deli_date, actdeli_date, mode_ofpay, cur_code, 
    buy_name, gTot_LineExtAmount, gTotamnt_disc, gTotamnt_allow, 
    gTot_TaxExclAmount, gTotinvper_vat, gTotamnt_vat, gTotamnt_vatExch, 
    gTot_TaxInclAmount, proc_pending, branch_id, branch_code, 
    buy_vatno, buy_countrycode, buy_id, buy_typeId, buy_cityname, 
    buy_streetname, buy_buildingname, buy_buildno, buy_plotid, 
    buy_adbuildno, buy_postalzone, buy_subcitysubname, buy_countrySubentity, 
    idx_ztcaupload, no_lines, Eamil, RewBase64ID, 
    ProcessZaca, Post_back, zaca_status, Mail_sent, 
    CUSTOMER_TRX_ID, zaca_status_detail, xmlName, Totamnt_allow, Totamnt_disc, gTotamnt_payable, gTotamnt_prepaid, TRX_SOURCE)
    VALUES
    (@inv_index, @inv_no, @refinv_no, @InvRef_Date, @instruction_code, 
    @inv_type, @inv_date, @inv_time, @deli_date, @actdeli_date, @mode_ofpay, @cur_code, 
    @buy_name, @gTot_LineExtAmount, @gTotamnt_disc, @gTotamnt_allow, 
    @gTot_TaxExclAmount, @gTotinvper_vat, @gTotamnt_vat, @gTotamnt_vatExch, 
    @gTot_TaxInclAmount, @proc_pending, @branch_id, @branch_code, 
    @buy_vatno, @buy_countrycode, @buy_id, @buy_typeId, @buy_cityname, 
    @buy_streetname, @buy_buildingname, @buy_buildno, @buy_plotid, 
    @buy_adbuildno, @buy_postalzone, @buy_subcitysubname, @buy_countrySubentity, 
    @idx_ztcaupload, @no_lines, @Eamil,  @RewBase64ID, 
    @ProcessZaca, @Post_back, @zaca_status, @Mail_sent, 
    @CUSTOMER_TRX_ID, @zaca_status_detail, @xmlName, @Totamnt_allow, @Totamnt_disc, @gTotamnt_payable, @gTotamnt_prepaid, @TRX_SOURCE);
    SELECT CAST(SCOPE_IDENTITY() AS INT)";


                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    //gTotamnt_payable
                    parameters.Add("@gTotamnt_payable", group.gTot_TaxInclAmount);
                    //Totamnt_allow
                    parameters.Add("@Totamnt_allow", group.Totamnt_allow);
                    //Totamnt_disc
                    parameters.Add("@Totamnt_disc", group.Totamnt_disc);
                    parameters.Add("@inv_index", group.inv_index);
                    parameters.Add("@inv_no", group.inv_no?.Trim());
                    parameters.Add("@refinv_no", group.refinv_no?.Trim());
                    parameters.Add("@InvRef_Date", group.InvRef_Date?.Trim());
                    parameters.Add("@instruction_code", group.instruction_code?.Trim());
                    parameters.Add("@inv_type", group.inv_type?.Trim());
                    parameters.Add("@inv_date", group.inv_date?.Trim());
                    parameters.Add("@inv_time", group.inv_time?.Trim());
                    //parameters.Add("@issued_date", group.issued_date?.Trim());
                    parameters.Add("@deli_date", group.deli_date?.Trim());
                    parameters.Add("@actdeli_date", group.actdeli_date?.Trim());

                    parameters.Add("@mode_ofpay", group.mode_ofpay?.Trim());
                    parameters.Add("@cur_code", group.cur_code?.Trim());
                    parameters.Add("@buy_name", group.buy_name?.Trim());
                    parameters.Add("@gTot_LineExtAmount", group.gTot_LineExtAmount?.Trim());
                    parameters.Add("@gTotamnt_disc", group.gTotamnt_disc?.Trim());
                    parameters.Add("@gTotamnt_allow", group.gTotamnt_allow?.Trim());
                    parameters.Add("@gTot_TaxExclAmount", group.gTot_TaxExclAmount?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTotinvper_vat", group.gTotinvper_vat?.Trim());
                    parameters.Add("@gTotamnt_vat", group.gTotamnt_vat?.Trim());
                    parameters.Add("@gTotamnt_vatExch", group.gTotamnt_vatExch?.Trim());
                    parameters.Add("@gTot_TaxInclAmount", group.gTot_TaxInclAmount?.Trim());
                    parameters.Add("@proc_pending", group.proc_pending?.Trim());
                    parameters.Add("@branch_id", group.branch_id?.Trim());
                    parameters.Add("@branch_code", group.branch_code?.Trim());
                    parameters.Add("@buy_vatno", group.buy_vatno?.Trim());
                    parameters.Add("@buy_countrycode", group.buy_countrycode?.Trim());
                    parameters.Add("@buy_id", group.buy_id?.Trim());

                    parameters.Add("@buy_cityname", group.buy_cityname?.Trim());
                    parameters.Add("@buy_streetname", group.buy_streetname?.Trim());
                    parameters.Add("@buy_buildingname", group.buy_buildingname?.Trim());//parameters.Add("@sel_buildingname", group.sel_buildingname?.Trim());
                    parameters.Add("@buy_buildno", group.buy_buildno?.Trim());
                    parameters.Add("@buy_plotid", group.buy_plotid?.Trim());
                    parameters.Add("@buy_adbuildno", group.buy_adbuildno?.Trim());
                    parameters.Add("@buy_postalzone", group.buy_postalzone?.Trim());
                    parameters.Add("@buy_subcitysubname", group.buy_subcitysubname?.Trim());//parameters.Add("@buy_citysubname", group.buy_citysubname?.Trim());
                    parameters.Add("@buy_countrySubentity", group.buy_countrySubentity?.Trim());
                    parameters.Add("@idx_ztcaupload", group.idx_ztcaupload?.Trim());
                    parameters.Add("@buy_typeId", group.buy_typeId?.Trim());
                    parameters.Add("@gTotamnt_prepaid", group.gTotamnt_prepaid?.Trim());
                    parameters.Add("@Eamil", group.Eamil?.Trim());
                    parameters.Add("@no_lines", group.no_lines);
                    parameters.Add("@RewBase64ID", group.RewBase64ID?.Trim());
                    parameters.Add("@ProcessZaca", group.ProcessZaca?.Trim());
                    parameters.Add("@Post_back", group.Post_back?.Trim());
                    parameters.Add("@zaca_status", group.zaca_status?.Trim());
                    parameters.Add("@Mail_sent", group.Mail_sent?.Trim());
                    parameters.Add("@CUSTOMER_TRX_ID", group.CUSTOMER_TRX_ID?.Trim());
                    parameters.Add("@zaca_status_detail", group.zaca_status_detail?.Trim());
                    parameters.Add("@xmlName", group.xmlName?.Trim());
                    parameters.Add("@TRX_SOURCE", group.TRX_SOURCE);
                    // parameters.Add("@gTotamnt_payable", group.gTotamnt_payable?.Trim());
                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }


                return insertedId;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<vw_dr_salesinvoices> GetAll_vw_cr_salesinvoices_CASH()
        {
            List<vw_dr_salesinvoices> _objList = new List<vw_dr_salesinvoices>();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_cr_cashsalesinvoices where inv_type='Simplified Credit Note' and ProcessZaca  ='no'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.Query<vw_dr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams).ToList();

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }
        //
        public int Update_vw_cr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_cashsalesinvoices " +
                   "SET    inv_index=@inv_index " +

                " WHERE rec_index = @rec_index";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.rec_index,


                            group.inv_index

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Delete_dublicate_vw_cr_salesinvoices_CASH(vw_dr_salesinvoices group)
        {
            try
            {
                int rowsAffected = 0;

                string query = "DELETE FROM vw_cr_cashsaleinvoicesdetails WHERE inv_no = @inv_no; " +
                     "DELETE FROM vw_cr_cashsalesinvoices WHERE inv_no = @inv_no;";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        public int Insert_vw_cr_saleinvoicesdetails_CASH(vw_dr_saleinvoicesdetails details)
        {
            try
            {


                int insertedId = 0;
                int rowsAffected = 0;

                string query = @"
        INSERT INTO vw_cr_cashsaleinvoicesdetails (
            inv_index, rec_index, item_description, item_qty, item_unit,
            item_price, lineExtAmount, amnt_disc, taxExclAmount, per_vat,
            tax_code, tax_exceptcode, except_reason, amnt_vat, taxInclAmount, inv_no
        )
        VALUES (
            @inv_index, @rec_index, @item_description, @item_qty, @item_unit,
            @item_price, @lineExtAmount, @amnt_disc, @taxExclAmount, @per_vat,
            @tax_code, @tax_exceptcode, @except_reason, @amnt_vat, @taxInclAmount, @inv_no
        );
        SELECT CAST(SCOPE_IDENTITY() AS INT)";

                using (var connection = new SqlConnection(conn))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@inv_index", details.inv_index);
                    parameters.Add("@rec_index", details.rec_index);
                    parameters.Add("@item_description", details.item_description);
                    parameters.Add("@item_qty", details.item_qty);
                    parameters.Add("@item_unit", details.item_unit);
                    parameters.Add("@item_price", details.item_price);
                    parameters.Add("@lineExtAmount", details.lineExtAmount);
                    parameters.Add("@amnt_disc", details.amnt_disc);
                    parameters.Add("@taxExclAmount", details.taxExclAmount);
                    parameters.Add("@per_vat", details.per_vat);
                    parameters.Add("@tax_code", details.tax_code);
                    parameters.Add("@tax_exceptcode", details.tax_exceptcode);
                    parameters.Add("@except_reason", details.except_reason);
                    parameters.Add("@amnt_vat", details.amnt_vat);
                    parameters.Add("@taxInclAmount", details.taxInclAmount);
                    parameters.Add("@inv_no", details.inv_no);

                    // Execute the query and retrieve the inserted ID
                    insertedId = connection.QueryFirstOrDefault<int>(query, parameters, commandType: CommandType.Text);

                    // The insertedId is now available for further use if needed
                }

                rowsAffected = insertedId != 0 ? 1 : 0;
                return rowsAffected;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //update zaca_status_detail
        public int Update_zaca_status_detail_vw_cr_salesinvoices_CASH(string inv_nos, string zaca_status_details)
        {
            try
            {
                vw_dr_salesinvoices group = new vw_dr_salesinvoices();
                group.inv_no = inv_nos;
                group.zaca_status_detail = zaca_status_details;
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_cashsalesinvoices " +
                   "SET    zaca_status_detail=@zaca_status_detail " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.zaca_status_detail

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //update_xml_name_for_attachemnt
        public int update_xml_name_for_attachemnt_vw_cr_salesinvoices_CASH(string inv_nos, string xmlName)
        {
            try
            {
                vw_dr_salesinvoices group = new vw_dr_salesinvoices();
                group.inv_no = inv_nos;
                group.xmlName = xmlName;
                int rowsAffected = 0;

                string query = "UPDATE vw_cr_cashsalesinvoices " +
                   "SET    xmlName=@xmlName " +

                " WHERE inv_no = @inv_no";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        var parameters = new
                        {

                            group.inv_no,


                            group.xmlName

                        };
                        rowsAffected = connection.Execute(query, parameters, commandType: CommandType.Text);

                    }
                    return rowsAffected;
                    //
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            //int rowsAffected = _dbConnection.Execute(updateQuery, group);
            //return rowsAffected > 0 ? 1 @ 0;
        }
        //get_allinvoice_data


        public vw_dr_salesinvoices get_allinvoice_data_vw_cr_salesinvoices_CASH(string inv_nos)
        {
            vw_dr_salesinvoices _objList = new vw_dr_salesinvoices();
            try
            {
                DynamicParameters dbParams = new DynamicParameters();

                string query = @" SELECT * FROM vw_cr_cashsalesinvoices   WHERE inv_no = '" + inv_nos + "'";
                {
                    using (var connection = new SqlConnection(conn))
                    {
                        _objList = connection.QueryFirstOrDefault<vw_dr_salesinvoices>(query, commandType: CommandType.Text, param: dbParams);

                    }
                    return _objList;
                    //
                }

            }
            catch (Exception ex)
            {

                return _objList;
            }
        }

        #endregion
        #endregion
        #endregion
    }
}
