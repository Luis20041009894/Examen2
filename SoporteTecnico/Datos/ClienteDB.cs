﻿using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Datos
{
    public class ClienteDB
    {
        string cadena = "server=localhost; user=root; database=soportetecnico; password=Shinigam96!;";


        public bool Insertar(Cliente cliente)
        {
            bool inserto = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO cliente VALUES ");
                sql.Append(" (@Identidad, @Nombre, @Telefono, @Correo, @Direccion, @FechaNacimiento, @EstadoActivo); ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = cliente.Identidad;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = cliente.Nombre;
                        comando.Parameters.Add("@Telefono", MySqlDbType.VarChar, 15).Value = cliente.Telefono;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = cliente.Correo;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 100).Value = cliente.Direccion;
                        comando.Parameters.Add("@FechaNacimiento", MySqlDbType.DateTime).Value = cliente.FechaNacimiento;
                        comando.Parameters.Add("@EstadoActivo", MySqlDbType.Bit).Value = cliente.EstadoActivo;
                        comando.ExecuteNonQuery();
                        inserto = true;

                    }
                }


            }
            catch (System.Exception ex)
            {
            }

            return inserto;

        }

        public bool Editar(Cliente cliente)
        {
            bool edito = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE cliente SET ");
                sql.Append(" Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion, FechaNacimiento = @FechaNacimiento, EstadoActivo = @EstadoActivo ");
                sql.Append(" WHERE Identidad = @Identidad; ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = cliente.Identidad;
                        comando.Parameters.Add("@Nombre", MySqlDbType.VarChar, 50).Value = cliente.Nombre;
                        comando.Parameters.Add("@Telefono", MySqlDbType.VarChar, 15).Value = cliente.Telefono;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value = cliente.Correo;
                        comando.Parameters.Add("@Direccion", MySqlDbType.VarChar, 100).Value = cliente.Direccion;
                        comando.Parameters.Add("@FechaNacimiento", MySqlDbType.DateTime).Value = cliente.FechaNacimiento;
                        comando.Parameters.Add("@EstadoActivo", MySqlDbType.Bit).Value = cliente.EstadoActivo;
                        comando.ExecuteNonQuery();
                        edito = true;
                    }
                }

            }
            catch (System.Exception ex)
            {
            }
            return edito;
        }

        public bool Eliminar(string identidad)
        {
            bool elimino = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM cliente ");
                sql.Append(" WHERE Identidad = @Identidad; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = identidad;
                        comando.ExecuteNonQuery();
                        elimino = true;

                    }
                }


            }
            catch (System.Exception ex)
            {
            }

            return elimino;

        }

        public DataTable DevolverClientes()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM cliente ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }

        public DataTable DevolverClientesPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM cliente WHERE Nombre LIKE '%" + nombre + "%'");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }


        public Cliente DevolverClientePorIdentidad(string identidad)
        {
            {
                Cliente cliente = null;
                try
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" SELECT * FROM cliente WHERE Identidad = @Identidad; ");
                    using (MySqlConnection _conexion = new MySqlConnection(cadena))
                    {
                        _conexion.Open();
                        using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                        {
                            comando.CommandType = CommandType.Text;
                            comando.Parameters.Add("@Identidad", MySqlDbType.VarChar, 25).Value = identidad;
                            MySqlDataReader dr = comando.ExecuteReader();
                            if (dr.Read())
                            {
                                cliente = new Cliente();

                                cliente.Identidad = identidad;
                                cliente.Nombre = dr["Nombre"].ToString();
                                cliente.Telefono = dr["Telefono"].ToString();
                                cliente.Correo = dr["Correo"].ToString();
                                cliente.Direccion = dr["Direccion"].ToString();
                                cliente.FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                                cliente.EstadoActivo = Convert.ToBoolean(dr["EstadoActivo"]);
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                }
                return cliente;

            }


        }
    }
}