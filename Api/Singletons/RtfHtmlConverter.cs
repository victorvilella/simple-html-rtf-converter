using SautinSoft;

namespace Api.Singletons
{

    public interface IRtfHtmlConverter
    {
        public string ToHtml(string input);
        public string ToRtf(string input);
    }
    public class RtfHtmlConverter: IRtfHtmlConverter
    {
        
        
        public string ToHtml(string input)
        {
            var rtfToHtml = new RtfToHtml
            {
                Encoding = RtfToHtml.eEncoding.UTF_8,
                ImageStyle = new RtfToHtml.CImageStyle
                {
                    IncludeImageInHtml = true,
                },
                TableStyle = new RtfToHtml.CTableStyle
                {
                    BorderType = RtfToHtml.eTableBorderType.SameAsInRtf,
                    WidthType = RtfToHtml.eTableWidthType.Pixels
                },
                TextStyle = new RtfToHtml.CTextStyle
                {
                    Font = RtfToHtml.eFont.Enable,
                    InlineCSS = false,
                    PreserveDocumentWidth = false,
                    PreserveDocumentMargins = false,
                    HyperlinkDetect = true,
                    HyperlinkTarget = RtfToHtml.eHyperlinkTarget.Blank,
                    MeasurementUnits = RtfToHtml.eMeasurementUnits.pt,
                },
                HtmlParts = RtfToHtml.eHtmlParts.Html_body,
                OutputFormat = RtfToHtml.eOutputFormat.HTML_5,
                TagStyle = new RtfToHtml.CTagStyle
                {
                    ParagraphTag = RtfToHtml.eTags.div,
                },
            };
            return rtfToHtml.ConvertString(input);
        }

        public string ToRtf(string input)
        {
            var htmlToRtf = new HtmlToRtf
            {
                Encoding = HtmlToRtf.eEncoding.windows1252,
                PreserveBackgroundColor = false,
                PreserveImages = true,
                PreserveHttpImages = true,
                PreserveHttpCss = true,
                BorderVisibility = HtmlToRtf.eBorderVisibility.SameAsOriginalHtml,
                PreserveHR = true,
                InputFormat = HtmlToRtf.eInputFormat.Html,
                OutputFormat = HtmlToRtf.eOutputFormat.Rtf,
                PageStyle = new HtmlToRtf.CPageStyle
                {

                },
                TableFitWidthByPage = true,
                TableFastProcessing = true,
                MergeOptions = new HtmlToRtf.CMergeOptions
                {
                    PageBreakBetweenDocuments = true,
                },
                HttpImagesTimeout = 10,
            };
            htmlToRtf.OpenHtml(input);
            return htmlToRtf.ToRtf();
        }
    }
}