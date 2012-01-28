using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Tower_defense
{
  public partial class GameConfSelector : Form
  {
    public GameConfSelector()
    {
      InitializeComponent();
    }

    private void BCancel_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.Cancel;
    }

    private void BSelect_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
    }

    private void GameConfSelector_Load(object sender, EventArgs e)
    {
      DirectoryInfo DIForListLoad = new DirectoryInfo(Environment.CurrentDirectory + "\\Data\\GameConfigs\\");
      FileInfo[] GameConfigs = DIForListLoad.GetFiles();
      foreach (FileInfo i in GameConfigs)
      {
        if (i.Extension == ".tdgc")
        {
          LBGameConf.Items.Add(i.Name.Substring(0,i.Name.Length-5));
        }
      }
      if (LBGameConf.Items.Count == 0)
      {
        MessageBox.Show("Configurations not founded!");
        this.DialogResult = DialogResult.Abort;
      }
      else
        LBGameConf.SelectedIndex = 0;
    }

    public string ReturnConfigName()
    {
      //if (LBGameConf.SelectedIndex >= 0)
        return Convert.ToString(LBGameConf.SelectedItem);
      /*else
        return null;*/
    }
  }
}
