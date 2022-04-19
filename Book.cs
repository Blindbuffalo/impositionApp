using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace impositionApp
{
    public class Book
    {
        public DirectoryInfo InputDir { get; set; }
        public DirectoryInfo OutputDir { get; set; }
        public int pagesPerSignature = 4;
        public int totalPageCount = 0;
        public List<Signature> Signatures = new List<Signature>();

        public float widthInch { get; set; }
        public float heightInch { get; set; }
        public float DPI { get; set; }

        public float fullWidthIn { get { return widthInch * 2; } protected set { } }
        public float fullHeightIn { get { return heightInch; } protected set { } }

        public int fullWidthPixcels { get { return (int)Math.Round( this.DPI * this.fullWidthIn, 0); } protected set { } }
        public int fullHeightPixcels { get { return (int)Math.Round(this.DPI * this.fullHeightIn, 0); } protected set { } }
        public void BuildSignatures(Dictionary<int, FileInfo> files)
        {
            this.totalPageCount = files.Count;

            int currentSignatureID = 1;
            for (int i = 1; i <= totalPageCount; i = i + this.pagesPerSignature)
            {
                int pagesForThisSig = (this.pagesPerSignature + i) - 1;

                if (pagesForThisSig > totalPageCount)
                {
                    pagesForThisSig = totalPageCount;
                }
                Signature s = new Signature() { book = this };
                for (int j = i; j <= pagesForThisSig; j++)
                {
                    s.pages.Add(new Page() { file = files[j], pageNum = j });

                }
                s.SignatureID = currentSignatureID;
                this.Signatures.Add(s);
                currentSignatureID++;
            }
        }
        public void LayoutSheets()
        {
            foreach (Signature signature in this.Signatures)
            {
                signature.CreateBlankSheetsBySignatureSize();
                int pageId = (this.pagesPerSignature * (signature.SignatureID - 1)) + 1;
                for (int i = 0; i < signature.Sheets.Count; i++)
                {
                    signature.Sheets[i].printSheetID = pageId;
                    signature.Sheets[i].outSide_Front = new PrintQuad() { page = signature.pages.Where(p => p.pageNum == pageId).FirstOrDefault(), sheet = signature.Sheets[i] };
                    pageId++;
                    signature.Sheets[i].inSide_Front = new PrintQuad() { page = signature.pages.Where(p => p.pageNum == pageId).FirstOrDefault(), sheet = signature.Sheets[i] };
                    pageId++;
                }
                for (int i = signature.Sheets.Count - 1; i >= 0; i--)
                {
                    int t = signature.Sheets.Count / 2;
                    signature.Sheets[i].inSide_Back = new PrintQuad() { page = signature.pages.Where(p => p.pageNum == pageId).FirstOrDefault(), sheet = signature.Sheets[i] };
                    pageId++;
                    signature.Sheets[i].outSide_Back = new PrintQuad() { page = signature.pages.Where(p => p.pageNum == pageId).FirstOrDefault(), sheet = signature.Sheets[i] };
                    pageId++;
                }
            }
        }

        public void OutputSheets()
        {
            foreach (Signature signature in this.Signatures)
            {
                foreach (PrintSheet sheet in signature.Sheets)
                {
                    sheet.CreateInsideImage();
                    sheet.CreateOutsideImage();
                }
            }
        }
    }
}
