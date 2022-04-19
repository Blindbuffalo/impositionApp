using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace impositionApp
{
    public partial class Form1 : Form
    {
        public Book book = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void bttnRun_Click(object sender, EventArgs e)
        {
            book = new Book();
            GetUserInputs();
            Dictionary<int, FileInfo> files = GetDictionaryOfFiles();

            book.BuildSignatures(files);
            book.LayoutSheets();
            book.OutputSheets();

        }

        public PictureBox BuildPictureBox(Bitmap page)
        {
            PictureBox p = new PictureBox();
            p.Width = 1000;
            p.Height = 2000;
            p.SizeMode = PictureBoxSizeMode.Zoom;
            p.Image = page;
            return p;
        }
        public void GetUserInputs()
        {
            this.book.pagesPerSignature = int.Parse( this.tbPagesPerSig.Text );
            this.book.widthInch = float.Parse(this.tbWidthIN.Text);
            this.book.heightInch = float.Parse(this.tbHeightIn.Text);
            this.book.DPI = float.Parse(this.tbDPI.Text);
            this.book.OutputDir = new DirectoryInfo(this.tboutputPath.Text);
            this.book.InputDir = new DirectoryInfo(this.tbinputPath.Text);
        }


        public Dictionary<int, FileInfo> GetDictionaryOfFiles()
        {

            Dictionary<int, FileInfo> pages = new Dictionary<int, FileInfo>();
            
            if (this.book.InputDir.Exists)
            {
                List<FileInfo> files = this.book.InputDir.GetFiles("*.png").ToList();

                
                foreach (FileInfo file in files)
                {
                    string[] t = file.Name.Split("_");
                    string filePageNum = t[t.Length - 1].Split(".")[0];
                    int pageNum = int.Parse(filePageNum);

                    pages.Add(pageNum, file);
                }
            }
            return pages;
        }

        private void bttnFixText_Click(object sender, EventArgs e)
        {
            //doChapters();
            doChapter(13);
        }

        public string paddZeros(int num)
        {
            switch (num.ToString().Length)
            {
                case 1:
                    return "00" + num.ToString();
                case 2:
                    return "0" + num.ToString();
                case 3:
                case 4:
                    return num.ToString();
                default:
                    return num.ToString();
            }
        }
        public void doChapters()
        {
            for (int i = 14; i <= 19; i++)
            {
                doChapter(i);
            }

        }
        public void doChapter(int chapterNum)
        {
            string chapterText = System.IO.File.ReadAllText(@"M:\Google Drive\!Art\Hobbit\HobbitText\" + paddZeros(chapterNum) + ".txt");

            Dictionary<int, int> LineBreakLocationsAndCount = new Dictionary<int, int>();

            LineBreakLocationsAndCount = GetPositionOfLineBreaks(chapterText);

            chapterText = RemoveSingleLineBreaks(chapterText, LineBreakLocationsAndCount);

            LineBreakLocationsAndCount = GetPositionOfLineBreaks(chapterText);

            chapterText = RemovePageBreaksLineBreaks(chapterText, LineBreakLocationsAndCount);

            LineBreakLocationsAndCount = GetPositionOfLineBreaks(chapterText);

            chapterText = RemoveExcessiveParagraphBreaks(chapterText, LineBreakLocationsAndCount);

            chapterText = ReplaceUnwantedChars(chapterText);

            chapterText = chapterText.ToLower();

            File.WriteAllText(@"M:\Google Drive\!Art\Hobbit\HobbitText\" + paddZeros(chapterNum) + "_edit.txt", chapterText);
        }
        public string ReplaceUnwantedChars(string chapterText)
        {

            chapterText = chapterText.Replace("?", ".");
            chapterText = chapterText.Replace("!", ".");
            chapterText = chapterText.Replace(",", "");
            chapterText = chapterText.Replace(";", ".");

            chapterText = chapterText.Replace("&", "and");

            chapterText = chapterText.Replace("-", " ");
            chapterText = chapterText.Replace("¬", " ");
            chapterText = chapterText.Replace("—", " ");

            chapterText = chapterText.Replace("“", "");
            chapterText = chapterText.Replace("”", "");
            chapterText = chapterText.Replace("\"", "");

            chapterText = chapterText.Replace("\'", "");
            chapterText = chapterText.Replace("’", "");
            chapterText = chapterText.Replace("‘", "");

            chapterText = chapterText.Replace("  ", " ");
            chapterText = chapterText.Replace("   ", " ");
            chapterText = chapterText.Replace("    ", " ");
            
            chapterText = chapterText.Replace(". \r\n", ".\r\n");
            chapterText = chapterText.Replace(". ", ".\u2002");
            return chapterText;
        }

        public Dictionary<int, int> GetPositionOfLineBreaks(string chapterText)
        {
            Dictionary<int, int> LineBreakLocationsAndCount = new Dictionary<int, int>();
            int i = 0;
            foreach (char c in chapterText)
            {
                if (c == ' ')
                {
                    int count = CheckForPageBreak(chapterText, i);
                    if (count > 0)
                    {
                        LineBreakLocationsAndCount.Add(i, count);
                    }

                }
                i++;
            }
            return LineBreakLocationsAndCount;
        }
        public string RemoveSingleLineBreaks(string chapterText, Dictionary<int, int> LineBreakLocationsAndCount)
        {
            List<int> keys = LineBreakLocationsAndCount.Keys.ToList();
            for (int i = keys.Count - 1; i > 0; i--)
            {
                int index = keys[i];
                int count = LineBreakLocationsAndCount[keys[i]];

                if (count == 1)
                {

  
                    chapterText = chapterText.Remove(index + 1, count * 2);
                    
                    
                }
            }
            return chapterText;
        }
        public string RemovePageBreaksLineBreaks(string chapterText, Dictionary<int, int> LineBreakLocationsAndCount)
        {
            List<int> keys = LineBreakLocationsAndCount.Keys.ToList();
            for (int i = keys.Count - 1; i > 0; i--)
            {
                int index = keys[i];
                int count = LineBreakLocationsAndCount[keys[i]];

                char c = chapterText[index - 1];
                if (!c.Equals('.') && !c.Equals('?') && !c.Equals('!') && !c.Equals('”') && !c.Equals('"') && !c.Equals('\''))
                {
                    int l = chapterText.Length;
                    int start = index - 1;
                    int leg = (count * 2) + 5;
                    string t = chapterText.Substring(start, leg);
                    chapterText = chapterText.Remove(index + 1, count * 2);
                    string t2 = chapterText.Substring(start, leg);
                }
            }
            return chapterText;
        }
        public string RemoveExcessiveParagraphBreaks(string chapterText, Dictionary<int, int> LineBreakLocationsAndCount)
        {
            List<int> keys = LineBreakLocationsAndCount.Keys.ToList();
            for (int i = keys.Count - 1; i > 0; i--)
            {
                int index = keys[i];
                int count = LineBreakLocationsAndCount[keys[i]];

                if (count == 1) { continue; }

                char c = chapterText[index - 1];
                

                //int l = chapterText.Length;
                //int start = index - 1;
                //int leg = (count * 2) + 5;
                //if(leg >= chapterText.Length)
                //{
                //    leg = chapterText.Length - start;
                //}
                //string t = chapterText.Substring(start, leg);
                chapterText = chapterText.Remove(index + 3, (count - 1) * 2);
                //string t2 = chapterText.Substring(start, leg);
                
            }
            return chapterText;
        }
        public int CheckForPageBreak(string chapterText, int index)
        {
            int i = index + 1;

            int count = 0;

            if(i >= chapterText.Length) { return 0;  }
            char next = chapterText[i];
            char next2 = chapterText[i + 1];
            if (next.Equals('\r') && next2.Equals('\n'))
            {
                count++;
                for (int c = i + 2; c < chapterText.Length; c = c + 2)
                {
                    char n = chapterText[c];
                    char n1 = chapterText[c + 1];
                    if (n.Equals('\r') && n1.Equals('\n'))
                    {
                        count++;

                        continue;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            return count;
        }
    }
}
