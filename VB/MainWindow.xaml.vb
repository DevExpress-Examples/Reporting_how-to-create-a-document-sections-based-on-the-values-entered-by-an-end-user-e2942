Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Printing

Namespace PrintDocumentFromUIWpf
	Partial Public Class MainWindow
		Inherits DXWindow
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub DXWindow_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
			InitDefaultVlaues()
		End Sub

		Private Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
			CreateAndPreviewLink()
		End Sub

		Private Sub InitDefaultVlaues()
			teReportHeader.EditValue = "Report Header"
			tePageHeader.EditValue = "Page Header"
			teDetail.EditValue = "Detail"
			tePageFooter.EditValue = "Page Footer"
			teReportFooter.EditValue = "Report Footer"
			seDetail.EditValue = 400
			cePageInfo.EditValue = True
		End Sub

		Private Sub CreateAndPreviewLink()
			Dim link As New SimpleLink()

			link.ReportHeaderTemplate = CType(Me.Resources("reportHeaderTemplate"), DataTemplate)
			link.PageHeaderTemplate = CType(Me.Resources("pageHeaderTemplate"), DataTemplate)
			link.DetailTemplate = CType(Me.Resources("detailTemplate"), DataTemplate)
			link.PageFooterTemplate = CType(Me.Resources("pageFooterTemplate"), DataTemplate)
			link.ReportFooterTemplate = CType(Me.Resources("reportFooterTemplate"), DataTemplate)

			link.PageHeaderData = teReportHeader
			link.PageHeaderData = tePageHeader
			link.PageFooterData = New PageFooterDataContext() With {.Title = tePageFooter.EditValue.ToString(), .PrintPageInfo = CBool(cePageInfo.IsChecked)}
			link.ReportFooterData = teReportFooter

			link.DetailCount = Convert.ToInt32(seDetail.EditValue)

			AddHandler link.CreateDetail, AddressOf link_CreateDetail

			link.ShowPrintPreviewDialog(Me)
		End Sub

		Private Sub link_CreateDetail(ByVal sender As Object, ByVal e As CreateAreaEventArgs)
			e.Data = String.Format("{0} (Row {1})", teDetail.EditValue, e.DetailIndex)
		End Sub

	End Class

	Public Class PageFooterDataContext
		Private privateTitle As String
		Public Property Title() As String
			Get
				Return privateTitle
			End Get
			Set(ByVal value As String)
				privateTitle = value
			End Set
		End Property
		Private privatePrintPageInfo As Boolean
		Public Property PrintPageInfo() As Boolean
			Get
				Return privatePrintPageInfo
			End Get
			Set(ByVal value As Boolean)
				privatePrintPageInfo = value
			End Set
		End Property
	End Class

End Namespace
