using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace Task3_Formating_In_WPF
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private decimal x;
		private decimal y;

		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Счиать строку из TextBox1,Разпарсить, Вывести в окно
		/// </summary>
		/// <exception cref="Exception">
		/// Отлавливает и выводит любые исключения
		/// </exception>
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string Value = TextBox1.Text;
			try
			{
				string[] SplittedValues = Value.Split(',');
				x = decimal.Parse(SplittedValues[0], CultureInfo.InvariantCulture);
				y = decimal.Parse(SplittedValues[1], CultureInfo.InvariantCulture);
				string ForPrint = string.Format("X:{0:N6} Y:{1:N6}", x, y);
				MessageBox.Show(ForPrint);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Введите оба ЧИСЛОВЫХ значения\n");
				MessageBox.Show(ex.Message);
			}
		}
		/// <summary>
		/// Счиать строку из файла,парсит,выводит
		/// </summary>
		/// <exception cref="Exception">
		/// Отлавливает и выводит любые исключения
		/// </exception>
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			List<string> lines = new List<string>();
			List<string> ModifiedLines = new List<string>();
			FileStream file = new FileStream("Input.txt", FileMode.Open);
			StreamReader readFile = new StreamReader(file);
			try
			{
				while (!readFile.EndOfStream)
				{
					lines.Add(readFile.ReadLine());
				}
				readFile.Close();
				foreach(var line in lines)
				{
					string[] SplittedValues = line.Split(',');
					string x = SplittedValues[0];
					string y = SplittedValues[1];
					string NewLine= string.Format("X:{0:N6} Y:{1:N6}", x, y);
					ModifiedLines.Add(NewLine);

				}
				ListBox1.ItemsSource = null;
				ListBox1.ItemsSource = ModifiedLines;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
			

		}
	}
}
