Imports System.Data.SqlClient  'importamos la libreria 

Public Class conexion
    Public cnn As New SqlConnection 'Variable que almacena la conexion 
    Public cmd As New SqlCommand    'Variable que almacena todos los comandos que se envian desde sql server

    Public Function conectado()
        Try 'capturador de errores
            cnn = New SqlConnection(My.Settings.colegio) 'conexion a nuestra base de datos "colegio" es la referencia de la base de datos
            cnn.Open() 'abrimos la conexion 
            Return True 'Retornamos a verdadero
        Catch ex As Exception
            MsgBox(ex.Message) 'agregamos un Msgbox por si existe algun error
            Return False 'Retornamos a falso
        End Try 'fin del capturador de errores
    End Function

End Class
