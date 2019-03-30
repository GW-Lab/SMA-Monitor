Imports System.Runtime.Serialization

Namespace Exceptions
   ' Exception to be thrown if Connection to Modbus device failed
   Public Class ConnectionException : Inherits ModbusException
      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(message As String)
         MyBase.New(message)
      End Sub

      Public Sub New(message As String, innerException As Exception)
         MyBase.New(message, innerException)
      End Sub

      Protected Sub New(info As SerializationInfo, context As StreamingContext)
         MyBase.New(info, context)
      End Sub
   End Class

   ''' <summary>
   ''' Exception to be thrown if Modbus Server returns error code "Function code not supported"
   ''' </summary>
   Public Class FunctionCodeNotSupportedException
      Inherits ModbusException
      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(message As String)
         MyBase.New(message)
      End Sub

      Public Sub New(message As String, innerException As Exception)
         MyBase.New(message, innerException)
      End Sub

      Protected Sub New(info As SerializationInfo, context As StreamingContext)
         MyBase.New(info, context)
      End Sub
   End Class

   ''' <summary>
   ''' Exception to be thrown if Modbus Server returns error code "quantity invalid"
   ''' </summary>
   Public Class QuantityInvalidException
      Inherits ModbusException
      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(message As String)
         MyBase.New(message)
      End Sub

      Public Sub New(message As String, innerException As Exception)
         MyBase.New(message, innerException)
      End Sub

      Protected Sub New(info As SerializationInfo, context As StreamingContext)
         MyBase.New(info, context)
      End Sub
   End Class

   ''' <summary>
   ''' Exception to be thrown if Modbus Server returns error code "starting adddress and quantity invalid"
   ''' </summary>
   Public Class StartingAddressInvalidException
      Inherits ModbusException
      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(message As String)
         MyBase.New(message)
      End Sub

      Public Sub New(message As String, innerException As Exception)
         MyBase.New(message, innerException)
      End Sub

      Protected Sub New(info As SerializationInfo, context As StreamingContext)
         MyBase.New(info, context)
      End Sub
   End Class

   ''' <summary>
   ''' Exception to be thrown if Modbus Server returns error code "Function Code not executed (0x04)"
   ''' </summary>
   Public Class ModbusException
      Inherits Exception
      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(message As String)
         MyBase.New(message)
      End Sub

      Public Sub New(message As String, innerException As Exception)
         MyBase.New(message, innerException)
      End Sub

      Protected Sub New(info As SerializationInfo, context As StreamingContext)
         MyBase.New(info, context)
      End Sub
   End Class

   ''' <summary>
   ''' Exception to be thrown if CRC Check failed
   ''' </summary>
   Public Class CRCCheckFailedException
      Inherits ModbusException
      Public Sub New()
         MyBase.New()
      End Sub

      Public Sub New(message As String)
         MyBase.New(message)
      End Sub

      Public Sub New(message As String, innerException As Exception)
         MyBase.New(message, innerException)
      End Sub

      Protected Sub New(info As SerializationInfo, context As StreamingContext)
         MyBase.New(info, context)
      End Sub
   End Class

End Namespace
