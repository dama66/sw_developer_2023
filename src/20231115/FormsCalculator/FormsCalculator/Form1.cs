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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        #region Numbers

        private void btt_1_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "1";
                lbl_calc.Text = lbl_calc.Text + "1";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "1";
                lbl_calc.Text = lbl_calc.Text + "1";
            }
        }

        private void btt_2_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "2";
                lbl_calc.Text = lbl_calc.Text + "2";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "2";
                lbl_calc.Text = lbl_calc.Text + "2";
            }
        }

        private void btt_3_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "3";
                lbl_calc.Text = lbl_calc.Text + "3";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "3";
                lbl_calc.Text = lbl_calc.Text + "3";
            }
        }

        private void btt_4_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "4";
                lbl_calc.Text = lbl_calc.Text + "4";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "4";
                lbl_calc.Text = lbl_calc.Text + "4";
            }
        }

        private void btt_5_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "5";
                lbl_calc.Text = lbl_calc.Text + "5";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "5";
                lbl_calc.Text = lbl_calc.Text + "5";
            }
        }

        private void btt_6_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "6";
                lbl_calc.Text = lbl_calc.Text + "6";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "6";
                lbl_calc.Text = lbl_calc.Text + "6";
            }
        }

        private void btt_7_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "7";
                lbl_calc.Text = lbl_calc.Text + "7";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "7";
                lbl_calc.Text = lbl_calc.Text + "7";
            }
        }

        private void btt_8_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "8";
                lbl_calc.Text = lbl_calc.Text + "8";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "8";
                lbl_calc.Text = lbl_calc.Text + "8";
            }
        }

        private void btt_9_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
                lbl_result.Text = "9";
                lbl_calc.Text = lbl_calc.Text + "9";
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "9";
                lbl_calc.Text = lbl_calc.Text + "9";
            }
        }

        private void btt_0_Click(object sender, EventArgs e)
        {
            if (lbl_result.Text == "0" && lbl_result.Text != null)
            {
               return;
            }
            else
            {
                lbl_result.Text = lbl_result.Text + "0";
                lbl_calc.Text = lbl_calc.Text + "0";
            }
        }
        #endregion

        #region Operations
        private void btt_add_Click(object sender, EventArgs e)
        {
            OperationClickEvent("+");
        }

        private void btt_sub_Click(object sender, EventArgs e)
        {
            OperationClickEvent("-");
        }

        private void btt_mul_Click(object sender, EventArgs e)
        {
            OperationClickEvent("*");
        }

        private void btt_div_Click(object sender, EventArgs e)
        {
            OperationClickEvent("/");
        }

        private void btt_dot_Click(object sender, EventArgs e)
        {
            lbl_result.Text = lbl_result.Text + ".";
            lbl_calc.Text = lbl_calc.Text + ".";
        }

        private void btt_equ_Click(object sender, EventArgs e)
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

        private void btt_clear_Click(object sender, EventArgs e)
        {
            firstNumber = 0.0;
            secondNumber = 0.0;
            lbl_calc.Text = string.Empty;
            lbl_result.Text = "0";
        }
        #endregion

        private void OperationClickEvent(string op)
        {
            if (firstNumber > 0)
            {
                secondNumber = Convert.ToDouble(lbl_result.Text);

                if (operation == "+")
                {
                    result = (firstNumber + secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                }

                if (operation == "-")
                {
                    result = (firstNumber - secondNumber);
                    lbl_result.Text = Convert.ToString(result);
                }

                if (operation == "*")
                {
                    result = (firstNumber * secondNumber);
                    lbl_result.Text = Convert.ToString(result);
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
