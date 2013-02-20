Title: Bitcoin Meter - Written in C#  
Date: 2/19/2013  
Author: Steven Kiley - skiley22@gmail.com  
Objective: To serialize JSON data provided by BitcoinPool.com and display it in a Rainmeter skin.  
Note: Code may be modified to be used with other pools and/or JSON objects  
This utilizes the official Rainmeter Plugin SDK found [here] (https://github.com/rainmeter/rainmeter-plugin-sdk)  
  
The "API" folder is reserved for compile-time. Don't touch anything inside. The "C#" folder is what you will be working with.  

All working files are contained under "SDK-CS.sln"; run this file to compile. Here I will explain the purpose of each C# file, and how to manipulate them to suit your needs:  

Serializer.cs  
  
This file is the core of the system. It pulls the JSON string from the BitcoinPool web server, serializes it, and prints the data to a formatted string.  
You will need to modify this code to enter your username where it needs it. 'var userGet = "/*Enter username here*/"'  
This file will not compile on its own; it does not include a main method.  
      
Program.cs  
  
This file is useful for debugging Serializer.cs. It simply creates a Serializer object and prints the data to console. This and serializer.cs together in a project will render a console debug when compiled. Leave this out of the project when compiling the Rainmeter plugin.
  
BitcoinPlugin.cs  

This file is used to create the Rainmeter plugin. I decided to only utilize certain data from the JSON object which is relevant to my interests. To add additional measurements:  
  
-Add the measurement under 'enum MeasureType { Username, Status }'  
-Under the Reload method, there is a switch case statement. Follow the format to add an additional case. 'case "unpaid": Type = MeasureType.Unpaid; break;'  
-Under the GetString method, there is another switch case statement. Here you are simply returning the MeasureType data: 'case MeasureType.Unpaid: return user.unpaid;' If the data is a string (and not numerical), the return statement should read 'return user.unpaid.ToString()'  
  
AssemblyInfo.cs  

Needed for compiling - do not touch.   
  
WHEN COMPILING: set the output directory to your Rainmeter plugins folder (ie C:\Program Files\Rainmeter\Plugins)  
  
I have included a Rainmeter skin file in the root directory for your convenience (PoolInfo.ini). It utilizes the default Illustro theme.  

Enjoy!
