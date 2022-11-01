using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
      
        public MainViewModel()
        {
            PanelLewy = new PanelViewModel();
            PanelPrawy = new PanelViewModel();
        }
        public PanelViewModel PanelLewy { get; set; }
        public PanelViewModel PanelPrawy { get; set; }

        private ICommand copyClick;

        public ICommand CopyClick => copyClick ?? (copyClick = new RelayCommand(
            o =>
            {
                if (PanelPrawy.SelectedFolder != null)
                {
                    string PrawyFile = PanelPrawy.SelectedFolder;
                    string PrawySourceFileName = PanelPrawy.FullPath + PrawyFile;
                    string LewyTargetFileName = PanelLewy.FullPath + PrawyFile;

                    try
                    {
                        File.Copy(PrawySourceFileName, LewyTargetFileName);
                    }
                    catch
                    {
                        //Console.WriteLine("Nie udało się skopiować pliku");
                        MessageBox.Show("Nie udało się skopiować pliku");
                    }
                    PanelLewy.FullPath = PanelLewy.FullPath;
                }
                else
                {
                    string LewyFile = PanelLewy.SelectedFolder;
                    string LewySourceFileName = PanelLewy.FullPath + LewyFile;
                    string PrawyTargetFileName = PanelPrawy.FullPath + LewyFile;
                    try
                    {
                        File.Copy(LewySourceFileName, PrawyTargetFileName);
                    }
                    catch
                    {
                        //Console.WriteLine("Nie udało się skopiować pliku");
                        MessageBox.Show("Nie udało się skopiować pliku");
                    }
                    PanelPrawy.FullPath = PanelPrawy.FullPath;
                }

            }, 
            o => (PanelLewy.SelectedFolder != null && PanelPrawy.FullPath != null && !PanelLewy.SelectedFolder.StartsWith(PanelLewy.SelectedDrive)) ||
                    (PanelPrawy.SelectedFolder != null && PanelLewy.FullPath != null && !PanelPrawy.SelectedFolder.StartsWith(PanelPrawy.SelectedDrive))));
    }
}

