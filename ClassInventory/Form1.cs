using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassInventory
{
    public partial class Form1 : Form
    {
        // create a List to store all inventory objects
        List<Player> players = new List<Player>();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {                       
            // gather all information from screen
            string name, team, position;
            int age;

            name = nameInput.Text;
            age = Convert.ToInt16(ageInput.Text);
            team = teamInput.Text;
            position = positionInput.Text;

            // create object with gathered information
            Player p = new Player(name, age, team, position);

            // add object to global list
            players.Add(p);

            // display message to indicate addition made
            outputLabel.Text = "Player " + name + " has been added to the database.";

            nameInput.Clear();
            ageInput.Clear();
            teamInput.Clear();
            positionInput.Clear();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // if object is in list remove it
            string removeName = removeInput.Text.ToString();

            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].name.Contains(removeName))
                {
                    players.RemoveAt(i);
                    outputLabel.Text = "Player " + removeName + " has been deleted from the database.";
                    break;
                }
            }

            // display message to indicate deletion made

            removeInput.Clear();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // if object entered exists in list show it
            string findName = searchInput.Text;

            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].name.Contains(findName))
                {
                    outputLabel.Text = players[i].name + ", " + players[i].age + ", " + players[i].team + ", " + players[i].position;

                    break;
                }
                else { outputLabel.Text = "Player " + findName + " cannot be found in database."; }
            }

            //else show not found message
            
            searchInput.Clear();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // show all objects in list
            outputLabel.Text = "";
            for (int i = 0; i < players.Count(); i++)
            {
                outputLabel.Text += players[i].name + ", " + players[i].age + ", " + players[i].team + ", " + players[i].position + "\n";
            }
        }
    }
}
