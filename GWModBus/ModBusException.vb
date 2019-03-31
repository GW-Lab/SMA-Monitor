Imports System.Runtime.Serialization

Namespace Exceptions
   Public Class ConnectionException : Inherits ModbusException ' Exception to be thrown if Connection to Modbus device failed
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

   Public Class FunctionCodeNotSupportedException : Inherits ModbusException ' Exception to be thrown if Modbus Server returns error code "Function code not supported"
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

   Public Class QuantityInvalidException : Inherits ModbusException ' Exception to be thrown if Modbus Server returns error code "quantity invalid"
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

   Public Class StartingAddressInvalidException : Inherits ModbusException ' Exception to be thrown if Modbus Server returns error code "starting adddress and quantity invalid"
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

   Public Class ModbusException : Inherits Exception ' Exception to be thrown if Modbus Server returns error code "Function Code not executed (0x04)"
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

   Public Class CRCCheckFailedException : Inherits ModbusException ''' Exception to be thrown if CRC Check failed
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
