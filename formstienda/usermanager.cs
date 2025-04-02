using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formstienda
{
    public  class UserManager
    {
        private static UserManager _instance;
        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }
                return _instance;
            }
        }

        // Lista para almacenar usuarios
        public List<usuarios> Usuarios { get; set; }

        // Constructor privado para el patrón Singleton
        private UserManager()
        {
            Usuarios = new List<usuarios>
            {
            new usuarios { Id= "01", Rol="Admin", Username = "Administrador", Password = "rafa8565" },
            new usuarios { Id= "02", Rol="Cajero", Username = "CajaEngel", Password = "engel59" },
            new usuarios { Id= "03", Rol="Cajero", Username = "CajaGuillermo", Password = "guillermo78" }
            };
        }

        // Método para agregar un usuario nuevo
        public bool AgregarUsuario(usuarios nuevoUsuario)
        {
            // Verificar si el usuario ya existe
            if (Usuarios.Any(u => u.Username == nuevoUsuario.Username))
            {
                MessageBox.Show("Error: El usuario ya existe.");
                return false; // Retornar falso si el usuario ya existe
            }
            else
            {
                // Agregar el nuevo usuario a la lista
                Usuarios.Add(nuevoUsuario);
                MessageBox.Show("Usuario agregado con éxito.");
                return true; // Retornar verdadero si se agregó el usuario
            }
        }

        // Otros métodos (UserLog y permisos)
        public string RolActual { get; private set; }
        public usuarios UserLog(string Username, string Password)
        {
            var user = Usuarios.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {
                RolActual = user.Rol; // Guarda el rol del usuario logueado
            }
            return user;
        }
    }
}
