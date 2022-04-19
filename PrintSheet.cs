using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace impositionApp
{
    public class PrintSheet
    {
        public int printSheetID;
        Bitmap blankSheetImage = null;
        public Signature signature { get; set; }
        public PrintQuad outSide_Front { get; set; }
        public PrintQuad outSide_Back { get; set; }
        public PrintQuad inSide_Front { get; set; }
        public PrintQuad inSide_Back { get; set; }

        public Bitmap outsideImage = null;
        public Bitmap insideImage = null;

        public void CreateOutsideImage()
        {
            outsideImage = this.newBlankSheetImage();
            Bitmap one = this.outSide_Back.GetPagesImage();
            Bitmap two = this.outSide_Front.GetPagesImage();

            outsideImage = this.AddPageToSheet(outsideImage, one, 0, 0);
            outsideImage = this.AddPageToSheet(outsideImage, two, this.outSide_Back.widthPix, 0);

            signature.EnsureSignatureFolderExists();

            outsideImage.Save(signature.Folder.FullName + this.signature.SignatureID.ToString("0000") + "_" + this.printSheetID.ToString("0000") + "_outside.png", ImageFormat.Png);
        }

        public void CreateInsideImage()
        {
            insideImage = this.newBlankSheetImage();
            Bitmap one = this.inSide_Front.GetPagesImage();
            Bitmap two = this.inSide_Back.GetPagesImage();

            insideImage = this.AddPageToSheet(insideImage, one, 0, 0);
            insideImage = this.AddPageToSheet(insideImage, two, this.inSide_Front.widthPix, 0);

            signature.EnsureSignatureFolderExists();

            insideImage.Save(signature.Folder.FullName + this.signature.SignatureID.ToString("0000") + "_" + this.printSheetID.ToString("0000")  + "_inside.png", ImageFormat.Png);
        }
        public Bitmap AddPageToSheet(Bitmap sheet, Bitmap page, int x, int y)
        {

            if (page == null) { return null; }

            Graphics g = Graphics.FromImage(sheet);
            g.DrawImage(page, x, y);

            g.Dispose();
            page.Dispose();

            return sheet;
        }
        public Bitmap newBlankSheetImage()
        {
            if(blankSheetImage != null) { return blankSheetImage; }

            Book book = this.signature.book;
            blankSheetImage = new Bitmap(book.fullWidthPixcels, book.fullHeightPixcels);
            blankSheetImage.SetResolution(book.DPI, book.DPI);

            using (Graphics graph = Graphics.FromImage(blankSheetImage))
            {
                Rectangle ImageSize = new Rectangle(0, 0, book.fullWidthPixcels, book.fullHeightPixcels);
                graph.FillRectangle(Brushes.White, ImageSize);
            }

            return (Bitmap)blankSheetImage.Clone();
        }


    }
    public class PrintQuad
    {
        public PrintSheet sheet { get; set; }
        public Page page { get; set; }
        public int widthPix { get; set; }
        public int heightPix { get; set; }

        public Bitmap GetPagesImage()
        {
            Bitmap pageImage = null;
            try
            {
                pageImage = new Bitmap(this.page.file.FullName);
                pageImage.SetResolution(this.sheet.signature.book.DPI, this.sheet.signature.book.DPI);

                this.widthPix = pageImage.Width;
                this.heightPix = pageImage.Height;

                return (Bitmap)pageImage.Clone();
            }
            catch (Exception e)
            {

                throw;
            }
            finally
            {
                pageImage.Dispose();
            }


        }
    }
}
