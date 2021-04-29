using MesajeroModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesajeroModel.DAL
{
    public interface IMensajes
    {
         void Save(Mesajero m);
         List<Mesajero> getAll();

    }
}
