Imports System.Net
Imports System.Net.Sockets

Public Class ModBusBase : Inherits TcpClient
   Private ReadOnly MaxRegistersToReadOrWrite As Byte = 125                                           ' ModBus Max = 125
   Private ReadOnly MaxRegisterAddresses As UInt16 = 65535

   Private networkStream As NetworkStream
   Private transactionIdentifier As UInt16 = 0                                                        ' Generate/holds a unique indentifier for Each ModBus Command   

   Private ReadOnly Property ConnectionTimeout As Integer = 1000                                      ' Gets the connection Timeout in case of ModbusTCP connection
   Private ReadOnly Property IPAddress As IPAddress                                                   ' Gets the IP-Address of the Server.
   Private ReadOnly Property Port As Integer = 502                                                    ' Gets the Port were the Modbus-TCP Server is reachable (Standard is 502).
   Private ReadOnly Property UnitIdentifier As Byte = &H1                                             ' Gets the Unit identifier in case of serial connection (Default = 0)

   Public Sub New(unitIdentifier As Byte, ipAddress As IPAddress, Optional port As Integer = 502) ' Constructor which determines the Master ip-address and the Master Port.
      Me.UnitIdentifier = unitIdentifier
      Me.IPAddress = ipAddress
      Me.Port = port
   End Sub

   Public Overloads Sub Connect()                                                                     ' Establish a TCP connection to a ModBus-device 
      Connect(IPAddress, Port)

      If Connected Then
         Me.networkStream = GetStream()
         Me.networkStream.ReadTimeout = ConnectionTimeout
      Else
         Close()
         Throw New Exceptions.ConnectionException("connection timed out")
      End If
   End Sub

   Public Async Function ReadHoldingRegistersAsync(startingAddress As UShort, quantity As UShort) As Task(Of Byte())   ' Read Holding Registers from Master device (FC3).
      If Connected Then
         If startingAddress > Me.MaxRegisterAddresses OrElse quantity > Me.MaxRegistersToReadOrWrite Then Throw New ArgumentException($"Starting address must be 0 - {Me.MaxRegisterAddresses}; quantity must be 0 - {Me.MaxRegistersToReadOrWrite}")

         Me.transactionIdentifier += 1US

         Dim modBusPacket = New ModBusPacket
         modBusPacket.AddRange(BitConverter.GetBytes(Me.transactionIdentifier).Reverse)               ' TransAction
         modBusPacket.AddRange(BitConverter.GetBytes(&H0US).Reverse)                                  ' Protocol   
         modBusPacket.AddRange(BitConverter.GetBytes(&H6US).Reverse)                                  ' Length
         modBusPacket.AddRange({UnitIdentifier, &H3})                                                 ' UnitIndentifier/ModBus Fuction Code 3
         modBusPacket.AddRange(BitConverter.GetBytes(startingAddress).Reverse)                        ' StartAddress
         modBusPacket.AddRange(BitConverter.GetBytes(quantity).Reverse)                               ' Quantity   
         modBusPacket.AddRange({0, 0})                                                                ' CRC Bytes  
         modBusPacket.ComputeCRC()

         Dim receiveBuffer As Byte() = {}                                                             ' Create Respons buffer

         If Client.Connected Then
            Await Me.networkStream.WriteAsync(modBusPacket.ToArray, 0, modBusPacket.Count - 2)

            receiveBuffer = New [Byte](quantity * 2 + 8) {}
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

   Public Async Function ReadInputRegistersAsync(startingAddress As UShort, quantity As UShort) As Task(Of Byte())
      If Connected Then
         If startingAddress > Me.MaxRegisterAddresses OrElse quantity > Me.MaxRegistersToReadOrWrite Then Throw New ArgumentException($"Starting address must be 0 - {Me.MaxRegisterAddresses}; quantity must be 0 - {Me.MaxRegistersToReadOrWrite}")

         Me.transactionIdentifier += 1US

         Dim modBusPacket = New ModBusPacket
         modBusPacket.AddRange(BitConverter.GetBytes(Me.transactionIdentifier).Reverse)               ' TransAction
         modBusPacket.AddRange(BitConverter.GetBytes(&H0US).Reverse)                                  ' Protocol   
         modBusPacket.AddRange(BitConverter.GetBytes(&H6US).Reverse)                                  ' Length
         modBusPacket.AddRange({UnitIdentifier, &H4})                                                 ' UnitIndentifier/ModBus Fuction Code 4
         modBusPacket.AddRange(BitConverter.GetBytes(startingAddress).Reverse)                        ' StartAddress
         modBusPacket.AddRange(BitConverter.GetBytes(quantity).Reverse)                               ' Quantity   
         modBusPacket.AddRange({0, 0})                                                                ' CRC Bytes  
         modBusPacket.ComputeCRC()

         Dim receiveBuffer As Byte() = {}                                                             ' Create Respons buffer

         If Client.Connected Then
            Await Me.networkStream.WriteAsync(modBusPacket.ToArray, 0, modBusPacket.Count - 2)

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

   Public Shared Function CRC16(data As Byte()) As UShort
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

      Return crc
   End Function
End Class
