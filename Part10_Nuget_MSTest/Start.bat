@echo off
CD "C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part10_Nuget_MSTest\MsTest"
mstest /testcontainer: Test.dll
PAUSE
csc /t:library Test.cs  -> Test.dll