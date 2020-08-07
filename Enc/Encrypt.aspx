<%@ Page Title="Encrypt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Encrypt.aspx.cs" Inherits="Enc.Encrypt" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .m {
            display: inline-block;
            margin: 10px;
            top: 10px;
        }

        .textarea {
            margin: 5px;
            width: 90%;
            height: 200px;
            resize: none;
            max-width: 600px;
            display: inline-block;
        }
        .lil{
            margin:5px;
        }
        
    </style>
   
    <div class="m">
        <asp:FileUpload id="FileUploadControl" runat="server" CssClass="m"/>
        <asp:Button runat="server" id="UploadButton" text="Выгрузить данные" onclick="UploadButton_Click" type="button" class="btn btn-success" />
        <asp:Button runat="server" ID="Next" Visible="false" type="button" text="Попробовать в кодировке ANSI" class="btn btn-success" name="encrypt" onclick ="NextCoder" ></asp:Button>
   
   </div>
    <div>
        <h3>
            Данные
        </h3>
       <asp:TextBox ID="before" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
        
    </div>
    <div>
        <h3>Введите ключ</h3>
        <asp:TextBox runat="server" ID="Key" class="m" size="40"></asp:TextBox>
        <asp:Label runat ="server" ID ="NoKey" Enabled="false"></asp:Label>
    </div>
    <div>
        <asp:Button runat="server" ID="EncryptBtn" type="button" text="Зашифровать" class="btn btn-success" name="encrypt" onclick ="VisinerEnc"></asp:Button>
    </div>
    <div>
        <h3>
            После шифровки
        </h3>
       <asp:TextBox ID="after" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
        <asp:Button runat="server" ID="DownloadBtn"  type="button" text="Скачать файл" class="btn btn-info" name="download" onclick ="ShowTB"></asp:Button>
        <asp:Label runat ="server" ID ="nameFile" Visible = "false"></asp:Label>
        <asp:TextBox ID="showTB" runat="server"  Visible = "false"></asp:TextBox>
        <asp:Button runat="server" ID="DownloadLast" Visible = "false" type="button" text="Скачать .txt" class="btn btn-info" name="download_last" onclick ="DownloadTxt"></asp:Button>
        <asp:Button runat="server" ID="DownloadLastDocX" Visible = "false" type="button" text="Скачать .docx" class="btn btn-info" name="download_last_docx" onclick ="DownloadDocX"></asp:Button>
    </div>    
        

    
   
</asp:Content>


