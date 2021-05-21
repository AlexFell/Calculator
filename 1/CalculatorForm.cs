using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

            inputCapacity.SelectedIndex = inputCapacity.FindString("10");
            outputCapacity.SelectedIndex = outputCapacity.FindString("10");
        }

        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var cursorPosition = inputBox.SelectionStart;
            int lenghtDifference = button.Text.Length;
            inputBox.Text = inputBox.Text.Insert(cursorPosition, button.Text);
            inputBox.SelectionStart = cursorPosition + lenghtDifference;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            inputBox.Text = "";
            outputBox.Text = "";
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            if (inputBox.Text != "")
            {
                var cursorPosition = inputBox.SelectionStart;
                if (cursorPosition != 0)
                {
                    var previousSymbol = cursorPosition - 1;
                    inputBox.Text = inputBox.Text.Remove(previousSymbol, 1);
                    inputBox.SelectionStart = cursorPosition - 1;
                }
            }
        }

        private void InputCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Control item in addictionalButtons.Controls)
            {
                item.Enabled = false;
            }
            foreach (Control item in mainButtons.Controls)
            {
                item.Enabled = false;
            }

            num0.Enabled = true;
            num1.Enabled = true;
            delimiter.Enabled = true;
            eraseButton.Enabled = true;

            switch (inputCapacity.SelectedIndex)
            {
                case 1:
                    {
                        foreach (Control item in mainButtons.Controls)
                        {
                            item.Enabled = true;
                        }
                        num8.Enabled = false;
                        num9.Enabled = false;
                    }
                    break;

                case 2:
                    {
                        foreach (Control item in mainButtons.Controls)
                        {
                            item.Enabled = true;
                        }
                    }
                    break;

                case 3:
                    {
                        foreach (Control item in addictionalButtons.Controls)
                        {
                            item.Enabled = true;
                        }
                        foreach (Control item in mainButtons.Controls)
                        {
                            item.Enabled = true;
                        }
                    }
                    break;
            }
        }

        private void Equally_Click(object sender, EventArgs e)
        {
            string toCalculate = "(" + inputBox.Text + ")";
            StringCalculation calculation = new StringCalculation();
            //calculation.Calculation
        }

        private void convert_Click(object sender, EventArgs e)
        {
            long numberSystem0 = this.inputCapacity.SelectedIndex;
            long numberSystem1 = this.outputCapacity.SelectedIndex;
            long numberSystem2;
            if (this.inputCapacity.SelectedIndex != 3)
            {
                long numberSystem = Convert.ToInt64(inputBox.Text);
                if (numberSystem0 == 0)
                {
                    if (numberSystem1 == 0) { outputBox.Text = inputBox.Text; }
                    numberSystem2 = Convert.ToInt64(inputBox.Text, 2);
                    if (numberSystem1 == 1) { outputBox.Text = Convert.ToString(numberSystem2, 8); }
                    if (numberSystem1 == 2) { outputBox.Text = Convert.ToString(numberSystem2); }
                    if (numberSystem1 == 3) { outputBox.Text = Convert.ToString(numberSystem2, 16); this.outputBox.Text = this.outputBox.Text.ToUpper(); }
                }
                if (numberSystem0 == 1)
                {
                    numberSystem2 = Convert.ToInt64(inputBox.Text, 8);
                    if (numberSystem1 == 0) { outputBox.Text = Convert.ToString(numberSystem2, 2); }
                    if (numberSystem1 == 1) { outputBox.Text = inputBox.Text; }
                    if (numberSystem1 == 2) { outputBox.Text = Convert.ToString(numberSystem2, 10); }
                    if (numberSystem1 == 3) { outputBox.Text = Convert.ToString(numberSystem2, 16); this.outputBox.Text = this.outputBox.Text.ToUpper(); }
                }
                if (numberSystem0 == 2)
                {
                    if (numberSystem1 == 0) { outputBox.Text = Convert.ToString(numberSystem, 2); }
                    if (numberSystem1 == 1) { outputBox.Text = Convert.ToString(numberSystem, 8); }
                    if (numberSystem1 == 2) { outputBox.Text = inputBox.Text; }
                    if (numberSystem1 == 3) { outputBox.Text = Convert.ToString(numberSystem, 16); this.outputBox.Text = this.outputBox.Text.ToUpper(); }
                }
            }

            if (numberSystem0 == 3)
            {
                numberSystem2 = Convert.ToInt64(inputBox.Text, 16);
                if (numberSystem1 == 0) { outputBox.Text = Convert.ToString(numberSystem2, 2); }
                if (numberSystem1 == 1) { outputBox.Text = Convert.ToString(numberSystem2, 8); }
                if (numberSystem1 == 2) { outputBox.Text = Convert.ToString(numberSystem2, 10); }
                if (numberSystem1 == 3) { outputBox.Text = inputBox.Text; }
            }
        }

        
    }
}
