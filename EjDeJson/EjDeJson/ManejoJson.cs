using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace EjDeJson
{
    public  static class ManejoJson
    {
        public static void GuardarEnJson(List<Estudiante> estudiantes, string rutaArchivo)
        {
            string json = JsonConvert.SerializeObject(estudiantes, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
        }

        public static List<Estudiante> LeerDesdeJson(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                return JsonConvert.DeserializeObject<List<Estudiante>>(json) ?? new List<Estudiante>();
            }
            return new List<Estudiante>();
        }
    }
}
