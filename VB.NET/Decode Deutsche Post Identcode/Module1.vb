'*****************************************************************************************'
'                                                                                         '
' Download offline evaluation version (DLL): https://bytescout.com/download/web-installer '
'                                                                                         '
' Signup Web API free trial: https://secure.bytescout.com/users/sign_up                   '
'                                                                                         '
' Copyright © 2017-2018 ByteScout Inc. All rights reserved.                               '
' http://www.bytescout.com                                                                '
'                                                                                         '
'*****************************************************************************************'


Imports System.IO

Imports Bytescout.BarCodeReader

Module Module1

    Sub Main()
        Const imageFile As String = "DeutschePostIdentcode.png"

        Console.WriteLine("Reading barcode(s) from image {0}", Path.GetFullPath(imageFile))

		Dim reader As New Reader()
        reader.RegistrationName = "demo"
		reader.RegistrationKey = "demo"

		' Set barcode type to find
		reader.BarcodeTypesToFind.Interleaved2of5 = True ' "Deutsche Post Identcode" is subset of "Interleaved 2 of 5" barcode

		' Read barcodes
		Dim barcodes As FoundBarcode() = reader.ReadFrom(imageFile)

        For Each barcode As FoundBarcode In barcodes
            Console.WriteLine("Found barcode with type '{0}' and value '{1}'", barcode.Type, barcode.Value)
        Next

        Console.WriteLine("Press any key to exit..")
        Console.ReadKey()

    End Sub

End Module
