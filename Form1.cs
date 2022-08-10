using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssignmentCalendar_5th_Aug
{
    public partial class Form1 : Form
    {
        int month, year;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)      //for next month
        {

            
            daycontainer.Controls.Clear();      //For moving to next year
            if(month==12)
            {
                year++;
                month = 1;
            }
            else
                month++;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);      //Displaying current month name
            lbday.Text = monthname + " " + year;        //lbday is the label containing Month and Year

            DateTime startofthemonth = new DateTime(year, month, 1);   //First day of month

            int days = DateTime.DaysInMonth(year, month);   //count days of month and store in days

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;  //convert start of the month to integer and store in day of the week

            for (int i = 1; i < dayoftheweek; i++)      // blank user control
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)      // blank user control
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }

        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            daycontainer.Controls.Clear();      //For going back to previous year
            if (month == 1)
            {
                year--;
                month = 12;
            }
            else
                month--;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbday.Text = monthname + " " + year;


            DateTime startofthemonth = new DateTime(year, month, 1);   //First day of month

            int days = DateTime.DaysInMonth(year, month);   //count days of month and store in days

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;  //convert start of the month to integer and store in day of the week

            for (int i = 1; i < dayoftheweek; i++)      // blank user control
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)      // blank user control
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }

        }

        private void Form1_Load(object sender, EventArgs e)     //Displaying Date and Time on Top
        {
            displayDays();
            timer1.Start();
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();
        }

        private void displayDays()      //Display function for dates on calendar
        {
            DateTime now = DateTime.Now;  //Current Date
            month = now.Month;
            year = now.Year;

            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbday.Text = monthname + " " + year;


            DateTime startofthemonth = new DateTime(year, month, 1);   //Assigning first day of month in startofthemonth

            int days = DateTime.DaysInMonth(year, month);   //count days of month and store in days

            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d"))+1 ;  //convert start of the month to integer and store in day of the week

            for (int i = 1; i < dayoftheweek; i++)      // blank user control - temporary
            {
                UserControlBlank ucblank = new UserControlBlank();      //usercontrolblank is a windows for for specified single date
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)      // blank user control - real dates
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)        //Timer for updating Time Continously
        {
            label8.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            

        }

        private void label9_Click(object sender, EventArgs e)
        {
            
        }

    }

}
 