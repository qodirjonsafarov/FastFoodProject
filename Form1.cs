using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFood
{
    public partial class Form1 : Form
    {
        object menuItem = null;
        bool prepared = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int quantity = Convert.ToInt16(textBox1.Text);
                if (quantity > 0)
                {

                    Employee employee = new Employee();
                    object menuItemRequest = null;
                    if (radioButton1.Checked)
                    {
                        menuItemRequest = employee.NewRequest(quantity, "Egg");
                    }
                    else if (radioButton2.Checked)
                    {
                        menuItemRequest = employee.NewRequest(quantity, "Chicken");
                    }

                    if (menuItemRequest != null)
                    {
                        menuItem = menuItemRequest;
                        prepared = false;
                        label3.Text = employee.Inspect(menuItemRequest);

                        listbox1.Items.Add($"New Request accepted at {DateTime.Now}");
                    }
                }
            }
            catch (FormatException)
            {
                listbox1.Items.Add("Please, enter the quantity of order!");
            }
            catch (Exception ex)
            {
                listbox1.Items.Add(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                object previousRequest = employee.CopyRequest();
                menuItem = previousRequest;
                prepared = false;
                label3.Text = employee.Inspect(previousRequest);
                listbox1.Items.Add($"Previous request is copied. at {DateTime.Now}");
                

            }
            catch (Exception ex)
            {
                listbox1.Items.Add(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                if (menuItem != null)
                {
                    if (prepared==false)
                    {
                        Employee employee = new Employee();
                        listbox1.Items.Add($"{ employee.PrepareFood(menuItem)} at {DateTime.Now}");
                        prepared = true;
                    }
                    else
                    {
                        listbox1.Items.Add("Food is already cooked and cannot be re-cooked.");
                        
                    }
                }
            }
        }
    }
}


