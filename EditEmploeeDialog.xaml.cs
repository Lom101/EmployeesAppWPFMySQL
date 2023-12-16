using EmployeesApp.Models;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace EmployeesApp
{
    /// <summary>
    /// Логика взаимодействия для EditEmploeeDialog.xaml
    /// </summary>
    public partial class EditEmploeeDialog : Window
    {
        public EditEmploeeDialog(EmployeeModel employeeModel)
        {
            InitializeComponent();
            NameTextBox.Text = employeeModel.Name;
            PositionTextBox.Text = employeeModel.Position;
            SalaryTextBox.Text = employeeModel.Salary.ToString();
            DepartmentTextBox.Text = employeeModel.Department;
            DateOfBirthTextBox.Text = employeeModel.DateOfBirth.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string position = PositionTextBox.Text;
            string salary = SalaryTextBox.Text;
            string department = DepartmentTextBox.Text;
            string dateOfBirth = DateOfBirthTextBox.Text;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика отмены
        }
    }
}
