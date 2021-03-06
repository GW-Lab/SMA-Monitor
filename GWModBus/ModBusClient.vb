﻿Imports System.Net
Imports System.Text

Public Class ModBusClient : Inherits ModBusBase
   Public Sub New(unitIdentifier As Byte, ipAddress As IPAddress, port As Integer)
      MyBase.New(unitIdentifier, ipAddress, port)
   End Sub

   Public Shared Function ConvertToSingle(registers As Byte()) As Single
      If registers.Length = 4 Then
         Return BitConverter.ToSingle({registers(3), registers(2), registers(1), registers(0)}, 0)
      Else
         Throw New ArgumentException("Input Array length invalid - Array langth must be '4'")
      End If
   End Function

   Public Shared Function ConvertToInt(registers As Byte()) As Integer
      If registers.Length = 4 Then
         Return BitConverter.ToInt32({registers(3), registers(2), registers(1), registers(0)}, 0)
      Else
         Throw New ArgumentException("Input Array length invalid - Array langth must be '4'")
      End If
   End Function

   Public Shared Function ConvertToLong(registers As Byte()) As Long
      If registers.Length = 8 Then
         Return BitConverter.ToInt64({registers(7), registers(6), registers(5), registers(4), registers(3), registers(2), registers(1), registers(0)}, 0)
      Else
         Throw New ArgumentException("Input Array length invalid - Array langth must be '8'")
      End If
   End Function

   Public Shared Function ConvertToDouble(registers As Byte()) As Double
      If registers.Length = 8 Then
         Return BitConverter.ToDouble({registers(7), registers(6), registers(5), registers(4), registers(3), registers(2), registers(1), registers(0)}, 0)
      Else
         Throw New ArgumentException("Input Array length invalid - Array langth must be '8'")
      End If
   End Function

   Public Shared Function ConvertSingleToBytes(value As Single) As Byte()
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

   Public Shared Function ConvertToString(registers As Byte()) As String
      Return BitConverter.ToString(registers)
   End Function
End Class
