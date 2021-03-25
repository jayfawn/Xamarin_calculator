using System;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        private int count = 0;
        private double numberOne = 0;
        private double numberTwo = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddClicked(object sender, EventArgs e)
        {
            if (CheckEndForFunction())
            {
                CounterLabel.Text = CounterLabel.Text.Remove(CounterLabel.Text.Length - 1);
            }
            if (CheckContainsLogic())
            {
                AssessEquals();
            }
            CounterLabel.Text += "+";
            
        }

        private void SubtractClicked(object sender, EventArgs e)
        {
            if (CheckEndForFunction())
            {
                CounterLabel.Text = CounterLabel.Text.Remove(CounterLabel.Text.Length - 1);
            }
            if (CheckContainsLogic())
            {
                AssessEquals();
            }
            CounterLabel.Text += "-";
        }


        private void MultiplyClicked(object sender, EventArgs e)
        {
            if (CheckEndForFunction())
            {
                CounterLabel.Text = CounterLabel.Text.Remove(CounterLabel.Text.Length - 1);
            };
            if (CheckContainsLogic())
            {
                AssessEquals();
            }
            CounterLabel.Text += "*";
        }
        private void DivideClicked(object sender, EventArgs e)
        {
            if (CheckEndForFunction())
            {
                CounterLabel.Text = CounterLabel.Text.Remove(CounterLabel.Text.Length - 1);
            }
            if (CheckContainsLogic())
            {
                AssessEquals();
            }
            CounterLabel.Text += "/";
        }

        private bool CheckEndForFunction()
        {
            return CounterLabel.Text.EndsWith("*") || CounterLabel.Text.EndsWith("/") || CounterLabel.Text.EndsWith("+") || CounterLabel.Text.EndsWith("-");
        }
        private void ResetClicked(object sender, EventArgs e)
        {
            CounterLabel.Text = "";
        }

        private void OneClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 1;
        }

        private void TwoClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 2;
        }
        private void ThreeClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 3;
        }
        private void FourClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 4;
        }
        private void FiveClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 5;
        }
        private void SixClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 6;
        }
        private void SevenClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 7;
        }
        private void EightClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 8;
        }
        private void NineClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 9;
        }
        private void ZeroClicked(object sender, EventArgs e)
        {
            CheckForPreviousCalc();
            CounterLabel.Text += 0;
        }
        private void CheckForPreviousCalc()
        {
            if (count == 1)
            {
                CounterLabel.Text = "";
                count = 0;
            }
        }
        private void DecimalClicked(object sender, EventArgs e)
        {
            CounterLabel.Text += ".";
        }
        private void BackSpaceClicked(object sender, EventArgs e)
        {
            if (CounterLabel.Text.Length > 0)
            {
                CounterLabel.Text = CounterLabel.Text.Remove(CounterLabel.Text.Length - 1);
            }          
        }
        private void PercentClicked(object sender, EventArgs e)
        {
            count = count;
        }

        private void EqualsClicked(object sender, EventArgs e)
        {
            count = 1;
            if (!CheckEndForFunction())
            {
                AssessEquals();
            }
        }
        private bool CheckContainsLogic()
        {
            return CounterLabel.Text.Contains("*") || CounterLabel.Text.Contains("+") || (CounterLabel.Text.Contains("-") && !CounterLabel.Text.StartsWith("-"))|| CounterLabel.Text.Contains("/");
        }
        private void AssessEquals()
        {
            var nums = CounterLabel.Text.Split(new char[] { '+', '-', '*', '/' });
            if (CounterLabel.Text.Contains("+"))
            {
                CounterLabel.Text = Add(nums);
            }
            if (CounterLabel.Text.Contains("/"))
            {
                CounterLabel.Text = Divide(nums);
            }
            if (CounterLabel.Text.Contains("*"))
            {
                CounterLabel.Text = Multiply(nums);
            }
            if (CounterLabel.Text.TrimStart('-').Contains("-"))
            {
                CounterLabel.Text = Minus(nums);
            }
        }

        private string Add(string[] numbers)
        {
            double result = 0;
            if (CounterLabel.Text.StartsWith("-"))
            {
                result = 0 - double.Parse(numbers[1]) + double.Parse(numbers[2]);
            }
            else
            {
                result = double.Parse(numbers[0]) + double.Parse(numbers[1]);
            }
            return result.ToString();
        }

        private string Minus(string[] numbers)
        {
            double result = 0;
            if (CounterLabel.Text.StartsWith("-"))
            {
                result = 0 - double.Parse(numbers[1]) - double.Parse(numbers[2]);
            }
            else
            {
                result = double.Parse(numbers[0]) - double.Parse(numbers[1]);
            }
            return result.ToString();        
        }

        private string Divide(string[] numbers)
        {
            double result = 0;
            if (CounterLabel.Text.StartsWith("-"))
            {
                result = 0 - double.Parse(numbers[1]) / double.Parse(numbers[2]);
            }
            else
            {
                result = double.Parse(numbers[0]) / double.Parse(numbers[1]);
            }
            return result.ToString();
        }

        private string Multiply(string[] numbers)
        {
            double result = 0;
            if (CounterLabel.Text.StartsWith("-"))
            {
                result = 0 - double.Parse(numbers[1]) * double.Parse(numbers[2]);
            }
            else
            {
                result = double.Parse(numbers[0]) * double.Parse(numbers[1]);
            }
            return result.ToString();
        }
    }
}
