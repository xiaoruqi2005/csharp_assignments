namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Clear(object sender, EventArgs e)
        {
           textBox1.Clear();
           textBox2.Clear();
           textBox3.Clear();
           comboBox1.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s="";
            double result = 0;
            s=textBox1.Text;
            double x=double .Parse(s);
            s=textBox2.Text;
            double y=double .Parse(s);
            s = comboBox1.SelectedItem.ToString();
            switch (s)
            {
                case "+": result = x + y; break;
                case "-": result = x - y; break;
                case "*": result = x * y; break;
                case "/": 
                    if(y==0)
                    {
                        MessageBox.Show("除数不能为0！");
                        Clear(sender, e);
                        return;
                    }
                    result = x / y; break;
            }
            textBox3.Text = result.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}
