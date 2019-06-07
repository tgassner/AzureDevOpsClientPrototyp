using AzureDevOpsClientPrototypLogic;
using Microsoft.VisualStudio.Services.WebApi;
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

namespace AzureDevOpsClientPrototypWinForm {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void ButtonGO_Click(object sender, EventArgs e) {
            try {
                Int32.Parse(textBoxWorkItemId.Text);
            } catch (FormatException) {
                MessageBox.Show("WorkItem Id has to be a number!!!");
                return;
            }
            try {
                Downloader downloader = new Downloader();
                string str = downloader.download(textBoxOrganisationName.Text, textBoxPersonalAccessToken.Text, textBoxProjectName.Text, Int32.Parse(textBoxWorkItemId.Text));
                textBoxResult.Text = str;
            } catch (VssServiceResponseException ex) {
                MessageBox.Show(ex.Message, "Error while loading");
                return;
            }
        }
    }
}
