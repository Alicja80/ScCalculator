using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ScCalculator
{
    public partial class Calculator : Form
    {
        Double value = 0;
        String operation = "" ;
        bool operation_pressed = false;
        bool altPressed = false;
        private TrigLib trigLib;
        private CalMathLib calMathLib;
        private OperatorsLib operatorsLib;
        private PowersLib powersLib;
        
        public Calculator()
        {
            InitializeComponent();

            radioButton_Degree.Checked = true;
            radioButton_Radian.Checked = false;

            trigLib = new TrigLib(AngleType.DEGREES);
            operatorsLib = new OperatorsLib();
            calMathLib = new CalMathLib();
            
        }
        
        // button 0-9 and (.)
        private void numberButton_OnClick( object sender, EventArgs e)
        {
            if (tbDisplay.Text.Equals("0") || (operation_pressed))
            {
                tbDisplay.Clear();
            }
            
            Button sendButton = (Button)sender;
            
            if (sendButton.Text == ".")
            {
                if(tbDisplay.Text == String.Empty || tbDisplay.Text.Equals("0"))
                {
                    tbDisplay.Text = "0.";
                }
                else if (!tbDisplay.Text.Contains("."))
                {
                    tbDisplay.Text = tbDisplay.Text + sendButton.Text;
                }
            }
            else
            {
                tbDisplay.Text = tbDisplay.Text + sendButton.Text;
            }
            operation_pressed = false;
            
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = null;
            equation.Text = null;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = "0";
            value = 0;
            equation.Text = "";
        }

        private void operator_OnClick(object sender, EventArgs e)
        {
            Button sendButton = (Button)sender;

            if(!String.IsNullOrEmpty(equation.Text))
            {
                btnSum.PerformClick();
            }

            if(sendButton.Text == "x^2")
            {
                tbDisplay.Text = Math.Pow(Convert.ToDouble(tbDisplay.Text), 2).ToString();
                return;
            }

            if (sendButton.Text == "x^3")
            {
                tbDisplay.Text = Math.Pow(Convert.ToDouble(tbDisplay.Text), 3).ToString();
                return;
            }

            if (sendButton.Text == "x^-1")
            {
                tbDisplay.Text = Math.Pow(Convert.ToDouble(tbDisplay.Text), -1).ToString();
                return;
            }

            if (value != 0)
            {
                operation_pressed = true;
                operation = sendButton.Text;
                equation.Text = value + "" + operation;

                
            }
            else
            {
                operation = sendButton.Text;
                value = Double.Parse(tbDisplay.Text);
                operation_pressed = true;
                equation.Text = value + "" + operation;
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            Button sendButton = (Button)sender;
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    tbDisplay.Text = operatorsLib.Add(value, Double.Parse(tbDisplay.Text)).ToString();
                    break;
                case "-":
                    tbDisplay.Text = operatorsLib.Min(value, Double.Parse(tbDisplay.Text)).ToString();             
                    break;
                case "+/-":
                    tbDisplay.Text = operatorsLib.PlusMin(value, Double.Parse(tbDisplay.Text)).ToString();
                    break;
                case "X":
                    tbDisplay.Text = operatorsLib.Multipl(value, Double.Parse(tbDisplay.Text)).ToString();
                    break;
                case "/":
                    tbDisplay.Text = operatorsLib.Div(value, Double.Parse(tbDisplay.Text)).ToString();
                 
                    break;
                case "%":
                    tbDisplay.Text = operatorsLib.Mod(value, Double.Parse(tbDisplay.Text)).ToString();
                    
                    break;
                case "x^2":
                    tbDisplay.Text = powersLib.Pow2(value).ToString();
                    break;
                case "x^3":
                    tbDisplay.Text = powersLib.Pow3(value).ToString();
                   
                    break;

                default:
                    break;
            }// end switch
           
            value = Double.Parse(tbDisplay.Text);
            operation = "";
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = "3.141592265359";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            string str = tbDisplay.Text;
            int n = str.Length;
            if (n == 0)
            {
                tbDisplay.Text = "";
            }
            else
            {
                tbDisplay.Text = str.Substring(0, n - 1);
            }
        }
        private void btnSqrt_OnClick(object sender, EventArgs e)
        {
                double value = calMathLib.CalculateSqrt( double.Parse(tbDisplay.Text));
                tbDisplay.Text = value.ToString();
        }
        private void btnSin_OnClick(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;

            if(btnSender.Text == "sin")
            {
                double sinVal = trigLib.CalculateSin(double.Parse(tbDisplay.Text));
                tbDisplay.Text = sinVal.ToString();
            }
            else if(btnSender.Text == "ArcSin")
            {
                double arcsinVal = trigLib.CalculateArcSin(double.Parse(tbDisplay.Text));
                tbDisplay.Text = arcsinVal.ToString();
            }
        }

        private void btnCos_OnClick(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;

            if (btnSender.Text == "cos")
            {
                double cosVal = trigLib.CalculateCos(double.Parse(tbDisplay.Text));
                tbDisplay.Text = cosVal.ToString();
            }
            else if (btnSender.Text == "ArcCos")
            {
                double arcCosVal = trigLib.CalculateArCos(double.Parse(tbDisplay.Text));
                tbDisplay.Text = arcCosVal.ToString();
            }
        }

        private void btnTg_OnClick(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            if (btnSender.Text == "tan")
            {
                double cosVal = trigLib.CalculateTan(double.Parse(tbDisplay.Text));
                tbDisplay.Text = cosVal.ToString();
            }
            else if (btnSender.Text == "ArcTan")
            {
                double arcTanVal = trigLib.CalculateArcTan(double.Parse(tbDisplay.Text));
                tbDisplay.Text = arcTanVal.ToString();
            }
        }

        private void btnFactorial_OnClick(object sender, EventArgs e)
        {
            int result = calMathLib.CalculateFactorial(int.Parse(tbDisplay.Text));
            tbDisplay.Text = result.ToString();
        }

        private void btnLn_Click(object sender, EventArgs e)
        {
            double result = powersLib.Ln(double.Parse(tbDisplay.Text));
            tbDisplay.Text = result.ToString();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            double result = powersLib.Log(double.Parse(tbDisplay.Text));
            tbDisplay.Text = result.ToString();
        }

        private void btnAlt_Click(object sender, EventArgs e)
        {
            altPressed = !altPressed;

            if(altPressed == true)
            {
                btnSin.Text = "ArcSin";
            }
            else
            {
                btnSin.Text = "sin";
            }

            if(altPressed == true)
            {
                btnCos.Text = "ArcCos";
            }
            else
            {
                btnCos.Text = "cos";
            }
            if (altPressed == true)
            {
                btnTan.Text = "ArcTan";
            }
            else
            {
                btnTan.Text = "tan";
            }
        }

        private void radioButton_OnClick(object sender, EventArgs e)
        {
            RadioButton radioButtonSender = (RadioButton)sender;
            if (sender == radioButton_Degree)
            {
                radioButton_Degree.Checked = true;
                radioButton_Radian.Checked = false;

                trigLib.SetTrigMode(AngleType.DEGREES);
            }
            else if (sender == radioButton_Radian)
            {
                radioButton_Degree.Checked = false;
                radioButton_Radian.Checked = true;

                trigLib.SetTrigMode(AngleType.RADIANS);
            }
        }
    }    
}
