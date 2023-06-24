﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PersonaNegocio
    {
        public void Agregar(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("ISERT INTO PERSONAS(IDUsuario,Dni,Nombre,Apellido,FechaNacimiento,UrlImagen,IDLocalidad,IDProvincia,Telefono)" +
                    "VALUES(@IDUsuario,@Dni,@Nombre,@Apellido,@FechaNacimiento,@urlDefault,@IDLocalidad,@IDProvincia,@Telefono)");

                datos.setearParametro("@IDUsuario", persona.IDUsuario);
                datos.setearParametro("@Nombre", persona.Nombre);
                datos.setearParametro("@Apellido", persona.Apellido);
                datos.setearParametro("@Dni", persona.Dni);
                datos.setearParametro("@FechaNacimiento", persona.FechaNacimiento);
                //Imagen por default " "
                datos.setearParametro("@urlDefault", "");
                datos.setearParametro("@IDLocalidad", persona.IDLocalidad);
                datos.setearParametro("@IDProvincia", persona.IDProvincia);
                datos.setearParametro("@Telefono", persona.Telefono);

                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

        }
    }
}