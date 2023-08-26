using Core.Application.Cnaes;
using Core.Application.Estabelecimentos;
using MediatR;
using System.Diagnostics;

namespace WinApp
{
    public partial class FormMain : Form
    {
        private readonly ISender mediator;
        private CancellationTokenSource? cancellationTokenSource;

        public FormMain(ISender mediator)
        {
            InitializeComponent();
            this.mediator = mediator;
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            PreencherEstados();
            await PreencherCnaes();
        }

        private async Task PreencherCnaes()
        {
            cbxCnaes.DataSource = await mediator.Send(new GetCnaesRequest()); ;
            cbxCnaes.DisplayMember = "Display";
            cbxCnaes.ValueMember = "Codigo";
            cbxCnaes.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbxCnaes.SelectedIndex = -1;
        }

        private void PreencherEstados()
        {
            List<string> estados = new()
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG",
                "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
            };
            cbxEstados.DataSource = estados;
            cbxEstados.SelectedIndex = -1;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                return;
            }

            SetUIState(true);
            dataGrid.DataSource = null;
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                if (!string.IsNullOrEmpty(txtCnpj.Text))
                {
                    var request = new GetEstabelecimentoRequest()
                    {
                        Cnpj = txtCnpj.Text
                    };
                    var estabelecimento = await mediator.Send(request, cancellationTokenSource.Token);
                    dataGrid.DataSource = new List<EstabelecimentoInfoDto>() { estabelecimento };
                }
                else
                {
                    var request = new SearchEstabelecimentosRequest()
                    {
                        Cep = txtCep.Text,
                        CnaeFiscalPrincipal = cbxCnaes.SelectedValue as string,
                        Uf = cbxEstados.SelectedValue as string,
                        SituacaoCadastral = "02" //Ativa
                    };
                    dataGrid.DataSource = await mediator.Send(request, cancellationTokenSource.Token);
                }
            }
            finally
            {
                SetUIState(false);
                btnBuscar.Text = "Filtrar";
                progressBar.Visible = false;
                panelAcoes.Enabled = true;
                cancellationTokenSource = null;
            }

            void SetUIState(bool searching)
            {
                btnBuscar.Text = searching ? "Cancelar" : "Filtrar";
                labelStatus.Text = searching ? "Executando pesquisa" : string.Empty;
                progressBar.Visible = searching;
                panelAcoes.Enabled = !searching;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCep.Text = string.Empty;
            txtCnpj.Text = string.Empty;
            cbxCnaes.SelectedIndex = -1;
            cbxEstados.SelectedIndex = -1;
        }

        private async void btnExportar_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
                return;
            }

            using SaveFileDialog saveFileDialog = new()
            {
                Filter = "Arquivo CSV (*.csv)|*.csv",
                Title = "Salvar arquivo CSV",
                FileName = "dados.csv"
            };
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            SetUIState(true);

            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                var request = new ExportEstabelecimentosRequest
                {
                    Cep = txtCep.Text,
                    CnaeFiscalPrincipal = cbxCnaes.SelectedValue as string,
                    Uf = cbxEstados.SelectedValue as string,
                    SituacaoCadastral = "02", //Ativa
                    FilePath = saveFileDialog.FileName
                };
                await mediator.Send(request, cancellationTokenSource.Token);

                MessageBox.Show("Exportação realizado com sucesso.", "Sucesso");
                Process.Start("explorer.exe", Path.GetDirectoryName(request.FilePath)!);
            }
            finally
            {
                SetUIState(false);
                cancellationTokenSource = null;
            }

            void SetUIState(bool exporting)
            {
                btnExportar.Text = exporting ? "Cancelar" : "Exportar para CSV";
                labelStatus.Text = exporting ? "Executando exportação" : string.Empty;
                panelPesquisar.Enabled = !exporting;
                progressBar.Visible = exporting;
            }
        }
    }
}
