namespace _1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = this.txtConvertRubles.Text;

            MessageBox.Show(Logic.ConvertPrice(input));

            txtConvertRubles.Clear();
        }
    }

    public class Logic
    {
        public static string ConvertPrice(string input)
        {
            if (int.TryParse(input, out int priceInKopecks))
            {
                if (priceInKopecks < 1 || priceInKopecks > 9999)
                {
                    return "Некорректное значение стоимости товара.";
                }
                else
                {
                    int rubles = priceInKopecks / 100;
                    int kopecks = priceInKopecks % 100;

                    string rublesWord = GetRublesWordForm(rubles);
                    string kopecksWord = GetKopecksWordForm(kopecks);

                    return $"Стоимость товара: {rubles} {rublesWord} {kopecks} {kopecksWord}.";
                }
            }
            else
            {
                return "Некорректный ввод. Введите целое число.";
            }

        }
        private static string GetRublesWordForm(int rubles)
        {
            if (rubles % 10 == 1 && rubles % 100 != 11)
            {
                return "рубль";
            }
            else if ((rubles % 10 >= 2 && rubles % 10 <= 4) && (rubles % 100 < 10 || rubles % 100 >= 20))
            {
                return "рубля";
            }
            else
            {
                return "рублей";
            }
        }

        private static string GetKopecksWordForm(int kopecks)
        {
            if (kopecks % 10 == 1 && kopecks % 100 != 11)
            {
                return "копейка";
            }
            else if ((kopecks % 10 >= 2 && kopecks % 10 <= 4) && (kopecks % 100 < 10 || kopecks % 100 >= 20))
            {
                return "копейки";
            }
            else
            {
                return "копеек";
            }
        }
    }
}
