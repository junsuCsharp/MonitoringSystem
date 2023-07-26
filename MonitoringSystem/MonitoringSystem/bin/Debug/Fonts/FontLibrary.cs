using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing;

namespace Fonts
{
    public class FontLibrary
    {
        public enum ENotoSans
        { 
            Normal, Black, ExtraBold, ExtraLight, Light, Medium, SemiBold, Thin
        }


        private static FontLibrary inst = new FontLibrary();
        public PrivateFontCollection privateFont = new PrivateFontCollection();
        public static FontFamily[] Families
        {
            get
            {
                return inst.privateFont.Families;
            }
        }

        public FontLibrary()
        {
            AddFontFromMemory();
        }

        private void AddFontFromMemory()
        {
            try
            {
                List<byte[]> fonts = new List<byte[]>();

                string path1 = Directory.GetCurrentDirectory();
                string path = @"C:\Users\Note Book_2\source\repos\MonitoringSystem - 2023.06.29\MonitoringSystem";
                //privateFont.AddFontFile(Directory.GetCurrentDirectory() + @"\Fonts\NotoMono-Regular.ttf");              //00

                int a = 1 - 1;
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-Black.ttf");                //00
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-BlackItalic.ttf");          //01
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-Bold.ttf");                 //02
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-BoldItalic.ttf");           //03
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-ExtraBold.ttf");            //04
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-ExtraBoldItalic.ttf");      //05
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-ExtraLight.ttf");           //06
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-ExtraLightItalic.ttf");     //07
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-Italic.ttf");               //08
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-Light.ttf");                //09
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-LightItalic.ttf");          //10
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-Medium.ttf");               //11
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-MediumItalic.ttf");         //12
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-Regular.ttf");              //13
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-SemiBold.ttf");             //14
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-SemiBoldItalic.ttf");       //15
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-Thin.ttf");                 //16
                privateFont.AddFontFile(path + @"\Fonts\NotoSans-ThinItalic.ttf");           //17

                foreach (byte[] font in fonts)
                {
                    IntPtr fontBuffer = Marshal.AllocCoTaskMem(font.Length);
                    Marshal.Copy(font, 0, fontBuffer, font.Length);
                    privateFont.AddMemoryFont(fontBuffer, font.Length);
                }
            }
            catch
            { 
                
            }           
        }

    }
}
