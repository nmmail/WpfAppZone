using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using System.IO;
using WpfAppZone.Classes;

namespace WpfAppZone
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   

        public MainWindow()
        {
            InitializeComponent();
        }

      

        private void TextBlock_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_ShowStaff_Click(object sender, RoutedEventArgs e)
        {
            ShowTableWindow showTableWindow = new ShowTableWindow();
            showTableWindow.Show();
            this.Hide();
        }
        DBConnection database = new DBConnection();
        DataTable querty(string querty)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand(querty, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return table;
            }
        }

        private void ToCsV(DataGrid dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            DataTable obj = querty($"SELECT * FROM Dictorate");
            var listStaff = new List<Dictorate>();
            var set = 0;
            while (set < obj.Rows.Count)
            {
                Dictorate staff = new Dictorate(Convert.ToInt32(obj.Rows[set][0]), Convert.ToString(obj.Rows[set][1]), Convert.ToString(obj.Rows[set][2]), Convert.ToString(obj.Rows[set][3]), Convert.ToString(obj.Rows[set][4]), Convert.ToString(obj.Rows[set][5]));
                listStaff.Add(staff);
                set++;
            }

            
        }
    }
}
