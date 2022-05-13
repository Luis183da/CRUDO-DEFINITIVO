Public Class Eusuario

    'Declaramos las variable de los campos de nuestra base de datos
    Private users As String
    Private passwords As String
    Private nivel As String

    Public Property _users 'Creamos las propiedades de Users
        Get  'Pondremos nuestro constructor Get
            Return users 'Retornamos al campo
        End Get
        Set(value) 'Y nuestro constructor Set
            users = value 'Le asignamos un valor a users
        End Set
    End Property

    Public Property _passwords 'Creamos las propiedades de passwords
        Get 'Pondremos nuestro constructor Get
            Return passwords 'Retornamos al campo
        End Get
        Set(value) 'Y nuestro constructor Set
            passwords = value 'Le asignamos un valor a passwords
        End Set
    End Property

    Public Property _nivel 'Creamos las propiedades de nivel
        Get 'Pondremos nuestro constructor Get
            Return nivel 'Retornamos al campo
        End Get
        Set(value) 'Y nuestro constructor Set
            nivel = value 'Le asignamos un valor a nivel
        End Set
    End Property

    Public Sub New()
        'Public por si se llega a dar un error 
    End Sub


End Class
