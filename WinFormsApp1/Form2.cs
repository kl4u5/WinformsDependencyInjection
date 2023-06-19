namespace TestDiWinFormsApp1
{
    public partial class Form2 : Form
    {
        private IHelloWorldService _service;
        private string _something;

        public Form2(IHelloWorldService service, string something)
        {
            InitializeComponent();

            this._service = service;
            this._something = something;

            this.Text = something;
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            var res = _service.DoWork();
            MessageBox.Show(this, res);
        }
    }
}
