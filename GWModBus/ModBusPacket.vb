Public Class ModBusPacket : Inherits List(Of Byte)
   Public Sub AddCRC()
      AddRange(ModBusBase.CRC16(ToArray)) ' Add the CRC to the Packet
   End Sub
End Class
