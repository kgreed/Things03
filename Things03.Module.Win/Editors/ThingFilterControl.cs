using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Things03.Module.BusinessObjects;

namespace Things03.Module.Win.Editors
{
    internal class ThingFilterControl : XtraUserControl
    {
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonApply;

        public ThingFilter Filter { get;  set; }
        public event Action ApplyFilter = delegate { };
        public ThingFilterControl()
        {
            InitializeComponent();
            Filter = new ThingFilter();
        }
        private void InitializeComponent()
        {
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(72, 46);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(270, 21);
            this.textBoxSearch.TabIndex = 0;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(396, 46);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(477, 46);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
            this.buttonApply.TabIndex = 2;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // ThingFilterControl
            // 
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxSearch);
            this.Name = "ThingFilterControl";
            this.Size = new System.Drawing.Size(750, 122);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Filter.Search = "";
            textBoxSearch.Text = Filter.Search;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Filter.Search = textBoxSearch.Text;

            ApplyFilter();
        }
    }
}
