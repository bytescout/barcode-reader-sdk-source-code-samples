'*******************************************************************************************'
'                                                                                           '
' Download Free Evaluation Version From:     https://bytescout.com/download/web-installer   '
'                                                                                           '
' Also available as Web API! Get free API Key https://app.pdf.co/signup                     '
'                                                                                           '
' Copyright © 2017-2020 ByteScout, Inc. All rights reserved.                                '
' https://www.bytescout.com                                                                 '
' https://www.pdf.co                                                                        '
'*******************************************************************************************'


if (WScript.Arguments.Count < 1) Then

	MsgBox "Run with the file name as the argument" & vbCRLF & vbCRLF & "ReadPatchCode.vbs <InputFileName>"
 	WScript.Quit 0
End If

WScript.Echo "Reading barcode(s) from image " & WScript.Arguments(0)

Set reader = CreateObject("Bytescout.BarCodeReader.Reader")

reader.RegistrationName = "demo"
reader.RegistrationKey = "demo"

' Set barcode type to find
reader.BarcodeTypesToFind.PatchCode = True
' Add vertical orientations to analysis
' OrientationType_Default - 17
' OrientationType_VerticalFromBottomToTop - 32768
' OrientationType_VerticalFromTopToBottom - 2
reader.Orientation = 17 Or 32768 Or 2 

reader.ReadFromFile WScript.Arguments(0)

For i = 0 To reader.FoundCount - 1 

	' Write to console
	WScript.Echo "Found barcode with type '" & reader.GetFoundBarcodeType(i) & "' and value '" & reader.GetFoundBarcodeValue(i) & "'"
Next

' Cleanup
Set reader = Nothing
