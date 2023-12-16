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
using System.Windows.Shapes;

namespace EmployeesApp
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeDialog.xaml
    /// </summary>
    public partial class AddEmployeeDialog : Window
    {
        public EmployeeModel Employee { get; private set; }

        public AddEmployeeDialog()
        {
            InitializeComponent();
            Employee = new EmployeeModel();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверка ввода данных и сохранение в модель
                Employee.Name = NameTextBox.Text;
                Employee.Position = PositionTextBox.Text;

                // Проверка и конвертация зарплаты
                if (int.TryParse(SalaryTextBox.Text, out int salary))
                {
                    Employee.Salary = salary;
                }
                else
                {
                    throw new ArgumentException("Зарплата должна быть числовым значением.");
                }

                Employee.Department = DepartmentTextBox.Text;
                Employee.DateOfBirth = DateOfBirthDatePicker.SelectedDate ?? DateTime.Now;

                DialogResult = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ошибка ввода: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось добавить сотрудника: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
