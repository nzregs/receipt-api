# Extracting Data from Receipts with Microsoft Cognitive Services #

## Problem Statement ##
To facilitate faster expense processing, we want to extract certain information from receipts. Re-keying info is never fun, so we want to try and extract the key information automatically from a photo of a receipts.

## Key technologies ##
- [Computer Vision API 1.0 - Optical Character Recognition (OCR)](https://docs.microsoft.com/en-us/azure/cognitive-services/Computer-vision/Home)
- [ASP.NET Core Web Application - Web API](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api)
- [Azure Web App](https://azure.microsoft.com/en-us/services/app-service/web/)
- [C# in Visual Studio 2017 Preview 4](https://www.visualstudio.com/vs/preview/)

## Solution overview ##

This solution provides an API that in turn uses the Microsoft Cognitive Services Computer Vision OCR (Optical Character Recognition) to read text off of an image of a printed receipt.  A client app - could be a Xamarin Mobile App, a batch process, a chat bot dialog, or other - will call the API sending it an image of a receipt.  The API will process the image and return the transcription of the recognised text in the receipt image, along with key data items like Tax Number, Receipt Date, and Receipt Total, in a JSON document.

Steps:
1. Client captures image of receipt (typically with device camera)
2. Client sends image to receipt API
3. Receipt API will send the image to Cognitive Services Computer Vision OCR API
4. Receipt API receives JSON containing text from OCR API
5. Receipt API reassembles the regions/lines/words received from OCR, as best as it can, into lines resembling the original receipt
6. Receipt API prcoesses the lines and uses patterns and RegEx to find and extract the key fields including: Receipt Total, Tax Number (in this example, an Australian Business Number aka ABN), and Receipt Date
7. Client receives JSON containing receipt lines and extracted fields
8. Client continues with receipt processing

### Code repository ###

[receipt-api](https://github.com/nzregs/receipt-api) is the related GitHub repository containing the Receipt API.
