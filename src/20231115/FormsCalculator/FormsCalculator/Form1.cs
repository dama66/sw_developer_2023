using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsCalculator
{
    public partial class Calculator : Form
    {

        double firstNumber = 0.0;
        string operation = string.Empty;
        double secondNumber = 0.0;
        double result = 0.0;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            lbl_result.Text = "0";
        }

        private void Numeric_Button_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;

            if (clickedButton == null)
            {
                return;
            }

            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = clickedButton.Text;
                lbl_calc.Text += clickedButton.Text;
            }
            else
            {
                lbl_result.Text +=  clickedButton.Text;
                lbl_calc.Text += clickedButton.Text;
            }
        }

        private void Operator_Button_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;

            OperationClickEvent(clickedButton.Text);
        }

        private void btt_dot_Click(object sender, EventArgs e)
        {
            lbl_result.Text += ".";
            lbl_calc.Text += ".";
        }

        private void btt_equ_Click(object sender, EventArgs e)
        {
            if(operation != string.Empty)
                {
                secondNumber = Convert.ToDouble(lbl_result.Text);

                lbl_calc.Text = lbl_calc.Text + "=";

                if (operation == "+")
                {
                    result = (firstNumber + secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                    firstNumber = result;
                }
                if (operation == "-")
                {
                    result = (firstNumber - secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                    firstNumber = result;
                }
                if (operation == "*")
                {
                    result = (firstNumber * secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                    firstNumber = result;
                }
                if (operation == "/")
                {
                    if (secondNumber == 0)
                    {
                        lbl_result.Text = "Cannot divide by zero";

                    }
                    else
                    {
                        result = (firstNumber / secondNumber);
                        lbl_result.Text = Convert.ToString(result);
                        firstNumber = result;
                    }
                }
            }
        }

        private void btt_clear_Click(object sender, EventArgs e)
        {
            firstNumber = 0.0;
            secondNumber = 0.0;
            lbl_calc.Text = string.Empty;
            lbl_result.Text = "0";
        }

     
        private void OperationClickEvent(string op)
        {

            if (firstNumber > 0)
            {
                secondNumber = Convert.ToDouble(lbl_result.Text);
                
                if (operation == "+")
                {
                    result = (firstNumber + secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                    operation = string.Empty;
                }

                if (operation == "-")
                {
                    result = (firstNumber - secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                    operation = string.Empty;
                }

                if (operation == "*")
                {
                    result = (firstNumber * secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                    operation = string.Empty;
                }

                if (operation == "/")
                {
                    if (secondNumber == 0)
                    {
                        lbl_result.Text = "Cannot divide by zero";
                    }
                    else
                    {
                        result = (firstNumber / secondNumber);
                        lbl_result.Text = Convert.ToString(result);
                    }
                    operation = string.Empty;
                }

                operation = op;
                secondNumber = 0.0;
                firstNumber = result;
                lbl_calc.Text = lbl_result.Text + operation;
                lbl_result.Text = "0";
            }
            else
            {
                firstNumber = Convert.ToDouble(lbl_result.Text);
                lbl_result.Text = "0";
                operation = op;
                lbl_calc.Text += operation;
            }
        }


    }
}
