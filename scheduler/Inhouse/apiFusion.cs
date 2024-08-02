using System;
using System.Xml.Serialization;
using System.IO;

namespace scheduler.Inhouse
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
    public class Envelope
    {
        [XmlElement(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public string Header { get; set; }

        [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public Body Body { get; set; }
    }

    public class Body
    {
        [XmlElement(ElementName = "runReportResponse", Namespace = "http://xmlns.oracle.com/oxp/service/PublicReportService")]
        public RunReportResponse RunReportResponse { get; set; }
    }

    public class RunReportResponse
    {
        [XmlElement(ElementName = "runReportReturn", Namespace = "http://xmlns.oracle.com/oxp/service/PublicReportService")]
        public RunReportReturn RunReportReturn { get; set; }
    }

    public class RunReportReturn
    {
        [XmlElement(ElementName = "reportBytes", Namespace = "http://xmlns.oracle.com/oxp/service/PublicReportService")]
        public string ReportBytes { get; set; }

        [XmlElement(ElementName = "reportContentType", Namespace = "http://xmlns.oracle.com/oxp/service/PublicReportService")]
        public string ReportContentType { get; set; }

        [XmlElement(ElementName = "reportFileID", Namespace = "http://xmlns.oracle.com/oxp/service/PublicReportService", IsNullable = true)]
        public string ReportFileID { get; set; }

        [XmlElement(ElementName = "reportLocale", Namespace = "http://xmlns.oracle.com/oxp/service/PublicReportService", IsNullable = true)]
        public string ReportLocale { get; set; }

        [XmlElement(ElementName = "metaDataList", Namespace = "http://xmlns.oracle.com/oxp/service/PublicReportService", IsNullable = true)]
        public string MetaDataList { get; set; }
    }

}
