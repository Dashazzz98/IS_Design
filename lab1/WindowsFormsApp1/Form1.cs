using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string[] alphabet = {"АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,.!? -:;_()1234567890", "ABCDEFGHIJKLMNOPQRSTUVWXYZ ,.!?-:;_()1234567890" };
        string[] mask = {"[а-яёА-Яё]", "[a-zA-Z]" }; //Массив масок для обработки символов ключа
        int id = 0;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";//фильтры для
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";//работы с файловой системой
        }

        public char[] alphabetGenerator(string alphabetLetters = null) //Генератор алфавита в массив символов из строки
        {
            char[] alphabet = alphabetLetters.ToCharArray();
            return alphabet;
        }

        private string crypt(string message, string key, char[] alphabet)
        {
            message = message.ToUpper();
            key = key.ToUpper();
            int lengthOfAlphanet = alphabet.Length;

            int index_of_key = 0;
            string result = "";

            foreach (char sym in message)
            {
                int c = (Array.IndexOf(alphabet, sym) + Array.IndexOf(alphabet, key[index_of_key])) % lengthOfAlphanet;
                result += alphabet[c];
                index_of_key++;
                if ((index_of_key + 1) == key.Length)//обнуление индекса символа ключа
                    index_of_key = 0;
            }
            return result;
        }

        private string decrypt(string message, string key, char[] alphabet)
        {
            message = message.ToUpper();
            key = key.ToUpper();
            int lengthOfAlphanet = alphabet.Length;

            int index_of_key = 0;
            string result = "";

            foreach (char sym in message)
            {
                int p = (Array.IndexOf(alphabet, sym) + lengthOfAlphanet - Array.IndexOf(alphabet, key[index_of_key])) % lengthOfAlphanet;
                result += alphabet[p];
                index_of_key++;
                if ((index_of_key + 1) == key.Length)//обнуление индекса символа ключа
                    index_of_key = 0;
            }
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox2.Text = crypt(textBox1.Text, textBox3.Text, alphabetGenerator(alphabet[id])).ToString();
            }
            if (radioButton2.Checked == true)
            {
                textBox2.Text = decrypt(textBox1.Text, textBox3.Text, alphabetGenerator(alphabet[id])).ToString();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox3.Text != "")) 
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
