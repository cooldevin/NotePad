using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    /// <summary>
    /// 全局配置文件类
    /// 
    /// </summary>
    class Config
    {
        public static string filePath = "font.dll";//保存路径
        public static Font getFont()
        {
            Font font = null;
            if (File.Exists(filePath))
            {
              
                string content = File.ReadAllText(filePath);
                string[] contents = content.Split(',');
                string fontFamily = contents[0];
                float size = float.Parse(contents[1]);
                FontStyle style = (FontStyle)Enum.Parse(typeof(FontStyle), contents[2]);
                font = new Font(fontFamily, size, style);
            }
            return font;
        }
    }
}
