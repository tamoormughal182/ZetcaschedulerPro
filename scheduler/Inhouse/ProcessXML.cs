using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace scheduler
{
    public class ProcessXML
    {
        public string Qry { get; set; }
        int sFilter;
        public static string SetBr_Code = String.Empty;
        public static string SetInvoice_No = String.Empty;
        public static string SetInv_type = String.Empty;
    }
    public class attachemnt_mail
    {
        public int id { get; set; }
        public string inv_index { get; set; }
        public string inv_no { get; set; }
        public string inve_type { get; set; }
        public string xml_name { get; set; }
        public DateTime xml_creation_date { get; set; }
        public string mail_send { get; set; }
        public string attachment_name { get; set; }
        public DateTime email_time { get; set; }
        public string xml_path { get; set; }
        public string ZacaRes { get; set; }
        public string ZacaPath { get; set; }
    }
    public class InvoiceFromAPI_oracel
    {
        public int Id { get; set; }
        public string Base64 { get; set; }
        public DateTime DateTimeInsertion { get; set; }
        public DateTime DateTimeZetcaStart { get; set; }
        public DateTime DateTimeZetcaEnd { get; set; }
        public string Status { get; set; }
        public string InvoiceTableId { get; set; }
        public string Type { get; set; }
        public string NoOfLine { get; set; }


    }
    #region vw_cr_salesinvoices
    public class vw_cr_salesinvoices
    {
        public long rec_index { get; set; }
        public long inv_index { get; set; }
        public string inv_no { get; set; }
        public string invref_no { get; set; }
        public string InvRef_Date { get; set; }
        public string instruction_code { get; set; }
        public string inv_type { get; set; }
        public string inv_date { get; set; }
        public string inv_time { get; set; }
        public string issued_date { get; set; }
        public string deli_date { get; set; }
        public string actdeli_date { get; set; }
        public string tax_code { get; set; }
        public string tax_exceptcode { get; set; }
        public string except_reason { get; set; }
        public string mode_ofpay { get; set; }
        public string cur_code { get; set; }
        public string buy_name { get; set; }
        public string gTot_LineExtAmount { get; set; }
        public string gTotamnt_disc { get; set; }
        public string gTotamnt_allow { get; set; }
        public string gTot_TaxExclAmount { get; set; }
        public string gTotinvper_vat { get; set; }
        public string gTotamnt_vat { get; set; }
        public string gTotamnt_vatExch { get; set; }
        public string gTot_TaxInclAmount { get; set; }
        public string proc_pending { get; set; }
        public string branch_id { get; set; }
        public string branch_code { get; set; }
        public string buy_vatno { get; set; }
        public string buy_countrycode { get; set; }
        public string buy_id { get; set; }
        public string sel_typeId { get; set; }
        public string buy_cityname { get; set; }
        public string buy_streetname { get; set; }
        public string sel_buildingname { get; set; }
        public string buy_buildno { get; set; }
        public string buy_plotid { get; set; }
        public string buy_adbuildno { get; set; }
        public string buy_postalzone { get; set; }
        public string buy_citysubname { get; set; }
        public string buy_countrySubentity { get; set; }
        public string idx_ztcaupload { get; set; }
        public string buy_typeId { get; set; }
        public string gTotamnt_prepaid { get; set; }
        public string Eamil { get; set; }
        public int no_lines { get; set; }
        public string RewBase64ID { get; set; }
        public string ProcessZaca { get; set; }
        //
        public string Post_back { get; set; }
        public string zaca_status { get; set; }
        public string Mail_sent { get; set; }
        public string CUSTOMER_TRX_ID { get; set; }
        public string zaca_status_detail { get; set; }
        public string xmlName { get; set; }
        //TRX_SOURCE
        public string TRX_SOURCE { get; set; }
    }
    public class vw_cr_saleinvoicesdetails
    {
        public long dtl_index { get; set; }
        public long inv_index { get; set; }
        public long rec_index { get; set; }
        public string item_description { get; set; }
        public string item_qty { get; set; }
        public string item_unit { get; set; }
        public string item_price { get; set; }
        public string lineExtAmount { get; set; }
        public string amnt_disc { get; set; }
        public string taxExclAmount { get; set; }
        public string per_vat { get; set; }
        public string tax_code { get; set; }
        public string tax_exceptcode { get; set; }
        public string except_reason { get; set; }
        public string amnt_vat { get; set; }
        public string taxInclAmount { get; set; }
        public string inv_no { get; set; }
    }
    #endregion
    #region vw_dr_salesinvoices

    public class vw_dr_salesinvoices
    {
        public long rec_index { get; set; }
        public long inv_index { get; set; }
        public string inv_no { get; set; }
        public string inv_type { get; set; }
        public string inv_date { get; set; }
        public string inv_time { get; set; }
        public string refinv_no { get; set; }
        public string InvRef_Date { get; set; }
        public string instruction_code { get; set; }
        public string deli_date { get; set; }
        public string actdeli_date { get; set; }
        public string mode_ofpay { get; set; }
        public string cur_code { get; set; }
        public string Totamnt_disc { get; set; }
        public string Totamnt_allow { get; set; }
        public string buy_name { get; set; }
        public string gTot_LineExtAmount { get; set; }
        public string gTotamnt_disc { get; set; }
        public string gTotamnt_allow { get; set; }
        public string gTot_TaxExclAmount { get; set; }
        public string gTotamnt_vatExch { get; set; }
        public string gTotinvper_vat { get; set; }
        public string gTotamnt_vat { get; set; }
        public string gTotamnt_prepaid { get; set; }
        public string gTot_TaxInclAmount { get; set; }
        public string gTotamnt_payable { get; set; }
        public string proc_pending { get; set; }
        public string branch_id { get; set; }
        public string branch_code { get; set; }
        public string buy_vatno { get; set; }
        public string buy_countrycode { get; set; }
        public string buy_id { get; set; }
        public string buy_typeId { get; set; }
        public string buy_cityname { get; set; }
        public string buy_streetname { get; set; }
        public string buy_buildingname { get; set; }
        public string buy_buildno { get; set; }
        public string buy_plotid { get; set; }
        public string buy_adbuildno { get; set; }
        public string buy_postalzone { get; set; }
        public string buy_subcitysubname { get; set; }
        public string buy_countrySubentity { get; set; }
        public string idx_ztcaupload { get; set; }
        public string no_lines { get; set; }
        public string Eamil { get; set; }
        public string ProcessStatus { get; set; }
        public string RewBase64ID { get; set; }
        public string ProcessZaca { get; set; }
        public string Post_back { get; set; }
        public string zaca_status { get; set; }
        public string Mail_sent { get; set; }
        public string CUSTOMER_TRX_ID { get; set; }
        public string zaca_status_detail { get; set; }
        public string xmlName { get; set; }
        //TRX_SOURCE
        public string TRX_SOURCE { get; set; }
    }

    //cash
    #region cash vw_cashsalesinvoices
    //public class vw_cashsalesinvoices
    //{
    //    public long rec_index { get; set; }
    //    public long inv_index { get; set; }
    //    public string inv_no { get; set; }
    //    public string invref_no { get; set; }
    //    public string InvRef_Date { get; set; }
    //    public string instruction_code { get; set; }
    //    public string inv_type { get; set; }
    //    public string inv_date { get; set; }
    //    public string inv_time { get; set; }
    //    public string issued_date { get; set; }
    //    public string deli_date { get; set; }
    //    public string actdeli_date { get; set; }
    //    public string tax_code { get; set; }
    //    public string tax_exceptcode { get; set; }
    //    public string except_reason { get; set; }
    //    public string mode_ofpay { get; set; }
    //    public string cur_code { get; set; }
    //    public string buy_name { get; set; }
    //    public string gTot_LineExtAmount { get; set; }
    //    public string gTotamnt_disc { get; set; }
    //    public string gTotamnt_allow { get; set; }
    //    public string gTot_TaxExclAmount { get; set; }
    //    public string gTotinvper_vat { get; set; }
    //    public string gTotamnt_vat { get; set; }
    //    public string gTotamnt_vatExch { get; set; }
    //    public string gTot_TaxInclAmount { get; set; }
    //    public string proc_pending { get; set; }
    //    public string branch_id { get; set; }
    //    public string branch_code { get; set; }
    //    public string buy_vatno { get; set; }
    //    public string buy_countrycode { get; set; }
    //    public string buy_id { get; set; }
    //    public string sel_typeId { get; set; }
    //    public string buy_cityname { get; set; }
    //    public string buy_streetname { get; set; }
    //    public string sel_buildingname { get; set; }
    //    public string buy_buildno { get; set; }
    //    public string buy_plotid { get; set; }
    //    public string buy_adbuildno { get; set; }
    //    public string buy_postalzone { get; set; }
    //    public string buy_citysubname { get; set; }
    //    public string buy_countrySubentity { get; set; }
    //    public string idx_ztcaupload { get; set; }
    //    public string buy_typeId { get; set; }
    //    public string gTotamnt_prepaid { get; set; }
    //    public string Eamil { get; set; }
    //    public int no_lines { get; set; }
    //    public string RewBase64ID { get; set; }
    //    public string ProcessZaca { get; set; }
    //    //
    //    public string Post_back { get; set; }
    //    public string zaca_status { get; set; }
    //    public string Mail_sent { get; set; }
    //    public string CUSTOMER_TRX_ID { get; set; }
    //    public string zaca_status_detail { get; set; }
    //    public string xmlName { get; set; }
    //}
    #endregion
    public class vw_dr_saleinvoicesdetails

    {
        public long dtl_index { get; set; }
        public long inv_index { get; set; }
        public long rec_index { get; set; }
        public string item_description { get; set; }
        public string item_qty { get; set; }
        public string item_unit { get; set; }
        public string item_price { get; set; }
        public string lineExtAmount { get; set; }
        public string amnt_disc { get; set; }
        public string taxExclAmount { get; set; }
        public string per_vat { get; set; }
        public string tax_code { get; set; }
        public string tax_exceptcode { get; set; }
        public string except_reason { get; set; }
        public string amnt_vat { get; set; }
        public string taxInclAmount { get; set; }
        public string inv_no { get; set; }
    }
    #endregion
    #region vw_salesinvoices


    public class vw_salesinvoices
    {
        public long rec_index { get; set; }
        public long inv_index { get; set; }
        public string inv_no { get; set; }
        public string inv_type { get; set; }
        public string inv_date { get; set; }
        public string inv_time { get; set; }
        public string deli_date { get; set; }
        public string actdeli_date { get; set; }
        public string mode_ofpay { get; set; }
        public string cur_code { get; set; }
        public string Totamnt_disc { get; set; } = "0";
        public string Totamnt_allow { get; set; } = "0";
        public string buy_name { get; set; }
        public string gTot_LineExtAmount { get; set; } = "0";
        public string gTotamnt_disc { get; set; } = "0";
        public string gTotamnt_allow { get; set; } = "0";
        public string gTot_TaxExclAmount { get; set; } = "0";
        public string gTotamnt_vatExch { get; set; }
        public string gTotinvper_vat { get; set; } = "0";
        public string gTotamnt_vat { get; set; } = "0";
        public string gTotamnt_prepaid { get; set; } = "0";
        public string gTot_TaxInclAmount { get; set; } = "0";
        public string gTotamnt_payable { get; set; } = "0";
        public string proc_pending { get; set; }
        public int branch_id { get; set; }
        public string branch_code { get; set; }
        public string buy_vatno { get; set; }
        public string buy_countrycode { get; set; }
        public string buy_id { get; set; }
        public string buy_typeId { get; set; }
        public string buy_cityname { get; set; }
        public string buy_streetname { get; set; }
        public string buy_buildingname { get; set; }
        public string buy_buildno { get; set; }
        public string buy_plotid { get; set; }
        public string buy_adbuildno { get; set; }
        public string buy_postalzone { get; set; }
        public string buy_subcitysubname { get; set; }
        public string buy_countrySubentity { get; set; }
        public int idx_ztcaupload { get; set; }
        public string Eamil { get; set; }
        public int no_lines { get; set; }
        public string RewBase64ID { get; set; }
        public string ProcessZaca { get; set; }
        //
        public string Post_back { get; set; }
        public string zaca_status { get; set; }
        public string Mail_sent { get; set; }
        public string CUSTOMER_TRX_ID { get; set; }
        public string zaca_status_detail { get; set; }
        public string xmlName { get; set; }

        //TRX_SOURCE
        public string TRX_SOURCE { get; set; }

    }
    public class vw_saleinvoicesdetails
    {
        public long dtl_index { get; set; }
        public long inv_index { get; set; }
        public long rec_index { get; set; }
        public string item_description { get; set; }
        public string item_qty { get; set; } = "0";
        public string item_unit { get; set; }
        public string item_price { get; set; } = "0";
        public string lineExtAmount { get; set; } = "0";
        public string amnt_disc { get; set; } = "0";
        public string taxExclAmount { get; set; } = "0";
        public string per_vat { get; set; } = "0";
        public string tax_code { get; set; }
        public string tax_exceptcode { get; set; }
        public string except_reason { get; set; }
        public string amnt_vat { get; set; } = "0";
        public string taxInclAmount { get; set; } = "0";
        public string inv_no { get; set; }
    }
    #endregion
    #region xml model
    //// using System.Xml.Serialization;
    //// XmlSerializer serializer = new XmlSerializer(typeof(DATADS));
    //// using (StringReader reader = new StringReader(xml))
    //// {
    ////    var test = (DATADS)serializer.Deserialize(reader);
    //// }

    //[XmlRoot(ElementName = "G_4")]
    //public class G4
    //{

    //    [XmlElement(ElementName = "LINE_DESC")]
    //    public string LINEDESC { get; set; }

    //    [XmlElement(ElementName = "ITEM_PRICE")]
    //    public int ITEMPRICE { get; set; }

    //    [XmlElement(ElementName = "QTY")]
    //    public int QTY { get; set; }

    //    [XmlElement(ElementName = "TOT_WITHOUT_TAX")]
    //    public int TOTWITHOUTTAX { get; set; }

    //    [XmlElement(ElementName = "LINE_VAT_AMT")]
    //    public int LINEVATAMT { get; set; }

    //    [XmlElement(ElementName = "SUBTOT_WITH_VAT")]
    //    public int SUBTOTWITHVAT { get; set; }

    //    [XmlElement(ElementName = "LINE_NUMBER")]
    //    public int LINENUMBER { get; set; }

    //    [XmlElement(ElementName = "QUANTITY_INVOICED")]
    //    public int QUANTITYINVOICED { get; set; }

    //    [XmlElement(ElementName = "AMOUNT_INCLUDES_TAX_FLAG")]
    //    public string AMOUNTINCLUDESTAXFLAG { get; set; }

    //    [XmlElement(ElementName = "TOTAL_LINE_AMOUNT")]
    //    public int TOTALLINEAMOUNT { get; set; }
    //}

    //[XmlRoot(ElementName = "G_1")]
    //public class G1
    //{

    //    [XmlElement(ElementName = "PARTY_ID")]
    //    public double PARTYID { get; set; }

    //    [XmlElement(ElementName = "PARTY_TYPE")]
    //    public string PARTYTYPE { get; set; }

    //    [XmlElement(ElementName = "COUNTRY")]
    //    public string COUNTRY { get; set; }

    //    [XmlElement(ElementName = "CITY")]
    //    public string CITY { get; set; }

    //    [XmlElement(ElementName = "INV_NO")]
    //    public int INVNO { get; set; }

    //    [XmlElement(ElementName = "CUSTOMER_TRX_ID")]
    //    public double CUSTOMERTRXID { get; set; }

    //    [XmlElement(ElementName = "INV_DATE")]
    //    public DateTime INVDATE { get; set; }

    //    [XmlElement(ElementName = "CURR_CODE")]
    //    public string CURRCODE { get; set; }

    //    [XmlElement(ElementName = "TRX_TYPE")]
    //    public string TRXTYPE { get; set; }

    //    [XmlElement(ElementName = "CUST_NAME")]
    //    public string CUSTNAME { get; set; }

    //    [XmlElement(ElementName = "ADDRESS")]
    //    public string ADDRESS { get; set; }

    //    [XmlElement(ElementName = "PARTY_SITE_ID")]
    //    public double PARTYSITEID { get; set; }

    //    [XmlElement(ElementName = "TOTAL_DISCOUNT")]
    //    public int TOTALDISCOUNT { get; set; }

    //    [XmlElement(ElementName = "TOTAL_ALLOWANCE")]
    //    public int TOTALALLOWANCE { get; set; }

    //    [XmlElement(ElementName = "BF_VAT")]
    //    public int BFVAT { get; set; }

    //    [XmlElement(ElementName = "TOTAL_VAT")]
    //    public int TOTALVAT { get; set; }

    //    [XmlElement(ElementName = "TOTAL_PAYABLE")]
    //    public int TOTALPAYABLE { get; set; }

    //    [XmlElement(ElementName = "EXTENDED_AMOUNT")]
    //    public int EXTENDEDAMOUNT { get; set; }

    //    [XmlElement(ElementName = "DISCOUNT")]
    //    public int DISCOUNT { get; set; }

    //    [XmlElement(ElementName = "SELLER_ID_TYPE")]
    //    public string SELLERIDTYPE { get; set; }

    //    [XmlElement(ElementName = "SELLER_IDENTIFICATION_NUMBER")]
    //    public double SELLERIDENTIFICATIONNUMBER { get; set; }

    //    [XmlElement(ElementName = "MD_PAY")]
    //    public string MDPAY { get; set; }

    //    [XmlElement(ElementName = "VAT_REG_NUM")]
    //    public int VATREGNUM { get; set; }

    //    [XmlElement(ElementName = "TAX_REG_NUM")]
    //    public double TAXREGNUM { get; set; }

    //    [XmlElement(ElementName = "G_4")]
    //    public List<G4> G4 { get; set; }
    //}

    //[XmlRoot(ElementName = "DATA_DS")]
    //public class DATADS
    //{

    //    [XmlElement(ElementName = "P_TRX_ID")]
    //    public double PTRXID { get; set; }

    //    [XmlElement(ElementName = "P_FROM_DATE")]
    //    public string PFROMDATE { get; set; }

    //    [XmlElement(ElementName = "P_TO_DATE")]
    //    public string PTODATE { get; set; }

    //    [XmlElement(ElementName = "G_1")]
    //    public G1 G1 { get; set; }
    //}
    #endregion
    #region xml model
    //// using System.Xml.Serialization;
    //// XmlSerializer serializer = new XmlSerializer(typeof(DATADS));
    //// using (StringReader reader = new StringReader(xml))
    //// {
    ////    var test = (DATADS)serializer.Deserialize(reader);
    //// }

    //[XmlRoot(ElementName = "G_2")]
    //public class G2
    //{

    //    [XmlElement(ElementName = "LINE_DESC")]
    //    public string LINEDESC { get; set; }

    //    [XmlElement(ElementName = "ITEM_PRICE")]
    //    public int ITEMPRICE { get; set; }

    //    [XmlElement(ElementName = "UOM")]
    //    public string UOM { get; set; }

    //    [XmlElement(ElementName = "QTY")]
    //    public int QTY { get; set; }

    //    [XmlElement(ElementName = "TOT_WITHOUT_TAX")]
    //    public int TOTWITHOUTTAX { get; set; }

    //    [XmlElement(ElementName = "VAT_CODE")]
    //    public string VATCODE { get; set; }

    //    [XmlElement(ElementName = "LINE_VAT_AMT")]
    //    public int LINEVATAMT { get; set; }

    //    [XmlElement(ElementName = "VAT_RATE")]
    //    public string VATRATE { get; set; }

    //    [XmlElement(ElementName = "SUBTOT_WITH_VAT")]
    //    public int SUBTOTWITHVAT { get; set; }

    //    [XmlElement(ElementName = "LINE_NUMBER")]
    //    public int LINENUMBER { get; set; }

    //    [XmlElement(ElementName = "QUANTITY_INVOICED")]
    //    public int QUANTITYINVOICED { get; set; }

    //    [XmlElement(ElementName = "AMOUNT_INCLUDES_TAX_FLAG")]
    //    public string AMOUNTINCLUDESTAXFLAG { get; set; }

    //    [XmlElement(ElementName = "TOTAL_LINE_AMOUNT")]
    //    public int TOTALLINEAMOUNT { get; set; }

    //    [XmlElement(ElementName = "LINE_AMNT_DISC")]
    //    public int LINEAMNTDISC { get; set; }

    //    [XmlElement(ElementName = "TAX_EXCEPTCODE")]
    //    public string TAXEXCEPTCODE { get; set; }

    //    [XmlElement(ElementName = "EXCEPT_REASON")]
    //    public string EXCEPTREASON { get; set; }

    //    [XmlElement(ElementName = "ITEM_UNIT")]
    //    public string ITEMUNIT { get; set; }
    //}

    //[XmlRoot(ElementName = "G_1")]
    //public class G1
    //{

    //    [XmlElement(ElementName = "INV_NO")]
    //    public int INVNO { get; set; }

    //    [XmlElement(ElementName = "CUSTOMER_TRX_ID")]
    //    public double CUSTOMERTRXID { get; set; }

    //    [XmlElement(ElementName = "INV_DATE")]
    //    public DateTime INVDATE { get; set; }

    //    [XmlElement(ElementName = "INV_TIME")]
    //    public DateTime INVTIME { get; set; }

    //    [XmlElement(ElementName = "TOT_INV_PER_VAT")]
    //    public int TOTINVPERVAT { get; set; }

    //    [XmlElement(ElementName = "TOT_AMNT_PREPAID")]
    //    public int TOTAMNTPREPAID { get; set; }

    //    [XmlElement(ElementName = "PROC_PENDING")]
    //    public string PROCPENDING { get; set; }

    //    [XmlElement(ElementName = "CURR_CODE")]
    //    public string CURRCODE { get; set; }

    //    [XmlElement(ElementName = "INV_TYPE")]
    //    public string INVTYPE { get; set; }

    //    [XmlElement(ElementName = "CUST_NAME")]
    //    public string CUSTNAME { get; set; }

    //    [XmlElement(ElementName = "PARTY_ID")]
    //    public double PARTYID { get; set; }

    //    [XmlElement(ElementName = "ADDRESS")]
    //    public string ADDRESS { get; set; }

    //    [XmlElement(ElementName = "POSTAL_CODE")]
    //    public string POSTALCODE { get; set; }

    //    [XmlElement(ElementName = "PARTY_SITE_ID")]
    //    public double PARTYSITEID { get; set; }

    //    [XmlElement(ElementName = "TOTAL_DISCOUNT")]
    //    public int TOTALDISCOUNT { get; set; }

    //    [XmlElement(ElementName = "TOTAL_ALLOWANCE")]
    //    public int TOTALALLOWANCE { get; set; }

    //    [XmlElement(ElementName = "BF_VAT")]
    //    public int BFVAT { get; set; }

    //    [XmlElement(ElementName = "TOTAL_VAT")]
    //    public int TOTALVAT { get; set; }

    //    [XmlElement(ElementName = "TOTAL_PAYABLE")]
    //    public int TOTALPAYABLE { get; set; }

    //    [XmlElement(ElementName = "EXTENDED_AMOUNT")]
    //    public int EXTENDEDAMOUNT { get; set; }

    //    [XmlElement(ElementName = "DISCOUNT")]
    //    public int DISCOUNT { get; set; }

    //    [XmlElement(ElementName = "SELLER_ID_TYPE")]
    //    public string SELLERIDTYPE { get; set; }

    //    [XmlElement(ElementName = "SELLER_IDENTIFICATION_NUMBER")]
    //    public double SELLERIDENTIFICATIONNUMBER { get; set; }

    //    [XmlElement(ElementName = "MD_PAY")]
    //    public string MDPAY { get; set; }

    //    [XmlElement(ElementName = "VAT_REG_NUM")]
    //    public int VATREGNUM { get; set; }

    //    [XmlElement(ElementName = "COUNTRY")]
    //    public string COUNTRY { get; set; }

    //    [XmlElement(ElementName = "CITY")]
    //    public string CITY { get; set; }

    //    [XmlElement(ElementName = "PARTY_TYPE")]
    //    public string PARTYTYPE { get; set; }

    //    [XmlElement(ElementName = "TAX_REG_NUM")]
    //    public double TAXREGNUM { get; set; }

    //    [XmlElement(ElementName = "G_2")]
    //    public List<G2> G2 { get; set; }
    //}

    //[XmlRoot(ElementName = "DATA_DS")]
    //public class DATADS
    //{

    //    [XmlElement(ElementName = "P_TRX_ID")]
    //    public double PTRXID { get; set; }

    //    [XmlElement(ElementName = "P_FROM_DATE")]
    //    public string PFROMDATE { get; set; }

    //    [XmlElement(ElementName = "P_TO_DATE")]
    //    public string PTODATE { get; set; }

    //    [XmlElement(ElementName = "G_1")]
    //    public G1 G1 { get; set; }
    //}


    #endregion

    #region MyRegion Working
    //[XmlRoot("DATA_DS")]
    //public class DataDs
    //{
    //    [XmlElement("P_TRX_ID")]
    //    public string PTrxId { get; set; }

    //    [XmlElement("P_FROM_DATE")]
    //    public string PFromDate { get; set; }

    //    [XmlElement("P_TO_DATE")]
    //    public string PToDate { get; set; }

    //    [XmlElement("G_1")]
    //    public G1 G1 { get; set; }
    //}

    //public class G1
    //{
    //    [XmlElement("INV_NO")]
    //    public string InvNo { get; set; }

    //    [XmlElement("CUSTOMER_TRX_ID")]
    //    public string CustomerTrxId { get; set; }

    //    [XmlElement("INV_DATE")]
    //    public string InvDate { get; set; }

    //    [XmlElement("INV_TIME")]
    //    public string InvTime { get; set; }

    //    [XmlElement("TOT_INV_PER_VAT")]
    //    public int TotInvPerVat { get; set; }

    //    [XmlElement("TOT_AMNT_PREPAID")]
    //    public int TotAmntPrepaid { get; set; }

    //    [XmlElement("PROC_PENDING")]
    //    public string ProcPending { get; set; }

    //    [XmlElement("CURR_CODE")]
    //    public string CurrCode { get; set; }

    //    [XmlElement("INV_TYPE")]
    //    public string InvType { get; set; }

    //    [XmlElement("CUST_NAME")]
    //    public string CustName { get; set; }

    //    [XmlElement("PARTY_ID")]
    //    public string PartyId { get; set; }

    //    [XmlElement("ADDRESS")]
    //    public string Address { get; set; }

    //    [XmlElement("POSTAL_CODE")]
    //    public string PostalCode { get; set; }

    //    [XmlElement("PARTY_SITE_ID")]
    //    public string PartySiteId { get; set; }

    //    [XmlElement("TOTAL_DISCOUNT")]
    //    public int TotalDiscount { get; set; }

    //    [XmlElement("TOTAL_ALLOWANCE")]
    //    public int TotalAllowance { get; set; }

    //    [XmlElement("BF_VAT")]
    //    public int BfVat { get; set; }

    //    [XmlElement("TOTAL_VAT")]
    //    public int TotalVat { get; set; }

    //    [XmlElement("TOTAL_PAYABLE")]
    //    public int TotalPayable { get; set; }

    //    [XmlElement("EXTENDED_AMOUNT")]
    //    public int ExtendedAmount { get; set; }

    //    [XmlElement("DISCOUNT")]
    //    public int Discount { get; set; }

    //    [XmlElement("SELLER_ID_TYPE")]
    //    public string SellerIdType { get; set; }

    //    [XmlElement("SELLER_IDENTIFICATION_NUMBER")]
    //    public string SellerIdentificationNumber { get; set; }

    //    [XmlElement("MD_PAY")]
    //    public string MdPay { get; set; }

    //    [XmlElement("VAT_REG_NUM")]
    //    public int VatRegNum { get; set; }

    //    [XmlElement("COUNTRY")]
    //    public string Country { get; set; }

    //    [XmlElement("CITY")]
    //    public string City { get; set; }

    //    [XmlElement("PARTY_TYPE")]
    //    public string PartyType { get; set; }

    //    [XmlElement("TAX_REG_NUM")]
    //    public string TaxRegNum { get; set; }

    //    [XmlElement("G_2")]
    //    public List<G2> G2 { get; set; }
    //}

    //public class G2
    //{
    //    [XmlElement("LINE_DESC")]
    //    public string LineDesc { get; set; }

    //    [XmlElement("ITEM_PRICE")]
    //    public int ItemPrice { get; set; }

    //    [XmlElement("UOM")]
    //    public string Uom { get; set; }

    //    [XmlElement("QTY")]
    //    public int Qty { get; set; }

    //    [XmlElement("TOT_WITHOUT_TAX")]
    //    public int TotWithoutTax { get; set; }

    //    [XmlElement("VAT_CODE")]
    //    public string VatCode { get; set; }

    //    [XmlElement("LINE_VAT_AMT")]
    //    public int LineVatAmt { get; set; }

    //    [XmlElement("VAT_RATE")]
    //    public string VatRate { get; set; }

    //    [XmlElement("SUBTOT_WITH_VAT")]
    //    public int SubtotWithVat { get; set; }

    //    [XmlElement("LINE_NUMBER")]
    //    public int LineNumber { get; set; }

    //    [XmlElement("QUANTITY_INVOICED")]
    //    public int QuantityInvoiced { get; set; }

    //    [XmlElement("AMOUNT_INCLUDES_TAX_FLAG")]
    //    public string AmountIncludesTaxFlag { get; set; }

    //    [XmlElement("TOTAL_LINE_AMOUNT")]
    //    public int TotalLineAmount { get; set; }

    //    [XmlElement("LINE_AMNT_DISC")]
    //    public int LineAmntDisc { get; set; }

    //    [XmlElement("TAX_EXCEPTCODE")]
    //    public string TaxExceptCode { get; set; }

    //    [XmlElement("EXCEPT_REASON")]
    //    public string ExceptReason { get; set; }

    //    [XmlElement("ITEM_UNIT")]
    //    public string ItemUnit { get; set; }
    //}
    #endregion
    #region working own modified name
    //[XmlRoot("DATA_DS")]
    //public class DataDs
    //{
    //    [XmlElement("P_TRX_ID")]
    //    public string P_TRX_ID { get; set; }

    //    [XmlElement("P_FROM_DATE")]
    //    public string P_FROM_DATE { get; set; }

    //    [XmlElement("P_TO_DATE")]
    //    public string P_TO_DATE { get; set; }

    //    [XmlElement("G_1")]
    //    public G1 G1 { get; set; }
    //}

    //public class G1
    //{
    //    [XmlElement("INV_NO")]
    //    public string INV_NO { get; set; }

    //    [XmlElement("CUSTOMER_TRX_ID")]
    //    public string CUSTOMER_TRX_ID { get; set; }

    //    [XmlElement("INV_DATE")]
    //    public string INV_DATE { get; set; }

    //    [XmlElement("INV_TIME")]
    //    public string INV_TIME { get; set; }

    //    [XmlElement("TOT_INV_PER_VAT")]
    //    public int TOT_INV_PER_VAT { get; set; }

    //    [XmlElement("TOT_AMNT_PREPAID")]
    //    public int TOT_AMNT_PREPAID { get; set; }

    //    [XmlElement("PROC_PENDING")]
    //    public string PROC_PENDING { get; set; }

    //    [XmlElement("CURR_CODE")]
    //    public string CURR_CODE { get; set; }

    //    [XmlElement("INV_TYPE")]
    //    public string INV_TYPE { get; set; }

    //    [XmlElement("CUST_NAME")]
    //    public string CUST_NAME { get; set; }

    //    [XmlElement("PARTY_ID")]
    //    public string PARTY_ID { get; set; }

    //    [XmlElement("ADDRESS")]
    //    public string ADDRESS { get; set; }

    //    [XmlElement("POSTAL_CODE")]
    //    public string POSTAL_CODE { get; set; }

    //    [XmlElement("PARTY_SITE_ID")]
    //    public string PARTY_SITE_ID { get; set; }

    //    [XmlElement("TOTAL_DISCOUNT")]
    //    public int TOTAL_DISCOUNT { get; set; }

    //    [XmlElement("TOTAL_ALLOWANCE")]
    //    public int TOTAL_ALLOWANCE { get; set; }

    //    [XmlElement("BF_VAT")]
    //    public int BF_VAT { get; set; }

    //    [XmlElement("TOTAL_VAT")]
    //    public int TOTAL_VAT { get; set; }

    //    [XmlElement("TOTAL_PAYABLE")]
    //    public int TOTAL_PAYABLE { get; set; }

    //    [XmlElement("EXTENDED_AMOUNT")]
    //    public int EXTENDED_AMOUNT { get; set; }

    //    [XmlElement("DISCOUNT")]
    //    public int DISCOUNT { get; set; }

    //    [XmlElement("SELLER_ID_TYPE")]
    //    public string SELLER_ID_TYPE { get; set; }

    //    [XmlElement("SELLER_IDENTIFICATION_NUMBER")]
    //    public string SELLER_IDENTIFICATION_NUMBER { get; set; }

    //    [XmlElement("MD_PAY")]
    //    public string MD_PAY { get; set; }

    //    [XmlElement("VAT_REG_NUM")]
    //    public int VAT_REG_NUM { get; set; }

    //    [XmlElement("COUNTRY")]
    //    public string COUNTRY { get; set; }

    //    [XmlElement("CITY")]
    //    public string CITY { get; set; }

    //    [XmlElement("PARTY_TYPE")]
    //    public string PARTY_TYPE { get; set; }

    //    [XmlElement("TAX_REG_NUM")]
    //    public string TAX_REG_NUM { get; set; }

    //    [XmlElement("G_2")]
    //    public List<G2> G2 { get; set; }
    //}

    //public class G2
    //{
    //    [XmlElement("LINE_DESC")]
    //    public string LINE_DESC { get; set; }

    //    [XmlElement("ITEM_PRICE")]
    //    public int ITEM_PRICE { get; set; }

    //    [XmlElement("UOM")]
    //    public string UOM { get; set; }

    //    [XmlElement("QTY")]
    //    public int QTY { get; set; }

    //    [XmlElement("TOT_WITHOUT_TAX")]
    //    public int TOT_WITHOUT_TAX { get; set; }

    //    [XmlElement("VAT_CODE")]
    //    public string VAT_CODE { get; set; }

    //    [XmlElement("LINE_VAT_AMT")]
    //    public int LINE_VAT_AMT { get; set; }

    //    [XmlElement("VAT_RATE")]
    //    public string VAT_RATE { get; set; }

    //    [XmlElement("SUBTOT_WITH_VAT")]
    //    public int SUBTOT_WITH_VAT { get; set; }

    //    [XmlElement("LINE_NUMBER")]
    //    public int LINE_NUMBER { get; set; }

    //    [XmlElement("QUANTITY_INVOICED")]
    //    public int QUANTITY_INVOICED { get; set; }

    //    [XmlElement("AMOUNT_INCLUDES_TAX_FLAG")]
    //    public string AMOUNT_INCLUDES_TAX_FLAG { get; set; }

    //    [XmlElement("TOTAL_LINE_AMOUNT")]
    //    public int TOTAL_LINE_AMOUNT { get; set; }

    //    [XmlElement("LINE_AMNT_DISC")]
    //    public int LINE_AMNT_DISC { get; set; }

    //    [XmlElement("TAX_EXCEPTCODE")]
    //    public string TAX_EXCEPTCODE { get; set; }

    //    [XmlElement("EXCEPT_REASON")]
    //    public string EXCEPT_REASON { get; set; }

    //    [XmlElement("ITEM_UNIT")]
    //    public string ITEM_UNIT { get; set; }
    //}
    #endregion
    #region list
    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(DATADS));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (DATADS)serializer.Deserialize(reader);
    // }

    [XmlRoot(ElementName = "G_2")]
    public class G_2
    {
        [XmlElement(ElementName = "LINE_DESC")]
        public string LINE_DESC { get; set; }
        [XmlElement(ElementName = "ITEM_PRICE")]
        public string ITEM_PRICE { get; set; }
        [XmlElement(ElementName = "UOM")]
        public string UOM { get; set; }
        [XmlElement(ElementName = "QTY")]
        public string QTY { get; set; }
        [XmlElement(ElementName = "TOT_WITHOUT_TAX")]
        public string TOT_WITHOUT_TAX { get; set; }
        [XmlElement(ElementName = "VAT_CODE")]
        public string VAT_CODE { get; set; }
        [XmlElement(ElementName = "LINE_VAT_AMT")]
        public string LINE_VAT_AMT { get; set; }
        [XmlElement(ElementName = "VAT_RATE")]
        public string VAT_RATE { get; set; }
        [XmlElement(ElementName = "SUBTOT_WITH_VAT")]
        public string SUBTOT_WITH_VAT { get; set; }
        [XmlElement(ElementName = "LINE_NUMBER")]
        public string LINE_NUMBER { get; set; }
        [XmlElement(ElementName = "QUANTITY_INVOICED")]
        public string QUANTITY_INVOICED { get; set; }
        [XmlElement(ElementName = "AMOUNT_INCLUDES_TAX_FLAG")]
        public string AMOUNT_INCLUDES_TAX_FLAG { get; set; }
        [XmlElement(ElementName = "TOTAL_LINE_AMOUNT")]
        public string TOTAL_LINE_AMOUNT { get; set; }
        [XmlElement(ElementName = "LINE_AMNT_DISC")]
        public string LINE_AMNT_DISC { get; set; }
        [XmlElement(ElementName = "TAX_EXCEPTCODE")]
        public string TAX_EXCEPTCODE { get; set; }
        [XmlElement(ElementName = "EXCEPT_REASON")]
        public string EXCEPT_REASON { get; set; }
        [XmlElement(ElementName = "ITEM_UNIT")]
        public string ITEM_UNIT { get; set; }
    }

    [XmlRoot(ElementName = "G_1")]
    public class G_1
    {
        //CUST_ID_NUMBER
        [XmlElement(ElementName = "CUST_ID_NUMBER")]
        public string CUST_ID_NUMBER { get; set; }
        //TRX_SOURCE
        [XmlElement(ElementName = "TRX_SOURCE")]
        public string TRX_SOURCE { get; set; }


        ///new end
        //1) ORG_INV_NUMBER(yesterday added)
        [XmlElement(ElementName = "ORG_INV_NUMBER")]
        public string ORG_INV_NUMBER { get; set; }
        //2) ORG_INV_DATE
        [XmlElement(ElementName = "ORG_INV_DATE")]
        public string ORG_INV_DATE { get; set; }
        //3) CREDIT_REASON
        [XmlElement(ElementName = "CREDIT_REASON")]
        public string CREDIT_REASON { get; set; }
        //
        [XmlElement(ElementName = "INV_NO")]
        public string INV_NO { get; set; }
        [XmlElement(ElementName = "CUSTOMER_TRX_ID")]
        public string CUSTOMER_TRX_ID { get; set; }
        [XmlElement(ElementName = "INV_DATE")]
        public string INV_DATE { get; set; }
        [XmlElement(ElementName = "INV_TIME")]
        public string INV_TIME { get; set; }
        [XmlElement(ElementName = "TOT_INV_PER_VAT")]
        public string TOT_INV_PER_VAT { get; set; }
        [XmlElement(ElementName = "TOT_AMNT_PREPAID")]
        public string TOT_AMNT_PREPAID { get; set; }
        [XmlElement(ElementName = "PROC_PENDING")]
        public string PROC_PENDING { get; set; }
        [XmlElement(ElementName = "CURR_CODE")]
        public string CURR_CODE { get; set; }
        [XmlElement(ElementName = "INV_TYPE")]
        public string INV_TYPE { get; set; }
        [XmlElement(ElementName = "CUST_NAME")]
        public string CUST_NAME { get; set; }
        [XmlElement(ElementName = "PARTY_ID")]
        public string PARTY_ID { get; set; }
        [XmlElement(ElementName = "ADDRESS")]
        public string ADDRESS { get; set; }
        [XmlElement(ElementName = "POSTAL_CODE")]
        public string POSTAL_CODE { get; set; }
        [XmlElement(ElementName = "PARTY_SITE_ID")]
        public string PARTY_SITE_ID { get; set; }
        [XmlElement(ElementName = "TOTAL_DISCOUNT")]
        public string TOTAL_DISCOUNT { get; set; }
        [XmlElement(ElementName = "TOTAL_ALLOWANCE")]
        public string TOTAL_ALLOWANCE { get; set; }
        [XmlElement(ElementName = "BF_VAT")]
        public string BF_VAT { get; set; }
        [XmlElement(ElementName = "TOTAL_VAT")]
        public string TOTAL_VAT { get; set; }
        [XmlElement(ElementName = "TOTAL_PAYABLE")]
        public string TOTAL_PAYABLE { get; set; }
        [XmlElement(ElementName = "LEGAL_ENTITIY")]
        public string LEGAL_ENTITIY { get; set; }
        [XmlElement(ElementName = "INV_CLASS")]
        public string INV_CLASS { get; set; }
        [XmlElement(ElementName = "EMAIL_ADDRESS")]
        public string EMAIL_ADDRESS { get; set; }
        [XmlElement(ElementName = "EXTENDED_AMOUNT")]
        public string EXTENDED_AMOUNT { get; set; }
        [XmlElement(ElementName = "DISCOUNT")]
        public string DISCOUNT { get; set; }
        [XmlElement(ElementName = "SELLER_ID_TYPE")]
        public string SELLER_ID_TYPE { get; set; }
        [XmlElement(ElementName = "SELLER_IDENTIFICATION_NUMBER")]
        public string SELLER_IDENTIFICATION_NUMBER { get; set; }
        [XmlElement(ElementName = "MD_PAY")]
        public string MD_PAY { get; set; }
        [XmlElement(ElementName = "VAT_REG_NUM")]
        public string VAT_REG_NUM { get; set; }
        [XmlElement(ElementName = "COUNTRY")]
        public string COUNTRY { get; set; }
        [XmlElement(ElementName = "CITY")]
        public string CITY { get; set; }
        [XmlElement(ElementName = "PARTY_TYPE")]
        public string PARTY_TYPE { get; set; }
        [XmlElement(ElementName = "TAX_REG_NUM")]
        public string TAX_REG_NUM { get; set; }
        [XmlElement(ElementName = "G_2")]
        public List<G_2> G_2 { get; set; }
    }

    [XmlRoot(ElementName = "DATA_DS")]
    public class DATA_DS
    {
        [XmlElement(ElementName = "P_TRX_ID")]
        public string P_TRX_ID { get; set; }
        [XmlElement(ElementName = "P_FROM_DATE")]
        public string P_FROM_DATE { get; set; }
        [XmlElement(ElementName = "P_TO_DATE")]
        public string P_TO_DATE { get; set; }
        [XmlElement(ElementName = "G_1")]
        public List<G_1> G_1 { get; set; }
    }


    #endregion
}
