using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private double result = 0;
        private string currentOperator = "";
        private bool isNewNumber = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) 
        {
            if (isNewNumber)
            {
                resultTextBox.Text = "";
            }
            isNewNumber = false;
            string number = ((Button)sender).Content.ToString();
            if (resultTextBox.Text == "0" && number != ",")
            {
                resultTextBox.Text = "";
            }
            resultTextBox.Text += number;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e) 
        {
            resultTextBox.Text = "0";
            result = 0;
            currentOperator = "";
            isNewNumber = true;
        }

        private void Operator_Click(object sender, RoutedEventArgs e) 
        {
            if (currentOperator != "")
            {
                Calculate();
            }
            currentOperator = ((Button)sender).Content.ToString();
            result = double.Parse(resultTextBox.Text);
            isNewNumber = true;
        }
        private void FloatingPointNumber_Click(object sender, RoutedEventArgs e)
        {
            if (isNewNumber)
            {
                resultTextBox.Text = "0";
            }
            if (!resultTextBox.Text.Contains("."))
            {
                resultTextBox.Text += ".";
            }
            isNewNumber = false;
        }
        private void Calculate() 
        {
            double currentValue = double.Parse(resultTextBox.Text);

            switch (currentOperator)
            {
                case "+":
                    result += currentValue;
                    break;
                case "-":
                    result -= currentValue;
                    break;
                case "×":
                    result *= currentValue;
                    break;
                case "÷":
                    if (Math.Abs(currentValue) > double.Epsilon)
                    {
                        result /= currentValue;
                    }
                    else
                    {
                        MessageBox.Show("Ділення на нуль неможливе.");
                    }
                    break;
                default:
                    break;
            }

            resultTextBox.Text = result.ToString();
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e) 
        {
            Calculate();
            currentOperator = "";
            isNewNumber = true;
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Text = (double.Parse(resultTextBox.Text) / 100).ToString();
            isNewNumber = true;
        }
        private void PlusMinusButton_Click(object sender, RoutedEventArgs e) 
        {
            if (resultTextBox.Text.Contains("-"))
            {
                resultTextBox.Text = resultTextBox.Text.Remove(0, 1);
            }
            else
            {
                resultTextBox.Text = "-" + resultTextBox.Text;
            }
        }
    }
}
