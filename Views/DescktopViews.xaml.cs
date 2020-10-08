using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;

namespace LiteCRM.Views
{
    /// <summary>
    /// Логика взаимодействия для DescktopViews.xaml
    /// </summary>
    public partial class DescktopViews : UserControl
    {
        public DescktopViews()
        {
            InitializeComponent();

            //Все графики находятся в пределах области построения ChartArea, создадим ее
            Chart.ChartAreas.Add(new ChartArea("Default"));

            //Добавим линию, и назначим ее в ранее созданную область "Default"
            Chart.Series.Add(new Series("Series1"));
            Chart.Series["Series1"].ChartArea = "Default";
            Chart.Series["Series1"].ChartType = SeriesChartType.Doughnut;

            //добавим данные линии
            string[] axisXData = new string[] { "a", "b", "c" };
            double[] axisYData = new double[] { 0.1, 1.5, 1.9 };
            Chart.Series["Series1"].Points.DataBindXY(axisXData, axisYData);

            //Все графики находятся в пределах области построения ChartArea, создадим ее
            Chart1.ChartAreas.Add(new ChartArea("Default"));

            //Добавим линию, и назначим ее в ранее созданную область "Default"
            Chart1.Series.Add(new Series("Series2"));
            Chart1.Series["Series2"].ChartArea = "Default";
            Chart1.Series["Series2"].ChartType = SeriesChartType.Doughnut;

            //добавим данные линии
            string[] axisXData1 = new string[] { "a", "b", "c" };
            double[] axisYData1 = new double[] { 0.1, 1.5, 1.9 };
            Chart1.Series["Series2"].Points.DataBindXY(axisXData1, axisYData1);


        }
    }
}
