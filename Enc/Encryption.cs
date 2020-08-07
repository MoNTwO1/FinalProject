using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enc;

namespace Enc
{
    public class Encryption
    {
        public string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public string Change()
        {
            string change = "Введите название файла";
            /*nameFile.Visible = true;
            nameFile.Text = "Введите название файла";
            showTB.Visible = true;
            DownloadLast.Visible = true;
            DownloadLastDocX.Visible = true;*/
            return change;
        }

        public bool TMethod()
        {
            return true;
        }

        public string EncVis(string text, string key)
        {
            string nText = "";
            var codeIndex = 0;
            for (int i = 0; i < text.Length; i++)
            {
                var letterIndex = alphabet.IndexOf(text[i]);
                var a = alphabet.IndexOf(key[codeIndex]);
                if (alphabet.IndexOf(text[i]) < 0)
                {
                    nText += text[i].ToString();
                }
                else
                {
                    nText += alphabet[(alphabet.Length + letterIndex + a) % alphabet.Length].ToString();
                    codeIndex++;
                    if (codeIndex == key.Length)
                    {
                        codeIndex = 0;
                    }


                }

            }
            return nText;
        }
    }
}