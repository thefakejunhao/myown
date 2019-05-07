using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //    string code = TextBox1.Text;
            //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
            //    QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            //    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //    imgBarCode.Height = 150;
            //    imgBarCode.Width = 150;
            //    using (Bitmap bitMap = qrCode.GetGraphic(20))
            //    {
            //        using (MemoryStream ms = new MemoryStream())
            //        {
            //            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            //            byte[] byteImage = ms.ToArray();
            //            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

            //        }
            //        PlaceHolder1.Controls.Add(imgBarCode);
            //    }
            //}

            string barCode = TextBox1.Text;
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            using (Bitmap bitmap = new Bitmap(barCode.Length * 40, 80))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font oFont = new Font("IDAutomationHC39M", 16);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitmap.Width, bitmap.Height);
                    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                PlaceHolder1.Controls.Add(imgBarCode);
            }
        }
    }
}