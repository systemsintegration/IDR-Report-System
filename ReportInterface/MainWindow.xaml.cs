using System.Collections.Generic;
using System.Windows;
using UDReports;

namespace ReportInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UnitDiary ExisitingDiairies = new UnitDiary();
        UnitDiary MissingDiaries = new UnitDiary();
        List<UnitDiary> Missing = new List<UnitDiary>();
        List<UnitDiary> Existing = new List<UnitDiary>();
        public MainWindow()
        {
            InitializeComponent();
            MissingDiaries.Uploaded = false;
            ExisitingDiairies.Uploaded = true;
        }

        private void getDiairies()
        {
            Missing = MissingDiaries.GetDiaries();
            Existing = ExisitingDiairies.GetDiaries();
        }

        private void saveMissing()
        {
            MissingDiaries.SaveReport(Missing);
        }

        private void GetReport_Click(object sender, RoutedEventArgs e)
        {
            getDiairies();
            Uploaded.ItemsSource = Missing;
            NotUploaded.ItemsSource = Existing;
        }

        private void SaveMissing_Click(object sender, RoutedEventArgs e)
        {
            saveMissing();
        }
    }
}
