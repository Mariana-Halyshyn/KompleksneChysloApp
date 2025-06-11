using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KompleksneChysloApp
{
    public partial class Form1 : Form
    {
        private List<Kompleksne_chyslo> numbers;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            listBoxNumbers.Items.Clear();

            // Створюємо список комплексних чисел
            numbers = new List<Kompleksne_chyslo>()
            {
                new Kompleksne_chyslo(3, 4),
                new Kompleksne_chyslo(1, -1),
                new Kompleksne_chyslo(0, 2),
                new Kompleksne_chyslo(-2, -3),
                new Kompleksne_chyslo(5, 0)
            };

            listBoxNumbers.Items.Add("Оригінальний масив:");
            foreach (var num in numbers)
                listBoxNumbers.Items.Add(num.GetText());

            var clone = (Kompleksne_chyslo)numbers[0].Clone();
            listBoxNumbers.Items.Add("");
            listBoxNumbers.Items.Add("Клон першого елемента:");
            listBoxNumbers.Items.Add(clone.GetText());

            numbers.Sort();
            listBoxNumbers.Items.Add("");
            listBoxNumbers.Items.Add("Відсортований масив:");
            foreach (var num in numbers)
                listBoxNumbers.Items.Add(num.GetText());
        }
    }
}


