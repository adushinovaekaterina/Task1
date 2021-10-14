using System;
using System.Linq;
using System.Windows.Forms;

namespace Лабораторная_работа__2
{
    /*    partial означает, что код класса разбит на несколько файлов, в Form1.Designer.cs
     *    находится вторая часть этого класса
     *    
     *    Form1 - класс, Form - класс, который написали разработчики .Net, он реализует обработку системных событий и т.д.
     *    
     *    Написав справа от названия своего класса через двоеточие название 
     *    другого класса, мы все свойства и методы последнего перенимаем в свой класс.
     *    Это называется наследованием.*/
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // вызов метода который формирует поля на форме, добавляет свойства,
            // всё то, что находится в Form1.Designer.cs
        }
        private void button1_Click(object sender, EventArgs e) // реакция на клик
        {
            int[] a = new int[3]; // массив для 3 целых чисел
            string outMessage;
            Logic logic = new Logic();

            // проверяем значение на корректность
            // если там нет сообщения, значит нет ошибки и будем конвертировать
            if ((outMessage = logic.checkDigit(this.txtFirstNumber.Text)).Equals("") &&
                (outMessage = logic.checkDigit(this.txtSecondNumber.Text)).Equals("") &&
                (outMessage = logic.checkDigit(this.txtThirdNumber.Text)).Equals(""))
            {
                a[0] = int.Parse(this.txtFirstNumber.Text); // первое число
                a[1] = int.Parse(this.txtSecondNumber.Text); // второе число
                a[2] = int.Parse(this.txtThirdNumber.Text); // третье число
                MessageBox.Show(Logic.Compare(a)); // выводим ответ
            }
            else
            {
                MessageBox.Show(outMessage); // в случае ошибки выводим сообщение
            }
        }
    }
    public class Logic // класс, где хранится логика
    {
        // проверка, является ли значение числом
        public string checkDigit(string digit)
        {
            string message = ""; // сообщение об ошибке
            int a; // число, которое проверяем
            try
            {
                a = int.Parse(digit);
            }
            catch (FormatException)
            {
                message = "Некорректный ввод";
            }
            return message; // возвращаем сообщение
        }
        // функция Compare нужна, чтобы сформировать результирующее сообщение
        public static string Compare(int[] a)
        {
            string outMessage = ""; // результируюшая строка
            int max = a.Max(); // самое большое число
            int min = a.Min(); // самое маленькое число
            int average = 0; // число, являющееся средним 
            int equalCount = 0; // количество пар равных чисел
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (((a[i]) == (a[i + 1])) || ((a[i] == a[a.Length - 1])))
                {
                    equalCount++;
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                // если элемент массива > минимального и < максимального
                if (a[i] > min && a[i] < max)
                {
                    average = a[i]; // среднее число
                }
            }
            if (equalCount == 2) // все элементы равны
            {
                outMessage = "Все числа равны, нет максимального, нет среднего, нет минимального числа";
            }
            else if (equalCount == 1) // 1 пара равных чисел
            {
                outMessage = "Максимальное: " + max + ", минимальное: " + min + ", среднее число отсутствует";
            }
            else
            {
                outMessage = "Максимальное: " + max + ", минимальное: " + min + ", среднее: " + average;
            }
            return outMessage;
        }
    }
}