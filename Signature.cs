using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace impositionApp
{
    public class Signature
    {
        public Book book { get; set; }
        public int SignatureID { get; set; }
        public List<Page> pages = new List<Page>();
        public List<PrintSheet> Sheets = new List<PrintSheet>();
        public DirectoryInfo Folder { get; set; }
        public void CreateBlankSheetsBySignatureSize()
        {
            int t = this.pages.Count / 4;

            for (int i = 0; i < t; i++)
            {
                Sheets.Add(new PrintSheet() { signature = this });
            }
        }

        public void EnsureSignatureFolderExists()
        {
            this.Folder = new DirectoryInfo(this.book.OutputDir.FullName + "\\Signature_" + this.SignatureID.ToString("0000") + "\\");

            if (this.Folder.Exists == false) { this.Folder.Create(); }
        }
    }

}
