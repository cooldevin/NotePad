using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class FontConfig : Form
    {
        public FontConfig()
        {
            InitializeComponent();
        }
        /**
         * 窗体加载事件
         * */
        private void FontConfig_Load(object sender, EventArgs e)
        {
            //获取字体
            getFontFamily();
            //获取字形
            getFontStyle();
            //大小
            getFontSize();

            this.fontFamily.SelectedIndex = 10;
            this.fontStyle.SelectedIndex = 2;
            this.fontSize.SelectedIndex = 4;
        }

        //获取字体
        private void getFontFamily() {

            InstalledFontCollection ifc = new InstalledFontCollection();
            //循环读取系统自带的字体
            foreach(FontFamily item in ifc.Families)
            {
                this.fontFamily.Items.Add(item.Name);
            }
        }

        private void getFontStyle()
        {
           foreach(FontStyle style in Enum.GetValues(typeof(FontStyle))){
                this.fontStyle.Items.Add(style);
            }
        }

        private void getFontSize()
        {
            for(int i = 2; i <= 72;i+=2)
            {
                this.fontSize.Items.Add(i);
            }
        }

        public event Action<Font> fontSave; 

        private void button2_Click(object sender, EventArgs e)
        {
            string fontfamily = this.fontFamily.Text;
            float fontSize = float.Parse(this.fontSize.Text);
            FontStyle fontStyle =(FontStyle) Enum.Parse(typeof(FontStyle), this.fontStyle.Text);
            Font   font = new Font(fontfamily, fontSize,fontStyle);
            fontSave(font);
            File.WriteAllText(Config.filePath, $"{fontfamily},{fontSize},{fontStyle}");
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
