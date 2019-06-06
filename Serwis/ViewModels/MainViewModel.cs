using Serwis.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Serwis.Commands;
using Serwis.DataAccess;
using Serwis.DataAccess.Implementations;
using System.IO;

namespace Serwis.ViewModels
{
    class MainViewModel  
    {
        public ObservableCollection<Computer> Computers
        {
            get;set;
        }
        public Computer NewComp { get; set; }
        private bool saveToOtherFile = false;
        public ICommand AddComputer
        {
            get;
            private set;
        }
        
        private void AddNewComputer()
        {

            Computers.Add(new Computer(NewComp));
            if (saveToOtherFile == false)
            {
                var fileName = @"serwis.xml";
                if (fileName != null)
                {
                    List<Computer> ComputerList = new List<Computer>();
                    foreach (var computer in Computers)
                    {
                        ComputerList.Add(computer);
                    }
                    _xmlComputerWriter.WriteComputers(fileName, ComputerList);
                }
            }
        }

        public ICommand OpenFile { get; private set; }
        public ICommand SaveFile { get; private set; }

        public void LoadFile()
        {
            var fileName = _dialogService.OpenFileDialog();
            
            if (fileName != null)
            {
                List<Computer> ComputerList = _xmlComputerReader.ReadBooks(fileName);
                foreach (var computer in ComputerList)
                {
                    Computers.Add(computer);
                }
            }
            saveToOtherFile = true; // po załadowaniu bazy zabraniamy zapisu do bazy podstawowej
        }

        public void SaveToFile()
        {
            var fileName = _dialogService.SaveToFileDialog();
            if (fileName != null)
            {
                List<Computer> ComputerList = new List<Computer>();
                foreach (var computer in Computers)
                {
                    ComputerList.Add(computer);
                }
                _xmlComputerWriter.WriteComputers(fileName, ComputerList);
               
            }
            
        }



        


        private readonly IDialogService _dialogService;
        private readonly XmlComputerReader _xmlComputerReader;
        private readonly XmlComputerWriter _xmlComputerWriter;

        public MainViewModel(IDialogService dialogService, XmlComputerReader sourceReader, XmlComputerWriter sourceWriter)
        {
            _dialogService = dialogService;
            _xmlComputerReader = sourceReader;
            _xmlComputerWriter = sourceWriter;
           
            Computers = new ObservableCollection<Computer>();
            if (File.Exists(@"serwis.xml"))
            {
                var fileName = @"serwis.xml"; // zaladowanie domyslnej bazy przy starcie programu
                if (fileName != null)
                {
                    List<Computer> ComputerList = _xmlComputerReader.ReadBooks(fileName);
                    foreach (var computer in ComputerList)
                    {
                        Computers.Add(computer);
                    }
                }
            }
            else
            {
                File.Create(@"serwis.xml");
            }
            NewComp = new Computer();
            AddComputer = new RelayCommands(p => AddNewComputer(), null);            OpenFile = new RelayCommands(p => LoadFile(), null);            SaveFile = new RelayCommands(p => SaveToFile(), null);
        }
    }
}
