using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrutcherCalculator
{

    /*
     * Title: PageCalculate
     * Author: Charlie Crutcher
     * Date: December 2022
     * Purpose: Button code and results.
     */

    public partial class PageCalculate : Page
    {
        public PageCalculate()
        {
            InitializeComponent();
        }

        // Button Presses - Contains add, subtract, multiply, divide, clear, exit and utility.



        //Add Button
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var calculationData = new CalculationData();
            calculationData = HarvestData();

            var result = Arithmetic.Addition(calculationData.FirstNumber, calculationData.SecondNumber);
            ResultTextBlock.Text = result.ToString("#.####");
        }



        //Subtract Button
        private void SubtractButton_Click(object sender, RoutedEventArgs e)
        {
            var calculationData = new CalculationData();
            calculationData = HarvestData();

            var result = Arithmetic.Subtraction(calculationData.FirstNumber, calculationData.SecondNumber);
            ResultTextBlock.Text = result.ToString("#.####");
        }



        //Multiply Button
        private void MultiplyButton_Click(object sender, RoutedEventArgs e)
        {
            var calculationData = new CalculationData();
            calculationData = HarvestData();

            var result = Arithmetic.Multiplication(calculationData.FirstNumber, calculationData.SecondNumber);
            ResultTextBlock.Text = result.ToString("#.####");
        }



        //DivideButton
        private void DivideButton_Click(object sender, RoutedEventArgs e)
        {
            var calculationData = new CalculationData();
            calculationData = HarvestData();

            var result = Arithmetic.Division(calculationData.FirstNumber, calculationData.SecondNumber);

                ResultTextBlock.Text = result.ToString("#.####");

        }



        //Clear Button
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            ClearControls();
        }



        //Exit Button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        // Utility
        private void ClearControls()
        {
            // Control
            FirstNumberTextBox.Text = "";
            SecondNumberTextBox.Text = "";
            ResultTextBlock.Text = "Result";
            // Focus
            FirstNumberTextBox.Focus();
        }



        private CalculationData HarvestData()
        {
            //Object to hold data while being gathered
            var tempData = new CalculationData();

            //Variables to hold text box string values and assign with current values
            var firstNumberText = FirstNumberTextBox.Text;
            var secondNumberText = SecondNumberTextBox.Text;

            //Number variables to hold values for CalculationData object
            double firstNumber;
            double secondNumber;

            /*
             Check there is data.
            This method has a weakness. If the user doesn't enter 
            text that can be converted to a number
             */



            if (!string.IsNullOrEmpty(firstNumberText))
            {
                try
                {
                    //Convert to a number
                    firstNumber = double.Parse(s: firstNumberText);
                    tempData.FirstNumber = firstNumber;
                }
                catch (FormatException e)
                {
                    //Tell the the user what happened as feedback
                    MessageBox.Show(e.Message);
                }
            }
            else //Error
            {
                MessageBox.Show("You must enter a value for First Number");
                //drop out of the method.
                return tempData;
            }



            // This metheod is more sophisticated and better practice than number one!
            if (Double.TryParse(secondNumberText, out secondNumber))
            {
                tempData.SecondNumber = secondNumber;
            }
            else
            {//Error

                MessageBox.Show($"Could not convert to a number. {secondNumberText}");
                return tempData;
            }
        return tempData;
        }




    }
}
