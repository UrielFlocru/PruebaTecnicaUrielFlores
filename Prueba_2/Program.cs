using System;
using MySql.Data.MySqlClient;
using System.Diagnostics.Contracts;
using System.IO;

class Program{
    static string connectionString = "Server=localhost; Database=pruebatecnica; User Id=root; Password=password;";

    static void Main (string[] args){
        bool continuar=true;
        while (continuar){
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("1. Listar top 10 usuarios");
            Console.WriteLine("2. Generar archivo CSV");
            Console.WriteLine("3. Actualizar salario de un usuario");
            Console.WriteLine("4. Agregar un nuevo usuario");
            Console.WriteLine("5. Salir");
            var opcion = Console.ReadLine();

            switch(opcion){
                case "1":
                    ListarTop10Usuarios();
                    break;
                case "2":
                    GenerarArchivoCSV();
                    break;
                case "3":
                    Console.WriteLine("Ingrese el ID del usuario:");
                    int userId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el nuevo salario:");
                    double nuevoSalario = Convert.ToDouble(Console.ReadLine());
                    ActualizarSalario (userId, nuevoSalario);
                    break;
                case "4":
                    Console.WriteLine("Ingrese el login:");
                    string login = Console.ReadLine();
                    Console.WriteLine("Ingrese el nombre:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido paterno:");
                    string paterno = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido materno:");
                    string materno = Console.ReadLine();
                    Console.WriteLine("Ingrese el sueldo:");
                    double sueldo = Convert.ToDouble(Console.ReadLine());
                    AgregarNuevoUsuario (login, nombre, paterno, materno, sueldo);
                    break;
                
                case "5":
                    continuar=false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida, intente de nuevo");
                    break;



            }

        }

    }


    static void ListarTop10Usuarios(){
        using (MySqlConnection connection= new MySqlConnection(connectionString)){
            string query = "SELECT u.userId, u.Login, u.Nombre, u.Paterno, u.Materno, e.Sueldo, e.FechaIngreso " +
            "FROM usuarios u JOIN empleados e ON u.userId = e.userId LIMIT 10";
            MySqlCommand command = new MySqlCommand(query,connection);

            try{
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()){
                    Console.WriteLine($"ID: {reader["userId"]}, Login: {reader["Login"]}, Nombre: {reader["Nombre"]} {reader["Paterno"]} {reader["Materno"]}, Sueldo: {reader["Sueldo"]}, Fecha Ingreso: {reader["FechaIngreso"]}");
                    
                }
                reader.Close();
            }

            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
    static void GenerarArchivoCSV(){
        using (MySqlConnection connection= new MySqlConnection(connectionString)){
            string query = "SELECT u.Login, u.Nombre, u.Paterno, u.Materno, e.Sueldo, e.FechaIngreso " +
                            "FROM usuarios u JOIN empleados e ON u.userId = e.userId";

            MySqlCommand command = new MySqlCommand(query,connection);

            try{
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                using (StreamWriter writer = new StreamWriter("usuarios.csv")){
                    writer.WriteLine("Login,NombreCompleto,Sueldo,FechaIngreso");
                    while (reader.Read()){
                        string nombreCompleto = $"{reader["Nombre"]} {reader["Paterno"]} {reader["Materno"]}";
                        writer.WriteLine ($"{reader["Login"]},{nombreCompleto}, {reader["Sueldo"]},{reader["FechaIngreso"]}");

                    }
                }
                reader.Close();
            }

            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
    static void ActualizarSalario(int userId, double nuevoSalario){
        using (MySqlConnection connection= new MySqlConnection(connectionString)){
            string query = "UPDATE empleados SET Sueldo = @NuevoSueldo WHERE userId = @UserId";
            
            MySqlCommand command = new MySqlCommand(query,connection);
            command.Parameters.AddWithValue("@NuevoSueldo",nuevoSalario);
            command.Parameters.AddWithValue("@UserId",userId);

            try{
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected>0){
                    Console.WriteLine("Sueldo actualizado correctamente");
                }else{
                    Console.WriteLine("Usuario no encontrado");
                }
            }

            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }
    static void AgregarNuevoUsuario(string login, string nombre, string paterno, string materno, double sueldo){
        using (MySqlConnection connection= new MySqlConnection(connectionString)){
            string queryUsuario = "INSERT INTO usuarios (Login, Nombre, Paterno, Materno) VALUES (@Login, @Nombre, @Paterno, @Materno)";
            string queryEmpleado = "INSERT INTO empleados (userId, Sueldo, FechaIngreso) VALUES (@UserId, @Sueldo, @FechaIngreso)";
            
            MySqlCommand commandUsuario = new MySqlCommand(queryUsuario,connection);
            commandUsuario.Parameters.AddWithValue("@Login", login);
            commandUsuario.Parameters.AddWithValue("@Nombre", nombre);
            commandUsuario.Parameters.AddWithValue("@Paterno", paterno);
            commandUsuario.Parameters.AddWithValue("@Materno", materno);

            try{
                connection.Open();

                commandUsuario.ExecuteNonQuery();

                int userId = (int)commandUsuario.LastInsertedId;

                MySqlCommand commandEmpleado = new MySqlCommand(queryEmpleado,connection);
                commandEmpleado.Parameters.AddWithValue("@UserId",userId);
                commandEmpleado.Parameters.AddWithValue("@Sueldo",sueldo);
                commandEmpleado.Parameters.AddWithValue("@FechaIngreso",DateTime.Now);

                commandEmpleado.ExecuteNonQuery();

                Console.WriteLine("Nuevo usuario agreado correctamente");

            }

            catch (Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
    }


}

