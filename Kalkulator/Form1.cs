using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        private double firstNumber;
        private string operation;

        public Form1()
        {
            InitializeComponent();
            tbScreen.Text = "0";
        }

        public void onBtnNumberClick(object sender, EventArgs e)
        {
            var clickedValue = (sender as Button).Text;

            if (tbScreen.Text == "0" && clickedValue != ",")
                tbScreen.Text = string.Empty;

            tbScreen.Text += clickedValue;
        }

        public void onBtnOperationClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            operation = button.Text;

            if (operation == "√")
            {
                firstNumber = double.Parse(tbScreen.Text);
                var result = Calculate(firstNumber, 0, operation); // secondNumber is not used for square root
                tbScreen.Text = result.ToString();
            }
            else
            {
                firstNumber = double.Parse(tbScreen.Text);
                tbScreen.Text = "0";
            }
        }

        public void OnBtnResultClick(object sender, EventArgs e)
        {
            var secondNumber = double.Parse(tbScreen.Text);
            var result = Calculate(firstNumber, secondNumber, operation);
            tbScreen.Text = result.ToString();
        }

        public double Calculate(double firstNumber, double secondNumber, string operation)
        {
            switch (operation)
            {
                case "+":
                    return firstNumber + secondNumber;
                case "-":
                    return firstNumber - secondNumber;
                case "*":
                    return firstNumber * secondNumber;
                case "√":
                    return Math.Sqrt(firstNumber);
                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Nie można dzielić przez 0!");
                        return 0;
                    }
                    return firstNumber / secondNumber;
                default:
                    throw new InvalidOperationException("Nieznana operacja: " + operation);
            }
        }

        public void OnBtnClearClick(object sender, EventArgs e)
        {
            tbScreen.Text = "0";
            firstNumber = 0;
            operation = string.Empty;
        }

        public void SetOperationBtnState(bool value)
        {
            plus.Enabled = value;
            mnozenie.Enabled = value;
            dzielenie.Enabled = value;
            minus.Enabled = value;
            pierwiastek.Enabled = value;
        }

        public void SetResultBtnState(bool value)
        {
            result.Enabled = value;
        }
    }
}
