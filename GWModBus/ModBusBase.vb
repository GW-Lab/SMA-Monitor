Imports System.Net
Imports System.Net.Sockets

Public Class ModBusBase : Inherits TcpClient
   ReadOnly MaxRegistersToReadOrWrite As Byte = 125                                                                     ' ModBus registers   125 maximal to read/write in a command
   ReadOnly MaxRegisterAddresses As UShort = 65535                                                                      ' ModBus addresses 65535 maximal
   ReadOnly ConnectionTimeout As Integer = 1000                                                                         ' Connection Timeout in case of ModbusTCP connection
   ReadOnly IPAddress As IPAddress                                                                                      ' IP-Address of the Server.
   ReadOnly Port As Integer = 502                                                                                       ' Port were the Modbus-TCP Server is reachable (Standard is 502).
   ReadOnly UnitID As Byte = &H1                                                                                        ' Unit identifier in case of serial connection (Default = 0)

   Private networkStream As NetworkStream
   Private transactionID As UShort = 0                                                                                  ' Unique (generated) indentifier for Each command send to the ModBus   

   Public Sub New(unitID As Byte, ipAddress As IPAddress, Optional port As Integer = 502)                               ' Constructor which determines the Master ip-address and the Master Port.
      Me.UnitID = unitID
      Me.IPAddress = ipAddress
      Me.Port = port
   End Sub

   Public Overloads Sub Connect()                                                                                       ' Establish a TCP connection to a ModBus-device 
      Connect(Me.IPAddress, Me.Port)

      If Connected Then
         Me.networkStream = GetStream()
         Me.networkStream.ReadTimeout = Me.ConnectionTimeout
      Else
         Close()
         Throw New Exceptions.ConnectionException("connection timed out")
      End If
   End Sub

   Public Async Function ReadHoldingAsync(startingAddress As UShort, quantity As UShort) As Task(Of Byte())             ' Read Holding Register(s) from Master device (FC3).
      If Connected Then
         If startingAddress > Me.MaxRegisterAddresses OrElse quantity > Me.MaxRegistersToReadOrWrite Then Throw New ArgumentException($"Starting address must be 0 - {Me.MaxRegisterAddresses}; quantity must be 0 - {Me.MaxRegistersToReadOrWrite}")

         Me.transactionID += 1US

         Dim packet = New ModBusPacket
         packet.AddRange(BitConverter.GetBytes(Me.transactionID).Reverse)                                               ' TransAction ID
         packet.AddRange(BitConverter.GetBytes(&H0US).Reverse)                                                          ' Protocol   
         packet.AddRange(BitConverter.GetBytes(&H6US).Reverse)                                                          ' Length
         packet.AddRange({Me.UnitID, &H3})                                                                              ' UnitIndentifier/ModBus Fuction Code 3 Read Holding register
         packet.AddRange(BitConverter.GetBytes(startingAddress).Reverse)                                                ' StartAddress
         packet.AddRange(BitConverter.GetBytes(quantity).Reverse)                                                       ' Quantity   
         packet.AddCRC()                                                                                            ' Read ALL data added to the packet until now Compute CRC16 and append the CRC16 to the packet   

         Dim receiveBuffer As Byte() = {}                                                                               ' Create a Respons buffer

         If Client.Connected Then
            Await Me.networkStream.WriteAsync(packet.ToArray, 0, packet.Count - 2)

            receiveBuffer = New Byte(quantity * 2 + 8) {}
            Dim bytesReceived = Await Me.networkStream.ReadAsync(receiveBuffer, 0, receiveBuffer.Length)
         End If

         If receiveBuffer(7) = &H84 Then
            Select Case receiveBuffer(8)
               Case &H1 : Throw New Exceptions.FunctionCodeNotSupportedException("Function code not supported by master")
               Case &H2 : Throw New Exceptions.StartingAddressInvalidException("Starting address invalid or starting address + quantity invalid")
               Case &H3 : Throw New Exceptions.QuantityInvalidException("quantity invalid")
               Case &H4 : Throw New Exceptions.ModbusException("error reading")
            End Select
         End If

         Dim modBusPayload = New Byte(quantity * 2 - 1) {}
         Array.Copy(receiveBuffer, 9, modBusPayload, 0, quantity * 2)

         Return modBusPayload
      Else
         Throw New Exceptions.ConnectionException("connection error")
      End If
   End Function

   Public Async Function ReadInputAsync(startingAddress As UShort, quantity As UShort) As Task(Of Byte())            ' Read Input Register(s) from Master device (FC3).
      If Connected Then
         If startingAddress > Me.MaxRegisterAddresses OrElse quantity > Me.MaxRegistersToReadOrWrite Then Throw New ArgumentException($"Starting address must be 0 - {Me.MaxRegisterAddresses}; quantity must be 0 - {Me.MaxRegistersToReadOrWrite}")

         Me.transactionID += 1US

         Dim packet = New ModBusPacket
         packet.AddRange(BitConverter.GetBytes(Me.transactionID).Reverse)                             ' TransAction ID
         packet.AddRange(BitConverter.GetBytes(&H0US).Reverse)                                        ' Protocol   0=TCP
         packet.AddRange(BitConverter.GetBytes(&H6US).Reverse)                                        ' Length
         packet.AddRange({Me.UnitID, &H4})                                                            ' UnitIndentifier/ModBus Fuction Code 4 Read input Register(s)
         packet.AddRange(BitConverter.GetBytes(startingAddress).Reverse)                              ' StartAddress
         packet.AddRange(BitConverter.GetBytes(quantity).Reverse)                                     ' Quantity   
         packet.AddCRC()                                                                              ' Use ALL packet data (except CRC bytes) and Compute the CRC16 and append the CRC16 to the packet  

         Dim receiveBuffer As Byte() = {}                                                             ' Create Respons a buffer

         If Client.Connected Then
            Await Me.networkStream.WriteAsync(packet.ToArray, 0, packet.Count - 2)

            receiveBuffer = New Byte(quantity * 2 + 8) {}
            Dim bytesReceived = Await Me.networkStream.ReadAsync(receiveBuffer, 0, receiveBuffer.Length)
         End If

         If receiveBuffer(7) = &H84 Then
            Select Case receiveBuffer(8)
               Case &H1 : Throw New Exceptions.FunctionCodeNotSupportedException("Function code not supported by master")
               Case &H2 : Throw New Exceptions.StartingAddressInvalidException("Starting address invalid or starting address + quantity invalid")
               Case &H3 : Throw New Exceptions.QuantityInvalidException("quantity invalid")
               Case &H4 : Throw New Exceptions.ModbusException("error reading")
            End Select
         End If

         Dim modBusPayload = New Byte(quantity * 2 - 1) {}
         Array.Copy(receiveBuffer, 9, modBusPayload, 0, quantity * 2)

         Return modBusPayload
      Else
         Throw New Exceptions.ConnectionException("connection error")
      End If
   End Function

   Public Sub Disconnect()                                                                            ' Close connection to ModBus-device.
      If Me.networkStream IsNot Nothing Then Me.networkStream.Close()
      If Me IsNot Nothing Then Close()
   End Sub

   Protected Overrides Sub Finalize()                                                                 ' Destructor - Close connection to ModBus-device.
      Try
         If Me.networkStream IsNot Nothing Then
            Me.networkStream.Close()
         End If

         Close()
      Finally
         MyBase.Finalize()
      End Try
   End Sub

#Region "CRC16"
   ' 6.2.2 CRC Generation from the MODBUS Specification V1.02

   ' A procedure For generating a CRC Is 
   ' 1. Load a 16bit register with FFFF hex (all 1's). Call this the CRC register. 
   ' 2. Exclusive Or the first 8bit byte of the message with the low order byte of the 16 bit CRC register, putting the result in the 
   ' CRC register. 
   ' 3. Shift the CRC register one bit to the right (toward the LSB), zero filling the MSB. 
   ' Extract And examine the LSB. 
   ' 4. (If the LSB was 0): Repeat Step 3 (another shift). 
   ' (If the LSB was 1): Exclusive Or the CRC register with the polynomial value 0xA001 (1010 0000 0000 0001). 
   ' 5. Repeat Steps 3 And 4 until 8 shifts have been performed. When this Is done, a complete 8bit byte will have been processed. 
   ' 6. Repeat Steps 2 through 5 for the next 8bit byte of the message. Continue doing this until all bytes have been processed. 
   ' 7. The final content of the CRC register Is the CRC value. 
   ' 8. When the CRC Is placed into the message, its upper And lower bytes must be swapped.

   Public Shared Function CRC16(data As Byte()) As Byte()
      Dim crc As UShort = &HFFFF

      For ndx = 0 To data.Length - 1
         crc = crc Xor data(ndx)

         For j = 0 To 7
            If (crc And &H1) > 0 Then
               crc >>= 1
               crc = CUShort(crc Xor &HA001)
            Else
               crc >>= 1
            End If
         Next
      Next

      Return BitConverter.GetBytes(crc)
   End Function
#End Region

End Class
