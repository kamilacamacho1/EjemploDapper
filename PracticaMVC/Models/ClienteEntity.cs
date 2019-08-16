using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC.Models
{
    public class ClienteEntity
    {
        public int idCliente { get; set; }

        public string nombreCliente { get; set; }

        public string genero { get; set; }

        public int idProfesion { get; set; }

       
    }

    public class Persona
    {
        public string nombre { get; set; }

        public int edad { get; set; }

        public int peso { get; set; }

        public string CambiarNobre()
        {
            var newNombre = "Hola_"+nombre;
            return newNombre;
        }

        public int calcula()
        {
            int calcular = edad * peso;
            return calcular;
        }

        public void instancia()
        {
            Persona per = new Persona();
            per.nombre = "Camila";
            per.edad = 22;
            per.peso = 65;


        }

    }
}