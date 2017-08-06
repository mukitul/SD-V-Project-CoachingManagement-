using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachingManagement
{
    public partial class ApplicationFormPrintPreview : Form
    {
        public ApplicationFormPrintPreview()
        {
            InitializeComponent();
        }

        private void ApplicationFormPrintPreview_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'coachingmanagementDataSet.StudentResult' table. You can move, or remove it, as needed.
            this.StudentResultTableAdapter.Fill(this.coachingmanagementDataSet.StudentResult);

            this.reportViewer1.RefreshReport();
        }
    }
}
