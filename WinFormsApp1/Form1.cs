namespace TestDiWinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly IHelloWorldService _service;

        public Form1(IHelloWorldService service)
        {
            InitializeComponent();
            this._service = service;
        }

        private void btnSayHello_Click(object sender, EventArgs e)
        {
            var res = _service.DoWork();
            MessageBox.Show(this, res);
        }

        private void btnOpenFileDialog_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                MessageBox.Show(this, openFileDialog1.FileName);
            } 
            else
            {
                MessageBox.Show(this, res.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new FormFactory().CreateForm2(this.textBox1.Text);
            form2.Show();
        }
    }
}