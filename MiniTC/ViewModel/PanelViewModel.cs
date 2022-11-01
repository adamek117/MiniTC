using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MiniTC.ViewModel
{
    class PanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PanelViewModel()
        {
            Drives = new ObservableCollection<string>();
            ListOfFolders = new ObservableCollection<string>();
        }
        public ObservableCollection<string> Drives { get; set; }
        public ObservableCollection<string> ListOfFolders { get; set; }

        private string selecteddrive;
        public string SelectedDrive
        {
            get => selecteddrive;
            set
            {
                selecteddrive = value;
                FullPath = selecteddrive;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(selecteddrive)));
            }
        }

        private string fullpath;
        public string FullPath
        {
            get => fullpath;
            set
            {
                ListOfFolders.Clear();
                fullpath = value;
                if(FullPath !=null)
                {
                    try
                    {
                        string[] FoldersList = Directory.GetDirectories(FullPath);
                        string[] FilesList = Directory.GetFiles(FullPath);
                        string back = "//";
                        if (FullPath.Length > 3)
                        {
                            ListOfFolders.Add(back);
                        }
                        foreach (string folder in FoldersList)
                        {
                            back = Path.GetFileName(folder);
                            back =  selecteddrive + back;
                            ListOfFolders.Add(back);
                        }
                        foreach (string file in FilesList)
                        {
                            back = Path.GetFileName(file);
                            ListOfFolders.Add(back);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Nie można tam wejść");
                        //Console.WriteLine("Nie można tam wejść");
                        FullPath = Path.GetDirectoryName(Path.GetDirectoryName(FullPath));
                    }
                    
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullPath)));

            }
        }

        private string selectedFolder;

        public string SelectedFolder
        {
            get => selectedFolder;
            set
            {
                selectedFolder = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFolder)));
            }
        }

        private ICommand combobox_click;

        public ICommand ComboboxClick => combobox_click ?? (combobox_click = new RelayCommand
                                                                        (
                                                                           o =>
                                                                           {
                                                                               Drives.Clear();
                                                                               string[] drives = Directory.GetLogicalDrives();

                                                                               foreach (var item in drives)
                                                                               {
                                                                                   Drives.Add(item);
                                                                               }
                                                                           }

                                                                        , null));


        private ICommand listBoxDoubleClick;
        public ICommand ListBoxDoubleClick => listBoxDoubleClick ?? (listBoxDoubleClick = new RelayCommand(
            o => {
                if (SelectedFolder.Equals("//"))
                {
                    FullPath = Path.GetDirectoryName(Path.GetDirectoryName(FullPath));
                    if (!FullPath.EndsWith("\\"))
                    {
                        FullPath += "\\";
                    }
                }
                else if (SelectedFolder.StartsWith(selecteddrive))
                {
                    FullPath += SelectedFolder.Remove(0, 3) + "\\";
                }
                SelectedFolder = null;
            }
            , null));
    }
}
