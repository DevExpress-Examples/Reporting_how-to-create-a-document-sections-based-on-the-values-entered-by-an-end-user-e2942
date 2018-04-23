using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Printing;

namespace PrintDocumentFromUIWpf {
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

            link.ReportHeaderTemplate = (DataTemplate)this.Resources["reportHeaderTemplate"];
            link.PageHeaderTemplate = (DataTemplate)this.Resources["pageHeaderTemplate"];
            link.DetailTemplate = (DataTemplate)this.Resources["detailTemplate"];
            link.PageFooterTemplate = (DataTemplate)this.Resources["pageFooterTemplate"];
            link.ReportFooterTemplate = (DataTemplate)this.Resources["reportFooterTemplate"];

            link.PageHeaderData = teReportHeader;
            link.PageHeaderData = tePageHeader;
            link.PageFooterData = new PageFooterDataContext() {
                Title = tePageFooter.EditValue.ToString(),
                PrintPageInfo = (bool)cePageInfo.IsChecked
            };
            link.ReportFooterData = teReportFooter;

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
