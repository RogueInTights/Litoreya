using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Litoreya
{
    public partial class Litoreya : Form
    {
        public Litoreya()
        {
            InitializeComponent();
        }

        private string consonantsPartOne = "бвгджзклмн";
        private string consonantsPartTwo = "щшчцхфтсрп";

        private string encode(string encrypted)
        {          
            for (int i = 0; i < encrypted.Length; i++)
            {
                int position = consonantsPartOne.IndexOf(encrypted[i]);

                if (position != -1)
                {
                    encrypted = encrypted
                        .Remove(i, 1)
                        .Insert(i, consonantsPartTwo[position].ToString());

                    continue;
                }

                position = consonantsPartTwo.IndexOf(encrypted[i]);

                if (position != -1)
                {
                    encrypted = encrypted
                        .Remove(i, 1)
                        .Insert(i, consonantsPartOne[position].ToString());
                }
            }

            return encrypted;
        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text.ToLower();
            outputTextBox.Text = encode(input);
        }
    }
}
