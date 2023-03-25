using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datos
{
    public class TicketsDB
    {
        string cadena = "server=localhost; user=root; database=soportetecnico; password=Shinigam96!;";

        public bool Guardar(Tickets tickets, List<Tickets> miTicket)
        {
            bool inserto = false;
            int idTicket = 0;
            try
            {
                StringBuilder sqlTicket = new StringBuilder();
                sqlTicket.Append(" INSERT INTO tickets (Fecha, IdentidadCliente, CodigoUsuario, TipoSoporte, DescripcionSolicitud, DescripcionRespuesta, Precio, ISV, Descuento, SubTotal, Total) VALUES (@Fecha, @IdentidadCliente, @CodigoUsuario, @TipoSoporte, @DescripcionSolicitud, @DescripcionRespuesta, @Precio, @ISV, @Descuento, @SubTotal, @Total); ");
                sqlTicket.Append(" SELECT LAST_INSERT_ID(); ");

                //StringBuilder sqlDetalle = new StringBuilder();
                //sqlDetalle.Append(" INSERT INTO detalletickets (IdTicket, CodigoTipoSoporte, Precio, Total) VALUES (@IdTicket, @CodigoTipoSoporte, @Precio, @Total); ");

                //StringBuilder sqlExistencia = new StringBuilder();
                //sqlExistencia.Append(" UPDATE producto SET Existencia = Existencia - @Cantidad WHERE Codigo = @Codigo; ");

                using (MySqlConnection con = new MySqlConnection(cadena))
                {
                    con.Open();

                    MySqlTransaction transaction = con.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                    try
                    {
                        using (MySqlCommand cmd1 = new MySqlCommand(sqlTicket.ToString(), con, transaction))
                        {
                            cmd1.CommandType = System.Data.CommandType.Text;
                            cmd1.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = tickets.Fecha;
                            cmd1.Parameters.Add("@IdentidadCliente", MySqlDbType.VarChar, 25).Value = tickets.IdentidadCliente;
                            cmd1.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = tickets.CodigoUsuario;
                            cmd1.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 50).Value = tickets.TipoSoporte;//****
                            cmd1.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 150).Value = tickets.DescripcionSolicitud;
                            cmd1.Parameters.Add("@DescripcionRespuesta", MySqlDbType.VarChar, 150).Value = tickets.DescripcionRespuesta;
                            cmd1.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = tickets.Precio;
                            cmd1.Parameters.Add("@ISV", MySqlDbType.Decimal).Value = tickets.ISV;
                            cmd1.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = tickets.Descuento;
                            cmd1.Parameters.Add("@SubTotal", MySqlDbType.Decimal).Value = tickets.SubTotal;
                            cmd1.Parameters.Add("@Total", MySqlDbType.Decimal).Value = tickets.Total;
                            idTicket = Convert.ToInt32(cmd1.ExecuteScalar());
                        }



                        transaction.Commit();
                        inserto = true;
                    }
                    catch (System.Exception)
                    {
                        inserto = false;
                        transaction.Rollback();
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return inserto;
        }
    }
}
