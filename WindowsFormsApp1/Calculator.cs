using System;
using System.Data;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        #region GlobalProperties
        bool operation = false;
        bool finalRest = false;
        #endregion

        #region Events
        public Calculator()
        {
            InitializeComponent();
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 1;
            txScreen.Text += val;
            //Equation.Add()
        }
        private void Btn2_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 2;
            txScreen.Text += val;
        }
        private void Btn3_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 3;
            txScreen.Text += val;
        }
        private void Btn4_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 4;
            txScreen.Text += val;
        }
        private void Btn5_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 5;
            txScreen.Text += val;
        }
        private void Btn6_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 6;
            txScreen.Text += val;
        }
        private void Btn7_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 7;
            txScreen.Text += val;
        }
        private void Btn8_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 8;
            txScreen.Text += val;
        }
        private void Btn9_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 9;
            txScreen.Text += val;
        }
        private void Btn0_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            operation = false;
            int val = 0;
            txScreen.Text += val;
        }
        private void BtnDot_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            string val = ".";
            if (!operation && txScreen.Text.Trim() != string.Empty) { txScreen.Text += val; };
            operation = true;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            string val = "+";
            if (!operation && txScreen.Text.Trim() != string.Empty) { txScreen.Text += val; };
            operation = true;
        }
        private void BtnSubtrack_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            string val = "-";
            if (!operation && txScreen.Text.Trim() != string.Empty) { txScreen.Text += val; };
            operation = true;
        }
        private void BtnMultiply_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            string val = "*";
            if (!operation && txScreen.Text.Trim() != string.Empty) { txScreen.Text += val; };
            operation = true;
        }
        private void BtnDivide_Click(object sender, EventArgs e)
        {
            VerifyEquals();
            string val = "/";
            if (!operation && txScreen.Text.Trim() != string.Empty) { txScreen.Text += val; };
            operation = true;
        }
        private void BtnEqual_Click(object sender, EventArgs e)
        {
            string expr = txScreen.Text.Replace(",", ".");
            var result = new DataTable().Compute(expr, null);
            txScreen.Text = Convert.ToString(result);
            finalRest = true;
        }
        private void BtnCe_Click(object sender, EventArgs e)
        {
            txScreen.Text = string.Empty;
        }
        private void BtnPorcentage_Click(object sender, EventArgs e)
        {

            int finalMajor = 0;
            double porcentageIni = 0;
            double totalCant = 0;

            if (txScreen.Text != string.Empty)
            {
                finalMajor = DefineMajor();
                if (finalMajor != -1)
                {
                    string sim = Convert.ToString(txScreen.Text.Substring(finalMajor)[0]);
                    porcentageIni = Convert.ToDouble(txScreen.Text.Substring(finalMajor + 1)) * 0.01;
                    txScreen.Text = txScreen.Text.Remove(finalMajor, (txScreen.Text.Length) - finalMajor);
                    finalMajor = DefineMajor();
                    totalCant = Convert.ToDouble(txScreen.Text.Substring(finalMajor + 1));
                    txScreen.Text = txScreen.Text.Remove(finalMajor + 1, (txScreen.Text.Length - 1) - finalMajor);
                    string stringResult = (totalCant + sim + (totalCant * porcentageIni));
                    string expr = stringResult.Replace(",", ".");
                    var result = new DataTable().Compute(expr, null);
                    txScreen.Text += result;
                }
            }
        }
        private void BtnSquare_Click(object sender, EventArgs e)
        {
            int positionSqrt = txScreen.Text.Length;
            double numberToSqrt = 0;
            int finalMajor = DefineMajor();

            if (finalMajor == -1)
            {
                numberToSqrt = Convert.ToDouble(txScreen.Text);
                txScreen.Text = Convert.ToString(Math.Sqrt(numberToSqrt));
            }
            else
            {
                numberToSqrt  = Convert.ToDouble(txScreen.Text.Substring(finalMajor));
                txScreen.Text = txScreen.Text.Remove(finalMajor + 1, (txScreen.Text.Length - 1) - finalMajor);
                txScreen.Text += Math.Sqrt(numberToSqrt);
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txScreen.Text != string.Empty)
            {
                txScreen.Text = txScreen.Text.Substring(0, txScreen.Text.Length - 1);
            }
        }
        private void TxScreen_TextChanged(object sender, EventArgs e)
        {
            if ((txScreen.Text.Length - 1) > 1)
            {
                string lastCharacter = Convert.ToString(txScreen.Text[txScreen.Text.Length - 1]).Trim();
                if (lastCharacter == "+" || lastCharacter == "-" || lastCharacter == "*" || lastCharacter == "/" || lastCharacter == ".")
                {
                    btnEqual.Enabled = false;
                }
                else
                {
                    btnEqual.Enabled = true;
                }
            }
        }
        #endregion

        #region Methods
        private void VerifyEquals()
        {
            if (finalRest)
            {
                txScreen.Text = string.Empty;
                finalRest = false;
            }
        }
        private int DefineMajor()
        {
            int finalMajor = 0;
            int major1 = 0;
            int major2 = 0;

            if (txScreen.Text.LastIndexOf('+') > txScreen.Text.LastIndexOf('-'))
            {
                major1 = txScreen.Text.LastIndexOf('+');
            }
            else
            {
                major1 = txScreen.Text.LastIndexOf('-');
            }

            if (txScreen.Text.LastIndexOf('*') > txScreen.Text.LastIndexOf('/'))
            {
                major2 = txScreen.Text.LastIndexOf('*');
            }
            else
            {
                major2 = txScreen.Text.LastIndexOf('/');
            }


            if (major1 > major2)
            {
                finalMajor = major1;
            }
            else
            {
                finalMajor = major2;
            }

            return finalMajor;
        }
        #endregion
    }
}

