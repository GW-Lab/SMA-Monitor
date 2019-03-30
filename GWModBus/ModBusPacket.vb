Public Class ModBusPacket : Inherits List(Of Byte)
   Public Sub ComputeCRC()
      Dim crc = BitConverter.GetBytes(ModBusBase.CRC16(Me.ToArray))

      Item(Count - 2) = crc(0)
      Item(Count - 1) = crc(1)
   End Sub

   'Public Shared Function DetectValidModbusFrame(readBuffer As Byte(), length As Integer) As Boolean
   '   If length < 6 Then ' minimum length 6 bytes
   '      Return False
   '   End If

   '   If (readBuffer(0) < 1) OrElse (readBuffer(0) > 247) Then 'SlaveID correct
   '      Return False
   '   End If

   '   Dim crc = System.BitConverter.GetBytes(GWModBus.Crc.Calculate(readBuffer, CUShort(length - 2), 0))
   '   If crc(0) <> readBuffer(length - 2) OrElse crc(1) <> readBuffer(length - 1) Then
   '      Return False
   '   End If

   '   Return True
   'End Function
End Class
