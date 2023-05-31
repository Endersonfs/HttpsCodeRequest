using HttpsCodeRequest;

Console.WriteLine(HttpsCode.OK);// Return Value (OK)
Console.WriteLine((int)HttpsCode.OK);// Return Code (200)
Console.WriteLine(HttpsCode.OK.GetDescription());// Return Descrption
Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine((int)HttpsCode.OK +" - "+HttpStatusCode.GetDescriptionByCode(HttpsCode.OK)); // Return Descrption
