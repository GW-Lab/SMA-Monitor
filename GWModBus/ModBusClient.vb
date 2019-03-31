Imports System.Net
Imports System.Text

Public Class ModBusClient : Inherits ModBusBase
   Public Sub New(unitIdentifier As Byte, ipAddress As IPAddress, port As Integer)
      MyBase.New(unitIdentifier, ipAddress, port)
   End Sub

   Public Shared Function ConvertRegistersToFloat(registers As Byte()) As Single
      If registers.Length <> 4 Then Throw New ArgumentException("Input Array length invalid - Array langth must be '4'")
      Return BitConverter.ToSingle({registers(3), registers(2), registers(1), registers(0)}, 0)
   End Function

   Public Shared Function ConvertRegistersToInt(registers As Byte()) As Integer
      If registers.Length <> 4 Then Throw New ArgumentException("Input Array length invalid - Array langth must be '4'")
      Return BitConverter.ToInt32({registers(3), registers(2), registers(1), registers(0)}, 0)
   End Function

   Public Shared Function ConvertRegistersToLong(registers As Byte()) As Long
      If registers.Length <> 8 Then Throw New ArgumentException("Input Array length invalid - Array langth must be '8'")
      Return BitConverter.ToInt64({registers(7), registers(6), registers(5), registers(4), registers(3), registers(2), registers(1), registers(0)}, 0)
   End Function

   Public Shared Function ConvertRegistersToDouble(registers As Byte()) As Double
      If registers.Length <> 8 Then Throw New ArgumentException("Input Array length invalid - Array langth must be '8'")
      Return BitConverter.ToDouble({registers(7), registers(6), registers(5), registers(4), registers(3), registers(2), registers(1), registers(0)}, 0)
   End Function

   Public Shared Function ConvertFloatToBytes(value As Single) As Byte()
      Return BitConverter.GetBytes(value)
   End Function

   Public Shared Function ConvertIntToBytes(value As Integer) As Byte()
      Return BitConverter.GetBytes(value)
   End Function

   Public Shared Function ConvertLongToBytes(value As Long) As Byte()
      Return BitConverter.GetBytes(value)
   End Function

   Public Shared Function ConvertDoubleToBytes(Value As Double) As Byte()
      Return BitConverter.GetBytes(Value)
   End Function

   Public Shared Function ConvertStringToBytes(text As String) As Byte()
      Return Encoding.Unicode.GetBytes(text)
   End Function

   Public Shared Function ConvertRegistersToString(registers As Byte()) As String
      Return BitConverter.ToString(registers)
   End Function
End Class
