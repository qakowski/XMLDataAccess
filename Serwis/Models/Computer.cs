using System;
using System.Collections.Generic;
using System.Text;

namespace Serwis.Models
{
    public class Computer: BindableBase
    {
        private int _serialNumber;
        private string _owner;
        private string _phoneNumber;
        private string _emailAddress;
        private string _address;

        public int SerialNumber
        {
            get => _serialNumber;
            set
            {
                _serialNumber = value;
                 OnPropertyChanged();
            }
        }
        public string Owner
        {
            get => _owner;
            set
            {
                _owner = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                //if (int.TryParse(value, out int phone))
                //{
                    _phoneNumber = value;
                    OnPropertyChanged();
                //}
                //else
                //{
                //    throw new ArgumentException($"{value} nie jest poprawnym numerem telefonu");
                //}
            }

        }
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                //if(value.Contains("@") && value.Contains("."))
                //{
                    _emailAddress = value;
                    OnPropertyChanged();
                //}
                //else
                //{
                //    throw new ArgumentException($"{value} nie jest poprawnym adresem email");
                //}
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        public Computer(Computer computer) : this()
        {
            this.SerialNumber = computer.SerialNumber;
            this.PhoneNumber = computer.PhoneNumber;
            this.Owner = computer.Owner;
            this.EmailAddress = computer.EmailAddress;
            this.Address = computer.Address;
        }

        public Computer()
        {

        }
        
    }
}
