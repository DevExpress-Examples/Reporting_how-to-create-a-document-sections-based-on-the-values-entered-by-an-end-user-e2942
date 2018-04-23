using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Printing;

namespace PrintDocumentFromUIWpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXWindow {
        public MainWindow() {
            InitializeComponent();
        }

        private void DXWindow_Loaded(object sender, System.Windows.RoutedEventArgs e) {
            InitDefaultVlaues();
        }

        private void btnPrint_Click(object sender, System.Windows.RoutedEventArgs e) {
            CreateAndPreviewLink();
        }

        private void InitDefaultVlaues() {
            teReportHeader.EditValue = "Report Header";
            tePageHeader.EditValue = "Page Header"; 
            teDetail.EditValue = "Detail";
            tePageFooter.EditValue = "Page Footer"; 
            teReportFooter.EditValue = "Report Footer";
            seDetail.EditValue = 400;
            cePageInfo.EditValue = true;
        }

        private void CreateAndPreviewLink() {
            SimpleLink link = new SimpleLink();
            
            link.ReportHeader = (DataTemplate)this.Resources["reportHeaderTemplate"];
            link.PageHeader = (DataTemplate)this.Resources["pageHeaderTemplate"];
            link.Detail = (DataTemplate)this.Resources["detailTemplate"];
            link.PageFooter = (DataTemplate)this.Resources["pageFooterTemplate"];
            link.ReportFooter = (DataTemplate)this.Resources["reportFooterTemplate"];

            link.ReportHeaderDataContext = teReportHeader;
            link.PageHeaderDataContext = tePageHeader;
            link.PageFooterDataContext = new PageFooterDataContext() {
                Title = tePageFooter.EditValue.ToString(),
                PrintPageInfo = (bool)cePageInfo.IsChecked
            };
            link.ReportFooterDataContext = teReportFooter;

            link.DetailCount = Convert.ToInt32(seDetail.EditValue);
            
            link.CreateDetail += new EventHandler<CreateAreaEventArgs>(link_CreateDetail);

            link.ShowPrintPreviewDialog(this);
        }

        void link_CreateDetail(object sender, CreateAreaEventArgs e) {
            e.Data = string.Format("{0} (Row {1})", teDetail.EditValue, e.DetailIndex);
        }

    }

    public class PageFooterDataContext {
        public string Title { get; set; }
        public bool PrintPageInfo { get; set; }
    }

}
