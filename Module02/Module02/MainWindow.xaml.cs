using System;
using System.CodeDom;
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

using System.Diagnostics;

namespace Module02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ClearForm();
            Demo();

        } //end ctor                                         



        void Demo()
        {

            var answer = Add(1,2,3,4,5,6,7,8,9,10);


        }

        void ClearForm()
        {

            readoutText.Text = "";

            companyNameText.Text = "";
            participantsText.Text = "1";
            goldMemberCheck.IsChecked = false;
            companyNameText.Focus();


        } //end clearForm

        /* This 
         * is 
         * multiline
         */


        /// <summary>
        /// Calculates the fee for the conference
        /// </summary>
        /// <param name="participantCount">a non zero number of parameters</param>
        /// <returns>The possibly discounted cost of the conference</returns>
        /// <exception cref="System.ArgumentException"></exception>
        decimal CalculateFee(int participantCount)
        {
            
            if (participantCount <= 0) throw new ArgumentException("Must have at leat 1 participant", nameof(participantCount));

            const int DISCOUNT_MIN = 5;
            const decimal FEE_PER_PERSON = 150m;
            const decimal DISCOUNT = .2m;
            decimal fee = participantCount * FEE_PER_PERSON;

            if (participantCount >= DISCOUNT_MIN)
            {

                fee = fee * (1 - DISCOUNT);
            }
            return fee;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var companyName = companyNameText.Text;

                //if (!int.TryParse(participantsText.Text, out int participants))
                //{
                //    readoutText.Text = "Participants needs a whole number.";
                //    return; //exit sub
                //}


                //Used instead of TryParse to generate Exceptions more easily
                var participants = int.Parse(participantsText.Text);

                var goldMember = (bool)goldMemberCheck.IsChecked;

                var fee = CalculateFee(participants);

                var message = $"For your {participants} participants you will be charged {fee:c}.";
                readoutText.Text = message;
            }
            catch(FormatException)
            {
                readoutText.Text = "Ensure that participants is a whole number.";
            }
            catch (OverflowException)
            {
                //User entered a number too large/small for participants
                readoutText.Text = $"Participants must 1 or more (no more than {int.MaxValue})";

            }
            catch (Exception ex)
            {

                //don't do this in the real world
                readoutText.Text = "Unknown Exception. Please contact Gavan";
                Trace.TraceError(ex.ToString());

            }
        }





        int Add(int a, int b)
        {
            return a + b;
        }

        int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        int Add(params int[] rest)
        {
            var total = 0;
            foreach (var item in rest)
            {
                total += item;
            }

            return total;
        }

        double Add(double a, double b)
        {
            return a + b;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
    } //end class
}
