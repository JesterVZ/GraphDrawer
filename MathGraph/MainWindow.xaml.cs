using LiveCharts;
using LiveCharts.Wpf;
using MathGraph.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MathGraph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EquationSolver equationSolver;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {
              equationSolver = new EquationSolver();
          }

          private void Button_Click(object sender, RoutedEventArgs e)
          {
              ChartValues<double> chartV = new ChartValues<double>();
              if(StepSlider.Value != 0)
              {
                  equationSolver.SetStep(Math.Round(StepSlider.Value) / 10);
              } else
              {
                  MessageBox.Show("Укажите шаг");
                  return;
              }
              switch (GraphTypeCombobox.SelectedIndex)
              {
                  case -1:
                      MessageBox.Show("Выберите уравнение");
                      return;
                  case 0:
                      equationSolver.Power(2);
                      break;
                  case 1:
                    try
                    {
                        equationSolver.Power(Convert.ToInt32(PowerTextBox.Text));
                    }
                    catch
                    {
                        MessageBox.Show("Укажите степень");
                    }
                      break;
                  case 2:
                      equationSolver.Power(3);
                      break;
                  case 3:
                      equationSolver.Sinus();
                      break;
                  case 4:
                      equationSolver.Cosinus();
                      break;
                  case 5:
                      equationSolver.SquareRoot();
                      break;
              }
              SeriesChart.Series.Clear();
              foreach (double i in equationSolver.Values)
              {
                  chartV.Add(i);
              }
              if (DrawPointsCheckBox.IsChecked == true)
              {
                  SeriesChart.Series.Add(new LineSeries
                  {
                      Values = chartV,
                  });;
              } else
              {
                  SeriesChart.Series.Add(new LineSeries
                  {
                      Values = chartV,
                      PointGeometry = null
                  });
              }

              DataContext = this;
          }

          private void Button_Click_1(object sender, RoutedEventArgs e)
          {
            SeriesChart.Series.Clear();
        }

          private void StepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
          {
              StepLabelValue.Text = (Math.Round(StepSlider.Value)/10).ToString();
          }

          private void GraphTypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              if(GraphTypeCombobox.SelectedIndex == 1)
              {
                  PowerTextBox.IsEnabled = true;
              } else
              {
                  PowerTextBox.IsEnabled = false;
              }
          }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
