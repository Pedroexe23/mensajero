using System;
using MesajeroModel.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesajeroModel.DAL;

namespace Mensajero
{
    class Program
    {
        static IMensajes dal = MensajesDALFactory.createDal();
        static bool Menu()
        {
            Boolean S = true;
            Console.WriteLine("Bienvenido ingrese \n1. Crear Mesaje\n2.Mostrar Mensaje\n0. Salir");
            string leer = Console.ReadLine();
            switch (leer)
            {
                case "1":
                    ingresarMensaje();
                    break;
                case "2":
                    MostrarMensaje();
                    break;
                case "0":
                    S = false;
                    break;
                default:
                    break;
            }
            return S;
        }
        static void ingresarMensaje()
        {
            String nombre, detalle;
            do
            {
                Console.WriteLine("ingrese nombre");
                nombre=Console.ReadLine().Trim();
            } while (nombre==string.Empty);

            do
            {
                Console.WriteLine("Ingrese detalle");
                detalle= Console.ReadLine().Trim();
            } while (detalle==string.Empty || detalle.Length>20);
            Mesajero m = new Mesajero()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo="Aplicacion"
            };
            dal.Save(m);
        }
        static void MostrarMensaje()
        {
            List<Mesajero> mensajes = dal.getAll();
            mensajes.ForEach(m=> {
                Console.WriteLine("nombre:{0},Detalle:{1}, Tipo{2}", m.Nombre, m.Detalle, m.Tipo);
            });
        }
        static void Main(string[] args)
        {
            while (Menu()) ;
        }
    }
}
