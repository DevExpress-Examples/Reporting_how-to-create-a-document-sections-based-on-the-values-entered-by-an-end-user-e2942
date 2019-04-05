<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* **[MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))**
<!-- default file list end -->
# How to create a document sections based on the values, entered by an end-user


<p>This example illustrates how to generate a document according to the end-user input. To pass specific values to the document's detail section, you just need to assign these values to the e.Data parameter of the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfPrintingSimpleLink_CreateDetailtopic"><u>SimpleLink.CreateDetail Event</u></a>. As for the report (page) header (footer) sections, it is necessary to override their DataContext, which is accessible via the corresponding Link properties. For instance, use the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfPrintingTemplatedLink_PageHeaderDatatopic"><u>TemplatedLink.PageHeaderData Property</u></a> to set the data context of a PageHeader.</p><p><strong>NOTE:</strong> We have a suggestion to enable printing in marginal sections of a document: <a href="https://www.devexpress.com/Support/Center/p/S35716">Links - Provide the capability to define a print template for the TopMargin and BottomMargin areas of a page</a></p>

<br/>


