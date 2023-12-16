using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesApp.Models
{
    public class EmployeeModel : INotifyPropertyChanged
    {
        private string _name;
        private string _position;
        private int _salary;
        private string _department;
        private DateTime _dateOfBirth;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                    return;
                _position = value;
                OnPropertyChanged("Position");
            }
        }
        public int Salary
        {
            get { return _salary; }
            set
            {
                if (_salary == value)
                    return;
                _salary = value;
                OnPropertyChanged("Salary");
            }
        }
        public string Department
        {
            get { return _department; }
            set
            {
                if (_department == value)
                    return;
                _department = value;
                OnPropertyChanged("Department");
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (_dateOfBirth == value)
                    return;
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
