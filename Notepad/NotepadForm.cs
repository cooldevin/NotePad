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

namespace Notepad
{
    public partial class NotepadForm : Form
    {
        public NotepadForm()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void NotepadForm_Load(object sender, EventArgs e)
        {
            this.txtContent.Font = Config.getFont();
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontConfig family = new FontConfig();
            family.fontSave += family_FontSave;
            family.ShowDialog();
        }

        private void family_FontSave(Font f)
        {
            this.txtContent.Font = f;
        }

        private void saveNote_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt";
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                //写入磁盘 持久化
                File.WriteAllText(saveFileDialog.FileName, this.txtContent.Text, Encoding.UTF8);
            }
        }

        private void openNote_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog= new OpenFileDialog();
            DialogResult result =   openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtContent.Text = File.ReadAllText(openFileDialog.FileName);
            }
            
        }
        ///自定义组合事件
        ///1、keyPrview置为true
        ///2、注册一个窗体按键事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotepadForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.S){
                saveNote_Click(sender,e);
            }
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
           DialogResult result =  colorDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.txtContent.ForeColor = colorDialog.Color;
            }
        }
    }
}
