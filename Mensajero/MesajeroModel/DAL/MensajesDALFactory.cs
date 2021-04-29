using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesajeroModel.DAL
{
    public class MensajesDALFactory
    {
        public static IMensajes createDal()
        {
            return MensajesDALArchivos.getInsatancia();
        }
    }
}
