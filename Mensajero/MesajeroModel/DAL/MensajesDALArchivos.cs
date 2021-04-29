using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MesajeroModel.DTO;

namespace MesajeroModel.DAL
{
    public class MensajesDALArchivos : IMensajes
    {
        
        private MensajesDALArchivos()
        {

        }
        private static IMensajes instancia;
        public static IMensajes getInsatancia()
        {
            if (instancia == null)
                instancia = new MensajesDALArchivos();
            return instancia;
        }


        private string archivo = Directory.GetCurrentDirectory()
            + Path.DirectorySeparatorChar + "mensajes.csv";

        public List<Mesajero> getAll()
        {
            List<Mesajero> mesajeros = new List<Mesajero>();

            try
            {
                using (StreamReader reader= new StreamReader(archivo))
                {
                    string texto = null;
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto!=null)
                        {
                            String[] textoArray = texto.Split(';');
                            Mesajero m = new Mesajero()
                            {
                                Nombre = textoArray[0],
                                Detalle= textoArray[1],
                                Tipo= textoArray[2]
                            };
                            mesajeros.Add(m);

                        }
                    } while (texto!=null);   
                }
            }
            catch (IOException ex)
            {

                throw;
            }

            return mesajeros;
        }

        public void Save(Mesajero m)
        {
            try
            {
                using (StreamWriter writer= new StreamWriter(archivo, true))
                {
                    writer.WriteLine(m);
                    writer.Flush();
                }
            }
            catch (IOException ex)
            {

                throw;
            }
        }
    }
}

