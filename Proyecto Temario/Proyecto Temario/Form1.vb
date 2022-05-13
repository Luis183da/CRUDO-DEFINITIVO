Imports entidad     'importamos la capa entidad
Imports datos     'importamos la capa datos

Public Class Form1
    Dim maest As New Maestro 'variable que hace referencia al formulario de Maestro
    Dim alum As New Alumno 'variable que hace referencia al formulario de alumno
    Dim fu As New Fusuario  'variable que hacen referencia a nuestra funcion Fusuario
    Dim eu As New Eusuario  'variable que hacen referencia a nuestra funcion Eusuario

    Dim texto As String 'declaramos una variable para el checkbox
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckMostrar.CheckedChanged
        If CheckMostrar.Checked = False Then 'con la ayudad de la sentencia if realizaremos la funcion de mostrar el texto de nuestro textbox
            TxtContraseña.PasswordChar = "*" 'si no se presiona el checkbox nuestro textbox se encuentra en modo passwordchar se quedara asi
        Else
            TxtContraseña.PasswordChar = "" 'de modo que si se presiona nuestro checkbox se activara y mostrara lo escrito en el texto de contraseña
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BtnIniciar_Click(sender As Object, e As EventArgs) Handles BtnIniciar.Click 'Boton Iniciar sesion

        Try 'Inicio de capturador de errores
            'Con la ayuda de If comprobaremos que todos nuestro textbox esten llenos 
            If TxtContraseña.Text <> "" And TxtUsuario.Text <> "" Then
                Dim dt As New DataTable 'Creamos un data table

                eu._users = TxtUsuario.Text 'Igualamos users que son los datos ingresados al textbox para comprobar con la base de datos
                eu._passwords = TxtContraseña.Text 'Igualamos passwords que son los datos ingresados al textbox para comprobar con la base de datos
                dt = fu.validarusuario(eu) 'Igualamos el data table de lo que enviamos de nuestra funcion Fusuario y enviamos el Eusuario



                If dt.Rows.Count > 0 Then 'Consulta por medio de un if si existe nuestro usuario en la base de datos
                    Timer1.Start() 'Iniciamos el timer luego de la funcion de arriba

                    Dim nivel As String 'Declaramos la variable de nivel para validar que tipo de usuario quiere ingresar
                    nivel = dt.Rows(0)("nivel") 'Igualamos el nivel a lo que corresponda con el dataTable y asignarle su tipo de usuario y por ende su ingreso
                    If nivel = "Alumno" Then 'Si nivel coincide con el tipo de Usuario alumno se abrira el form correspondiente
                        alum.Show() 'Apertura correspondiente al formulario de tipo de usuario Alumno
                    ElseIf nivel = "Maestro" Then 'Si el nivel de usuario es igual a Maestro entonces aperturamos el form correspondiente
                        maest.Show() 'Apertura del formulario de Maestro
                    End If
                Else
                    Static intento As Integer 'Declaramos un variable para los intentos de entrar errados por el usuario
                    intento = intento + 1 'Suma de los intentos del Usuario
                    MsgBox("estimado usuario te quedan" & (100 - intento) & "intentos") 'Conteo de los intentos que le restan a nuestra usuario
                    If intento = 3 Then 'Si es mayor a 3 intentos mostrara un Mensaje
                        MsgBox("Sigue intentanto, por favor", MsgBoxStyle.Critical, "Sistema") 'Mensaje donde se le invite al usuario a seguir intentando entrar
                    End If
                End If
            End If
        Catch ex As Exception 'Fin de capturador de Errores
            MsgBox(ex.Message) 'Mensaje en caso de un error en el procedimiento anterior 
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick  'Timer para nuestra progresbar
        ProgressBar1.Increment(5) 'Programamos el progressbar para que se incremente de 5 en 5
        If ProgressBar1.Value = 100 Then 'Si nuestro progressbar iguala el valor de 100
            Timer1.Enabled = False 'El Timer se va a finalizar
            Me.Hide() 'Ocultamos el formulario de Login
            MsgBox("Bienvenido  " & TxtUsuario.Text) 'Se podra visualizar un mensaje de bienvenidad
        End If
    End Sub
End Class
