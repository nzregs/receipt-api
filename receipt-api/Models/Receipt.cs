using System.Collections.Generic;

namespace receipt_api
{
    public class Receipt
    {
        public string language { get; set; }
        public float textAngle { get; set; }
        public string orientation { get; set; }
        public string abn { get; set; }
        public string businessname { get; set; }
        public string receiptdate { get; set; }
        public string taxtotal { get; set; }
        public string receipttotal { get; set; }

        public List<ReceiptLine> lines;
    }

    public class ReceiptLine
    {
        public string boundingBox { get; set; }
        public int x;
        public int y;
        public int width;
        public int height;
        public string text { get; set; }
    }
}
