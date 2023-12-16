using EmployeesApp.Models;
using EmployeesApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

using Microsoft.Win32;


namespace EmployeesApp
{
    public partial class MainWindow : Window
    {
        private string PATH = $"{Environment.CurrentDirectory}\\employeeDataList.json";
        private BindingList<EmployeeModel> _employeeDataList;
        private FileIOService _fileIOService;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);
            _employeeDataList = new BindingList<EmployeeModel>();
            EmployeesList.ItemsSource = _employeeDataList;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _employeeDataList = _fileIOService.LoadData();
                EmployeesList.ItemsSource = _employeeDataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeDialog addDialog = new AddEmployeeDialog();
            if (addDialog.ShowDialog() == true)
            {
                _employeeDataList.Add(addDialog.Employee);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EmployeeModel selectedEmployee = (EmployeeModel)EmployeesList.SelectedItem;

                if (selectedEmployee != null)
                {
                    EditEmployeeDialog editDialog = new EditEmployeeDialog(selectedEmployee);
                    editDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника для редактирования");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel selectedEmployee = (EmployeeModel)EmployeesList.SelectedItem;

            if (selectedEmployee != null)
            {
                _employeeDataList.Remove(selectedEmployee);
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _fileIOService.SaveData(_employeeDataList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void ChoosePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JSON files (*.json)|*.json";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filePath = openFileDialog.FileName;

                PATH = filePath;

                _fileIOService = new FileIOService(PATH);

                MessageBox.Show($"Выбран файл: {filePath}");
            }
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            string programInfo = "Программа для работы с данными о сотрудниках. В программе можно добавлять редактировать и удалять данные о сотрудниках в разных json файлах.";
            MessageBox.Show(programInfo, "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
