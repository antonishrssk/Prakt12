using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Prakt12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DispatcherTimer timer;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsEnabled = true;
        }

        // Таймер для StatusBar'а
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            textBlockDate.Text = date.ToString("dd.MM.yyyy");
            textBlockTime.Text = date.ToString("HH:mm");
        }

        // Рассчитать объем и площадь поверхности куба
        private void btnCalc1_Click(object sender, RoutedEventArgs e)
        {
            if (Int64.TryParse(tbCubeSide.Text, out long a) && a >= 0)
            {
                Calculation.CubeVolumeAndArea(a, out long v, out long s);
                tbCubeVolume.Text = v.ToString();
                tbCubeArea.Text = s.ToString();
            }
            else MessageBox.Show("Введите правильное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            tbCubeSide.Focus();
        }

        // Рассчитать количество полных тонн и килограмм
        private void btnCalc2_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(tbMass.Text, out int m) && m >= 0)
            {
                Calculation.TonsAndKilograms(m, out int tons, out int remainingKilograms);
                tbTons.Text = tons.ToString();
                tbRemainingKilograms.Text = remainingKilograms.ToString();
            }
            else MessageBox.Show("Введите правильное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            tbMass.Focus();
        }

        // Очистить объем и площадь поверхности куба
        private void tbCubeSide_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbCubeVolume.Clear();
            tbCubeArea.Clear();
        }

        // Очистить количество полных тонн и килограмм
        private void tbMass_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbTons.Clear();
            tbRemainingKilograms.Clear();
        }

        // Смена вкладок
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    textBlockTask.Text = "Задача №1";
                    break;
                case 1:
                    textBlockTask.Text = "Задача №2";
                    break;
            }
        }

        // О программе
        private void miInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №12\n" +
                "Разработчик: Антонишин Кирилл Сергеевич\n" +
                "Реализовать расчет задачи:\n" +
                "• Дана длина ребра куба А. Найти объем куба V и площадь его поверхности S.\n" +
                "• Дана масса M в килограммах. Используя операцию деления целых чисел, найти количество полных тонн и килограмм (1 тонна = 1000 кг).",
                "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Выход
        private void miExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
