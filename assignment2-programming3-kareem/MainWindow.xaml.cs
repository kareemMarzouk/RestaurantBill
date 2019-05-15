using System;
using System.Collections.Generic;
using System.Data;
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


namespace assignment2_programming3_kareem
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

        public struct Orders
        {
            public string item;
            public double price;
        }


        Orders order = new Orders();

        static double subtotal;
        const double tax = 0.13;
        static double total;
        static double totalTaxes;

        string restBill = "Restaurant Bill: \n"; 

        private void getRestaurantBill(string customerOrder)
        {
            order.item = customerOrder.Split(' ')[1];
            order.price = Convert.ToDouble(customerOrder.Split('$')[1]);

            restBill += "Item: " + order.item + "\nPrice: " + order.price.ToString("C2") + "\n";

            update();
        }

        private void update()
        {
            subtotal += order.price;
            total += order.price + (order.price * tax);
            totalTaxes += order.price * tax;

            listBox.Items.Clear();
            listBox.Items.Add(restBill);
            listBox.Items.Add("Subtotal: " + subtotal.ToString("C2"));
            listBox.Items.Add("Tax: " + totalTaxes.ToString("C2"));
            listBox.Items.Add("Total: " + total.ToString("C2"));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == ComboBox1)
                getRestaurantBill(ComboBox1.SelectedItem.ToString());
        }

        private void ComboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == ComboBox2)
                getRestaurantBill(ComboBox2.SelectedItem.ToString());
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == ComboBox3)
                getRestaurantBill(ComboBox3.SelectedItem.ToString());
        }

        private void ComboBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == ComboBox4)
                getRestaurantBill(ComboBox4.SelectedItem.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            subtotal = 0;
            totalTaxes = 0;
            total = 0;
            restBill = "Restaurant Bill: \n";
            listBox.Items.Clear();

        }



        /// <summary>
        /// ///////////////////////////
        /// </summary>


        class PrintDG
        {
            public void printDG(ListBox listBox, string title)
            {



                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    FlowDocument fd = new FlowDocument();

                    Paragraph p = new Paragraph(new Run(title));
                    p.FontStyle = listBox.FontStyle;
                    p.FontFamily = listBox.FontFamily;
                    p.FontSize = 18;
                    fd.Blocks.Add(p);

                    Table table = new Table();
                    TableRowGroup tableRowGroup = new TableRowGroup();
                    TableRow r = new TableRow();
                    fd.PageWidth = printDialog.PrintableAreaWidth;
                    fd.PageHeight = printDialog.PrintableAreaHeight;
                    fd.BringIntoView();

                    fd.TextAlignment = TextAlignment.Center;
                    fd.ColumnWidth = 500;
                    table.CellSpacing = 0;
                    
                    fd.Blocks.Add(table);

                    printDialog.PrintDocument(((IDocumentPaginatorSource)fd).DocumentPaginator, "");

                }
            }
        }





        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDG print = new PrintDG();

            print.printDG(listBox, listBox.SelectedItems.ToString());
        }
    }
}
