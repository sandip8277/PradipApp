using iTextSharp.text;

namespace QuickReviewReports
{
    internal class PdfPCell
    {
        private Phrase phrase;

        public PdfPCell(Phrase phrase)
        {
            this.phrase = phrase;
        }
    }
}