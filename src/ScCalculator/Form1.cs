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

        public Calculator()
        {
            InitializeComponent();
        }
        
        // button 0-9 and (.)
        private void numberButton_OnClick( object sender, EventArgs e)
        {
            if (tbDisplay.Text.Equals("0") || (operation_pressed))
            
                tbDisplay.Clear();

                operation_pressed = false;
                Button sendButton = (Button)sender;// sender is the button that did the click
            
  
            if (sendButton.Text == ".")
            {
                if (!tbDisplay.Text.Contains ("."))
                    tbDisplay.Text = tbDisplay.Text + sendButton.Text;
            }
            else
            {
                tbDisplay.Text = tbDisplay.Text + sendButton.Text;
            }
           
               //tbDisplay.AppendText(sendButton.Text);  // for now, we'll just add it on to the display
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            //tbDisplay.Text = "0";
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // this method should clear the display
            tbDisplay.Text = "0";
        }

        private void decimal_btnOnClick(object sender, EventArgs e)
        {   
        }

        private void operator_OnClick(object sender, EventArgs e)
        {
            Button sendButton = (Button)sender;
            operation = sendButton.Text;
            value = Double.Parse(tbDisplay.Text);
            operation_pressed = true;
            equation.Text = value + "" + operation;
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            equation.Text = "";
            switch (operation)
            {
                case "+":
                    tbDisplay.Text = (value + Double.Parse(tbDisplay.Text)).ToString();
                    break;
                case "-":
                    tbDisplay.Text = (value - Double.Parse(tbDisplay.Text)).ToString();
                    break;
                case "*":
                    tbDisplay.Text = (value * Double.Parse(tbDisplay.Text)).ToString();
                    break;
                case "/":
                    tbDisplay.Text = (value / Double.Parse(tbDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }// end switch
            //operation_pressed = false;

            value = Double.Parse(tbDisplay.Text);
            operation = "";
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
    }    
}
