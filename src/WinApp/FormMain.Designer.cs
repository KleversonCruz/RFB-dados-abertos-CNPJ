namespace WinApp
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            btnLimpar = new Button();
            cbxCnaes = new ComboBox();
            label2 = new Label();
            cbxEstados = new ComboBox();
            txtCep = new TextBox();
            label1 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnBuscar = new Button();
            txtCnpj = new TextBox();
            dataGrid = new DataGridView();
            btnExportar = new Button();
            progressBar = new ProgressBar();
            panelAcoes = new Panel();
            labelStatus = new Label();
            panelPesquisar = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
            panelAcoes.SuspendLayout();
            panelPesquisar.SuspendLayout();
            SuspendLayout();
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(97, 97, 97);
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(139, 117);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(121, 24);
            btnLimpar.TabIndex = 6;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // cbxCnaes
            // 
            cbxCnaes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbxCnaes.FormattingEnabled = true;
            cbxCnaes.Location = new Point(266, 78);
            cbxCnaes.Name = "cbxCnaes";
            cbxCnaes.Size = new Size(362, 23);
            cbxCnaes.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(266, 58);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 25;
            label2.Text = "CNAE";
            // 
            // cbxEstados
            // 
            cbxEstados.FormattingEnabled = true;
            cbxEstados.Location = new Point(12, 78);
            cbxEstados.Name = "cbxEstados";
            cbxEstados.Size = new Size(121, 23);
            cbxEstados.TabIndex = 2;
            // 
            // txtCep
            // 
            txtCep.Location = new Point(139, 78);
            txtCep.Name = "txtCep";
            txtCep.Size = new Size(121, 23);
            txtCep.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 59);
            label1.Name = "label1";
            label1.Size = new Size(28, 15);
            label1.TabIndex = 27;
            label1.Text = "CEP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 60);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 23;
            label4.Text = "UF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 16);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 22;
            label3.Text = "CNPJ";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.FromArgb(33, 33, 33);
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(12, 117);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(121, 24);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtCnpj
            // 
            txtCnpj.Location = new Point(12, 34);
            txtCnpj.Name = "txtCnpj";
            txtCnpj.Size = new Size(121, 23);
            txtCnpj.TabIndex = 1;
            // 
            // dataGrid
            // 
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.BackgroundColor = Color.White;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGrid.GridColor = SystemColors.ControlLight;
            dataGrid.Location = new Point(12, 163);
            dataGrid.Name = "dataGrid";
            dataGrid.ReadOnly = true;
            dataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGrid.RowHeadersVisible = false;
            dataGrid.Size = new Size(776, 283);
            dataGrid.TabIndex = 4;
            dataGrid.TabStop = false;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.FromArgb(97, 97, 97);
            btnExportar.FlatAppearance.BorderSize = 0;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(12, 13);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(121, 24);
            btnExportar.TabIndex = 7;
            btnExportar.Text = "Exportar para CSV";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(688, 17);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 15);
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.TabIndex = 21;
            progressBar.Visible = false;
            // 
            // panelAcoes
            // 
            panelAcoes.Controls.Add(labelStatus);
            panelAcoes.Controls.Add(btnExportar);
            panelAcoes.Controls.Add(progressBar);
            panelAcoes.Dock = DockStyle.Bottom;
            panelAcoes.Location = new Point(0, 452);
            panelAcoes.Name = "panelAcoes";
            panelAcoes.Size = new Size(800, 49);
            panelAcoes.TabIndex = 22;
            // 
            // labelStatus
            // 
            labelStatus.Location = new Point(514, 17);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(168, 15);
            labelStatus.TabIndex = 22;
            labelStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelPesquisar
            // 
            panelPesquisar.Controls.Add(btnLimpar);
            panelPesquisar.Controls.Add(label3);
            panelPesquisar.Controls.Add(cbxCnaes);
            panelPesquisar.Controls.Add(txtCnpj);
            panelPesquisar.Controls.Add(label2);
            panelPesquisar.Controls.Add(btnBuscar);
            panelPesquisar.Controls.Add(cbxEstados);
            panelPesquisar.Controls.Add(label4);
            panelPesquisar.Controls.Add(txtCep);
            panelPesquisar.Controls.Add(label1);
            panelPesquisar.Dock = DockStyle.Top;
            panelPesquisar.Location = new Point(0, 0);
            panelPesquisar.Name = "panelPesquisar";
            panelPesquisar.Size = new Size(800, 156);
            panelPesquisar.TabIndex = 23;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 501);
            Controls.Add(panelPesquisar);
            Controls.Add(panelAcoes);
            Controls.Add(dataGrid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta CNPJ";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
            panelAcoes.ResumeLayout(false);
            panelPesquisar.ResumeLayout(false);
            panelPesquisar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox cbxCnaes;
        private Label label2;
        private ComboBox cbxEstados;
        private TextBox txtCep;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button btnBuscar;
        private TextBox txtCnpj;
        private DataGridView dataGrid;
        private Button btnLimpar;
        private Button btnExportar;
        private ProgressBar progressBar;
        private Panel panelAcoes;
        private Panel panelPesquisar;
        private Label labelStatus;
    }
}