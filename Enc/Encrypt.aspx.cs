using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Enc
{

    public partial class Encrypt : Page
    {
        
        public string EncryptText { get; set; }

        public string s = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void NextCoder(object sender, EventArgs e)
        {
            if (FileUploadControl.FileName.Split('.')[FileUploadControl.FileName.Split('.').Length - 1] == "txt")
            {
                FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUploadControl.FileName);
                Encoding code = Encoding.Default;
                var source = File.ReadAllText(Server.MapPath("~/Data/") + FileUploadControl.FileName, code);
                byte[] encBytes = code.GetBytes(source);
                byte[] utf8Bytes = Encoding.Convert(code, Encoding.UTF8, encBytes);
                s = Encoding.UTF8.GetString(utf8Bytes);
                before.Text = s;
                Next.Visible = false;
                File.Delete(Server.MapPath("~/Data/") + FileUploadControl.FileName);
            }   

        }
        public void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.FileName.Split('.')[FileUploadControl.FileName.Split('.').Length - 1] == "txt")
            {
                
                FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUploadControl.FileName);
                s = File.ReadAllText(Server.MapPath("~/Data/") + FileUploadControl.FileName);
                Next.Visible = true;
                before.Text = s;
                EncryptText = s;
                before.Text = s;
                File.Delete(Server.MapPath("~/Data/") + FileUploadControl.FileName);

            }
            else if (FileUploadControl.FileName.Split('.')[FileUploadControl.FileName.Split('.').Length - 1] == "docx")
            {
                FileUploadControl.PostedFile.SaveAs(Server.MapPath("~/Data/") + FileUploadControl.FileName);
                var text = "";
                using (var wordDocument = WordprocessingDocument.Open(Server.MapPath("~/Data/") + FileUploadControl.FileName as string, false))
                {
                    //получаем весь текст
                    text = wordDocument.MainDocumentPart.Document.Body.InnerText;
                    
                }
                
                EncryptText = text;
                before.Text = text;
               
            }
        }

        public void VisinerEnc(object sender, EventArgs e)
        {

            if (Key.Text == "")
            {
                NoKey.Visible = true;
                NoKey.Text = "Нужно ввести ключ";
            }
            else
            {
               
                EncryptVisiner(before.Text, Key.Text);
            }
            
            

        }

        public void EncryptVisiner(string text, string key)
        {

            Encryption encryption = new Encryption();
            after.Text = encryption.EncVis(text, key).ToString();

        }

        
        
        public void ShowTB(object sender, EventArgs e)
        {
            Encryption cry = new Encryption();
            nameFile.Text = cry.Change();
            nameFile.Visible = cry.TMethod();
            showTB.Visible = cry.TMethod();
            DownloadLast.Visible = cry.TMethod();
            DownloadLastDocX.Visible = cry.TMethod();
        }


        public void DownloadTxt(object sender, EventArgs e)
        {
            if (showTB.Text == null || showTB.Text == "")
            {
                
                nameFile.Text = "Нужно ввести название файла!";
            }
            else
            {
                string appPath = Server.MapPath("~/Data/");
                string filePath = appPath + showTB.Text+".txt";
                StreamWriter w;
                w = File.CreateText(filePath);
                w.Write(after.Text);
                
                w.Flush();
                w.Close();
                Response.Clear();
                Response.ContentType ="application/octet-stream";
                Response.AppendHeader("Content-Disposition", "filename="+ showTB.Text + ".txt");
                Response.TransmitFile(Server.MapPath("~/Data/") + showTB.Text + ".txt");
                Response.End();
                File.Delete(Server.MapPath("~/Data/")+ showTB.Text + ".txt");
            }

            

        }

        public void DownloadDocX(object sender, EventArgs e)
        {
            if (showTB.Text == null || showTB.Text == "")
            {
                nameFile.Text = "Нужно ввести название файла!";
            }
            else
            {
                using (MemoryStream mem = new MemoryStream())
                {
                    
                    using (WordprocessingDocument wordDocument =
                        WordprocessingDocument.Create(mem, WordprocessingDocumentType.Document, true))
                    {
                        
                        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                        
                        mainPart.Document = new Document();
                        Body body = mainPart.Document.AppendChild(new Body());
                        Paragraph para = body.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());

                        
                        run.AppendChild(new Text(after.Text));
                       
                    }

                    // Download File
                    Context.Response.AppendHeader("Content-Disposition","attachment;filename="+showTB.Text+".docx");
                    mem.Position = 0;
                    mem.CopyTo(Context.Response.OutputStream);
                    Context.Response.Flush();
                    Context.Response.End();
                    File.Delete(Server.MapPath("~/Data/") + showTB.Text + ".docx");
                }
            }
            

        }


    }

 }

