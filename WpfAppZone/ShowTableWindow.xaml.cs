using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using WpfAppZone.Classes;
namespace WpfAppZone
{
    /// <summary>
    /// Логика взаимодействия для ShowTableWindow.xaml
    /// </summary>
    public partial class ShowTableWindow : Window
    {
        DBConnection database = new DBConnection();

        public ShowTableWindow()
        {
            InitializeComponent();
            
        }

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

        private void Button_Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void ComboBox_listInformation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid_ShowInfo.ItemsSource = null;
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_listInformation.Text == "Сотрудники")
            {
                DataTable obj = querty($"SELECT * FROM Staff");
                var listStaff = new List<Staff>();
                var set = 0;
                while (set < obj.Rows.Count)
                {
                    Staff staff = new Staff(Convert.ToInt32(obj.Rows[set][0]), Convert.ToString(obj.Rows[set][1]), Convert.ToString(obj.Rows[set][2]), Convert.ToString(obj.Rows[set][3]));
                    listStaff.Add(staff);
                    set++;
                }
                DataGrid_ShowInfo.ItemsSource = listStaff;
               
            }
            else if (ComboBox_listInformation.Text == "Дирекция")
            {
                DataTable obj = querty($"SELECT * FROM Dictorate");
                var listStaff = new List<Dictorate>();
                var set = 0;
                while (set < obj.Rows.Count)
                {
                    Dictorate staff = new Dictorate(Convert.ToInt32(obj.Rows[set][0]), Convert.ToString(obj.Rows[set][1]), Convert.ToString(obj.Rows[set][2]), Convert.ToString(obj.Rows[set][3]), Convert.ToString(obj.Rows[set][4]), Convert.ToString(obj.Rows[set][5]));
                    listStaff.Add(staff);
                    set++;
                }
                DataGrid_ShowInfo.ItemsSource = listStaff;
             
            }
            else if (ComboBox_listInformation.Text == "Растения")
            {
                DataTable obj = querty($"SELECT * FROM Plants");
                var listStaff = new List<Plants>();
                var set = 0;
                while (set < obj.Rows.Count)
                {
                    Plants staff = new Plants(Convert.ToInt32(obj.Rows[set][0]), Convert.ToDateTime(obj.Rows[set][1]), Convert.ToDateTime(obj.Rows[set][2]), Convert.ToString(obj.Rows[set][3]), Convert.ToString(obj.Rows[set][4]), Convert.ToInt32(obj.Rows[set][5]));
                    listStaff.Add(staff);
                    set++;
                }
                DataGrid_ShowInfo.ItemsSource = listStaff;
          
            }
            else if (ComboBox_listInformation.Text == "Сервис")
            {
                DataTable obj = querty($"SELECT * FROM Servises");
                var listStaff = new List<Servises>();
                var set = 0;
                while (set < obj.Rows.Count)
                {
                    Servises staff = new Servises(Convert.ToInt32(obj.Rows[set][0]), Convert.ToString(obj.Rows[set][1]), Convert.ToString(obj.Rows[set][2]), Convert.ToInt32(obj.Rows[set][3]));
                    listStaff.Add(staff);
                    set++;
                }
                DataGrid_ShowInfo.ItemsSource = listStaff;
            
            }
            else if (ComboBox_listInformation.Text == "Комании")
            {
                DataTable obj = querty($"SELECT * FROM Company");
                var listStaff = new List<Company>();
                var set = 0;
                while (set < obj.Rows.Count)
                {
                    Company staff = new Company(Convert.ToInt32(obj.Rows[set][0]), Convert.ToString(obj.Rows[set][1]), Convert.ToString(obj.Rows[set][2]));
                    listStaff.Add(staff);
                    set++;
                }
                DataGrid_ShowInfo.ItemsSource = listStaff;
          
            }
        }

        bool flag = false;

        private void Button_Red_Click(object sender, RoutedEventArgs e)
        {
            if(flag == false)
            {
                MessageBox.Show("Включен режим редактирования. Будьте осторожны при введении данных.");
                DataGrid_ShowInfo.IsReadOnly = false;
                Button_Red.Background = Brushes.Pink;
            }
            else
            {
                MessageBox.Show("Режим редактирования выключен.");
                DataGrid_ShowInfo.IsReadOnly = true;
                Button_Red.Background = Brushes.LightGray;
            }
            flag = !flag;
            DataGrid_ShowInfo.Columns[0].IsReadOnly = true;
        }

        private void Button_End_Click(object sender, RoutedEventArgs e)
        {            
            if (ComboBox_listInformation.Text == "Сотрудники")
            {
                try
                {
                    var row_list = (Staff)DataGrid_ShowInfo.SelectedValue;
                    
                }
                catch 
                {
                    MessageBox.Show("Не выбран элемент изменения");
                }

                try
                {
                    var lo = (Staff)DataGrid_ShowInfo.SelectedValue;
                    DataTable obj = querty($"UPDATE Staff SET FIO = {lo.Name}, Addres = {lo.Address}, Phone = {lo.Phone} WHERE id = {lo.Id} ");
                }
                catch
                {
                    MessageBox.Show("Изменение не успешно, проверте правильность вводимых данных");
                }
           
            }
            if (ComboBox_listInformation.Text == "Дирекция")
            {
                try
                {
                    var row_list = (Dictorate)DataGrid_ShowInfo.SelectedValue;

                }
                catch
                {
                    MessageBox.Show("Не выбран элемент изменения");
                }
                try
                {
                    var lo = (Dictorate)DataGrid_ShowInfo.SelectedValue;
                    DataTable obj = querty($"UPDATE Dictorate SET FIO = '{lo.FIO}', Address = '{lo.Address}', Phone = '{lo.Phone}', Education = '{lo.Educateion}',NameInstitution = '{lo.NameInstitution}' WHERE id = {lo.Id} ");

                }
                catch
                {
                    MessageBox.Show("Изменение не успешно, проверте правильность вводимых данных");
                }
          }
            if (ComboBox_listInformation.Text == "Растения")
            {
                try
                {
                    var row_list = (Plants)DataGrid_ShowInfo.SelectedValue;

                }
                catch
                {
                    MessageBox.Show("Не выбран элемент изменения");
                }
                try
                {
                    var lo = (Plants)DataGrid_ShowInfo.SelectedValue;
                    DataTable obj = querty($"UPDATE Plants SET DisembarkationDate = '{lo.DisembarkationDate}', PlantAge = '{lo.PlantAge}', ViewPlant = '{lo.ViewPlant}', WateringMode = '{lo.WateringMode}',WateringRate = '{lo.WateringRate}' WHERE id = {lo.Id} ");

                }
                catch
                {
                    MessageBox.Show("Изменение не успешно, проверте правильность вводимых данных");
                }
        }
            if (ComboBox_listInformation.Text == "Сервис")
            {
                try
                {
                    var row_list = (Servises)DataGrid_ShowInfo.SelectedValue;

                }
                catch
                {
                    MessageBox.Show("Не выбран элемент изменения");
                }
                try
                {
                    var lo = (Servises)DataGrid_ShowInfo.SelectedValue;
                    DataTable obj = querty($"UPDATE Servises SET Zones = '{lo.Zones}', Name = '{lo.Name}', IdStaff = '{lo.IdStaff}' WHERE id = {lo.Id} ");

                }
                catch
                {
                    MessageBox.Show("Изменение не успешно, проверте правильность вводимых данных");
                }
            }
            if (ComboBox_listInformation.Text == "Комании")
            {
                try
                {
                    var row_list = (Company)DataGrid_ShowInfo.SelectedValue;

                }
                catch
                {
                    MessageBox.Show("Не выбран элемент изменения");
                    return;
                }

                try
                {
                    var lo = (Company)DataGrid_ShowInfo.SelectedValue;
                    DataTable obj = querty($"UPDATE Servises SET LegalAddress = '{lo.LegalAddress}', Name = '{lo.Name}' WHERE id = {lo.Id} ");

                }
                catch
                {
                    MessageBox.Show("Изменение не успешно, проверте правильность вводимых данных");
                }
            }
        }
    }
}
