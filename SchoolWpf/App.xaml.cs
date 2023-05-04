using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SchoolWpf.Components.Model;

namespace SchoolWpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ZooDB_ZiatEntities Db = new ZooDB_ZiatEntities();
    }
}
