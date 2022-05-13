Imports System.Data.SqlClient 'importamos la libreria para la base de datos
Imports entidad   'importamos la capa entidad con la ayuda de una referencia hecha antes
Public Class Fusuario

    Inherits conexion 'Hacemos constancia de nuestra clase conexion

    Public Function validarusuario(ByVal dts As Eusuario) As DataTable 'Creamos nuestro funcion en ella esta la variable que recibira los valores enviados por Eusuarios
        conectado() 'conexion hecha
        cmd = New SqlCommand("_iniciosesion") 'Enviamos el procedimiento almacenado que se llama iniciosesion
        cmd.CommandType = CommandType.StoredProcedure 'especificamos el tipo de comando
        cmd.Connection = cnn 'Devolvemos nuestra conexion al comando que estamos enviando

        cmd.Parameters.AddWithValue("@users", dts._users) 'Enviamos los parametros de users
        cmd.Parameters.AddWithValue("@passwords", dts._passwords) 'Enviamos los parametros de passwords

        If cmd.ExecuteNonQuery Then  'Si todo se ejectura correctamente creamos un datatable
            Using dt As New DataTable 'Declaramos la variable de nuestro datatable
                Using da As New SqlDataAdapter(cmd) 'Declaramos una variable para nuestro dataAdapter convertira todo los datos enviamos de SQL a Visual studio todo enviamos
                    'desde el comando CMD
                    da.Fill(dt) 'Rellenamos todo lo que tiene nuestro adaptador a nuestro Datatable
                    Return dt 'Retornamos el dataTable con el contenido
                End Using
            End Using
        Else 'En caso de que no se ejecute como quisieramos
            Return Nothing 'por medio de Nothing diremos que no se retorne nada
        End If

    End Function
End Class
