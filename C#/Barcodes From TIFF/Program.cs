//*******************************************************************************************//
//                                                                                           //
// Download Free Evaluation Version From: https://bytescout.com/download/web-installer       //
//                                                                                           //
// Also available as Web API! Free Trial Sign Up: https://secure.bytescout.com/users/sign_up //
//                                                                                           //
// Copyright © 2017-2018 ByteScout Inc. All rights reserved.                                 //
// http://www.bytescout.com                                                                  //
//                                                                                           //
//*******************************************************************************************//


using System;
using Bytescout.BarCodeReader;

namespace BarcodesFromTIFF
{
    class Program
    {
        static void Main()
        {
            Reader barcodeReader = new Reader();
            barcodeReader.RegistrationName = "demo";
			barcodeReader.RegistrationKey = "demo";

            // Limit search to 1-dimensional barcodes only (exclude 2D barcodes to speed up the processing).
            // Change to barcodeReader.BarcodeTypesToFind.SetAll() to scan for all supported 1D and 2D barcode types
            // or select specific type, e.g. barcodeReader.BarcodeTypesToFind.PDF417 = True
			barcodeReader.BarcodeTypesToFind.All1D = true;
			
			Console.WriteLine("Reading barcode(s) from TIFF image...");

            FoundBarcode[] barcodes = barcodeReader.ReadFrom("multipage.tif");

            foreach (FoundBarcode barcode in barcodes)
            {
                Console.WriteLine("Found barcode with type '{0}' and value '{1}' on page {2} at {3}", barcode.Type, barcode.Value, barcode.Page, barcode.Rect);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
