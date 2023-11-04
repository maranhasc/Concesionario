using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concesionario.model
{
    internal class GestorDeDatos
    {
        private const string archivoDatos = "coches.txt";

        public Coche[] LeerTodosLosRegistros()
        {
            if (!File.Exists(archivoDatos))
                return new Coche[0];

            string[] registros = File.ReadAllLines(archivoDatos);
            Coche[] resultado = new Coche[registros.Length];

            for (int i = 0; i < registros.Length; i++)
            {
                string[] campos = registros[i].Split(',');

                Coche coches = new Coche
                {
                    Modelo = campos[0],
                    Marca = campos[1],
                    Motor = campos[2],
                    Stock = campos[3],
                    Precio = campos[4],
                    Año = campos[5]
                };
                resultado[i] = coches;
            }
            return resultado;
        }

        public void Guardar(IEnumerable<Coche> coches)
        {
            StringBuilder builder = new StringBuilder();

            foreach (Coche c in coches)
            {
                string registro = string.Format("{0},{1},{2},{3},{4},{5}",c.Modelo, c.Marca, c.Motor, c.Stock,c.Precio, c.Año);
                                                
                                                     
                builder.AppendLine(registro);
            }


            File.WriteAllText(archivoDatos, builder.ToString());

        }
    }
}
