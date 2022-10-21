using BillingSystem.MODULES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.VIEW
{
    public partial class frmBackuprestore : Form
    {
        public frmBackuprestore()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            //SFD.Filter = "*.harbsbilling_backup|*.harbsbilling_backup";
            SFD.Filter = "*.sql_bkup|*.sql_bkup";
            if (SFD.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            //database configuaration
            string Myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection conn = new SqlConnection(Myconstr);

            string ErrorMSG = "";
            try
            {
                BackupRestoreModule bkupModule = new BackupRestoreModule();

                bool saveDB = bkupModule.SaveDatabase(conn, SFD.FileName);
                if (!saveDB)
                {
                    throw new Exception(ErrorMSG);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }


        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            //OFD.Filter = "*.harbsbilling_backup|*.harbsbilling_backup";
            OFD.Filter = "*.sql_bkup|*.sql_bkup";
            if (OFD.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            //database configuaration
            string Myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection conn = new SqlConnection(Myconstr);

            string ErrorMSG = "";
            try
            {
                BackupRestoreModule bkupModule = new BackupRestoreModule();

                bool saveDB = bkupModule.LoadDatabase(conn, OFD.FileName);
                if (!saveDB)
                {
                    throw new Exception(ErrorMSG);
                }

                MessageBox.Show("Restore Completed Successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
