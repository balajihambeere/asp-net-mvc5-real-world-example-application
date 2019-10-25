using GyandhaaraLibrary.Data;
using GyandhaaraLibrary.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyandhaaraLibrary.Service
{
    public class HomeService : IHomeService
    {
        public void Load()
        {
            Database.SetInitializer<DataContext>(new DataContextInitializer());
        }
    }
}
